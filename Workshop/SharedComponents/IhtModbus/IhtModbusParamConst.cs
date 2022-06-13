using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.IhtDev;

namespace SharedComponents.IhtModbus
{
    class IhtModbusParamConst
    {
        /// <summary>
        /// 
        /// </summary>
        public enum eIdxDeviceInfo
        {
            PartNoLWord = 0,
            PartNoHWord,
            SerialNoLWord,
            SerialNoHWord,
            HwVersion,
            FwVersion,
            FwSubVersion,

            TorchPartNoLWord,
            TorchPartNoHWord,
            TorchSerialNoLWord,
            TorchSerialNoHWord,
            TorchHwVersion,
            TorchFwVersion,
            TorchFwSubVersion,
            TorchHwFunctions,
            TorchTypeIdx,

            // ---------------
            Length
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetDevInfoSimulationData(ref UInt16[] au16DeviceInfo)
        {
            int fwMinimumVersion = IhtDevices.GetFwMinimumVersion(isRobot: false);

            Array.Resize(ref au16DeviceInfo, (int)eIdxDeviceInfo.Length);
            au16DeviceInfo[(int)eIdxDeviceInfo.PartNoLWord] = 35653; // 101189
            au16DeviceInfo[(int)eIdxDeviceInfo.PartNoHWord] = 1;
            au16DeviceInfo[(int)eIdxDeviceInfo.SerialNoLWord] = 12345; // 12345 
            au16DeviceInfo[(int)eIdxDeviceInfo.SerialNoHWord] = 0;
            au16DeviceInfo[(int)eIdxDeviceInfo.HwVersion] = 0;
            au16DeviceInfo[(int)eIdxDeviceInfo.FwVersion] = (UInt16)((fwMinimumVersion & 0xFFFF) >> 8);
            au16DeviceInfo[(int)eIdxDeviceInfo.FwSubVersion] = (UInt16)(fwMinimumVersion & 0xFF);

            au16DeviceInfo[(int)eIdxDeviceInfo.TorchPartNoLWord] = 9430; // 140502
            au16DeviceInfo[(int)eIdxDeviceInfo.TorchPartNoHWord] = 2;
            au16DeviceInfo[(int)eIdxDeviceInfo.TorchSerialNoLWord] = 0;
            au16DeviceInfo[(int)eIdxDeviceInfo.TorchSerialNoHWord] = 0;
            au16DeviceInfo[(int)eIdxDeviceInfo.TorchHwVersion] = 0;
            au16DeviceInfo[(int)eIdxDeviceInfo.TorchFwVersion] = 0;
            au16DeviceInfo[(int)eIdxDeviceInfo.TorchFwSubVersion] = 0;
            au16DeviceInfo[(int)eIdxDeviceInfo.TorchHwFunctions] = 0;
            au16DeviceInfo[(int)eIdxDeviceInfo.TorchTypeIdx] = (UInt16)IhtDevices.TorchType.Propane;
        }


