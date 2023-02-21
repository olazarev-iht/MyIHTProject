using System.IO.Ports;
using System.Net.Sockets;
//using log4net;
//using Modbus.Device;
using System.Collections;
using SharedComponents.Helpers;
using SharedComponents.IhtModbusCmd;
using SharedComponents.IhtMsg;
using SharedComponents.IhtData;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbusTable;
using SharedComponents.Services.APCHardwareMockDBServices;
using SharedComponents.StatusInfo;
using NModbus;
using NModbus.Serial;
using Microsoft.Extensions.DependencyInjection;

namespace SharedComponents.IhtModbus
{
  public class IhtModbusResult
    {
        public IhtModbusResult()
        {
            Result = false;
        }

        public bool Result { get; set; }
    }

    public class IhtModbusCommunic
    {
        public enum SlaveId
        {
            Id_Invalid = -1,
            Id_Broadcast = 0,
            Id_Default = 10,
            Id_10 = 10,
            Id_11,
            Id_12,
            Id_13,
            Id_14,
            Id_15,
            Id_16,
            Id_17,
            Id_18,
            Id_19,
            Id_20,
            Id_21,
            Id_22,
            Id_23,
            Id_24,
            Id_25,
            Id_Max
        }

        public static int GetStationNo(int slaveId)
        {
            return (int)slaveId - (int)SlaveId.Id_Default;
        }
        public static int GetStationNo(SlaveId slaveId)
        {
            return GetStationNo((int)slaveId);
        }

        public static int GetSlaveId(int stationNo)
        {
          return (int)stationNo + (int)SlaveId.Id_Default;
        }

        public static string clientCode = string.Empty;
        public static string installationMode = string.Empty;

        // Declare a delegate
        public delegate IhtModbusAddrInfo GetAddrInfoDelegate();
        public delegate UInt16[] GetValuesDelegate();
        public delegate void SetValuesDelegate(UInt16[] u16Datas);
        public delegate string GetDescriptionDelegate(UInt16 u16Idx, UInt16 u16Value);
        public delegate string GetDescriptionConstDelegate(UInt16 u16Idx);
        public delegate string GetUnitDelegate(UInt16 u16Idx);
        public delegate double GetRealMultiplierDelegate(UInt16 u16Idx);

        public IhtDevices ihtDevices { get { return IhtDevices.GetIhtDevices(); } }
        private MainWndHelper mainWndHlp { get { return MainWndHelper.GetMainWndHelper(); } }

        private SerialPort port = null;
        public SerialPort Port
        {
            get { return port; }
        }

        private TcpClient client = null;
        public TcpClient Client
        {
            get { return client; }
        }

        private IModbusMaster modbusMaster = null;

        private IhtModbusCommunicData communicData = null;
        private ArrayList ihtModbusDatas = new ArrayList();

        public IhtModbusCmdExecInputEmulation ihtModbusCmdExecInputEmulation = null;
        public IhtModbusCmdExecInputEmulation_2 ihtModbusCmdExecInputEmulation_2 = null;
        public IhtModbusCmdSetupCtrl ihtModbusCmdSetupCtrl = null;
        public IhtModbusCmdParam ihtModbusCmdParam = null;
        public IhtModbusCmdExecTactile ihtModbusCmdExecTactile = null;
        public IhtModbusCmdExecSwitch ihtModbusCmdExecSwitch = null;
        public IhtModbusCmdHeightCtrl ihtModbusCmdHeightCtrl = null;
        public IhtModbusCmdTestPressureOut ihtModbusCmdTestPressureOut = null;

        public IhtModbusTables ihtModbusTables = null;
        public IhtModbusTableCutCycleStateLabels ihtModbusTableCutCycleStateLabels { get { return ihtModbusTables.ihtModbusTableCutCycleStateLabels; } }
        public IhtModbusTableCutCycleStateCurrTbl ihtModbusTableCutCycleStateCurrTbl { get { return ihtModbusTables.ihtModbusTableCutCycleStateCurrTbl; } }
        public IhtModbusTableCutCycleStatePrevTbl ihtModbusTableCutCycleStatePrevTbl { get { return ihtModbusTables.ihtModbusTableCutCycleStatePrevTbl; } }
        public IhtModbusTableErrorLabels ihtModbusTableErrorLabels { get { return ihtModbusTables.ihtModbusTableErrorLabels; } }
        public IhtModbusTableErrorTbl ihtModbusTableErrorTbl { get { return ihtModbusTables.ihtModbusTableErrorTbl; } }
        public IhtModbusTableMenuParamTbl ihtModbusTableMenuParamTbl { get { return ihtModbusTables.ihtModbusTableMenuParamTbl; } }
        public IhtModbusTableOxyProcCutCycleStateLabels ihtModbusTableOxyProcCutCycleStateLabels { get { return ihtModbusTables.ihtModbusTableOxyProcCutCycleStateLabels; } }
        public IhtModbusTableOxyProcCutCycleStateCurrTbl ihtModbusTableOxyProcCutCycleStateCurrTbl { get { return ihtModbusTables.ihtModbusTableOxyProcCutCycleStateCurrTbl; } }
        public IhtModbusTableOxyProcCutCycleStatePrevTbl ihtModbusTableOxyProcCutCycleStatePrevTbl { get { return ihtModbusTables.ihtModbusTableOxyProcCutCycleStatePrevTbl; } }
        public IhtModbusTableTempHistogramuCTbl ihtModbusTableTempHistogramuCTbl { get { return ihtModbusTables.ihtModbusTableTempHistogramuCTbl; } }
        public IhtModbusTableHistogramCommonTbl ihtModbusTableHistogramCommonTbl { get { return ihtModbusTables.ihtModbusTableHistogramCommonTbl; } }
        public IhtModbusTableHistogramCommonCustomTbl ihtModbusTableHistogramCommonCustomTbl { get { return ihtModbusTables.ihtModbusTableHistogramCommonCustomTbl; } }
        public IhtModbusTableErrorCustomTbl ihtModbusTableErrorCustomTbl { get { return ihtModbusTables.ihtModbusTableErrorCustomTbl; } }
        public IhtModbusTableFitPlus3HistoErrorTbl ihtModbusTableFitPlus3HistoErrorTbl { get { return ihtModbusTables.ihtModbusTableFitPlus3HistoErrorTbl; } }
        public IhtModbusTableFitPlus3HistoErrorCustomTbl ihtModbusTableFitPlus3HistoErrorCustomTbl { get { return ihtModbusTables.ihtModbusTableFitPlus3HistoErrorCustomTbl; } }
        public IhtModbusTableFitPlus3HistoTempuCTbl ihtModbusTableFitPlus3HistoTempuCTbl { get { return ihtModbusTables.ihtModbusTableFitPlus3HistoTempuCTbl; } }
        public IhtModbusTableFitPlus3HistoTempTopTbl ihtModbusTableFitPlus3HistoTempTopTbl { get { return ihtModbusTables.ihtModbusTableFitPlus3HistoTempTopTbl; } }
        public IhtModbusTableFitPlus3HistoTempBottomTbl ihtModbusTableFitPlus3HistoTempBottomTbl { get { return ihtModbusTables.ihtModbusTableFitPlus3HistoTempBottomTbl; } }
        public IhtModbusTableStatusInfoTbl ihtModbusTableStatusInfoTbl { get { return ihtModbusTables.ihtModbusTableStatusInfoTbl; } }
        public IhtModbusTableStatusInfoSpecificTbl ihtModbusTableStatusInfoSpecificTbl { get { return ihtModbusTables.ihtModbusTableStatusInfoSpecificTbl; } }


        public bool IsStarted { get; private set; }

        public static int CurrOnSlaveBits { get; set; }
        public bool IsSimulation { get => isSimulation || IsSimulationHighPriority; set => isSimulation = value; }

        private bool isSimulation = true;

        public bool IsSimulationHighPriority { get; set; }
        /// <summary>
        /// 
        /// </summary>
        static private IhtModbusCommunic _ihtModbusCommunic_ = null;

        public readonly IAPCSimulationDataMockDBService _apcSimulationDataMockDBService;

        private static IServiceProvider _provider;
        /// <summary>
        /// Konstruktor
        /// </summary>
        /*
        public IhtModbusCommunic(IServiceProvider provider)
        {
          _provider = provider ?? throw new ArgumentNullException($"{nameof(provider)}");
        }
        */
        // instead of ---> in file IhtDevices
        // { get { return IhtModbusCommunic.GetIhtModbusCommunic(); } }
        public static IhtModbusCommunic GetIhtModbusCommunic()
        {
            if (_ihtModbusCommunic_ == null)
            {
                _ihtModbusCommunic_ = _provider?.GetService<IhtModbusCommunic>(); // Application.Current.MainWindow.FindResource("ihtModbusCommunic") as IhtModbusCommunic;
            }
            return _ihtModbusCommunic_;
        }

        /// <summary>
        /// 
        /// </summary>
        /*
        static IhtModbusCommunic()
        {
            CurrOnSlaveBits = 0;
        }
        */
        public IhtModbusCommunic(
          IAPCSimulationDataMockDBService apcSimulationDataMockDBService,
          IServiceProvider provider
          )
        {
            _apcSimulationDataMockDBService = apcSimulationDataMockDBService ??
               throw new ArgumentNullException($"{nameof(apcSimulationDataMockDBService)}");
          _provider = provider ?? throw new ArgumentNullException($"{nameof(provider)}");
        }

