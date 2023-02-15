using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareDBServices
{
    public interface IConfigSettingsDBService
    {
		public Task<ConfigSettingsModel> GetEntryAsync(CancellationToken cancellationToken);
		public Task<ConfigSettingsModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(ConfigSettingsModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(ConfigSettingsModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
		public Task DeleteAllEntriesAsync(CancellationToken cancellationToken);
	}
}
