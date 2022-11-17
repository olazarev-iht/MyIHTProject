using IhtApcWebServer.Data;
using IhtApcWebServer.Data.DataMapper;
using IhtApcWebServer.Data.Models.APCHardware;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SharedComponents.IhtModbus;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareDBServices;
using System.Data;
using System.Text;

namespace IhtApcWebServer.Services.APCHardwareDBServices
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

			int[] paramsArray = new int[4];

			int[] ignitionParamsArray = { (int)IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition, (int)IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition, (int)IhtModbusParamDyn.eIdxTechnology.IgnitionFlameAdjust };
			int[] preheatParamsArray = { (int)IhtModbusParamDyn.eIdxTechnology.HeatO2PreHeat, (int)IhtModbusParamDyn.eIdxTechnology.FuelGasPreHeat};
			int[] piercingParamsArray = { (int)IhtModbusParamDyn.eIdxTechnology.HeatO2Pierce, (int)IhtModbusParamDyn.eIdxTechnology.FuelGasPierce, (int)IhtModbusParamDyn.eIdxTechnology.CutO2Pierce };
			int[] cuttingParamsArray = { (int)IhtModbusParamDyn.eIdxTechnology.HeatO2Cut, (int)IhtModbusParamDyn.eIdxTechnology.FuelGasCut, (int)IhtModbusParamDyn.eIdxTechnology.CutO2Cut };

			switch (ParamsType)
			{
				case "Ignition": paramsArray = ignitionParamsArray; break;
				case "PreHeat": paramsArray = preheatParamsArray; break;
				case "Pierce": paramsArray = piercingParamsArray; break;
				case "Cut": paramsArray = cuttingParamsArray; break;
			}

			var entries = await dbContext.ParameterDatas
				.AsNoTracking()
				.Include(p => p.APCDevice)
				.Include(p => p.DynParams)
					.ThenInclude(dp => dp.ConstParams)
				.Include(p => p.DynParams)
					.ThenInclude(dp => dp.ParameterDataInfo)
				.Where(p => p.APCDevice != null && p.APCDevice.Num == DeviceId)
				.Where(p => p.DynParams != null && paramsArray.ToList().Contains(p.DynParams.ParamId) && p.ParamGroupId == ParamGroup.Technology)
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

			string cmd = "Insert Or Ignore Into ParameterDatas(Id, ParamName, APCDeviceId, ParamGroupId, DynParamsId) Values";
			StringBuilder sb = new(cmd);
			var paramItems = new List<object>();

			var num = 1;

			foreach (var entry in entries)
			{
				paramItems.Add(new SqliteParameter($"@Id{num}", entry.Id));
				paramItems.Add(new SqliteParameter($"@ParamName{num}", entry.ParamName));
				paramItems.Add(new SqliteParameter($"@APCDeviceId{num}", entry.APCDeviceId));
				paramItems.Add(new SqliteParameter($"@ParamGroupId{num}", entry.ParamGroupId));
				paramItems.Add(new SqliteParameter($"@DynParamsId{num}", entry.DynParamsId));

				sb.Append($"(@Id{num}, @ParamName{num}, @APCDeviceId{num}, @ParamGroupId{num}, @DynParamsId{num})");

				if (num < entries.Count())
				{
					sb.AppendLine(",");
					num++;
				}
			}

			cmd = sb.ToString();

			await dbContext.Database.ExecuteSqlRawAsync(cmd, paramItems, cancellationToken);

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

		public async Task DeleteAllEntriesAsync(CancellationToken cancellationToken, int? devicesAmount = null)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			//dbContext.RemoveRange(dbContext.ParameterDatas);

			//await dbContext.SaveChangesAsync(cancellationToken);

			string cmd = $"DELETE FROM ParameterDatas";

			if (devicesAmount != null)
            {
				cmd += $" Where APCDeviceId in (Select Id From APCDEvices Where Num <= {devicesAmount} )";
			}

			await dbContext.Database.ExecuteSqlRawAsync(cmd, cancellationToken);
		}
	}
}



