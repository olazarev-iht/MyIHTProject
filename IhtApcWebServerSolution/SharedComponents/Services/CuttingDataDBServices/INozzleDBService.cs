using SharedComponents.Models.CuttingData;

namespace SharedComponents.Services.CuttingDataDBServices
{
	public interface INozzleDBService
	{
		public Task<IEnumerable<NozzleModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<NozzleModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(NozzleModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, NozzleModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
	}
}
