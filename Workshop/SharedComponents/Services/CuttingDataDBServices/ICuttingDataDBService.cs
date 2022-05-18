using SharedComponents.Models.CuttingData;

namespace SharedComponents.Services.CuttingDataDBServices
{
	public interface ICuttingDataDBService
	{
		public Task<IEnumerable<CuttingDataModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<CuttingDataModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(CuttingDataModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, CuttingDataModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
	}
}
