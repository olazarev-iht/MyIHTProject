using BlazorServerHost.Data;
using BlazorServerHost.Data.DataMapper;
using BlazorServerHost.Data.Models.APCHardware;
using Microsoft.EntityFrameworkCore;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareDBServices;

namespace BlazorServerHost.Services.APCHardwareDBServices
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

		public async Task<ParameterDataModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.ParameterDatas
				.Include(p => p.APCDevice)
				.Include(p => p.DynParams)
				.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<ParameterData, ParameterDataModel>(entry);
		}

		public async Task<Guid> AddEntryAsync(ParameterDataModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<ParameterDataModel, ParameterData>(model);

			await dbContext.ParameterDatas.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
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
	}
}



