using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;
using SharedComponents.Models.APCHardware;
using SharedComponents.Models.CuttingData;



namespace SharedComponents.Services.APCHardwareManagers
{
    public interface IParameterDataInfoManager
    {
        public Task InitializeParameterDataInfoAsync(CancellationToken cancellationToken);
        public Task<IEnumerable<ParameterDataModel>> GetParamsByDeviceIdAndParamsTypeAsync(int DeviceId, string ParamsType, CancellationToken cancellationToken);
        public Task<ParameterDataModel?> GetParamDataFromMockDBByAPCDeviceAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, CancellationToken cancellationToken);
        public Task<IEnumerable<ParameterDataModel>> GetDeviceSetupParamsAsync(int apcDeviceNum, CancellationToken cancellationToken, bool refreshAll = true);
        public Task UpdateDynParamValueAsync(DynParamsModel newData, CancellationToken cancellationToken);
        public Task UpdateMockDynParamValueByAPCDeviceAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, int paramValue, CancellationToken cancellationToken);
        public Task UpdateDynParamValueByAPCDeviceNumAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, int paramValue, CancellationToken cancellationToken);
        public Task UpdateDynParamValueByDeviceNumAndAddressAsync(int deviceNum, int paramAddress, int paramValue, CancellationToken cancellationToken);
        public Task UpdateDynParamValuesRangeAsync(int deviceNumber, (ushort paramAddress, ushort paramValue)[] paramsInfo, CancellationToken cancellationToken);
        public Task LoadCuttingDataParamsFromDBAsync(ArrayList _modbusDatas, CuttingDataModel cuttingDataModel);
        public Task<int> GetAPCDevicesNumber(CancellationToken cancellationToken);
        public Task<int> GetValueFromSimulationDataByAddress(int address, CancellationToken cancellationToken);
        public Task UpdateAPCHardwareDataAsync(CancellationToken cancellationToken, List<IhtDevice> deviceList = null);
        public Task CopyModbusAPCHardwareDataAsync(CancellationToken cancellationToken, List<IhtDevice> ihtDeviceList = null);
        public Task WriteHoldingRegistersAsync(int apcDeviceNum, int paramAddress, int paramValue, IhtModbusResult? ihtModbusResult = null);
        public Task WriteHoldingRegistersRangeAsync(int apcDeviceNum, int paramAddress, ushort[] paramValues, IhtModbusResult? ihtModbusResult = null);
        public Task<ushort?> ReadOneHoldingRegisterAsync(byte slaveAddress, ushort startAddress);
        public Task DeleteAllEntriesFromCutingDataSequenceTableAsync(CancellationToken cancellationToken);
        public Task<bool> IsSystemHasSavedSettings(CancellationToken cancellationToken);
        public Task<ParameterDataModel?> GetDeviceParamByParamGroupAndParamIdAsync(int DeviceId, ParamGroup paramGroup, int paramId, CancellationToken cancellationToken);
    }
}
