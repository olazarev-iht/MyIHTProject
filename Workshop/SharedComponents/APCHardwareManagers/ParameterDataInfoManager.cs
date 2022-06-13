using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.Services.APCHardwareManagers;
using SharedComponents.Services.APCHardwareDBServices;
using SharedComponents.Services.APCHardwareMockDBServices;

namespace SharedComponents.APCHardwareManagers
{
    public class ParameterDataInfoManager : IParameterDataInfoManager
    {
        protected readonly IParameterDataDBService _parameterDataDBService;
        protected readonly IParameterDataInfoDBService _parameterDataInfoDBService;
        protected readonly IParameterDataMockDBService _parameterDataMockDBService;

        public ParameterDataInfoManager(
            IParameterDataDBService parameterDataDBService,
            IParameterDataInfoDBService parameterDataInfoDBService, 
            IParameterDataMockDBService parameterDataMockDBService)
        {
            _parameterDataDBService = parameterDataDBService ??
               throw new ArgumentNullException($"{nameof(parameterDataDBService)}");

            _parameterDataInfoDBService = parameterDataInfoDBService ??
               throw new ArgumentNullException($"{nameof(parameterDataInfoDBService)}");

            _parameterDataMockDBService = parameterDataMockDBService ??
               throw new ArgumentNullException($"{nameof(parameterDataInfoDBService)}");
        }

        public async Task InitializeParameterDataInfoAsync(CancellationToken cancellationToken)
        {
            var parameterDataListFromAPC = await _parameterDataMockDBService.GetEntriesAsync(cancellationToken);

            if (parameterDataListFromAPC.Any())
            {
                await _parameterDataDBService.AddRangeAsync(parameterDataListFromAPC)
            }
            


            return Task.CompletedTask;

        }
    }
}
