using BlazorServerHost.Data;
using BlazorServerHost.Data.DataMapper;
using BlazorServerHost.Data.Models.CuttingData;
using SharedComponents.Models.CuttingData;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Services.CuttingDataDBServices;

namespace BlazorServerHost.Services.CuttingDataDBServices
{
	public class NozzleDBService : INozzleDBService
	{
		private readonly IDbContextFactory<CuttingDataDbContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public NozzleDBService(IDbContextFactory<CuttingDataDbContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<NozzleModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.Nozzle
				.AsNoTracking()
				.OrderBy(p => p.Name)
				.Select(p => _mapper.Map<Nozzle, NozzleModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<NozzleModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.Nozzle.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<Nozzle, NozzleModel>(entry);
		}

		public async Task<Guid> AddEntryAsync(NozzleModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<NozzleModel, Nozzle>(model);

			await dbContext.Nozzle.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task UpdateEntryAsync(Guid id, NozzleModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.Nozzle.SingleAsync(s => s.Id == id, cancellationToken);

			if (entry != null)
			{
				newData.Id = entry.Id;
				entry = _mapper.Map<NozzleModel, Nozzle>(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new Nozzle() { Id = id, };

			dbContext.Nozzle.Attach(stub);
			dbContext.Nozzle.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}