    /// <summary>
    /// Bit entsprechend der Slave ID ermitteln
    /// </summary>
    static public UInt16 GetSlaveIdBit(int _slaveId)
        {
            if (_slaveId > (int)SlaveId.Id_Invalid && _slaveId < (int)SlaveId.Id_Max)
            {
                return (UInt16)(1 << (_slaveId - (UInt16)SlaveId.Id_Default));
            }
            return 0;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        //public IhtModbusCommunic()
        //{
        //}

        /// <summary>
        /// Init
        /// </summary>
        public void Init(bool _IsSimulation, IhtModbusCommunicData ihtModbusCommunicData)
        {
            this.IsSimulation = _IsSimulation;

            this.communicData = ihtModbusCommunicData;//MainWindow.GetMainWindow().FindResource("modbusCommunicData") as IhtModbusCommunicData; 

            this.ihtModbusCmdExecInputEmulation = new IhtModbusCmdExecInputEmulation(this);
            this.ihtModbusCmdExecInputEmulation_2 = new IhtModbusCmdExecInputEmulation_2(this);
            this.ihtModbusCmdSetupCtrl = new IhtModbusCmdSetupCtrl(this);
            this.ihtModbusCmdParam = new IhtModbusCmdParam(this);
            this.ihtModbusCmdExecTactile = new IhtModbusCmdExecTactile(this);
            this.ihtModbusCmdExecSwitch = new IhtModbusCmdExecSwitch(this);
            this.ihtModbusCmdHeightCtrl = new IhtModbusCmdHeightCtrl(this);
            this.ihtModbusCmdTestPressureOut = new IhtModbusCmdTestPressureOut(this);
            this.ihtModbusTables = new IhtModbusTables(this);
        }

        /// <summary>
        /// ModbusDatas der verbundenen Slave's abfragen
        /// </summary>
        public ArrayList GetConnectedModbusDatas()
        {
            ArrayList _modbusDatas = new ArrayList();
            foreach (IhtModbusData modbusData in ihtModbusDatas)
            {
                if (modbusData.Connected && modbusData.SlaveId != (int)SlaveId.Id_Broadcast)
                {
                    _modbusDatas.Add(modbusData);
                }
            }
            return _modbusDatas;
        }

        /// <summary>
        /// ModbusDaten vom entrpechendem Slave's abfragen
        /// </summary>
        public IhtModbusData GetConnectedModbusData(int _slaveId)
        {
            ArrayList _modbusDatas = GetConnectedModbusDatas();
            foreach (IhtModbusData modbusData in _modbusDatas)
            {
                if (modbusData.SlaveId == _slaveId)
                {
                    return modbusData;
                }
            }
            return null;
        }

        /// <summary>
        /// - Broadcastfunktionalität dahingehend erweitert, dass im 1. Registerwert die Slave-Ids bitkodiert erwartet werden.
        ///   Befehl wird nur dann angenommen, wenn das entsprechende Slave-Id Bit im 1. Registerwert vorhanden ist.
        ///   Der 1. Registerwert wird danach verworfen und die Registeranzahl um den Wert 1 vermindert. 
        /// </summary>
        private UInt16 GetOnSlaveIdBits()
        {
            return (UInt16)IhtModbusCommunic.CurrOnSlaveBits;
        }

        /// <summary>
        /// Verbindung zu den Geräten aufbauen
        /// </summary>
        public async Task<bool> ConnectAsync(IhtMsgInfo msgInfo, UInt16 u16OnSlaveIdBits, bool isRobot)
        {
            ArrayList SlaveIds = ihtDevices.GetVisibleSlaveIds();
            return await ConnectAsync(SlaveIds, msgInfo, u16OnSlaveIdBits, isRobot).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        private async Task<bool> ConnectAsync(ArrayList SlaveIds, IhtMsgInfo msgInfo, UInt16 u16OnSlaveIdBits, bool isRobot)
        {
            bool blResult = false;
            if (communicData.IsTcp == true)
            {
                //mainWndHlp.SetStatusMsgCultureId(IhtMsgLog.Info.Info, "_CultureMsgLogCommunicIsTcp");
                blResult = await ConnectTcpAsync(SlaveIds, msgInfo, u16OnSlaveIdBits, isRobot).ConfigureAwait(false);
            }
            else if (communicData.IsRtu == true)
            {
                //mainWndHlp.SetStatusMsgCultureId(IhtMsgLog.Info.Info, "_CultureMsgLogCommunicIsRtu");
                blResult = await ConnectRtuAsync(SlaveIds, msgInfo, u16OnSlaveIdBits, isRobot).ConfigureAwait(false);
            }
            else
            {
                //mainWndHlp.mainWnd.StopBackgroundWorker();
                //mainWndHlp.SetStatusMsgCultureId(IhtMsgLog.Info.Error, "_CultureMsgLogInvalidSelection");
                ihtModbusDatas.Clear();
            }
            return blResult;
        }

        /// <summary>
        /// Modbus Kommunikation über RTU herstellen
        /// </summary>
        private bool firstCall = false;
        private async Task<bool> ConnectRtuAsync(ArrayList SlaveIds, IhtMsgInfo msgInfo, UInt16 u16OnSlaveIdBits, bool isRobot)
        {
            bool blResult = false;
            bool isComPort = IhtCmdLineParams.GetIhtCmdLineParams().IsComPort;
            string comPort = (isComPort && !firstCall) ? IhtCmdLineParams.GetIhtCmdLineParams().ComPort : communicData.ComPort;
            try
            {
                IsStarted = false;
                await Task.Delay(1000).ConfigureAwait(false);

                if (client != null)
                {
                    client.Close();
                }

                if (!IsSimulation && SerialPort.GetPortNames().Length == 0)
                {
                    mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, "No serial COM-Port available!");
                    return false;
                }

                // condition added by olazarev
                if (!IsSimulation)
                {
                    OpenPort(comPort);
                }

                string msg = String.Format("Port: {0}; Baudrate: {1}", comPort, communicData.Baudrate.ToString());
                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Info, msg);

                // condition added by olazarev
                if (port != null)
                {
                    // create modbus master
                    var factory = new ModbusFactory();
                    modbusMaster = factory.CreateRtuMaster(port);
                    //modbusMaster = ModbusSerialMaster.CreateRtu(port);
                }

                IsStarted = true;
                await ConnectRdDataAsync(SlaveIds, u16OnSlaveIdBits, isRobot).ConfigureAwait(false);

                blResult = GetConnectedModbusDatas().Count > 0;

                if (!blResult)
                {
                    if (port != null)
                    {
                        port.Close();
                    }
                }
            }
            catch (Exception exc)
            {
                msgInfo.msgText = exc.Message;
            }

            // Wenn Kommunikation erfolgreich war, dann COM-Port merken
            if (blResult)
            {
                communicData.ComPortLast = comPort;
            }
            else if (isComPort && !firstCall)
            {
                // keine weitere Aktion
            }
            else
            {
                bool find = false;
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (communicData.ComPortLast == s)
                    {
                        find = true;
                        break;
                    }
                }

                // Nur wenn verfügbar
                if (find && communicData.ComPort != communicData.ComPortLast)
                {
                    // TODO: implement: ?
                    //await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
                    //{
                    //    mainWndHlp.ClrStatusMsgs();
                    //    mainWndHlp.mainWnd.ClrImageButStatusMsg();
                    //    mainWndHlp.SetStatusMsgCultureId(IhtMsgLog.Info.Info, "_CultureMsgLogRecognizingTorches");
                    //}));

                    OpenPort(communicData.ComPortLast);

                    string msg = String.Format("Port: {0}; Baudrate: {1}", communicData.ComPortLast, communicData.Baudrate.ToString());
                    mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Info, msg);

                    // create modbus master
                    //modbusMaster = ModbusSerialMaster.CreateRtu(port);
                    var factory = new ModbusFactory();
                    modbusMaster = factory.CreateRtuMaster(port);

                    IsStarted = true;
                    await ConnectRdDataAsync(SlaveIds, u16OnSlaveIdBits, isRobot).ConfigureAwait(false);

                    blResult = GetConnectedModbusDatas().Count > 0;
                    if (blResult)
                    {
                        communicData.ComPort = communicData.ComPortLast;
                    }
                    else
                    {
                        if (port != null)
                        {
                            port.Close();
                        }
                    }
                }
            }

