using BlazorServerHost.Data;
using BlazorServerHost.Data.DataMapper;
using BlazorServerHost.Data.Models.CuttingData;
using SharedComponents.Models.CuttingData;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Services.CuttingDataDBServices;
using System.Transactions;

namespace BlazorServerHost.Services.CuttingDataDBServices
{
	public class CuttingDataDBService : ICuttingDataDBService
	{
		private readonly IDbContextFactory<CuttingDataDbContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public CuttingDataDBService(IDbContextFactory<CuttingDataDbContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<List<CuttingDataModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.CuttingData
				.OrderByDescending(p => p.idCutDataParent)
					.ThenBy(p => p.Thickness)
				.Include(p => p.Gas)
				.Include(p => p.Nozzle)
				.Include(p => p.Material)
				.Select(p => _mapper.Map<CuttingData, CuttingDataModel>(p))
				.ToListAsync(cancellationToken);

			return entries;
		}

		public async Task<CuttingDataModel?> GetEntryByIdAsync(int id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.CuttingData
				.Include(p => p.Gas)
				.Include(p => p.Nozzle)
				.Include(p => p.Material)
				.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<CuttingData, CuttingDataModel>(entry);
		}

		public async Task<int?> AddEntryAsync(CuttingDataModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<CuttingDataModel, CuttingData>(model);

			using var tx = dbContext.Database.BeginTransaction();

			var customCounter = await dbContext.CustomCounter.SingleAsync();
			
			entity.Id = customCounter.Ids ;
			entity.idCutDataParent = !string.IsNullOrWhiteSpace(model.idCutDataParent.ToString()) ? model.idCutDataParent : model.Id;

			await dbContext.Database.ExecuteSqlRawAsync($@"update CustomCounter Set Ids = {++customCounter.Ids}");

			await dbContext.CuttingData.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			await tx.CommitAsync();

			return entity.Id;
		}

		public async Task<int?> AddBaseEntryAsync(CuttingDataModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<CuttingDataModel, CuttingData>(model);

			entity.Id = 0;
			entity.idCutDataParent = !string.IsNullOrWhiteSpace(model.idCutDataParent.ToString()) ? model.idCutDataParent : model.Id;

			await dbContext.CuttingData.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task UpdateEntryAsync(int id, CuttingDataModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			try
			{
				var entry = await dbContext.CuttingData.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

				if (entry != null)
				{
					newData.Id = entry.Id;
					//entry = _mapper.Map<CuttingDataModel, CuttingData>(newData);
					dbContext.Entry(entry).CurrentValues.SetValues(newData);
					await dbContext.SaveChangesAsync(cancellationToken);
				}
			}
			catch (DbUpdateConcurrencyException ex)
			{
				foreach (var entry in ex.Entries)
				{

					var proposedValues = entry.CurrentValues;
					var databaseValues = entry.GetDatabaseValues();
					var originalValues = entry.OriginalValues;

					foreach (var property in proposedValues.Properties)
					{
						var proposedValue = proposedValues[property];
						//var databaseValue = databaseValues[property];
						var originalValue = originalValues[property];

						// TODO: decide which value should be written to database
						proposedValues[property] = proposedValue;
					}

					// Refresh original values to bypass next concurrency check
					entry.OriginalValues.SetValues(proposedValues);

				}

				await dbContext.SaveChangesAsync(cancellationToken);
			}
			catch (Exception ex)
			{
				//throw new Exception(ex.Message, ex);
				var message = ex.Message;
			}
		}

		public async Task DeleteEntryAsync(int id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			using var tx = dbContext.Database.BeginTransaction();

			var stub = new CuttingData() { Id = id, };

			dbContext.CuttingData.Attach(stub);
			dbContext.CuttingData.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);


			string cmd = $"DELETE FROM sqlite_sequence WHERE name = 'CuttingData'";
			//await dbContext.Database.ExecuteSqlRawAsync(cmd, cancellationToken);

			await tx.CommitAsync(cancellationToken);
		}
	}
}
