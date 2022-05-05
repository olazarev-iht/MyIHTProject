using BlazorServerHost.Features.Models;
using BlazorServerHost.Services;

namespace BlazorServerHost.Features.HeightControlFeature.Services
{
	public class HeightControlDataProvider: IDisposable
	{
		public event EventHandler? HeightControlDataChanged;
		public HeightControlModel CurrentHeightData { get; set; } = new();

		private readonly IHardwareStatusService _hardwareStatus;

		public HeightControlDataProvider(IHardwareStatusService hardwareStatus)
		{
			_hardwareStatus = hardwareStatus ?? throw new ArgumentNullException(nameof(hardwareStatus));

			_hardwareStatus.HardwareStatusChanged += _hardwareStatus_HardwareStatusChanged;
		}

		private void _hardwareStatus_HardwareStatusChanged(object? sender, EventArgs e)
		{
			if (_hardwareStatus.CurrentState.ActualHeight != CurrentHeightData.ActualHeight
			    || _hardwareStatus.CurrentState.SetHeight != CurrentHeightData.SetHeight)
			{
				CurrentHeightData.ActualHeight = _hardwareStatus.CurrentState.ActualHeight;
				CurrentHeightData.SetHeight = _hardwareStatus.CurrentState.SetHeight;

				OnHeightControlDataChanged();
			}
		}

		public void Dispose()
		{
			_hardwareStatus.HardwareStatusChanged -= _hardwareStatus_HardwareStatusChanged;
		}

		protected virtual void OnHeightControlDataChanged()
		{
			HeightControlDataChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
