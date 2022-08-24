using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.Cultures;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;

namespace SharedComponents.IhtModbus
{
    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusData
    {
        /// <summary>
        /// 
        /// </summary>
        public enum eIdxAddr
        {
            Version,
            //-------------------
            AreasNumber,
            //-------------------
            FrameLength,
            //-------------------
            Password,
            Reserved0,
            Reserved1,
            Reserved2,
            Reserved3,
            Reserved4,
            Reserved5,
            //-------------------
            StartDeviceInfo,
            NumberDeviceInfo,
            //-------------------
            StartTechnologyConst,
            NumberTechnologyConst,
            //-------------------
            StartTechnologyDyn,
            NumberTechnologyDyn,
            //-------------------
            StartProcessConst,
            NumberProcessConst,
            //-------------------
            StartProcessDyn,
            NumberProcessDyn,
            //-------------------
            StartConfigConst,
            NumberConfigConst,
            //-------------------
            StartConfigDyn,
            NumberConfigDyn,
            //-------------------
            StartServiceConst,
            NumberServiceConst,
            //-------------------
            StartServiceDyn,
            NumberServiceDyn,
            //-------------------
            StartProcessInfo,
            NumberProcessInfo,
            //-------------------
            StartCmdExec,
            NumberCmdExec,
            //-------------------
            StartSetupExec,
            NumberSetupExec,
            //-------------------
            StartData,
            NumberData,
            //-------------------
            StartTableData,
            NumberTableData,
            //-------------------
            Length,

            // Für die Simulation
            NumberOfAddrAreas = (Length - StartDeviceInfo) / 2,
            LengthOfAddrPreAreas = StartDeviceInfo
        }

        /// <summary>
        /// 
        /// </summary>
        public enum eAddress
        {
            StartAddress = 4000,
            FirstArea = StartAddress + eIdxAddr.StartDeviceInfo,
            PasswordAddress = 4003,
            CmdExecTactileAddress = 4800
        }

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

        public bool Connected { get; set; }
        public int SlaveId { get; set; }

        private UInt16 u16AreasNumber = 0;
        private IhtModbusAddrAreas addrAreas;

        internal IhtModbusAddrAreas GetAddrAreas() { return addrAreas; }
        internal UInt16 GetAreasNumber() { return u16AreasNumber; }

        private UInt16[] au16DeviceInfo;
        private UInt16[] au16TechnologyConst;
        private UInt16[] au16ProcessConst;
        private UInt16[] au16ConfigConst;
        private UInt16[] au16ServiceConst;

        private UInt16[] au16TechnologyDyn;
        private UInt16[] au16ProcessDyn;
        private UInt16[] au16ConfigDyn;
        private UInt16[] au16ServiceDyn;
        private UInt16[] au16ProcInfo;
        private UInt16[] au16CmdExec;
        private UInt16[] au16SetupExec;
        private UInt16[] au16Data;
        private UInt16[] au16TableData;

        internal UInt16[] GetDeviceInfo() { return au16DeviceInfo; }
        internal UInt16[] GetTechnologyConst() { return au16TechnologyConst; }
        internal UInt16[] GetProcessConst() { return au16ProcessConst; }
        internal UInt16[] GetConfigConst() { return au16ConfigConst; }
        internal UInt16[] GetServiceConst() { return au16ServiceConst; }

        internal UInt16 GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo eIdxDeviceInfo)
        {
            int idx = (int)eIdxDeviceInfo;
            if (idx < au16DeviceInfo.Length)
            {
                return au16DeviceInfo[idx];
            }
            return 0;
        }

        internal UInt16 GetTechnologyConst(IhtModbusParamConst.eIdxTechnology eIdxTechnology)
        {
            int idx = (int)eIdxTechnology;
            if (idx < au16TechnologyConst.Length)
            {
                return au16TechnologyConst[idx];
            }
            return 0;
        }
        internal UInt16 GetProcessConst(IhtModbusParamConst.eIdxProcess eIdxProcess)
        {
            int idx = (int)eIdxProcess;
            if (idx < au16ProcessConst.Length)
            {
                return au16ProcessConst[idx];
            }
            return 0;
        }
        internal UInt16 GetConfigConst(IhtModbusParamConst.eIdxConfig eIdxConfig)
        {
            int idx = (int)eIdxConfig;
            if (idx < au16ConfigConst.Length)
            {
                return au16ConfigConst[idx];
            }
            return 0;
        }
        internal UInt16 GetServiceConst(IhtModbusParamConst.eIdxService eIdxService)
        {
            int idx = (int)eIdxService;
            if (idx < au16ServiceConst.Length)
            {
                return au16ServiceConst[idx];
            }
            return 0;
        }

