using BlazorServerHost.Data;
using BlazorServerHost.Data.DataMapper;
using BlazorServerHost.Data.Models.APCHardwareMoq;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareMoqDBServices;

namespace BlazorServerHost.Services.APCHardwareMoqDBServices
{
	public class LiveParamsDBService : ILiveParamsDBService
	{
		private readonly IDbContextFactory<APCHardwareMoqDBContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public LiveParamsDBService(IDbContextFactory<APCHardwareMoqDBContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<LiveParamsModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.LiveParams
				.AsNoTracking()
				.Select(p => _mapper.Map<LiveParams, LiveParamsModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<LiveParamsModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.LiveParams.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<LiveParams, LiveParamsModel>(entry);
		}

		public async Task<Guid> AddEntryAsync(LiveParamsModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<LiveParamsModel, LiveParams>(model);

			await dbContext.LiveParams.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task UpdateEntryAsync(Guid id, LiveParamsModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.LiveParams.SingleAsync(s => s.Id == id, cancellationToken);

			if (entry != null)
			{
				newData.Id = entry.Id;
				entry = _mapper.Map<LiveParamsModel, LiveParams>(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new LiveParams() { Id = id, };

			dbContext.LiveParams.Attach(stub);
			dbContext.LiveParams.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}


