using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareDBServices
{
	public interface IParameterDataDBService
	{
		public Task<IEnumerable<ParameterDataModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<IEnumerable<ParameterDataModel>> GetParamsByDeviceIdAndParamsTypeAsync(int DeviceId, string ParamsType, CancellationToken cancellationToken);
		public Task<ParameterDataModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(ParameterDataModel model, CancellationToken cancellationToken);
		public Task<IEnumerable<ParameterDataModel>> AddRangeAsync(IEnumerable<ParameterDataModel> entities, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, ParameterDataModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
		public Task DeleteAllEntriesAsync(CancellationToken cancellationToken);
	}
}