            firstCall = true;
            return blResult;
        }

        /// <summary>
        /// 
        /// </summary>
        private void OpenPort(string comPort)
        {
            if (port != null)
            {
                port.Close();
            }
            port = new SerialPort(comPort);
            // configure serial port
            port.BaudRate = communicData.Baudrate;
            port.DataBits = communicData.DataBits;
            port.Parity = communicData.Parity;
            port.StopBits = communicData.StopBits;
            port.WriteTimeout = communicData.WriteTimeout_ms;
            port.ReadTimeout = communicData.ReadTimeout_ms;
            if (!IsSimulation)
            {
                port.Open();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OpenPort()
        {
            string comPort = communicData.ComPort;
            if (port != null)
            {
                port.Close();
            }
            port = new SerialPort(comPort);
            // configure serial port
            port.BaudRate = communicData.Baudrate;
            port.DataBits = communicData.DataBits;
            port.Parity = communicData.Parity;
            port.StopBits = communicData.StopBits;
            port.WriteTimeout = communicData.WriteTimeout_ms;
            port.ReadTimeout = communicData.ReadTimeout_ms;
            if (!IsSimulation)
            {
                port.Open();
                // create modbus master
                //modbusMaster = ModbusSerialMaster.CreateRtu(port);
                var factory = new ModbusFactory();
                modbusMaster = factory.CreateRtuMaster(port);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClosePort()
        {
            if (port != null)
            {
                port.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int GetBaudrate()
        {
            return communicData.Baudrate;
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetComPort()
        {
            return communicData.ComPort;
        }

        /// <summary>
        /// Modbus Kommunikation über TCP herstellen
        /// </summary>
        private async Task<bool> ConnectTcpAsync(ArrayList SlaveIds, IhtMsgInfo msgInfo, UInt16 u16OnSlaveIdBits, bool isRobot)
        {
            bool blResult = false;
            try
            {
                IsStarted = false;
                await Task.Delay(1000).ConfigureAwait(false);

                if (port != null)
                {
                    port.Close();
                }

                if (client != null)
                {
                    client.Close();
                }

                string msg = String.Format("IP-Address: {0}; Port: {1}", communicData.IpAddress, communicData.IpPort.ToString());
                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Info, msg);
                client = new TcpClient(communicData.IpAddress, communicData.IpPort);

                // create modbus master
                //modbusMaster = ModbusIpMaster.CreateIp(client);
                var factory = new ModbusFactory();
                IModbusMaster master = factory.CreateMaster(client);
                IsStarted = true;

                await ConnectRdDataAsync(SlaveIds, u16OnSlaveIdBits, isRobot).ConfigureAwait(false);
                blResult = GetConnectedModbusDatas().Count > 0;
            }
            catch (Exception exc)
            {
                msgInfo.msgText = exc.Message;
            }
            return blResult;
        }

        /// <summary>
        /// read holding registers
        /// </summary>
        private enum Communic { Delay_ms = 10 }
        SemaphoreSlim mutexModbusMaster = new SemaphoreSlim(1);
        private async Task<ushort[]> ModbusMaster_ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numRegisters, IhtModbusResult ihtModbusResult)
        {
            ihtModbusResult.Result = false;
            await mutexModbusMaster.WaitAsync().ConfigureAwait(false);
            await Task.Delay((int)Communic.Delay_ms).ConfigureAwait(false);
            ushort[] datas = null;
            try
            {
                if (!IsSimulation)
                {
                    if (modbusMaster != null)
                    {
                        datas = modbusMaster.ReadHoldingRegisters(slaveAddress, startAddress, numRegisters);
                    }
                }
                else
                {
                    if (_apcSimulationDataMockDBService != null)
                    {
                        datas = await _apcSimulationDataMockDBService.ReadHoldingRegistersAsync(slaveAddress, startAddress, numRegisters);
                    }
                }

                ihtModbusResult.Result = true;
                ihtDevices.ClrCommunicError((int)slaveAddress);
            }
            catch (Exception exc)
            {
                ihtModbusResult.Result = false;
                //string txtSlaveId = CultureResources.GetString("_CultureSlaveId");
                //string msg = String.Format("{0}={1}: {2}", txtSlaveId, slaveAddress.ToString(), exc.Message);
                //mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, msg);
                ihtDevices.SetCommunicError((int)slaveAddress);
            }
            finally
            {
                mutexModbusMaster.Release();
            }

            return datas;
        }

        /// <summary>
        /// 
        /// </summary>
        private ushort[] ReadSimulationData(int slaveAddress, ushort startAddress, ushort numRegisters)
        {
            UInt16[] au16Data = new UInt16[numRegisters];
            try
            {
                IhtModbusData _ihtModbusData = GetConnectedModbusData(slaveAddress);
                if (_ihtModbusData != null)
                {
                    _ihtModbusData.ReadSimulationData(startAddress, numRegisters, au16Data);
                }
            }
            catch (Exception exc)
            {
                //string txtSlaveId = CultureResources.GetString("_CultureSlaveId");
                string txtSlaveId = "_CultureSlaveId";
                string msg = String.Format("{0}={1}: {2}", txtSlaveId, slaveAddress.ToString(), exc.Message);
                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, msg);
            }
            return au16Data;
        }

        /// <summary>
        /// write holding registers
        /// </summary>
        private async Task ModbusMaster_WriteMultipleRegistersAsync(byte slaveAddress,
                                                                    ushort startAddress,
                                                                    ushort[] registers,
                                                                    IhtModbusResult ihtModbusResult,
                                                                    UInt16 u16OnSlaveIdBits = 0
                                                                   )
        {
            await mutexModbusMaster.WaitAsync().ConfigureAwait(false);
            await Task.Delay((int)Communic.Delay_ms).ConfigureAwait(false);
            //UInt16 u16OnSlaveIdBits = ((int)slaveAddress == 0) ? GetOnSlaveIdBits() : (UInt16)0;
            if (u16OnSlaveIdBits == 0)
            {
                u16OnSlaveIdBits = ((int)slaveAddress == 0) ? GetOnSlaveIdBits() : (UInt16)0;
            }
            ihtModbusResult.Result = false;
            try
            {
                UInt16[] u16Registers = registers;
                if (slaveAddress == Convert.ToByte(SlaveId.Id_Broadcast))
                {
                    UInt16[] u16NewRegister = new UInt16[registers.Length + 1];
                    u16NewRegister[0] = u16OnSlaveIdBits;
                    registers.CopyTo(u16NewRegister, 1);
                    u16Registers = u16NewRegister;
                }

                if (!IsSimulation)
                {
                    modbusMaster.WriteMultipleRegisters(slaveAddress, startAddress, u16Registers);
                }
                
                ihtModbusResult.Result = true;
                ihtDevices.ClrCommunicError((int)slaveAddress);
            }
            catch (Exception exc)
            {
                //string txtSlaveId = CultureResources.GetString("_CultureSlaveId");
                string txtSlaveId = "_CultureSlaveId";
                string msg = String.Format("{0}={1}: {2}", txtSlaveId, slaveAddress.ToString(), exc.Message);
                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, msg);
                ihtDevices.SetCommunicError((int)slaveAddress);
            }
            finally
            {
                mutexModbusMaster.Release();
            }
        }

        /// <summary>
        /// read holding registers
        /// </summary>
        private async Task<UInt16[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numRegisters, IhtModbusResult ihtModbusResult)
        {
            return await ModbusMaster_ReadHoldingRegistersAsync(slaveAddress, startAddress, numRegisters, ihtModbusResult).ConfigureAwait(false);
        }


        /// <summary>
        /// write holding registers
        /// </summary>
        private async Task<bool> WriteMultipleRegistersAsync(byte slaveAddress, ushort startAddress, ushort[] registers)
        {
            IhtModbusResult ihtModbusResult = new IhtModbusResult(); ;
            await ModbusMaster_WriteMultipleRegistersAsync(slaveAddress, startAddress, registers, ihtModbusResult).ConfigureAwait(false);
            return ihtModbusResult.Result;
        }

        /// <summary>
        /// Modbus-Daten fuer Verbindung lesen
        /// </summary>
        private async Task ConnectRdDataAsync(ArrayList SlaveIds, UInt16 u16OnSlaveIdBits, bool isRobot)
        {
            IhtModbusTableBase.IsSimulation = IsSimulation;

            int currSlaveId = (int)SlaveId.Id_Broadcast;
            bool isExecReset = communicData.IsExecReset;
            bool isCuPartNo_101189 = false; // CU+
            bool isCuPartNo_100684 = false; // CU+ neu mit CU Sync Unterstützung
            bool isCuPartNo_100685 = false; // Roboter-Anwnedung
            try
            {
                //string connectingTorch = CultureResources.GetString("_CultureMsgLogConnectingTorch");
                //string torch = CultureResources.GetString("_CultureTorch");
                //string torchType = CultureResources.GetString("_CultureTorchType");
                //string txtSlaveId = CultureResources.GetString("_CultureSlaveId");
                //string notConnected = CultureResources.GetString("_CultureNotConnected");
                //string connected = CultureResources.GetString("_CultureConnected");
                //string fwSpecialActive = CultureResources.GetString("_CultureMsgLogFwSpecialActive");
                //string fwUpdateRequired = CultureResources.GetString("_CultureMsgLogFwUpdateRequired");
                //string torchWrongIdentity = CultureResources.GetString("_CultureTorchTypeWrongIdentity");
                //string calibrationInvalid = CultureResources.GetString("_CultureCalibrationInvalid");
                //string pressureOutputsLocked = CultureResources.GetString("_CultureInfoPressureOutputsLocked");

                string connectingTorch = "connectingTorch"; 
                string torch = "torch";
                string torchType = "torchType";
                string txtSlaveId = "txtSlaveId";
                string notConnected = "notConnected";
                string connected = "connected";
                string fwSpecialActive = "fwSpecialActive";
                string fwUpdateRequired = "fwUpdateRequired";
                string torchWrongIdentity = "torchWrongIdentity";
                string calibrationInvalid = "calibrationInvalid";
                string pressureOutputsLocked = "pressureOutputsLocked";

                //TODO: implement ?
                //mainWndHlp.mainWnd.StopBackgroundWorker();
                if (modbusMaster != null)
                {
                    modbusMaster.Transport.ReadTimeout = 500;
                    modbusMaster.Transport.WriteTimeout = 500;
                    modbusMaster.Transport.WaitToRetryMilliseconds = 250;
                }

                ihtModbusDatas.Clear();

                int firstConnectedSlaveId = 0;
                string msg = string.Empty;
                IhtModbusResult ihtModbusResult = new IhtModbusResult();

                UInt16 u16VisibleSlaveIdBits = 0;
                foreach (int _slaveId in SlaveIds)
                {
                    u16VisibleSlaveIdBits |= IhtModbusCommunic.GetSlaveIdBit(_slaveId);
                }

                // Einen Reset der Control-Units auslösen, damit die Daten der Fit+3 erneut ausgelesen werden
                if (isExecReset)
                {
                    mainWndHlp.SetStatusMsg(IhtMsgLog.Info.None, "");
                    //msg = CultureResources.GetString("_CultureResetAllDevices");
                    msg = "_CultureResetAllDevices";
                    mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Info, msg);
                    // Reset-Befehl an alle angeschlossene Geräte senden
                    ushort[] registers = { (ushort)IhtModbusCmdExecTactile.eCmdBit.ExecuteReset };
                    await ModbusMaster_WriteMultipleRegistersAsync((byte)SlaveId.Id_Broadcast,
                                                                    (ushort)IhtModbusData.eAddress.CmdExecTactileAddress,
                                                                    registers,
                                                                    ihtModbusResult,
                                                                    u16VisibleSlaveIdBits
                                                                  ).ConfigureAwait(false);
                }
                // PasswordLevel  an alle angeschlossene Geräte senden
                if (!IsSimulation)
                {
                    await Task.Delay(1000).ConfigureAwait(false);
                    ushort[] registers = { (UInt16)IhtModbusData.ePasswordCode.Level_2 };
                    await ModbusMaster_WriteMultipleRegistersAsync((byte)SlaveId.Id_Broadcast,
                                                                    (ushort)IhtModbusData.eAddress.PasswordAddress,
                                                                    registers,
                                                                    ihtModbusResult,
                                                                    u16VisibleSlaveIdBits
                                                                  ).ConfigureAwait(false);
                }
                else
                {
                    ihtModbusResult.Result = true;
                }

                // Nach dem Reset eine Verweilpause ausführen., damit die Control-Unit Zeit hat die Fit+3 Device-Info Daten auszulesen
                if (isExecReset)
                {
                    //TODO: implement ?
                    //await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
                    //{
                    //    MainWindow.GetMainWindow().eventDisplay.FontSizeLoadingAnimation = 17.0;
                    //}));

                    // Abfragen, ob alle sichtbaren Geräte auf der obere Endlage stehen
                    int milliseconds = 5000;

                    for (; milliseconds > 0; milliseconds -= 1000)
                    {
                        //TODO: implement ?
                        //await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
                        //{
                        //    string text = ((milliseconds < 10000) ? "    " : "   ") + (milliseconds / 1000).ToString() + "s";
                        //    MainWindow.GetMainWindow().eventDisplay.TextLoadingAnimation = text;
                        //}));
                        
                        await Task.Delay(1000).ConfigureAwait(false);
                    }

                    //TODO: implement ?
                    //await Application.Current.Dispatcher.InvokeAsync(new Action(() =>
                    //{
                    //    MainWindow.GetMainWindow().eventDisplay.TextLoadingAnimation = EventDisplay.DefaultTextLoadAnimation;
                    //    MainWindow.GetMainWindow().eventDisplay.FontSizeLoadingAnimation = EventDisplay.DefaultFontSizeLoadAnimation;
                    //}));
                }

                #region foreach
                // Alle angeschlossenen Geräte auslesen
                foreach (int _slaveId in SlaveIds)
                {
                    bool blSlaveIdBroadcast = false;
                    currSlaveId = _slaveId;
                    if (currSlaveId == (int)SlaveId.Id_Broadcast)
                    {
                        currSlaveId = firstConnectedSlaveId;
                        blSlaveIdBroadcast = true;
                    }

                    if (!blSlaveIdBroadcast)
                    {
                        mainWndHlp.SetStatusMsg(IhtMsgLog.Info.None, "");
                        //msg = String.Format("{0} {1}: {2} = {3}", connectingTorch, ((int)(currSlaveId - 10)).ToString(), txtSlaveId, currSlaveId.ToString());
                        msg = $"{connectingTorch} {currSlaveId - 10}: {txtSlaveId} = {currSlaveId}";
                        mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Info, msg);
                    }

                    if (currSlaveId == (int)SlaveId.Id_Broadcast)
                    {
                        // Und gleich zum Nächsten
                        continue;
                    }

                    // Ab StartAdresse 10 Eintraege lesen
                    var values = await Rd_AddrPreAreasAsync(currSlaveId, ihtModbusResult).ConfigureAwait(false);
                    if (!ihtModbusResult.Result)
                    {
                        if (!blSlaveIdBroadcast)
                        {
                            //string msg = String.Format("Torch {0}: not connected!", ((int)(currSlaveId - SlaveId.Id_Default)).ToString());
                            //msg = String.Format("{0} {1}: {2}!", torch, ((int)(currSlaveId - SlaveId.Id_Default)).ToString(), notConnected);
                            msg = $"{torch} {(int)(currSlaveId - SlaveId.Id_Default)}: {notConnected}!";

                            mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, msg);

                            //TODO: implement ?
                            //Application.Current.Dispatcher.Invoke(new Action(() =>
                            //{
                            //    ihtDevices.SetStatusErrorBackground(currSlaveId);
                            //}));
                        }
                        continue;
                    }
                    else
                    {
                        if (!blSlaveIdBroadcast && !IsSimulation)
                        {
                            bool isApplFwMissing = false;
                            foreach (ushort u16Data in (ushort[])values)
                            {
                                isApplFwMissing = isApplFwMissing || u16Data == 0xFFFF;
                                if (isApplFwMissing)
                                {
                                    break;
                                }
                            }
                            // Wenn die Applikations-FW fehlt, dann ist der Downloadkernel aktiv
                            if (isApplFwMissing)
                            {
                                // Ein Identify über den Downloadkernel versuchen
                                bool isDownloadkernelActive = await IdentifyOverDownloadkernel((IhtCommunic.SlaveId.Id)currSlaveId);
                                // Wenn ein Downloadkernel mit Modbus-Kommunikation vorhanden ist
                                if (isDownloadkernelActive)
                                {
                                    // Meldung ausgeben, dass ein FW-Download notwendig ist, bzw. Service kontaktieren
                                    mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, $"{torch} {((int)(currSlaveId - SlaveId.Id_Default)).ToString()}, {txtSlaveId} = {currSlaveId}: CU+ Firmware application is missing!");
                                    mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, "Please contact service!");
                                }
                                // Port wieder öffnen
                                OpenPort();
                                // Und gleich zum Nächsten
                                continue;
                            }
                        }
                    }

                    IhtModbusData ihtModbusData = new IhtModbusData(currSlaveId, (ushort[])values, IsSimulation);

                    // Adress-Bereiche auslesen
                    ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_AddrAreasAsync(ihtModbusData).ConfigureAwait(false));
                    // Geraete-Info auslesen                                                                                               
                    ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_DeviceInfoAsync(ihtModbusData, true).ConfigureAwait(false));
                    // Technologie-Parameter Const. auslesen
                    ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_TechnologyConstAsync(ihtModbusData, true).ConfigureAwait(false));
                    // Process-Parameter Const. auslesen
                    ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_ProcessConstAsync(ihtModbusData, true).ConfigureAwait(false));
                    // Config-Parameter Const. auslesen                                                                                     
                    ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_ConfigConstAsync(ihtModbusData, true).ConfigureAwait(false));
                    // Sevice-Parameter Const. auslesen                                                                                    
                    ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_ServiceConstAsync(ihtModbusData, true).ConfigureAwait(false));
                    // Technologie-Parameter Dyn. auslesen                                                                                 
                    ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_TechnologyDynAsync(ihtModbusData, true).ConfigureAwait(false));
                    // Process-Parameter Dyn. auslesen                                                                                     
                    ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_ProcessDynAsync(ihtModbusData, true).ConfigureAwait(false));
                    // Config-Parameter Dyn. auslesen                                                                                      
                    ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_ConfigDynAsync(ihtModbusData, true).ConfigureAwait(false));
                    // Sevice-Parameter Dyn. auslesen                                                                                      
                    ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_ServiceDynAsync(ihtModbusData, true).ConfigureAwait(false));
                    // Table Data vor Process-Info auslesen, damit für einen anstehenden FehlerCode die Description zur Verfügung steht
                    if (ihtModbusData.GetAddrAreas().u16Version >= 0x0105)
                    {
                        // Data auslesen
                        ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_DataAsync(ihtModbusData).ConfigureAwait(false));
                        // TableData auslesen
                        ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_TableDataAsync(ihtModbusData).ConfigureAwait(false));
                        // ErrorCode Labels auslesen
                        ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_ErrorCodeLabelsAsync(ihtModbusData).ConfigureAwait(false));
                    }
                    // Process-Info auslesen
                    ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_ProcessInfoAsync(ihtModbusData, true).ConfigureAwait(false));
                    // Cmd-Exec. auslesen
                    ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_CmdExecAsync(ihtModbusData, true).ConfigureAwait(false));
                    // Setup-Exec. auslesen
                    ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await ihtDevices.Read_SetupExecAsync(ihtModbusData, true).ConfigureAwait(false));

                    if (!ihtModbusResult.Result)
                    {
                        if (!blSlaveIdBroadcast)
                        {
                            //string msg = String.Format("Torch {0}: not connected!", ((int)(currSlaveId - SlaveId.Id_Default)).ToString());
                            msg = String.Format("{0} {1}: {2}!", torch, ((int)(currSlaveId - SlaveId.Id_Default)).ToString(), notConnected);
                            mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, msg);
                        }
                        continue;
                    }

                    ihtModbusData.Connected = true;

                    if (firstConnectedSlaveId == 0)
                    {
                        firstConnectedSlaveId = ihtModbusData.SlaveId;
                    }

                    if (blSlaveIdBroadcast == true)
                    {
                        ihtModbusData.SlaveId = 0;
                        // Nur wenn mindestens ein Gerät verbunden wurde
                        if (ihtModbusDatas.Count > 0)
                        {
                            ihtModbusDatas.Add(ihtModbusData);
                        }
                    }
                    else
                    {
                        ihtModbusDatas.Add(ihtModbusData);
                        // IhtModbusParamDyn.eIdxCmdExec.Switch aktualisieren
                        //ihtModbusCmdExecSwitch.UpdateRegister(ihtModbusData.SlaveId, ihtModbusData.GetValue(IhtModbusParamDyn.eIdxCmdExec.Switch));
                        // Wenn es keine Simulation ist
                        if (!IsSimulation)
                        {
                            // PasswordLevel setzen
                            await ihtDevices.ihtModbusCommunic.ihtModbusCmdParam.WriteAsync(ihtModbusData.SlaveId, IhtModbusData.ePassword.Level_2).ConfigureAwait(false);
                        }
                    }

                    if (!blSlaveIdBroadcast)
                    {
                        // Aktuelles Gerät
                        IhtDevice _ihtDevice = ihtDevices.GetDevice(currSlaveId);

                        int cuPartNo = _ihtDevice.GetPartNo();

                        // Wenn es keine Simulation ist
                        if (!IsSimulation)
                        {
                            // Merken welche CU+ Geraete-Typen vorhanden sind
                            isCuPartNo_100684 = isCuPartNo_100684 || cuPartNo == 100684;
                            isCuPartNo_101189 = isCuPartNo_101189 || cuPartNo == 101189;
                            isCuPartNo_100685 = isCuPartNo_100685 || cuPartNo == 100685;
                        }

                        // Entsprechend dem letzten Zustand Brenner On/Off schalten
                        if ((u16OnSlaveIdBits & _ihtDevice.GetSlaveIdBit()) != 0)
                        {
                            // Brenner ist eingeschaltet
                            //await ihtDevices.ClrTorchOffAsync(currSlaveId).ConfigureAwait(false);
                        }
                        else
                        {
                            // Brenner ist ausgeschaltet
                            //await ihtDevices.SetTorchOffAsync(currSlaveId).ConfigureAwait(false);
                        }

                        // Falls ClrClearenceCtrlOff zuvor aktiv war, löschen
                        //await ihtDevices.ClrClearenceCtrlOffAsync(currSlaveId).ConfigureAwait(false);
                        // FlameOnAtProcessEnd entsprechend setzen
                        //await ihtDevices.UpdateFlameOnAtProcessEndAsync(currSlaveId).ConfigureAwait(false);
                        // ClearenceCtrlManual entsprechend setzen
                        //await ihtDevices.UpdateClearenceCtrlManualAsync(currSlaveId).ConfigureAwait(false);

#if true
                        bool blFwUpdate = false;
                        bool blFwSpecialCU = false;

                        string torchNumber = ((int)(currSlaveId - SlaveId.Id_Default)).ToString();
                        string serialNo = ihtModbusData.GetDeviceInfoValue(IhtModbusData.DataDeviceInfoValue.SerialNo);
                        string partNo = ihtModbusData.GetDeviceInfoValue(IhtModbusData.DataDeviceInfoValue.PartNo);
                        //string msg = String.Format("Torch {0}: connected, {1}", torchNumber, serialNo);
                        //msg = String.Format("{0} {1}: {2}; {3}; {4}", torch, ((int)(currSlaveId - SlaveId.Id_Default)).ToString(), connected, serialNo, partNo);
                        msg = $"{torch} {(int)(currSlaveId - SlaveId.Id_Default)}: {connected}; {serialNo}; {partNo}";
                        mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Ok, msg);

                        string fwVersionCU = ihtModbusData.GetDeviceInfoValue(IhtModbusData.DataDeviceInfoValue.FwVersion);
                        string hwVersionCU = ihtModbusData.GetDeviceInfoValue(IhtModbusData.DataDeviceInfoValue.HwVersion);
                        //msg = String.Format("Torch {0}: {1}, {2}", torch, torchNumber, fwVersionCU, hwVersionCU);
                        msg = String.Format("{0} {1}: {2}; {3}", torch, torchNumber, fwVersionCU, hwVersionCU);
                        mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Info, msg);
                        // Auf FW-Update CU+ prüfen
                        int fwVersionCuValue = (ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.FwVersion) << 8)
                                              + (ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.FwSubVersion) & 0xFF);

                        // FW-Special CU+
                        UInt16 u16FwVersionCU = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.FwVersion);
                        if (((u16FwVersionCU & 0xFF00) >> 8) >= 90)
                        {
                            blFwSpecialCU = true;
                            ihtDevices.SetFwSpecial(currSlaveId);
                            string val = String.Format("V{0,2:00}.{1,2:00}.{2,2:00}",
                                                        (fwVersionCuValue & 0xFF0000) >> 16,
                                                        (fwVersionCuValue & 0x00FF00) >> 8,
                                                          fwVersionCuValue & 0x0000FF
                                                      );
                            //msg = String.Format("Torch {0}: {1} {2}", torchNumber, "FW-Special active:", val);
                            msg = String.Format("{0} {1}: CU+ {2}: {3}", torch, torchNumber, fwSpecialActive, val);
                            mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, msg);
                        }
                        else
                        {
                            ihtDevices.ClrFwSpecial(currSlaveId);
                        }

                        // FW-Update CU+
                        int fwMinimumVersion = IhtDevices.GetFwMinimumVersion(isRobot && (cuPartNo == 100685));
                        if (!blFwSpecialCU && fwVersionCuValue < fwMinimumVersion)
                        {
                            blFwUpdate = true;
                            ihtDevices.SetFwUpdate(currSlaveId);
                            string val = String.Format("V{0,2:00}.{1,2:00}.{2,2:00}",
                                                        (fwMinimumVersion & 0xFF0000) >> 16,
                                                        (fwMinimumVersion & 0x00FF00) >> 8,
                                                         fwMinimumVersion & 0x0000FF
                                                      );
                            //msg = String.Format("Torch {0}: {1} {2}", torchNumber, "FW-Update required! Minimum version:", val);
                            msg = String.Format("{0} {1}: CU+ {2}: {3}", torch, torchNumber, fwUpdateRequired, val);
                            mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, msg);
                        }
                        else
                        {
                            ihtDevices.ClrFwUpdate(currSlaveId);
                        }

                        // FW-Version Torch
                        int fwVersionTorchValue = (ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchFwVersion) << 8)
                                                  + (ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchFwSubVersion) & 0xFF);
                        string fwVersionTorch = ihtModbusData.GetDeviceInfoValue(IhtModbusData.DataDeviceInfoValue.TorchFwVersion);
                        string hwVersionTorch = ihtModbusData.GetDeviceInfoValue(IhtModbusData.DataDeviceInfoValue.TorchHwVersion);
                        if (fwVersionTorchValue > 0)
                        {
                            msg = String.Format("{0} {1}: {2}; {3}", torch, torchNumber, fwVersionTorch, hwVersionTorch);
                            mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Info, msg);
                        }

                        // FW-Special Torch
                        bool blFwSpecialTorch = false;
                        UInt16 u16FwVersionTorch = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchFwVersion);
                        if (((u16FwVersionTorch & 0xFF00) >> 8) >= 90)
                        {
                            blFwSpecialTorch = true;
                            ihtDevices.SetFwSpecial(currSlaveId);
                            string val = String.Format("V{0,2:00}.{1,2:00}.{2,2:00}",
                                                        (fwVersionTorchValue & 0xFF0000) >> 16,
                                                        (fwVersionTorchValue & 0x00FF00) >> 8,
                                                         fwVersionTorchValue & 0x0000FF
                                                      );
                            //msg = String.Format("Torch {0}: {1} {2}", torchNumber, "FW-Special active:", val);
                            msg = String.Format("{0} {1}: FIT+3 {2}: {3}", torch, torchNumber, fwSpecialActive, val);
                            mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, msg);
                        }
                        else if (!blFwSpecialCU)
                        {
                            ihtDevices.ClrFwSpecial(currSlaveId);
                        }

                        if (!IsSimulation && !blFwSpecialTorch && fwVersionTorchValue < IhtDevices.TorchFwMinimumVersion)
                        {
                            if (fwVersionTorchValue == 0)
                            {
                                msg = String.Format("{0} {1}: FIT+3 {2}", torch, torchNumber, notConnected);
                                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, msg);
                            }
                            else
                            {
                                // FW-Update Torch
                                blFwUpdate = true;
                                ihtDevices.SetFwUpdate(currSlaveId);
                                string val = String.Format("V{0,2:00}.{1,2:00}.{2,2:00}",
                                                            (IhtDevices.TorchFwMinimumVersion & 0xFF0000) >> 16,
                                                            (IhtDevices.TorchFwMinimumVersion & 0x00FF00) >> 8,
                                                             IhtDevices.TorchFwMinimumVersion & 0x0000FF
                                                          );
                                //msg = String.Format("Torch {0}: {1} {2}", torchNumber, "FW-Update required! Minimum version:", val);
                                msg = String.Format("{0} {1}: FIT+3 {2}: {3}", torch, torchNumber, fwUpdateRequired, val);
                                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, msg);
                            }
                        }
                        // Nur wenn CU+ kein FW-Update gesetzt hat
                        else if (!blFwUpdate)
                        {
                            ihtDevices.ClrFwUpdate(currSlaveId);
                        }

                        // TorchPartNo
                        string torchPartNo = ihtModbusData.GetDeviceInfoValue(IhtModbusData.DataDeviceInfoValue.TorchPartNo);
                        // TorchType
                        int torchTypeIdx = (Int16)ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchTypeIdx);
                        string fwTorchType = ihtModbusData.GetDeviceInfoValue(IhtModbusData.DataDeviceInfoValue.TorchType);
                        bool blWarning = false;
                        bool blWarningTorchType = false;
                        // Wenn Status-Informationen verfügbar sind, dann TorchType über Status-Informationen auslesen
                        if (!IsSimulation
                            && !blFwSpecialCU
                            && fwVersionCuValue >= IhtDevices.AvailableStatusInfoFwVersion
                            && !blFwSpecialTorch
                            && fwVersionTorchValue >= IhtDevices.TorchAvailableStatusInfoFwVersion)
                        {
                            int dataOffsetAddr = 0;
                            int dataCounts = (int)IhtModbusParamDyn.eIdxData.DataMaxLength;
                            // StatusInfoSpecific auslesen und anzeigen
                            if (await ihtDevices.Read_StatusInfoSpecificAsync(ihtModbusData, dataOffsetAddr, dataCounts) == true)
                            {
                                List<UInt16> listTblData = ihtDevices.GetStatusInfoSpecificList();
                                int idx = (int)StatusInfoDataFitPlus3.StatusInfoIdx.TorchTypeIdx;
                                if (idx < listTblData.Count)
                                {
                                    torchTypeIdx = (Int16)listTblData[idx];
                                    fwTorchType = ihtModbusData.GetTorchTypedIdxInfo(torchTypeIdx);
                                }
                                // Nur wenn der TorchTypeIdx ungültig ist
                                if (torchTypeIdx == -1)
                                {
                                    blWarning = true;
                                    blWarningTorchType = true;
                                    int statusReg1Length = 0;
                                    idx = (int)StatusInfoDataFitPlus3.StatusInfoIdx.StatusReg1Length;
                                    if (idx < listTblData.Count)
                                    {
                                        statusReg1Length = (Int16)listTblData[idx];
                                    }
                                    idx = (int)StatusInfoDataFitPlus3.StatusInfoIdx.StatusReg1;
                                    if (idx < listTblData.Count && statusReg1Length >= 8)
                                    {
                                        int statusReg1 = (Int16)listTblData[idx];
                                        int andMask = 1 << (int)StatusInfoDataRegister.RegisterIdxBit.Bit_6 | 1 << (int)StatusInfoDataRegister.RegisterIdxBit.Bit_7;
                                        int bits = (statusReg1 & andMask) >> 6;
                                        switch (bits)
                                        {
                                            // Bit0=0, Bit1=0: Kein Fehler / Torch Code gültig
                                            case 0:
                                                break;
                                            // Bit0=1, Bit1=0: Torch Not Connected
                                            case 1:
                                                fwTorchType = ihtModbusData.GetTorchControllerNotConnected();
                                                break;
                                            // Bit0=0, Bit1=1: Torch Not Defined
                                            case 2:
                                                fwTorchType = ihtModbusData.GetTorchTypeUndefined();
                                                break;
                                            // Bit0=1, Bit1=1: Torch Code Fault
                                            case 3:
                                                fwTorchType = ihtModbusData.GetTorchTypeCodeFault();
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            string msgUpper = fwTorchType.ToUpper();
                            blWarning = msgUpper.Contains("INVALID") || msg.Contains("UNKNOWN");
                        }
                        msg = String.Format("{0} {1}: {2}, {3}", torch, torchNumber, fwTorchType, torchPartNo);
                        if (fwVersionTorchValue > 0)
                        {
                            mainWndHlp.SetStatusMsg(blWarning ? IhtMsgLog.Info.Warning : IhtMsgLog.Info.Info, msg);
                        }

                        // Wrong-TorchType
                        bool blWrogTorchType = false;
                        if (fwVersionTorchValue > 0 && torchTypeIdx != -1)
                        {
                            if ((ihtDevices.IsPropane || ihtDevices.IsNaturalGas)
                                && torchTypeIdx != (int)IhtDevices.TorchType.Propane
                               )
                            {
                                blWrogTorchType = true;
                            }
                            else if (ihtDevices.IsAcetylane && torchTypeIdx != (int)IhtDevices.TorchType.Acetylane)
                            {
                                blWrogTorchType = true;
                            }
                        }

                        if (blWrogTorchType)
                        {
                            msg = String.Format("{0} {1}: {2}!", torch, torchNumber, torchWrongIdentity);
                            mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, msg);
                            blWarning = true;
                            blWarningTorchType = true;
                        }

                        if (blWarningTorchType)
                        {
                            ihtDevices.SetWrongTorchType(currSlaveId);
                        }
                        else
                        {
                            ihtDevices.ClrWrongTorchType(currSlaveId);
                        }

                        // Calibration invalid
                        DataProcessInfo dataProcessInfo = ihtDevices.GetDataProcessInfo(currSlaveId);

                        //TODO: implement - IsRobot ?
                        //if (mainWndHlp.mainWnd.IsRobot == false && dataProcessInfo != null && dataProcessInfo.IsCalibrationValid == false)
                        //{
                        //    //msg = String.Format("Torch {0}: {1}", torchNumber, "Calibration invalid!");
                        //    msg = String.Format("{0} {1}: {2}!", torch, torchNumber, calibrationInvalid);
                        //    mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, msg);
                        //}

                        // Pressure outputs locked
                        DataCmdExecution dataCmdExecution = ihtDevices.GetDataCmdExecution(currSlaveId);
                        if (dataCmdExecution != null && dataCmdExecution.IsLockPressureOutput)
                        {
                            //msg = String.Format("Torch {0}: {1}", torchNumber, "Pressure outputs locked!");
                            msg = String.Format("{0} {1}: {2}!", torch, torchNumber, pressureOutputsLocked);
                            mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, msg);
                        }

                        //TODO: implement ?
                        //Application.Current.Dispatcher.Invoke(new Action(() =>
                        //{
                        //    ihtDevices.ClrStatusErrorBackground(currSlaveId);
                        //    if (!blWarning && !blFwUpdate && !blFwSpecialCU && !blFwSpecialTorch)
                        //    {
                        //        ihtDevices.SetStatusOkBackground(currSlaveId);
                        //    }
                        //    else
                        //    {
                        //        ihtDevices.SetStatusWarningBackground(currSlaveId);
                        //    }
                        //}));
                        #endif
                        if (IsSimulation)
                        {
                            await Task.Delay(1000).ConfigureAwait(false);
                        }
                    }
                }

