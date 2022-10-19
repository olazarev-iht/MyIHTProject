using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.IhtDev;

namespace SharedComponents.IhtModbus
{
    class IhtModbusRealMultiplierParam
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
            bool IgnorePasswordValid = false;
            return GetTechnology(u16Idx, IgnorePasswordValid);
        }
        public static double GetTechnology(UInt16 u16Idx, bool IgnorePasswordValid)
        {
            bool _isPasswordValid = IgnorePasswordValid ? true : IsPasswordValid;
            IhtModbusParamDyn.eIdxTechnology Idx = (IhtModbusParamDyn.eIdxTechnology)u16Idx;
            switch (Idx)
            {
                case IhtModbusParamDyn.eIdxTechnology.PreHeatHeight: return 0.1;
                case IhtModbusParamDyn.eIdxTechnology.PierceHeight: return 0.1;
                case IhtModbusParamDyn.eIdxTechnology.CutHeight: return 0.1;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition: return _isPasswordValid || IsPasswordLevel_SwLevel_1 ? 0.001 : 1.0;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2PreHeat: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Pierce: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Cut: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.CutO2Pierce: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.CutO2Cut: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition: return _isPasswordValid || IsPasswordLevel_SwLevel_1 ? 0.001 : 1.0;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasPreHeat: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasPierce: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasCut: return 0.001;
                case IhtModbusParamDyn.eIdxTechnology.PreHeatTime: return 0.1;
                case IhtModbusParamDyn.eIdxTechnology.PiercePreTime: return _isPasswordValid ? (u16PierceMode == 0) ? 0.1 : 1.0 : 1.0;
                case IhtModbusParamDyn.eIdxTechnology.PierceTime: return 0.1;
                case IhtModbusParamDyn.eIdxTechnology.PiercePostTime: return _isPasswordValid ? (u16PierceMode == 0) ? 0.1 : 1.0 : 1.0;
                case IhtModbusParamDyn.eIdxTechnology.PierceHeightRampTime: return _isPasswordValid ? 0.1 : 1.0;
                case IhtModbusParamDyn.eIdxTechnology.CutHeightRampTime: return _isPasswordValid ? 0.1 : 1.0;
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
                case IhtModbusParamDyn.eIdxProcess.FlashbackSensivitity: return 1.0;
                case IhtModbusParamDyn.eIdxProcess.SlagIntervalTime: return 0.01;
                case IhtModbusParamDyn.eIdxProcess.SlagFirstSlagTime: return 0.01;
                case IhtModbusParamDyn.eIdxProcess.SlagSecurityTime: return 0.1;
                case IhtModbusParamDyn.eIdxProcess.SlagPostTime: return 0.1;
                case IhtModbusParamDyn.eIdxProcess.SlagActiveGradient: return 0.01;
                case IhtModbusParamDyn.eIdxProcess.SlagInActiveGradient: return 0.01;
                case IhtModbusParamDyn.eIdxProcess.IgnitionDetectionEnable: return 1.0;
                case IhtModbusParamDyn.eIdxProcess.PiercingSensorMode: return 1.0;
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
                case IhtModbusParamDyn.eIdxProcessInfo.Status2: return 1.0;
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
                case IhtModbusParamDyn.eIdxProcessInfo.CurrSetupExecSetup: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.CurrSetupExecTestPressureOut: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.CurrPasswordLevel: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.ClearanceOut_digit: return 1.0;
                case IhtModbusParamDyn.eIdxProcessInfo.ClearanceOut_mV: return 0.001;
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
}
