using IhtApcWebServer.Data;
using IhtApcWebServer.Data.DataMapper;
using IhtApcWebServer.Data.Models.CuttingData;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Helpers;
using SharedComponents.Models.CuttingData;
using SharedComponents.MqttModel;
using SharedComponents.Services.CuttingDataDBServices;

namespace IhtApcWebServer.Services.CuttingDataArchiveDBService
{
    public class CuttingDataArchiveDBService : ICuttingDataArchiveDBService
    {
        private readonly IDbContextFactory<CuttingDataArchiveDbContext> _dbContextFactory;

        private readonly DbModelMapper _mapper;

        public CuttingDataArchiveDBService(IDbContextFactory<CuttingDataArchiveDbContext> dbContextFactory, DbModelMapper mapper)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CuttingDataModel>> GetEntriesAsync(CancellationToken cancellationToken)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            var entries = new List<CuttingDataModel>();

            try
            {
                entries = await dbContext.CuttingData
                    .Where(p => p.Id < CommonConstants.CutDBMinConstRowNumber)
                    .OrderBy(p => p.Id)
                    .ThenBy(p => p.Thickness)
                    .Include(p => p.Gas)
                    .Include(p => p.Nozzle)
                    .Include(p => p.Material)
                    .Select(p => _mapper.Map<CuttingData, CuttingDataModel>(p))
                    .ToListAsync(cancellationToken);
            }
            catch { }

            return entries;
        }
    }
}