        /// <summary>
        /// 
        /// </summary>
        public enum eIdxTechnology
        {
            PreHeatHeightMin = 0,
            PreHeatHeightMax,
            PreHeatHeightStep,
            PierceHeightMin,
            PierceHeightMax,
            PierceHeightStep,
            CutHeightMin,
            CutHeightMax,
            CutHeightStep,
            HeatO2IgnitionMin,
            HeatO2IgnitionMax,
            HeatO2IgnitionStep,
            HeatO2PreHeatMin,
            HeatO2PreHeatMax,
            HeatO2PreHeatStep,
            HeatO2PierceMin,
            HeatO2PierceMax,
            HeatO2PierceStep,
            HeatO2CutMin,
            HeatO2CutMax,
            HeatO2CutStep,
            CutO2PierceMin,
            CutO2PierceMax,
            CutO2PierceStep,
            CutO2CutMin,
            CutO2CutMax,
            CutO2CutStep,
            FuelGasIgnitionMin,
            FuelGasIgnitionMax,
            FuelGasIgnitionStep,
            FuelGasPreHeatMin,
            FuelGasPreHeatMax,
            FuelGasPreHeatStep,
            FuelGasPierceMin,
            FuelGasPierceMax,
            FuelGasPierceStep,
            FuelGasCutMin,
            FuelGasCutMax,
            FuelGasCutStep,
            PreHeatTimeMin,
            PreHeatTimeMax,
            PreHeatTimeStep,
            PiercePreTimeMin,
            PiercePreTimeMax,
            PiercePreTimeStep,
            PierceTimeMin,
            PierceTimeMax,
            PierceTimeStep,
            PiercePostTimeMin,
            PiercePostTimeMax,
            PiercePostTimeStep,
            PierceHeightRampTimeMin,
            PierceHeightRampTimeMax,
            PierceHeightRampTimeStep,
            CutHeightRampTimeMin,
            CutHeightRampTimeMax,
            CutHeightRampTimeStep,
            PierceModeMin,
            PierceModeMax,
            PierceModeStep,
            IgnitionFlameAdjustMin,
            IgnitionFlameAdjustMax,
            IgnitionFlameAdjustStep,
            GasTypeMin,
            GasTypeMax,
            GasTypeStep,
            CuttingSpeedMin,
            CuttingSpeedMax,
            CuttingSpeedStep,
            PierceCuttingSpeedChangeMin,
            PierceCuttingSpeedChangeMax,
            PierceCuttingSpeedChangeStep,
            ControlBitsMin,
            ControlBitsMax,
            ControlBitsStep,
            // ---------------
            Length
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetTechnologySimulationData(ref UInt16[] au16TechnologyConst)
        {
            Array.Resize(ref au16TechnologyConst, (int)eIdxTechnology.Length);
            au16TechnologyConst[(int)eIdxTechnology.PreHeatHeightMin] = 20;
            au16TechnologyConst[(int)eIdxTechnology.PreHeatHeightMax] = 200;
            au16TechnologyConst[(int)eIdxTechnology.PreHeatHeightStep] = 5;
            au16TechnologyConst[(int)eIdxTechnology.PierceHeightMin] = 20;
            au16TechnologyConst[(int)eIdxTechnology.PierceHeightMax] = 500;
            au16TechnologyConst[(int)eIdxTechnology.PierceHeightStep] = 5;
            au16TechnologyConst[(int)eIdxTechnology.CutHeightMin] = 20;
            au16TechnologyConst[(int)eIdxTechnology.CutHeightMax] = 200;
            au16TechnologyConst[(int)eIdxTechnology.CutHeightStep] = 5;
            au16TechnologyConst[(int)eIdxTechnology.HeatO2IgnitionMin] = 500;
            au16TechnologyConst[(int)eIdxTechnology.HeatO2IgnitionMax] = 5000;
            au16TechnologyConst[(int)eIdxTechnology.HeatO2IgnitionStep] = 10;
            au16TechnologyConst[(int)eIdxTechnology.HeatO2PreHeatMin] = 500;
            au16TechnologyConst[(int)eIdxTechnology.HeatO2PreHeatMax] = 5000;
            au16TechnologyConst[(int)eIdxTechnology.HeatO2PreHeatStep] = 10;
            au16TechnologyConst[(int)eIdxTechnology.HeatO2PierceMin] = 500;
            au16TechnologyConst[(int)eIdxTechnology.HeatO2PierceMax] = 5000;
            au16TechnologyConst[(int)eIdxTechnology.HeatO2PierceStep] = 10;
            au16TechnologyConst[(int)eIdxTechnology.HeatO2CutMin] = 500;
            au16TechnologyConst[(int)eIdxTechnology.HeatO2CutMax] = 5000;
            au16TechnologyConst[(int)eIdxTechnology.HeatO2CutStep] = 10;
            au16TechnologyConst[(int)eIdxTechnology.CutO2PierceMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.CutO2PierceMax] = 10000;
            au16TechnologyConst[(int)eIdxTechnology.CutO2PierceStep] = 10;
            au16TechnologyConst[(int)eIdxTechnology.CutO2CutMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.CutO2CutMax] = 10000;
            au16TechnologyConst[(int)eIdxTechnology.CutO2CutStep] = 10;
            au16TechnologyConst[(int)eIdxTechnology.FuelGasIgnitionMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.FuelGasIgnitionMax] = 1000;
            au16TechnologyConst[(int)eIdxTechnology.FuelGasIgnitionStep] = 10;
            au16TechnologyConst[(int)eIdxTechnology.FuelGasPreHeatMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.FuelGasPreHeatMax] = 1000;
            au16TechnologyConst[(int)eIdxTechnology.FuelGasPreHeatStep] = 10;
            au16TechnologyConst[(int)eIdxTechnology.FuelGasPierceMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.FuelGasPierceMax] = 1000;
            au16TechnologyConst[(int)eIdxTechnology.FuelGasPierceStep] = 10;
            au16TechnologyConst[(int)eIdxTechnology.FuelGasCutMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.FuelGasCutMax] = 1000;
            au16TechnologyConst[(int)eIdxTechnology.FuelGasCutStep] = 10;
            au16TechnologyConst[(int)eIdxTechnology.PreHeatTimeMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.PreHeatTimeMax] = 3000;
            au16TechnologyConst[(int)eIdxTechnology.PreHeatTimeStep] = 10;
            au16TechnologyConst[(int)eIdxTechnology.PiercePreTimeMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.PiercePreTimeMax] = 100;
            au16TechnologyConst[(int)eIdxTechnology.PiercePreTimeStep] = 1;
            au16TechnologyConst[(int)eIdxTechnology.PierceTimeMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.PierceTimeMax] = 100;
            au16TechnologyConst[(int)eIdxTechnology.PierceTimeStep] = 1;
            au16TechnologyConst[(int)eIdxTechnology.PiercePostTimeMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.PiercePostTimeMax] = 100;
            au16TechnologyConst[(int)eIdxTechnology.PiercePostTimeStep] = 1;
            au16TechnologyConst[(int)eIdxTechnology.PierceHeightRampTimeMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.PierceHeightRampTimeMax] = 30;
            au16TechnologyConst[(int)eIdxTechnology.PierceHeightRampTimeStep] = 1;
            au16TechnologyConst[(int)eIdxTechnology.CutHeightRampTimeMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.CutHeightRampTimeMax] = 30;
            au16TechnologyConst[(int)eIdxTechnology.CutHeightRampTimeStep] = 1;
            au16TechnologyConst[(int)eIdxTechnology.PierceModeMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.PierceModeMax] = 1;
            au16TechnologyConst[(int)eIdxTechnology.PierceModeStep] = 1;
            au16TechnologyConst[(int)eIdxTechnology.IgnitionFlameAdjustMin] = 200;
            au16TechnologyConst[(int)eIdxTechnology.IgnitionFlameAdjustMax] = 1000;
            au16TechnologyConst[(int)eIdxTechnology.IgnitionFlameAdjustStep] = 1;
            au16TechnologyConst[(int)eIdxTechnology.GasTypeMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.GasTypeMax] = 1;
            au16TechnologyConst[(int)eIdxTechnology.GasTypeStep] = 1;
            au16TechnologyConst[(int)eIdxTechnology.CuttingSpeedMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.CuttingSpeedMax] = 2000;
            au16TechnologyConst[(int)eIdxTechnology.CuttingSpeedStep] = 1;
            au16TechnologyConst[(int)eIdxTechnology.PierceCuttingSpeedChangeMin] = 50;
            au16TechnologyConst[(int)eIdxTechnology.PierceCuttingSpeedChangeMax] = 150;
            au16TechnologyConst[(int)eIdxTechnology.PierceCuttingSpeedChangeStep] = 1;
            au16TechnologyConst[(int)eIdxTechnology.ControlBitsMin] = 0;
            au16TechnologyConst[(int)eIdxTechnology.ControlBitsMax] = 65535;
            au16TechnologyConst[(int)eIdxTechnology.ControlBitsStep] = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        public enum eIdxProcess
        {
            RetractHeightMin = 0,
            RetractHeightMax,
            RetractHeightStep,
            SlagSensitivityMin,
            SlagSensitivityMax,
            SlagSensitivityStep,
            HeatO2TemperMin,
            HeatO2TemperMax,
            HeatO2TemperStep,
            FuelGasTemperMin,
            FuelGasTemperMax,
            FuelGasTemperStep,
            HeightTemperMin,
            HeightTemperMax,
            HeightTemperStep,
            LinearDriveManualPosSpeedMin,
            LinearDriveManualPosSpeedMax,
            LinearDriveManualPosSpeedStep,
            FuelGasOffsetMin,
            FuelGasOffsetMax,
            FuelGasOffsetStep,
            FlashbackSensivitityMin,
            FlashbackSensivitityMax,
            FlashbackSensivitityStep,
            #region Slag
            SlagIntervalTimeMin,
            SlagIntervalTimeMax,
            SlagIntervalTimeStep,

            SlagFirstSlagTimeMin,
            SlagFirstSlagTimeMax,
            SlagFirstSlagTimeStep,

            SlagSecurityTimeMin,
            SlagSecurityTimeMax,
            SlagSecurityTimeStep,

            SlagPostTimeMin,
            SlagPostTimeMax,
            SlagPostTimeStep,

            SlagActiveGradientMin,
            SlagActiveGradientMax,
            SlagActiveGradientStep,

            SlagInActiveGradientMin,
            SlagInActiveGradientMax,
            SlagInActiveGradientStep,
            #endregion // Slag
            IgnitionDetectionEnableMin,
            IgnitionDetectionEnableMax,
            IgnitionDetectionEnableStep,
            PiercingSensorModeMin,
            PiercingSensorModeMax,
            PiercingSensorModeStep,
            // ---------------
            Length
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetProcessSimulationData(ref UInt16[] au16ProcessConst)
        {
            Array.Resize(ref au16ProcessConst, (int)eIdxProcess.Length);
            au16ProcessConst[(int)eIdxProcess.RetractHeightMin] = 0;
            au16ProcessConst[(int)eIdxProcess.RetractHeightMax] = 500;
            au16ProcessConst[(int)eIdxProcess.RetractHeightStep] = 25;

            au16ProcessConst[(int)eIdxProcess.SlagSensitivityMin] = 0;
            au16ProcessConst[(int)eIdxProcess.SlagSensitivityMax] = 3;
            au16ProcessConst[(int)eIdxProcess.SlagSensitivityStep] = 1;

            au16ProcessConst[(int)eIdxProcess.HeatO2TemperMin] = 500;
            au16ProcessConst[(int)eIdxProcess.HeatO2TemperMax] = 5000;
            au16ProcessConst[(int)eIdxProcess.HeatO2TemperStep] = 10;

            au16ProcessConst[(int)eIdxProcess.FuelGasTemperMin] = 0;
            au16ProcessConst[(int)eIdxProcess.FuelGasTemperMax] = 1000;
            au16ProcessConst[(int)eIdxProcess.FuelGasTemperStep] = 10;

            au16ProcessConst[(int)eIdxProcess.HeightTemperMin] = 20;
            au16ProcessConst[(int)eIdxProcess.HeightTemperMax] = 200;
            au16ProcessConst[(int)eIdxProcess.HeightTemperStep] = 5;

            au16ProcessConst[(int)eIdxProcess.LinearDriveManualPosSpeedMin] = 10;
            au16ProcessConst[(int)eIdxProcess.LinearDriveManualPosSpeedMax] = 100;
            au16ProcessConst[(int)eIdxProcess.LinearDriveManualPosSpeedStep] = 1;

            au16ProcessConst[(int)eIdxProcess.FuelGasOffsetMin] = 50;
            au16ProcessConst[(int)eIdxProcess.FuelGasOffsetMax] = 150;
            au16ProcessConst[(int)eIdxProcess.FuelGasOffsetStep] = 1;

            au16ProcessConst[(int)eIdxProcess.FlashbackSensivitityMin] = 1;
            au16ProcessConst[(int)eIdxProcess.FlashbackSensivitityMax] = 3;
            au16ProcessConst[(int)eIdxProcess.FlashbackSensivitityStep] = 1;

            #region Slag
            au16ProcessConst[(int)eIdxProcess.SlagIntervalTimeMin] = 25;
            au16ProcessConst[(int)eIdxProcess.SlagIntervalTimeMax] = 150;
            au16ProcessConst[(int)eIdxProcess.SlagIntervalTimeStep] = 5;

            au16ProcessConst[(int)eIdxProcess.SlagFirstSlagTimeMin] = 10;
            au16ProcessConst[(int)eIdxProcess.SlagFirstSlagTimeMax] = 50;
            au16ProcessConst[(int)eIdxProcess.SlagFirstSlagTimeStep] = 5;

            au16ProcessConst[(int)eIdxProcess.SlagSecurityTimeMin] = 50;
            au16ProcessConst[(int)eIdxProcess.SlagSecurityTimeMax] = 300;
            au16ProcessConst[(int)eIdxProcess.SlagSecurityTimeStep] = 5;

            au16ProcessConst[(int)eIdxProcess.SlagPostTimeMin] = 0;
            au16ProcessConst[(int)eIdxProcess.SlagPostTimeMax] = 100;
            au16ProcessConst[(int)eIdxProcess.SlagPostTimeStep] = 5;

            au16ProcessConst[(int)eIdxProcess.SlagActiveGradientMin] = 50;
            au16ProcessConst[(int)eIdxProcess.SlagActiveGradientMax] = 150;
            au16ProcessConst[(int)eIdxProcess.SlagActiveGradientStep] = 5;

            au16ProcessConst[(int)eIdxProcess.SlagInActiveGradientMin] = 50;
            au16ProcessConst[(int)eIdxProcess.SlagInActiveGradientMax] = 150;
            au16ProcessConst[(int)eIdxProcess.SlagInActiveGradientStep] = 5;
            #endregion // Slag
            au16ProcessConst[(int)eIdxProcess.IgnitionDetectionEnableMin] = 0;
            au16ProcessConst[(int)eIdxProcess.IgnitionDetectionEnableMax] = 1;
            au16ProcessConst[(int)eIdxProcess.IgnitionDetectionEnableStep] = 1;

            au16ProcessConst[(int)eIdxProcess.PiercingSensorModeMin] = 0;
            au16ProcessConst[(int)eIdxProcess.PiercingSensorModeMax] = 1;
            au16ProcessConst[(int)eIdxProcess.PiercingSensorModeStep] = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        public enum eIdxConfig
        {
            LinearDriveUpSpeedFastMin = 0,
            LinearDriveUpSpeedFastMax,
            LinearDriveUpSpeedFastStep,
            LinearDriveUpSpeedSlowMin,
            LinearDriveUpSpeedSlowMax,
            LinearDriveUpSpeedSlowStep,
            LinearDriveDnSpeedFastMin,
            LinearDriveDnSpeedFastMax,
            LinearDriveDnSpeedFastStep,
            LinearDriveDnSpeedSlowMin,
            LinearDriveDnSpeedSlowMax,
            LinearDriveDnSpeedSlowStep,
            DynamicMin,
            DynamicMax,
            DynamicStep,
            SensorCollisionDelayMin,
            SensorCollisionDelayMax,
            SensorCollisionDelayStep,
            LinearDriveRefSpeedMin,
            LinearDriveRefSpeedMax,
            LinearDriveRefSpeedStep,
            LinearDrivePosSpeedMin,
            LinearDrivePosSpeedMax,
            LinearDrivePosSpeedStep,
            TactileInitialPosFindingMin,
            TactileInitialPosFindingMax,
            TactileInitialPosFindingStep,
            DistanceCalibrationMin,
            DistanceCalibrationMax,
            DistanceCalibrationStep,
            HoseLengthMin,
            HoseLengthMax,
            HoseLengthStep,
            CutO2BlowOutTimeMin,
            CutO2BlowOutTimeMax,
            CutO2BlowOutTimeStep,
            CutO2BlowOutPressureMin,
            CutO2BlowOutPressureMax,
            CutO2BlowOutPressureStep,
            CutO2BlowOutTimeOutMin,
            CutO2BlowOutTimeOutMax,
            CutO2BlowOutTimeOutStep,
            CapSetpointFlameOffsMin,
            CapSetpointFlameOffsMax,
            CapSetpointFlameOffsStep,
            LoadDefaultParameterMin,
            LoadDefaultParameterMax,
            LoadDefaultParameterStep,

            // ---------------
            Length
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetConfigSimulationData(ref UInt16[] au16ConfigConst)
        {
            Array.Resize(ref au16ConfigConst, (int)eIdxConfig.Length);
            au16ConfigConst[(int)eIdxConfig.LinearDriveUpSpeedFastMin] = 10;
            au16ConfigConst[(int)eIdxConfig.LinearDriveUpSpeedFastMax] = 100;
            au16ConfigConst[(int)eIdxConfig.LinearDriveUpSpeedFastStep] = 1;
            au16ConfigConst[(int)eIdxConfig.LinearDriveUpSpeedSlowMin] = 10;
            au16ConfigConst[(int)eIdxConfig.LinearDriveUpSpeedSlowMax] = 100;
            au16ConfigConst[(int)eIdxConfig.LinearDriveUpSpeedSlowStep] = 1;
            au16ConfigConst[(int)eIdxConfig.LinearDriveDnSpeedFastMin] = 10;
            au16ConfigConst[(int)eIdxConfig.LinearDriveDnSpeedFastMax] = 100;
            au16ConfigConst[(int)eIdxConfig.LinearDriveDnSpeedFastStep] = 1;
            au16ConfigConst[(int)eIdxConfig.LinearDriveDnSpeedSlowMin] = 10;
            au16ConfigConst[(int)eIdxConfig.LinearDriveDnSpeedSlowMax] = 100;
            au16ConfigConst[(int)eIdxConfig.LinearDriveDnSpeedSlowStep] = 1;
            au16ConfigConst[(int)eIdxConfig.DynamicMin] = 10;
            au16ConfigConst[(int)eIdxConfig.DynamicMax] = 100;
            au16ConfigConst[(int)eIdxConfig.DynamicStep] = 1;
            au16ConfigConst[(int)eIdxConfig.SensorCollisionDelayMin] = 0;
            au16ConfigConst[(int)eIdxConfig.SensorCollisionDelayMax] = 20;
            au16ConfigConst[(int)eIdxConfig.SensorCollisionDelayStep] = 1;
            au16ConfigConst[(int)eIdxConfig.LinearDriveRefSpeedMin] = 0;
            au16ConfigConst[(int)eIdxConfig.LinearDriveRefSpeedMax] = 0;
            au16ConfigConst[(int)eIdxConfig.LinearDriveRefSpeedStep] = 0;
            au16ConfigConst[(int)eIdxConfig.LinearDrivePosSpeedMin] = 10;
            au16ConfigConst[(int)eIdxConfig.LinearDrivePosSpeedMax] = 100;
            au16ConfigConst[(int)eIdxConfig.LinearDrivePosSpeedStep] = 1;
            au16ConfigConst[(int)eIdxConfig.TactileInitialPosFindingMin] = 0;
            au16ConfigConst[(int)eIdxConfig.TactileInitialPosFindingMax] = 1;
            au16ConfigConst[(int)eIdxConfig.TactileInitialPosFindingStep] = 1;
            au16ConfigConst[(int)eIdxConfig.DistanceCalibrationMin] = 0;
            au16ConfigConst[(int)eIdxConfig.DistanceCalibrationMax] = 100;
            au16ConfigConst[(int)eIdxConfig.DistanceCalibrationStep] = 10;
            au16ConfigConst[(int)eIdxConfig.HoseLengthMin] = 500;
            au16ConfigConst[(int)eIdxConfig.HoseLengthMax] = 20000;
            au16ConfigConst[(int)eIdxConfig.HoseLengthStep] = 10;
            au16ConfigConst[(int)eIdxConfig.CutO2BlowOutTimeMin] = 0;
            au16ConfigConst[(int)eIdxConfig.CutO2BlowOutTimeMax] = 30;
            au16ConfigConst[(int)eIdxConfig.CutO2BlowOutTimeStep] = 1;
            au16ConfigConst[(int)eIdxConfig.CutO2BlowOutPressureMin] = 0;
            au16ConfigConst[(int)eIdxConfig.CutO2BlowOutPressureMax] = 5000;
            au16ConfigConst[(int)eIdxConfig.CutO2BlowOutPressureStep] = 10;
            au16ConfigConst[(int)eIdxConfig.CutO2BlowOutTimeOutMin] = 0;
            au16ConfigConst[(int)eIdxConfig.CutO2BlowOutTimeOutMax] = 240;
            au16ConfigConst[(int)eIdxConfig.CutO2BlowOutTimeOutStep] = 1;
            au16ConfigConst[(int)eIdxConfig.CapSetpointFlameOffsMin] = 0;
            au16ConfigConst[(int)eIdxConfig.CapSetpointFlameOffsMax] = 1;
            au16ConfigConst[(int)eIdxConfig.CapSetpointFlameOffsStep] = 1;
            au16ConfigConst[(int)eIdxConfig.LoadDefaultParameterMin] = 0;
            au16ConfigConst[(int)eIdxConfig.LoadDefaultParameterMax] = 1;
            au16ConfigConst[(int)eIdxConfig.LoadDefaultParameterStep] = 1;
        }


        /// <summary>
        /// 
        /// </summary>
        public enum eIdxService
        {
            IgnitionPreFlowMultiplierMin = 0,
            IgnitionPreFlowMultiplierMax,
            IgnitionPreFlowMultiplierStep,
            IgnitionOnDurationTimeMin,
            IgnitionOnDurationTimeMax,
            IgnitionOnDurationTimeStep,
            HeatO2PostFlowMultiplierMin,
            HeatO2PostFlowMultiplierMax,
            HeatO2PostFlowMultiplierStep,
            HeatO2PostFlowPressureMin,
            HeatO2PostFlowPressureMax,
            HeatO2PostFlowPressureStep,
            SlagCuttingSpeedReductionMin,
            SlagCuttingSpeedReductionMax,
            SlagCuttingSpeedReductionStep,
            SensorCollisionOutputDisableMin,
            SensorCollisionOutputDisableMax,
            SensorCollisionOutputDisableStep,
            PidErrorThresholdDelayMin,
            PidErrorThresholdDelayMax,
            PidErrorThresholdDelayStep,
            ToleranceInPositionMin,
            ToleranceInPositionMax,
            ToleranceInPositionStep,
            Fit3ValveDelayMin,
            Fit3ValveDelayMax,
            Fit3ValveDelayStep,
            Fit3ValveDurationMin,
            Fit3ValveDurationMax,
            Fit3ValveDurationStep,
            Fit3GlowPlugDelayMin,
            Fit3GlowPlugDelayMax,
            Fit3GlowPlugDelayStep,
            Fit3GlowPlugDurationMin,
            Fit3GlowPlugDurationMax,
            Fit3GlowPlugDurationStep,
            Fit3GlowPlugSetpointMin,
            Fit3GlowPlugSetpointMax,
            Fit3GlowPlugSetpointStep,
            Fit3SaveIgnitionDataMin,
            Fit3SaveIgnitionDataMax,
            Fit3SaveIgnitionDataStep,

            // ---------------
            Length
        }

        /// <summary>
        /// 
        /// </summary>
        public static void SetServiceSimulationData(ref UInt16[] au16ServiceConst)
        {
            Array.Resize(ref au16ServiceConst, (int)eIdxService.Length);
            au16ServiceConst[(int)eIdxService.IgnitionPreFlowMultiplierMin] = 1;
            au16ServiceConst[(int)eIdxService.IgnitionPreFlowMultiplierMax] = 20;
            au16ServiceConst[(int)eIdxService.IgnitionPreFlowMultiplierStep] = 1;
            au16ServiceConst[(int)eIdxService.IgnitionOnDurationTimeMin] = 0;
            au16ServiceConst[(int)eIdxService.IgnitionOnDurationTimeMax] = 3000;
            au16ServiceConst[(int)eIdxService.IgnitionOnDurationTimeStep] = 100;
            au16ServiceConst[(int)eIdxService.HeatO2PostFlowMultiplierMin] = 1;
            au16ServiceConst[(int)eIdxService.HeatO2PostFlowMultiplierMax] = 20;
            au16ServiceConst[(int)eIdxService.HeatO2PostFlowMultiplierStep] = 1;
            au16ServiceConst[(int)eIdxService.HeatO2PostFlowPressureMin] = 500;
            au16ServiceConst[(int)eIdxService.HeatO2PostFlowPressureMax] = 5000;
            au16ServiceConst[(int)eIdxService.HeatO2PostFlowPressureStep] = 250;
            au16ServiceConst[(int)eIdxService.SlagCuttingSpeedReductionMin] = 50;
            au16ServiceConst[(int)eIdxService.SlagCuttingSpeedReductionMax] = 100;
            au16ServiceConst[(int)eIdxService.SlagCuttingSpeedReductionStep] = 1;
            au16ServiceConst[(int)eIdxService.SensorCollisionOutputDisableMin] = 0;
            au16ServiceConst[(int)eIdxService.SensorCollisionOutputDisableMax] = 1;
            au16ServiceConst[(int)eIdxService.SensorCollisionOutputDisableStep] = 1;
            au16ServiceConst[(int)eIdxService.PidErrorThresholdDelayMin] = 0;
            au16ServiceConst[(int)eIdxService.PidErrorThresholdDelayMax] = 200;
            au16ServiceConst[(int)eIdxService.PidErrorThresholdDelayStep] = 10;
            au16ServiceConst[(int)eIdxService.ToleranceInPositionMin] = 10;
            au16ServiceConst[(int)eIdxService.ToleranceInPositionMax] = 100;
            au16ServiceConst[(int)eIdxService.ToleranceInPositionStep] = 10;
            au16ServiceConst[(int)eIdxService.Fit3ValveDelayMin] = 0;
            au16ServiceConst[(int)eIdxService.Fit3ValveDelayMax] = 5000;
            au16ServiceConst[(int)eIdxService.Fit3ValveDelayStep] = 50;
            au16ServiceConst[(int)eIdxService.Fit3ValveDurationMin] = 1000;
            au16ServiceConst[(int)eIdxService.Fit3ValveDurationMax] = 5000;
            au16ServiceConst[(int)eIdxService.Fit3ValveDurationStep] = 50;
            au16ServiceConst[(int)eIdxService.Fit3GlowPlugDelayMin] = 0;
            au16ServiceConst[(int)eIdxService.Fit3GlowPlugDelayMax] = 5000;
            au16ServiceConst[(int)eIdxService.Fit3GlowPlugDelayStep] = 50;
            au16ServiceConst[(int)eIdxService.Fit3GlowPlugDurationMin] = 1000;
            au16ServiceConst[(int)eIdxService.Fit3GlowPlugDurationMax] = 5000;
            au16ServiceConst[(int)eIdxService.Fit3GlowPlugDurationStep] = 50;
            au16ServiceConst[(int)eIdxService.Fit3GlowPlugSetpointMin] = 1200;
            au16ServiceConst[(int)eIdxService.Fit3GlowPlugSetpointMax] = 1800;
            au16ServiceConst[(int)eIdxService.Fit3GlowPlugSetpointStep] = 50;
            au16ServiceConst[(int)eIdxService.Fit3SaveIgnitionDataMin] = 0;
            au16ServiceConst[(int)eIdxService.Fit3SaveIgnitionDataMax] = 1;
            au16ServiceConst[(int)eIdxService.Fit3SaveIgnitionDataStep] = 1;
        }

    }
}
