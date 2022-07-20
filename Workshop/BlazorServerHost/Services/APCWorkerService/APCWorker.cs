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

		public SingletonDataModel CurrentState { get; set; } = new();

		public event EventHandler? WorkerStatusChanged;

		public event EventHandler? DynamicDataChanged;
		public APCWorker(
			IParameterDataInfoManager parameterDataInfoManager,
			ILogger<APCWorkerService> logger)
		{
			_parameterDataInfoManager = parameterDataInfoManager ?? throw new ArgumentNullException(nameof(parameterDataInfoManager));

			_logger = logger ?? throw new ArgumentNullException(nameof(logger));


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

		public async Task RefreshDynamicDataAsync(int apcDeviceNum, ParamGroup paramGroup, ParamIds paramId)
		{
			try
			{
				// Get Dynamic Parameter from Mock DB (APC Device) after client had updated the APC Device
				var mockParameterData = await _parameterDataInfoManager.GetParamDataFromMockDBByAPCDeviceAndParamIdAsync(
					apcDeviceNum, 
					paramGroup,
					paramId, 
					CancellationToken.None);

				if (mockParameterData != null && mockParameterData.APCDevice != null && mockParameterData.DynParams != null) {
					// Update Dynamic Parameter in the Dynamic Params DB
					await _parameterDataInfoManager.UpdateDynParamValueByAPCDeviceNumAndParamIdAsync(
						mockParameterData.APCDevice.Num,
						mockParameterData.ParamGroupId,
						mockParameterData.DynParams.ParamId, 
						mockParameterData.DynParams.Value, 
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



