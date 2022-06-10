using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareMoqDBServices
{
	public interface ILiveParamsDBService
	{
		public Task<IEnumerable<LiveParamsModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<LiveParamsModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(LiveParamsModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, LiveParamsModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
	}
}
