
using IhtApcWebServer.Data;
using IhtApcWebServer.Data.DataMapper;
using IhtApcWebServer.Data.Models.APCHardware;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Helpers;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareDBServices;
using System.Data;
using System.Text;


namespace IhtApcWebServer.Services.APCHardwareDBServices
{
    public class ErrorLogDBService : IErrorLogDBService
    {
        private readonly IDbContextFactory<APCHardwareDBContext> _dbContextFactory;

        private readonly DbModelMapper _mapper;

        public ErrorLogDBService(IDbContextFactory<APCHardwareDBContext> dbContextFactory, DbModelMapper mapper)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ErrorLogModel>> GetEntriesAsync(CancellationToken cancellationToken)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var rowsNumToShow = CommonConstants.MaxErrolLogRowsToShow;

			var entries = await dbContext.ErrorLogs
                .AsNoTracking()
                .Where(p => p.ErrorCode != null && !p.ErrorCode.Equals("Exception"))
                .Select(p => _mapper.Map<ErrorLog, ErrorLogModel > (p))
                .ToArrayAsync(cancellationToken);

            entries = entries.OrderByDescending(p => p.TimeStamp).Take(rowsNumToShow).ToArray();

            return entries;
        }

        public async Task<ErrorLogModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
            var entry = await dbContext.ErrorLogs.SingleAsync(s => s.Id == id, cancellationToken);

            return _mapper.Map<ErrorLog, ErrorLogModel>(entry);
        }

		public async Task<Guid> AddEntryByItemsValAsync(string errorCode, string errorMessage, int? slaveId = null, params string[] strArgs)
		{
			var errorLog = new ErrorLogModel()
			{
				Id = Guid.NewGuid(),
				SlaveId = slaveId,
				ErrorCode = int.TryParse(errorCode, out int erNumber) ? string.Format("Er.{0,2:00}", erNumber) : errorCode,
				Description = errorMessage,
				TimeStamp = DateTime.Now,
				Args = strArgs
			};

			return await AddEntryAsync(errorLog, CancellationToken.None);
		}

		public async Task<Guid> AddEntryAsync(ErrorLogModel model, CancellationToken cancellationToken)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            var entity = _mapper.Map<ErrorLogModel, ErrorLog>(model);

            await dbContext.ErrorLogs.AddAsync(entity, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

			// Delete old rows if count > max allowed
			var query = dbContext.ErrorLogs;
			var count = query.Count();
			var maxRowsNum = CommonConstants.MaxErrolLogRowsNum;

			if(count > maxRowsNum) 
			{ 
				var setToDelete = await query.OrderBy(e => e.TimeStamp).Take(count - maxRowsNum).ToListAsync(cancellationToken);
				dbContext.RemoveRange(setToDelete);
				await dbContext.SaveChangesAsync(cancellationToken);
			}

			return entity.Id;
        }

        public async Task UpdateEntryAsync(ErrorLogModel newData, CancellationToken cancellationToken)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            var entry = await dbContext.ErrorLogs.SingleAsync();

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

            var stub = new ErrorLog() { Id = id, };

            dbContext.ErrorLogs.Attach(stub);
            dbContext.ErrorLogs.Remove(stub);

            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAllEntriesAsync(CancellationToken cancellationToken)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            //dbContext.RemoveRange(dbContext.ErrorLogs);

            //await dbContext.SaveChangesAsync(cancellationToken);

            string cmd = $"DELETE FROM ErrorLogs";

            await dbContext.Database.ExecuteSqlRawAsync(cmd, cancellationToken);
        }
    }
}