#endregion // foreach
                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.None, "");
                // Wenn es eine Roboteranwendung ist
                if (isRobot)
                {
                    // Wenn es keine CU+ für eine Roboteranwendung ist, dann Warnung ausgeben
                    if (isCuPartNo_100684 || isCuPartNo_101189)
                    {
                        mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, "Control units types other than (PartNo: 100685) are not permitted!");
                        mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, "Please contact the service.");
                    }
                }
                // Wenn zwei verschiedene Geraete-Typen betrieben werden, dann Warnung ausgeben
                else if (isCuPartNo_100684 && isCuPartNo_101189)
                {
                    mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, "Different control units types (PartNo: 101189, 100684) are not permitted!");
                    mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Warning, "Please contact the service.");
                }
            }
            catch (Exception exc)
            {
                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, exc.Message);
            }
        }

        /// <summary>
        /// Identify über Downloadkernel ausführen
        /// </summary>
        private async Task<bool> IdentifyOverDownloadkernel(IhtCommunic.SlaveId.Id slaveId)
        {
            IhtCommunicManagerService.Manager managerService = null;
            IhtCommunicManagerApc.Manager managerApc = null;
            IhtCommunic.Error.ErrorInfo errorInfo = new IhtCommunic.Error.ErrorInfo(false);
            try
            {
                IhtCommunicService.Download.Download download = null;
                IhtCommunicService.CutbusData.ApplicationInfoData applicationInfoData = new IhtCommunicService.CutbusData.ApplicationInfoData();
                IhtCommunicService.CutbusData.DownloadKernelInfoData downloadKernelInfoData = new IhtCommunicService.CutbusData.DownloadKernelInfoData();

                managerService = IhtCommunicManager.CommunicManager.CreateCommunicManagerService();

                errorInfo = managerService.Open();
                if (!errorInfo.IsResult())
                {
                    mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, errorInfo.Message);
                }

                if (errorInfo.IsResult())
                {
                    managerApc = IhtCommunicManager.CommunicManager.CreateCommunicManagerApc(IhtCommunicManager.CommunicManager.CommunicType.Modbus, new IhtCommunic.Unit.Unit(IhtCommunic.Unit.Dimension.Type.mm));
                    errorInfo = managerApc.Open();
                    if (!errorInfo.IsResult())
                    {
                        mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, errorInfo.Message);
                    }
                    else
                    {
                        ClosePort();
                        errorInfo = managerApc.ConnectRtu(communicData.ComPort, communicData.Baudrate);
                        download = new IhtCommunicService.Download.Download(slaveId, managerApc.Communic);
                    }
                }

                ushort address = 0;
                ushort length = 0;
                IhtCommunic.Error.ErrorInfoRead errorInfoRead = new IhtCommunic.Error.ErrorInfoRead(false);
                if (errorInfo.IsResult())
                {
                    download = new IhtCommunicService.Download.Download(slaveId, managerApc.Communic);
                    // ApplikationsInfo-Daten auslesen
                    address = (ushort)IhtCommunicService.CutbusData.ApplicationInfoData.Address.Start;
                    length = (ushort)IhtCommunicService.CutbusData.ApplicationInfoData.Idx.Length;
                    errorInfoRead = await managerApc.Communic.ReadRegistersAsync(slaveId, address, length)/*.ConfigureAwait(false)*/;
                    if (errorInfoRead.IsResult())
                    {
                        // ApplikationsInfo-Daten übernehmen
                        applicationInfoData.SetDatas(errorInfoRead.Datas);
                    }
                    else
                    {
                        mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, errorInfoRead.Message);
                    }
                }
                else
                {
                    mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, errorInfo.Message);
                }

                string partNo = string.Empty;
                // Wenn kein Fehler und Freischaltung erfolgreich war
                if (errorInfoRead.IsResult())
                {
                    // DownloadKernelInfo-Daten auslesen
                    address = (ushort)IhtCommunicService.CutbusData.DownloadKernelInfoData.Address.Start;
                    length = (int)IhtCommunicService.CutbusData.DownloadKernelInfoData.Idx.Length;
                    errorInfoRead = await managerApc.Communic.ReadRegistersAsync(slaveId, address, length)/*.ConfigureAwait(false)*/;
                    if (errorInfoRead.IsResult())
                    {
                        // DownloadKernelInfo-Daten übernehmen
                        downloadKernelInfoData.SetDatas(errorInfoRead.Datas);

                        bool isValid = false;
                        partNo = applicationInfoData.PartNo(out isValid).ToString();

                        string message = string.Empty;
                        message += string.Format("Product: {0}", downloadKernelInfoData.ProductText()) + Environment.NewLine;
                        message += string.Format("SubProduct: {0}", downloadKernelInfoData.SubProductText()) + Environment.NewLine;
                        //message += string.Format("Options: {0}", "todo") + Environment.NewLine;
                        message += string.Format("Partnumber: {0}", applicationInfoData.PartNo(out isValid)) + Environment.NewLine;
                        message += string.Format("Serialnumber: {0}", applicationInfoData.SerialNo(out isValid)) + Environment.NewLine;
                        message += string.Format("Hardware-Version: {0}", applicationInfoData.HwVersionText()) + Environment.NewLine;
                        message += string.Format("Extension: 0x{0,8:X8}", applicationInfoData.Extension(out isValid)) + Environment.NewLine;
                        string txtApplNotAvailable = "Application is not available";
                        message += string.Format("Firmware: {0}", applicationInfoData.IsProgTypeApplicationFlash() ? "Application is active" : txtApplNotAvailable) + Environment.NewLine;
                        // Downloadkernel: Mediums, Protocols
                        message += "Downloadkernel mediums: " + downloadKernelInfoData.MediumsText() + Environment.NewLine;
                        message += "Downloadkernel protocols: " + downloadKernelInfoData.ProtocolsText() + Environment.NewLine;
                        // Firmware
                        if (applicationInfoData.IsProgTypeApplicationFlash())
                        {
                            message += string.Format("Application Firmware-Version: {0}", applicationInfoData.FwVersionText()) + Environment.NewLine;
                        }
                        message += string.Format("Downloadkernel Firmware-Version: {0}", downloadKernelInfoData.FwVersionText()) + Environment.NewLine;
                        //MessageBox.Show(message);
                        string[] vs = message.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string s in vs)
                        {
                            if (s.Contains(txtApplNotAvailable))
                            {
                                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, s);
                            }
                            else
                            {
                                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Info, s);
                            }
                        }
                    }
                    else
                    {
                        mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, errorInfoRead.Message);
                    }
                }
                errorInfo.Set(errorInfoRead);
            }
            catch (Exception ex)
            {
                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, ex.Message);
                errorInfo.Result = false;
            }
            finally
            {
                if (managerApc != null)
                {
                    managerApc.Close();
                }
                if (managerService != null)
                {
                    managerService.Close();
                }
                //OpenPort();
            }
            return errorInfo.Result;
        }

