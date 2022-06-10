﻿using BlazorServerHost.Data;
using BlazorServerHost.Data.DataMapper;
using BlazorServerHost.Data.Models.APCHardwareMoq;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareMoqDBServices;

namespace BlazorServerHost.Services.APCHardwareMoqDBServices
{
	public class DynParamsDBService : IDynParamsDBService
	{
		private readonly IDbContextFactory<APCHardwareMoqDBContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public DynParamsDBService(IDbContextFactory<APCHardwareMoqDBContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<DynParamsModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.DynParams
				.AsNoTracking()
				.Select(p => _mapper.Map<DynParams, DynParamsModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<DynParamsModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.DynParams.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<DynParams, DynParamsModel>(entry);
		}

		public async Task<Guid> AddEntryAsync(DynParamsModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<DynParamsModel, DynParams>(model);

			await dbContext.DynParams.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task UpdateEntryAsync(Guid id, DynParamsModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.DynParams.SingleAsync(s => s.Id == id, cancellationToken);

			if (entry != null)
			{
				newData.Id = entry.Id;
				entry = _mapper.Map<DynParamsModel, DynParams>(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new DynParams() { Id = id, };

			dbContext.DynParams.Attach(stub);
			dbContext.DynParams.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}


