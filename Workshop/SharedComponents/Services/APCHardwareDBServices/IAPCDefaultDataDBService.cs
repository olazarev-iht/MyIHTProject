using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareDBServices
{
    public interface IAPCDefaultDataDBService
    {
		public Task<IEnumerable<APCDefaultDataModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<APCDefaultDataModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(APCDefaultDataModel model, CancellationToken cancellationToken);
		public Task<IEnumerable<APCDefaultDataModel>> AddRangeAsync(IEnumerable<APCDefaultDataModel> entities, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, APCDefaultDataModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
		public Task DeleteAllEntriesAsync(CancellationToken cancellationToken);
	}
}