#region Rd_Data
        /// <summary>
        /// Ab StartAdresse 10 Eintraege lesen
        /// </summary>
        private async Task<object> Rd_AddrPreAreasAsync(int slaveId, IhtModbusResult ihtModbusResult)
        {
            //Result = IsSimulation;
            // Ab StartAdresse 10 Eintraege lesen
            ushort startAddress = (ushort)IhtModbusData.eAddress.StartAddress;
            ushort numRegisters = (ushort)IhtModbusData.eIdxAddr.StartDeviceInfo;
            var values = !IsSimulation ? await ReadHoldingRegistersAsync((byte)slaveId, startAddress, numRegisters, ihtModbusResult).ConfigureAwait(false)
                                       : await _apcSimulationDataMockDBService.ReadHoldingRegistersAsync((byte)slaveId, startAddress, numRegisters, ihtModbusResult).ConfigureAwait(false);
            return values;
        }

        /// <summary>
        /// Daten auslesen
        /// </summary>
        private async Task<bool> Rd_AddrAreasAsync(IhtModbusData ihtModbusData)
        {
            IhtModbusResult ihtModbusResult = new IhtModbusResult(); ;
            ihtModbusResult.Result = IsSimulation;
            // Adress-Bereiche auslesen
            ushort startAddress = (ushort)IhtModbusData.eAddress.StartAddress;
            ushort numRegisters = (ushort)IhtModbusData.eIdxAddr.Reserved5 + 1;
            numRegisters += (ushort)(ihtModbusData.GetAreasNumber() * 2);

            var values = !IsSimulation ? await ReadHoldingRegistersAsync((byte)ihtModbusData.SlaveId, startAddress, numRegisters, ihtModbusResult).ConfigureAwait(false)
                                       : await _apcSimulationDataMockDBService.ReadHoldingRegistersAsync((byte)ihtModbusData.SlaveId, startAddress, numRegisters, ihtModbusResult).ConfigureAwait(false);

            if (ihtModbusResult.Result)
            {
                if (!IsSimulation)
                {
                    ihtModbusData.SetAreasReservedData((ushort[])values);
                    ushort[] src = (ushort[])values;
                    ushort[] datas = new ushort[ihtModbusData.GetAreasNumber() * 2];
                    for (int i = 0; i < datas.Length; i++)
                    {
                        datas[i] = src[(int)IhtModbusData.eIdxAddr.Reserved5 + 1 + i];
                    }
                    ihtModbusData.SetAreasData(datas);
                }
                else
                {
                    var info = values.Select((v, i) => new { Index = i, Value = v }).Where(x => x.Index >= 10).Select(x => x.Value).ToArray();
                    ihtModbusData.SetAreasData(info);
                }
            }
            return ihtModbusResult.Result;
        }

        /// <summary>
        /// Daten auslesen
        /// </summary>
        public async Task<bool> Rd_DataAsync(IhtModbusData ihtModbusData, GetAddrInfoDelegate addrInfoDelegate, SetValuesDelegate setValuesDelegate)
        {
            if (IsSimulation) return true;

            IhtModbusResult ihtModbusResult = new IhtModbusResult();
            IhtModbusAddrInfo addrInfo = addrInfoDelegate();
            var values = await ReadHoldingRegistersAsync((byte)ihtModbusData.SlaveId, addrInfo.u16StartAddr, addrInfo.u16AddrNumber, ihtModbusResult).ConfigureAwait(false);
            if (ihtModbusResult.Result)
            {
                setValuesDelegate((ushort[])values);
            }
            return ihtModbusResult.Result;
        }
