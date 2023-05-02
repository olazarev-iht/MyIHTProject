using IhtApcWebServer.Services;
using IhtApcWebServer.Services.APCWorkerService;
using Microsoft.AspNetCore.Components;

namespace IhtApcWebServer.Pages
{
	public partial class LiveAPCParamsInfo : ComponentBase, IDisposable
	{
		[Inject]
		private ILogger<HardwareInfo> _logger { get; set; }

		[Inject]
		public IAPCWorkerService? APCWorkerService { get; set; }

		public bool IsInitialized => APCWorkerService != null;

		protected override void OnInitialized()
		{
			//APCWorkerService.WorkerStatusChanged  += APCWorkerService_WorkerStatusChanged;
			base.OnInitialized();
		}

		private async void APCWorkerService_WorkerStatusChanged(object? sender, EventArgs e)
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
			//APCWorkerService.WorkerStatusChanged -= APCWorkerService_WorkerStatusChanged;
		}
	}
}
