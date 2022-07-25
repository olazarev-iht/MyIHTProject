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

        public async Task<IEnumerable<ParameterDataModel>> GetDeviceSetupParamsAsync(APCDeviceModel apcDevice, CancellationToken cancellationToken)
        {
            var deviceParams = await _parameterDataDBService.GetDeviceSetupParamsAsync(apcDevice, cancellationToken);
            return deviceParams;
        }

        public async Task<int> GetAPCDevicesNumber(CancellationToken cancellationToken)
        {
            var devicesNum = await _apcDeviceDBService.GetDevicesCountAsync(cancellationToken);
            return devicesNum;
        }

        public async Task<IEnumerable<ParameterDataModel>> GetParamsByDeviceIdAndParamsTypeAsync(int DeviceId, string ParamsType, CancellationToken cancellationToken)
        {
            var dynParams = await _parameterDataDBService.GetParamsByDeviceIdAndParamsTypeAsync(DeviceId, ParamsType, cancellationToken);

            return dynParams;
        }

        public async Task<ParameterDataModel?> GetParamDataFromMockDBByAPCDeviceAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, CancellationToken cancellationToken)
        {
            var parameterData = await _parameterDataMockDBService.GetEntryByAPCDeviceAndParamIdAsync(apcDeviceNum, paramGroup, paramId, CancellationToken.None);
            return parameterData;
        }

        public async Task UpdateDynParamValueAsync(DynParamsModel newData, CancellationToken cancellationToken)
        {
            if(newData == null)
            {
                throw new ArgumentNullException(nameof(newData));   
            }

            await _dynParamsDBService.UpdateDynParamValueAsync(newData, cancellationToken);
        }

        public async Task UpdateMockDynParamValueByAPCDeviceAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, int paramValue, CancellationToken cancellationToken)
        {
            await _dynParamsMockDBService.UpdateMockDynParamValueByAPCDeviceAndParamIdAsync(apcDeviceNum, paramGroup, paramId, paramValue, cancellationToken);
        }

        public async Task UpdateDynParamValueByAPCDeviceNumAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, int paramValue, CancellationToken cancellationToken)
        {
            await _dynParamsDBService.UpdateDynParamValueByAPCDeviceNumAndParamIdAsync(apcDeviceNum, paramGroup, paramId, paramValue, cancellationToken);
        }

        public async Task InitializeParameterDataInfoAsync(CancellationToken cancellationToken)
        {
            await DeleteAllAPCHardwareDataAsync(CancellationToken.None);

            await FillParameterDataAsync(CancellationToken.None);

        }

        private async Task DeleteAllAPCHardwareDataAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _parameterDataDBService.DeleteAllEntriesAsync(cancellationToken);
                await _dynParamsDBService.DeleteAllEntriesAsync(cancellationToken);
                await _constParamsDBService.DeleteAllEntriesAsync(cancellationToken);
                await _parameterDataInfoDBService.DeleteAllEntriesAsync(cancellationToken);
                await _apcDeviceDBService.DeleteAllEntriesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }

        private async Task<bool> FillParameterDataAsync(CancellationToken cancellationToken)
        {
            try
            {
                await FillAPCDevicesAsync(CancellationToken.None);

                var apcDeviceList = await _apcDeviceDBService.GetEntriesAsync(cancellationToken);

                foreach (var apcDevice in apcDeviceList)
                {
                    foreach (ParamGroup paramGroup in (ParamGroup[])Enum.GetValues(typeof(ParamGroup)))
                    {
                        foreach (int paramId in ParamGroupHelper.ParamGroupToParamEnum[paramGroup])
                        {
                            var mockParameterData = await _parameterDataMockDBService.GetEntryByAPCDeviceAndParamIdAsync(apcDevice.Num, paramGroup, paramId, cancellationToken);
                            var mockDynParams = mockParameterData?.DynParams;

                            if (mockDynParams == null || mockDynParams.ConstParams == null) continue;

                            var constParamsId = await SaveConstParamsAsync(mockDynParams.ConstParams, cancellationToken);

                            var parameterDataInfoModel = new ParameterDataInfoModel(paramGroup, paramId);
                            var parameterDataInfoId = await SaveParameterDataInfoAsync(parameterDataInfoModel, cancellationToken);

                            if (constParamsId != Guid.Empty && parameterDataInfoId != Guid.Empty)
                            {
                                var newDynParams = new DynParamsModel
                                {
                                    Id = Guid.NewGuid(),
                                    ParamId = paramId,
                                    ConstParamsId = constParamsId,
                                    ParameterDataInfoId = parameterDataInfoId,
                                    Value = mockDynParams.Value
                                };

                                var dynParamsId = await SaveDynParamsAsync(newDynParams, cancellationToken);

                                if (dynParamsId != Guid.Empty)
                                {
                                    var paramName = ParamGroupHelper.ParamGroupToEnumType[paramGroup].GetEnumName(paramId);
                                    var deviceName = apcDevice.Num != 0 ? $"Device{apcDevice.Num}" : "System";

                                    var newParameterData = new ParameterDataModel
                                    {
                                        Id = Guid.NewGuid(),
                                        ParamName = $"{deviceName}_{paramName}",
                                        APCDeviceId = apcDevice.Id,
                                        ParamGroupId = paramGroup,
                                        DynParamsId = dynParamsId // newDynParams.Id
                                    };

                                    await SaveParameterDataAsync(newParameterData, cancellationToken);
                                }
                            }
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }

        }

        private async Task<bool> FillAPCDevicesAsync(CancellationToken cancellationToken)
        {
            try
            {
                // Get APCDevice table from Mock and save to working table
                var apcDeviceListFromAPC = await _apcDeviceMockDBService.GetEntriesAsync(cancellationToken);

                if (apcDeviceListFromAPC.Any())
                {
                    var apcDeviceInsertedList = await _apcDeviceDBService.AddRangeAsync(apcDeviceListFromAPC, cancellationToken);
                }

                return true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }

        }

        private async Task<Guid> SaveParameterDataInfoAsync(ParameterDataInfoModel parameterDataInfoModel, CancellationToken cancellationToken)
        {
            try
            {
                parameterDataInfoModel.Id = Guid.NewGuid();

                return await _parameterDataInfoDBService.AddEntryAsync(parameterDataInfoModel, cancellationToken);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return Guid.Empty;
        }

        private async Task<Guid> SaveConstParamsAsync(ConstParamsModel constParamsModel, CancellationToken cancellationToken)
        {
            try
            {
                var newConstParams = new ConstParamsModel
                {
                    Id = Guid.NewGuid(),
                    Min = constParamsModel.Min,
                    Max = constParamsModel.Max,
                    Step = constParamsModel.Step
                };

                return await _constParamsDBService.AddEntryAsync(newConstParams, cancellationToken); ;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return Guid.Empty;
        }

        private async Task<Guid> SaveDynParamsAsync(DynParamsModel dynParamsModel, CancellationToken cancellationToken)
        {
            try
            {
                return await _dynParamsDBService.AddEntryAsync(dynParamsModel, cancellationToken);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return Guid.Empty;
        }

        private async Task<Guid> SaveParameterDataAsync(ParameterDataModel parameterDataModel, CancellationToken cancellationToken)
        {
            try
            {
                return await _parameterDataDBService.AddEntryAsync(parameterDataModel, cancellationToken);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return Guid.Empty;
        }
    }
}
