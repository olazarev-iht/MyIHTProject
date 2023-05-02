﻿using SharedComponents.Models.CuttingData;

namespace SharedComponents.Services.CuttingDataDBServices
{
	public interface ICuttingDataDBService
	{
		public Task<List<CuttingDataModel>> GetEntriesAsync(CancellationToken cancellationToken);
		public Task<List<CuttingDataModel>> GetCustomEntriesAsync(CancellationToken cancellationToken);
        public Task<List<CuttingDataModel>> GetEntriesByGasTypeAsync(int gasTypeId, CancellationToken cancellationToken);
		public Task<CuttingDataModel?> GetEntryByIdAsync(int id, CancellationToken cancellationToken);
		public Task<CuttingDataModel?> GetEntryByGasIdAndIdAsync(int id, int gasTypeId, CancellationToken cancellationToken);
		public Task<int?> AddEntryAsync(CuttingDataModel model, CancellationToken cancellationToken);
		//public Task<int?> AddEntryFromArchiveAsync(CuttingDataModel model, CancellationToken cancellationToken);
		public Task AddListFromArchiveAsync(List<CuttingDataModel> modelList, CancellationToken cancellationToken);
        public Task UpdateEntryAsync(int id, CuttingDataModel newData, CancellationToken cancellationToken);
		public Task DeleteEntryAsync(int id, CancellationToken cancellationToken);
		public Task DeleteAllEntriesFromSequenceAsync(CancellationToken cancellationToken);
	}
}