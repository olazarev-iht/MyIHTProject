using IhtApcWebServer.Data;
using IhtApcWebServer.Data.DataMapper;
using IhtApcWebServer.Data.Models.APCHardware;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareDBServices;

namespace IhtApcWebServer.Services.APCHardwareDBServices
{
	public class ConstParamsDBService : IConstParamsDBService
	{
		private readonly IDbContextFactory<APCHardwareDBContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public ConstParamsDBService(IDbContextFactory<APCHardwareDBContext> dbContextFactory, DbModelMapper mapper)
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

			// await dbContext.ConstParams.AddAsync(entity, cancellationToken);
			// await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task<IEnumerable<ConstParamsModel>> AddRangeAsync(IEnumerable<ConstParamsModel> entities, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = _mapper.Map<IEnumerable<ConstParamsModel>, IEnumerable<ConstParams>>(entities);

			//foreach(var entry in entries)
			//	dbContext.Entry<ParameterData>(entry).State = EntityState.Detached;

			await dbContext.Set<ConstParams>().AddRangeAsync(entries);
			await dbContext.SaveChangesAsync();

			return _mapper.Map<IEnumerable<ConstParams>, IEnumerable<ConstParamsModel>>(entries);

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

		public async Task DeleteAllEntriesAsync(CancellationToken cancellationToken, int? devicesAmount = null)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			//dbContext.RemoveRange(dbContext.ConstParams);

			//await dbContext.SaveChangesAsync(cancellationToken);

			string cmd = $"DELETE FROM ConstParams";

			if (devicesAmount != null)
			{
				cmd += $" Where Id in (Select dyn.ConstParamsId From DynParams dyn join ParameterDatas pd " +
					$" on dyn.Id = pd.DynParamsId join APCDEvices apc " +
					$" on pd.APCDEviceId = apc.Id  Where apc.Num <= {devicesAmount} )";
			}

			await dbContext.Database.ExecuteSqlRawAsync(cmd, cancellationToken);
		}
	}
}


