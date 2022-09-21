using Microsoft.Extensions.Options;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;
using SharedComponents.IhtModbusTable;
using SharedComponents.Models;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services;
using SharedComponents.Services.APCHardwareManagers;
using SharedComponents.Services.APCWorkerService;
using System.Diagnostics;

namespace BlazorServerHost.Services.APCWorkerService
{
	public class APCWorker : IAPCWorker
	{
		private readonly ILogger<APCWorkerService> _logger;
		private readonly IParameterDataInfoManager _parameterDataInfoManager;
		private readonly IhtModbusCommunic _ihtModbusCommunic;
		private readonly Settings _settings;
		private readonly IhtDevices _ihtDevices;

		public SingletonDataModel CurrentState { get; set; } = new();

		public event EventHandler? LiveDataChanged;

		public event EventHandler? DynamicDataChanged;
		public APCWorker(
			IParameterDataInfoManager parameterDataInfoManager,
			ILogger<APCWorkerService> logger,
			IhtModbusCommunic ihtModbusCommunic,
			IOptions<Settings> settings,
			IhtDevices ihtDevices
			)
		{
			_parameterDataInfoManager = parameterDataInfoManager ?? throw new ArgumentNullException(nameof(parameterDataInfoManager));

			_logger = logger ?? throw new ArgumentNullException(nameof(logger));

			_ihtModbusCommunic = ihtModbusCommunic ?? throw new ArgumentNullException(nameof(ihtModbusCommunic));

			_settings = settings != null ? settings.Value : throw new ArgumentNullException($"{nameof(settings)}");

			_ihtDevices = ihtDevices ?? throw new ArgumentNullException(nameof(ihtDevices));

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
					// TODO currently we read the whole APC model, but we may will read only Live data
					//CurrentState = await _hardwareAPCServise.GetSingletonDataModelAsync(CancellationToken.None);
					//var parameterValue = await _ihtModbusCommunic.ReadAsync(apcSlaveId, (ushort)paramStartAddress, registerCount, ihtModbusResult);
					Stopwatch stopwatch = new Stopwatch();
					var modbusDatas = _ihtModbusCommunic.GetConnectedModbusDatas();

					stopwatch.Start();
					foreach (IhtModbusData modbusData in modbusDatas)
                    {
						IhtModbusResult ihtModbusResult = new();

						byte apcSlaveId = (byte)modbusData.SlaveId;
						ushort paramStartAddress = modbusData.GetAddrInfo(IhtModbusAddrAreas.eIdxAddrInfo.ProcessInfo).u16StartAddr;
						ushort registerCount     = modbusData.GetAddrInfo(IhtModbusAddrAreas.eIdxAddrInfo.ProcessInfo).u16AddrNumber;
						UInt16[] parameterValue = await _ihtModbusCommunic.ReadAsync(apcSlaveId, (ushort)paramStartAddress, registerCount, ihtModbusResult);

						// Update old data with the new and get an event in device.dataProcessInfo
						ihtModbusResult.Result = await _ihtDevices.Read_ProcessInfoAsync(modbusData, true);

						var device = _ihtDevices.GetDevice(apcSlaveId);
						//device.dataProcessInfo;

						//Compare old and new data

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

		public async Task RefreshDynamicDataAsync(int apcSlaveId, int paramAddress)
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

				// Invoke DynamicDataChanged Event after the Dynamic Parameter had been updated
				DynamicDataChanged?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while updating hardware values");
			}
		}

		private async Task InitializeAsync()
		{
			await _parameterDataInfoManager.InitializeParameterDataInfoAsync(CancellationToken.None);

		}

		public void _apcWorkerService_LiveDataChanged(object? sender, EventArgs e)
		{
			LiveDataChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}