        internal UInt16[] GetDataTechnologyDyn() { return au16TechnologyDyn; }
        internal UInt16[] GetDataProcessDyn() { return au16ProcessDyn; }
        internal UInt16[] GetDataConfigDyn() { return au16ConfigDyn; }
        internal UInt16[] GetDataServiceDyn() { return au16ServiceDyn; }
        internal UInt16[] GetDataProcessInfo() { return au16ProcInfo; }
        internal UInt16[] GetDataCmdExec() { return au16CmdExec; }
        internal UInt16[] GetDataSetupExec() { return au16SetupExec; }
        internal UInt16[] GetDataData() { return au16Data; }
        internal UInt16[] GetDataTableData() { return au16TableData; }

        internal UInt16 GetValue(IhtModbusParamDyn.eIdxTechnology eIdxTechnology)
        {
            int idx = (int)eIdxTechnology;
            if (idx < au16TechnologyDyn.Length)
            {
                return au16TechnologyDyn[idx];
            }
            return 0;
        }
        internal UInt16 GetValue(IhtModbusParamDyn.eIdxProcess eIdxProcess)
        {
            int idx = (int)eIdxProcess;
            if (idx < au16ProcessDyn.Length)
            {
                return au16ProcessDyn[idx];
            }
            return 0;
        }
        internal UInt16 GetValue(IhtModbusParamDyn.eIdxConfig eIdxConfig)
        {
            int idx = (int)eIdxConfig;
            if (idx < au16ConfigDyn.Length)
            {
                return au16ConfigDyn[idx];
            }
            return 0;
        }
        internal UInt16 GetValue(IhtModbusParamDyn.eIdxService eIdxService)
        {
            int idx = (int)eIdxService;
            if (idx < au16ServiceDyn.Length)
            {
                return au16ServiceDyn[idx];
            }
            return 0;
        }
        internal UInt16 GetValue(IhtModbusParamDyn.eIdxProcessInfo eIdxProcessInfo)
        {
            int idx = (int)eIdxProcessInfo;
            if (idx < au16ProcInfo.Length)
            {
                return au16ProcInfo[idx];
            }
            return 0;
        }
        internal UInt16 GetValue(IhtModbusParamDyn.eIdxCmdExec eIdxCmdExec)
        {
            int idx = (int)eIdxCmdExec;
            if (idx < au16CmdExec.Length)
            {
                return au16CmdExec[idx];
            }
            return 0;
        }
        internal UInt16 GetValue(IhtModbusParamDyn.eIdxSetupExec eIdxSetupExec)
        {
            int idx = (int)eIdxSetupExec;
            if (idx < au16SetupExec.Length)
            {
                return au16SetupExec[idx];
            }
            return 0;
        }
        internal UInt16 GetValue(IhtModbusParamDyn.eIdxData eIdxData)
        {
            int idx = (int)eIdxData;
            if (idx < au16Data.Length)
            {
                return au16Data[idx];
            }
            return 0;
        }
        internal UInt16 GetValue(IhtModbusParamDyn.eIdxTable eIdxTableData)
        {
            int idx = (int)eIdxTableData;
            if (idx < au16TableData.Length)
            {
                return au16TableData[idx];
            }
            return 0;
        }

        internal UInt16 GetValue(IhtModbusParamConst.eIdxTechnology eIdxTechnology)
        {
            int idx = (int)eIdxTechnology;
            if (idx < au16TechnologyConst.Length)
            {
                return au16TechnologyConst[idx];
            }
            return 0;
        }
        internal UInt16 GetValue(IhtModbusParamConst.eIdxProcess eIdxProcess)
        {
            int idx = (int)eIdxProcess;
            if (idx < au16ProcessConst.Length)
            {
                return au16ProcessConst[idx];
            }
            return 0;
        }
        internal UInt16 GetValue(IhtModbusParamConst.eIdxConfig eIdxConfig)
        {
            int idx = (int)eIdxConfig;
            if (idx < au16ConfigConst.Length)
            {
                return au16ConfigConst[idx];
            }
            return 0;
        }
        internal UInt16 GetValue(IhtModbusParamConst.eIdxService eIdxService)
        {
            int idx = (int)eIdxService;
            if (idx < au16ServiceConst.Length)
            {
                return au16ServiceConst[idx];
            }
            return 0;
        }

