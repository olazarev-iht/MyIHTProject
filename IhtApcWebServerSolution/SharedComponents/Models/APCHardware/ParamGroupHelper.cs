using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.IhtModbus;
using System.ComponentModel;
using SharedComponents.IhtModbusCmd;

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

    public enum SettingParamIds
    {
        [Description("Automatic Height Calibration")]
        TactileInitialPosFinding = 1,
        [Description("Manual Height Calibration")]
        DistanceCalibration,
        [Description("Position")]
        LinearDrivePosition,
        [Description("Height Calibration Valid")]
        CalibrationValid,
        [Description("Height Calibration Active")]
        CalibrationActive,
        [Description("Retract Position")]
        RetractHeight,
        [Description("Retract Position enable")]
        RetractPosAtProcessEnd,
        [Description("Slag Sensitivity")]
        SlagSensitivity,
        [Description("Slag Post Time")]
        SlagPostTime,
        [Description("Slag Cutting Speed Reduction")]
        SlagCuttingSpeedReduction,
        [Description("Start Preflow")]
        CutO2Blowout,
        [Description("Break Preflow")]
        CutO2BlowoutBreak,
        [Description("Preflow active")]
        CutO2BlowoutActive,
        [Description("Preflow active time")]
        CurrCutO2BlowoutTime,
        [Description("PreFlow Time")]
        CutO2BlowOutTime,
        [Description("SPreFlow Pressure")]
        CutO2BlowOutPressure,
        [Description("PreFlow Timeout")]
        CutO2BlowOutTimeOut,
        [Description("Piercing with Height Control")]
        PiercingSensorMode,
        [Description("Dynamic")]
        Dynamic,
        [Description("Height Control Active")]
        HeightControlActive,
        [Description("Status Height Control")]
        StatusHeightControl
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


        private const string ParamType_DataProcessInfo = "SharedComponents.IhtData.DataProcessInfo";
        private const string ParamType_DataCmdExecution = "SharedComponents.IhtData.DataCmdExecution";

        private const string ParamName_CalibrationValid = "IsCalibrationValid";
        private const string ParamName_CalibrationActive = "IsCalibrationActive";
        private const string ParamName_RetractPosAtProcessEnd = "IsRetractPosAtProcessEnd";
        private const string ParamName_CutO2BlowoutActive = "IsCutO2BlowoutActive";
        private const string ParamName_CurrCutO2BlowoutTime = "CurrCutO2BlowoutTime";
        private const string ParamName_HeightControlActive = "IsHeightControlActive";
        private const string ParamName_LinearDrivePosition = "LinearDrivePosition";
        private const string ParamName_StatusHeightControl = "StatusHeightControl";

        public static readonly Dictionary<SettingParamIds, (Enum? paramModbusEnum, string Format)> SettingParamsProperties = new()
        {
            { SettingParamIds.TactileInitialPosFinding, (IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding, @"{ 'Mode':'Switch', 'Values': ['Disable', 'Enable'] }") },
            { SettingParamIds.DistanceCalibration, (IhtModbusParamDyn.eIdxConfig.DistanceCalibration, @"{ 'Mode':'Slider', 'Unit' : true }") },
            { SettingParamIds.LinearDrivePosition, (IhtModbusParamDyn.eIdxProcessInfo.LinearDrivePosition, @"{ 'Unit' : true }") },
            { SettingParamIds.CalibrationValid, (null, @"{ 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }") },
            { SettingParamIds.CalibrationActive, (null, @"{ 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }") },
            { SettingParamIds.RetractHeight, (IhtModbusParamDyn.eIdxProcess.RetractHeight, @"{ 'Name':'Retract Position', 'Mode':'Slider' }") },
            { SettingParamIds.RetractPosAtProcessEnd, (IhtModbusCmdExecSwitch.eCmdBit.RetractPosAtProcessEnd, @"{ 'Mode':'Switch', 'Values': ['Disable', 'Enable'] }") },
            { SettingParamIds.SlagSensitivity, (IhtModbusParamDyn.eIdxProcess.SlagSensitivity, @"{ 'Mode':'Select', 'Values': ['Off','Low','Default','High'] }") },
            { SettingParamIds.SlagPostTime, (IhtModbusParamDyn.eIdxProcess.SlagPostTime, @"{ 'Mode':'Slider' }") },
            { SettingParamIds.SlagCuttingSpeedReduction, (IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction, @"{ 'Mode':'Slider' }") },
            { SettingParamIds.CutO2Blowout, (IhtModbusCmdExecTactile.eCmdBit.CutO2Blowout, @"{ 'Mode':'Button', 'Values': ['Start'] }") },
            { SettingParamIds.CutO2BlowoutBreak, (IhtModbusCmdExecTactile.eCmdBit.CutO2BlowoutBreak, @"{ 'Mode':'Button', 'Values': ['Break'] }") },
            { SettingParamIds.CutO2BlowoutActive, (null, @"{ 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }") },
            { SettingParamIds.CurrCutO2BlowoutTime, (IhtModbusParamDyn.eIdxProcessInfo.CurrCutO2BlowoutTime, @"{ 'Mode':'ProgressCircular' }") },
            { SettingParamIds.CutO2BlowOutTime, (IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime, @"{ 'Mode':'Slider' }") },
            { SettingParamIds.CutO2BlowOutPressure, (IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure, @"{ 'Mode':'Slider' }") },
            { SettingParamIds.CutO2BlowOutTimeOut, (IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut, @"{ 'Mode':'Slider' }") },
            { SettingParamIds.PiercingSensorMode, (IhtModbusParamDyn.eIdxProcess.PiercingSensorMode, @"{ 'Mode':'Switch', 'Values': ['Disable', 'Enable'] }") },            
            { SettingParamIds.Dynamic, (IhtModbusParamDyn.eIdxConfig.Dynamic, @"{ 'Mode':'Slider' }") },
            { SettingParamIds.HeightControlActive, (null, @"{ 'Mode':'NoYes', 'Values': ['No','Yes'], 'ReadOnly':true }") },
            { SettingParamIds.StatusHeightControl, (IhtModbusParamDyn.eIdxProcessInfo.StatusHeightControl, @"{ 'Mode':'Select', 'Values': ['Off','PreHeating','Piercing','Cutting'], 'ReadOnly':true }") }
        };

        public static readonly Dictionary<SettingParamIds, (string paramType, string paramName)> NonDynSettingParamTypeAndName = new()
        {
            { SettingParamIds.CalibrationValid, (ParamType_DataProcessInfo, ParamName_CalibrationValid) },
            { SettingParamIds.CalibrationActive, (ParamType_DataProcessInfo, ParamName_CalibrationActive) },
            { SettingParamIds.RetractPosAtProcessEnd, (ParamType_DataCmdExecution, ParamName_RetractPosAtProcessEnd) },
            { SettingParamIds.CutO2BlowoutActive, (ParamType_DataProcessInfo, ParamName_CutO2BlowoutActive) },
            { SettingParamIds.CurrCutO2BlowoutTime, (ParamType_DataProcessInfo, ParamName_CurrCutO2BlowoutTime) },
            { SettingParamIds.HeightControlActive, (ParamType_DataProcessInfo, ParamName_HeightControlActive) },
            { SettingParamIds.LinearDrivePosition, (ParamType_DataProcessInfo, ParamName_LinearDrivePosition) },
            { SettingParamIds.StatusHeightControl, (ParamType_DataProcessInfo, ParamName_StatusHeightControl) },
        };

        public static Dictionary<ParamGroup, int[]> ParamGroupToParamEnum = new Dictionary<ParamGroup, int[]>()
        {
            { ParamGroup.Technology, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxTechnology)) },
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

    //internal record struct NewStruct(ParamGroup Technology, Type? Item2)
    //{
    //    public static implicit operator (ParamGroup Technology, Type?)(NewStruct value)
    //    {
    //        return (value.Technology, value.Item2);
    //    }

    //    public static implicit operator NewStruct((ParamGroup Technology, Type?) value)
    //    {
    //        return new NewStruct(value.Technology, value.Item2);
    //    }
    //}
}
