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
    class IhtModbusDescriptionParamConst
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

        /// <summary>
        /// 
        /// </summary>
        public static string GetDeviceInfo(UInt16 u16Idx, UInt16 u16Value)
        {
            IhtModbusParamConst.eIdxDeviceInfo eIdx = (IhtModbusParamConst.eIdxDeviceInfo)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamConst.eIdxDeviceInfo.PartNoLWord: return "Part number Low Word";
                case IhtModbusParamConst.eIdxDeviceInfo.PartNoHWord: return "Part number High Word";
                case IhtModbusParamConst.eIdxDeviceInfo.SerialNoLWord: return "Serial number Low Word";
                case IhtModbusParamConst.eIdxDeviceInfo.SerialNoHWord: return "Serial number High Word";
                case IhtModbusParamConst.eIdxDeviceInfo.HwVersion: return "HW-Version xx.yy";
                case IhtModbusParamConst.eIdxDeviceInfo.FwVersion: return "FW-Version xx.yy";
                case IhtModbusParamConst.eIdxDeviceInfo.FwSubVersion: return "FW-SubVersion zz";

                case IhtModbusParamConst.eIdxDeviceInfo.TorchPartNoLWord: return "FIT+3: Part number Low Word";
                case IhtModbusParamConst.eIdxDeviceInfo.TorchPartNoHWord: return "FIT+3: Part number Hight Word";
                case IhtModbusParamConst.eIdxDeviceInfo.TorchSerialNoLWord: return "FIT+3: Serial number Low Word";
                case IhtModbusParamConst.eIdxDeviceInfo.TorchSerialNoHWord: return "FIT+3: Serial number High Word";
                case IhtModbusParamConst.eIdxDeviceInfo.TorchHwVersion: return "FIT+3: HW-Version xx.yy";
                case IhtModbusParamConst.eIdxDeviceInfo.TorchFwVersion: return "FIT+3: FW-Version xx.yy";
                case IhtModbusParamConst.eIdxDeviceInfo.TorchFwSubVersion: return "FIT+3: FW-SubVersion zz";
                case IhtModbusParamConst.eIdxDeviceInfo.TorchHwFunctions: return "FIT+3: HW-Functions";
                case IhtModbusParamConst.eIdxDeviceInfo.TorchTypeIdx: return "FIT+3: Torch type";//: 0=Propan, 1=Acetylane";
            }
            return "unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetTechnology(UInt16 u16Idx)
        {
            IhtModbusParamConst.eIdxTechnology Idx = (IhtModbusParamConst.eIdxTechnology)u16Idx;
            switch (Idx)
            {
                case IhtModbusParamConst.eIdxTechnology.PreHeatHeightMin: return "Pre Heat Height min";
                case IhtModbusParamConst.eIdxTechnology.PreHeatHeightMax: return "Pre Heat Height max";
                case IhtModbusParamConst.eIdxTechnology.PreHeatHeightStep: return "Pre Heat Height step";
                case IhtModbusParamConst.eIdxTechnology.PierceHeightMin: return "Pierce Height min";
                case IhtModbusParamConst.eIdxTechnology.PierceHeightMax: return "Pierce Height max";
                case IhtModbusParamConst.eIdxTechnology.PierceHeightStep: return "Pierce Height step";
                case IhtModbusParamConst.eIdxTechnology.CutHeightMin: return "Cut Height min";
                case IhtModbusParamConst.eIdxTechnology.CutHeightMax: return "Cut Height max";
                case IhtModbusParamConst.eIdxTechnology.CutHeightStep: return "Cut Height step";
                case IhtModbusParamConst.eIdxTechnology.HeatO2IgnitionMin: return IsPasswordLevel_SwLevel_1 ? "HeatO2 Ignition min" : "PI0 min";
                case IhtModbusParamConst.eIdxTechnology.HeatO2IgnitionMax: return IsPasswordLevel_SwLevel_1 ? "HeatO2 Ignition max" : "PI0 max";
                case IhtModbusParamConst.eIdxTechnology.HeatO2IgnitionStep: return IsPasswordLevel_SwLevel_1 ? "HeatO2 Ignition step" : "PI0 step";
                case IhtModbusParamConst.eIdxTechnology.HeatO2PreHeatMin: return "HeatO2 Pre Heat min";
                case IhtModbusParamConst.eIdxTechnology.HeatO2PreHeatMax: return "HeatO2 Pre Heat max";
                case IhtModbusParamConst.eIdxTechnology.HeatO2PreHeatStep: return "HeatO2 Pre Heat step";
                case IhtModbusParamConst.eIdxTechnology.HeatO2PierceMin: return "HeatO2 Pierce min";
                case IhtModbusParamConst.eIdxTechnology.HeatO2PierceMax: return "HeatO2 Pierce max";
                case IhtModbusParamConst.eIdxTechnology.HeatO2PierceStep: return "HeatO2 Pierce step";
                case IhtModbusParamConst.eIdxTechnology.HeatO2CutMin: return "HeatO2 Cut min";
                case IhtModbusParamConst.eIdxTechnology.HeatO2CutMax: return "HeatO2 Cut max";
                case IhtModbusParamConst.eIdxTechnology.HeatO2CutStep: return "HeatO2 Cut step";
                case IhtModbusParamConst.eIdxTechnology.CutO2PierceMin: return "CutO2 Pierce min";
                case IhtModbusParamConst.eIdxTechnology.CutO2PierceMax: return "CutO2 Pierce max";
                case IhtModbusParamConst.eIdxTechnology.CutO2PierceStep: return "CutO2 Pierce step";
                case IhtModbusParamConst.eIdxTechnology.CutO2CutMin: return "CutO2 Cut min";
                case IhtModbusParamConst.eIdxTechnology.CutO2CutMax: return "CutO2 Cut max";
                case IhtModbusParamConst.eIdxTechnology.CutO2CutStep: return "CutO2 Cut step";
                case IhtModbusParamConst.eIdxTechnology.FuelGasIgnitionMin: return IsPasswordLevel_SwLevel_1 ? "FuelGas Ignition min" : "PI1 min";
                case IhtModbusParamConst.eIdxTechnology.FuelGasIgnitionMax: return IsPasswordLevel_SwLevel_1 ? "FuelGas Ignition max" : "PI1 max";
                case IhtModbusParamConst.eIdxTechnology.FuelGasIgnitionStep: return IsPasswordLevel_SwLevel_1 ? "FuelGas Ignition step" : "PI1 step";
                case IhtModbusParamConst.eIdxTechnology.FuelGasPreHeatMin: return "FuelGas Pre Heat min";
                case IhtModbusParamConst.eIdxTechnology.FuelGasPreHeatMax: return "FuelGas Pre Heat max";
                case IhtModbusParamConst.eIdxTechnology.FuelGasPreHeatStep: return "FuelGas Pre Heat step";
                case IhtModbusParamConst.eIdxTechnology.FuelGasPierceMin: return "FuelGas Pierce min";
                case IhtModbusParamConst.eIdxTechnology.FuelGasPierceMax: return "FuelGas Pierce max";
                case IhtModbusParamConst.eIdxTechnology.FuelGasPierceStep: return "FuelGas Pierce step";
                case IhtModbusParamConst.eIdxTechnology.FuelGasCutMin: return "FuelGas Cut min";
                case IhtModbusParamConst.eIdxTechnology.FuelGasCutMax: return "FuelGas Cut max";
                case IhtModbusParamConst.eIdxTechnology.FuelGasCutStep: return "FuelGas Cut step";
                case IhtModbusParamConst.eIdxTechnology.PreHeatTimeMin: return "Pre Heat Time min";
                case IhtModbusParamConst.eIdxTechnology.PreHeatTimeMax: return "Pre Heat Time max";
                case IhtModbusParamConst.eIdxTechnology.PreHeatTimeStep: return "Pre Heat Time step";
                case IhtModbusParamConst.eIdxTechnology.PiercePreTimeMin: return IsPasswordValid ? "Pierce Pre Time min" : "PP1 min";
                case IhtModbusParamConst.eIdxTechnology.PiercePreTimeMax: return IsPasswordValid ? "Pierce Pre Time max" : "PP1 max";
                case IhtModbusParamConst.eIdxTechnology.PiercePreTimeStep: return IsPasswordValid ? "Pierce Pre Time step" : "PP1 step";
                case IhtModbusParamConst.eIdxTechnology.PierceTimeMin: return "Pierce Time min";
                case IhtModbusParamConst.eIdxTechnology.PierceTimeMax: return "Pierce Time max";
                case IhtModbusParamConst.eIdxTechnology.PierceTimeStep: return "Pierce Time step";
                case IhtModbusParamConst.eIdxTechnology.PiercePostTimeMin: return IsPasswordValid ? "Pierce Post Time min" : "PP2 min";
                case IhtModbusParamConst.eIdxTechnology.PiercePostTimeMax: return IsPasswordValid ? "Pierce Post Time max" : "PP2 max";
                case IhtModbusParamConst.eIdxTechnology.PiercePostTimeStep: return IsPasswordValid ? "Pierce Post Time step" : "PP2 step";
                case IhtModbusParamConst.eIdxTechnology.PierceHeightRampTimeMin: return IsPasswordValid ? "Pierce Height Ramp Time min" : "PP3 min";
                case IhtModbusParamConst.eIdxTechnology.PierceHeightRampTimeMax: return IsPasswordValid ? "Pierce Height Ramp Time max" : "PP3 max";
                case IhtModbusParamConst.eIdxTechnology.PierceHeightRampTimeStep: return IsPasswordValid ? "Pierce Height Ramp Time step" : "PP3 step";
                case IhtModbusParamConst.eIdxTechnology.CutHeightRampTimeMin: return IsPasswordValid ? "Cut Height Ramp Time min" : "PP4 min";
                case IhtModbusParamConst.eIdxTechnology.CutHeightRampTimeMax: return IsPasswordValid ? "Cut Height Ramp Time max" : "PP4 max";
                case IhtModbusParamConst.eIdxTechnology.CutHeightRampTimeStep: return IsPasswordValid ? "Cut Height Ramp Time step" : "PP4 step";
                case IhtModbusParamConst.eIdxTechnology.PierceModeMin: return IsPasswordValid ? "Pierce Mode min" : "PP0 min";
                case IhtModbusParamConst.eIdxTechnology.PierceModeMax: return IsPasswordValid ? "Pierce Mode max" : "PP0 max";
                case IhtModbusParamConst.eIdxTechnology.PierceModeStep: return IsPasswordValid ? "Pierce Mode step" : "PP0 step";
                case IhtModbusParamConst.eIdxTechnology.IgnitionFlameAdjustMin: return "Ignition Flame Adjust min";
                case IhtModbusParamConst.eIdxTechnology.IgnitionFlameAdjustMax: return "Ignition Flame Adjust max";
                case IhtModbusParamConst.eIdxTechnology.IgnitionFlameAdjustStep: return "Ignition Flame Adjust step";
                case IhtModbusParamConst.eIdxTechnology.GasTypeMin: return "Gas Type min";
                case IhtModbusParamConst.eIdxTechnology.GasTypeMax: return "Gas Type max";
                case IhtModbusParamConst.eIdxTechnology.GasTypeStep: return "Gas Type step";
                case IhtModbusParamConst.eIdxTechnology.CuttingSpeedMin: return "Cutting Speed min";
                case IhtModbusParamConst.eIdxTechnology.CuttingSpeedMax: return "Cutting Speed max";
                case IhtModbusParamConst.eIdxTechnology.CuttingSpeedStep: return "Cutting Speed step";
                case IhtModbusParamConst.eIdxTechnology.PierceCuttingSpeedChangeMin: return "Pierce Cutting Speed Change min";
                case IhtModbusParamConst.eIdxTechnology.PierceCuttingSpeedChangeMax: return "Pierce Cutting Speed Change max";
                case IhtModbusParamConst.eIdxTechnology.PierceCuttingSpeedChangeStep: return "Pierce Cutting Speed Change step";
                case IhtModbusParamConst.eIdxTechnology.ControlBitsMin: return IsPasswordValid ? "Control Bits min" : "PC0 min";
                case IhtModbusParamConst.eIdxTechnology.ControlBitsMax: return IsPasswordValid ? "Control Bits max" : "PC0 max";
                case IhtModbusParamConst.eIdxTechnology.ControlBitsStep: return IsPasswordValid ? "Control Bits step" : "PC0 step";
            }
            return "unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetProcess(UInt16 u16Idx, UInt16 u16Value)
        {
            IhtModbusParamConst.eIdxProcess eIdx = (IhtModbusParamConst.eIdxProcess)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamConst.eIdxProcess.RetractHeightMin: return "Retract Height min";
                case IhtModbusParamConst.eIdxProcess.RetractHeightMax: return "Retract Height max";
                case IhtModbusParamConst.eIdxProcess.RetractHeightStep: return "Retract Height step";
                case IhtModbusParamConst.eIdxProcess.SlagSensitivityMin: return "Slag Sensitivity min";
                case IhtModbusParamConst.eIdxProcess.SlagSensitivityMax: return "Slag Sensitivity max";
                case IhtModbusParamConst.eIdxProcess.SlagSensitivityStep: return "Slag Sensitivity step";
                case IhtModbusParamConst.eIdxProcess.HeatO2TemperMin: return "HeatO2 Temper min";
                case IhtModbusParamConst.eIdxProcess.HeatO2TemperMax: return "HeatO2 Temper max";
                case IhtModbusParamConst.eIdxProcess.HeatO2TemperStep: return "HeatO2 Temper step";
                case IhtModbusParamConst.eIdxProcess.FuelGasTemperMin: return "FuelGas Temper min";
                case IhtModbusParamConst.eIdxProcess.FuelGasTemperMax: return "FuelGas Temper max";
                case IhtModbusParamConst.eIdxProcess.FuelGasTemperStep: return "FuelGas Temper step";
                case IhtModbusParamConst.eIdxProcess.HeightTemperMin: return "Height Temper min";
                case IhtModbusParamConst.eIdxProcess.HeightTemperMax: return "Height Temper max";
                case IhtModbusParamConst.eIdxProcess.HeightTemperStep: return "Height Temper step";
                case IhtModbusParamConst.eIdxProcess.LinearDriveManualPosSpeedMin: return "LD Manual Position Speed min";
                case IhtModbusParamConst.eIdxProcess.LinearDriveManualPosSpeedMax: return "LD Manual Position Speed max";
                case IhtModbusParamConst.eIdxProcess.LinearDriveManualPosSpeedStep: return "LD Manual Position Speed step";
                case IhtModbusParamConst.eIdxProcess.FuelGasOffsetMin: return "FuelGas Offset min";
                case IhtModbusParamConst.eIdxProcess.FuelGasOffsetMax: return "FuelGas Offset max";
                case IhtModbusParamConst.eIdxProcess.FuelGasOffsetStep: return "FuelGas Offset step";
                case IhtModbusParamConst.eIdxProcess.FlashbackSensivitityMin: return "Flashback Sensivitity min";
                case IhtModbusParamConst.eIdxProcess.FlashbackSensivitityMax: return "Flashback Sensivitity max";
                case IhtModbusParamConst.eIdxProcess.FlashbackSensivitityStep: return "Flashback Sensivitity step";
                #region Slag
                case IhtModbusParamConst.eIdxProcess.SlagIntervalTimeMin: return "Slag IntervalTime min";
                case IhtModbusParamConst.eIdxProcess.SlagIntervalTimeMax: return "Slag IntervalTime max";
                case IhtModbusParamConst.eIdxProcess.SlagIntervalTimeStep: return "Slag IntervalTime step";

                case IhtModbusParamConst.eIdxProcess.SlagFirstSlagTimeMin: return "Slag FirstSlagTime min";
                case IhtModbusParamConst.eIdxProcess.SlagFirstSlagTimeMax: return "Slag FirstSlagTime max";
                case IhtModbusParamConst.eIdxProcess.SlagFirstSlagTimeStep: return "Slag FirstSlagTime step";

                case IhtModbusParamConst.eIdxProcess.SlagSecurityTimeMin: return "Slag SecurityTime min";
                case IhtModbusParamConst.eIdxProcess.SlagSecurityTimeMax: return "Slag SecurityTime max";
                case IhtModbusParamConst.eIdxProcess.SlagSecurityTimeStep: return "Slag SecurityTime step";

                case IhtModbusParamConst.eIdxProcess.SlagPostTimeMin: return "Slag PostTime min";
                case IhtModbusParamConst.eIdxProcess.SlagPostTimeMax: return "Slag PostTime max";
                case IhtModbusParamConst.eIdxProcess.SlagPostTimeStep: return "Slag PostTime step";

                case IhtModbusParamConst.eIdxProcess.SlagActiveGradientMin: return "Slag ActiveGradient min";
                case IhtModbusParamConst.eIdxProcess.SlagActiveGradientMax: return "Slag ActiveGradient max";
                case IhtModbusParamConst.eIdxProcess.SlagActiveGradientStep: return "Slag ActiveGradient step";

                case IhtModbusParamConst.eIdxProcess.SlagInActiveGradientMin: return "Slag InActiveGradient min";
                case IhtModbusParamConst.eIdxProcess.SlagInActiveGradientMax: return "Slag InActiveGradient max";
                case IhtModbusParamConst.eIdxProcess.SlagInActiveGradientStep: return "Slag InActiveGradient step";
                #endregion // Slag                                                
                case IhtModbusParamConst.eIdxProcess.IgnitionDetectionEnableMin: return "Ignition Detection Enable min";
                case IhtModbusParamConst.eIdxProcess.IgnitionDetectionEnableMax: return "Ignition Detection Enable max";
                case IhtModbusParamConst.eIdxProcess.IgnitionDetectionEnableStep: return "Ignition Detection Enable step";

                case IhtModbusParamConst.eIdxProcess.PiercingSensorModeMin: return "Piercing Height Control min";
                case IhtModbusParamConst.eIdxProcess.PiercingSensorModeMax: return "Piercing Height Control max";
                case IhtModbusParamConst.eIdxProcess.PiercingSensorModeStep: return "Piercing Height Control step";
            }
            return "unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetConfig(UInt16 u16Idx, UInt16 u16Value)
        {
            IhtModbusParamConst.eIdxConfig eIdx = (IhtModbusParamConst.eIdxConfig)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamConst.eIdxConfig.LinearDriveUpSpeedFastMin: return "LD Up Speed fast min";
                case IhtModbusParamConst.eIdxConfig.LinearDriveUpSpeedFastMax: return "LD Up Speed fast max";
                case IhtModbusParamConst.eIdxConfig.LinearDriveUpSpeedFastStep: return "LD Up Speed fast step";
                case IhtModbusParamConst.eIdxConfig.LinearDriveUpSpeedSlowMin: return "LD Up Speed slow min";
                case IhtModbusParamConst.eIdxConfig.LinearDriveUpSpeedSlowMax: return "LD Up Speed slow max";
                case IhtModbusParamConst.eIdxConfig.LinearDriveUpSpeedSlowStep: return "LD Up Speed slow step";
                case IhtModbusParamConst.eIdxConfig.LinearDriveDnSpeedFastMin: return "LD Down Speed fast min";
                case IhtModbusParamConst.eIdxConfig.LinearDriveDnSpeedFastMax: return "LD Down Speed fast max";
                case IhtModbusParamConst.eIdxConfig.LinearDriveDnSpeedFastStep: return "LD Down Speed fast step";
                case IhtModbusParamConst.eIdxConfig.LinearDriveDnSpeedSlowMin: return "LD Down Speed slow min";
                case IhtModbusParamConst.eIdxConfig.LinearDriveDnSpeedSlowMax: return "LD Down Speed slow max";
                case IhtModbusParamConst.eIdxConfig.LinearDriveDnSpeedSlowStep: return "LD Down Speed slow step";
                case IhtModbusParamConst.eIdxConfig.DynamicMin: return "Dynamic min";
                case IhtModbusParamConst.eIdxConfig.DynamicMax: return "Dynamic max";
                case IhtModbusParamConst.eIdxConfig.DynamicStep: return "Dynamic step";
                case IhtModbusParamConst.eIdxConfig.SensorCollisionDelayMin: return "Sensor Collision Delay min";
                case IhtModbusParamConst.eIdxConfig.SensorCollisionDelayMax: return "Sensor Collision Delay max";
                case IhtModbusParamConst.eIdxConfig.SensorCollisionDelayStep: return "Sensor Collision Delay step";
                case IhtModbusParamConst.eIdxConfig.LinearDriveRefSpeedMin: return "LD Reference Speed min";
                case IhtModbusParamConst.eIdxConfig.LinearDriveRefSpeedMax: return "LD Reference Speed max";
                case IhtModbusParamConst.eIdxConfig.LinearDriveRefSpeedStep: return "LD Reference Speed step";
                case IhtModbusParamConst.eIdxConfig.LinearDrivePosSpeedMin: return "LD Position Speed min";
                case IhtModbusParamConst.eIdxConfig.LinearDrivePosSpeedMax: return "LD Position Speed max";
                case IhtModbusParamConst.eIdxConfig.LinearDrivePosSpeedStep: return "LD Position Speed step";
                case IhtModbusParamConst.eIdxConfig.TactileInitialPosFindingMin: return "Tactile Initial Position Finding Enable min";
                case IhtModbusParamConst.eIdxConfig.TactileInitialPosFindingMax: return "Tactile Initial Position Finding Enable max";
                case IhtModbusParamConst.eIdxConfig.TactileInitialPosFindingStep: return "Tactile Initial Position Finding Enable step";
                case IhtModbusParamConst.eIdxConfig.DistanceCalibrationMin: return "Distance Calibration min";
                case IhtModbusParamConst.eIdxConfig.DistanceCalibrationMax: return "Distance Calibration max";
                case IhtModbusParamConst.eIdxConfig.DistanceCalibrationStep: return "Distance Calibration step";
                case IhtModbusParamConst.eIdxConfig.HoseLengthMin: return "Hose Length min";
                case IhtModbusParamConst.eIdxConfig.HoseLengthMax: return "Hose Length max";
                case IhtModbusParamConst.eIdxConfig.HoseLengthStep: return "Hose Length step";
                case IhtModbusParamConst.eIdxConfig.CutO2BlowOutTimeMin: return "PreFlow Time min";
                case IhtModbusParamConst.eIdxConfig.CutO2BlowOutTimeMax: return "PreFlow Time max";
                case IhtModbusParamConst.eIdxConfig.CutO2BlowOutTimeStep: return "PreFlow Time step";
                case IhtModbusParamConst.eIdxConfig.CutO2BlowOutPressureMin: return "PreFlow Pressure min";
                case IhtModbusParamConst.eIdxConfig.CutO2BlowOutPressureMax: return "PreFlow Pressure max";
                case IhtModbusParamConst.eIdxConfig.CutO2BlowOutPressureStep: return "PreFlow Pressure step";
                case IhtModbusParamConst.eIdxConfig.CutO2BlowOutTimeOutMin: return "PreFlow Timeout min";
                case IhtModbusParamConst.eIdxConfig.CutO2BlowOutTimeOutMax: return "PreFlow Timeout max";
                case IhtModbusParamConst.eIdxConfig.CutO2BlowOutTimeOutStep: return "PreFlow Timeout step";
                case IhtModbusParamConst.eIdxConfig.CapSetpointFlameOffsMin: return "CapSetpoint FlameOffset Enable min";
                case IhtModbusParamConst.eIdxConfig.CapSetpointFlameOffsMax: return "CapSetpoint FlameOffset Enable max";
                case IhtModbusParamConst.eIdxConfig.CapSetpointFlameOffsStep: return "CapSetpoint FlameOffset Enable step";
                case IhtModbusParamConst.eIdxConfig.LoadDefaultParameterMin: return "Load Default Parameter min";
                case IhtModbusParamConst.eIdxConfig.LoadDefaultParameterMax: return "Load Default Parameter max";
                case IhtModbusParamConst.eIdxConfig.LoadDefaultParameterStep: return "Load Default Parameter step";
            }
            return "unknown";
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GetService(UInt16 u16Idx, UInt16 u16Value)
        {
            IhtModbusParamConst.eIdxService eIdx = (IhtModbusParamConst.eIdxService)u16Idx;
            switch (eIdx)
            {
                case IhtModbusParamConst.eIdxService.IgnitionPreFlowMultiplierMin: return "Ignition PreFlow Multiplier min";
                case IhtModbusParamConst.eIdxService.IgnitionPreFlowMultiplierMax: return "Ignition PreFlow Multiplier max";
                case IhtModbusParamConst.eIdxService.IgnitionPreFlowMultiplierStep: return "Ignition PreFlow Multiplier step";
                case IhtModbusParamConst.eIdxService.IgnitionOnDurationTimeMin: return "Ignition Duration time min";
                case IhtModbusParamConst.eIdxService.IgnitionOnDurationTimeMax: return "Ignition Duration time max";
                case IhtModbusParamConst.eIdxService.IgnitionOnDurationTimeStep: return "Ignition Duration time step";
                case IhtModbusParamConst.eIdxService.HeatO2PostFlowMultiplierMin: return "HeatO2 PostFlow Multiplier min";
                case IhtModbusParamConst.eIdxService.HeatO2PostFlowMultiplierMax: return "HeatO2 PostFlow Multiplier max";
                case IhtModbusParamConst.eIdxService.HeatO2PostFlowMultiplierStep: return "HeatO2 PostFlow Multiplier step";
                case IhtModbusParamConst.eIdxService.HeatO2PostFlowPressureMin: return "HeatO2 PostFlow Pressure min";
                case IhtModbusParamConst.eIdxService.HeatO2PostFlowPressureMax: return "HeatO2 PostFlow Pressure max";
                case IhtModbusParamConst.eIdxService.HeatO2PostFlowPressureStep: return "HeatO2 PostFlow Pressure step";
                case IhtModbusParamConst.eIdxService.SlagCuttingSpeedReductionMin: return "Slag Cutting Speed Reduction min";
                case IhtModbusParamConst.eIdxService.SlagCuttingSpeedReductionMax: return "Slag Cutting Speed Reduction max";
                case IhtModbusParamConst.eIdxService.SlagCuttingSpeedReductionStep: return "Slag Cutting Speed Reduction step";
                case IhtModbusParamConst.eIdxService.SensorCollisionOutputDisableMin: return "Sensor Collision Output Disable min";
                case IhtModbusParamConst.eIdxService.SensorCollisionOutputDisableMax: return "Sensor Collision Output Disable max";
                case IhtModbusParamConst.eIdxService.SensorCollisionOutputDisableStep: return "Sensor Collision Output Disable step";
                case IhtModbusParamConst.eIdxService.PidErrorThresholdDelayMin: return "Pid Error Threshold Delay min";
                case IhtModbusParamConst.eIdxService.PidErrorThresholdDelayMax: return "Pid Error Threshold Delay max";
                case IhtModbusParamConst.eIdxService.PidErrorThresholdDelayStep: return "Pid Error Threshold Delay step";
                case IhtModbusParamConst.eIdxService.ToleranceInPositionMin: return "Tolerance InPosition min";
                case IhtModbusParamConst.eIdxService.ToleranceInPositionMax: return "Tolerance InPosition max";
                case IhtModbusParamConst.eIdxService.ToleranceInPositionStep: return "Tolerance InPosition step";
                case IhtModbusParamConst.eIdxService.Fit3ValveDelayMin: return "Fit+3 Solenoid Valve Delay min";
                case IhtModbusParamConst.eIdxService.Fit3ValveDelayMax: return "Fit+3 Solenoid Valve Delay max";
                case IhtModbusParamConst.eIdxService.Fit3ValveDelayStep: return "Fit+3 Solenoid Valve Delay step";
                case IhtModbusParamConst.eIdxService.Fit3ValveDurationMin: return "Fit+3 Solenoid Valve Duration min";
                case IhtModbusParamConst.eIdxService.Fit3ValveDurationMax: return "Fit+3 Solenoid Valve Duration max";
                case IhtModbusParamConst.eIdxService.Fit3ValveDurationStep: return "Fit+3 Solenoid Valve Duration step";
                case IhtModbusParamConst.eIdxService.Fit3GlowPlugDelayMin: return "Fit+3 Glow Plug Delay min";
                case IhtModbusParamConst.eIdxService.Fit3GlowPlugDelayMax: return "Fit+3 Glow Plug Delay max";
                case IhtModbusParamConst.eIdxService.Fit3GlowPlugDelayStep: return "Fi+t3 Glow Plug Delay step";
                case IhtModbusParamConst.eIdxService.Fit3GlowPlugDurationMin: return "Fit+3 Glow Plug Duration min";
                case IhtModbusParamConst.eIdxService.Fit3GlowPlugDurationMax: return "Fit+3 Glow Plug Duration max";
                case IhtModbusParamConst.eIdxService.Fit3GlowPlugDurationStep: return "Fit+3 Glow Plug Duration step";
                case IhtModbusParamConst.eIdxService.Fit3GlowPlugSetpointMin: return "Fit+3 Glow Plug Setpoint min";
                case IhtModbusParamConst.eIdxService.Fit3GlowPlugSetpointMax: return "Fit+3 Glow Plug Setpoint max";
                case IhtModbusParamConst.eIdxService.Fit3GlowPlugSetpointStep: return "Fit+3 Glow Plug Setpoint step";
                case IhtModbusParamConst.eIdxService.Fit3SaveIgnitionDataMin: return "Fit+3 Save Ignition Data min";
                case IhtModbusParamConst.eIdxService.Fit3SaveIgnitionDataMax: return "Fit+3 Save Ignition Data max";
                case IhtModbusParamConst.eIdxService.Fit3SaveIgnitionDataStep: return "Fit+3 Save Ignition Data step";
            }
            return "unknown";
        }

    }
}
