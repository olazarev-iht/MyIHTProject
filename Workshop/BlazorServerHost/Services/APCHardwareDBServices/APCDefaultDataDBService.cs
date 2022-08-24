using BlazorServerHost.Data;
using BlazorServerHost.Data.DataMapper;
using BlazorServerHost.Data.Models.APCHardware;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareDBServices;

namespace BlazorServerHost.Services
{
    public class APCDefaultDataDBService : IAPCDefaultDataDBService
    {
		private readonly IDbContextFactory<APCHardwareDBContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public APCDefaultDataDBService(IDbContextFactory<APCHardwareDBContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<APCDefaultDataModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.APCDefaultDatas
				.AsNoTracking()
				.Select(p => _mapper.Map<APCDefaultData, APCDefaultDataModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<APCDefaultDataModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.APCDefaultDatas.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<APCDefaultData, APCDefaultDataModel>(entry);
		}

		public async Task<Guid> AddEntryAsync(APCDefaultDataModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<APCDefaultDataModel, APCDefaultData>(model);

			// await dbContext.ConstParams.AddAsync(entity, cancellationToken);
			// await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task<IEnumerable<APCDefaultDataModel>> AddRangeAsync(IEnumerable<APCDefaultDataModel> entities, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = _mapper.Map<IEnumerable<APCDefaultDataModel>, IEnumerable<APCDefaultData>>(entities);

			//foreach(var entry in entries)
			//	dbContext.Entry<ParameterData>(entry).State = EntityState.Detached;

			await dbContext.Set<APCDefaultData>().AddRangeAsync(entries);
			await dbContext.SaveChangesAsync();

			return _mapper.Map<IEnumerable<APCDefaultData>, IEnumerable<APCDefaultDataModel>>(entries);

		}

		public async Task UpdateEntryAsync(Guid id, APCDefaultDataModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.APCDefaultDatas.SingleAsync(s => s.Id == id, cancellationToken);

			if (entry != null)
			{
				newData.Id = entry.Id;
				entry = _mapper.Map<APCDefaultDataModel, APCDefaultData>(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new APCDefaultData() { Id = id, };

			dbContext.APCDefaultDatas.Attach(stub);
			dbContext.APCDefaultDatas.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteAllEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			//dbContext.RemoveRange(dbContext.ConstParams);

			//await dbContext.SaveChangesAsync(cancellationToken);

			string cmd = $"DELETE FROM APCDefaultDatas";

			await dbContext.Database.ExecuteSqlRawAsync(cmd, cancellationToken);
		}
	}
}
