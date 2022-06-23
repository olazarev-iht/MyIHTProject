using BlazorServerHost.Features.Models.CNC;
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

			var apcDynamicParamsFromDB = await _parameterDataInfoManager.GetDynParamsByDeviceIdAndParamsTypeAsync(
				CurrentDeviceNumber, CurrentParamsType, CancellationToken.None);

			var paramHeatO2FromDB = apcDynamicParamsFromDB.FirstOrDefault(p => p.ParamName.ToLower().Contains("HeatO2".ToLower()));
			var paramFuelGasFromDB = apcDynamicParamsFromDB.FirstOrDefault(p => p.ParamName.ToLower().Contains("FuelGas".ToLower()));
			var paramCutO2FromDB = apcDynamicParamsFromDB.FirstOrDefault(p => p.ParamName.ToLower().Contains("CutO2".ToLower()));

			IfChangedUpdateModelParamFromDB(paramFromModel: ref _paramHeatO2, paramFromDB: paramHeatO2FromDB);
			IfChangedUpdateModelParamFromDB(paramFromModel: ref _paramFuelGas, paramFromDB: paramFuelGasFromDB);
			IfChangedUpdateModelParamFromDB(paramFromModel: ref _paramCutO2, paramFromDB: paramCutO2FromDB);

			if (_paramChangedFlag)
			{
				OnDynamicAPCParamsDataChanged();
			}

			//var singletonAPCDynamicParamsDictionary = _apcWorker.CurrentState.HardwareAPCList.Select(apc =>
			//	new { Id = int.Parse(apc.DeviceName?.Last().ToString() ?? "0"), apc.DynamicParams }).ToDictionary(lp => lp.Id);
			//
			//for (var i = 1; i < singletonAPCDynamicParamsDictionary.Count + 1; i++)
			//{
			//	if (CurrentDynamicAPCParams.DynamicParamsInfos.Count == 0
			//		|| singletonAPCDynamicParamsDictionary[i].DynamicParams?.DynamicParam1 != (CurrentDynamicAPCParams.DynamicParamsInfos[i]?.DynamicParam1 ?? 0)
			//		|| singletonAPCDynamicParamsDictionary[i].DynamicParams?.DynamicParam1 != (CurrentDynamicAPCParams.DynamicParamsInfos[i]?.DynamicParam2 ?? 0)
			//		|| singletonAPCDynamicParamsDictionary[i].DynamicParams?.DynamicParam1 != (CurrentDynamicAPCParams.DynamicParamsInfos[i]?.DynamicParam3 ?? 0))
			//	{
			//		CurrentDynamicAPCParams.DynamicParamsInfos.ToList().ForEach(kvp =>
			//		{
			//			kvp.Value.DynamicParam1 = singletonAPCDynamicParamsDictionary[kvp.Key]?.DynamicParams?.DynamicParam1 ?? 0;
			//			kvp.Value.DynamicParam2 = singletonAPCDynamicParamsDictionary[kvp.Key]?.DynamicParams?.DynamicParam2 ?? 0;
			//			kvp.Value.DynamicParam3 = singletonAPCDynamicParamsDictionary[kvp.Key]?.DynamicParams?.DynamicParam3 ?? 0;
			//		});

			//		OnDynamicAPCParamsDataChanged();

			//		break;
			//	}
			//}
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


