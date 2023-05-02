using IhtApcWebServer.Data;
using IhtApcWebServer.Data.DataMapper;
using IhtApcWebServer.Data.Models.APCHardware;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareDBServices;
using System.Data;
using System.Text;

namespace IhtApcWebServer.Services.APCHardwareArchiveDBServices
{
    public class ConfigSettingsArchiveDBService : IConfigSettingsArchiveDBService
    {
        private readonly IDbContextFactory<APCHardwareArchiveDBContext> _dbContextFactory;

        private readonly DbModelMapper _mapper;

        public ConfigSettingsArchiveDBService(IDbContextFactory<APCHardwareArchiveDBContext> dbContextFactory, DbModelMapper mapper)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

		public async Task<ConfigSettingsModel> GetEntryAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            var entry = new ConfigSettings();

            try
            {
                entry = await dbContext.ConfigSettings.SingleAsync(cancellationToken);
            }
            catch { }

			return _mapper.Map<ConfigSettings, ConfigSettingsModel>(entry);
		}
    }
}
