using SharedComponents.Models.CuttingData;

namespace SharedComponents.Services.CuttingDataDBServices
{
	public interface IGasDBService
	{
		public Task<IEnumerable<GasModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<GasModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(GasModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, GasModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
	}
}
