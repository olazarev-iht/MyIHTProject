using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.StatusInfo
{
    abstract class StatusInfoDataBase
    {
        public static readonly string Unit_None = string.Empty;
        public static readonly string Unit_mm = "mm";
        public static readonly string Unit_Volt = "V";
        public static readonly string Unit_Ampere = "A";
        public static readonly string Unit_Percent = "%";
        public static readonly string Unit_ms = "ms";
        public static readonly string Unit_s = "s";
        public static readonly string Unit_Degree = "°C";

        public static readonly string StatusRegister_0_Length = "Status register 0 (length)";
        public static readonly string StatusRegister_0 = "Status register 0";
        public static readonly string StatusRegister_1_Length = "Status register 1 (length)";
        public static readonly string StatusRegister_1 = "Status register 1";
        public static readonly string StatusRegister_2_Length = "Status register 2 (length)";
        public static readonly string StatusRegister_2 = "Status register 2";
        public static readonly string StatusRegister_3_Length = "Status register 3 (length)";
        public static readonly string StatusRegister_3 = "Status register 3";
        public static readonly string StatusRegister_4_Length = "Status register 4 (length)";
        public static readonly string StatusRegister_4 = "Status register 4";

        public static readonly string Temperature_uc = "Temperature uc";
        public static readonly string Temperature_uc_Min = "Temperature uc min";
        public static readonly string Temperature_uc_Max = "Temperature uc max";

        public static readonly string UB24V = "UB +24V";
        public static readonly string UB24V_Min = "UB +24V min";
        public static readonly string UB24V_Max = "UB +24V max";

        public static readonly string UB5V = "UB +5V";
        public static readonly string UB5V_Min = "UB +5V min";
        public static readonly string UB5V_Max = "UB +5V max";

        public static readonly string IgnitionGlowPlug = "IgnitionGlowPlug";

        public static readonly string ErrorCurrent = "Error (Er.xx)";
        public static readonly string Position = "Position";

        public int DataLength { get; }
        public int DataLengthMax { get; }

        protected StatusInfoDataBase(int dataLength, int dataLengthMax)
        {
            DataLengthMax = dataLengthMax;
            DataLength = (dataLength > DataLengthMax) ? DataLengthMax : dataLength;
        }

        abstract public StatusInfoData GetStatusInfoData(int idx);

    }

}
