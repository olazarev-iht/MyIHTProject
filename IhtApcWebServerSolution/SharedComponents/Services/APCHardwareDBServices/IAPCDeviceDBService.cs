using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareDBServices
{
	public interface IAPCDeviceDBService
	{
		public Task<IEnumerable<APCDeviceModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<int> GetDevicesCountAsync(CancellationToken cancellationToken);
		public Task<APCDeviceModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<APCDeviceModel?> GetEntryByDevNumAsync(int id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(APCDeviceModel model, CancellationToken cancellationToken);
		public Task<IEnumerable<APCDeviceModel>> AddRangeAsync(IEnumerable<APCDeviceModel> entities, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, APCDeviceModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
		public Task DeleteAllEntriesAsync(CancellationToken cancellationToken);
	}
}