        internal void SetValue(IhtModbusParamDyn.eIdxTechnology eIdxTechnology, UInt16 u16Data)
        {
            int idx = (int)eIdxTechnology;
            if (idx < au16TechnologyDyn.Length)
                au16TechnologyDyn[idx] = u16Data;
        }
        internal void SetValue(IhtModbusParamDyn.eIdxProcess eIdxProcess, UInt16 u16Data)
        {
            int idx = (int)eIdxProcess;
            if (idx < au16ProcessDyn.Length)
                au16ProcessDyn[idx] = u16Data;
        }
        internal void SetValue(IhtModbusParamDyn.eIdxConfig eIdxConfig, UInt16 u16Data)
        {
            int idx = (int)eIdxConfig;
            if (idx < au16ConfigDyn.Length)
                au16ConfigDyn[idx] = u16Data;
        }
        internal void SetValue(IhtModbusParamDyn.eIdxService eIdxService, UInt16 u16Data)
        {
            int idx = (int)eIdxService;
            if (idx < au16ServiceDyn.Length)
                au16ServiceDyn[idx] = u16Data;
        }
        internal void SetValue(IhtModbusParamDyn.eIdxProcessInfo eIdxProcessInfo, UInt16 u16Data)
        {
            int idx = (int)eIdxProcessInfo;
            if (idx < au16ProcInfo.Length)
                au16ProcInfo[idx] = u16Data;
        }
        internal void SetValue(IhtModbusParamDyn.eIdxCmdExec eIdxCmdExec, UInt16 u16Data)
        {
            int idx = (int)eIdxCmdExec;
            if (idx < au16CmdExec.Length)
                au16CmdExec[idx] = u16Data;
        }
        internal void SetValue(IhtModbusParamDyn.eIdxSetupExec eIdxSetupExec, UInt16 u16Data)
        {
            int idx = (int)eIdxSetupExec;
            if (idx < au16SetupExec.Length)
                au16SetupExec[idx] = u16Data;
        }
        /*
            internal void SetValue(IhtModbusParamDyn.eIdxData eIdxDataData, UInt16 u16Data)
            {
              int idx = (int)eIdxDataData;
              if (idx < au16DataData.Length)
                au16DataData[idx] = u16Data;
            }
            internal void SetValue(IhtModbusParamDyn.eIdxTableData eIdxTableData, UInt16 u16Data)
            {
              int idx = (int)eIdxTableData;
              if (idx < au16TableData.Length)
                au16TableData[idx] = u16Data;
            }
        */
        public void UpdatePasswordRegister(UInt16 _data)
        {
            GetAddrAreas().u16Password = _data;
        }

        internal IhtModbusAddrInfo[] GetAddrInfos() { return addrAreas.addrInfos; }

        internal IhtModbusAddrInfo GetAddrInfo(IhtModbusAddrAreas.eIdxAddrInfo eIdxAddrInfo) { return addrAreas.addrInfos[(int)eIdxAddrInfo]; }

