using IhtApcWebServer.Services.APCCommunic;
using Microsoft.Extensions.Options;
using SharedComponents.IhtData;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;
using SharedComponents.IhtModbusTable;
using SharedComponents.Models;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services;
using SharedComponents.Services.APCHardwareManagers;
using SharedComponents.Services.APCWorkerService;
using System.Diagnostics;

namespace IhtApcWebServer.Services.APCWorkerService
{
	public class APCWorker : IAPCWorker
	{
		private readonly ILogger<APCWorkerService> _logger;
		private readonly IParameterDataInfoManager _parameterDataInfoManager;
		private readonly IhtModbusCommunic _ihtModbusCommunic;
		private readonly Settings _settings;
		private readonly IhtDevices _ihtDevices;
		private readonly APCCommunicManager _apcCommunicManager;
		private readonly DataCommon _dataCommon;

		private const string DEFAULT_COM_PORT = "COM3";

		public SingletonDataModel CurrentState { get; set; } = new();

		public event EventHandler? LiveDataChanged;

		public event EventHandler? DynamicDataChanged;

		public event EventHandler? DynDataLoaded;

		public APCWorker(
			IParameterDataInfoManager parameterDataInfoManager,
			ILogger<APCWorkerService> logger,
			IhtModbusCommunic ihtModbusCommunic,
			IOptions<Settings> settings,
			IhtDevices ihtDevices,
			APCCommunicManager apcCommunicManager,
			DataCommon dataCommon)
		{
			_parameterDataInfoManager = parameterDataInfoManager ?? throw new ArgumentNullException(nameof(parameterDataInfoManager));

			_logger = logger ?? throw new ArgumentNullException(nameof(logger));

			_ihtModbusCommunic = ihtModbusCommunic ?? throw new ArgumentNullException(nameof(ihtModbusCommunic));

			_settings = settings != null ? settings.Value : throw new ArgumentNullException($"{nameof(settings)}");

			_ihtDevices = ihtDevices ?? throw new ArgumentNullException(nameof(ihtDevices));

			_apcCommunicManager = apcCommunicManager ?? throw new ArgumentNullException(nameof(apcCommunicManager));

			_dataCommon = dataCommon ?? throw new ArgumentNullException(nameof(dataCommon));

			InitializeAsync().Wait();

#pragma warning disable CS4014
			//DoWork(CancellationToken.None);
#pragma warning restore CS4014
		}

		public async Task DoWork(CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				try
				{
					// We read only Live data (ProcessInfo) and update existing model
					Stopwatch stopwatch = new Stopwatch();
					var modbusDatas = _ihtModbusCommunic.GetConnectedModbusDatas();

					stopwatch.Start();
					foreach (IhtModbusData modbusData in modbusDatas)
                    {
						IhtModbusResult ihtModbusResult = new();

						//byte apcSlaveId = (byte)modbusData.SlaveId;
						//ushort paramStartAddress = modbusData.GetAddrInfo(IhtModbusAddrAreas.eIdxAddrInfo.ProcessInfo).u16StartAddr;
						//ushort registerCount     = modbusData.GetAddrInfo(IhtModbusAddrAreas.eIdxAddrInfo.ProcessInfo).u16AddrNumber;
						//UInt16[] parameterValue = await _ihtModbusCommunic.ReadAsync(apcSlaveId, (ushort)paramStartAddress, registerCount, ihtModbusResult);

						// Update old data with the new and get an event in device.dataProcessInfo
						ihtModbusResult.Result = await _ihtDevices.Read_ProcessInfoAsync(modbusData, true);

						//var device = _ihtDevices.GetDevice(apcSlaveId);
						//device.dataProcessInfo;

						//Compare old and new data

						var selectedDevice = _ihtDevices.GetDevices().FirstOrDefault(d => d.IsCheckedTorch);

						if (selectedDevice != null) {
							if (modbusData.SlaveId == selectedDevice.SlaveId)
							{
								_dataCommon.UpdateDatas(modbusData);

							}
						}

					}
					long interval_ms = 500 - stopwatch.ElapsedMilliseconds;

					if (interval_ms > 0)
					{
						await Task.Delay((int)interval_ms, cancellationToken);
					}
					// Für alle nicht verbundenen Geräte die Process-Info Daten löschen
					_ihtDevices.ClrProcessInfoDatas();

					//LiveDataChanged?.Invoke(this, EventArgs.Empty);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "An error occurred while updating hardware values");
				}

				// Must be 0.2 msec
				//await Task.Delay(TimeSpan.FromSeconds(20));
			}

		}

		public async Task RefreshDynamicDataAsync(int apcSlaveId, int paramAddress, bool refresh)
		{
			try
			{
				// Get Dynamic Parameter from Mock DB (APC Device) after client had updated the APC Device
				IhtModbusResult ihtModbusResult = new();
				var parameterValue = await _ihtModbusCommunic.ReadAsync(apcSlaveId, (ushort)paramAddress, ihtModbusResult);

				if (ihtModbusResult.Result)
				{
					// Update Dynamic Parameter in the Dynamic Params DB
					await _parameterDataInfoManager.UpdateDynParamValueByDeviceNumAndAddressAsync(apcSlaveId, paramAddress, (int)parameterValue,
						CancellationToken.None);
				}


				if (refresh)
                {
					// Refresh always
					DynDataLoaded?.Invoke(this, EventArgs.Empty);
				}
				else
                {
					// Invoke DynamicDataChanged Event after the Dynamic Parameter had been updated
					DynamicDataChanged?.Invoke(this, EventArgs.Empty);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while updating hardware values");
			}
		}

		private async Task InitializeAsync()
		{
			
			await _parameterDataInfoManager.InitializeParameterDataInfoAsync(CancellationToken.None);

			// initialize CutingDataSequence table - we can implement if we need
			//await _parameterDataInfoManager.DeleteAllEntriesFromCutingDataSequenceTableAsync(CancellationToken.None);

			await _apcCommunicManager.Init(nameComPort: DEFAULT_COM_PORT, isSimulation: false, performResetDevices: false);

		}

		public void _apcWorkerService_LiveDataChanged(string? changedPropName)
		{
			LiveDataChanged?.Invoke(changedPropName, EventArgs.Empty);
		}

		public void _apcWorkerService_DynDataLoaded()
		{
			DynDataLoaded?.Invoke(this, EventArgs.Empty);
		}
	}
}



