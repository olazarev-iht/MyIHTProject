using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtModbus
{
    public class IhtModbusAccessLevelParamDyn
    {
        public static int GetTechnology(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxTechnology Idx = (IhtModbusParamDyn.eIdxTechnology)u16Idx;
            switch (Idx)
            {
                case IhtModbusParamDyn.eIdxTechnology.PreHeatHeight: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.PierceHeight: return (int)IhtModbusData.ePassword.Level_0; ;
                case IhtModbusParamDyn.eIdxTechnology.CutHeight: return (int)IhtModbusData.ePassword.Level_0; ;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2PreHeat: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Pierce: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.HeatO2Cut: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.CutO2Pierce: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.CutO2Cut: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasPreHeat: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasPierce: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.FuelGasCut: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.PreHeatTime: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.PiercePreTime: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.PierceTime: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.PiercePostTime: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.PierceHeightRampTime: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.CutHeightRampTime: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.PierceMode: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.IgnitionFlameAdjust: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.GasType: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.CuttingSpeed: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.PierceCuttingSpeedChange: return (int)IhtModbusData.ePassword.Level_0;
                case IhtModbusParamDyn.eIdxTechnology.ControlBits: return (int)IhtModbusData.ePassword.Level_0;
                default: return (int)IhtModbusData.ePassword.Level_0;
            }
        }

        public static int GetConfig(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxConfig eIdx = (IhtModbusParamDyn.eIdxConfig)u16Idx;
            return eIdx switch
            {
                IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedFast => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedSlow => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedFast => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedSlow => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.Dynamic => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.SensorCollisionDelay => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.LinearDriveRefSpeed => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.LinearDrivePosSpeed => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.DistanceCalibration => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.HoseLength => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.CapSetpointFlameOffs => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxConfig.LoadDefaultParameter => (int)IhtModbusData.ePassword.Level_0,
                _ => (int)IhtModbusData.ePassword.Level_0,
            };
        }

        public static int GetService(UInt16 u16Idx)
        {
            IhtModbusParamDyn.eIdxService eIdx = (IhtModbusParamDyn.eIdxService)u16Idx;
            return eIdx switch
            {
                IhtModbusParamDyn.eIdxService.IgnitionPreFlowMultiplier => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxService.IgnitionOnDurationTime => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxService.HeatO2PostFlowMultiplier => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxService.HeatO2PostFlowPressure => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxService.SensorCollisionOutputDisable => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxService.PidErrorThresholdDelay => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxService.ToleranceInPosition => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxService.Fit3ValveDelay => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxService.Fit3ValveDuration => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxService.Fit3GlowPlugDelay => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxService.Fit3GlowPlugDuration => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxService.Fit3GlowPlugSetpoint => (int)IhtModbusData.ePassword.Level_0,
                IhtModbusParamDyn.eIdxService.Fit3SaveIgnitionData => (int)IhtModbusData.ePassword.Level_0,
                _ => (int)IhtModbusData.ePassword.Level_0,
            };
        }


    }
}
