using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.Models.APCHardware;
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

        public async Task<List<ParameterDataInfoModel>> InitializeParameterDataInfoAsync(CancellationToken cancellationToken)
        {
            var parameterDataInfoModel = await _parameterDataInfoDBService.GetEntriesAsync(cancellationToken);

            if (parameterDataInfoModel.Any())
            {
                await _parameterDataInfoDBService.DeleteAllEntriesAsync(cancellationToken);
            }

            var parameterDataListFromAPC = await _parameterDataMockDBService.GetEntriesAsync(cancellationToken);
            IEnumerable<ParameterDataModel> parameterDataInsertedList = null;
            List<ParameterDataInfoModel> parameterDataInfoListToSave = new();
            List<ParameterDataInfoModel> parameterDataInfoInserted = new();

            if (parameterDataListFromAPC.Any())
            {
                parameterDataInsertedList = await _parameterDataDBService.AddRangeAsync(parameterDataListFromAPC, cancellationToken);
            }

            if (parameterDataInsertedList != null)
            {
                foreach (var parameterData in parameterDataInsertedList)
                {
                    var parameterDataInfoToSave = new ParameterDataInfoModel(parameterData?.DynParams?.ParamId);
                    parameterDataInfoListToSave.Add(parameterDataInfoToSave);
                }
            }

            if (parameterDataInfoListToSave != null)
            {
                parameterDataInfoInserted = (await _parameterDataInfoDBService.AddRangeAsync(parameterDataInfoListToSave, cancellationToken)).ToList();
            }

            return parameterDataInfoInserted;
        }
    }
}
