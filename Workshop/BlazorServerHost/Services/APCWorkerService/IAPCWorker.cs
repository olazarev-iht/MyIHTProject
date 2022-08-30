using SharedComponents.Models;
using SharedComponents.Models.APCHardware;

namespace BlazorServerHost.Services.APCWorkerService
{
	public interface IAPCWorker
	{
		SingletonDataModel CurrentState { get; }
		event EventHandler WorkerStatusChanged;
		event EventHandler DynamicDataChanged;
		Task RefreshDynamicDataAsync(int deviceNum, int paramAddress);
		Task DoWork(CancellationToken stoppingToken);
	}
}
