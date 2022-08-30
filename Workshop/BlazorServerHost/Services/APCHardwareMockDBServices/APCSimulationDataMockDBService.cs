using BlazorServerHost.Data;
using BlazorServerHost.Data.DataMapper;
using BlazorServerHost.Data.Models.APCHardwareMock;
using Microsoft.EntityFrameworkCore;
using SharedComponents.IhtModbus;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareMockDBServices;

namespace BlazorServerHost.Services.APCHardwareMockDBServices
{
    public class APCSimulationDataMockDBService : IAPCSimulationDataMockDBService
	{
		private readonly IDbContextFactory<APCHardwareMockDBContext> _dbContextFactory;

		private readonly DbModelMapper _mapper;

		public APCSimulationDataMockDBService(IDbContextFactory<APCHardwareMockDBContext> dbContextFactory, DbModelMapper mapper)
		{
			_dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));

			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<IEnumerable<APCSimulationDataModel>> GetEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.APCSimulationDatas
				.AsNoTracking()
				.OrderBy(p => p.Address)
				.Select(p => _mapper.Map<APCSimulationData, APCSimulationDataModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<IEnumerable<APCSimulationDataModel>> GetApcSimulationDataSetByAddressAndNumber(int deviceNum, ushort startAddress, ushort numParams, CancellationToken cancellationToken)
        {
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = await dbContext.APCSimulationDatas
				.AsNoTracking()
				.Where(p => p.Device == deviceNum && p.Address >= startAddress && p.Address < startAddress + numParams)
				.OrderBy(p => p.Address)
				.Select(p => _mapper.Map<APCSimulationData, APCSimulationDataModel>(p))
				.ToArrayAsync(cancellationToken);

			return entries;
		}

		public async Task<UInt16[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numRegisters, IhtModbusResult? ihtModbusResult = null)
		{
			var deviceId = slaveAddress > 10 ? slaveAddress - 10 : slaveAddress;

			var simulationData = await GetApcSimulationDataSetByAddressAndNumber(deviceId, startAddress, numRegisters, CancellationToken.None);

			return simulationData.Select(x => (ushort)x.Value).ToArray();
		}

		public async Task WriteHoldingRegistersAsync(byte slaveAddress, ushort address, int value, IhtModbusResult? ihtModbusResult = null)
		{
			var deviceId = slaveAddress > 10 ? slaveAddress - 10 : slaveAddress;

			await UpdateEntryByDeviceNumAndAddressAsync(deviceId, address, value, CancellationToken.None);

		}

		public async Task UpdateEntryByDeviceNumAndAddressAsync(int deviceNumber, ushort paramAddress, int paramValue, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.APCSimulationDatas
				.SingleAsync(s => s.Device == deviceNumber && s.Address == paramAddress, cancellationToken);

			if (entry != null)
			{
				entry.Value = paramValue;
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task<(ushort Address, ushort Value)[]> GetHoldingRegistersWithAddressAsync(byte slaveAddress, ushort startAddress, ushort numRegisters, IhtModbusResult? ihtModbusResult = null)
		{
			var deviceId = slaveAddress > 10 ? slaveAddress - 10 : slaveAddress;

			var simulationData = await GetApcSimulationDataSetByAddressAndNumber(deviceId, startAddress, numRegisters, CancellationToken.None);

			return simulationData.Select(x => ((ushort)x.Address, (ushort)x.Value)).ToArray();
		}

		public async Task<APCSimulationDataModel?> GetEntryByAddressAsync(int address, CancellationToken cancellationToken)
        {
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.APCSimulationDatas.SingleAsync(s => s.Address == address, cancellationToken);

			return _mapper.Map<APCSimulationData, APCSimulationDataModel>(entry);
		}

		public async Task<APCSimulationDataModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
			var entry = await dbContext.APCSimulationDatas.SingleAsync(s => s.Id == id, cancellationToken);

			return _mapper.Map<APCSimulationData, APCSimulationDataModel>(entry);
		}

		public async Task<Guid> AddEntryAsync(APCSimulationDataModel model, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entity = _mapper.Map<APCSimulationDataModel, APCSimulationData>(model);

			await dbContext.APCSimulationDatas.AddAsync(entity, cancellationToken);
			await dbContext.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}

		public async Task<IEnumerable<APCSimulationDataModel>> AddRangeAsync(IEnumerable<APCDefaultDataModel> entities, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entries = _mapper.Map<IEnumerable<APCDefaultDataModel>, IEnumerable<APCSimulationData>>(entities);

            //foreach (var entry in entries)
            //    dbContext.Entry<APCSimulationData>(entry).State = EntityState.Detached;

            //dbContext.Configuration.AutoDetectChangesEnabled = false;

            await dbContext.Set<APCSimulationData>().AddRangeAsync(entries);
			await dbContext.SaveChangesAsync();

			return _mapper.Map<IEnumerable<APCSimulationData>, IEnumerable<APCSimulationDataModel>>(entries);

		}

		public async Task UpdateEntryAsync(Guid id, APCSimulationDataModel newData, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var entry = await dbContext.APCSimulationDatas.SingleAsync(s => s.Id == id, cancellationToken);

			if (entry != null)
			{
				newData.Id = entry.Id;
				entry = _mapper.Map<APCSimulationDataModel, APCSimulationData>(newData);
				await dbContext.SaveChangesAsync(cancellationToken);
			}
		}

		public async Task UpdateFromDefaultDataAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			string cmd = $"DELETE FROM APCSimulationDatas; INSERT INTO APCSimulationDatas SELECT * FROM APCDefaultDatas";

			await dbContext.Database.ExecuteSqlRawAsync(cmd, cancellationToken);
		}

		public async Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			var stub = new APCSimulationData() { Id = id, };

			dbContext.APCSimulationDatas.Attach(stub);
			dbContext.APCSimulationDatas.Remove(stub);

			await dbContext.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteAllEntriesAsync(CancellationToken cancellationToken)
		{
			await using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

			string cmd = $"DELETE FROM APCSimulationDatas";

			await dbContext.Database.ExecuteSqlRawAsync(cmd, cancellationToken);
		}

	}
}
