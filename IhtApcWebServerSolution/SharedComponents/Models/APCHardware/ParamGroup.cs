using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.IhtModbus;

namespace SharedComponents.Models.APCHardware
{
    public enum ParamGroup
    {
        Technology = 1,
        Process,
        Config,
        Service,
        ProcessInfo,
        CmdExec,
        SetupExec,
        StatusHeightCtrl, // ???
        Additional,
    }
    public enum DynParamsForAreasEnum  //only for that order -> GetAreasDataSimulationData()
    {
        StartTechnologyConst = 2,
        // NumberTechnologyConst,
        //-------------------
        StartTechnologyDyn = 4,
        // NumberTechnologyDyn,
        //-------------------
        StartProcessConst = 6,
        // NumberProcessConst,
        //-------------------
        StartProcessDyn = 8,
        // NumberProcessDyn,
        //-------------------
        StartConfigConst = 10,
        // NumberConfigConst,
        //-------------------
        StartConfigDyn = 12,
        // NumberConfigDyn,
        //-------------------
        StartServiceConst = 14,
        // NumberServiceConst,
        //-------------------
        StartServiceDyn = 16,
        //NumberServiceDyn
    }
    public class ParamGroupHelper
    {
        public static ushort startTechnologyConstStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.StartTechnologyConst;
        public static ushort numberTechnologyConstStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.NumberTechnologyConst;

        public static ushort startTechnologyDynStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.StartTechnologyDyn;
        public static ushort numberTechnologyDynStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.NumberTechnologyDyn;

        public static ushort startProcessConstStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.StartProcessConst;
        public static ushort numberProcessConstStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.NumberProcessConst;

        public static ushort startProcessDynStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.StartProcessDyn;
        public static ushort numberProcessDynStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.NumberProcessDyn;

        public static ushort startConfigConstStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.StartConfigConst;
        public static ushort numberConfigConstStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.NumberConfigConst;

        public static ushort startConfigDynStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.StartConfigDyn;
        public static ushort numberConfigDynStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.NumberConfigDyn;

        public static ushort startServiceConstStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.StartServiceConst;
        public static ushort numberServiceConstStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.NumberServiceConst;

        public static ushort startServiceDynStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.StartServiceDyn;
        public static ushort numberServiceDynStoreValue = (ushort)IhtModbusData.eAddress.StartAddress + (ushort)IhtModbusData.eIdxAddr.NumberServiceDyn;

        public static Dictionary<ParamGroup, int[]> ParamGroupToParamEnum = new Dictionary<ParamGroup, int[]>()
        {
            { ParamGroup.Technology, (int[])Enum.GetValues(typeof(ParamIds)) },
            { ParamGroup.Process, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxProcess)) },
            { ParamGroup.Config, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxConfig)) },
            { ParamGroup.Service, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxService)) },
            { ParamGroup.ProcessInfo, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxProcessInfo)) },
            { ParamGroup.CmdExec, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxCmdExec)) },
            { ParamGroup.SetupExec, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxSetupExec)) },
            { ParamGroup.StatusHeightCtrl, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eStatusHeightCtrl)) },
            { ParamGroup.Additional, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxAdditional)) }
        };

        public static Dictionary<ParamGroup, (ushort startConstStoreValue, ushort numberConstStoreValue, ushort startDynStoreValue, ushort numberDynStoreValue)>
            _groupAddressesDictionary = new Dictionary<ParamGroup, (ushort, ushort, ushort, ushort)>()
        {
            { ParamGroup.Technology, (startTechnologyConstStoreValue, numberTechnologyConstStoreValue, startTechnologyDynStoreValue, numberTechnologyDynStoreValue) },
            { ParamGroup.Process, (startProcessConstStoreValue, numberProcessConstStoreValue, startProcessDynStoreValue, numberProcessDynStoreValue) },
            { ParamGroup.Config, (startConfigConstStoreValue, numberConfigConstStoreValue, startConfigDynStoreValue, numberConfigDynStoreValue) },
            { ParamGroup.Service, (startServiceConstStoreValue, numberServiceConstStoreValue, startServiceDynStoreValue, numberServiceDynStoreValue) }
        };

        public static Dictionary<DynParamsForAreasEnum, Type> DynParamsAreasToSubGroupTypeEnum = new ()
        {
            { DynParamsForAreasEnum.StartTechnologyConst, typeof(IhtModbusParamConst.eIdxTechnology) },
            { DynParamsForAreasEnum.StartTechnologyDyn, typeof(IhtModbusParamDyn.eIdxTechnology) },
            { DynParamsForAreasEnum.StartProcessConst, typeof(IhtModbusParamConst.eIdxProcess) },
            { DynParamsForAreasEnum.StartProcessDyn, typeof(IhtModbusParamDyn.eIdxProcess) },
            { DynParamsForAreasEnum.StartConfigConst, typeof(IhtModbusParamConst.eIdxConfig) },
            { DynParamsForAreasEnum.StartConfigDyn, typeof(IhtModbusParamDyn.eIdxConfig) },
            { DynParamsForAreasEnum.StartServiceConst, typeof(IhtModbusParamConst.eIdxService) },
            { DynParamsForAreasEnum.StartServiceDyn, typeof(IhtModbusParamDyn.eIdxService) },
        };

        public static Dictionary<ParamGroup, Type> ParamGroupToEnumType = new Dictionary<ParamGroup, Type>()
        {
            { ParamGroup.Technology, typeof(IhtModbusParamDyn.eIdxTechnology) },
            { ParamGroup.Process, typeof(IhtModbusParamDyn.eIdxProcess) },
            { ParamGroup.Config, typeof(IhtModbusParamDyn.eIdxConfig) },
            { ParamGroup.Service, typeof(IhtModbusParamDyn.eIdxService) },
            { ParamGroup.ProcessInfo, typeof(IhtModbusParamDyn.eIdxProcessInfo) },
            { ParamGroup.CmdExec, typeof(IhtModbusParamDyn.eIdxCmdExec) },
            { ParamGroup.SetupExec, typeof(IhtModbusParamDyn.eIdxSetupExec) },
            { ParamGroup.StatusHeightCtrl, typeof(IhtModbusParamDyn.eStatusHeightCtrl) },
            { ParamGroup.Additional, typeof(IhtModbusParamDyn.eIdxAdditional) }
        };
    }
}
