using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtModbus
{
    public class IhtModbusParamDyn
    {
        /// <summary>
        /// We temporary write params into DynParams DB, 
        /// but not into Mock DB (APC)
        /// </summary>
        public enum eIdxAdditional
        {
            // Enabled/Disabled
            RetractPosition,

            //Yes/No
            StartPreflow,
            PreflowActive,

            // Enabled/Disabled
            PiercingHeightControl,
            PiercingDetection,

            //Yes/No
            HeightControlActive,
        }


        /// <summary>
        /// 
        /// </summary>
        public enum eIdxTechnology
        {
            PreHeatHeight = 0,
            PierceHeight,
            CutHeight,
            HeatO2Ignition,
            HeatO2PreHeat,
            HeatO2Pierce,
            HeatO2Cut,
            CutO2Pierce,
            CutO2Cut,
            FuelGasIgnition,
            FuelGasPreHeat,
            FuelGasPierce,
            FuelGasCut,
            PreHeatTime,
            PiercePreTime,
            PierceTime,
            PiercePostTime,
            PierceHeightRampTime,
            CutHeightRampTime,
            PierceMode,
            IgnitionFlameAdjust,
            GasType,
            CuttingSpeed,
            PierceCuttingSpeedChange,
            ControlBits,
            // ---------------
            Length
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetTechnologySimulationData(ref UInt16[] au16TechnologyDyn)
        {
            Array.Resize(ref au16TechnologyDyn, (int)eIdxTechnology.Length);
            au16TechnologyDyn[(int)eIdxTechnology.PreHeatHeight] = 80;
            au16TechnologyDyn[(int)eIdxTechnology.PierceHeight] = 100;
            au16TechnologyDyn[(int)eIdxTechnology.CutHeight] = 50;
            au16TechnologyDyn[(int)eIdxTechnology.HeatO2Ignition] = 2000;
            au16TechnologyDyn[(int)eIdxTechnology.HeatO2PreHeat] = 2000;
            au16TechnologyDyn[(int)eIdxTechnology.HeatO2Pierce] = 4000;
            au16TechnologyDyn[(int)eIdxTechnology.HeatO2Cut] = 2000;
            au16TechnologyDyn[(int)eIdxTechnology.CutO2Pierce] = 1500;
            au16TechnologyDyn[(int)eIdxTechnology.CutO2Cut] = 6000;
            au16TechnologyDyn[(int)eIdxTechnology.FuelGasIgnition] = 200;
            au16TechnologyDyn[(int)eIdxTechnology.FuelGasPreHeat] = 200;
            au16TechnologyDyn[(int)eIdxTechnology.FuelGasPierce] = 200;
            au16TechnologyDyn[(int)eIdxTechnology.FuelGasCut] = 200;
            au16TechnologyDyn[(int)eIdxTechnology.PreHeatTime] = 150;
            au16TechnologyDyn[(int)eIdxTechnology.PiercePreTime] = 0;
            au16TechnologyDyn[(int)eIdxTechnology.PierceTime] = 10;
            au16TechnologyDyn[(int)eIdxTechnology.PiercePostTime] = 0;
            au16TechnologyDyn[(int)eIdxTechnology.PierceHeightRampTime] = 0;
            au16TechnologyDyn[(int)eIdxTechnology.CutHeightRampTime] = 0;
            au16TechnologyDyn[(int)eIdxTechnology.PierceMode] = 0;
            au16TechnologyDyn[(int)eIdxTechnology.IgnitionFlameAdjust] = 500;
            au16TechnologyDyn[(int)eIdxTechnology.GasType] = 0;
            au16TechnologyDyn[(int)eIdxTechnology.CuttingSpeed] = 460;
            au16TechnologyDyn[(int)eIdxTechnology.PierceCuttingSpeedChange] = 100;
            au16TechnologyDyn[(int)eIdxTechnology.ControlBits] = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        public enum eIdxProcess
        {
            RetractHeight = 0,
            SlagSensitivity,
            HeatO2Temper,
            FuelGasTemper,
            HeightTemper,
            LinearDriveManualPosSpeed,
            FuelGasOffset,
            FlashbackSensivitity,
            #region Slag
            SlagIntervalTime,
            SlagFirstSlagTime,
            SlagSecurityTime,
            SlagPostTime,
            SlagActiveGradient,
            SlagInActiveGradient,
            #endregion // Slag
            IgnitionDetectionEnable,
            PiercingSensorMode,
            // ---------------
            Length
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetProcessSimulationData(ref UInt16[] au16ProcessDyn)
        {
            Array.Resize(ref au16ProcessDyn, (int)eIdxProcess.Length);
            au16ProcessDyn[(int)eIdxProcess.RetractHeight] = 100;
            au16ProcessDyn[(int)eIdxProcess.SlagSensitivity] = 2;
            au16ProcessDyn[(int)eIdxProcess.HeatO2Temper] = 500;
            au16ProcessDyn[(int)eIdxProcess.FuelGasTemper] = 0;
            au16ProcessDyn[(int)eIdxProcess.HeightTemper] = 80;
            au16ProcessDyn[(int)eIdxProcess.LinearDriveManualPosSpeed] = 20;
            au16ProcessDyn[(int)eIdxProcess.FuelGasOffset] = 100;
            au16ProcessDyn[(int)eIdxProcess.FlashbackSensivitity] = 2;
            #region Slag                                             
            au16ProcessDyn[(int)eIdxProcess.SlagIntervalTime] = 50;
            au16ProcessDyn[(int)eIdxProcess.SlagFirstSlagTime] = 25;
            au16ProcessDyn[(int)eIdxProcess.SlagSecurityTime] = 100;
            au16ProcessDyn[(int)eIdxProcess.SlagPostTime] = 20;
            au16ProcessDyn[(int)eIdxProcess.SlagActiveGradient] = 100;
            au16ProcessDyn[(int)eIdxProcess.SlagInActiveGradient] = 100;
            #endregion // Slag
            au16ProcessDyn[(int)eIdxProcess.IgnitionDetectionEnable] = 1;
            au16ProcessDyn[(int)eIdxProcess.PiercingSensorMode] = 1;
        }


        /// <summary>
        /// 
        /// </summary>
        public enum eIdxConfig
        {
            LinearDriveUpSpeedFast = 0,
            LinearDriveUpSpeedSlow,
            LinearDriveDnSpeedFast,
            LinearDriveDnSpeedSlow,
            Dynamic,
            SensorCollisionDelay,
            LinearDriveRefSpeed,
            LinearDrivePosSpeed,
            [Description("Automatic Height Calibration")]
            TactileInitialPosFinding,
            DistanceCalibration,
            HoseLength,
            CutO2BlowOutTime,
            CutO2BlowOutPressure,
            CutO2BlowOutTimeOut,
            CapSetpointFlameOffs,
            LoadDefaultParameter,

            // ---------------
            Length
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetConfigSimulationData(ref UInt16[] au16ConfigDyn)
        {
            Array.Resize(ref au16ConfigDyn, (int)eIdxConfig.Length);
            au16ConfigDyn[(int)eIdxConfig.LinearDriveUpSpeedFast] = 90;
            au16ConfigDyn[(int)eIdxConfig.LinearDriveUpSpeedSlow] = 45;
            au16ConfigDyn[(int)eIdxConfig.LinearDriveDnSpeedFast] = 65;
            au16ConfigDyn[(int)eIdxConfig.LinearDriveDnSpeedSlow] = 45;
            au16ConfigDyn[(int)eIdxConfig.Dynamic] = 35;
            au16ConfigDyn[(int)eIdxConfig.SensorCollisionDelay] = 10;
            au16ConfigDyn[(int)eIdxConfig.LinearDriveRefSpeed] = 43;
            au16ConfigDyn[(int)eIdxConfig.LinearDrivePosSpeed] = 95;
            au16ConfigDyn[(int)eIdxConfig.TactileInitialPosFinding] = 1;
            au16ConfigDyn[(int)eIdxConfig.DistanceCalibration] = 0;
            au16ConfigDyn[(int)eIdxConfig.HoseLength] = 1500;
            au16ConfigDyn[(int)eIdxConfig.CutO2BlowOutTime] = 5;
            au16ConfigDyn[(int)eIdxConfig.CutO2BlowOutPressure] = 2500;
            au16ConfigDyn[(int)eIdxConfig.CutO2BlowOutTimeOut] = 240;
            au16ConfigDyn[(int)eIdxConfig.CapSetpointFlameOffs] = 0;
            au16ConfigDyn[(int)eIdxConfig.LoadDefaultParameter] = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        public enum eIdxService
        {
            IgnitionPreFlowMultiplier = 0,
            IgnitionOnDurationTime,
            HeatO2PostFlowMultiplier,
            HeatO2PostFlowPressure,
            SlagCuttingSpeedReduction,
            SensorCollisionOutputDisable,
            PidErrorThresholdDelay,
            ToleranceInPosition,
            Fit3ValveDelay,
            Fit3ValveDuration,
            Fit3GlowPlugDelay,
            Fit3GlowPlugDuration,
            Fit3GlowPlugSetpoint,
            Fit3SaveIgnitionData,

            // ---------------
            Length
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetServiceSimulationData(ref UInt16[] au16ServiceConst)
        {
            Array.Resize(ref au16ServiceConst, (int)eIdxService.Length);
            au16ServiceConst[(int)eIdxService.IgnitionPreFlowMultiplier] = 4;
            au16ServiceConst[(int)eIdxService.IgnitionOnDurationTime] = 1000;
            au16ServiceConst[(int)eIdxService.HeatO2PostFlowMultiplier] = 7;
            au16ServiceConst[(int)eIdxService.HeatO2PostFlowPressure] = 1000;
            au16ServiceConst[(int)eIdxService.SlagCuttingSpeedReduction] = 100;
            au16ServiceConst[(int)eIdxService.SensorCollisionOutputDisable] = 0;
            au16ServiceConst[(int)eIdxService.PidErrorThresholdDelay] = 0;
            au16ServiceConst[(int)eIdxService.ToleranceInPosition] = 50;
            au16ServiceConst[(int)eIdxService.Fit3ValveDelay] = 0;
            au16ServiceConst[(int)eIdxService.Fit3ValveDuration] = 3200;
            au16ServiceConst[(int)eIdxService.Fit3GlowPlugDelay] = 200;
            au16ServiceConst[(int)eIdxService.Fit3GlowPlugDuration] = 3000;
            au16ServiceConst[(int)eIdxService.Fit3GlowPlugSetpoint] = 1400;
            au16ServiceConst[(int)eIdxService.Fit3SaveIgnitionData] = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        public enum eIdxProcessInfo
        {
            ErrorCode = 0,
            Status,
            Status2,
            StatusLeds,
            StatusInputs,
            StatusOutputs,
            StatusHeightControl,
            CurrOutHeatO2,
            CurrOutCutO2,
            CurrOutFuelGas,
            CurrHeatTime,
            CurrOxyfuelProcState,
            CurrCutCycleState,
            CurrUB24V,
            UB24VMin,
            UB24VMax,
            LinearDrivePosition,
            IgnitionFlameAdjustParamDisabled,
            CurrCutO2BlowoutTime,
            CurrSetupExecSetup,
            CurrSetupExecTestPressureOut,
            CurrPasswordLevel,
            ClearanceOut_digit,
            ClearanceOut_mV,

            // ---------------
            Length
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetProcessInfoSimulationData(ref UInt16[] au16ProcInfo)
        {
            Array.Resize(ref au16ProcInfo, (int)eIdxProcessInfo.Length);
            au16ProcInfo[(int)eIdxProcessInfo.ErrorCode] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.Status] = 2369;
            au16ProcInfo[(int)eIdxProcessInfo.Status2] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.StatusLeds] = 64;
            au16ProcInfo[(int)eIdxProcessInfo.StatusInputs] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.StatusOutputs] = 4;
            au16ProcInfo[(int)eIdxProcessInfo.StatusHeightControl] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.CurrOutHeatO2] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.CurrOutCutO2] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.CurrOutFuelGas] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.CurrHeatTime] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.CurrOxyfuelProcState] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.CurrCutCycleState] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.CurrUB24V] = 240;
            au16ProcInfo[(int)eIdxProcessInfo.UB24VMin] = 239;
            au16ProcInfo[(int)eIdxProcessInfo.UB24VMax] = 241;
            au16ProcInfo[(int)eIdxProcessInfo.LinearDrivePosition] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.IgnitionFlameAdjustParamDisabled] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.CurrCutO2BlowoutTime] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.CurrSetupExecSetup] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.CurrSetupExecTestPressureOut] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.CurrPasswordLevel] = (UInt16)IhtModbusData.ePassword.Level_2;
            au16ProcInfo[(int)eIdxProcessInfo.ClearanceOut_digit] = 0;
            au16ProcInfo[(int)eIdxProcessInfo.ClearanceOut_mV] = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        public enum eIdxCmdExec
        {
            Tactile = 0,
            Switch,
            HeightCtrl,
            InputEmulation,
            InputEmulation_2,
            SwitchSet,
            SwitchClr,
            InputEmulationSet,
            InputEmulationClr,
            InputEmulation_2_Set,
            InputEmulation_2_Clr,

            // ---------------
            Length
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetCmdExecSimulationData(ref UInt16[] au16CmdExec)
        {
            Array.Resize(ref au16CmdExec, (int)eIdxCmdExec.Length);
            au16CmdExec[(int)eIdxCmdExec.Tactile] = 0;
            au16CmdExec[(int)eIdxCmdExec.Switch] = 4;
            au16CmdExec[(int)eIdxCmdExec.HeightCtrl] = 0;
            au16CmdExec[(int)eIdxCmdExec.InputEmulation] = 0;
            au16CmdExec[(int)eIdxCmdExec.InputEmulation_2] = 0;
            au16CmdExec[(int)eIdxCmdExec.SwitchSet] = 0;
            au16CmdExec[(int)eIdxCmdExec.SwitchClr] = 0;
            au16CmdExec[(int)eIdxCmdExec.InputEmulationSet] = 0;
            au16CmdExec[(int)eIdxCmdExec.InputEmulationClr] = 0;
            au16CmdExec[(int)eIdxCmdExec.InputEmulation_2_Set] = 0;
            au16CmdExec[(int)eIdxCmdExec.InputEmulation_2_Clr] = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        public const UInt16 u16SetupExecHeartbeatValue = 0xA5A5;
        public enum eIdxSetupExec
        {
            HeartbeatTimeout = 0,
            Heartbeat,
            Setup,
            TestPressureOut,
            HeatO2,
            CutO2,
            FuelGas,

            // ---------------
            Length
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetSetupExecSimulationData(ref UInt16[] au16SetupExec)
        {
            Array.Resize(ref au16SetupExec, (int)eIdxSetupExec.Length);
            au16SetupExec[(int)eIdxSetupExec.HeartbeatTimeout] = 0;
            au16SetupExec[(int)eIdxSetupExec.Heartbeat] = 0;
            au16SetupExec[(int)eIdxSetupExec.Setup] = 0;
            au16SetupExec[(int)eIdxSetupExec.TestPressureOut] = 0;
            au16SetupExec[(int)eIdxSetupExec.HeatO2] = 0;
            au16SetupExec[(int)eIdxSetupExec.CutO2] = 0;
            au16SetupExec[(int)eIdxSetupExec.FuelGas] = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        public enum eIdxData
        {
            DataRxMaxLength,
            DataTxMaxLength,
            DataStart,
            DataLength,
            Data00, Data01, Data02, Data03, Data04, Data05, Data06, Data07,
            Data08, Data09, Data10, Data11, Data12, Data13, Data14, Data15,
            Data16, Data17, Data18, Data19, Data20, Data21, Data22, Data23,
            Data24, Data25, Data26, Data27, Data28, Data29, Data30, Data31,
            Data32, Data33, Data34, Data35, Data36, Data37, Data38, Data39,
            Data40, Data41, Data42, Data43, Data44, Data45, Data46, Data47,
            Data48, Data49, Data50, Data51, Data52, Data53, Data54, Data55,
            Data56, Data57, Data58, Data59, Data60, Data61, Data62, Data63,
            DataIdx,

            // ---------------
            Length,
            DataMaxLength = (Data63 - Data00 + 1)
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetDataSimulationData(ref UInt16[] au16Data)
        {
            Array.Resize(ref au16Data, (int)eIdxData.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        public enum eIdxTable
        {
            CutCycleStateLabelTbl,
            CutCycleStateCurrTbl,
            CutCycleStatePrevTbl,
            ErrorLabelTbl,
            ErrorEepromTbl,
            MenuParamTbl,
            OxyProcCutCycleStateLabelTbl,
            OxyProcCutCycleStateCurrTbl,
            OxyProcCutCycleStatePrevTbl,
            TempHistogramuCTbl,
            HistogramCommonTbl,
            HistogramCommonCustomTbl,
            ErrorCustomTbl,
            FitPlus3HistoErrorTbl,
            FitPlus3HistoErrorCustomTbl,
            FitPlus3HistoTempuCTbl,
            FitPlus3HistoTempTopTbl,
            FitPlus3HistoTempBottomTbl,
            ErrorEepromErase,
            TempHistogramuCErase,
            HistogramCommonErase,
            HistogramCommonCustomErase,
            ErrorCustomErase,
            FitPlus3HistoErrorErase,
            FitPlus3HistoErrorCustomErase,
            FitPlus3HistoErrorAllErase,
            FitPlus3HistoTempAllErase,
            StatusGetMaxDataLength,
            StatusInfoTbl,
            StatusInfoSpecificTbl,
            StatusInfoDynamicTbl,
            StatusInfoSpecificDynamicTbl,

            // ---------------
            Length
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetTableDataSimulationData(ref UInt16[] au16TableData)
        {
            Array.Resize(ref au16TableData, (int)eIdxTable.Length);
        }

        /*
            /// <summary>
            /// 
            /// </summary>
            public enum eCmExecTactileBit
            {
              ClrErrorCode               = 0x0001,
              Ignite                     = 0x0002,
              ReloadPreHeatTime          = 0x0004,
              StopPreHeatTime            = 0x0008,
              ClrCapSetpointFlameOffsets = 0x0010,
              ClrPressureOutputs         = 0x0020,
              CutO2Blowout               = 0x0040,
              CutO2BlowoutBreak          = 0x0080
            }
        */
        /*
            public enum eCmdExecSwitchBit
            {
              LockPressureOutput     = 0x0001,
              FlameOnAtProcessEnd    = 0x0002,
              RetractPosAtProcessEnd = 0x0004,
              Temper                 = 0x0008
            }
        */
        /*
            /// <summary>
            /// 
            /// </summary>
            public enum eCmdExecInputEmulationBit
            {
              MoveManUp      = 0x0001,
              MoveManDown    = 0x0002,
              Calibrate      = 0x0004,
              HeightCtrlUp   = 0x0008,
              HeightCtrlDown = 0x0010
            }
        */
        /*
            /// <summary>
            /// 
            /// </summary>
            public enum eCmdExecInputEmulationBit_2
            {
              None                  = 0x0000,
              StartProcess          = 0x0001,
              DelayStartPreHeatTime = 0x0002,
            }
        */
        /*
            public enum eCmdHeightCtrl
            {
              Off = 0,
              HeightHeat,
              HeightPierce,
              HeightCut,
              HeightPierceRamp,
              HeightCutRamp,
              HeightTemper,
              HeightHeartbeat = 0x8000
            }
        */
        public enum eStatusHeightCtrl
        {
            Off = 0,
            HeightPreHeat,
            HeightPierce,
            HeightCut,
            HeightTemper
        }

        /*
            public enum eCmdSetupCtrl
            {
              Off = 0,
              Start,
              Ignition,
              Heating,
              Piercing,
              Cutting,
              CheckFlame,
              Ramp,
              Temper
            }
         */
        /*
            public enum eCmdTestPressureOutBit
            {
              HeatO2 = 0x0001,
              CutO2 = 0x0002,
              FuelGas = 0x0004
            }
        */
        public enum eStatusBit
        {
            Ready = 0x0001,
            ProcessActive = 0x0002,
            EmergencyMode = 0x0004,
            UpperPosition = 0x0008,
            ControlActive = 0x0010,
            InPosition = 0x0020,
            CalibrationValid = 0x0040,
            CalibrationActive = 0x0080,
            TactileInitPosFindEnabled = 0x0100,
            LockPressureOutputActive = 0x0200,
            FlameOnAtProcessEndEnabled = 0x0400,
            RetractPosAtProcessEndEnabled = 0x0800,
            CapSetpointFlameOffsEnabled = 0x1000,
            CutO2BlowoutActive = 0x2000,
            TemperProcessActive = 0x4000,
            AckErrorActive = 0x8000
        }

        public enum eStatus2Bit
        {
            FlameOn = 0x0001,
            ClearanceControlOff = 0x0002,
            ClearanceControlManual = 0x0004,
            TorchOff = 0x0008,
            IsIgnitionDetectionEnabled = 0x0010,
            IsIsPiercingSensorMode = 0x0020,
        }

        public enum eStatusLedBit
        {
            Ignition = 0x0001,
            PreHeating = 0x0002,
            Piercing = 0x0004,
            Cutting = 0x0008,
            Temper = 0x0010,
            CutO2Blowout = 0x0020,
            RetractPosition = 0x0040,
            UpperPosition = 0x0080,
            Error = 0x0100
        }

        public enum eStatusInpBit
        {
            ManUp = 0x0001,
            ManDown = 0x0002,
            Automatic = 0x0004,
            StartProcess = 0x0008,
            Ignite = 0x0010,
            TorchDisabled = 0x0020,
            ClearanceCtrlOff = 0x0040,
            StopHeating = 0x0080,
            Stop = 0x0100,
            ClearanceAdjustUp = 0x0200,
            ClearanceAdjustDown = 0x0400,
            CuSync = 0x0800,
            ClearanceSignalAdjust = 0x1000,
        }

        public enum eStatusOutBit
        {
            Fault = 0x0001,
            InPosition = 0x0002,
            UpperPosition = 0x0004,
            Ok2Move = 0x0008,
            SlowSpeed = 0x0010,
            Fit3_InputIgnition = 0x0020,
            Fit3_SolenoidValve = 0x0040,
            Fit3_GlowPlug = 0x0080,
            Fit3_FlameFlashback = 0x0100,
            Fit3_Error = 0x0200,
            Fit3_ErrUB24V = 0x0400,
            Fit3_ErrucTemperature = 0x0800,
            Fit3_ErrSolenoidValve = 0x1000,
            Fit3_ErrGlowPlug = 0x2000,
            Fit3_ErrCommunic = 0x4000
        }
    }
}
