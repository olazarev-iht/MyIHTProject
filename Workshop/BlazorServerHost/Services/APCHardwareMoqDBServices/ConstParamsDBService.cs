using BlazorServerHost.Data;
using BlazorServerHost.Data.DataMapper;
using BlazorServerHost.Data.Models.APCHardwareMoq;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareMoqDBServices;

namespace BlazorServerHost.Services.APCHardwareMoqDBServices
{
	public class ConstParamsDBService : IConstParamsDBService
	{
		private readonly IDbContextFactory<APCHardwareMoqDBContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public ConstParamsDBService(IDbContextFactory<APCHardwareMoqDBContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<ConstParamsModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.ConstParams
				.AsNoTracking()
				.Select(p => _mapper.Map<ConstParams, ConstParamsModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<ConstParamsModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.ConstParams.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<ConstParams, ConstParamsModel>(entry);
		}

		public async Task<Guid> AddEntryAsync(ConstParamsModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<ConstParamsModel, ConstParams>(model);

			await dbContext.ConstParams.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task UpdateEntryAsync(Guid id, ConstParamsModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.ConstParams.SingleAsync(s => s.Id == id, cancellationToken);

			if (entry != null)
			{
				newData.Id = entry.Id;
				entry = _mapper.Map<ConstParamsModel, ConstParams>(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new ConstParams() { Id = id, };

			dbContext.ConstParams.Attach(stub);
			dbContext.ConstParams.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}


