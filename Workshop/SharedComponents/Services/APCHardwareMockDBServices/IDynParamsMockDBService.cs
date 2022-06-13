using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareMockDBServices
{
	public interface IDynParamsMockDBService
	{
		public Task<IEnumerable<DynParamsModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<DynParamsModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(DynParamsModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, DynParamsModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
	}
}
