using SharedComponents.Models;

namespace BlazorServerHost.Services.APCWorkerService
{
	public interface IAPCWorkerService
	{
		SingletonDataModel CurrentState { get; }
		event EventHandler WorkerStatusChanged;
	}
}
