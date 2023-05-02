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
    class IhtModbusDescriptionParamDyn
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

        public static int iPierceMode { get; set; }
        public static int iGasType { get; set; }

        static IhtModbusDescriptionParamDyn()
        {
            iPierceMode = -1;
            iGasType = -1;
        }

        public static string GetAdditional(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxAdditional Idx = (IhtModbusParamDyn.eIdxAdditional)u16Idx;
            switch (Idx)
            {
                case IhtModbusParamDyn.eIdxAdditional.RetractPosition: return "Retract Position";
                case IhtModbusParamDyn.eIdxAdditional.StartPreflow: return "Start Preflow";
                case IhtModbusParamDyn.eIdxAdditional.PreflowActive: return "Preflow Active";
                case IhtModbusParamDyn.eIdxAdditional.PiercingHeightControl: return "Piercing Height Control";
                case IhtModbusParamDyn.eIdxAdditional.PiercingDetection: return "Piercing Detection";
                case IhtModbusParamDyn.eIdxAdditional.HeightControlActive: return "Height Control Active";
            }
            return "unknown";
        }

        public static string GetStatusHeightCtrl(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eStatusHeightCtrl Idx = (IhtModbusParamDyn.eStatusHeightCtrl)u16Idx;
            switch (Idx)
            {
                case IhtModbusParamDyn.eStatusHeightCtrl.Off: return "Off";
                case IhtModbusParamDyn.eStatusHeightCtrl.HeightPreHeat: return "Height PreHeat";
                case IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce: return "Height Pierce";
                case IhtModbusParamDyn.eStatusHeightCtrl.HeightCut: return "Height Cut";
            }
            return "unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetTechnology(UInt16 u16Idx)
        {
            return GetTechnology(u16Idx, 65535);
        }
        public static string GetTechnology(UInt16 u16Idx, UInt16 u16Value)
        {
            IhtModbusParamDyn.eIdxTechnology Idx = (IhtModbusParamDyn.eIdxTechnology)u16Idx;
            switch (Idx)
            {
                case IhtModbusParamDyn.eIdxTechnology.PreHeatHeight: return "Pre Heat Height";
                case IhtModbusParamDyn.eIdxTechnology.PierceHeight: return "Pierce Height";
                case IhtModbusParamDyn.eIdxTechnology.CutHeight: return "Cut Height";
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition: return IsPasswordLevel_SwLevel_1 ? "HeatO2 Ignition" : "PI0";
                case IhtModbusParamDyn.eIdxTechnology.HeatO2PreHeat: return "HeatO2 Pre Heat";
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Pierce: return "HeatO2 Pierce";
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Cut: return "HeatO2 Cut";
                case IhtModbusParamDyn.eIdxTechnology.CutO2Pierce: return "CutO2 Pierce";
                case IhtModbusParamDyn.eIdxTechnology.CutO2Cut: return "CutO2 Cut";
                case IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition: return IsPasswordLevel_SwLevel_1 ? "FuelGas Ignition" : "PI1";
                case IhtModbusParamDyn.eIdxTechnology.FuelGasPreHeat: return "FuelGas Pre Heat";
                case IhtModbusParamDyn.eIdxTechnology.FuelGasPierce: return "FuelGas Pierce";
                case IhtModbusParamDyn.eIdxTechnology.FuelGasCut: return "FuelGas Cut";
                case IhtModbusParamDyn.eIdxTechnology.PreHeatTime: return "Pre Heat Time";
                case IhtModbusParamDyn.eIdxTechnology.PiercePreTime: return IsPasswordValid ? "Pierce Pre Time" : "PP1";
                case IhtModbusParamDyn.eIdxTechnology.PierceTime: return "Pierce Time";
                case IhtModbusParamDyn.eIdxTechnology.PiercePostTime: return IsPasswordValid ? "Pierce Post Time" : "PP2";
                case IhtModbusParamDyn.eIdxTechnology.PierceHeightRampTime: return IsPasswordValid ? "Pierce Height Ramp Time" : "PP3";
                case IhtModbusParamDyn.eIdxTechnology.CutHeightRampTime: return IsPasswordValid ? "Cut Height Ramp Time" : "PP4";
                case IhtModbusParamDyn.eIdxTechnology.PierceMode: return IsPasswordValid ? (iPierceMode == 0) ? "Pierce Mode absolute" : (iPierceMode == 1) ? "Pierce Mode realtive" : "PP0" : "PP0";
                case IhtModbusParamDyn.eIdxTechnology.IgnitionFlameAdjust: return "Ignition Flame Adjust";
                //case IhtModbusParamDyn.eIdxTechnology.GasType                 : return (iGasType == 1) ? "Gas Type: Acetylene" : (iGasType == 1) ? "Gas Type: Propane" : "Gas Type";
                case IhtModbusParamDyn.eIdxTechnology.GasType: return (iGasType == 1) ? "Gas Type: Acetylene" : (iGasType == 0) ? "Gas Type: Propane" : "Gas Type: unknown";
                case IhtModbusParamDyn.eIdxTechnology.CuttingSpeed: return "Cutting Speed";
                case IhtModbusParamDyn.eIdxTechnology.PierceCuttingSpeedChange: return "Pierce Cutting Speed Change";
                case IhtModbusParamDyn.eIdxTechnology.ControlBits: return IsPasswordValid ? "Control Bits" : "PC0";
            }
            return "unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetProcess(UInt16 u16Idx)
        {
            return GetProcess(u16Idx, 65535);
        }
        public static string GetProcess(UInt16 u16Idx, UInt16 u16Value)
        {
            IhtModbusParamDyn.eIdxProcess eIdx = (IhtModbusParamDyn.eIdxProcess)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxProcess.RetractHeight: return "Retract Height";
                case IhtModbusParamDyn.eIdxProcess.SlagSensitivity:
                    {
                        //string result = CultureResources.GetString("_CultureParamSlagSensitivity");//"Slag Sensitivity";
                        //switch (u16Value)
                        //{
                        //    case 0: result += $": {CultureResources.GetString("_CultureParamOff")}"/*off"    */; break;
                        //    case 1: result += $": {CultureResources.GetString("_CultureParamLow")}"/*low"    */; break;
                        //    case 2: result += $": {CultureResources.GetString("_CultureParamDefault")}"/*default"*/; break;
                        //    case 3: result += $": {CultureResources.GetString("_CultureParamHigh")}"/*high"   */; break;
                        //}
                        //return result;

                        string result = "Slag Sensitivity";
                        switch (u16Value)
                        {
                            case 0: result += $": off"; break;
                            case 1: result += $": low"; break;
                            case 2: result += $": default"; break;
                            case 3: result += $": high"; break;
                        }
                        return result;
                    }
                case IhtModbusParamDyn.eIdxProcess.HeatO2Temper: return "HeatO2 Temper";
                case IhtModbusParamDyn.eIdxProcess.FuelGasTemper: return "FuelGas Temper";
                case IhtModbusParamDyn.eIdxProcess.HeightTemper: return "Height Temper";
                case IhtModbusParamDyn.eIdxProcess.LinearDriveManualPosSpeed: return "LD Manual Position Speed";
                case IhtModbusParamDyn.eIdxProcess.FuelGasOffset: return "FuelGas Offset";
                case IhtModbusParamDyn.eIdxProcess.FlashbackSensivitity:
                    {
                        //string result = CultureResources.GetString("_CultureParamFlashbackSensitivity");//"Flashback Sensivitity";
                        //switch (u16Value)
                        //{
                        //    case 0: result += $": {CultureResources.GetString("_CultureParamOff")}"/*off"    */; break;
                        //    case 1: result += $": {CultureResources.GetString("_CultureParamLow")}"/*low"    */; break;
                        //    case 2: result += $": {CultureResources.GetString("_CultureParamDefault")}"/*default"*/; break;
                        //    case 3: result += $": {CultureResources.GetString("_CultureParamHigh")}"/*high"   */; break;
                        //}
                        //return result;

                        string result = "Flashback Sensivitity";
                        switch (u16Value)
                        {
                            case 0: result += $": off"; break;
                            case 1: result += $": low"; break;
                            case 2: result += $": default"; break;
                            case 3: result += $": high"; break;
                        }
                        return result;
                    }
                #region Slag
                case IhtModbusParamDyn.eIdxProcess.SlagIntervalTime: return "Slag IntervalTime";
                case IhtModbusParamDyn.eIdxProcess.SlagFirstSlagTime: return "Slag FirstSlagTime";
                case IhtModbusParamDyn.eIdxProcess.SlagSecurityTime: return "Slag SecurityTime";
                case IhtModbusParamDyn.eIdxProcess.SlagPostTime: return "Slag PostTime";
                case IhtModbusParamDyn.eIdxProcess.SlagActiveGradient: return "Slag ActiveGradient";
                case IhtModbusParamDyn.eIdxProcess.SlagInActiveGradient: return "Slag InActiveGradient";
                #endregion // Slag
                case IhtModbusParamDyn.eIdxProcess.IgnitionDetectionEnable:
                    {
                        //string result = CultureResources.GetString("_CultureParamIgnitionDetection");//"Ignition Detection";
                        //switch (u16Value)
                        //{
                        //    case 0: result += $": {CultureResources.GetString("_CultureParamDisabled")}"/*": disabled"*/; break;
                        //    case 1: result += $": {CultureResources.GetString("_CultureParamEnabled")}"/*": enabled" */; break;
                        //}
                        //return result;

                        string result = "Ignition Detection";
                        switch (u16Value)
                        {
                            case 0: result += $": disabled"; break;
                            case 1: result += $": enabled"; break;
                        }
                        return result;
                    }
                case IhtModbusParamDyn.eIdxProcess.PiercingSensorMode:
                    {
                        //string result = CultureResources.GetString("_CultureParamPiercingHeightControl");//"Piercing Height Control";
                        //switch (u16Value)
                        //{
                        //    case 0: result += $": {CultureResources.GetString("_CultureParamDisabled")}"/*": disabled"*/; break;
                        //    case 1: result += $": {CultureResources.GetString("_CultureParamEnabled")}"/*": enabled" */; break;
                        //}
                        //return result;

                        string result = "Piercing Height Control";
                        switch (u16Value)
                        {
                            case 0: result += $": disabled"; break;
                            case 1: result += $": enabled"; break;
                        }
                        return result;
                    }
            }
            return "unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetConfig(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxConfig eIdx = (IhtModbusParamDyn.eIdxConfig)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedFast: return "LD Up Speed fast";
                case IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedSlow: return "LD Up Speed slow";
                case IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedFast: return "LD Down Speed fast";
                case IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedSlow: return "LD Down Speed slow";
                case IhtModbusParamDyn.eIdxConfig.Dynamic: return "Dynamic";
                case IhtModbusParamDyn.eIdxConfig.SensorCollisionDelay: return "Sensor Collision Delay";
                case IhtModbusParamDyn.eIdxConfig.LinearDriveRefSpeed: return "LD Reference Speed";
                case IhtModbusParamDyn.eIdxConfig.LinearDrivePosSpeed: return "LD Position Speed";
                case IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding: return "Tactile Initial Position Finding Enable";
                case IhtModbusParamDyn.eIdxConfig.DistanceCalibration: return "Distance Calibration";
                case IhtModbusParamDyn.eIdxConfig.HoseLength: return "Hose Length";
                case IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime: return "PreFlow Time";
                case IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure: return "PreFlow Pressure";
                case IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut: return "PreFlow Timeout";
                case IhtModbusParamDyn.eIdxConfig.CapSetpointFlameOffs: return "CapSetpoint FlameOffset Enable";
                case IhtModbusParamDyn.eIdxConfig.LoadDefaultParameter: return "Load Default Parameter";
            }
            return "unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetService(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxService eIdx = (IhtModbusParamDyn.eIdxService)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxService.IgnitionPreFlowMultiplier: return "Ignition PreFlow Multiplier";
                case IhtModbusParamDyn.eIdxService.IgnitionOnDurationTime: return "Ignition Duration time";
                case IhtModbusParamDyn.eIdxService.HeatO2PostFlowMultiplier: return "HeatO2 PostFlow Multiplier";
                case IhtModbusParamDyn.eIdxService.HeatO2PostFlowPressure: return "HeatO2 PostFlow Pressure";
                case IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction: return "Slag Cutting Speed Reduction";
                case IhtModbusParamDyn.eIdxService.SensorCollisionOutputDisable: return "Sensor Collision Output Disable";
                case IhtModbusParamDyn.eIdxService.PidErrorThresholdDelay: return "Pid Error Threshold Delay";
                case IhtModbusParamDyn.eIdxService.ToleranceInPosition: return "Tolerance InPosition";
                case IhtModbusParamDyn.eIdxService.Fit3ValveDelay: return "Fit+3 Solenoid Valve Delay";
                case IhtModbusParamDyn.eIdxService.Fit3ValveDuration: return "Fit+3 Solenoid Valve Duration";
                case IhtModbusParamDyn.eIdxService.Fit3GlowPlugDelay: return "Fit+3 Glow Plug Delay";
                case IhtModbusParamDyn.eIdxService.Fit3GlowPlugDuration: return "Fit+3 Glow Plug Duration";
                case IhtModbusParamDyn.eIdxService.Fit3GlowPlugSetpoint: return "Fit+3 Glow Plug Setpoint";
                case IhtModbusParamDyn.eIdxService.Fit3SaveIgnitionData: return "Fit+3 Save Ignition Data";
            }
            return "unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetProcessInfo(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxProcessInfo eIdx = (IhtModbusParamDyn.eIdxProcessInfo)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxProcessInfo.ErrorCode: return "Error Code";
                case IhtModbusParamDyn.eIdxProcessInfo.Status: return "Status 1";
                case IhtModbusParamDyn.eIdxProcessInfo.Status2: return "Status 2";
                case IhtModbusParamDyn.eIdxProcessInfo.StatusLeds: return "Status Led's";
                case IhtModbusParamDyn.eIdxProcessInfo.StatusInputs: return "Status Inputs";
                case IhtModbusParamDyn.eIdxProcessInfo.StatusOutputs: return "Status Outputs";
                case IhtModbusParamDyn.eIdxProcessInfo.StatusHeightControl: return "Status Height Control";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrOutHeatO2: return "Current output pressure HeatO2";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrOutCutO2: return "Current output pressure CutO2";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrOutFuelGas: return "Current output pressure FuelGas";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrHeatTime: return "Current Pre Heat Time";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrOxyfuelProcState: return "Current oxyfuel process status";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrCutCycleState: return "Current cut cycle status";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrUB24V: return "Current UB+24V";
                case IhtModbusParamDyn.eIdxProcessInfo.UB24VMin: return "Minimal value UB+24V";
                case IhtModbusParamDyn.eIdxProcessInfo.UB24VMax: return "Maximal value UB+24V";
                case IhtModbusParamDyn.eIdxProcessInfo.LinearDrivePosition: return "Linear Drive Position";
                case IhtModbusParamDyn.eIdxProcessInfo.IgnitionFlameAdjustParamDisabled: return "Ignition Flame Adjust Parameter disabled";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrCutO2BlowoutTime: return "Current PreFlow Time";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrSetupExecSetup: return "Current Setup Execution";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrSetupExecTestPressureOut: return "Current TestPressure-Out";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrPasswordLevel: return "Current Password Level";
                case IhtModbusParamDyn.eIdxProcessInfo.ClearanceOut_digit: return "Clearance Out digit";
                case IhtModbusParamDyn.eIdxProcessInfo.ClearanceOut_mV: return "Clearance Out Volt";
            }
            return "unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetCmdExec(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxCmdExec eIdx = (IhtModbusParamDyn.eIdxCmdExec)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxCmdExec.Tactile: return "Command exec. tactile";
                case IhtModbusParamDyn.eIdxCmdExec.Switch: return "Command exec. switch";
                case IhtModbusParamDyn.eIdxCmdExec.HeightCtrl: return "Height Control";
                case IhtModbusParamDyn.eIdxCmdExec.InputEmulation: return "Input Emulation";
                case IhtModbusParamDyn.eIdxCmdExec.InputEmulation_2: return "Input Emulation 2";
                case IhtModbusParamDyn.eIdxCmdExec.SwitchSet: return "Command exec. switch set";
                case IhtModbusParamDyn.eIdxCmdExec.SwitchClr: return "Command exec. switch clear";
                case IhtModbusParamDyn.eIdxCmdExec.InputEmulationSet: return "Input Emulation set";
                case IhtModbusParamDyn.eIdxCmdExec.InputEmulationClr: return "Input Emulation clear";
                case IhtModbusParamDyn.eIdxCmdExec.InputEmulation_2_Set: return "Input Emulation 2 set";
                case IhtModbusParamDyn.eIdxCmdExec.InputEmulation_2_Clr: return "Input Emulation 2 clear";
            }
            return "unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetSetupExec(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxSetupExec eIdx = (IhtModbusParamDyn.eIdxSetupExec)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxSetupExec.HeartbeatTimeout: return "Heartbeat Timeout";
                case IhtModbusParamDyn.eIdxSetupExec.Heartbeat: return "Heartbeat";
                case IhtModbusParamDyn.eIdxSetupExec.Setup: return "Setup execution";
                case IhtModbusParamDyn.eIdxSetupExec.TestPressureOut: return "Test Pressure Output";
                case IhtModbusParamDyn.eIdxSetupExec.HeatO2: return "Test Pressure HeatO2";
                case IhtModbusParamDyn.eIdxSetupExec.CutO2: return "Test Pressure CutO2";
                case IhtModbusParamDyn.eIdxSetupExec.FuelGas: return "Test Pressure FuelGas";
            }
            return "unknown";
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// 
    class RealMultiplierParam
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

        public static UInt16 u16PierceMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static double GetDefault(UInt16 u16Idx)
        {
            return 1.0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static double GetTechnology(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxTechnology Idx = (IhtModbusParamDyn.eIdxTechnology)u16Idx;
            switch (Idx)
            {
                case IhtModbusParamDyn.eIdxTechnology.PreHeatHeight: return 0.1;
                case IhtModbusParamDyn.eIdxTechnology.PierceHeight: return 0.1;
                case IhtModbusParamDyn.eIdxTechnology.CutHeight: return 0.1;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition: return IsPasswordLevel_SwLevel_1 ? 0.001 : 1.0;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2PreHeat: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Pierce: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Cut: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.CutO2Pierce: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.CutO2Cut: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition: return IsPasswordLevel_SwLevel_1 ? 0.001 : 1.0;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasPreHeat: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasPierce: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasCut: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.PreHeatTime: return 0.1;
                case IhtModbusParamDyn.eIdxTechnology.PiercePreTime: return IsPasswordValid ? (u16PierceMode == 0) ? 0.1 : 1.0 : 1.0;
                case IhtModbusParamDyn.eIdxTechnology.PierceTime: return 0.1;
                case IhtModbusParamDyn.eIdxTechnology.PiercePostTime: return IsPasswordValid ? (u16PierceMode == 0) ? 0.1 : 1.0 : 1.0;
                case IhtModbusParamDyn.eIdxTechnology.PierceHeightRampTime: return IsPasswordValid ? 0.1 : 1.0;
                case IhtModbusParamDyn.eIdxTechnology.CutHeightRampTime: return IsPasswordValid ? 0.1 : 1.0;
                case IhtModbusParamDyn.eIdxTechnology.PierceMode: return 1.0;
                case IhtModbusParamDyn.eIdxTechnology.IgnitionFlameAdjust: return 0.1;
                case IhtModbusParamDyn.eIdxTechnology.GasType: return 1.0;
                case IhtModbusParamDyn.eIdxTechnology.CuttingSpeed: return 1.0;
                case IhtModbusParamDyn.eIdxTechnology.PierceCuttingSpeedChange: return 1.0;
                case IhtModbusParamDyn.eIdxTechnology.ControlBits: return 1.0;
            }
            return 1.0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static double GetProcess(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxProcess eIdx = (IhtModbusParamDyn.eIdxProcess)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxProcess.RetractHeight: return 1.0;
                case IhtModbusParamDyn.eIdxProcess.SlagSensitivity: return 1.0;
                case IhtModbusParamDyn.eIdxProcess.HeatO2Temper: return 0.001;
                case IhtModbusParamDyn.eIdxProcess.FuelGasTemper: return 0.001;
                case IhtModbusParamDyn.eIdxProcess.HeightTemper: return 0.1;
                case IhtModbusParamDyn.eIdxProcess.LinearDriveManualPosSpeed: return 1.0;
                case IhtModbusParamDyn.eIdxProcess.FuelGasOffset: return 1.0;
                case IhtModbusParamDyn.eIdxProcess.FlashbackSensivitity: return 0.1;
                #region Slag
                case IhtModbusParamDyn.eIdxProcess.SlagIntervalTime: return 0.01;
                case IhtModbusParamDyn.eIdxProcess.SlagFirstSlagTime: return 0.01;
                case IhtModbusParamDyn.eIdxProcess.SlagSecurityTime: return 0.001;
                case IhtModbusParamDyn.eIdxProcess.SlagPostTime: return 0.001;
                case IhtModbusParamDyn.eIdxProcess.SlagActiveGradient: return 0.01;
                case IhtModbusParamDyn.eIdxProcess.SlagInActiveGradient: return 0.01;
                    #endregion // Slag
            }
            return 1.0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static double GetConfig(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxConfig eIdx = (IhtModbusParamDyn.eIdxConfig)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedFast: return 1.0;
                case IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedSlow: return 1.0;
                case IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedFast: return 1.0;
                case IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedSlow: return 1.0;
                case IhtModbusParamDyn.eIdxConfig.Dynamic: return 1.0;
                case IhtModbusParamDyn.eIdxConfig.SensorCollisionDelay: return 0.1;
                case IhtModbusParamDyn.eIdxConfig.LinearDriveRefSpeed: return 1.0;
                case IhtModbusParamDyn.eIdxConfig.LinearDrivePosSpeed: return 1.0;
                case IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding: return 1.0;
                case IhtModbusParamDyn.eIdxConfig.DistanceCalibration: return 0.1;
                case IhtModbusParamDyn.eIdxConfig.HoseLength: return 1.0;
                case IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime: return 1.0;
                case IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure: return 0.001;
                case IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut: return 1.0;
                case IhtModbusParamDyn.eIdxConfig.CapSetpointFlameOffs: return 1.0;
                case IhtModbusParamDyn.eIdxConfig.LoadDefaultParameter: return 1.0;
            }
            return 1.0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static double GetService(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxService eIdx = (IhtModbusParamDyn.eIdxService)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxService.IgnitionPreFlowMultiplier: return 1.0;
                case IhtModbusParamDyn.eIdxService.IgnitionOnDurationTime: return 0.001;
                case IhtModbusParamDyn.eIdxService.HeatO2PostFlowMultiplier: return 1.0;
                case IhtModbusParamDyn.eIdxService.HeatO2PostFlowPressure: return 0.001;
                case IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction: return 1.0;
                case IhtModbusParamDyn.eIdxService.SensorCollisionOutputDisable: return 1.0;
                case IhtModbusParamDyn.eIdxService.PidErrorThresholdDelay: return 0.001;
                case IhtModbusParamDyn.eIdxService.ToleranceInPosition: return 1.0;
                case IhtModbusParamDyn.eIdxService.Fit3ValveDelay: return 0.001;
                case IhtModbusParamDyn.eIdxService.Fit3ValveDuration: return 0.001;
                case IhtModbusParamDyn.eIdxService.Fit3GlowPlugDelay: return 0.001;
                case IhtModbusParamDyn.eIdxService.Fit3GlowPlugDuration: return 0.001;
                case IhtModbusParamDyn.eIdxService.Fit3GlowPlugSetpoint: return 0.001;
                case IhtModbusParamDyn.eIdxService.Fit3SaveIgnitionData: return 1.0;
            }
            return 1.0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static double GetProcessInfo(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxProcessInfo eIdx = (IhtModbusParamDyn.eIdxProcessInfo)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxProcessInfo.ErrorCode: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.Status: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.StatusLeds: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.StatusInputs: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.StatusOutputs: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.StatusHeightControl: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.CurrOutHeatO2: return 0.001;
                case IhtModbusParamDyn.eIdxProcessInfo.CurrOutCutO2: return 0.001;
                case IhtModbusParamDyn.eIdxProcessInfo.CurrOutFuelGas: return 0.001;
                case IhtModbusParamDyn.eIdxProcessInfo.CurrHeatTime: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.CurrOxyfuelProcState: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.CurrCutCycleState: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.CurrUB24V: return 0.1;
                case IhtModbusParamDyn.eIdxProcessInfo.UB24VMin: return 0.1;
                case IhtModbusParamDyn.eIdxProcessInfo.UB24VMax: return 0.1;
                case IhtModbusParamDyn.eIdxProcessInfo.LinearDrivePosition: return 0.1;
                case IhtModbusParamDyn.eIdxProcessInfo.IgnitionFlameAdjustParamDisabled: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.CurrCutO2BlowoutTime: return 1.0;
            }
            return 1.0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static double GetCmdExec(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxCmdExec eIdx = (IhtModbusParamDyn.eIdxCmdExec)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxCmdExec.Tactile: return 1.0;
                case IhtModbusParamDyn.eIdxCmdExec.Switch: return 1.0;
                case IhtModbusParamDyn.eIdxCmdExec.HeightCtrl: return 1.0;
                case IhtModbusParamDyn.eIdxCmdExec.InputEmulation: return 1.0;
                case IhtModbusParamDyn.eIdxCmdExec.SwitchSet: return 1.0;
                case IhtModbusParamDyn.eIdxCmdExec.SwitchClr: return 1.0;
            }
            return 1.0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static double GetSetupExec(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxSetupExec eIdx = (IhtModbusParamDyn.eIdxSetupExec)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxSetupExec.HeartbeatTimeout: return 1.0;
                case IhtModbusParamDyn.eIdxSetupExec.Heartbeat: return 1.0;
                case IhtModbusParamDyn.eIdxSetupExec.Setup: return 1.0;
                case IhtModbusParamDyn.eIdxSetupExec.TestPressureOut: return 1.0;
                case IhtModbusParamDyn.eIdxSetupExec.HeatO2: return 0.001;
                case IhtModbusParamDyn.eIdxSetupExec.CutO2: return 0.001;
                case IhtModbusParamDyn.eIdxSetupExec.FuelGas: return 0.001;
            }
            return 1.0;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// 
    class UnitParam
    {
        public static bool IsPasswordValid { get; set; }
        public static int u16PierceMode { get; set; }

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
                case IhtModbusParamDyn.eIdxTechnology.PreHeatHeight: return "mm";
                case IhtModbusParamDyn.eIdxTechnology.PierceHeight: return "mm";
                case IhtModbusParamDyn.eIdxTechnology.CutHeight: return "mm";
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition: return IsPasswordValid ? "bar" : " ";
                case IhtModbusParamDyn.eIdxTechnology.HeatO2PreHeat: return "bar";
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Pierce: return "bar";
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Cut: return "bar";
                case IhtModbusParamDyn.eIdxTechnology.CutO2Pierce: return "bar";
                case IhtModbusParamDyn.eIdxTechnology.CutO2Cut: return "bar";
                case IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition: return IsPasswordValid ? "bar" : " ";
                case IhtModbusParamDyn.eIdxTechnology.FuelGasPreHeat: return "bar";
                case IhtModbusParamDyn.eIdxTechnology.FuelGasPierce: return "bar";
                case IhtModbusParamDyn.eIdxTechnology.FuelGasCut: return "bar";
                case IhtModbusParamDyn.eIdxTechnology.PreHeatTime: return "s";
                case IhtModbusParamDyn.eIdxTechnology.PiercePreTime: return IsPasswordValid ? (u16PierceMode == 0) ? "s" : "%" : " ";
                case IhtModbusParamDyn.eIdxTechnology.PierceTime: return "s";
                case IhtModbusParamDyn.eIdxTechnology.PiercePostTime: return IsPasswordValid ? (u16PierceMode == 0) ? "s" : "%" : " ";
                case IhtModbusParamDyn.eIdxTechnology.PierceHeightRampTime: return IsPasswordValid ? "s" : " ";
                case IhtModbusParamDyn.eIdxTechnology.CutHeightRampTime: return IsPasswordValid ? "s" : " ";
                case IhtModbusParamDyn.eIdxTechnology.PierceMode: return " ";
                case IhtModbusParamDyn.eIdxTechnology.IgnitionFlameAdjust: return "%";
                case IhtModbusParamDyn.eIdxTechnology.GasType: return " ";
                case IhtModbusParamDyn.eIdxTechnology.CuttingSpeed: return "mm/min";
                case IhtModbusParamDyn.eIdxTechnology.PierceCuttingSpeedChange: return "%";
                case IhtModbusParamDyn.eIdxTechnology.ControlBits: return " ";
            }
            return " ";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetProcess(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxProcess eIdx = (IhtModbusParamDyn.eIdxProcess)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxProcess.RetractHeight: return "mm";
                case IhtModbusParamDyn.eIdxProcess.SlagSensitivity: return " ";
                case IhtModbusParamDyn.eIdxProcess.HeatO2Temper: return "bar";
                case IhtModbusParamDyn.eIdxProcess.FuelGasTemper: return "bar";
                case IhtModbusParamDyn.eIdxProcess.HeightTemper: return "mm";
                case IhtModbusParamDyn.eIdxProcess.LinearDriveManualPosSpeed: return "%";
                case IhtModbusParamDyn.eIdxProcess.FuelGasOffset: return "%";
                case IhtModbusParamDyn.eIdxProcess.FlashbackSensivitity: return "°C";
                #region Slag
                case IhtModbusParamDyn.eIdxProcess.SlagIntervalTime: return "s";
                case IhtModbusParamDyn.eIdxProcess.SlagFirstSlagTime: return "s";
                case IhtModbusParamDyn.eIdxProcess.SlagSecurityTime: return "s";
                case IhtModbusParamDyn.eIdxProcess.SlagPostTime: return "s";
                case IhtModbusParamDyn.eIdxProcess.SlagActiveGradient: return "mm";
                case IhtModbusParamDyn.eIdxProcess.SlagInActiveGradient: return "mm";
                    #endregion // Slag
            }
            return " ";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetConfig(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxConfig eIdx = (IhtModbusParamDyn.eIdxConfig)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedFast: return "%";
                case IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedSlow: return "%";
                case IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedFast: return "%";
                case IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedSlow: return "%";
                case IhtModbusParamDyn.eIdxConfig.Dynamic: return " ";
                case IhtModbusParamDyn.eIdxConfig.SensorCollisionDelay: return "s";
                case IhtModbusParamDyn.eIdxConfig.LinearDriveRefSpeed: return "%";
                case IhtModbusParamDyn.eIdxConfig.LinearDrivePosSpeed: return "%";
                case IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding: return " ";
                case IhtModbusParamDyn.eIdxConfig.DistanceCalibration: return "mm";
                case IhtModbusParamDyn.eIdxConfig.HoseLength: return "mm";
                case IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime: return "s";
                case IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure: return "bar";
                case IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut: return "min";
                case IhtModbusParamDyn.eIdxConfig.CapSetpointFlameOffs: return " ";
                case IhtModbusParamDyn.eIdxConfig.LoadDefaultParameter: return " ";
            }
            return " ";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetService(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxService eIdx = (IhtModbusParamDyn.eIdxService)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxService.IgnitionPreFlowMultiplier: return Units.Get_ms_10mm();
                case IhtModbusParamDyn.eIdxService.IgnitionOnDurationTime: return "s";
                case IhtModbusParamDyn.eIdxService.HeatO2PostFlowMultiplier: return Units.Get_ms_10mm(); ;
                case IhtModbusParamDyn.eIdxService.HeatO2PostFlowPressure: return "bar";
                case IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction: return "%";
                case IhtModbusParamDyn.eIdxService.SensorCollisionOutputDisable: return " ";
                case IhtModbusParamDyn.eIdxService.PidErrorThresholdDelay: return "s";
                case IhtModbusParamDyn.eIdxService.ToleranceInPosition: return "%";
                case IhtModbusParamDyn.eIdxService.Fit3ValveDelay: return "s";
                case IhtModbusParamDyn.eIdxService.Fit3ValveDuration: return "s";
                case IhtModbusParamDyn.eIdxService.Fit3GlowPlugDelay: return "s";
                case IhtModbusParamDyn.eIdxService.Fit3GlowPlugDuration: return "s";
                case IhtModbusParamDyn.eIdxService.Fit3GlowPlugSetpoint: return "V";
                case IhtModbusParamDyn.eIdxService.Fit3SaveIgnitionData: return " ";
            }
            return " ";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetProcessInfo(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxProcessInfo eIdx = (IhtModbusParamDyn.eIdxProcessInfo)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxProcessInfo.ErrorCode: return " ";
                case IhtModbusParamDyn.eIdxProcessInfo.Status: return " ";
                case IhtModbusParamDyn.eIdxProcessInfo.StatusLeds: return " ";
                case IhtModbusParamDyn.eIdxProcessInfo.StatusInputs: return " ";
                case IhtModbusParamDyn.eIdxProcessInfo.StatusOutputs: return " ";
                case IhtModbusParamDyn.eIdxProcessInfo.StatusHeightControl: return " ";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrOutHeatO2: return "bar";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrOutCutO2: return "bar";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrOutFuelGas: return "bar";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrHeatTime: return "s";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrOxyfuelProcState: return " ";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrCutCycleState: return " ";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrUB24V: return "V";
                case IhtModbusParamDyn.eIdxProcessInfo.UB24VMin: return "V";
                case IhtModbusParamDyn.eIdxProcessInfo.UB24VMax: return "V";
                case IhtModbusParamDyn.eIdxProcessInfo.LinearDrivePosition: return "mm";
                case IhtModbusParamDyn.eIdxProcessInfo.IgnitionFlameAdjustParamDisabled: return " ";
                case IhtModbusParamDyn.eIdxProcessInfo.CurrCutO2BlowoutTime: return "s";
                case IhtModbusParamDyn.eIdxProcessInfo.ClearanceOut_digit: return "digit";
                case IhtModbusParamDyn.eIdxProcessInfo.ClearanceOut_mV: return "V";
            }
            return " ";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetCmdExec(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxCmdExec eIdx = (IhtModbusParamDyn.eIdxCmdExec)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxCmdExec.Tactile: return " ";
                case IhtModbusParamDyn.eIdxCmdExec.Switch: return " ";
                case IhtModbusParamDyn.eIdxCmdExec.HeightCtrl: return " ";
                case IhtModbusParamDyn.eIdxCmdExec.InputEmulation: return " ";
                case IhtModbusParamDyn.eIdxCmdExec.SwitchSet: return " ";
                case IhtModbusParamDyn.eIdxCmdExec.SwitchClr: return " ";
            }
            return " ";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetSetupExec(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxSetupExec eIdx = (IhtModbusParamDyn.eIdxSetupExec)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamDyn.eIdxSetupExec.HeartbeatTimeout: return "ms";
                case IhtModbusParamDyn.eIdxSetupExec.Heartbeat: return " ";
                case IhtModbusParamDyn.eIdxSetupExec.Setup: return " ";
                case IhtModbusParamDyn.eIdxSetupExec.TestPressureOut: return " ";
                case IhtModbusParamDyn.eIdxSetupExec.HeatO2: return "mbar";
                case IhtModbusParamDyn.eIdxSetupExec.CutO2: return "mbar";
                case IhtModbusParamDyn.eIdxSetupExec.FuelGas: return "mbar";
            }
            return " ";
        }

    }
}
