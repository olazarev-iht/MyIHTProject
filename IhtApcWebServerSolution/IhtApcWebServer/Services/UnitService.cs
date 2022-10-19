using Blazored.LocalStorage;

namespace IhtApcWebServer.Services
{
	public class UnitService
	{
		private bool _isInitialized = false;
		private bool _isInitializing = false;
		private readonly ILocalStorageService _localStorage;
		private readonly ILogger<UnitService> _logger;
		public bool IsPressureBar { get; private set; }
		public bool IsDistanceMetric { get; private set; }

		public UnitService(ILocalStorageService localStorage, IHttpContextAccessor accessor, ILogger<UnitService> logger)
		{
			_localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task EnsureInitializedAsync()
		{
			if (_isInitialized) return;

			if (_isInitializing && !_isInitialized)
			{
				do
				{
					await Task.Yield();
				} while (!_isInitialized);

				return;
			}

			_isInitializing = true;

			try
			{
				if (await _localStorage.ContainKeyAsync(nameof(IsPressureBar)))
				{
					IsPressureBar = await _localStorage.GetItemAsync<bool>(nameof(IsPressureBar));
				}
				else
				{
					await SetPressureUnitAsync(true);
				}

				if (await _localStorage.ContainKeyAsync(nameof(IsDistanceMetric)))
				{
					IsDistanceMetric = await _localStorage.GetItemAsync<bool>(nameof(IsDistanceMetric));
				}
				else
				{
					await SetDistanceUnitAsync(true);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occured while initializing UnitService");
			}

			_isInitialized = true;
		}

		public async Task SetPressureUnitAsync(bool isBar)
		{
			await _localStorage.SetItemAsync(nameof(IsPressureBar), isBar);
			IsPressureBar = isBar;
		}

		public async Task SetDistanceUnitAsync(bool isMetric)
		{
			await _localStorage.SetItemAsync(nameof(IsDistanceMetric), isMetric);
			IsDistanceMetric = isMetric;
		}
	}
}