#endregion // Rd_Data  

        /// <summary>
        /// 
        /// </summary>
        public IhtModbusData GetData(int SlaveId)
        {
            foreach (IhtModbusData data in ihtModbusDatas)
            {
                if (data.SlaveId == SlaveId)
                {
                    return data;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<UInt16[]> ReadAsync(byte slaveId, ushort u16StartAddr, ushort u16NumOfRegister, IhtModbusResult ihtModbusResult)
        {
            return await ReadHoldingRegistersAsync(slaveId, u16StartAddr, u16NumOfRegister, ihtModbusResult).ConfigureAwait(false);
        }
        public async Task<UInt16[]> ReadAsync(int slaveId, ushort u16StartAddr, ushort u16NumOfRegister, IhtModbusResult ihtModbusResult)
        {
            return await ReadAsync((byte)slaveId, u16StartAddr, u16NumOfRegister, ihtModbusResult).ConfigureAwait(false);
        }
        public async Task<UInt16> ReadAsync(int slaveId, ushort u16StartAddr, IhtModbusResult ihtModbusResult)
        {
            UInt16[] u16Datas = await ReadAsync(slaveId, u16StartAddr, 1, ihtModbusResult).ConfigureAwait(false);
            return (u16Datas != null) ? u16Datas[0] : (UInt16)0xFFFF;
        }

        /// <summary>
        /// 
        /// </summary>
#if False
    public void Read(byte slaveId, ushort u16StartAddr, ushort u16NumOfRegister, CallbackRead callBack, object ownerData)
    {
      ReadHoldingRegisters(slaveId, u16StartAddr, u16NumOfRegister, callBack, ownerData);
    }
    public void Read(int slaveId, ushort u16StartAddr, ushort u16NumOfRegister, CallbackRead callBack, object ownerData)
    {
      Read((byte)slaveId, u16StartAddr, u16NumOfRegister, callBack, ownerData);
    }
    public void Read(int slaveId, ushort u16StartAddr, CallbackRead callBack, object ownerData)
    {
      Read(slaveId, u16StartAddr, 1, callBack, ownerData);
    }
#endif

        /// <summary>
        /// 
        /// </summary>
        public async Task<bool> WriteAsync(byte slaveId, ushort u16StartAddr, ushort[] u16Datas)
        {
            return await WriteMultipleRegistersAsync(slaveId, u16StartAddr, u16Datas).ConfigureAwait(false);
        }
        public async Task<bool> WriteAsync(int slaveId, ushort u16StartAddr, ushort[] u16Datas)
        {
            return await WriteMultipleRegistersAsync((byte)slaveId, u16StartAddr, u16Datas).ConfigureAwait(false);
        }
        public async Task<bool> WriteAsync(int slaveId, ushort u16StartAddr, ushort u16Data)
        {
            ushort[] u16Datas = { u16Data };
            return await WriteMultipleRegistersAsync((byte)slaveId, u16StartAddr, u16Datas).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
#if _false
    public async Task WriteAsync(byte slaveId, ushort u16StartAddr, ushort[] u16Datas/*, IhtSemaphore semaphore*/)
    {
      await WriteMultipleRegistersAsync(slaveId, u16StartAddr, u16Datas/*, semaphore*/).ConfigureAwait(false);
    }
    public async Task WriteAsync(int slaveId, ushort u16StartAddr, ushort[] u16Datas/*, IhtSemaphore semaphore*/)
    {
      await WriteMultipleRegistersAsync((byte)slaveId, u16StartAddr, u16Datas/*, semaphore*/).ConfigureAwait(false);
    }
    public async Task WriteAsync(int slaveId, ushort u16StartAddr, ushort u16Data/*, IhtSemaphore semaphore*/)
    {
      ushort[] u16Datas = { u16Data };
      await WriteMultipleRegistersAsync((byte)slaveId, u16StartAddr, u16Datas/*, semaphore*/).ConfigureAwait(false);
    }
#endif

#region Read_...
        /// <summary>
        /// Adress-Bereiche auslesen
        /// </summary>
        public async Task<bool> Read_AddrAreasAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_AddrAreasAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// Geraete-Info auslesen 
        /// </summary>
        public async Task<bool> Read_DeviceInfoAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_DeviceInfo, ihtModbusData.SetDeviceInfoData).ConfigureAwait(false);
        }

        /// <summary>
        /// Technologie-Parameter Const. auslesen 
        /// </summary>
        public async Task<bool> Read_TechnologyConstAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_TechnologyConst, ihtModbusData.SetTechnologyConstData).ConfigureAwait(false);
        }

        /// <summary>
        /// Process-Parameter Const. auslesen 
        /// </summary>
        public async Task<bool> Read_ProcessConstAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ProcessConst, ihtModbusData.SetProcessConstData).ConfigureAwait(false);
        }

        /// <summary>
        /// Config-Parameter Const. auslesen 
        /// </summary>
        public async Task<bool> Read_ConfigConstAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ConfigConst, ihtModbusData.SetConfigConstData).ConfigureAwait(false);
        }

        /// <summary>
        /// Sevice-Parameter Const. auslesen
        /// </summary>
        public async Task<bool> Read_ServiceConstAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ServiceConst, ihtModbusData.SetServiceConstData).ConfigureAwait(false);
        }

        /// <summary>
        /// Technologie-Parameter Dyn. auslesen
        /// </summary>
        public async Task<bool> Read_TechnologyDynAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_TechnologyDyn, ihtModbusData.SetTechnologyDynData).ConfigureAwait(false);
        }

        /// <summary>
        /// Process-Parameter Dyn. auslesen
        /// </summary>
        public async Task<bool> Read_ProcessDynAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ProcessDyn, ihtModbusData.SetProcessDynData).ConfigureAwait(false);
        }

        /// <summary>
        /// Config-Parameter Dyn. auslesen 
        /// </summary>
        public async Task<bool> Read_ConfigDynAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ConfigDyn, ihtModbusData.SetConfigDynData).ConfigureAwait(false);
        }

        /// <summary>
        /// Sevice-Parameter Dyn. auslesen
        /// </summary>
        public async Task<bool> Read_ServiceDynAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ServiceDyn, ihtModbusData.SetServiceDynData).ConfigureAwait(false);
        }

        /// <summary>
        /// Process-Info auslesen
        /// </summary>
        public async Task<bool> Read_ProcessInfoAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ProcessInfo, ihtModbusData.SetProcInfoData).ConfigureAwait(false);
        }

        /// <summary>
        /// Cmd-Exec. auslesen
        /// </summary>
        public async Task<bool> Read_CmdExecAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_CmdExec, ihtModbusData.SetCmdExecData).ConfigureAwait(false);
        }

        /// <summary>
        /// Setup-Exec. auslesen
        /// </summary>
        public async Task<bool> Read_SetupExecAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_SetupExec, ihtModbusData.SetSetupExecData).ConfigureAwait(false);
        }
