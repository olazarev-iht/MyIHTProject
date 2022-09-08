//using BlazorServerHost.Features.Models.CNC;
using BlazorServerHost.Services.APCWorkerService;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;
using SharedComponents.Models;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services;
using SharedComponents.Services.APCHardwareManagers;

namespace BlazorServerHost.Features.HeightControlFeature.Services.CNC
{
	public class DynDataModificationCNCDataProvider : IDisposable
	{
		public event EventHandler? DynamicAPCParamsDataChanged;

		private readonly ILogger<DynDataModificationCNCDataProvider> _logger;

		public int CurrentDeviceNumber { get; set; } = 1;

		public int CurrentSlaveId
        {
			get { return CurrentDeviceNumber + (int)IhtModbusCommunic.SlaveId.Id_Default; }
        }
		public string CurrentParamsType { get; set; } = "Ignition";

		public int APCDevicesCount 
		{ 
			get { return GeAPCDevicesNumber().Result; }
		}

		public bool IsCurrentDeviceBusy
		{
            get { return IsAnOtherUserWorkingWithDeviceNow(); } 
			
		}

		private readonly IAPCWorker _apcWorker;
		private readonly IParameterDataInfoManager _parameterDataInfoManager;
		private readonly IhtDevices _ihtDevices;

		public ParameterDataModel _paramHeatO2 = new ParameterDataModel();
		public ParameterDataModel _paramFuelGas = new ParameterDataModel();
		public ParameterDataModel _paramCutO2 = new ParameterDataModel();
		public ParameterDataModel _paramFlameAdjust = new ParameterDataModel();

		private bool _paramChangedFlag = false;

		private CancellationTokenSource tokenSource = null;

		// To define hwo is currently working with the device
		private static Guid[] currentlyInWorkDevices = new Guid[11];

		// TODO: take this value from the Authenticated user id
		private Guid _userId = Guid.NewGuid();

		public DynDataModificationCNCDataProvider(
			IAPCWorker apcWorker, 
			IParameterDataInfoManager parameterDataInfoManager,
			ILogger<DynDataModificationCNCDataProvider> logger,
			IhtDevices ihtDevices)
		{
			_apcWorker = apcWorker ?? throw new ArgumentNullException(nameof(apcWorker));

			_parameterDataInfoManager = parameterDataInfoManager ?? throw new ArgumentNullException(nameof(parameterDataInfoManager));

			_logger = logger ?? throw new ArgumentNullException(nameof(logger));

			_ihtDevices = ihtDevices ?? throw new ArgumentNullException(nameof(ihtDevices));

			_apcWorker.DynamicDataChanged += _apcWorkerService_DymanicDataChanged;

			CheckIfDynamicDataChangedAndCreateEventForDisplay().Wait();
		}

		public async void dynamicParamsDysplay_DynamicAPCParamsClientChanged(object? sender, EventArgs e)
		{
			var parameter = sender as ParameterDataModel;
			if (parameter == null || parameter.DynParams == null) return;

			// Update prameter value in the APC Device (Mock DB)
			await UpdateDynParamInAPCDeviceMockDBAsync(CurrentDeviceNumber, parameter.DynParams.Address, parameter.DynParams.Value);

			// Only to show the flow
			//await Task.Delay(TimeSpan.FromSeconds(5));

			await _apcWorker.RefreshDynamicDataAsync(CurrentDeviceNumber, parameter.DynParams.Address);
		}

		private bool IsAnOtherUserWorkingWithDeviceNow()
        {
			var returnVal = false;
			
			if (currentlyInWorkDevices[CurrentDeviceNumber] != Guid.Empty && currentlyInWorkDevices[CurrentDeviceNumber] != _userId)
            {
				returnVal = true;
			}

			return returnVal;
		}

		private void ReleaseAllTheDevices()
        {
			for (int i = 1; i < currentlyInWorkDevices.Length; i++)
			{
				if (currentlyInWorkDevices[i] == _userId)
				{
					currentlyInWorkDevices[i] = Guid.Empty;
				}
			}
		}


		SemaphoreSlim mutexModbusMaster = new SemaphoreSlim(1,1);

