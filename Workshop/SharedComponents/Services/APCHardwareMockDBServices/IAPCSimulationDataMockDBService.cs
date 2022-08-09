using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareMockDBServices
{
    public interface IAPCSimulationDataMockDBService
    {
        public Task<IEnumerable<APCSimulationDataModel>> GetEntriesAsync(CancellationToken cancellationToken);
        public Task<APCSimulationDataModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<APCSimulationDataModel?> GetEntryByAddressAsync(int address, CancellationToken cancellationToken);
        public Task<Guid> AddEntryAsync(APCSimulationDataModel model, CancellationToken cancellationToken);
        public Task UpdateEntryAsync(Guid id, APCSimulationDataModel newData, CancellationToken cancellationToken);
        public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
    }
}
