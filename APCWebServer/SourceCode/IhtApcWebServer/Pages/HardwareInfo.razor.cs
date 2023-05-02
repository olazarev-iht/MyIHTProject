using IhtApcWebServer.Services;
using Microsoft.AspNetCore.Components;

namespace IhtApcWebServer.Pages
{
	public partial class HardwareInfo : ComponentBase, IDisposable
	{
		[Inject]
		private ILogger<HardwareInfo> _logger { get; set; }

		[Inject]
		public IHardwareStatusService? HardwareStatus { get; set; }

		public bool IsInitialized => HardwareStatus != null;

		protected override void OnInitialized()
		{
			HardwareStatus.HardwareStatusChanged += HardwareStatus_HardwareStatusChanged;
			base.OnInitialized();
		}

		private async void HardwareStatus_HardwareStatusChanged(object? sender, EventArgs e)
		{
			try
			{
				await InvokeAsync(StateHasChanged);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occured while updating.");
			}
		}

		public void Dispose()
		{
			HardwareStatus.HardwareStatusChanged -= HardwareStatus_HardwareStatusChanged;
		}
	}
}
