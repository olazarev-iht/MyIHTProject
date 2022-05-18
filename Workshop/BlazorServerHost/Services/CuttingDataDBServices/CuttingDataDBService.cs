using BlazorServerHost.Data;
using BlazorServerHost.Data.DataMapper;
using BlazorServerHost.Data.Models.CuttingData;
using SharedComponents.Models.CuttingData;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Services.CuttingDataDBServices;

namespace BlazorServerHost.Services.CuttingDataDBServices
{
	public class CuttingDataDBService : ICuttingDataDBService
	{
		private readonly IDbContextFactory<CuttingDataDbContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public CuttingDataDBService(IDbContextFactory<CuttingDataDbContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<CuttingDataModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.CuttingData
				.Include(p => p.Gas)
				.Include(p => p.Nozzle)
				.Include(p => p.Material)
				.Select(p => _mapper.Map<CuttingData, CuttingDataModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<CuttingDataModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.CuttingData
				.Include(p => p.Gas)
				.Include(p => p.Nozzle)
				.Include(p => p.Material)
				.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<CuttingData, CuttingDataModel>(entry);
		}

		public async Task<Guid> AddEntryAsync(CuttingDataModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<CuttingDataModel, CuttingData>(model);

			await dbContext.CuttingData.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task UpdateEntryAsync(Guid id, CuttingDataModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.CuttingData.SingleAsync(s => s.Id == id, cancellationToken);

			if (entry != null)
			{
				newData.Id = entry.Id;
				entry = _mapper.Map<CuttingDataModel, CuttingData>(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new CuttingData() { Id = id, };

			dbContext.CuttingData.Attach(stub);
			dbContext.CuttingData.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
