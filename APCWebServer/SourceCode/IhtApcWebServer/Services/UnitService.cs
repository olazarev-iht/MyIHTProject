using Blazored.LocalStorage;
using SharedComponents.IhtDev;

namespace IhtApcWebServer.Services
{
	public class UnitService
	{
		private bool _isInitialized = false;
		private bool _isInitializing = false;

		private IhtDevices _ihtDevices;

		private readonly ILocalStorageService _localStorage;
		private readonly ILogger<UnitService> _logger;
		public static IhtDevices.PressureUnit PressureUnit { get; private set; }
		public static IhtDevices.LengthUnit LengthUnit { get; private set; }

		public UnitService(
			ILocalStorageService localStorage, 
			IHttpContextAccessor accessor, 
			ILogger<UnitService> logger)
		{
			_localStorage = localStorage ?? throw new ArgumentNullException(nameof(localStorage));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));

			_ihtDevices = IhtDevices.GetIhtDevices();
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
				if (await _localStorage.ContainKeyAsync(nameof(PressureUnit)))
				{
					PressureUnit = await _localStorage.GetItemAsync<IhtDevices.PressureUnit>(nameof(PressureUnit));
				}
				else
				{
					await SetPressureUnitAsync(IhtDevices.PressureUnit.IsPressureBar);
				}

				if (await _localStorage.ContainKeyAsync(nameof(LengthUnit)))
				{
					LengthUnit = await _localStorage.GetItemAsync<IhtDevices.LengthUnit>(nameof(LengthUnit));
				}
				else
				{
					await SetDistanceUnitAsync(IhtDevices.LengthUnit.IsUnitMm);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occured while initializing UnitService");
			}

			_isInitialized = true;
		}

		public async Task SetPressureUnitAsync(IhtDevices.PressureUnit pressureUnit)
		{
			await _localStorage.SetItemAsync(nameof(PressureUnit), pressureUnit);

			PressureUnit = pressureUnit;

			_ihtDevices.CurrPressureUnit = pressureUnit;
		}

		public async Task SetDistanceUnitAsync(IhtDevices.LengthUnit lengthUnit)
		{
			await _localStorage.SetItemAsync(nameof(LengthUnit), lengthUnit);

			LengthUnit = lengthUnit;

			_ihtDevices.CurrLengthUnit = lengthUnit;
		}
	}
}
