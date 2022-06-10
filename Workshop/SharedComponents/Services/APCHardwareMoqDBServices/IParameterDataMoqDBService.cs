﻿using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareMoqDBServices
{
	public interface IParameterDataMoqDBService
	{
		public Task<IEnumerable<ParameterDataModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<ParameterDataModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
		public Task<Guid> AddEntryAsync(ParameterDataModel model, CancellationToken cancellationToken);
		public Task UpdateEntryAsync(Guid id, ParameterDataModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
	}
}