		public async void dynamicParamsDysplay_APCTorchPositionChanged(object? sender, EventArgs e)
		{
			var commandType = sender as string;
			if (string.IsNullOrWhiteSpace(commandType)) return;

			// If the device is busy - stop the command
			if (IsAnOtherUserWorkingWithDeviceNow()) return;

			// To prevent the mutex queue from growing
			if (mutexModbusMaster.CurrentCount == 0)
				return;

			// If the current device is free - set up it as busy by the current user
			if (currentlyInWorkDevices[CurrentDeviceNumber] == Guid.Empty)
			{
				// Release other devices are busy by the current user
				ReleaseAllTheDevices();

				// Set up the device as busy by the current user
				currentlyInWorkDevices[CurrentDeviceNumber] = _userId;
			}

			//Action<CancellationToken> doHeartBeatWork = null;

			await mutexModbusMaster.WaitAsync();

			tokenSource = new CancellationTokenSource();
			var token = tokenSource.Token;

			try
			{
				await Task.Run(async () => await StartSendingHeartBeatForTorchAsync(commandType, token), token);
			}
            catch (AggregateException ex1)
            {
                // catch whatever was thrown
                foreach (Exception eex in ex1.InnerExceptions)
                    Console.WriteLine(eex.Message);
            }
            catch (OperationCanceledException ex)
			{
                Console.WriteLine($"\n{nameof(OperationCanceledException)} thrown\n");

                if (ex.InnerException != null)
                {
                    var innerExMessage = ex.InnerException.Message;
                }

                var exMessage = ex.Message;
            }
            catch (Exception ex2)
			{
				//Console.WriteLine(ex2.Message);
			}
			finally
			{
				tokenSource?.Dispose();
				//tokenSource = null;
				mutexModbusMaster?.Release();
			}

		}

		public async void dynamicParamsDysplay_APCTorchPositionStoped(object? sender, EventArgs e)
		{
			await StopMovingTorchAsync(); 
		}

		public async Task StopMovingTorchAsync()
        {
			if (IsAnOtherUserWorkingWithDeviceNow()) return;

			// Set up the device as free
			currentlyInWorkDevices[CurrentDeviceNumber] = Guid.Empty;

			if (tokenSource != null) 
				tokenSource.Cancel();

			//Dispose token source instead of finally block
			//tokenSource?.Dispose();

			Console.WriteLine("\nTask cancellation requested.");

			await StopMoveTorchCommandAsync();
		}

		private async Task StartSendingHeartBeatForTorchAsync(string commandType, CancellationToken ct)
		{
			Task taskSendHeartBeat = null;

			// Cancellation was already requested
			if (ct.IsCancellationRequested)
			{
				Console.WriteLine($"Task {commandType} was cancelled before it got started. Device {CurrentDeviceNumber}");
				ct.ThrowIfCancellationRequested();
			}

			switch (commandType)
			{
				case "MoveTorchUp":
					taskSendHeartBeat = SendHeartBeatMoveTorchUpAsync();
					break;
				case "MoveTorchDown":
					taskSendHeartBeat = SendHeartBeatMoveTorchDownAsync();
					break;
				default: return;
			}

			while (true)
			{

				await taskSendHeartBeat;

				//In the production Delay must be < 0.750 sec
				int time_ms = 250;

				while (time_ms > 0)
                {
					await Task.Delay(10);
					time_ms -= 10;
					if (ct.IsCancellationRequested)
					{
						Console.WriteLine($"\nTask {commandType} cancelled. Device {CurrentDeviceNumber}");
						ct.ThrowIfCancellationRequested();
						break;
					}
				}
			}
		}

		private async Task StopMoveTorchCommandAsync()
		{
			// TODO: call APC device API function to Move Torch Up instead.
			//await Task.Run(() => { _logger.LogDebug("\nSent Command - StopTorch"); });
			
			await _ihtDevices.StopManUpAsync(CurrentSlaveId);
			await _ihtDevices.StopManDownAsync(CurrentSlaveId);

			_logger.LogDebug($"\n\n\n\nSent Command - Stop Torch. Device: {CurrentDeviceNumber}. User: {_userId}\n\n\n\n");
		}

		private async Task SendHeartBeatMoveTorchUpAsync()
		{
			// TODO: call APC device API function to Move Torch Up instead.
			//await Task.Run(() => { _logger.LogDebug("\nSent Command - MoveTorchUp"); });
			await _ihtDevices.MoveManUpAsync(CurrentSlaveId);

			_logger.LogDebug($"\nSent Command - Move Torch Up. Device {CurrentDeviceNumber}. User: {_userId}");
		}

