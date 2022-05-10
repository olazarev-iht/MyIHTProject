using BlazorServerHost.Data;
using BlazorServerHost.Extensions;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models;
using SharedComponents.Services;

namespace BlazorServerHost.Services
{
	public class HardwareAPCServise : IHardwareAPCServise
	{
		private readonly IDbContextFactory<HardwareAPCDbContext> _dbContextFactory;

		public HardwareAPCServise(IDbContextFactory<HardwareAPCDbContext> dbContextFactory)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
		}

		public async Task<SingletonDataModel> GetSingletonDataModelAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.HardwareAPCModel
				.Include(m => m.ConstParams)
				.Include(m => m.DynamicParams)
				.Include(m => m.LiveParams)
				.OrderBy(m => m.DeviceName)
				.ToArrayAsync(cancellationToken);

			return new SingletonDataModel()
			{
				HardwareAPCList = entries
			};
		}

		public async Task<HardwareAPCModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.HardwareAPCModel.SingleOrDefaultAsync(s => s.DeviceId == id, cancellationToken);

			return entry;
		}

		public async Task<Guid?> AddEntryAsync(HardwareAPCModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = model;

			await dbContext.HardwareAPCModel.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.DeviceId;
		}

		public async Task UpdateEntryAsync(Guid id, HardwareAPCModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.HardwareAPCModel.SingleAsync(s => s.DeviceId == id, cancellationToken);
			//entry.CopyFromModel(newData);
			entry.LiveParams = newData.LiveParams;
			entry.DynamicParams = newData.DynamicParams;
			entry.ConstParams = newData.ConstParams;

			// dbContext.Entry(entry).CurrentValues.SetValues(newData);

			//context.Attach(person);
			//context.Entry(person).Property(p => p.Name).IsModified = true;
			// context.Entry(person).State = EntityState.Modified;

			// Context.Entry(await Context.MyDbSet.FirstOrDefaultAsync(x => x.Id == item.Id)).CurrentValues.SetValues(item);
			// dbContext.Update(entity);

			await dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new HardwareAPCModel() { DeviceId = id };

			dbContext.HardwareAPCModel.Attach(stub);
			dbContext.HardwareAPCModel.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