#endregion // Read_...


#region Read_Tables Text...
        /// <summary>
        /// Data auslesen
        /// </summary>
        public async Task<bool> Read_DataAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_Data, ihtModbusData.SetData).ConfigureAwait(false);
        }

        /// <summary>
        /// TableData auslesen
        /// </summary>
        public async Task<bool> Read_TableDataAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_TableData, ihtModbusData.SetTableData).ConfigureAwait(false);
        }

        /// <summary>
        /// Error-Code Labels auslesen
        /// </summary>
        public async Task<bool> Read_TableErrorCodeLabelsAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusTables.ihtModbusTableErrorLabels.Read_TableTextAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// Error-Code Counts auslesen
        /// </summary>
        public async Task<bool> Read_TableErrorAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusTables.ihtModbusTableErrorTbl.Read_TableTextAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// OxyProc CutCycleHistory Current  auslesen
        /// </summary>
        public async Task<bool> Read_TableOxyProcCutCycleHistoryCurrentAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusTables.ihtModbusTableOxyProcCutCycleStateCurrTbl.Read_TableTextAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// OxyProc CutCycleHistory Previous  auslesen
        /// </summary>
        public async Task<bool> Read_TableOxyProcCutCycleHistoryPreviousAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusTables.ihtModbusTableOxyProcCutCycleStatePrevTbl.Read_TableTextAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// Temperatur Histogramm fuer µC auslesen
        /// </summary>
        public async Task<bool> Read_TableTempHistogramuCTblAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusTables.ihtModbusTableTempHistogramuCTbl.Read_TableTextAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// Histogramm  Common auslesen
        /// </summary>
        public async Task<bool> Read_TableHistogramCommonTblAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusTables.ihtModbusTableHistogramCommonTbl.Read_TableTextAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// Histogramm Common fuer Kunde auslesen
        /// </summary>
        public async Task<bool> Read_TableHistogramCommonCustomTblAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusTables.ihtModbusTableHistogramCommonCustomTbl.Read_TableTextAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// Fehler Histogramm fuer Kunde auslesen
        /// </summary>
        public async Task<bool> Read_TableErrorCustomTblAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusTables.ihtModbusTableErrorCustomTbl.Read_TableTextAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// FIT+3 Fehler Histogramm fuer µC auslesen
        /// </summary>
        public async Task<bool> Read_TableFitPlus3HistoErrorTblAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusTables.ihtModbusTableFitPlus3HistoErrorTbl.Read_TableTextAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// FIT+3 Temperatur Histogramm fuer µC auslesen
        /// </summary>
        public async Task<bool> Read_TableFitPlus3HistoErrorCustomTblAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusTables.ihtModbusTableFitPlus3HistoErrorCustomTbl.Read_TableTextAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// FIT+3 Temperatur Histogramm fuer µC auslesen
        /// </summary>
        public async Task<bool> Read_TableFitPlus3HistoTempuCTblAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusTables.ihtModbusTableFitPlus3HistoTempuCTbl.Read_TableTextAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// FIT+3 Temperatur-Oben Histogramm auslesen
        /// </summary>
        public async Task<bool> Read_TableFitPlus3HistoTempTopTblAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusTables.ihtModbusTableFitPlus3HistoTempTopTbl.Read_TableTextAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// FIT+3 Temperatur-Unten Histogramm auslesen
        /// </summary>
        public async Task<bool> Read_TableFitPlus3HistoTempBottomTblAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusTables.ihtModbusTableFitPlus3HistoTempBottomTbl.Read_TableTextAsync(ihtModbusData).ConfigureAwait(false);
        }
