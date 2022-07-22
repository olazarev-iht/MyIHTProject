using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareDBServices
{
	public interface IDynParamsDBService
	{
		public Task<IEnumerable<DynParamsModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<DynParamsModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(DynParamsModel model, CancellationToken cancellationToken);
		public Task<IEnumerable<DynParamsModel>> AddRangeAsync(IEnumerable<DynParamsModel> entities, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, DynParamsModel newData, CancellationToken cancellationToken);
		public Task UpdateDynParamValueAsync(DynParamsModel newData, CancellationToken cancellationToken);
		public Task UpdateDynParamValueByAPCDeviceNumAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, int paramValue, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
		public Task DeleteAllEntriesAsync(CancellationToken cancellationToken);
	}
}
