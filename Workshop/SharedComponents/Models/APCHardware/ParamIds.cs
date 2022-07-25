using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.IhtModbus;

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
            IhtModbusParamDyn.eIdxConfig.Dynamic.ToString(),
            IhtModbusParamDyn.eIdxAdditional.HeightControlActive.ToString(),
            IhtModbusParamDyn.eStatusHeightCtrl.Off.ToString(),
            IhtModbusParamDyn.eStatusHeightCtrl.HeightPreHeat.ToString(),
            IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce.ToString(),
            IhtModbusParamDyn.eStatusHeightCtrl.HeightCut.ToString(),

            // System parameters
            IhtModbusParamDyn.eIdxProcess.RetractHeight.ToString(),
            IhtModbusParamDyn.eIdxAdditional.RetractPosition.ToString(),
            IhtModbusParamDyn.eIdxProcess.SlagSensitivity.ToString(),
            IhtModbusParamDyn.eIdxProcess.SlagPostTime.ToString(),
            IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction.ToString(),
            IhtModbusParamDyn.eIdxAdditional.StartPreflow.ToString(),
            IhtModbusParamDyn.eIdxAdditional.PreflowActive.ToString(),
            IhtModbusParamDyn.eIdxAdditional.PiercingHeightControl.ToString(),
            IhtModbusParamDyn.eIdxAdditional.PiercingDetection.ToString()
        };
    }

}
