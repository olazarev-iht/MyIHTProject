using IhtApcWebServer.Data;
using IhtApcWebServer.Data.DataMapper;
using IhtApcWebServer.Data.Models.APCHardware;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareDBServices;

namespace IhtApcWebServer.Services.APCHardwareDBServices
{
	public class APCDeviceDBService : IAPCDeviceDBService
	{
		private readonly IDbContextFactory<APCHardwareDBContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public APCDeviceDBService(IDbContextFactory<APCHardwareDBContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<APCDeviceModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.APCDevices
				.AsNoTracking()
				.OrderBy(p => p.Name)
				.Select(p => _mapper.Map<APCDevice, APCDeviceModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<int> GetDevicesCountAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = dbContext.APCDevices.Where(d => d.Num > 0).Count();

			return entries;
		}

		public async Task<APCDeviceModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.APCDevices.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<APCDevice, APCDeviceModel>(entry);
		}

		public async Task<APCDeviceModel?> GetEntryByDevNumAsync(int id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.APCDevices.SingleAsync(s => s.Num == id, cancellationToken);

			return _mapper.Map<APCDevice, APCDeviceModel>(entry);
		}

		public async Task<Guid> AddEntryAsync(APCDeviceModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<APCDeviceModel, APCDevice>(model);

			await dbContext.APCDevices.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task<IEnumerable<APCDeviceModel>> AddRangeAsync(IEnumerable<APCDeviceModel> entities, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = _mapper.Map<IEnumerable<APCDeviceModel>, IEnumerable<APCDevice>>(entities);

			entries = entries.Select(apc => { apc.Id = Guid.NewGuid(); return apc; });

			await dbContext.Set<APCDevice>().AddRangeAsync(entries);
			await dbContext.SaveChangesAsync();

			return _mapper.Map<IEnumerable<APCDevice>, IEnumerable<APCDeviceModel>>(entries);

		}

		public async Task UpdateEntryAsync(Guid id, APCDeviceModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.APCDevices.SingleAsync(s => s.Id == id, cancellationToken);

			if (entry != null)
			{
				newData.Id = entry.Id;
				entry = _mapper.Map<APCDeviceModel, APCDevice>(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new APCDevice() { Id = id, };

			dbContext.APCDevices.Attach(stub);
			dbContext.APCDevices.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteAllEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			dbContext.RemoveRange(dbContext.APCDevices);

			await dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}

