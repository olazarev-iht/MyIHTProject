using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.Services.APCCommunicServices;
using SharedComponents.Services.APCHardwareManagers;
using IhtApcWebServer.Services.APCWorkerService;
using SharedComponents.IhtModbus;
using SharedComponents.IhtDev;
using SharedComponents.IhtMsg;

namespace IhtApcWebServer.Services.APCCommunic
{
    public class APCCommunicManager : ICommunicService
    {
        IhtDevices _ihtDevices;
        IhtModbusCommunic _ihtModbusCommunic;
        IhtModbusCommunicData _ihtModbusCommunicData;
        IParameterDataInfoManager _parameterDataInfoManager;
        APCWorkerBackgroundService _apcWorkerBackgroundService;

        private int _isRobot = 0;
        //TODO: implement with command line
        //if (ihtCmdLineParams.GetParam(IhtCmdLineParams.IdNo.Robot, ref _isRobot))
        //{
        //    IsRobot = _isRobot > 0;
        //    if (IsRobot)
        //    {
        //    }
        //}
        public bool IsRobot
        {
            get{
                return _isRobot > 0;
            }
        }

        public APCCommunicManager(
            IhtDevices ihtDevices,
            IhtModbusCommunic ihtModbusCommunic, 
            IhtModbusCommunicData ihtModbusCommunicData,
            IParameterDataInfoManager parameterDataInfoManager,
            APCWorkerBackgroundService apcWorkerBackgroundService)
        {
            _ihtDevices = ihtDevices ??
               throw new ArgumentNullException($"{nameof(ihtDevices)}");

            _ihtModbusCommunic = ihtModbusCommunic ??
               throw new ArgumentNullException($"{nameof(ihtModbusCommunic)}");

            _ihtModbusCommunicData = ihtModbusCommunicData ??
               throw new ArgumentNullException($"{nameof(ihtModbusCommunicData)}");

            _parameterDataInfoManager = parameterDataInfoManager ??
               throw new ArgumentNullException($"{nameof(parameterDataInfoManager)}");

            _apcWorkerBackgroundService = apcWorkerBackgroundService ??
               throw new ArgumentNullException($"{nameof(apcWorkerBackgroundService)}");

        }

        //TODO: Temp Init() func - delete when config settings will be implemented
        public async Task Init(string nameComPort, bool isSimulation, bool performResetDevices)
        {
            _ihtModbusCommunicData.ComPort = nameComPort;
            _ihtModbusCommunicData.IsExecReset = performResetDevices;
            _ihtModbusCommunic.Init(isSimulation, _ihtModbusCommunicData);

            await ConnectAsync();
        }

        //TODO: call ConnectAsync() func directly
        public async Task ConnectAsync()
        {
            await CmdConnectExecAsync();
        }

        private async Task CmdConnectExecAsync()
        {
            //TODO: implement ?
            //_mainWndHlp.ClrStatusMsgs();

            //ClrImageButStatusMsg();

            //commonDataControl.MainAereaIsEnabled = false;
            //eventDisplay.Visibility = Visibility.Visible;
            //eventDisplay.VisibilityLoadAnimation = Visibility.Visible;
            //eventDisplay.VisibilityCloseButton = Visibility.Collapsed;
            //eventDisplay.TextLoadingAnimation = EventDisplay.DefaultTextLoadAnimation;
            //eventDisplay.FontSizeLoadingAnimation = EventDisplay.DefaultFontSizeLoadAnimation;

            //TODO: implement ?
            //StopBackgroundWorker();
            if (_apcWorkerBackgroundService != null && APCWorkerBackgroundService._stoppingCts != null)
            {
                await _apcWorkerBackgroundService.StopAsync(APCWorkerBackgroundService._stoppingCts.Token);
            }
            // Eingeschaltete Geräte merken
            UInt16 u16OnSlaveIdBits = (UInt16)IhtModbusCommunic.CurrOnSlaveBits;

            // Alle Geräte in den Default-Zustand versetzen
            _ihtDevices.SetDefaults();

            //SetStatusMsg(IhtMsgLog.Info.Info, AssemblyInfo.AssemblyTitle);
            //SetStatusMsg(IhtMsgLog.Info.Info, $"Version: {AssemblyInfo.AssemblyVersion}");
            //SetStatusMsg(IhtMsgLog.Info.None, "");

            // TODO: implement    
            //if (_machineCommunic.ApcFolderName.Length > 0)
            //{
            //    SetStatusMsg(IhtMsgLog.Info.Info, $"APC-Name: {_machineCommunic.ApcFolderName}");
            //    SetStatusMsg(IhtMsgLog.Info.None, "");
            //}

            // MainAerea disablen solange der Verbindingsaufbau läift     
            //mainWndHlp.mainWnd.dockPanel_mainAerea.IsEnabled = false;
            //commonDataControl.MainAereaIsEnabled = false;

            // MQTT
            // TODO implement
            //await MqttConnect();

            // Verbindung zu den Geräten asyncron ausführen
            //SetStatusMsgCultureId(IhtMsgLog.Info.Info, "_CultureMsgLogRecognizingTorches");
            IhtMsgInfo msgInfo = new IhtMsgInfo();
            bool blResult = await _ihtModbusCommunic.ConnectAsync(msgInfo, u16OnSlaveIdBits, IsRobot);
            // Verbindungs-Resultat auswerten
            bool blEnable = blResult;
            if (blResult)
            {
                ArrayList SlaveIds = _ihtDevices.GetVisibleSlaveIds();
                foreach (int slaveId in SlaveIds)
                {
                    IhtModbusData modbusData = _ihtModbusCommunic.GetData(slaveId);
                    if (modbusData == null || modbusData.Connected == false)
                    {
                        blEnable = false;
                    }
                    else
                    {
                        // Gerät als verbunden setzen
                        _ihtDevices.SetConnected(slaveId);
                    }
                }

                // Fill Dyn Params DB
                var connectedDevicesAmount = _ihtDevices.GetConnectedDevices().Count;
                await _parameterDataInfoManager.UpdateAPCHardwareDataAsync(CancellationToken.None, connectedDevicesAmount);
            }
            // Info setzen, ob mindestens ein Gerät verbunden ist
            //commonDataControl.IsConnecteds = _ihtDevices.IsConneteds();

            // Alle Geräte die verbunden sind enablen
            _ihtDevices.EnableConnecteds(u16OnSlaveIdBits);

            if (msgInfo.msgText != null)
            {
                //SetStatusMsg(IhtMsgLog.Info.Error, msgInfo.msgText);
            }
            //      commonDataControl.MainAereaIsEnabled = blEnable;
            //eventDisplay.VisibilityLoadAnimation = Visibility.Collapsed;
            //blEnable = blEnable && ButStatusMsgError != IhtMsgLog.Info.Error && ButStatusMsgWarning != IhtMsgLog.Info.Warning;
            //eventDisplay.VisibilityCloseButton = (blEnable) ? Visibility.Collapsed : Visibility.Visible;
            if (blResult)
            {
                //eventDisplay.Visibility = Visibility.Hidden;
                //CommandManager.InvalidateRequerySuggested();
                //----> StartBackgroundWorker();
                if (_apcWorkerBackgroundService != null)
                {
                    await _apcWorkerBackgroundService.StartAsync(new CancellationToken());
                }
                //commonDataControl.MainAereaIsEnabled = blEnable;
            }
        }
    }
}
