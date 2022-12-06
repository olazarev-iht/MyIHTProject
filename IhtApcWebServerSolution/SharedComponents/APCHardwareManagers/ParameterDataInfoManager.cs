using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SharedComponents.CutDataRepository;
using SharedComponents.IhtDev;
using SharedComponents.IhtData;
using SharedComponents.IhtModbus;
using SharedComponents.IhtModbusTable;
using SharedComponents.Models;
using SharedComponents.Models.CuttingData;
using SharedComponents.Models.APCHardware;
using SharedComponents.Services.APCHardwareManagers;
using SharedComponents.Services.APCHardwareDBServices;
using SharedComponents.Services.APCHardwareMockDBServices;
using SharedComponents.Services.CuttingDataDBServices;

namespace SharedComponents.APCHardwareManagers
{
    public class ParameterDataInfoManager : IParameterDataInfoManager
    {
        protected readonly IAPCDeviceDBService _apcDeviceDBService;
        protected readonly IConstParamsDBService _constParamsDBService;
        protected readonly IDynParamsDBService _dynParamsDBService;
        protected readonly IParameterDataDBService _parameterDataDBService;
        protected readonly IParameterDataInfoDBService _parameterDataInfoDBService;
        protected readonly ICuttingDataDBService _cuttingDataDBService;

        protected readonly IAPCDeviceMockDBService _apcDeviceMockDBService;
        protected readonly IConstParamsMockDBService _constParamsMockDBService;
        protected readonly IDynParamsMockDBService _dynParamsMockDBService;
        protected readonly IParameterDataMockDBService _parameterDataMockDBService;
        protected readonly IAPCSimulationDataMockDBService _apcSimulationDataMockDBService;
        protected readonly IAPCDefaultDataMockDBService _apcDefaultDataMockDBService;

        private readonly IhtModbusCommunic _ihtModbusCommunic;
        private readonly IhtCutDataAddressMap _ihtCutDataAddressMap;
        private readonly Settings _settings;

        public ParameterDataInfoManager(
            IAPCDeviceDBService apcDeviceDBService,
            IConstParamsDBService constParamsDBService,
            IDynParamsDBService dynParamsDBService,
            IParameterDataDBService parameterDataDBService,
            IParameterDataInfoDBService parameterDataInfoDBService,
            ICuttingDataDBService cuttingDataDBService,
            IAPCDeviceMockDBService apcDeviceMockDBService,
            IConstParamsMockDBService constParamsMockDBService,
            IDynParamsMockDBService dynParamsMockDBService,
            IParameterDataMockDBService parameterDataMockDBService,
            IAPCSimulationDataMockDBService apcSimulationDataMockDBService,
            IAPCDefaultDataMockDBService apcDefaultDataMockDBService,
            IhtModbusCommunic ihtModbusCommunic,
            IhtCutDataAddressMap ihtCutDataAddressMap,
            IOptions<Settings> settings
            )
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

            _cuttingDataDBService = cuttingDataDBService ??
               throw new ArgumentNullException($"{nameof(cuttingDataDBService)}");

            _apcDeviceMockDBService = apcDeviceMockDBService ??
               throw new ArgumentNullException($"{nameof(apcDeviceMockDBService)}");

            _constParamsMockDBService = constParamsMockDBService ??
               throw new ArgumentNullException($"{nameof(constParamsMockDBService)}");

            _dynParamsMockDBService = dynParamsMockDBService ??
               throw new ArgumentNullException($"{nameof(dynParamsMockDBService)}");

            _parameterDataMockDBService = parameterDataMockDBService ??
               throw new ArgumentNullException($"{nameof(parameterDataInfoDBService)}");

            _apcSimulationDataMockDBService = apcSimulationDataMockDBService ??
               throw new ArgumentNullException($"{nameof(apcSimulationDataMockDBService)}");

            _apcDefaultDataMockDBService = apcDefaultDataMockDBService ??
               throw new ArgumentNullException($"{nameof(apcDefaultDataMockDBService)}");

            _ihtModbusCommunic = ihtModbusCommunic ??
               throw new ArgumentNullException($"{nameof(ihtModbusCommunic)}");

