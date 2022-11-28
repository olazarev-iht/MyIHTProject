using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.IhtModbus;
using SharedComponents.IhtModbusCmd;

namespace SharedComponents.Models.APCHardware
{
    public enum ParamIds
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

    public class ParamIdsHelper
    {
        public List<string> SetupParameters = new List<string>()
        {
            // Devices parameters
            IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding.ToString(),
            IhtModbusParamDyn.eIdxConfig.DistanceCalibration.ToString(),
            IhtModbusParamDyn.eIdxProcessInfo.LinearDrivePosition.ToString(),
            IhtModbusParamDyn.eStatusBit.CalibrationValid.ToString(),
            IhtModbusParamDyn.eStatusBit.CalibrationActive.ToString(),

            IhtModbusParamDyn.eIdxProcess.RetractHeight.ToString(),
            IhtModbusCmdExecSwitch.eCmdBit.RetractPosAtProcessEnd.ToString(),

            IhtModbusParamDyn.eIdxProcess.SlagSensitivity.ToString(),
            IhtModbusParamDyn.eIdxProcess.SlagPostTime.ToString(),
            IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction.ToString(),

            IhtModbusCmdExecTactile.eCmdBit.CutO2Blowout.ToString(),
            IhtModbusCmdExecTactile.eCmdBit.CutO2BlowoutBreak.ToString(),
            IhtModbusParamDyn.eStatusBit.CutO2BlowoutActive.ToString(),
            IhtModbusParamDyn.eIdxProcessInfo.CurrCutO2BlowoutTime.ToString(),
            IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime.ToString(),
            IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure.ToString(),
            IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut.ToString(),

            IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce.ToString(),
            IhtModbusParamDyn.eIdxAdditional.PiercingDetection.ToString(),

            IhtModbusParamDyn.eIdxConfig.Dynamic.ToString(),
            IhtModbusParamDyn.eStatusInpBit.ClearanceCtrlOff.ToString(),
            IhtModbusParamDyn.eStatusHeightCtrl.Off.ToString(),
            IhtModbusParamDyn.eStatusHeightCtrl.HeightPreHeat.ToString(),
            IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce.ToString(),
            IhtModbusParamDyn.eStatusHeightCtrl.HeightCut.ToString()         
        };
    }

}
