using BlazorServerHost.Data;
using BlazorServerHost.Data.DataMapper;
using BlazorServerHost.Data.Models.APCHardware;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareDBServices;

namespace BlazorServerHost.Services.APCHardwareDBServices
{
	public class ParameterDataDBService : IParameterDataDBService
	{
		private readonly IDbContextFactory<APCHardwareDBContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public ParameterDataDBService(IDbContextFactory<APCHardwareDBContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<ParameterDataModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.ParameterDatas
				.AsNoTracking()
				.Include(p => p.APCDevice)
				.Include(p => p.DynParams)
				.Select(p => _mapper.Map<ParameterData, ParameterDataModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<IEnumerable<ParameterDataModel>> GetParamsByDeviceIdAndParamsTypeAsync(int DeviceId, string ParamsType, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.ParameterDatas
				.AsNoTracking()
				.Include(p => p.APCDevice)
				.Include(p => p.DynParams)
					.ThenInclude(dp => dp.ConstParams)			
				.Where(p => p.APCDevice != null && p.APCDevice.Num == DeviceId)
				.Where(p => p.ParamName.Contains(ParamsType))
				.Select(p => _mapper.Map<ParameterData, ParameterDataModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<IEnumerable<ParameterDataModel>> GetParamsByDeviceIdAndParamGroupAsync(int DeviceId, ParamGroup paramGroup, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.ParameterDatas
				.AsNoTracking()
				.Include(p => p.APCDevice)
				.Include(p => p.DynParams)
					.ThenInclude(dp => dp.ConstParams)
				.Where(p => p.APCDevice != null && p.APCDevice.Num == DeviceId)
				.Where(p => p.ParamGroupId == paramGroup)
				.Select(p => _mapper.Map<ParameterData, ParameterDataModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<ParameterDataModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.ParameterDatas
				.Include(p => p.APCDevice)
				.Include(p => p.DynParams)
				.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<ParameterData, ParameterDataModel>(entry);
		}

		public async Task<ParameterDataModel?> GetEntryByAPCDeviceAndParamIdAsync(APCDeviceModel apcDevice, ParamGroup paramGroup, int paramId, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.ParameterDatas
				.AsNoTracking()
				.Include(p => p.DynParams)
				.SingleAsync(p => p.DynParams != null && p.APCDevice != null && p.ParamGroupId == paramGroup && p.DynParams.ParamId == paramId && p.APCDevice.Id == apcDevice.Id, cancellationToken);

			return _mapper.Map<ParameterData, ParameterDataModel>(entry);
		}

		public async Task<IEnumerable<ParameterDataModel>> GetDeviceSetupParamsAsync(int apcDeviceNum, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var setupParameters = new ParamIdsHelper().SetupParameters;

			var entryItems = await dbContext.ParameterDatas
				.AsNoTracking()
				.Include(p => p.APCDevice)
				.Include(p => p.DynParams)
					.ThenInclude(p => p.ConstParams)
				.Include(p => p.DynParams)
					.ThenInclude(p => p.ParameterDataInfo)
				.Where(p => p.DynParams != null && p.APCDevice != null && p.APCDevice.Num == apcDeviceNum && p.ParamName != null)
				.ToArrayAsync(cancellationToken);

			var entry = entryItems
				.Where(p => setupParameters.Contains(GetParamName(p.ParamName)))
				.Select(p => _mapper.Map<ParameterData, ParameterDataModel>(p))
				.OrderBy(p => p.ViewGroupOrder)
					.ThenBy(p => p.ViewItemOrder)
				.ToArray();

			return entry;
		}
		

		private string GetParamName(string? paramNameNullable)
        {
			if(string.IsNullOrWhiteSpace(paramNameNullable))
				return string.Empty;

			var returnVal = paramNameNullable.Contains('_') ? paramNameNullable.Split("_")[1] : paramNameNullable;

			return returnVal;
        }

		public async Task<Guid> AddEntryAsync(ParameterDataModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<ParameterDataModel, ParameterData>(model);

			await dbContext.ParameterDatas.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task<IEnumerable<ParameterDataModel>> AddRangeAsync(IEnumerable<ParameterDataModel> entities, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = _mapper.Map<IEnumerable<ParameterDataModel>, IEnumerable<ParameterData>>(entities);

			//foreach(var entry in entries)
			//	dbContext.Entry<ParameterData>(entry).State = EntityState.Detached;

			await dbContext.Set<ParameterData>().AddRangeAsync(entries);
			await dbContext.SaveChangesAsync();

			return _mapper.Map<IEnumerable<ParameterData>, IEnumerable<ParameterDataModel>>(entries);

		}

		public async Task UpdateEntryAsync(Guid id, ParameterDataModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.ParameterDatas.SingleAsync(s => s.Id == id, cancellationToken);

			if (entry != null)
			{
				newData.Id = entry.Id;
				entry = _mapper.Map<ParameterDataModel, ParameterData>(newData);
				//dbContext.Entry(entry).CurrentValues.SetValues(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new ParameterData() { Id = id, };

			dbContext.ParameterDatas.Attach(stub);
			dbContext.ParameterDatas.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteAllEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			//dbContext.RemoveRange(dbContext.ParameterDatas);

			//await dbContext.SaveChangesAsync(cancellationToken);

			string cmd = $"DELETE FROM ParameterDatas";

			await dbContext.Database.ExecuteSqlRawAsync(cmd, cancellationToken);
		}
	}
}



