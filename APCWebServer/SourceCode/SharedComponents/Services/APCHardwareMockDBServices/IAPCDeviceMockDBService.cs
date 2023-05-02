using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareMockDBServices
{
	public interface IAPCDeviceMockDBService
	{
		public Task<IEnumerable<APCDeviceModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<APCDeviceModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(APCDeviceModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, APCDeviceModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
	}
}
