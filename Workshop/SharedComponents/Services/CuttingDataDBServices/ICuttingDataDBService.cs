using SharedComponents.Models.CuttingData;

namespace SharedComponents.Services.CuttingDataDBServices
{
	public interface ICuttingDataDBService
	{
		public Task<List<CuttingDataModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<CuttingDataModel?> GetEntryByIdAsync(string id, CancellationToken cancellationToken);
		public Task<string?> AddEntryAsync(CuttingDataModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(string id, CuttingDataModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(string id, CancellationToken cancellationToken);
	}
}
