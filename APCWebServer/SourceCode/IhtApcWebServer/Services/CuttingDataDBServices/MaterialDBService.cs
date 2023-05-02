using IhtApcWebServer.Data;
using IhtApcWebServer.Data.DataMapper;
using IhtApcWebServer.Data.Models.CuttingData;
using SharedComponents.Models.CuttingData;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Services.CuttingDataDBServices;

namespace IhtApcWebServer.Services.CuttingDataDBServices
{
	public class MaterialDBService : IMaterialDBService
	{
		private readonly IDbContextFactory<CuttingDataDbContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public MaterialDBService(IDbContextFactory<CuttingDataDbContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<MaterialModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.Material
				.AsNoTracking()
				.OrderBy(p => p.Name)
				.Select(p => _mapper.Map<Material, MaterialModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<MaterialModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.Material.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<Material, MaterialModel>(entry);
		}

		public async Task<Guid> AddEntryAsync(MaterialModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<MaterialModel, Material>(model);

			await dbContext.Material.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task UpdateEntryAsync(Guid id, MaterialModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.Material.SingleAsync(s => s.Id == id, cancellationToken);

			if (entry != null)
			{
				newData.Id = entry.Id;
				entry = _mapper.Map<MaterialModel, Material>(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new Material() { Id = id, };

			dbContext.Material.Attach(stub);
			dbContext.Material.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
