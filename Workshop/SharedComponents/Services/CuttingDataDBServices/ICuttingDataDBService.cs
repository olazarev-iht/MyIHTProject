using SharedComponents.Models.CuttingData;

namespace SharedComponents.Services.CuttingDataDBServices
{
	public interface ICuttingDataDBService
	{
		public Task<List<CuttingDataModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<CuttingDataModel?> GetEntryByIdAsync(int id, CancellationToken cancellationToken);
		public Task<int?> AddEntryAsync(CuttingDataModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(int id, CuttingDataModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(int id, CancellationToken cancellationToken);
	}
}
