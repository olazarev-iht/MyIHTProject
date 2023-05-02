using SharedComponents.Models;

namespace IhtApcWebServer.Services.APCWorkerService
{
	public interface IAPCWorkerService
	{
		SingletonDataModel CurrentState { get; }
		event EventHandler WorkerStatusChanged;
		event EventHandler DynamicDataChanged;
		Task RefreshDynamicDataAsync();
	}
}
