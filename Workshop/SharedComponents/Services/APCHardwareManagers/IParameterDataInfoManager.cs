using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.IhtModbus;
using SharedComponents.Models.APCHardware;


namespace SharedComponents.Services.APCHardwareManagers
{
    public interface IParameterDataInfoManager
    {
        public Task InitializeParameterDataInfoAsync(CancellationToken cancellationToken);
        public Task<IEnumerable<ParameterDataModel>> GetParamsByDeviceIdAndParamsTypeAsync(int DeviceId, string ParamsType, CancellationToken cancellationToken);
        public Task<ParameterDataModel?> GetParamDataFromMockDBByAPCDeviceAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, CancellationToken cancellationToken);
        public Task<IEnumerable<ParameterDataModel>> GetDeviceSetupParamsAsync(int apcDeviceNum, CancellationToken cancellationToken);
        public Task UpdateDynParamValueAsync(DynParamsModel newData, CancellationToken cancellationToken);
        public Task UpdateMockDynParamValueByAPCDeviceAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, int paramValue, CancellationToken cancellationToken);
        public Task UpdateDynParamValueByAPCDeviceNumAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, int paramValue, CancellationToken cancellationToken);
        public Task UpdateDynParamValueByDeviceNumAndAddressAsync(int deviceNum, int paramAddress, int paramValue, CancellationToken cancellationToken);
        public Task UpdateDynParamValuesRangeAsync(int deviceNumber, (ushort paramAddress, ushort paramValue)[] paramsInfo, CancellationToken cancellationToken);
        public Task<int> GetAPCDevicesNumber(CancellationToken cancellationToken);
        public Task<int> GetValueFromSimulationDataByAddress(int address, CancellationToken cancellationToken);
        public Task UpdateAPCHardwareDataAsync(CancellationToken cancellationToken, int? devicesAmount = null);
        public Task WriteHoldingRegistersAsync(int apcDeviceNum, int paramAddress, int paramValue, IhtModbusResult? ihtModbusResult = null);
        public Task<ushort?> ReadOneHoldingRegisterAsync(byte slaveAddress, ushort startAddress);
    }
}
