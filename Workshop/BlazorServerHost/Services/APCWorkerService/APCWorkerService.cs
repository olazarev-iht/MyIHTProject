using SharedComponents.Models;
using SharedComponents.Services;

namespace BlazorServerHost.Services.APCWorkerService
{
	public class BackgroundAPCMonitor : BackgroundService
	{
		private readonly IAPCWorkerService _workerService;

		public BackgroundAPCMonitor(IAPCWorkerService workerService)
		{
			_workerService = workerService;
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			return Task.CompletedTask;
		}
	}

	public class APCWorkerService : IAPCWorkerService
	{
		private readonly ILogger<APCWorkerService> _logger;

		private readonly IHardwareAPCServise _hardwareAPCServise;

		public SingletonDataModel CurrentState { get; set; } = new();

		public event EventHandler? WorkerStatusChanged;


		public APCWorkerService(IHardwareAPCServise hardwareAPCServise, ILogger<APCWorkerService> logger)
		{
			_hardwareAPCServise = hardwareAPCServise ?? throw new ArgumentNullException(nameof(hardwareAPCServise));

			_logger = logger ?? throw new ArgumentNullException(nameof(logger));

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
					CurrentState = await _hardwareAPCServise.GetSingletonDataModelAsync(CancellationToken.None);

					WorkerStatusChanged?.Invoke(this, EventArgs.Empty);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "An error occurred while updating hardware values");
				}
				await Task.Delay(TimeSpan.FromSeconds(20));
			}
		}
	}
}


