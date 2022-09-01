using System;
using System.Threading.Tasks;
using System.Windows;
using System.IO.Ports;
using System.Net.Sockets;
//using log4net;
//using Modbus.Device;
using System.Collections;
using SharedComponents;
using SharedComponents.Helpers;
using SharedComponents.IhtModbusCmd;
using System.Threading;
using SharedComponents.IhtMsg;
using SharedComponents.IhtData;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbusTable;
using SharedComponents.Cultures;
using System.Collections.Generic;
using SharedComponents.Services.APCHardwareManagers;
using SharedComponents.Services.APCHardwareMockDBServices;
using SharedComponents.StatusInfo;
using NModbus;
using NModbus.Serial;
using NModbus.Utility;
using static IhtCommunicService.CutbusData.DownloadKernelInfoData;

namespace SharedComponents.IhtModbus
{
    public class IhtModbusCommunicInfo
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

        // Declare a delegate
        public delegate IhtModbusAddrInfo GetAddrInfoDelegate();
        public delegate UInt16[] GetValuesDelegate();
        public delegate void SetValuesDelegate(UInt16[] u16Datas);
        public delegate string GetDescriptionDelegate(UInt16 u16Idx, UInt16 u16Value);
        public delegate string GetDescriptionConstDelegate(UInt16 u16Idx);
        public delegate string GetUnitDelegate(UInt16 u16Idx);
        public delegate double GetRealMultiplierDelegate(UInt16 u16Idx);

        public IhtDevices _ihtDevices;
        public readonly IAPCSimulationDataMockDBService _apcSimulationDataMockDBService;
        public readonly IParameterDataInfoManager _parameterDataInfoManager;

        // TODO: remove when we will read from command line ?
        static bool IsSimulation = true;

        private SerialPort _port = null;
        private TcpClient _client = null;
        private IModbusMaster _modbusMaster = null;


        public IhtModbusCommunicInfo(
                IhtDevices ihtDevices,
                IAPCSimulationDataMockDBService apcSimulationDataMockDBService,
                IParameterDataInfoManager parameterDataInfoManager
                )
        {
            _ihtDevices = ihtDevices ??
               throw new ArgumentNullException($"{nameof(ihtDevices)}");

            _apcSimulationDataMockDBService = apcSimulationDataMockDBService ??
               throw new ArgumentNullException($"{nameof(apcSimulationDataMockDBService)}");

            _parameterDataInfoManager = parameterDataInfoManager ??
               throw new ArgumentNullException($"{nameof(parameterDataInfoManager)}");
        }

        public static int GetStationNo(int slaveId)
        {
            return (int)slaveId - (int)SlaveId.Id_Default;
        }
        public static int GetStationNo(SlaveId slaveId)
        {
            return GetStationNo((int)slaveId);
        }

        /// <summary>
        /// - Broadcastfunktionalität dahingehend erweitert, dass im 1. Registerwert die Slave-Ids bitkodiert erwartet werden.
        ///   Befehl wird nur dann angenommen, wenn das entsprechende Slave-Id Bit im 1. Registerwert vorhanden ist.
        ///   Der 1. Registerwert wird danach verworfen und die Registeranzahl um den Wert 1 vermindert. 
        /// </summary>
        private static UInt16 GetOnSlaveIdBits()
        {
            return (UInt16)IhtModbusCommunic.CurrOnSlaveBits;
        }

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
        /// 
        /// </summary>
        private void OpenPort(string comPort)
        {
            if (_port != null)
            {
                _port.Close();
            }
            _port = new SerialPort(comPort);
            // configure serial port
            _port.BaudRate = 57600;
            _port.DataBits = 8;
            _port.Parity = Parity.Even;
            _port.StopBits = StopBits.One;
            _port.WriteTimeout = 1000;
            _port.ReadTimeout = 1000;
            if (!IsSimulation)
            {
                _port.Open();
            }
        }

        /// <summary>
        /// Modbus Kommunikation über RTU herstellen
        /// </summary>
        private async Task<bool> ConnectRtuAsync(string comPort)
        {
            bool blResult = false;
            try
            {
                await Task.Delay(100).ConfigureAwait(false);

                if (_client != null)
                {
                    _client.Close();
                }

                if (!IsSimulation && SerialPort.GetPortNames().Length == 0)
                {
                    //mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, "No serial COM-Port available!");
                    return false;
                }

                OpenPort(comPort);

                //string msg = String.Format("Port: {0}; Baudrate: {1}", comPort, communicData.Baudrate.ToString());
                //mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Info, msg);

                // create modbus master
                var factory = new ModbusFactory();
                _modbusMaster = factory.CreateRtuMaster(_port);
                _modbusMaster.Transport.ReadTimeout = 500;
                _modbusMaster.Transport.WriteTimeout = 500;
                _modbusMaster.Transport.WaitToRetryMilliseconds = 250;

            }
            catch (Exception exc)
            {

            }

            return blResult;
        }

