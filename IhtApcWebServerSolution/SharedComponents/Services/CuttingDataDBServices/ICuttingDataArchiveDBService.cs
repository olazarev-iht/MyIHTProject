using SharedComponents.Models.CuttingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Services.CuttingDataDBServices
{
    public interface ICuttingDataArchiveDBService
    {
        public Task<List<CuttingDataModel>> GetEntriesAsync(CancellationToken cancellationToken);
    }
}
