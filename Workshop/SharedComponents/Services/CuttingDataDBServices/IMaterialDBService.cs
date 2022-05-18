using SharedComponents.Models.CuttingData;

namespace SharedComponents.Services.CuttingDataDBServices
{
	public interface IMaterialDBService
	{
		public Task<IEnumerable<MaterialModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<MaterialModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(MaterialModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, MaterialModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
	}
}
