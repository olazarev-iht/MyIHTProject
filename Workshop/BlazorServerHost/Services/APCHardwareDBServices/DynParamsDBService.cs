using BlazorServerHost.Data;
using BlazorServerHost.Data.DataMapper;
using BlazorServerHost.Data.Models.APCHardware;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareDBServices;

namespace BlazorServerHost.Services.APCHardwareDBServices
{
	public class DynParamsDBService : IDynParamsDBService
	{
		private readonly IDbContextFactory<APCHardwareDBContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public DynParamsDBService(IDbContextFactory<APCHardwareDBContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<DynParamsModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.DynParams
				.AsNoTracking()
				.Include(p => p.ConstParams)
				.Select(p => _mapper.Map<DynParams, DynParamsModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<DynParamsModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.DynParams
				.Include(p => p.ConstParams)
				.SingleAsync(s => s.Id == id, cancellationToken);

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

		public async Task<IEnumerable<DynParamsModel>> AddRangeAsync(IEnumerable<DynParamsModel> entities, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = _mapper.Map<IEnumerable<DynParamsModel>, IEnumerable<DynParams>>(entities);

			//foreach(var entry in entries)
			//	dbContext.Entry<ParameterData>(entry).State = EntityState.Detached;

			await dbContext.Set<DynParams>().AddRangeAsync(entries);
			await dbContext.SaveChangesAsync();

			return _mapper.Map<IEnumerable<DynParams>, IEnumerable<DynParamsModel>>(entries);

		}

		public async Task UpdateEntryAsync(Guid id, DynParamsModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.DynParams.SingleAsync(s => s.Id.ToString().ToLower() == id.ToString().ToLower(), cancellationToken);

			if (entry != null)
			{
				newData.Id = entry.Id;
				entry = _mapper.Map<DynParamsModel, DynParams>(newData);
				//dbContext.Entry(entry).CurrentValues.SetValues(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task UpdateDynParamValueAsync(DynParamsModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.DynParams.SingleAsync(s => s.Id == newData.Id, cancellationToken);

			if (entry != null)
			{
				//entry.Value = newData.Value;
				//entry = _mapper.Map<DynParamsModel, DynParams>(entry);
				dbContext.Entry(entry).CurrentValues.SetValues(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task UpdateDynParamValueByAPCDeviceNumAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, int paramValue, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.ParameterDatas
				.Include(p => p.APCDevice)
				.Include(p => p.DynParams)
				.Where(d => d.APCDevice != null && d.APCDevice.Num == apcDeviceNum)
				.Where(d => d.ParamGroupId == paramGroup)
				.Where(d => d.DynParams != null && d.DynParams.ParamId == paramId)
				.SingleAsync();

			if (entry != null && entry.DynParams != null)
			{
				entry.DynParams.Value = paramValue;

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

		public async Task DeleteAllEntriesAsync(CancellationToken cancellationToken, int? devicesAmount = null)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			//dbContext.RemoveRange(dbContext.DynParams);

			//await dbContext.SaveChangesAsync(cancellationToken);

			string cmd = $"DELETE FROM DynParams";

			if (devicesAmount != null)
			{
				cmd += $" Where Id in (Select pd.DynParamId From ParameterDatas pd join APCDEvices apc " +
                    $" on pd.APCDEviceId = apc.Id  Where apc.Num <= {devicesAmount} )";
			}

			await dbContext.Database.ExecuteSqlRawAsync(cmd, cancellationToken);
		}
	}
}


