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
        public Task<IEnumerable<ParameterDataModel>> GetDynParamsByDeviceIdAndParamsTypeAsync(int DeviceId, string ParamsType, CancellationToken cancellationToken);
        public Task UpdateDynParamValueAsync(DynParamsModel newData, CancellationToken cancellationToken);
        public Task<int> GeAPCDevicesNumber(CancellationToken cancellationToken);
    }
}