		private async Task SendHeartBeatMoveTorchDownAsync()
		{
			// TODO: call APC device API function to Move Torch Down instead.
			//await Task.Run(() => { _logger.LogDebug("\nSent Command - MoveTorchDown"); });
			await _ihtDevices.MoveManDownAsync(CurrentSlaveId);

			_logger.LogDebug($"\nSent Command - Move Torch Down. Device {CurrentDeviceNumber}. User: {_userId}");
		}

		private async Task UpdateDynParamInAPCDeviceMockDBAsync(int deviceNum, int paramAddress, int paramValue, IhtModbusResult? ihtModbusResult = null)
        {
			await _parameterDataInfoManager.WriteHoldingRegistersAsync(deviceNum, paramAddress, paramValue, ihtModbusResult);
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

			await UpdateModelParamsFromDBAsync();

			if (_paramChangedFlag)
			{
				OnDynamicAPCParamsDataChanged();
			}
		}

		public async Task UpdateModelParamsFromDBAsync()
        {
			var dynParamsFromDB = await GetDynParamsFromDBAsync(CurrentDeviceNumber, CurrentParamsType);

			IfChangedUpdateModelParamFromDB(paramFromModel: ref _paramHeatO2, paramFromDB: dynParamsFromDB.HeatO2);
			IfChangedUpdateModelParamFromDB(paramFromModel: ref _paramFuelGas, paramFromDB: dynParamsFromDB.FuelGas);
			IfChangedUpdateModelParamFromDB(paramFromModel: ref _paramCutO2, paramFromDB: dynParamsFromDB.CutO2);
			IfChangedUpdateModelParamFromDB(paramFromModel: ref _paramFlameAdjust, paramFromDB: dynParamsFromDB.FlameAdjust);
		}

		public async Task<bool> RefreshDynamicDataModelToDisplayAsync()
        {
			try
			{
				var dynParamsFromDB = await GetDynParamsFromDBAsync(CurrentDeviceNumber, CurrentParamsType);

				_paramHeatO2 = dynParamsFromDB.HeatO2;
				_paramFuelGas = dynParamsFromDB.FuelGas;
				_paramCutO2 = dynParamsFromDB.CutO2;
				_paramFlameAdjust = dynParamsFromDB.FlameAdjust;
			}
			catch (Exception ex)
            {
				return false;
			}

			return true;
		}

		public async Task<(ParameterDataModel HeatO2, ParameterDataModel FuelGas, ParameterDataModel CutO2, ParameterDataModel FlameAdjust)> 
			GetDynParamsFromDBAsync(int currentDeviceNumber, string currentParamsType)
        {
			if (currentParamsType == "Heat") currentParamsType = "Cut";

			var apcDynamicParamsFromDB = await _parameterDataInfoManager.GetParamsByDeviceIdAndParamsTypeAsync(
				currentDeviceNumber, currentParamsType, CancellationToken.None);

			var paramHeatO2FromDB = apcDynamicParamsFromDB.FirstOrDefault(p => p.ParamName.ToLower().Contains("HeatO2".ToLower()));
			var paramFuelGasFromDB = apcDynamicParamsFromDB.FirstOrDefault(p => p.ParamName.ToLower().Contains("FuelGas".ToLower()));
			var paramCutO2FromDB = apcDynamicParamsFromDB.FirstOrDefault(p => p.ParamName.ToLower().Contains("CutO2".ToLower()));
			var paramFlameAdjustFromDB = apcDynamicParamsFromDB.FirstOrDefault(p => p.ParamName.ToLower().Contains("FlameAdjust".ToLower()));

			return (paramHeatO2FromDB, paramFuelGasFromDB, paramCutO2FromDB, paramFlameAdjustFromDB);
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
					if (paramFromModel.Id == paramFromDB.Id)
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
                    else
                    {
						throw new InvalidOperationException();
                    }
				}
			}
		}

		private async Task<int> GeAPCDevicesNumber()
        {
			return await _parameterDataInfoManager.GetAPCDevicesNumber(CancellationToken.None);
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


