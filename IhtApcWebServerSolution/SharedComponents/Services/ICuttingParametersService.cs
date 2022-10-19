using SharedComponents.Models;

namespace SharedComponents.Services
{
	public interface ICuttingParametersService
	{
		public Task<PagedResult<CuttingParametersModel>> GetEntriesAsync(int skip, int take, CancellationToken cancellationToken);
		public Task<CuttingParametersModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(CuttingParametersModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, CuttingParametersModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
	}
}
