using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtModbus
{
    /// <summary>
    /// Address-Info
    /// </summary>
    public class IhtModbusAddrInfo
    {
        public UInt16 u16StartAddr { get; set; }
        public UInt16 u16AddrNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IhtModbusAddrInfo(UInt16 u16StartAddr, UInt16 u16AddrNumber)
        {
            this.u16StartAddr = u16StartAddr;
            this.u16AddrNumber = u16AddrNumber;
        }
    }
}
