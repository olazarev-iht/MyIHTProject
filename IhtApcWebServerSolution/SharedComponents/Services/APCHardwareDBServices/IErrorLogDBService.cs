using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareDBServices
{
    public interface IErrorLogDBService
    {
        public Task<ErrorLogModel> GetEntryAsync(CancellationToken cancellationToken);
        public Task<ErrorLogModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<Guid> AddEntryAsync(ErrorLogModel model, CancellationToken cancellationToken);
        public Task UpdateEntryAsync(ErrorLogModel newData, CancellationToken cancellationToken);
        public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
        public Task DeleteAllEntriesAsync(CancellationToken cancellationToken);
    }
}
