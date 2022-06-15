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
        protected readonly IAPCDeviceDBService _apcDeviceDBService;
        protected readonly IConstParamsDBService _constParamsDBService;
        protected readonly IDynParamsDBService _dynParamsDBService;
        protected readonly IParameterDataDBService _parameterDataDBService;
        protected readonly IParameterDataInfoDBService _parameterDataInfoDBService;

        protected readonly IAPCDeviceMockDBService _apcDeviceMockDBService;
        protected readonly IConstParamsMockDBService _constParamsMockDBService;
        protected readonly IDynParamsMockDBService _dynParamsMockDBService;
        protected readonly IParameterDataMockDBService _parameterDataMockDBService;

        public ParameterDataInfoManager(
            IAPCDeviceDBService apcDeviceDBService,
            IConstParamsDBService constParamsDBService,
            IDynParamsDBService dynParamsDBService,
            IParameterDataDBService parameterDataDBService,
            IParameterDataInfoDBService parameterDataInfoDBService,
            IAPCDeviceMockDBService apcDeviceMockDBService,
            IConstParamsMockDBService constParamsMockDBService,
            IDynParamsMockDBService dynParamsMockDBService,
            IParameterDataMockDBService parameterDataMockDBService)
        {
            _apcDeviceDBService = apcDeviceDBService ??
               throw new ArgumentNullException($"{nameof(apcDeviceDBService)}");

            _constParamsDBService = constParamsDBService ??
               throw new ArgumentNullException($"{nameof(constParamsDBService)}");

            _dynParamsDBService = dynParamsDBService ??
               throw new ArgumentNullException($"{nameof(dynParamsDBService)}");

            _parameterDataDBService = parameterDataDBService ??
               throw new ArgumentNullException($"{nameof(parameterDataDBService)}");

            _parameterDataInfoDBService = parameterDataInfoDBService ??
               throw new ArgumentNullException($"{nameof(parameterDataInfoDBService)}");

            _apcDeviceMockDBService = apcDeviceMockDBService ??
               throw new ArgumentNullException($"{nameof(apcDeviceMockDBService)}");

            _constParamsMockDBService = constParamsMockDBService ??
               throw new ArgumentNullException($"{nameof(constParamsMockDBService)}");

            _dynParamsMockDBService = dynParamsMockDBService ??
               throw new ArgumentNullException($"{nameof(dynParamsMockDBService)}");

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

            // 1. Get APCDevice table from Mock and save to working table ---------------------------------
            var apcDeviceListFromAPC = await _apcDeviceMockDBService.GetEntriesAsync(cancellationToken);

            var apcDeviceListCurrent = await _apcDeviceDBService.GetEntriesAsync(cancellationToken);
            if(apcDeviceListCurrent.Any())
            {
                await _apcDeviceDBService.DeleteAllEntriesAsync(cancellationToken);
            }

            // IEnumerable<APCDeviceModel> apcDeviceInsertedList = null;
            if (apcDeviceListFromAPC.Any())
            {
                var apcDeviceInsertedList = await _apcDeviceDBService.AddRangeAsync(apcDeviceListFromAPC, cancellationToken);
            }
            //--------------------------------------------------------------------------------------------

            // 2. Get ConstParams table from Mock and save to working table ---------------------------------
            var constParamsListFromAPC = await _constParamsMockDBService.GetEntriesAsync(cancellationToken);

            var constParamsListCurrent = await _constParamsDBService.GetEntriesAsync(cancellationToken);
            if (constParamsListCurrent.Any())
            {
                await _apcDeviceDBService.DeleteAllEntriesAsync(cancellationToken);
            }

            if (constParamsListFromAPC.Any())
            {
                var constParamsInsertedList = await _constParamsDBService.AddRangeAsync(constParamsListFromAPC, cancellationToken);
            }
            //--------------------------------------------------------------------------------------------

            // 2. Get DynParams table from Mock and save to working table ---------------------------------
            var dynParamsListFromAPC = await _dynParamsMockDBService.GetEntriesAsync(cancellationToken);

            var dynParamsListCurrent = await _dynParamsDBService.GetEntriesAsync(cancellationToken);
            if (dynParamsListCurrent.Any())
            {
                await _dynParamsDBService.DeleteAllEntriesAsync(cancellationToken);
            }

            if (constParamsListFromAPC.Any())
            {
                var constParamsInsertedList = await _dynParamsDBService.AddRangeAsync(dynParamsListFromAPC, cancellationToken);
            }
            //--------------------------------------------------------------------------------------------


            var parameterDataListFromAPC = await _parameterDataMockDBService.GetEntriesAsync(cancellationToken);
            IEnumerable<ParameterDataModel> parameterDataInsertedList = null;

            List<ParameterDataInfoModel> parameterDataInfoListToSave = new();
            List<ParameterDataInfoModel> parameterDataInfoInsertedList = new();

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

            if (parameterDataInfoListToSave.Any())
            {
                parameterDataInfoInsertedList = (await _parameterDataInfoDBService.AddRangeAsync(parameterDataInfoListToSave, cancellationToken)).ToList();
            }

            return parameterDataInfoInsertedList;
        }
    }
}
