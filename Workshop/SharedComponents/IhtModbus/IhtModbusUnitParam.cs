using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.Helpers;
using SharedComponents.IhtDev;
using SharedComponents.Models.APCHardware;

namespace SharedComponents.IhtModbus
{
    class IhtModbusUnitParam
    {
        public static bool IsPasswordValid { get; set; }
        private static bool IsPasswordLevel_SwLevel_1;
        public static int PasswordLevel_Software
        {
            set
            {
                switch (value)
                {
                    case (int)IhtDevices.PasswordLevel_SW.Level_1:
                    case (int)IhtDevices.PasswordLevel_SW.Level_2:
                    case (int)IhtDevices.PasswordLevel_SW.Level_3:
                        IsPasswordLevel_SwLevel_1 = true;
                        break;
                    default:
                        IsPasswordLevel_SwLevel_1 = false;
                        break;
                }
            }
        }
        public static int u16PierceMode { get; set; }

        public static bool IsPressurePsi { get { return Units.IsPressurePsi; } }
        public static bool IsUnitInch { get { return Units.IsUnitInch || Units.IsUnitInchFractional; } }

        public static readonly string txtMm = Units.txtMm;
        public static readonly string txtInch = Units.txtInch;
        public static readonly string txtBar = Units.txtBar;
        public static readonly string txtPsi = Units.txtPsi;

        public static readonly string txtMm_min = Units.txtMm_min;
        public static readonly string txtInch_min = Units.txtInch_min;

