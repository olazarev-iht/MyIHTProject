using IhtApcWebServer.Data;
using IhtApcWebServer.Data.DataMapper;
using IhtApcWebServer.Data.Models.APCHardware;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SharedComponents.IhtDev;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareDBServices;
using System.Data;
using System.Text;

namespace IhtApcWebServer.Services.APCHardwareDBServices
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

			string cmd = "Insert Or Ignore Into ParameterDataInfos(Id, Unit, Format, MinDescription, MaxDescription, StepDescription, ValueDescription, Multiplier) Values";
			StringBuilder sb = new(cmd);
			var paramItems = new List<object>();

			var num = 1;

			foreach (var entry in entries)
			{
				paramItems.Add(new SqliteParameter($"@Id{num}", entry.Id));
				paramItems.Add(new SqliteParameter($"@Unit{num}", entry.Unit));
				paramItems.Add(new SqliteParameter($"@Format{num}", entry.Format));
				paramItems.Add(new SqliteParameter($"@MinDescription{num}", entry.MinDescription));
				paramItems.Add(new SqliteParameter($"@MaxDescription{num}", entry.MaxDescription));				
				paramItems.Add(new SqliteParameter($"@StepDescription{num}", entry.StepDescription));
				paramItems.Add(new SqliteParameter($"@ValueDescription{num}", entry.ValueDescription));
				paramItems.Add(new SqliteParameter($"@Multiplier{num}", entry.Multiplier));
				
				sb.Append($"(@Id{num}, @Unit{num}, @Format{num}, @MinDescription{num}, @MaxDescription{num}, @StepDescription{num}, @ValueDescription{num}, @Multiplier{num} )");

				if (num < entries.Count())
				{
					sb.AppendLine(",");
					num++;
				}
			}

			cmd = sb.ToString();

			await dbContext.Database.ExecuteSqlRawAsync(cmd, paramItems, cancellationToken);

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

		public async Task DeleteAllEntriesAsync(CancellationToken cancellationToken, List<IhtDevice> deviceList = null)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			//dbContext.RemoveRange(dbContext.ParameterDataInfos);

			//await dbContext.SaveChangesAsync(cancellationToken);

			string cmd = $"DELETE FROM ParameterDataInfos";

			if (deviceList != null && deviceList.Count > 0)
			{
				cmd += $" Where Id in (Select pdi.Id From ParameterDataInfos pdi left join DynParams dyn on pdi.Id = dyn.ParameterDataInfoId" +
                    $" Where dyn.ParameterDataInfoId is null)";
			}

			await dbContext.Database.ExecuteSqlRawAsync(cmd, cancellationToken);
		}
	}
}


