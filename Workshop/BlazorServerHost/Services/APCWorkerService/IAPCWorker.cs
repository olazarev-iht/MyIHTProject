using SharedComponents.Models;

namespace BlazorServerHost.Services.APCWorkerService
{
	public interface IAPCWorker
	{
		SingletonDataModel CurrentState { get; }
		event EventHandler WorkerStatusChanged;
		event EventHandler DynamicDataChanged;
		Task RefreshDynamicDataAsync();
	}
}
