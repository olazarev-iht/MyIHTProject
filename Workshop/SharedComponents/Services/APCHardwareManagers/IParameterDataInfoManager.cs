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
        public Task<List<ParameterDataInfoModel>> InitializeParameterDataInfoAsync(CancellationToken cancellationToken);
    }
}
