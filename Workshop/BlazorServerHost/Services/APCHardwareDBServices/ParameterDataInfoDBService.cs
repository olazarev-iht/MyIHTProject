using BlazorServerHost.Data;
using BlazorServerHost.Data.DataMapper;
using BlazorServerHost.Data.Models.APCHardware;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareDBServices;

namespace BlazorServerHost.Services.APCHardwareDBServices
{
	public class ParameterDataInfoDBService : IParameterDataInfoDBService
	{
		private readonly IDbContextFactory<APCHardwareDBContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public ParameterDataInfoDBService(IDbContextFactory<APCHardwareDBContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<ParameterDataInfoModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.ParameterDataInfos
				.AsNoTracking()
				.Select(p => _mapper.Map<ParameterDataInfo, ParameterDataInfoModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<ParameterDataInfoModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.ParameterDataInfos.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<ParameterDataInfo, ParameterDataInfoModel>(entry);
		}

		public async Task<Guid> AddEntryAsync(ParameterDataInfoModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<ParameterDataInfoModel, ParameterDataInfo>(model);

			await dbContext.ParameterDataInfos.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task<IEnumerable<ParameterDataInfoModel>> AddRangeAsync(IEnumerable<ParameterDataInfoModel> entities, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = _mapper.Map<IEnumerable<ParameterDataInfoModel>, IEnumerable<ParameterDataInfo>>(entities);

			await dbContext.Set<ParameterDataInfo>().AddRangeAsync(entries);
			await dbContext.SaveChangesAsync();

			return _mapper.Map<IEnumerable<ParameterDataInfo>, IEnumerable<ParameterDataInfoModel>>(entries);

		}

		public async Task UpdateEntryAsync(Guid id, ParameterDataInfoModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.ParameterDataInfos.SingleAsync(s => s.Id == id, cancellationToken);

			if (entry != null)
			{
				newData.Id = entry.Id;
				entry = _mapper.Map<ParameterDataInfoModel, ParameterDataInfo>(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new ParameterDataInfo() { Id = id, };

			dbContext.ParameterDataInfos.Attach(stub);
			dbContext.ParameterDataInfos.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteAllEntriesAsync(CancellationToken cancellationToken, int? devicesAmount = null)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			//dbContext.RemoveRange(dbContext.ParameterDataInfos);

			//await dbContext.SaveChangesAsync(cancellationToken);

			string cmd = $"DELETE FROM ParameterDataInfos";

			if (devicesAmount != null)
			{
				cmd += $" Select pdi.Id From ParameterDataInfos pdi left join DynParams dyn on pdi.Id = dyn.ParameterDataInfoId" +
                    $" Where dyn.ParameterDataInfoId is null";
			}

			await dbContext.Database.ExecuteSqlRawAsync(cmd, cancellationToken);
		}
	}
}