        public async Task ConnectAsync(string comPort, bool isSimulation, bool isExecReset)
        {
            IhtModbusTableBase.IsSimulation = IsSimulation = isSimulation;

            bool result = await ConnectRtuAsync(comPort);

            int currSlaveId = (int)SlaveId.Id_Broadcast;
            int firstConnectedSlaveId = 0;

            ArrayList slaveIds = _ihtDevices.GetVisibleSlaveIds();

            IhtModbusResult ihtModbusResult = new IhtModbusResult();

            UInt16 u16VisibleSlaveIdBits = 0;
            foreach (int _slaveId in slaveIds)
            {
                u16VisibleSlaveIdBits |= IhtModbusCommunic.GetSlaveIdBit(_slaveId);
            }

            // Einen Reset der Control-Units auslösen, damit die Daten der Fit+3 erneut ausgelesen werden
            if (isExecReset)
            {
                /*
                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.None, "");
                msg = CultureResources.GetString("_CultureResetAllDevices");
                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Info, msg);
                */
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

            foreach (int slaveId in slaveIds)
            {
                bool blSlaveIdBroadcast = false;
                currSlaveId = slaveId;
                if (currSlaveId == (int)SlaveId.Id_Broadcast)
                {
                    currSlaveId = firstConnectedSlaveId;
                    blSlaveIdBroadcast = true;
                }

                if (currSlaveId == (int)SlaveId.Id_Broadcast)
                {
                    // Und gleich zum Nächsten
                    continue;
                }


                var values = await Rd_AddrPreAreasAsync(slaveId, ihtModbusResult).ConfigureAwait(false);

                var ihtModbusData = new IhtModbusData(slaveId, (ushort[])values, IsSimulation);

                // Adress-Bereiche auslesen
                //ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await _ihtDevices.Read_AddrAreasAsync(ihtModbusData).ConfigureAwait(false));
                ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await Read_AddrAreasAsync(ihtModbusData).ConfigureAwait(false));
                // Geraete-Info auslesen
                //ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await _ihtDevices.Read_DeviceInfoAsync(ihtModbusData, true).ConfigureAwait(false));
                ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await Read_DeviceInfoAsync(ihtModbusData, true).ConfigureAwait(false));
                // Technologie-Parameter Const. auslesen
                //ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await _ihtDevices.Read_TechnologyConstAsync(ihtModbusData, true).ConfigureAwait(false));
                ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await Read_TechnologyConstAsync(ihtModbusData, true).ConfigureAwait(false));
                // Process-Parameter Const. auslesen
                //ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await _ihtDevices.Read_ProcessConstAsync(ihtModbusData, true).ConfigureAwait(false));
                ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await Read_ProcessConstAsync(ihtModbusData, true).ConfigureAwait(false));
                // Config-Parameter Const. auslesen                                                                                     
                //ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await _ihtDevices.Read_ConfigConstAsync(ihtModbusData, true).ConfigureAwait(false));
                ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await Read_ConfigConstAsync(ihtModbusData, true).ConfigureAwait(false));
                // Sevice-Parameter Const. auslesen                                                                                    
                //ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await _ihtDevices.Read_ServiceConstAsync(ihtModbusData, true).ConfigureAwait(false));
                ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await Read_ServiceConstAsync(ihtModbusData, true).ConfigureAwait(false));
                // Technologie-Parameter Dyn. auslesen                                                                                 
                //ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await _ihtDevices.Read_TechnologyDynAsync(ihtModbusData, true).ConfigureAwait(false));
                ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await Read_TechnologyDynAsync(ihtModbusData, true).ConfigureAwait(false));
                // Process-Parameter Dyn. auslesen                                                                                     
                //ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await _ihtDevices.Read_ProcessDynAsync(ihtModbusData, true).ConfigureAwait(false));
                ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await Read_ProcessDynAsync(ihtModbusData, true).ConfigureAwait(false));
                // Config-Parameter Dyn. auslesen                                                                                      
                //ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await _ihtDevices.Read_ConfigDynAsync(ihtModbusData, true).ConfigureAwait(false));
                ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await Read_ConfigDynAsync(ihtModbusData, true).ConfigureAwait(false));
                // Sevice-Parameter Dyn. auslesen                                                                                      
                //ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await _ihtDevices.Read_ServiceDynAsync(ihtModbusData, true).ConfigureAwait(false));
                ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await Read_ServiceDynAsync(ihtModbusData, true).ConfigureAwait(false));
            }

            var devicesAmount = _ihtDevices.GetVisibleDevices().Count;
            await _parameterDataInfoManager.UpdateAPCHardwareDataAsync(CancellationToken.None, devicesAmount);

        }

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
                    ihtModbusData.SetAreasData((ushort[])values);
                }
            }
            return ihtModbusResult.Result;
        }

        /// <summary>
        /// Geraete-Info reading 
        /// </summary>
        internal async Task<bool> Read_DeviceInfoAsync(IhtModbusData ihtModbusData, bool updateData)
        {
            bool blResult = await Read_DeviceInfoAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateData)
            {
                IhtDevice _ihtDevice = _ihtDevices.GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateDataDeviceInfo(ihtModbusData);
                }
            }
            return blResult;
        }

        /// <summary>
        /// Technologie-Parameter Const. reading 
        /// </summary>
        internal async Task<bool> Read_TechnologyConstAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await Read_TechnologyConstAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = _ihtDevices.GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateDataParamConstTechnology(ihtModbusData);
                }
            }
            return blResult;
        }

        /// <summary>
        /// Process-Parameter Const. reading 
        /// </summary>
        internal async Task<bool> Read_ProcessConstAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await Read_ProcessConstAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = _ihtDevices.GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateDataParamConstProcess(ihtModbusData);
                }
            }
            return blResult;
        }

        /// <summary>
        /// Config-Parameter Const. auslesen 
        /// </summary>
        internal async Task<bool> Read_ConfigConstAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await Read_ConfigConstAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = _ihtDevices.GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateDataParamConstConfig(ihtModbusData);
                }
            }
            return blResult;
        }

        /// <summary>
        /// Sevice-Parameter Const. auslesen
        /// </summary>
        internal async Task<bool> Read_ServiceConstAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await Read_ServiceConstAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = _ihtDevices.GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateDataParamConstService(ihtModbusData);
                }
            }
            return blResult;
        }

        /// <summary>
        /// Technologie-Parameter Dyn. auslesen
        /// </summary>
        internal async Task<bool> Read_TechnologyDynAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await Read_TechnologyDynAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                _ihtDevices.UpdateParamDynTechnology(ihtModbusData);
            }
            return blResult;
        }

        /// <summary>
        /// Process-Parameter Dyn. auslesen
        /// </summary>
        internal async Task<bool> Read_ProcessDynAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await Read_ProcessDynAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = _ihtDevices.GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateParamDynProcess(ihtModbusData);
                }
            }
            return blResult;
        }

        /// <summary>
        /// Config-Parameter Dyn. auslesen 
        /// </summary>
        internal async Task<bool> Read_ConfigDynAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await Read_ConfigDynAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = _ihtDevices.GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateParamDynConfig(ihtModbusData);
                }
            }
            return blResult;
        }

        /// <summary>
        /// Sevice-Parameter Dyn. auslesen
        /// </summary>
        internal async Task<bool> Read_ServiceDynAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await Read_ServiceDynAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = _ihtDevices.GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateParamDynService(ihtModbusData);
                }
            }
            return blResult;
        }

        private async Task<UInt16[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numRegisters, IhtModbusResult ihtModbusResult)
        {
            return await ModbusMaster_ReadHoldingRegistersAsync(slaveAddress, startAddress, numRegisters, ihtModbusResult).ConfigureAwait(false);
        }

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
                    datas = _modbusMaster.ReadHoldingRegisters(slaveAddress, startAddress, numRegisters);
                }
                else
                {
                    datas = await _apcSimulationDataMockDBService.ReadHoldingRegistersAsync(slaveAddress, startAddress, numRegisters);
                }
                ihtModbusResult.Result = true;
                _ihtDevices.ClrCommunicError((int)slaveAddress);
            }
            catch (Exception exc)
            {
                ihtModbusResult.Result = false;
                string txtSlaveId = CultureResources.GetString("_CultureSlaveId");
                string msg = String.Format("{0}={1}: {2}", txtSlaveId, slaveAddress.ToString(), exc.Message);
                // mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, msg);
                _ihtDevices.SetCommunicError((int)slaveAddress);
            }
            finally
            {
                mutexModbusMaster.Release();
            }

            return datas;
        }



        #region Read_...
        /// <summary>
        /// Adress-Bereiche auslesen
        /// </summary>
        internal async Task<bool> Read_AddrAreasAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_AddrAreasAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// Geraete-Info auslesen 
        /// </summary>
        internal async Task<bool> Read_DeviceInfoAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_DeviceInfo, ihtModbusData.SetDeviceInfoData).ConfigureAwait(false);
        }

        /// <summary>
        /// Technologie-Parameter Const. auslesen 
        /// </summary>
        internal async Task<bool> Read_TechnologyConstAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_TechnologyConst, ihtModbusData.SetTechnologyConstData).ConfigureAwait(false);
        }

        /// <summary>
        /// Process-Parameter Const. auslesen 
        /// </summary>
        internal async Task<bool> Read_ProcessConstAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ProcessConst, ihtModbusData.SetProcessConstData).ConfigureAwait(false);
        }

        /// <summary>
        /// Config-Parameter Const. auslesen 
        /// </summary>
        internal async Task<bool> Read_ConfigConstAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ConfigConst, ihtModbusData.SetConfigConstData).ConfigureAwait(false);
        }

        /// <summary>
        /// Sevice-Parameter Const. auslesen
        /// </summary>
        internal async Task<bool> Read_ServiceConstAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ServiceConst, ihtModbusData.SetServiceConstData).ConfigureAwait(false);
        }

        /// <summary>
        /// Technologie-Parameter Dyn. auslesen
        /// </summary>
        internal async Task<bool> Read_TechnologyDynAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_TechnologyDyn, ihtModbusData.SetTechnologyDynData).ConfigureAwait(false);
        }

        /// <summary>
        /// Process-Parameter Dyn. auslesen
        /// </summary>
        internal async Task<bool> Read_ProcessDynAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ProcessDyn, ihtModbusData.SetProcessDynData).ConfigureAwait(false);
        }

        /// <summary>
        /// Config-Parameter Dyn. auslesen 
        /// </summary>
        internal async Task<bool> Read_ConfigDynAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ConfigDyn, ihtModbusData.SetConfigDynData).ConfigureAwait(false);
        }

        /// <summary>
        /// Sevice-Parameter Dyn. auslesen
        /// </summary>
        internal async Task<bool> Read_ServiceDynAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ServiceDyn, ihtModbusData.SetServiceDynData).ConfigureAwait(false);
        }

        /// <summary>
        /// Process-Info auslesen
        /// </summary>
        internal async Task<bool> Read_ProcessInfoAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_ProcessInfo, ihtModbusData.SetProcInfoData).ConfigureAwait(false);
        }

        /// <summary>
        /// Cmd-Exec. auslesen
        /// </summary>
        internal async Task<bool> Read_CmdExecAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_CmdExec, ihtModbusData.SetCmdExecData).ConfigureAwait(false);
        }

        /// <summary>
        /// Setup-Exec. auslesen
        /// </summary>
        internal async Task<bool> Read_SetupExecAsync(IhtModbusData ihtModbusData)
        {
            return await Rd_DataAsync(ihtModbusData, ihtModbusData.GetAddrInfo_SetupExec, ihtModbusData.SetSetupExecData).ConfigureAwait(false);
        }
        #endregion // Read_...

        internal async Task<bool> Rd_DataAsync(IhtModbusData ihtModbusData, GetAddrInfoDelegate addrInfoDelegate, SetValuesDelegate setValuesDelegate)
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
                    _modbusMaster.WriteMultipleRegisters(slaveAddress, startAddress, u16Registers);
                }
                ihtModbusResult.Result = true;
                _ihtDevices.ClrCommunicError((int)slaveAddress);
            }
            catch (Exception exc)
            {
                /*
                string txtSlaveId = CultureResources.GetString("_CultureSlaveId");
                string msg = String.Format("{0}={1}: {2}", txtSlaveId, slaveAddress.ToString(), exc.Message);
                mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, msg);
                */
                _ihtDevices.SetCommunicError((int)slaveAddress);
            }
            finally
            {
                mutexModbusMaster.Release();
            }
        }

    }
}
