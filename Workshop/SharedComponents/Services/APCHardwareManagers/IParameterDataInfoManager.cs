using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.Models.APCHardware;

namespace SharedComponents.Services.APCHardwareManagers
{
    public interface IParameterDataInfoManager
    {
        public Task InitializeParameterDataInfoAsync(CancellationToken cancellationToken);
        public Task<IEnumerable<ParameterDataModel>> GetParamsByDeviceIdAndParamsTypeAsync(int DeviceId, string ParamsType, CancellationToken cancellationToken);
        public Task<ParameterDataModel?> GetParamDataFromMockDBByAPCDeviceAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, CancellationToken cancellationToken);
        public Task<IEnumerable<ParameterDataModel>> GetDeviceSetupParamsAsync(APCDeviceModel apcDevice, CancellationToken cancellationToken);
        public Task UpdateDynParamValueAsync(DynParamsModel newData, CancellationToken cancellationToken);
        public Task UpdateMockDynParamValueByAPCDeviceAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, int paramValue, CancellationToken cancellationToken);
        public Task UpdateDynParamValueByAPCDeviceNumAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, int paramValue, CancellationToken cancellationToken);
        public Task<int> GetAPCDevicesNumber(CancellationToken cancellationToken);
    }
}
