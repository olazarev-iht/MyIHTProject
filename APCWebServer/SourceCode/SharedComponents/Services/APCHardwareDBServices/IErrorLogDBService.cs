using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareDBServices
{
    public interface IErrorLogDBService
    {
        public Task<IEnumerable<ErrorLogModel>> GetEntriesAsync(CancellationToken cancellationToken);
        public Task<ErrorLogModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryByItemsValAsync(string errorCode, string errorMessage, int? slaveId = null, params string[] strArgs);
		public Task<Guid> AddEntryAsync(ErrorLogModel model, CancellationToken cancellationToken);
        public Task UpdateEntryAsync(ErrorLogModel newData, CancellationToken cancellationToken);
        public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
        public Task DeleteAllEntriesAsync(CancellationToken cancellationToken);
    }
}
