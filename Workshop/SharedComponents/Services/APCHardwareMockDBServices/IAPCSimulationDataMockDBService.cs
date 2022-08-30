using SharedComponents.IhtModbus;
using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareMockDBServices
{
    public interface IAPCSimulationDataMockDBService
    {
        public Task<IEnumerable<APCSimulationDataModel>> GetEntriesAsync(CancellationToken cancellationToken);
        public Task<APCSimulationDataModel?> GetEntryByIdAsync(Guid id, CancellationToken cancellationToken);
        public Task<APCSimulationDataModel?> GetEntryByAddressAsync(int address, CancellationToken cancellationToken);
        public Task<IEnumerable<APCSimulationDataModel>> GetApcSimulationDataSetByAddressAndNumber(int deviceNum, ushort startAddress, ushort numParams, CancellationToken cancellationToken);
        public Task<Guid> AddEntryAsync(APCSimulationDataModel model, CancellationToken cancellationToken);
        public Task UpdateEntryAsync(Guid id, APCSimulationDataModel newData, CancellationToken cancellationToken);
        public Task UpdateFromDefaultDataAsync(CancellationToken cancellationToken);
        public Task DeleteEntryAsync(Guid id, CancellationToken cancellationToken);
        public Task<UInt16[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numRegisters, IhtModbusResult? ihtModbusResult = null);
        public Task WriteHoldingRegistersAsync(byte slaveAddress, ushort address, int value, IhtModbusResult? ihtModbusResult = null);
        public Task<(ushort Address, ushort Value)[]> GetHoldingRegistersWithAddressAsync(byte slaveAddress, ushort startAddress, ushort numRegisters, IhtModbusResult? ihtModbusResult = null);
        public Task DeleteAllEntriesAsync(CancellationToken cancellationToken);
        public Task<IEnumerable<APCSimulationDataModel>> AddRangeAsync(IEnumerable<APCDefaultDataModel> entities, CancellationToken cancellationToken);

    }
}
