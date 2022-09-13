using Microsoft.Extensions.Options;
using SharedComponents.IhtModbus;
using SharedComponents.IhtModbusTable;
using SharedComponents.Models;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services;
using SharedComponents.Services.APCHardwareManagers;

namespace BlazorServerHost.Services.APCWorkerService
{
	public class APCWorker : IAPCWorker
	{
		private readonly ILogger<APCWorkerService> _logger;
		private readonly IParameterDataInfoManager _parameterDataInfoManager;
		private readonly IhtModbusCommunic _ihtModbusCommunic;
		private readonly Settings _settings;

		public SingletonDataModel CurrentState { get; set; } = new();

		public event EventHandler? WorkerStatusChanged;

		public event EventHandler? DynamicDataChanged;
		public APCWorker(
			IParameterDataInfoManager parameterDataInfoManager,
			ILogger<APCWorkerService> logger,
			IhtModbusCommunic ihtModbusCommunic,
			IOptions<Settings> settings
			)
		{
			_parameterDataInfoManager = parameterDataInfoManager ?? throw new ArgumentNullException(nameof(parameterDataInfoManager));

			_logger = logger ?? throw new ArgumentNullException(nameof(logger));

			_ihtModbusCommunic = ihtModbusCommunic ?? throw new ArgumentNullException(nameof(ihtModbusCommunic));

			_settings = settings != null ? settings.Value : throw new ArgumentNullException($"{nameof(settings)}");

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

					WorkerStatusChanged?.Invoke(this, EventArgs.Empty);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "An error occurred while updating hardware values");
				}

				// Must be 0.2 msec
				await Task.Delay(TimeSpan.FromSeconds(20));
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
	}
}



