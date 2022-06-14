using SharedComponents.Models;
using SharedComponents.Services;
using SharedComponents.Services.APCHardwareManagers;

namespace BlazorServerHost.Services.APCWorkerService
{
	//public class BackgroundAPCMonitor : BackgroundService
	//{
	//	private readonly IAPCWorkerService _workerService;

	//	public BackgroundAPCMonitor(IAPCWorkerService workerService)
	//	{
	//		_workerService = workerService;
	//	}

	//	protected override Task ExecuteAsync(CancellationToken stoppingToken)
	//	{
	//		return Task.CompletedTask;
	//	}
	//}

	public class APCWorker : IAPCWorker
	{
		private readonly ILogger<APCWorkerService> _logger;

		private readonly IHardwareAPCServise _hardwareAPCServise;

		private readonly IParameterDataInfoManager _parameterDataInfoManager;

		public SingletonDataModel CurrentState { get; set; } = new();

		public event EventHandler? WorkerStatusChanged;

		public event EventHandler? DynamicDataChanged;
		public APCWorker(
			IHardwareAPCServise hardwareAPCServise, 
			IParameterDataInfoManager parameterDataInfoManager, 
			ILogger<APCWorkerService> logger)
		{
			_hardwareAPCServise = hardwareAPCServise ?? throw new ArgumentNullException(nameof(hardwareAPCServise));

			_parameterDataInfoManager = parameterDataInfoManager ?? throw new ArgumentNullException(nameof(parameterDataInfoManager));

			_logger = logger ?? throw new ArgumentNullException(nameof(logger));

			InitializeSystem().Wait();

#pragma warning disable CS4014
			UpdateValues();
#pragma warning restore CS4014
		}

		private async Task UpdateValues()
		{
			while (true)
			{
				try
				{
					// TODO currently we read the whole APC model, but we may will read only Live data
					CurrentState = await _hardwareAPCServise.GetSingletonDataModelAsync(CancellationToken.None);

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

		public async Task RefreshDynamicDataAsync()
		{
			try
			{
				// TODO currently we read the whole APC model, but we may will read only Dynamic data
				CurrentState = await _hardwareAPCServise.GetSingletonDataModelAsync(CancellationToken.None);

				DynamicDataChanged?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while updating hardware values");
			}
		}

		private async Task InitializeSystem()
        {
			await _parameterDataInfoManager.InitializeParameterDataInfoAsync(CancellationToken.None);

		}
	}
}



