using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.Models;

namespace SharedComponents.Services
{
	public interface IHardwareAPCServise
	{
		public Task<SingletonDataModel> GetSingletonDataModelAsync(CancellationToken cancellationToken);
		public Task<HardwareAPCModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid?> AddEntryAsync(HardwareAPCModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, HardwareAPCModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
	}
}