            _ihtCutDataAddressMap = ihtCutDataAddressMap ??
               throw new ArgumentNullException($"{nameof(ihtCutDataAddressMap)}");

            _settings = settings != null ? settings.Value : 
                throw new ArgumentNullException($"{nameof(settings)}");
        }

        private List<ConstParamsModel> constParamsModels = new();
        private List<ParameterDataInfoModel> parameterDataInfoModels = new();
        private List<DynParamsModel> dynParamsModels = new();
        private List<ParameterDataModel> parameterDataModels = new();

        private void ResetParamsLists()
        {
            constParamsModels = new();
            parameterDataInfoModels = new();
            dynParamsModels = new();
            parameterDataModels = new();
        }

        public async Task<int> GetValueFromSimulationDataByAddress(int address, CancellationToken cancellationToken)
        {
            var value = await _apcSimulationDataMockDBService.GetEntryByAddressAsync(address, cancellationToken);
            if (value == null) return 0;
            return value.Value;
        }

        static IEnumerable<ParameterDataModel> deviceParams;

        public async Task<IEnumerable<ParameterDataModel>> GetDeviceSetupParamsAsync(int deviceNum, CancellationToken cancellationToken, bool refreshAll = true)
        {
            var maxDevNum = (int)IhtModbusCommunic.SlaveId.Id_Default;

            if (deviceNum > maxDevNum)
            {
                deviceNum -= maxDevNum;
            }

            if(refreshAll)
                deviceParams = await _parameterDataDBService.GetDeviceSetupParamsAsync(deviceNum, cancellationToken);

            var currSlaveId = deviceNum + maxDevNum;

            DataProcessInfo dataProcessInfo = _ihtModbusCommunic.ihtDevices.GetDataProcessInfo(currSlaveId);
            DataCmdExecution dataCmdExecution = _ihtModbusCommunic.ihtDevices.GetDataCmdExecution(currSlaveId);
            object dataSourceObj;

            deviceParams.ToList().ForEach(p => {

                // The parameter is not dynamic
                if (p.DynParams != null && p.DynParams.Address == 0) {

                    PropertyInfo? prop = Type.GetType(p.ParamSettings.ParamType)?.GetProperty(p.ParamSettings.ParamName, BindingFlags.Public | BindingFlags.Instance);

                    if (prop != null)
                    {
                        if (p.ParamSettings.ParamType.Contains(dataProcessInfo.GetType().ToString()))
                        {
                            dataSourceObj = dataProcessInfo;
                        }
                        else
                        {
                            dataSourceObj = dataCmdExecution;
                        }

                        p.DynParams.Value = prop?.GetValue(dataSourceObj) as int? ?? -1;
                    }
                }
            });
            

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

        public async Task WriteHoldingRegistersAsync(int apcDeviceNum, int paramAddress, int paramValue, IhtModbusResult? ihtModbusResult = null)
        {
            await _apcSimulationDataMockDBService.WriteHoldingRegistersAsync((byte)apcDeviceNum, (ushort)paramAddress, paramValue, ihtModbusResult);
        }

        public async Task WriteHoldingRegistersRangeAsync(int apcDeviceNum, int paramAddress, ushort[] paramValues, IhtModbusResult? ihtModbusResult = null)
        {
            await _apcSimulationDataMockDBService.WriteHoldingRegistersRangeAsync((byte)apcDeviceNum, (ushort)paramAddress, paramValues, ihtModbusResult);
        }

        public async Task UpdateDynParamValueByAPCDeviceNumAndParamIdAsync(int apcDeviceNum, ParamGroup paramGroup, int paramId, int paramValue, CancellationToken cancellationToken)
        {
            await _dynParamsDBService.UpdateDynParamValueByAPCDeviceNumAndParamIdAsync(apcDeviceNum, paramGroup, paramId, paramValue, cancellationToken);
        }

        public async Task UpdateDynParamValueByDeviceNumAndAddressAsync(int deviceNum, int paramAddress, int paramValue, CancellationToken cancellationToken)
        {
            await _dynParamsDBService.UpdateDynParamValueByDeviceNumAndAddressAsync(deviceNum, paramAddress, paramValue, cancellationToken);
        }

        public async Task UpdateDynParamValuesRangeAsync(int deviceNumber, (ushort paramAddress, ushort paramValue)[] paramsInfo, CancellationToken cancellationToken)
        {
            await _dynParamsDBService.UpdateDynParamValuesRangeAsync(deviceNumber, paramsInfo, cancellationToken);
        }

        public async Task DeleteAllEntriesFromCutingDataSequenceTableAsync(CancellationToken cancellationToken)
        {
            await _cuttingDataDBService.DeleteAllEntriesFromSequenceAsync(cancellationToken);
        }

        public async Task InitializeParameterDataInfoAsync(CancellationToken cancellationToken)
        {
            var settings = _settings;

            // Example for deleting data for devices
            // await DeleteAllAPCHardwareDataAsync(CancellationToken.None, 10);

            // We Update SimulationData mock table every time we turn the device on
            await UpdateSimulationDataMockWithDefaultData(CancellationToken.None);

            var isParameterDataEmpty = !(await _parameterDataDBService.GetEntriesAsync(CancellationToken.None)).Any();

            /// TODO: Deside if we need this initialization: (commented)
            if (isParameterDataEmpty)
            {
                _ihtModbusCommunic.IsSimulationHighPriority = true;
                await UpdateAPCHardwareDataAsync(cancellationToken);
                _ihtModbusCommunic.IsSimulationHighPriority = false;
            }
        }

        public async Task UpdateAPCHardwareDataAsync(CancellationToken cancellationToken, int? devicesAmount = null)
        {
            await DeleteAPCHardwareDataAsync(cancellationToken, devicesAmount);
            await FillAPCHardwareDataAsync(cancellationToken, devicesAmount);
        }

        public async Task UpdateSimulationDataMockWithDefaultData(CancellationToken cancellationToken)
        {
            await _apcSimulationDataMockDBService.UpdateFromDefaultDataAsync(cancellationToken);
        }

        public async Task LoadCuttingDataParamsFromDBAsync(ArrayList _modbusDatas, CuttingDataModel cuttingDataModel)
        {
            foreach (IhtModbusData modbusData in _modbusDatas)
            {
                // Write Dyn Params data to the modbusData
                _ihtCutDataAddressMap.SetData(cuttingDataModel, modbusData);

                // Technologie-Parameter Dyn. write into the Device
                var result = await _ihtModbusCommunic.ihtDevices.Write_TechnologyDynAsync(modbusData, true);

                if (result)
                {
                    var startAddress = modbusData.GetAddrInfo(IhtModbusAddrAreas.eIdxAddrInfo.TechnologyDyn).u16StartAddr;

                    if (_ihtModbusCommunic.IsSimulation)
                    {
                        await _apcSimulationDataMockDBService
                            .WriteHoldingRegistersRangeAsync((byte)modbusData.SlaveId, startAddress, modbusData.GetDataTechnologyDyn());
                    }

                    // Read the Dyn Params from the Device
                    IhtModbusResult ihtModbusResult = new();
                    ihtModbusResult.Result = await _ihtModbusCommunic.ihtDevices.Read_TechnologyDynAsync(modbusData, true);

                    if (ihtModbusResult.Result)
                    {
                        // Write Dyn Params into the DB
                        var technologyDyn = modbusData.GetDataTechnologyDyn();
                        //ushort paramsStartAddress = modbusData.GetAddrInfo(IhtModbusAddrAreas.eIdxAddrInfo.TechnologyDyn).u16StartAddr;

                        var paramsAddressAndValues = technologyDyn.Select(x => (startAddress++, x)).ToArray();

                        await UpdateDynParamValuesRangeAsync(modbusData.SlaveId, paramsAddressAndValues, CancellationToken.None);
                    }
                }
            }

        }

        private async Task DeleteAPCHardwareDataAsync(CancellationToken cancellationToken, int? devicesAmount = null)
        {
            try
            {
                // Since we use cascade delete (onDelete: ReferentialAction.Cascade) we can delete in the following way:
                // since we don't copy APCDevice table every time any more we don't delete it
                await _constParamsDBService.DeleteAllEntriesAsync(cancellationToken, devicesAmount);
                await _parameterDataInfoDBService.DeleteAllEntriesAsync(cancellationToken, devicesAmount);                
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }

        private async Task<bool> FillAPCHardwareDataAsync(CancellationToken cancellationToken, int? devicesAmount = null)
        {
            try
            {
                ResetParamsLists();

                var apcDeviceList = (await _apcDeviceDBService.GetEntriesAsync(cancellationToken))
                    .Where(d => devicesAmount == null || d.Num <= devicesAmount);

                var ihtDevices = IhtDevices.ihtDevices.Select(kpv => kpv.Value)
                    .Where(kvp => devicesAmount == null || kvp.DeviceNumber <= devicesAmount).OrderBy(kvp => kvp.DeviceNumber).ToList();

                // Not DB Model devices
                foreach (var apcDevice in ihtDevices)
                {
                    // DB Model - remove in the future (we need only for APCDeviceId = deviceDBModel.Id)
                    var deviceDBModel = apcDeviceList.FirstOrDefault(dev => dev.Num == apcDevice.DeviceNumber);
                    if (deviceDBModel == null) throw new Exception("There is no device in the collaction");

                    // TODO: Try to get values from modbusData
                    await SaveParameterDatasForDeviceAndGroupAsync(deviceDBModel.Id, apcDevice.DeviceNumber, ParamGroup.Technology);
                    await SaveParameterDatasForDeviceAndGroupAsync(deviceDBModel.Id, apcDevice.DeviceNumber, ParamGroup.Process);
                    await SaveParameterDatasForDeviceAndGroupAsync(deviceDBModel.Id, apcDevice.DeviceNumber, ParamGroup.Config);
                    await SaveParameterDatasForDeviceAndGroupAsync(deviceDBModel.Id, apcDevice.DeviceNumber, ParamGroup.Service);
                }

                await _constParamsDBService.AddRangeAsync(constParamsModels, CancellationToken.None);
                await _parameterDataInfoDBService.AddRangeAsync(parameterDataInfoModels, CancellationToken.None);
                await _dynParamsDBService.AddRangeAsync(dynParamsModels, CancellationToken.None);
                await _parameterDataDBService.AddRangeAsync(parameterDataModels, CancellationToken.None);

                return true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return false;
            }
        }

        private async Task SaveParameterDatasForDeviceAndGroupAsync(Guid deviceDBModelId, int deviceNumber, ParamGroup paramGroup)
        {
            var constParamsValuesArray = await GetParamsSubGroupValuesFromMockDB((byte)deviceNumber, 
                ParamGroupHelper._groupAddressesDictionary[paramGroup].startConstStoreValue,
                ParamGroupHelper._groupAddressesDictionary[paramGroup].numberConstStoreValue);

            var dynParamsValuesArray = await GetParamsSubGroupValuesFromMockDB((byte)deviceNumber,
                ParamGroupHelper._groupAddressesDictionary[paramGroup].startDynStoreValue,
                ParamGroupHelper._groupAddressesDictionary[paramGroup].numberDynStoreValue);

            await SaveParameterDatasForArraysAsync(deviceDBModelId, deviceNumber, paramGroup, constParamsValuesArray, dynParamsValuesArray);
        }

        private async Task SaveParameterDatasForArraysAsync(Guid deviceDBModelId, int deviceNumber, ParamGroup paramGroup, 
            (ushort Address, ushort Value)[] constParamsArray, (ushort Address, ushort Value)[] dynParamsArray)
        {
            Guid? parameterDataInfoId = null;

            // Array from the ParamGroup Enum
            var knownParamIdArray = ParamGroupHelper.ParamGroupToParamEnum[paramGroup];
            
            for (var paramId = 0; paramId < dynParamsArray.Length; paramId++)
            {
                // Parameter is known if it's Id less than the last enum Id in the ParanGroup (but not the "Length")
                var isKnownParameter = paramId < knownParamIdArray.Length - 1;

                var constParamsModel = new ConstParamsModel(paramId, constParamsArray.Select(x => x.Value).ToArray());
                // Save into Const Params List 
                var constParamsId = constParamsModel.Id;
                constParamsModels.Add(constParamsModel);

                if (isKnownParameter)
                {
                    var parameterDataInfoModel = new ParameterDataInfoModel(paramGroup, paramId);
                    parameterDataInfoId = parameterDataInfoModel.Id;
                    // Save into the Param Data Info List
                    parameterDataInfoModels.Add(parameterDataInfoModel);
                }

                if (constParamsModel.Id != Guid.Empty && parameterDataInfoId != Guid.Empty)
                {
                    var newDynParams = new DynParamsModel
                    {
                        Id = Guid.NewGuid(),
                        ParamId = paramId,
                        Address = dynParamsArray[paramId].Address,
                        ConstParamsId = constParamsId,
                        ParameterDataInfoId = parameterDataInfoId,
                        Value = dynParamsArray[paramId].Value
                    };

                    // Save into Dyn Params List
                    var dynParamsId = newDynParams.Id;
                    dynParamsModels.Add(newDynParams);

                    if (dynParamsId != Guid.Empty)
                    {
                        var paramName = isKnownParameter ? ParamGroupHelper.ParamGroupToEnumType[paramGroup].GetEnumName(paramId) : $"Param_{paramId}";
                        var deviceName = deviceNumber != 0 ? $"Device{deviceNumber}" : "System";

                        var newParameterData = new ParameterDataModel
                        {
                            Id = Guid.NewGuid(),
                            ParamName = $"{deviceName}_{paramName}",
                            APCDeviceId = deviceDBModelId,
                            ParamGroupId = paramGroup,
                            DynParamsId = dynParamsId // newDynParams.Id
                        };

                        // Save into Parameter Data List
                        parameterDataModels.Add(newParameterData);
                    }
                }
            }
        }

        private async Task<(ushort Address, ushort Value)[]> GetParamsSubGroupValuesFromMockDB(byte apcDeviceId, ushort startStoreValue, ushort numberStoreValue)
        {
            var apcSlaveId = apcDeviceId + (int)IhtModbusCommunic.SlaveId.Id_Default;

            //TODO: change to "await _ihtModbusCommunic.ReadAsync(apcSlaveId, (ushort)paramAddress, ihtModbusResult);"
            var ihtModbusResult = new IhtModbusResult();
            var paramsStartAddr = await _ihtModbusCommunic.ReadAsync(apcSlaveId, startStoreValue, ihtModbusResult);

            var paramsNumber = await _ihtModbusCommunic.ReadAsync(apcSlaveId, numberStoreValue, ihtModbusResult);

            var paramsValues = await _ihtModbusCommunic.ReadAsync(apcSlaveId, paramsStartAddr, paramsNumber, ihtModbusResult);
            //var paramsValues = await _apcSimulationDataMockDBService.GetHoldingRegistersWithAddressAsync(deviceNum, paramsStartAddr, paramsNumber);

            var paramsAddressAndValues = paramsValues.Select(x => (paramsStartAddr++, x)).ToArray();

            return paramsAddressAndValues;
        }

        public async Task<UInt16?> ReadOneHoldingRegisterAsync(byte slaveId, ushort startAddress)
        {
            var deviceId = slaveId > 10 ? slaveId - 10 : slaveId;

            var simulationData = (await _apcSimulationDataMockDBService.ReadHoldingRegistersAsync((byte)deviceId, startAddress, 1)).FirstOrDefault();

            return simulationData;
        }

        private async Task<bool> FillParameterDataAsync_old(CancellationToken cancellationToken)
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
                    Id = constParamsModel.Id == Guid.Empty ? Guid.NewGuid() : constParamsModel.Id,
                    Min = constParamsModel.Min,
                    Max = constParamsModel.Max,
                    Step = constParamsModel.Step
                };

                return await _constParamsDBService.AddEntryAsync(newConstParams, cancellationToken);
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
