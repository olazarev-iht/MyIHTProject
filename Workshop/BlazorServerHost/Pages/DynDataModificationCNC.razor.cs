using BlazorServerHost.Services;
using BlazorServerHost.Services.APCWorkerService;
using Microsoft.AspNetCore.Components;

namespace BlazorServerHost.Pages
{
	public partial class DynDataModificationCNC : ComponentBase, IDisposable
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