#endregion // Read_Tables Text...


#region Read_Tables Value...
        /// <summary>
        /// Status-Info auslesen
        /// </summary>
        public async Task<bool> Read_TableStatusInfoTblAsync(IhtModbusData ihtModbusData, int dataOffsetAddr = 0, int dataCounts = (int)IhtModbusParamDyn.eIdxData.DataMaxLength)
        {
            return await ihtModbusTables.ihtModbusTableStatusInfoTbl.Read_TableValueAsync(ihtModbusData, dataOffsetAddr, dataCounts).ConfigureAwait(false);
        }

        /// <summary>
        /// Status-Info Specific auslesen
        /// </summary>
        public async Task<bool> Read_TableStatusInfoSpecificTblAsync(IhtModbusData ihtModbusData, int dataOffsetAddr = 0, int dataCounts = (int)IhtModbusParamDyn.eIdxData.DataMaxLength)
        {
            return await ihtModbusTables.ihtModbusTableStatusInfoSpecificTbl.Read_TableValueAsync(ihtModbusData, dataOffsetAddr, dataCounts).ConfigureAwait(false);
        }
#endregion // Read_Tables Value...


#region Write_EraseTables...
        private UInt16 GetTableDataAddr(IhtModbusData ihtModbusData, IhtModbusParamDyn.eIdxTable eIdxTable)
        {
            IhtModbusAddrInfo addrInfo = ihtModbusData.GetAddrInfo_TableData();
            UInt16 address = (UInt16)(addrInfo.u16StartAddr + eIdxTable);
            return address;
        }

        /// <summary>
        /// Fehler Histogramm fuer löschen
        /// </summary>
        public async Task<bool> Write_EraseTableErrorTblAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, GetTableDataAddr(ihtModbusData, IhtModbusParamDyn.eIdxTable.ErrorEepromErase), 0).ConfigureAwait(false);
        }

        /// <summary>
        /// Temperatur Histogramm fuer µC löschen
        /// </summary>
        public async Task<bool> Write_EraseTableTempHistogramuCTblcAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, GetTableDataAddr(ihtModbusData, IhtModbusParamDyn.eIdxTable.TempHistogramuCErase), 0).ConfigureAwait(false);
        }

        /// <summary>
        /// Histogramm  Common löschen
        /// </summary>
        public async Task<bool> Write_EraseTableHistogramCommonTblAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, GetTableDataAddr(ihtModbusData, IhtModbusParamDyn.eIdxTable.HistogramCommonErase), 0).ConfigureAwait(false);
        }

        /// <summary>
        /// Histogramm Common fuer Kunde löschen
        /// </summary>
        public async Task<bool> Write_EraseTableHistogramCommonCustomTblAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, GetTableDataAddr(ihtModbusData, IhtModbusParamDyn.eIdxTable.HistogramCommonCustomErase), 0).ConfigureAwait(false);
        }

        /// <summary>
        /// Fehler Histogramm fuer Kunde löschen
        /// </summary>
        public async Task<bool> Write_EraseTableErrorCustomTblAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, GetTableDataAddr(ihtModbusData, IhtModbusParamDyn.eIdxTable.ErrorCustomErase), 0).ConfigureAwait(false);
        }

        /// <summary>
        /// FIT+3 Fehler Histogramm löschen
        /// </summary>
        public async Task<bool> Write_EraseTableFitPlus3HistoErrorTblAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, GetTableDataAddr(ihtModbusData, IhtModbusParamDyn.eIdxTable.FitPlus3HistoErrorErase), 0).ConfigureAwait(false);
        }

        /// <summary>
        /// FIT+3 Fehler Histogramm für Kunde löschen
        /// </summary>
        public async Task<bool> Write_EraseTableFitPlus3HistoErrorCustomTblAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, GetTableDataAddr(ihtModbusData, IhtModbusParamDyn.eIdxTable.FitPlus3HistoErrorCustomErase), 0).ConfigureAwait(false);
        }

        /// <summary>
        /// FIT+3 Alle Fehler Histogramme löschen
        /// </summary>
        public async Task<bool> Write_EraseTableFitPlus3HistoErrorAllAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, GetTableDataAddr(ihtModbusData, IhtModbusParamDyn.eIdxTable.FitPlus3HistoErrorAllErase), 0).ConfigureAwait(false);
        }

        /// <summary>
        /// FIT+3 Alle Temperatur Histogramm löschen
        /// </summary>
        public async Task<bool> Write_EraseTableFitPlus3HistoTempuAllAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, GetTableDataAddr(ihtModbusData, IhtModbusParamDyn.eIdxTable.FitPlus3HistoTempAllErase), 0).ConfigureAwait(false);
        }
#endregion // Write_EraseTables...


#region Write...
        /// <summary>
        /// Technologie-Parameter Dyn. schreiben
        /// </summary>
        public async Task<bool> Write_TechnologyDynAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, ihtModbusData.GetAddrInfo_TechnologyDyn().u16StartAddr, ihtModbusData.GetDataTechnologyDyn()).ConfigureAwait(false);
        }
        /// <summary>
        /// Parameter ProcesDyn schreiben
        /// </summary>
        public async Task<bool> Write_ProcessDynAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, ihtModbusData.GetAddrInfo_ProcessDyn().u16StartAddr, ihtModbusData.GetDataProcessDyn()).ConfigureAwait(false);
        }

        /// <summary>
        /// Parameter ConfigDyn schreiben
        /// </summary>
        public async Task<bool> Write_ConfigDynAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, ihtModbusData.GetAddrInfo_ConfigDyn().u16StartAddr, ihtModbusData.GetDataConfigDyn()).ConfigureAwait(false);
        }

        /// <summary>
        /// Parameter ServiceDyn schreiben
        /// </summary>
        public async Task<bool> Write_ServiceDynAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, ihtModbusData.GetAddrInfo_ServiceDyn().u16StartAddr, ihtModbusData.GetDataServiceDyn()).ConfigureAwait(false);
        }

        /// <summary>
        /// Parameter CmdExec schreiben
        /// </summary>
        public async Task<bool> Write_CmdExecAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, ihtModbusData.GetAddrInfo_CmdExec().u16StartAddr, ihtModbusData.GetDataCmdExec()).ConfigureAwait(false);
        }

        /// <summary>
        /// Parameter SetupExec schreiben
        /// </summary>
        public async Task<bool> Write_SetupExecAsync(IhtModbusData ihtModbusData)
        {
            return await WriteAsync(ihtModbusData.SlaveId, ihtModbusData.GetAddrInfo_SetupExec().u16StartAddr, ihtModbusData.GetDataSetupExec()).ConfigureAwait(false);
        }
    #endregion // Write_...

  }

}
