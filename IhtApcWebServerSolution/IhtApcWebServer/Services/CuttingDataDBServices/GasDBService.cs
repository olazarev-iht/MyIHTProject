using IhtApcWebServer.Data;
using IhtApcWebServer.Data.DataMapper;
using IhtApcWebServer.Data.Models.CuttingData;
using SharedComponents.Models.CuttingData;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Services.CuttingDataDBServices;

namespace IhtApcWebServer.Services.CuttingDataDBServices
{
	public class GasDBService : IGasDBService
	{
		private readonly IDbContextFactory<CuttingDataDbContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public GasDBService(IDbContextFactory<CuttingDataDbContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<GasModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.Gas
				.AsNoTracking()
				.OrderBy(p => p.GasId)
				.Select(p => _mapper.Map<Gas, GasModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<GasModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.Gas.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<Gas, GasModel>(entry);
		}

		public async Task<Guid> AddEntryAsync(GasModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<GasModel, Gas>(model);

			await dbContext.Gas.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task UpdateEntryAsync(Guid id, GasModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.Gas.SingleAsync(s => s.Id == id, cancellationToken);

			if (entry != null)
			{
				newData.Id = entry.Id;
				entry = _mapper.Map<GasModel, Gas>(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new Gas() { Id = id, };

			dbContext.Gas.Attach(stub);
			dbContext.Gas.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
