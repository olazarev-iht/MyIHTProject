using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtModbus
{
    class IhtModbusData
    {
        public enum ePassword
        {
            Level_0,
            Level_1,
            Level_2,
            Level_Value
        }
        public enum ePasswordCode
        {
            Level_0 = 0,
            Level_1 = 1410,
            Level_2 = 17484,
            Level_GCE = 58301,
            Level_3 = 10769
        }
    }
}