        /// <summary>
        /// 
        /// </summary>
        public static string GetDefault(UInt16 u16Idx)
        {
            return " ";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetTechnology(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxTechnology Idx = (IhtModbusParamDyn.eIdxTechnology)u16Idx;
            switch (Idx)
            {
                case IhtModbusParamDyn.eIdxTechnology.PreHeatHeight: return IsUnitInch ? txtInch : txtMm;
                case IhtModbusParamDyn.eIdxTechnology.PierceHeight: return IsUnitInch ? txtInch : txtMm;
                case IhtModbusParamDyn.eIdxTechnology.CutHeight: return IsUnitInch ? txtInch : txtMm;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition: return IsPasswordLevel_SwLevel_1 ? (IsPressurePsi ? txtPsi : txtBar) : " ";
                case IhtModbusParamDyn.eIdxTechnology.HeatO2PreHeat: return IsPressurePsi ? txtPsi : txtBar;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Pierce: return IsPressurePsi ? txtPsi : txtBar;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Cut: return IsPressurePsi ? txtPsi : txtBar;
                case IhtModbusParamDyn.eIdxTechnology.CutO2Pierce: return IsPressurePsi ? txtPsi : txtBar;
                case IhtModbusParamDyn.eIdxTechnology.CutO2Cut: return IsPressurePsi ? txtPsi : txtBar;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition: return IsPasswordLevel_SwLevel_1 ? (IsPressurePsi ? txtPsi : txtBar) : " ";
                case IhtModbusParamDyn.eIdxTechnology.FuelGasPreHeat: return IsPressurePsi ? txtPsi : txtBar;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasPierce: return IsPressurePsi ? txtPsi : txtBar;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasCut: return IsPressurePsi ? txtPsi : txtBar;
                case IhtModbusParamDyn.eIdxTechnology.PreHeatTime: return "s";
                case IhtModbusParamDyn.eIdxTechnology.PiercePreTime: return IsPasswordValid ? (u16PierceMode == 0) ? "s" : "%" : " ";
                case IhtModbusParamDyn.eIdxTechnology.PierceTime: return "s";
                case IhtModbusParamDyn.eIdxTechnology.PiercePostTime: return IsPasswordValid ? (u16PierceMode == 0) ? "s" : "%" : " ";
                case IhtModbusParamDyn.eIdxTechnology.PierceHeightRampTime: return IsPasswordValid ? "s" : " ";
                case IhtModbusParamDyn.eIdxTechnology.CutHeightRampTime: return IsPasswordValid ? "s" : " ";
                case IhtModbusParamDyn.eIdxTechnology.PierceMode: return " ";
                case IhtModbusParamDyn.eIdxTechnology.IgnitionFlameAdjust: return "%";
                case IhtModbusParamDyn.eIdxTechnology.GasType: return " ";
                case IhtModbusParamDyn.eIdxTechnology.CuttingSpeed: return IsUnitInch ? txtInch_min : txtMm_min;
                case IhtModbusParamDyn.eIdxTechnology.PierceCuttingSpeedChange: return "%";
                case IhtModbusParamDyn.eIdxTechnology.ControlBits: return " ";
            }
            return " ";
        }

        /// <summary>
        /// 
        /// </summary>
        //public static string GetProcess(UInt16 u16Idx)
        //{
        //    IhtModbusParamDyn.eIdxProcess eIdx = (IhtModbusParamDyn.eIdxProcess)u16Idx;
        //    switch (eIdx)
        //    {
        //        case IhtModbusParamDyn.eIdxProcess.RetractHeight: return IsUnitInch ? txtInch : txtMm;
        //        case IhtModbusParamDyn.eIdxProcess.SlagSensitivity: return " ";
        //        case IhtModbusParamDyn.eIdxProcess.HeatO2Temper: return IsPressurePsi ? txtPsi : txtBar;
        //        case IhtModbusParamDyn.eIdxProcess.FuelGasTemper: return IsPressurePsi ? txtPsi : txtBar;
        //        case IhtModbusParamDyn.eIdxProcess.HeightTemper: return IsUnitInch ? txtInch : txtMm;
        //        case IhtModbusParamDyn.eIdxProcess.LinearDriveManualPosSpeed: return "%";
        //        case IhtModbusParamDyn.eIdxProcess.FuelGasOffset: return "%";
        //        case IhtModbusParamDyn.eIdxProcess.FlashbackSensivitity: return " ";
        //        #region Slag
        //        case IhtModbusParamDyn.eIdxProcess.SlagIntervalTime: return "s";
        //        case IhtModbusParamDyn.eIdxProcess.SlagFirstSlagTime: return "s";
        //        case IhtModbusParamDyn.eIdxProcess.SlagSecurityTime: return "s";
        //        case IhtModbusParamDyn.eIdxProcess.SlagPostTime: return "s";
        //        case IhtModbusParamDyn.eIdxProcess.SlagActiveGradient: return "mm";
        //        case IhtModbusParamDyn.eIdxProcess.SlagInActiveGradient: return "mm";
        //            #endregion // Slag
        //    }
        //    return " ";
        //}

        /// <summary>
        /// 
        /// </summary>
        //public static string GetConfig(UInt16 u16Idx)
        //{
        //    IhtModbusParamDyn.eIdxConfig eIdx = (IhtModbusParamDyn.eIdxConfig)u16Idx;
        //    switch (eIdx)
        //    {
        //        case IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedFast: return "%";
        //        case IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedSlow: return "%";
        //        case IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedFast: return "%";
        //        case IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedSlow: return "%";
        //        case IhtModbusParamDyn.eIdxConfig.Dynamic: return " ";
        //        case IhtModbusParamDyn.eIdxConfig.SensorCollisionDelay: return "s";
        //        case IhtModbusParamDyn.eIdxConfig.LinearDriveRefSpeed: return "%";
        //        case IhtModbusParamDyn.eIdxConfig.LinearDrivePosSpeed: return "%";
        //        case IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding: return " ";
        //        case IhtModbusParamDyn.eIdxConfig.DistanceCalibration: return IsUnitInch ? txtInch : txtMm;
        //        case IhtModbusParamDyn.eIdxConfig.HoseLength: return IsUnitInch ? txtInch : txtMm;
        //        case IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime: return "s";
        //        case IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure: return IsPressurePsi ? txtPsi : txtBar;
        //        case IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut: return "min";
        //        case IhtModbusParamDyn.eIdxConfig.CapSetpointFlameOffs: return " ";
        //        case IhtModbusParamDyn.eIdxConfig.LoadDefaultParameter: return " ";
        //    }
        //    return " ";
        //}

        /// <summary>
        /// 
        /// </summary>
        //public static string GetService(UInt16 u16Idx)
        //{
        //    IhtModbusParamDyn.eIdxService eIdx = (IhtModbusParamDyn.eIdxService)u16Idx;
        //    switch (eIdx)
        //    {
        //        case IhtModbusParamDyn.eIdxService.IgnitionPreFlowMultiplier: return Units.Get_ms_10mm(); ;
        //        case IhtModbusParamDyn.eIdxService.IgnitionOnDurationTime: return "s";
        //        case IhtModbusParamDyn.eIdxService.HeatO2PostFlowMultiplier: return Units.Get_ms_10mm(); ;
        //        case IhtModbusParamDyn.eIdxService.HeatO2PostFlowPressure: return IsPressurePsi ? txtPsi : txtBar;
        //        case IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction: return "%";
        //        case IhtModbusParamDyn.eIdxService.SensorCollisionOutputDisable: return " ";
        //        case IhtModbusParamDyn.eIdxService.PidErrorThresholdDelay: return "s";
        //        case IhtModbusParamDyn.eIdxService.ToleranceInPosition: return "%";
        //        case IhtModbusParamDyn.eIdxService.Fit3ValveDelay: return "s";
        //        case IhtModbusParamDyn.eIdxService.Fit3ValveDuration: return "s";
        //        case IhtModbusParamDyn.eIdxService.Fit3GlowPlugDelay: return "s";
        //        case IhtModbusParamDyn.eIdxService.Fit3GlowPlugDuration: return "s";
        //        case IhtModbusParamDyn.eIdxService.Fit3GlowPlugSetpoint: return "V";
        //        case IhtModbusParamDyn.eIdxService.Fit3SaveIgnitionData: return " ";
        //    }
        //    return " ";
        //}

        /// <summary>
        /// 
        /// </summary>
        //public static string GetProcessInfo(UInt16 u16Idx)
        //{
        //    IhtModbusParamDyn.eIdxProcessInfo eIdx = (IhtModbusParamDyn.eIdxProcessInfo)u16Idx;
        //    switch (eIdx)
        //    {
        //        case IhtModbusParamDyn.eIdxProcessInfo.ErrorCode: return " ";
        //        case IhtModbusParamDyn.eIdxProcessInfo.Status: return " ";
        //        case IhtModbusParamDyn.eIdxProcessInfo.StatusLeds: return " ";
        //        case IhtModbusParamDyn.eIdxProcessInfo.StatusInputs: return " ";
        //        case IhtModbusParamDyn.eIdxProcessInfo.StatusOutputs: return " ";
        //        case IhtModbusParamDyn.eIdxProcessInfo.StatusHeightControl: return " ";
        //        case IhtModbusParamDyn.eIdxProcessInfo.CurrOutHeatO2: return IsPressurePsi ? txtPsi : txtBar;
        //        case IhtModbusParamDyn.eIdxProcessInfo.CurrOutCutO2: return IsPressurePsi ? txtPsi : txtBar;
        //        case IhtModbusParamDyn.eIdxProcessInfo.CurrOutFuelGas: return IsPressurePsi ? txtPsi : txtBar;
        //        case IhtModbusParamDyn.eIdxProcessInfo.CurrHeatTime: return "s";
        //        case IhtModbusParamDyn.eIdxProcessInfo.CurrOxyfuelProcState: return " ";
        //        case IhtModbusParamDyn.eIdxProcessInfo.CurrCutCycleState: return " ";
        //        case IhtModbusParamDyn.eIdxProcessInfo.CurrUB24V: return "V";
        //        case IhtModbusParamDyn.eIdxProcessInfo.UB24VMin: return "V";
        //        case IhtModbusParamDyn.eIdxProcessInfo.UB24VMax: return "V";
        //        case IhtModbusParamDyn.eIdxProcessInfo.LinearDrivePosition: return IsUnitInch ? txtInch : txtMm;
        //        case IhtModbusParamDyn.eIdxProcessInfo.IgnitionFlameAdjustParamDisabled: return " ";
        //        case IhtModbusParamDyn.eIdxProcessInfo.CurrCutO2BlowoutTime: return "s";
        //        case IhtModbusParamDyn.eIdxProcessInfo.CurrSetupExecSetup: return " ";
        //        case IhtModbusParamDyn.eIdxProcessInfo.CurrSetupExecTestPressureOut: return " ";
        //        case IhtModbusParamDyn.eIdxProcessInfo.CurrPasswordLevel: return " ";
        //        case IhtModbusParamDyn.eIdxProcessInfo.ClearanceOut_digit: return "digit";
        //        case IhtModbusParamDyn.eIdxProcessInfo.ClearanceOut_mV: return "V";
        //    }
        //    return " ";
        //}

        /// <summary>
        /// 
        /// </summary>
        //public static string GetCmdExec(UInt16 u16Idx)
        //{
        //    IhtModbusParamDyn.eIdxCmdExec eIdx = (IhtModbusParamDyn.eIdxCmdExec)u16Idx;
        //    switch (eIdx)
        //    {
        //        case IhtModbusParamDyn.eIdxCmdExec.Tactile: return " ";
        //        case IhtModbusParamDyn.eIdxCmdExec.Switch: return " ";
        //        case IhtModbusParamDyn.eIdxCmdExec.HeightCtrl: return " ";
        //        case IhtModbusParamDyn.eIdxCmdExec.InputEmulation: return " ";
        //        case IhtModbusParamDyn.eIdxCmdExec.SwitchSet: return " ";
        //        case IhtModbusParamDyn.eIdxCmdExec.SwitchClr: return " ";
        //    }
        //    return " ";
        //}

        /// <summary>
        /// 
        /// </summary>
        //public static string GetSetupExec(UInt16 u16Idx)
        //{
        //    IhtModbusParamDyn.eIdxSetupExec eIdx = (IhtModbusParamDyn.eIdxSetupExec)u16Idx;
        //    switch (eIdx)
        //    {
        //        case IhtModbusParamDyn.eIdxSetupExec.HeartbeatTimeout: return "ms";
        //        case IhtModbusParamDyn.eIdxSetupExec.Heartbeat: return " ";
        //        case IhtModbusParamDyn.eIdxSetupExec.Setup: return " ";
        //        case IhtModbusParamDyn.eIdxSetupExec.TestPressureOut: return " ";
        //        case IhtModbusParamDyn.eIdxSetupExec.HeatO2: return IsPressurePsi ? txtPsi : txtBar;
        //        case IhtModbusParamDyn.eIdxSetupExec.CutO2: return IsPressurePsi ? txtPsi : txtBar;
        //        case IhtModbusParamDyn.eIdxSetupExec.FuelGas: return IsPressurePsi ? txtPsi : txtBar;
        //    }
        //    return " ";
        //}
    }
}
