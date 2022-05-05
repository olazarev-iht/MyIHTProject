namespace BlazorServerHost.Services
{
	public class HardwareInfoModel
	{
		public double HeatingOxygenePressure { get; set; } = 0;
		public double CuttingOxygenePressure { get; set; } = 0;
		public double FuelGasPressure { get; set; } = 0;

		public double SetHeight { get; set; } = 10;
		public double ActualHeight { get; set; } = 20;
	}

	public interface IHardwareStatusService
	{
		HardwareInfoModel CurrentState { get; }
		event EventHandler HardwareStatusChanged;
	}

	public class BackgroundHardwareMonitor : BackgroundService
	{
		private readonly IHardwareStatusService _statusService;

		public BackgroundHardwareMonitor(IHardwareStatusService statusService)
		{
			_statusService = statusService;
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			return Task.CompletedTask;
		}
	}

	public class FakeHardwareStatusService : IHardwareStatusService
	{
		private readonly ILogger<FakeHardwareStatusService> _logger;
		public HardwareInfoModel CurrentState { get; } = new();

		public event EventHandler? HardwareStatusChanged;

		private Random _rng = new Random();
		private bool _updateHeight = true;

		public FakeHardwareStatusService(ILogger<FakeHardwareStatusService> logger)
		{
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
					var value = _rng.Next(-5, 5) * 1.2;
					if (CurrentState.FuelGasPressure < 6) value = Math.Abs(value);
					if (CurrentState.FuelGasPressure > 20) value = -Math.Abs(value);
					CurrentState.FuelGasPressure += value;

					value = _rng.Next(-5, 5) * 1.2;
					if (CurrentState.HeatingOxygenePressure < 6) value = Math.Abs(value);
					if (CurrentState.HeatingOxygenePressure > 20) value = -Math.Abs(value);
					CurrentState.HeatingOxygenePressure += value;

					value = _rng.Next(-5, 5) * 1.2;
					if (CurrentState.CuttingOxygenePressure < 6) value = Math.Abs(value);
					if (CurrentState.CuttingOxygenePressure > 20) value = -Math.Abs(value);
					CurrentState.CuttingOxygenePressure += value;

					if (_updateHeight)
					{
						value = _rng.Next(-2, 2) * 1.1;
						if (CurrentState.ActualHeight < 3) value = Math.Abs(value);
						if (CurrentState.ActualHeight > 15) value = -Math.Abs(value);
						CurrentState.ActualHeight += value;

						value = _rng.Next(-2, 2) * 1.1;
						if (CurrentState.SetHeight < 3) value = Math.Abs(value);
						if (CurrentState.SetHeight > 15) value = -Math.Abs(value);
						CurrentState.SetHeight += value;
					}

					_updateHeight = !_updateHeight;

					HardwareStatusChanged?.Invoke(this, EventArgs.Empty);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "An error occurred while updating hardware values");
				}
				await Task.Delay(TimeSpan.FromSeconds(2));
			}
		}
	}
}
