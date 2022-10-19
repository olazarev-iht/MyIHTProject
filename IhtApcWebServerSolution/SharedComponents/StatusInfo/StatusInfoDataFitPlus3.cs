using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.StatusInfo
{
    class StatusInfoDataFitPlus3 : StatusInfoDataBase
    {
        public static readonly string Temperature_Top = "Temperature Top";
        public static readonly string Temperature_Top_Min = "Temperature Top min";
        public static readonly string Temperature_Top_Max = "Temperature Top max";

        public static readonly string Temperature_Bottom = "Temperature Bottom";
        public static readonly string Temperature_Bottom_Min = "Temperature Bottom min";
        public static readonly string Temperature_Bottom_Max = "Temperature Bottom max";

        public static readonly string TorchTypeIdx = "Torch Type Idx";
        public static readonly string AnalogSetpoint_mV = "Analog Setpoint";
        public static readonly string AnalogOutput_mV = "Analog Output";

        public enum StatusInfoIdx
        {
            StatusReg0Length,
            StatusReg0,
            StatusReg1Length,
            StatusReg1,
            StatusReg2Length,
            StatusReg2,
            Ub24V_mV,
            Ub24VMin_mV,
            Ub24VMax_mV,
            Ub5V_mV,
            Ub5VMin_mV,
            Ub5VMax_mV,
            IgnGlowPlug_mV,
            TempuC_Celsius,
            TempuCMin_Celsius,
            TempuCMax_Celsius,
            TempTop_Celsius,
            TempTopMin_Celsius,
            TempTopMax_Celsius,
            TempBottom_Celsius,
            TempBottomMin_Celsius,
            TempBottomMax_Celsius,
            TorchTypeIdx,
            //
            Length
        }

        protected Dictionary<StatusInfoIdx, StatusInfoData> dictStatusInfoData = new Dictionary<StatusInfoIdx, StatusInfoData>()
    {
      {StatusInfoIdx.StatusReg0Length     , new StatusInfoData(Unit_None  , $"Fit+3 {StatusRegister_0_Length}",   1.0  ,  StatusInfoData.GetFormattedUInt16, StatusInfoData.InfoData.RegisterLength)},
      {StatusInfoIdx.StatusReg0           , new StatusInfoData(Unit_None  , $"Fit+3 {StatusRegister_0       }",   1.0  ,  StatusInfoData.GetFormattedHex   , StatusInfoData.InfoData.Register      )},
      {StatusInfoIdx.StatusReg1Length     , new StatusInfoData(Unit_None  , $"Fit+3 {StatusRegister_1_Length}",   1.0  ,  StatusInfoData.GetFormattedUInt16, StatusInfoData.InfoData.RegisterLength)},
      {StatusInfoIdx.StatusReg1           , new StatusInfoData(Unit_None  , $"Fit+3 {StatusRegister_1       }",   1.0  ,  StatusInfoData.GetFormattedHex   , StatusInfoData.InfoData.Register      )},
      {StatusInfoIdx.StatusReg2Length     , new StatusInfoData(Unit_None  , $"Fit+3 {StatusRegister_2_Length}",   1.0  ,  StatusInfoData.GetFormattedUInt16, StatusInfoData.InfoData.RegisterLength)},
      {StatusInfoIdx.StatusReg2           , new StatusInfoData(Unit_None  , $"Fit+3 {StatusRegister_2       }",   1.0  ,  StatusInfoData.GetFormattedHex   , StatusInfoData.InfoData.Register      )},
      {StatusInfoIdx.Ub24V_mV             , new StatusInfoData(Unit_Volt  , $"Fit+3 {UB24V                  }",   0.001,  StatusInfoData.GetFormattedDouble, StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.Ub24VMin_mV          , new StatusInfoData(Unit_Volt  , $"Fit+3 {UB24V_Min              }",   0.001,  StatusInfoData.GetFormattedDouble, StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.Ub24VMax_mV          , new StatusInfoData(Unit_Volt  , $"Fit+3 {UB24V_Max              }",   0.001,  StatusInfoData.GetFormattedDouble, StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.Ub5V_mV              , new StatusInfoData(Unit_Volt  , $"Fit+3 {UB5V                   }",   0.001,  StatusInfoData.GetFormattedDouble, StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.Ub5VMin_mV           , new StatusInfoData(Unit_Volt  , $"Fit+3 {UB5V_Min               }",   0.001,  StatusInfoData.GetFormattedDouble, StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.Ub5VMax_mV           , new StatusInfoData(Unit_Volt  , $"Fit+3 {UB5V_Max               }",   0.001,  StatusInfoData.GetFormattedDouble, StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.IgnGlowPlug_mV       , new StatusInfoData(Unit_Volt  , $"Fit+3 {IgnitionGlowPlug       }",   0.001,  StatusInfoData.GetFormattedDouble, StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.TempuC_Celsius       , new StatusInfoData(Unit_Degree, $"Fit+3 {Temperature_uc         }",   1.0  ,  StatusInfoData.GetFormattedInt16 , StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.TempuCMin_Celsius    , new StatusInfoData(Unit_Degree, $"Fit+3 {Temperature_uc_Min     }",   1.0  ,  StatusInfoData.GetFormattedInt16 , StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.TempuCMax_Celsius    , new StatusInfoData(Unit_Degree, $"Fit+3 {Temperature_uc_Max     }",   1.0  ,  StatusInfoData.GetFormattedInt16 , StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.TempTop_Celsius      , new StatusInfoData(Unit_Degree, $"Fit+3 {Temperature_Top        }",   1.0  ,  StatusInfoData.GetFormattedInt16 , StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.TempTopMin_Celsius   , new StatusInfoData(Unit_Degree, $"Fit+3 {Temperature_Top_Min    }",   1.0  ,  StatusInfoData.GetFormattedInt16 , StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.TempTopMax_Celsius   , new StatusInfoData(Unit_Degree, $"Fit+3 {Temperature_Top_Max    }",   1.0  ,  StatusInfoData.GetFormattedInt16 , StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.TempBottom_Celsius   , new StatusInfoData(Unit_Degree, $"Fit+3 {Temperature_Bottom     }",   1.0  ,  StatusInfoData.GetFormattedInt16 , StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.TempBottomMin_Celsius, new StatusInfoData(Unit_Degree, $"Fit+3 {Temperature_Bottom_Min }",   1.0  ,  StatusInfoData.GetFormattedInt16 , StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.TempBottomMax_Celsius, new StatusInfoData(Unit_Degree, $"Fit+3 {Temperature_Bottom_Max }",   1.0  ,  StatusInfoData.GetFormattedInt16 , StatusInfoData.InfoData.Value         )},
      {StatusInfoIdx.TorchTypeIdx         , new StatusInfoData(Unit_None  , $"Fit+3 {TorchTypeIdx           }",   1.0  ,  StatusInfoData.GetFormattedInt16 , StatusInfoData.InfoData.Value         )},
    };

        public StatusInfoDataFitPlus3(int datalength)
          : base(datalength, (int)StatusInfoIdx.Length)
        {
        }

        override public StatusInfoData GetStatusInfoData(int idx)
        {
            dictStatusInfoData.TryGetValue((StatusInfoIdx)idx, out StatusInfoData statusInfoData);
            return statusInfoData;
        }
    }
}
