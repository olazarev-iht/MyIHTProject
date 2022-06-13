using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtDev
{
    public class IhtDevices
    {
        //                                                   V  00  . 02      . 09
        //public static readonly int FwMinimumVersion      = (((0<<8) +  2)<<8) +  9;
        public static int GetFwMinimumVersion(bool isRobot)
        {
            //                            V  00  . 02      . 09
            int FwMinimumVersion = (((0 << 8) + 2) << 8) + 9;
            //                            V  01  . 00      . 06
            int FwMinimumVersionRobot = (((1 << 8) + 0) << 8) + 6;
            return isRobot ? FwMinimumVersionRobot : FwMinimumVersion;
        }
        //                                                               V  01  . 00      . 07
        public static readonly int AvailableStatusInfoFwVersion = (((1 << 8) + 0) << 8) + 1;

        //                                                               V  00  . 03      .  1
        public static readonly int TorchFwMinimumVersion = (((0 << 8) + 3) << 8) + 1;

        //                                                               V  01  . 00      . 05
        public static readonly int TorchAvailableStatusInfoFwVersion = (((1 << 8) + 0) << 8) + 5;

        public enum DeviceNumber
        {
            Device_01 = 1,
            Device_02,
            Device_03,
            Device_04,
            Device_05,
            Device_06,
            Device_07,
            Device_08,
            Device_09,
            Device_10
        }

        public enum Device
        {
            DeviceLength = DeviceNumber.Device_10 - 1
        }

        public enum PasswordLevel_SW
        {
            Level_0,
            Level_1,
            Level_2,
            Level_3
        }

        public enum TorchType
        {
            Invalid = -1,
            Propane = 0,
            Acetylane = 1,
            NaturalGas = 2
        }

        public enum ErrorCode
        {
            Code_07 = 7,
            Code_08 = 8
        }
    }
}
