using SharedComponents.Models;
using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCWorkerService
{
	public interface IAPCWorker
	{
		SingletonDataModel CurrentState { get; }
		event EventHandler LiveDataChanged;
		event EventHandler DynamicDataChanged;
		event EventHandler DynDataLoaded;
		Task RefreshDynamicDataAsync(int deviceNum, int paramAddress);
		Task DoWork(CancellationToken stoppingToken);
		void _apcWorkerService_LiveDataChanged(string? sender);
		void _apcWorkerService_DynDataLoaded();
	}
}