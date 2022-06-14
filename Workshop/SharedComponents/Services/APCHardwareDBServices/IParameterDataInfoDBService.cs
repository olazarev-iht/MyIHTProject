using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareDBServices
{
	public interface IParameterDataInfoDBService
	{
		public Task<IEnumerable<ParameterDataInfoModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<ParameterDataInfoModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(ParameterDataInfoModel model, CancellationToken cancellationToken);
		public Task<IEnumerable<ParameterDataInfoModel>> AddRangeAsync(IEnumerable<ParameterDataInfoModel> entities, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, ParameterDataInfoModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
		public Task DeleteAllEntriesAsync(CancellationToken cancellationToken);
	}
}