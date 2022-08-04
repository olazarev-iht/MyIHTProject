using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtModbus
{
    /// <summary>
    /// Address-Bereich
    /// </summary>
    class IhtModbusAddrAreas
    {
        /// <summary>
        /// 
        /// </summary>
        public enum eIdxAddrInfo
        {
            DeviceInfo,
            TechnologyConst,
            TechnologyDyn,
            ProcessConst,
            ProcessDyn,
            ConfigConst,
            ConfigDyn,
            ServiceConst,
            ServiceDyn,
            ProcessInfo,
            CmdExec,
            SetupExec,
            Data,
            TableData,

            //----------------------
            Length
        }

        public UInt16 u16Version { get; set; }
        public UInt16 u16AddrCnt { get; set; }
        public UInt16 u16MaxRtuFrame { get; set; }
        public UInt16 u16Password { get; set; }
        public UInt16 u16Reserved0 { get; set; }
        public UInt16 u16Reserved1 { get; set; }
        public UInt16 u16Reserved2 { get; set; }
        public UInt16 u16Reserved3 { get; set; }
        public UInt16 u16Reserved4 { get; set; }
        public UInt16 u16Reserved5 { get; set; }

        public IhtModbusAddrInfo[] addrInfos;

        /// <summary>
        /// 
        /// </summary>
        public IhtModbusAddrAreas(UInt16 u16AddrAreas)
        {
            addrInfos = new IhtModbusAddrInfo[u16AddrAreas];
        }
    }
}
