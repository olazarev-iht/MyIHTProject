using IhtApcWebServer.Data;
using IhtApcWebServer.Extensions;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models;
using SharedComponents.Services;

namespace IhtApcWebServer.Services
{
	public class CuttingParametersService : ICuttingParametersService
	{
		private readonly IDbContextFactory<CuttingParametersDbContext> _dbContextFactory;

		public CuttingParametersService(IDbContextFactory<CuttingParametersDbContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
		}

		public async Task<PagedResult<CuttingParametersModel>> GetEntriesAsync(int skip, int take, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.CuttingParameters
				.AsNoTracking()
				.OrderBy(p => p.Id)
				.Skip(skip)
				.Take(take)
				.Select(p => p.ToModel())
				.ToArrayAsync(cancellationToken);

			return new PagedResult<CuttingParametersModel>()
			{
				Entries = entries,
				StartIndex = skip,
				PageSize = take,
				TotalEntries = await dbContext.CuttingParameters.CountAsync(cancellationToken),
			};
		}

		public async Task<CuttingParametersModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.CuttingParameters.SingleOrDefaultAsync(s => s.Id == id, cancellationToken);

			return entry?.ToModel();
		}

		public async Task<Guid> AddEntryAsync(CuttingParametersModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = model.FromModel();

			await dbContext.CuttingParameters.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task UpdateEntryAsync(Guid id, CuttingParametersModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.CuttingParameters.SingleAsync(s => s.Id == id, cancellationToken);
			entry.CopyFromModel(newData);
			await dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new CuttingParameterSet() { Id = id, };

			dbContext.CuttingParameters.Attach(stub);
			dbContext.CuttingParameters.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
