﻿using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareMockDBServices
{
	public interface IConstParamsMockDBService
	{
		public Task<IEnumerable<ConstParamsModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<ConstParamsModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(ConstParamsModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, ConstParamsModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
	}
}
