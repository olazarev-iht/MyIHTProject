using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
