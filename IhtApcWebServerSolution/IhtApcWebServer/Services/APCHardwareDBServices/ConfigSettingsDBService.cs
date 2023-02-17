using IhtApcWebServer.Data;
using IhtApcWebServer.Data.DataMapper;
using IhtApcWebServer.Data.Models.APCHardware;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareDBServices;
using System.Data;
using System.Text;

namespace IhtApcWebServer.Services.APCHardwareDBServices
{
	public class ConfigSettingsDBService : IConfigSettingsDBService
	{
		private readonly IDbContextFactory<APCHardwareDBContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public ConfigSettingsDBService(IDbContextFactory<APCHardwareDBContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<ConfigSettingsModel> GetEntryAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.ConfigSettings.SingleAsync(cancellationToken);

			return _mapper.Map<ConfigSettings, ConfigSettingsModel>(entry);
		}

		public async Task<ConfigSettingsModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.ConfigSettings.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<ConfigSettings, ConfigSettingsModel>(entry);
		}

		public async Task<Guid> AddEntryAsync(ConfigSettingsModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<ConfigSettingsModel, ConfigSettings>(model);

			await dbContext.ConfigSettings.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task UpdateEntryAsync(ConfigSettingsModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.ConfigSettings.SingleAsync();

			if (entry != null)
			{
				newData.Id = entry.Id;
				//entry = _mapper.Map<ConfigSettingsModel, ConfigSettings>(newData);
				dbContext.Entry(entry).CurrentValues.SetValues(newData);
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

		public async Task DeleteAllEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			//dbContext.RemoveRange(dbContext.ConstParams);

			//await dbContext.SaveChangesAsync(cancellationToken);

			string cmd = $"DELETE FROM ConfigSettings";

			await dbContext.Database.ExecuteSqlRawAsync(cmd, cancellationToken);
		}
	}
}
