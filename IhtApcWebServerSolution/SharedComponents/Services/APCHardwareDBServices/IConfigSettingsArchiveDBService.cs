using SharedComponents.Models.APCHardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Services.APCHardwareDBServices
{
    public interface IConfigSettingsArchiveDBService
    {
        public Task<ConfigSettingsModel> GetEntryAsync(CancellationToken cancellationToken);
    }
}
