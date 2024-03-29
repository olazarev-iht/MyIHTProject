﻿using BlazorServerHost.Features.Models.CNC;
using BlazorServerHost.Services.APCWorkerService;
using SharedComponents.Models;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services;
using SharedComponents.Services.APCHardwareManagers;

namespace BlazorServerHost.Features.HeightControlFeature.Services.CNC
{
	public class DynDataModificationCNCDataProvider : IDisposable
	{
		public event EventHandler? DynamicAPCParamsDataChanged;

		//public DynDataModificationParamsModel CurrentDynamicAPCParams { get; set; }
		//public DynamicAPCParamsModel CurrentDynamicAPCParams { get; set; } = new();

		public int CurrentDeviceNumber { get; set; } = 1;
		public string CurrentParamsType { get; set; } = "Ignition";

		private readonly IAPCWorker _apcWorker;

		private readonly IParameterDataInfoManager _parameterDataInfoManager;

		public ParameterDataModel _paramHeatO2 = new ParameterDataModel();
		public ParameterDataModel _paramFuelGas = new ParameterDataModel();
		public ParameterDataModel _paramCutO2 = new ParameterDataModel();

		private bool _paramChangedFlag = false;

		public DynDataModificationCNCDataProvider(IAPCWorker apcWorker, IParameterDataInfoManager parameterDataInfoManager)
		{
			_apcWorker = apcWorker ?? throw new ArgumentNullException(nameof(apcWorker));

			_parameterDataInfoManager = parameterDataInfoManager ?? throw new ArgumentNullException(nameof(parameterDataInfoManager));

			_apcWorker.DynamicDataChanged += _apcWorkerService_DymanicDataChanged;

			CheckIfDynamicDataChangedAndCreateEventForDisplay().Wait();
		}

		public async void dynamicParamsDysplay_DynamicAPCParamsClientChanged(object? sender, EventArgs e)
		{
			await _parameterDataInfoManager.UpdateDynParamValueAsync(newData: (sender as ParameterDataModel)?.DynParams, CancellationToken.None);

			// Only to show the flow
			//await Task.Delay(TimeSpan.FromSeconds(5));

			await _apcWorker.RefreshDynamicDataAsync();
		}

		private async void _apcWorkerService_DymanicDataChanged(object? sender, EventArgs e)
		{
			await CheckIfDynamicDataChangedAndCreateEventForDisplay();
		}
	
		private async Task CheckIfDynamicDataChangedAndCreateEventForDisplay()
		{
			_paramChangedFlag = false;

			// New: Get Dyn params data from the DB instead of the _apcWorker.CurrentState
			// So, we get all the dynamic params for the current devices and current params type

			var dynParamsFromDB = await GetDynParamsFromDBAsync(CurrentDeviceNumber, CurrentParamsType);

			IfChangedUpdateModelParamFromDB(paramFromModel: ref _paramHeatO2, paramFromDB: dynParamsFromDB.HeatO2);
			IfChangedUpdateModelParamFromDB(paramFromModel: ref _paramFuelGas, paramFromDB: dynParamsFromDB.FuelGas);
			IfChangedUpdateModelParamFromDB(paramFromModel: ref _paramCutO2, paramFromDB: dynParamsFromDB.CutO2);

			if (_paramChangedFlag)
			{
				OnDynamicAPCParamsDataChanged();
			}
		}

		public async Task<bool> RefreshDynamicDataModelToDisplayAsync()
        {
			try
			{
				var dynParamsFromDB = await GetDynParamsFromDBAsync(CurrentDeviceNumber, CurrentParamsType);

				_paramHeatO2 = dynParamsFromDB.HeatO2;
				_paramFuelGas = dynParamsFromDB.FuelGas;
				_paramCutO2 = dynParamsFromDB.CutO2;
			}
			catch (Exception ex)
            {
				return false;
			}

			return true;
		}

		public async Task<(ParameterDataModel HeatO2, ParameterDataModel FuelGas, ParameterDataModel CutO2)> GetDynParamsFromDBAsync(
			int currentDeviceNumber, string currentParamsType)
        {
			var apcDynamicParamsFromDB = await _parameterDataInfoManager.GetDynParamsByDeviceIdAndParamsTypeAsync(
				currentDeviceNumber, currentParamsType, CancellationToken.None);

			var paramHeatO2FromDB = apcDynamicParamsFromDB.FirstOrDefault(p => p.ParamName.ToLower().Contains("HeatO2".ToLower()));
			var paramFuelGasFromDB = apcDynamicParamsFromDB.FirstOrDefault(p => p.ParamName.ToLower().Contains("FuelGas".ToLower()));
			var paramCutO2FromDB = apcDynamicParamsFromDB.FirstOrDefault(p => p.ParamName.ToLower().Contains("CutO2".ToLower()));

			return (paramHeatO2FromDB, paramFuelGasFromDB, paramCutO2FromDB);
		}

		private void IfChangedUpdateModelParamFromDB(ref ParameterDataModel paramFromModel, ParameterDataModel? paramFromDB)
		{
			if (paramFromDB != null)
			{
				if (paramFromModel.Id == Guid.Empty)
				{
					paramFromModel = paramFromDB;
				}
				else
				{
					if (paramFromDB.DynParams != null && paramFromModel.DynParams != null)
					{
						if (paramFromModel.DynParams.Value != paramFromDB.DynParams.Value)
						{
							paramFromModel.DynParams.Value = paramFromDB.DynParams.Value;

							_paramChangedFlag = true;
						}
					}
				}
			}
		}

		public void Dispose()
		{
			_apcWorker.DynamicDataChanged -= _apcWorkerService_DymanicDataChanged;
		}

		protected virtual void OnDynamicAPCParamsDataChanged()
		{
			DynamicAPCParamsDataChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}