        internal IhtModbusAddrInfo GetAddrInfo_DeviceInfo() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.DeviceInfo]; }
        internal IhtModbusAddrInfo GetAddrInfo_TechnologyConst() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.TechnologyConst]; }
        internal IhtModbusAddrInfo GetAddrInfo_TechnologyDyn() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.TechnologyDyn]; }
        internal IhtModbusAddrInfo GetAddrInfo_ProcessConst() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.ProcessConst]; }
        internal IhtModbusAddrInfo GetAddrInfo_ProcessDyn() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.ProcessDyn]; }
        internal IhtModbusAddrInfo GetAddrInfo_ConfigConst() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.ConfigConst]; }
        internal IhtModbusAddrInfo GetAddrInfo_ConfigDyn() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.ConfigDyn]; }
        internal IhtModbusAddrInfo GetAddrInfo_ServiceConst() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.ServiceConst]; }
        internal IhtModbusAddrInfo GetAddrInfo_ServiceDyn() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.ServiceDyn]; }
        internal IhtModbusAddrInfo GetAddrInfo_ProcessInfo() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.ProcessInfo]; }
        internal IhtModbusAddrInfo GetAddrInfo_CmdExec() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.CmdExec]; }
        internal IhtModbusAddrInfo GetAddrInfo_SetupExec() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.SetupExec]; }
        internal IhtModbusAddrInfo GetAddrInfo_Data() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.Data]; }
        internal IhtModbusAddrInfo GetAddrInfo_TableData() { return addrAreas.addrInfos[(int)IhtModbusAddrAreas.eIdxAddrInfo.TableData]; }

        public IhtModbusData(int _slaveId, ushort[] data, bool _IsSimulation)
        {
            if (!data.Any()) return;

            this.Connected = false;
            this.SlaveId = _slaveId;
            UInt16 idx = (UInt16)eIdxAddr.AreasNumber;
            u16AreasNumber = data[idx];
            addrAreas = new IhtModbusAddrAreas(u16AreasNumber);
            idx = 0;
            addrAreas.u16Version = data[idx++];
            addrAreas.u16AddrCnt = data[idx++];
            addrAreas.u16MaxRtuFrame = data[idx++];
            addrAreas.u16Password = data[idx++];
            addrAreas.u16Reserved0 = data[idx++];
            addrAreas.u16Reserved1 = data[idx++];
            addrAreas.u16Reserved2 = data[idx++];
            addrAreas.u16Reserved3 = data[idx++];
            addrAreas.u16Reserved4 = data[idx++];
            addrAreas.u16Reserved5 = data[idx++];

            // Simulationsdaten setzen
            if (_IsSimulation)
            {
                IhtModbusParamConst.SetDevInfoSimulationData(ref au16DeviceInfo);
                IhtModbusParamConst.SetTechnologySimulationData(ref au16TechnologyConst);
                IhtModbusParamConst.SetProcessSimulationData(ref au16ProcessConst);
                IhtModbusParamConst.SetConfigSimulationData(ref au16ConfigConst);
                IhtModbusParamConst.SetServiceSimulationData(ref au16ServiceConst);

                IhtModbusParamDyn.SetTechnologySimulationData(ref au16TechnologyDyn);
                IhtModbusParamDyn.SetProcessSimulationData(ref au16ProcessDyn);
                IhtModbusParamDyn.SetConfigSimulationData(ref au16ConfigDyn);
                IhtModbusParamDyn.SetServiceSimulationData(ref au16ServiceDyn);
                IhtModbusParamDyn.SetProcessInfoSimulationData(ref au16ProcInfo);
                IhtModbusParamDyn.SetCmdExecSimulationData(ref au16CmdExec);
                IhtModbusParamDyn.SetSetupExecSimulationData(ref au16SetupExec);
                IhtModbusParamDyn.SetDataSimulationData(ref au16Data);
                IhtModbusParamDyn.SetTableDataSimulationData(ref au16TableData);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static UInt16[] GetAddrAreasSimulationData(UInt16 u16Version)
        {
            UInt16[] au16Data = new UInt16[(int)eIdxAddr.LengthOfAddrPreAreas];

            au16Data[(int)eIdxAddr.Version] = u16Version;
            au16Data[(int)eIdxAddr.AreasNumber] = (UInt16)eIdxAddr.NumberOfAddrAreas;
            au16Data[(int)eIdxAddr.FrameLength] = 256;
            au16Data[(int)eIdxAddr.Password] = (UInt16)ePassword.Level_2;
            au16Data[(int)eIdxAddr.Reserved0] = 0;
            au16Data[(int)eIdxAddr.Reserved1] = 0;
            au16Data[(int)eIdxAddr.Reserved2] = 0;
            au16Data[(int)eIdxAddr.Reserved3] = 0;
            au16Data[(int)eIdxAddr.Reserved4] = 0;
            au16Data[(int)eIdxAddr.Reserved5] = 0;

            return au16Data;
        }

        /// <summary>
        /// 
        /// </summary>
        public static UInt16[] GetAreasDataSimulationData()
        {
            UInt16[] au16Data = new UInt16[(int)eIdxAddr.NumberOfAddrAreas * 2];
            int idx = 0;
            //-------------------
            /*StartDeviceInfo */
            au16Data[idx++] = 4100;
            /*NumberDeviceInfo*/
            au16Data[idx++] = (UInt16)IhtModbusParamConst.eIdxDeviceInfo.Length;
            //-------------------
            /*StartTechnologyConst */
            au16Data[idx++] = 4200;
            /*NumberTechnologyConst*/
            au16Data[idx++] = (UInt16)IhtModbusParamConst.eIdxTechnology.Length;
            //-------------------
            /*StartTechnologyDyn */
            au16Data[idx++] = 4300;
            /*NumberTechnologyDyn*/
            au16Data[idx++] = (UInt16)IhtModbusParamDyn.eIdxTechnology.Length;
            //-------------------
            /*StartProcessConst */
            au16Data[idx++] = 4400;
            /*NumberProcessConst*/
            au16Data[idx++] = (UInt16)IhtModbusParamConst.eIdxProcess.Length;
            //-------------------
            /*StartProcessDyn */
            au16Data[idx++] = 4450;
            /*NumberProcessDyn*/
            au16Data[idx++] = (UInt16)IhtModbusParamDyn.eIdxProcess.Length;
            //-------------------
            /*StartConfigConst */
            au16Data[idx++] = 4500;
            /*NumberConfigConst*/
            au16Data[idx++] = (UInt16)IhtModbusParamConst.eIdxConfig.Length;
            //-------------------
            /*StartConfigDyn */
            au16Data[idx++] = 4550;
            /*NumberConfigDyn*/
            au16Data[idx++] = (UInt16)IhtModbusParamDyn.eIdxConfig.Length;
            //-------------------
            /*StartServiceConst */
            au16Data[idx++] = 4600;
            /*NumberServiceConst*/
            au16Data[idx++] = (UInt16)IhtModbusParamConst.eIdxService.Length;
            //-------------------
            /*StartServiceDyn */
            au16Data[idx++] = 4650;
            /*NumberServiceDyn*/
            au16Data[idx++] = (UInt16)IhtModbusParamDyn.eIdxService.Length;
            //-------------------
            /*StartProcessInfo */
            au16Data[idx++] = 4700;
            /*NumberProcessInfo*/
            au16Data[idx++] = (UInt16)IhtModbusParamDyn.eIdxProcessInfo.Length;
            //-------------------
            /*StartCmdExec */
            au16Data[idx++] = 4800;
            /*NumberCmdExec*/
            au16Data[idx++] = (UInt16)IhtModbusParamDyn.eIdxCmdExec.Length;
            //-------------------
            /*StartSetupExec */
            au16Data[idx++] = 4850;
            /*NumberSetupExec*/
            au16Data[idx++] = (UInt16)IhtModbusParamDyn.eIdxSetupExec.Length;
            //-------------------
            /*StartData */
            au16Data[idx++] = 6000;
            /*NumberData*/
            au16Data[idx++] = (UInt16)IhtModbusParamDyn.eIdxData.Length;
            //-------------------
            /*StartTableData */
            au16Data[idx++] = 6100;
            /*NumberTableData*/
            au16Data[idx++] = (UInt16)IhtModbusParamDyn.eIdxTable.Length;
            //-------------------

            return au16Data;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void ReadSimulationData(ushort startAddress, ushort numRegisters, ushort[] au16Data)
        {
            IhtModbusAddrInfo _ihtModbusAddrInfo;

            // DeviceInfo
            _ihtModbusAddrInfo = GetAddrInfo_DeviceInfo();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetDeviceInfo(), au16Data);
                return;
            }
            // TechnologyConst
            _ihtModbusAddrInfo = GetAddrInfo_TechnologyConst();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetTechnologyConst(), au16Data);
                return;
            }
            // TechnologyDyn
            _ihtModbusAddrInfo = GetAddrInfo_TechnologyDyn();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetDataTechnologyDyn(), au16Data);
                return;
            }
            // ProcessConst
            _ihtModbusAddrInfo = GetAddrInfo_ProcessConst();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetProcessConst(), au16Data);
                return;
            }
            // ProcessDyn
            _ihtModbusAddrInfo = GetAddrInfo_ProcessDyn();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetDataProcessDyn(), au16Data);
                return;
            }
            // ConfigConst
            _ihtModbusAddrInfo = GetAddrInfo_ConfigConst();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetConfigConst(), au16Data);
                return;
            }
            // ConfigDyn
            _ihtModbusAddrInfo = GetAddrInfo_ConfigDyn();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetDataConfigDyn(), au16Data);
                return;
            }
            // ServiceConst
            _ihtModbusAddrInfo = GetAddrInfo_ServiceConst();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetServiceConst(), au16Data);
                return;
            }
            // ServiceDyn
            _ihtModbusAddrInfo = GetAddrInfo_ServiceDyn();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetDataServiceDyn(), au16Data);
                return;
            }
            // ProcessInfo
            _ihtModbusAddrInfo = GetAddrInfo_ProcessInfo();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetDataProcessInfo(), au16Data);
                return;
            }
            // CmdExec
            _ihtModbusAddrInfo = GetAddrInfo_CmdExec();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetDataCmdExec(), au16Data);
                return;
            }
            // SetupExec
            _ihtModbusAddrInfo = GetAddrInfo_SetupExec();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetDataSetupExec(), au16Data);
                return;
            }
            // Data
            _ihtModbusAddrInfo = GetAddrInfo_Data();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetDataData(), au16Data);
                return;
            }
            // TableData
            _ihtModbusAddrInfo = GetAddrInfo_TableData();
            if (IsInAddressRange(_ihtModbusAddrInfo, startAddress, numRegisters))
            {
                int startIdx = startAddress - _ihtModbusAddrInfo.u16StartAddr;
                ReadSimulationData(startIdx, numRegisters, GetDataTableData(), au16Data);
                return;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReadSimulationData(int startIdx, int numRegisters, ushort[] au16DataSrc, ushort[] au16DataDes)
        {
            try
            {
                Array.Copy(au16DataSrc, startIdx, au16DataDes, 0, numRegisters);
            }
            catch (Exception exc)
            {
                string msg = exc.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool IsInAddressRange(IhtModbusAddrInfo _ihtModbusAddrInfo, ushort startAddress, ushort numRegisters)
        {
            UInt16 u16StartAddr = _ihtModbusAddrInfo.u16StartAddr;
            UInt16 u16AddrNumber = _ihtModbusAddrInfo.u16AddrNumber;
            if (startAddress >= u16StartAddr && (startAddress + numRegisters) <= (u16StartAddr + u16AddrNumber))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetAreasReservedData(ushort[] data)
        {
            int idx = (int)eIdxAddr.Password;
            addrAreas.u16Password = data[idx++];
            addrAreas.u16Reserved0 = data[idx++];
            addrAreas.u16Reserved1 = data[idx++];
            addrAreas.u16Reserved2 = data[idx++];
            addrAreas.u16Reserved3 = data[idx++];
            addrAreas.u16Reserved4 = data[idx++];
            addrAreas.u16Reserved5 = data[idx++];
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetAreasData(ushort[] data)
        {
            UInt16 idxData = 0;
            UInt16 idx = 0;
            for (; idx < u16AreasNumber; idx++)
            {
                UInt16 u16StartAddr = data[idxData++];
                UInt16 u16AddrNumber = data[idxData++];
                addrAreas.addrInfos[idx] = new IhtModbusAddrInfo(u16StartAddr, u16AddrNumber);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetDeviceInfoData(ushort[] data)
        {
            Array.Resize(ref au16DeviceInfo, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16DeviceInfo[idx] = data[idx];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetTechnologyConstData(ushort[] data)
        {
            Array.Resize(ref au16TechnologyConst, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16TechnologyConst[idx] = data[idx];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetProcessConstData(ushort[] data)
        {
            Array.Resize(ref au16ProcessConst, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16ProcessConst[idx] = data[idx];
                // 01.08.2019 GR: Flashbackerkennung darf nicht ausschaltbar sein
                if ((int)idx == (int)IhtModbusParamConst.eIdxProcess.FlashbackSensivitityMin)
                {
                    au16ProcessConst[idx] = 1;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetConfigConstData(ushort[] data)
        {
            Array.Resize(ref au16ConfigConst, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16ConfigConst[idx] = data[idx];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetServiceConstData(ushort[] data)
        {
            Array.Resize(ref au16ServiceConst, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16ServiceConst[idx] = data[idx];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetTechnologyDynData(ushort[] data)
        {
            Array.Resize(ref au16TechnologyDyn, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16TechnologyDyn[idx] = data[idx];
            }
            UInt16 u16PierceMode = au16TechnologyDyn[(int)IhtModbusParamDyn.eIdxTechnology.PierceMode];
            //      DescriptionParamDyn.u16PierceMode = u16PierceMode;
            //      UnitParam.u16PierceMode = u16PierceMode;
            //      RealMultiplierParam.u16PierceMode = u16PierceMode;
            UInt16 u16GasType = au16TechnologyDyn[(int)IhtModbusParamDyn.eIdxTechnology.GasType];
            //      DescriptionParamDyn.u16GasType = u16GasType;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetProcessDynData(ushort[] data)
        {
            Array.Resize(ref au16ProcessDyn, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16ProcessDyn[idx] = data[idx];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetConfigDynData(ushort[] data)
        {
            Array.Resize(ref au16ConfigDyn, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16ConfigDyn[idx] = data[idx];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetServiceDynData(ushort[] data)
        {
            Array.Resize(ref au16ServiceDyn, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16ServiceDyn[idx] = data[idx];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetProcInfoData(ushort[] data)
        {
            Array.Resize(ref au16ProcInfo, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16ProcInfo[idx] = data[idx];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetCmdExecData(ushort[] data)
        {
            Array.Resize(ref au16CmdExec, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16CmdExec[idx] = data[idx];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetSetupExecData(ushort[] data)
        {
            Array.Resize(ref au16SetupExec, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16SetupExec[idx] = data[idx];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetData(ushort[] data)
        {
            Array.Resize(ref au16Data, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16Data[idx] = data[idx];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetTableData(ushort[] data)
        {
            Array.Resize(ref au16TableData, data.Length);
            UInt16 idx = 0;
            for (; idx < data.Length; idx++)
            {
                au16TableData[idx] = data[idx];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public enum DataDeviceInfoValue
        {
            PartNo,
            SerialNo,
            HwVersion,
            FwVersion,
            TorchPartNo,
            TorchSerialNo,
            TorchFwVersion,
            TorchHwVersion,
            TorchType
        }
        public enum DescriptionData
        {
            All,
            OnlyDescritpion,
            OnlyValue
        }
        /// <summary>
        /// 
        /// </summary>
        internal string GetDeviceInfoValue(DataDeviceInfoValue dataDeviceInfoValue, DescriptionData descData = DescriptionData.All)
        {
            UInt32 u32Data = 0;
            string data = " ";
            string desc = " ";
            string val = " ";
            switch (dataDeviceInfoValue)
            {
                case DataDeviceInfoValue.PartNo:
                    u32Data = ((UInt32)GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.PartNoHWord) << 16) + (UInt32)GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.PartNoLWord);
                    desc = String.Format("CU+ {0}", CultureResources.GetString("_CulturePartNumber"));
                    val = String.Format("{0}", u32Data);
                    data = descData == DescriptionData.All ? String.Format("{0}: {1}", desc, val)
                                                         : descData == DescriptionData.OnlyDescritpion ? desc : val;
                    break;
                case DataDeviceInfoValue.SerialNo:
                    u32Data = ((UInt32)GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.SerialNoHWord) << 16) + (UInt32)GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.SerialNoLWord);
                    desc = String.Format("CU+ {0}", CultureResources.GetString("_CultureSerialNumber"));
                    val = String.Format("{0}", u32Data);
                    data = descData == DescriptionData.All ? String.Format("{0}: {1}", desc, val)
                                                         : descData == DescriptionData.OnlyDescritpion ? desc : val;
                    break;
                case DataDeviceInfoValue.HwVersion:
                    desc = String.Format("CU+ HW-{0}", CultureResources.GetString("_CultureVersion"));
                    val = String.Format("V{0,2:00}.{1,2:00}", (GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.HwVersion) >> 8), (GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.HwVersion) & 0xFF));
                    data = descData == DescriptionData.All ? String.Format("{0}: {1}", desc, val)
                                                         : descData == DescriptionData.OnlyDescritpion ? desc : val;
                    break;
                case DataDeviceInfoValue.FwVersion:
                    desc = String.Format("CU+ FW-{0}", CultureResources.GetString("_CultureVersion"));
                    val = String.Format("V{0,2:00}.{1,2:00}.{2,2:00}", (GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.FwVersion) >> 8), (GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.FwVersion) & 0xFF), (GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.FwSubVersion) & 0xFF));
                    data = descData == DescriptionData.All ? String.Format("{0}: {1}", desc, val)
                                                         : descData == DescriptionData.OnlyDescritpion ? desc : val;
                    break;
                case DataDeviceInfoValue.TorchPartNo:
                    u32Data = ((UInt32)GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchPartNoHWord) << 16) + (UInt32)GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchPartNoLWord);
                    desc = String.Format("FIT+3 {0}", CultureResources.GetString("_CulturePartNumber"));
                    val = String.Format("{0}", u32Data);
                    data = descData == DescriptionData.All ? String.Format("{0}: {1}", desc, val)
                                                         : descData == DescriptionData.OnlyDescritpion ? desc : val;
                    break;
                case DataDeviceInfoValue.TorchSerialNo:
                    u32Data = ((UInt32)GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchSerialNoHWord) << 16) + (UInt32)GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchSerialNoLWord);
                    desc = String.Format("FIT+3 {0}", CultureResources.GetString("_CultureSerialNumber"));
                    val = String.Format("{0}", u32Data);
                    data = descData == DescriptionData.All ? String.Format("{0}: {1}", desc, val)
                                                         : descData == DescriptionData.OnlyDescritpion ? desc : val;
                    break;
                case DataDeviceInfoValue.TorchHwVersion:
                    desc = String.Format("FIT+3 HW-{0}", CultureResources.GetString("_CultureVersion"));
                    val = String.Format("V{0,2:00}.{1,2:00}", (GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchHwVersion) >> 8), (GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchHwVersion) & 0xFF));
                    data = descData == DescriptionData.All ? String.Format("{0}: {1}", desc, val)
                                                         : descData == DescriptionData.OnlyDescritpion ? desc : val;
                    break;
                case DataDeviceInfoValue.TorchFwVersion:
                    desc = String.Format("FIT+3 FW-{0}", CultureResources.GetString("_CultureVersion"));
                    val = String.Format("V{0,2:00}.{1,2:00}.{2,2:00}", (GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchFwVersion) >> 8), (GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchFwVersion) & 0xFF), (GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchFwSubVersion) & 0xFF));
                    data = descData == DescriptionData.All ? String.Format("{0}: {1}", desc, val)
                                                         : descData == DescriptionData.OnlyDescritpion ? desc : val;
                    break;
                case DataDeviceInfoValue.TorchType:
                    data = GetTorchTypedIdxInfo((Int16)GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchTypeIdx), descData);
                    /*
                    Int16  i16TorchTypeIdx = (Int16)GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchTypeIdx);
                    string torchType       = CultureResources.GetString("_CultureUnknown");
                    switch (i16TorchTypeIdx)
                    {
                      case (int)IhtDevices.TorchType.Propane  : torchType = CultureResources.GetString("_CulturePropane"  ); break;
                      case (int)IhtDevices.TorchType.Acetylane: torchType = CultureResources.GetString("_CultureAcetylane"); break;
                      case (int)IhtDevices.TorchType.Invalid  : torchType = CultureResources.GetString("_CultureInvalid"  ); break;
                    }
                    desc = CultureResources.GetString("_CultureTorchType");
                    val  = torchType;
                    data = descData==DescriptionData.All ? String.Format("FIT+3 {0}: {1}", desc, val) 
                                                         : descData==DescriptionData.OnlyDescritpion ? desc : val;
                    */
                    break;
            }
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i16TorchTypeIdx"></param>
        /// <returns></returns>
        public string GetTorchTypedIdxInfo(int iTorchTypeIdx, DescriptionData descData = DescriptionData.All)
        {
            string torchType = CultureResources.GetString("_CultureUnknown");
            switch (iTorchTypeIdx)
            {
                case (int)IhtDevices.TorchType.Propane: torchType = CultureResources.GetString("_CulturePropane"); break;
                case (int)IhtDevices.TorchType.Acetylane: torchType = CultureResources.GetString("_CultureAcetylane"); break;
                case (int)IhtDevices.TorchType.Invalid: torchType = CultureResources.GetString("_CultureInvalid"); break;
            }
            string desc = CultureResources.GetString("_CultureTorchType");
            string val = torchType;
            string data = descData == DescriptionData.All ? String.Format("FIT+3 {0}: {1}", desc, val)
                                                        : descData == DescriptionData.OnlyDescritpion ? desc : val;
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal string GetTorchControllerNotConnected()
        {
            string desc = CultureResources.GetString("_CultureFit3TorchControllerNotConnected");
            string data = String.Format("FIT+3: {0}", desc);
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal string GetTorchTypeUndefined()
        {
            string desc = CultureResources.GetString("_CultureFit3TorchTypeUndefined");
            string data = String.Format("FIT+3: {0}", desc);
            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal string GetTorchTypeCodeFault()
        {
            string desc = CultureResources.GetString("_CultureFit3TorchTypeCodeFault");
            string data = String.Format("FIT+3: {0}", desc);
            return data;
        }
    }

}
