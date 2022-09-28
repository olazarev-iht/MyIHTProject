using SharedComponents;
using SharedComponents.IhtData;
using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace SharedComponents.IhtDev
{
    public class IhtDevice : INotifyPropertyChanged
    {
        static public readonly int ErrorCodeCommunic = 100;

        #region // INotifyPropertyChanged
        // IsError  
        private bool _isError { get; set; }
        public bool IsError
        {
            get { return _isError; }
            set { _isError = value; RaisePropertyChanged("IsError"); }
        }
        // IsWarning
        private bool isWarning { get; set; }
        public bool IsWarning
        {
            get { return isWarning; }
            set { isWarning = value; RaisePropertyChanged("IsWarning"); }
        }
        // IsOk
        private bool _isOk { get; set; }
        public bool IsOk
        {
            get { return _isOk; }
            set { _isOk = value; RaisePropertyChanged("IsOk"); }
        }
        // IsConnected  
        private bool _isConnected { get; set; }
        public bool IsConnected
        {
            get { return _isConnected; }
            set { _isConnected = value; RaisePropertyChanged("IsConnected"); }
        }
        // IsEnabled
        private bool _isEnabledChbx { get; set; }
        public bool IsEnabledChbx
        {
            get { return _isEnabledChbx; }
            set { _isEnabledChbx = value; RaisePropertyChanged("IsEnabledChbx"); }
        }
        // IsEnabledMainControl
        private bool _isEnabledMainControl { get; set; }
        public bool IsEnabledMainControl
        {
            get { return _isEnabledMainControl; }
            set {
                _isEnabledMainControl = value; 
                //if (IsTorchDisabled)
                //{
                //    _isEnabledMainControl = false;
                //}
                //else
                //{
                //    _isEnabledMainControl = value;
                //    _isOnLast = value;
                //}
                RaisePropertyChanged("IsEnabledMainControl"); 
            }
        }
        // IsVisible
        private bool _isVisible { get; set; }
        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; RaisePropertyChanged("IsVisible"); }
        }
        // IsTorchDisabled
        private bool _isTorchDisabled { get; set; }
        public bool IsTorchDisabled
        {
            get
            {
                //if (dataProcessInfo != null)
                //{
                //    _isTorchDisabled = dataProcessInfo.IsInpTorchDisabled;
                //}

                return _isTorchDisabled;
            }
            set
            {
                
                if (value)
                {
                    IsOn = false;
                    IsEnabledOn = false;
                    IsEnabledMainControl = false;
                }
                else
                {
                    //IsEnabledOn = IsEnabledOnLast;
                    //IsOn = IsEnabledOn;

                    IsEnabledOn = true;
                    IsOn = true;

                    if (_isTorchDisabled)
                        IsEnabledMainControl = true;
                    // we do not change here IsEnabledMainControl !!!
                }

                _isTorchDisabled = value;
                RaisePropertyChanged("IsTorchDisabled");
            }
        }
        // IsOn  
        private bool _isOnLast { get; set; }
        private bool _isOn { get; set; }
        public bool IsOn
        {
            get { return _isOn; }
            set
            {
                if (IsTorchDisabled)
                {
                    _isOn = false;
                }
                else
                {
                    _isOn = value;
                    _isOnLast = value;
                }
                RaisePropertyChanged("IsOn");
            }
        }
        // IsCheckedTorch  
        private bool _isCheckedTorch { get; set; }
        public bool IsCheckedTorch
        {
            get { return _isCheckedTorch; }
            set { _isCheckedTorch = value; RaisePropertyChanged("IsCheckedTorch"); }
        }
        // IsEnabledOnLast  
        private bool _isEnabledOnLast { get; set; }
        public bool IsEnabledOnLast
        {
            get { return _isEnabledOnLast; }
            set { _isEnabledOnLast = value; RaisePropertyChanged("IsEnabledOnLast"); }
        }
        // IsEnabledOn  
        private bool _isEnabledOn { get; set; }
        public bool IsEnabledOn
        {
            get { return _isEnabledOn; }
            set
            {
                if (IsTorchDisabled)
                {
                    _isEnabledOn = false;
                }
                else
                {
                    _isEnabledOn = value;
                    IsEnabledOnLast = value;
                }
                RaisePropertyChanged("IsEnabledOn");
            }
        }
        // IsWrongTorchType
        private bool _isWrongTorchType { get; set; }
        public bool IsWrongTorchType
        {
            get { return _isWrongTorchType; }
            set { _isWrongTorchType = value; RaisePropertyChanged("IsWrongTorchType"); }
        }
        // IsFwUpdate
        private bool _isFwUpdate { get; set; }
        public bool IsFwUpdate
        {
            get { return _isFwUpdate; }
            set { _isFwUpdate = value; RaisePropertyChanged("IsFwUpdate"); }
        }
        // IsFwSpecial
        private bool _isFwSpecial { get; set; }
        public bool IsFwSpecial
        {
            get { return _isFwSpecial; }
            set { _isFwSpecial = value; RaisePropertyChanged("IsFwSpecial"); }
        }
        // IsCommunicError
        private bool _isCommunicError { get; set; }
        public bool IsCommunicError
        {
            get { return _isCommunicError; }
            set
            {
                _isCommunicError = value;
                if (dataProcessInfo != null)
                {
                    dataProcessInfo.IsCommunicError = value;
                }
                RaisePropertyChanged("IsCommunicError");
            }
        }
        // SlaveId  
        private int _slaveId { get; set; }
        public int SlaveId
        {
            get { return _slaveId; }
            set { _slaveId = value; RaisePropertyChanged("SlaveId"); }
        }
        // DeviceNumber
        private int _deviceNumber { get; set; }
        public int DeviceNumber
        {
            get { return _deviceNumber; }
            set { _deviceNumber = value; RaisePropertyChanged("DeviceNumber"); }
        }

        // Helper-Methode, um nicht in jedem Set-Accessor zu prüfen, ob PropertyRaisePropertyChanged!=null
        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        #endregion // INotifyPropertyChanged


        public void IsEnabledChangedHandler(object? sender, PropertyChangedEventArgs eventArgs)
        {
            var ihtDevice = sender as IhtDevice;

            if (ihtDevice != null)
            {
                var deviceNum = ihtDevice.DeviceNumber;

                if (deviceNum > 0)
                {
                    if (eventArgs.PropertyName == "IsVisible")
                    {
                        // IsVisible switched to true
                        if (ihtDevice.IsVisible)
                        {
                            IhtDevices.ihtDevices.ToList().ForEach(kvp =>
                            {
                                if (kvp.Value.DeviceNumber > deviceNum)
                                {
                                    kvp.Value.IsEnabledChbx = false;
                                }
                                if (kvp.Value.DeviceNumber == deviceNum + 1)
                                {
                                    kvp.Value.IsEnabledChbx = true;
                                }
                            });
                        }
                        else
                        {
                            IhtDevices.ihtDevices.ToList().ForEach(kvp =>
                            {
                                if (kvp.Value.DeviceNumber > deviceNum)
                                {
                                    kvp.Value.IsVisible = false;
                                    kvp.Value.IsEnabledChbx = false;
                                }
                            });
                        }
                    }

                    if (eventArgs.PropertyName == "IsEnabledMainControl")
                    {
                        //if (ihtDevice.IsCheckedTorch && !ihtDevice.IsEnabledMainControl)
                        //{
                        //    var firstAvailableDevice = IhtDevices.ihtDevices.ToList().OrderBy(kvp => kvp.Value.DeviceNumber)
                        //        .FirstOrDefault(kvp => kvp.Value.IsEnabledMainControl && kvp.Value.IsConnected).Value.IsCheckedTorch = true;
                        //}
                    }
                }
            }
        }


        private DataProcessInfo? _dataProcessInfo = null;
        public DataProcessInfo? dataProcessInfo {

            get {
                if (_dataProcessInfo == null)
                    _dataProcessInfo = _provider?.GetService<DataProcessInfo>();
                return _dataProcessInfo;
            }

            private set => _dataProcessInfo = value;
        }
        public DataDeviceInfo dataDeviceInfo { get; private set; } = new DataDeviceInfo();
        public DataParamConstTechnology dataParamConstTechnology { get; private set; } = new DataParamConstTechnology();
        public DataParamDynTechnology dataParamDynTechnology { get; private set; } = new DataParamDynTechnology();
        public DataParamConstProcess dataParamConstProcess { get; private set; } = new DataParamConstProcess();
        public DataParamDynProcess dataParamDynProcess { get; private set; } = new DataParamDynProcess();
        public DataParamConstConfig dataParamConstConfig { get; private set; } = new DataParamConstConfig();
        public DataParamDynConfig dataParamDynConfig { get; private set; } = new DataParamDynConfig();
        public DataParamConstService dataParamConstService { get; private set; } = new DataParamConstService();
        public DataParamDynService dataParamDynService { get; private set; } = new DataParamDynService();
        public DataSetupExecution dataSetupExecution { get; private set; } = new DataSetupExecution();
        public DataCmdExecution dataCmdExecution { get; private set; } = new DataCmdExecution();

        public ErrorCodeLables errorCodeLabels = new ErrorCodeLables();

        /// <summary>
        /// Konstruktor
        /// </summary>

        static IServiceProvider _provider;
        public IhtDevice(IServiceProvider provider)
        {
            _provider = provider ??
               throw new ArgumentNullException($"{nameof(provider)}");

            PropertyChanged += IsEnabledChangedHandler;
        }

        public void SetData(IhtModbusCommunic.SlaveId _slaveId,
                            IhtDevices.DeviceNumber _eDeviceNubmer
                            //DataDeviceInfo _dataDeviceInfo,
                            //DataProcessInfo _dataProcessInfo,
                            //DataParamConstTechnology _dataParamConstTechnology,
                            //DataParamDynTechnology _dataParamDynTechnology,
                            //DataParamConstProcess _dataParamConstProcess,
                            //DataParamDynProcess _dataParamDynProcess,
                            //DataParamConstConfig _dataParamConstConfig,
                            //DataParamDynConfig _dataParamDynConfig,
                            //DataParamConstService _dataParamConstService,
                            //DataParamDynService _dataParamDynService,
                            //DataSetupExecution _dataSetupExecution,
                            //DataCmdExecution _dataCmdExecution
                           )
        {
            SlaveId = (int)_slaveId;
            DeviceNumber = (int)_eDeviceNubmer;

            //dataDeviceInfo = _dataDeviceInfo;
            //dataProcessInfo = _dataProcessInfo;
            //dataParamConstTechnology = _dataParamConstTechnology;
            //dataParamDynTechnology = _dataParamDynTechnology;
            //dataParamConstProcess = _dataParamConstProcess;
            //dataParamDynProcess = _dataParamDynProcess;
            //dataParamConstConfig = _dataParamConstConfig;
            //dataParamDynConfig = _dataParamDynConfig;
            //dataParamConstService = _dataParamConstService;
            //dataParamDynService = _dataParamDynService;
            //dataSetupExecution = _dataSetupExecution;
            //dataCmdExecution = _dataCmdExecution;

            // Slave_ID auf den Process-Info's setzen
            if (dataProcessInfo != null)
            {
                dataProcessInfo.SlaveId = SlaveId;
            }
        }

        /// <summary>
        /// Slave-Id Bit afragen
        /// </summary>
        internal UInt16 GetSlaveIdBit()
        {
            return (UInt16)(1 << (SlaveId - (int)IhtModbusCommunic.SlaveId.Id_Default));
        }

        #region Tables
        /// <summary>
        /// Error-Code Labels setzen
        /// </summary>
        internal void SetErrorCodeLabels(ErrorCodeLables _errorCodeLables)
        {
            errorCodeLabels = _errorCodeLables;
        }

        /// <summary>
        /// Error-Code Label abfragen
        /// </summary>
        internal string GetErrorCodeLabel(int errorCode)
        {
            return errorCodeLabels.GetErrorCodeLabel(errorCode);
        }
        #endregion // Tables

        #region UpdateDataParamConst...
        /// <summary>
        /// Data Device-Info aktualisieren
        /// </summary>
        internal void UpdateDataDeviceInfo(IhtModbusData _modbusData)
        {
            dataDeviceInfo.UpdateDatas(_modbusData);
        }

        /// <summary>
        /// Data Technologie-Parameter Const. aktualisieren
        /// </summary>
        internal void UpdateDataParamConstTechnology(IhtModbusData _modbusData)
        {
            dataParamConstTechnology.UpdateDatas(_modbusData);
        }

        /// <summary>
        /// Data Process-Parameter Const. aktualisieren
        /// </summary>
        internal void UpdateDataParamConstProcess(IhtModbusData ihtModbusData)
        {
            dataParamConstProcess.UpdateDatas(ihtModbusData);
        }
        /// <summary>
        /// Data Config-Parameter Const. aktualisieren
        /// </summary>
        internal void UpdateDataParamConstConfig(IhtModbusData ihtModbusData)
        {
            dataParamConstConfig.UpdateDatas(ihtModbusData);
        }

        /// <summary>
        /// Data Service-Parameter Const. aktualisieren
        /// </summary>
        internal void UpdateDataParamConstService(IhtModbusData ihtModbusData)
        {
            dataParamConstService.UpdateDatas(ihtModbusData);
        }
        #endregion // UpdateDataParamConst...


        #region UpdateDataParam...
        /// <summary>
        /// Data Technologie-Parameter Dyn. aktualisieren
        /// </summary>
        internal void UpdateDataParamDynTechnology(IhtModbusData _modbusData)
        {
            dataParamDynTechnology.UpdateDatas(_modbusData);
        }

        /// <summary>
        /// Data Process-Parameter Dyn. aktualisieren
        /// </summary>
        internal void UpdateParamDynProcess(IhtModbusData ihtModbusData)
        {
            dataParamDynProcess.UpdateDatas(ihtModbusData);
        }

        /// <summary>
        /// Data Config-Parameter Dyn. aktualisieren
        /// </summary>
        internal void UpdateParamDynConfig(IhtModbusData ihtModbusData)
        {
            dataParamDynConfig.UpdateDatas(ihtModbusData);
        }

        /// <summary>
        /// Data Service-Parameter Dyn. aktualisieren
        /// </summary>
        internal void UpdateParamDynService(IhtModbusData ihtModbusData)
        {
            dataParamDynService.UpdateDatas(ihtModbusData);
        }

        /// <summary>
        /// Data  ProcessInfo aktualisieren
        /// </summary>
        internal void UpdateDataProcessInfo(IhtModbusData _modbusData)
        {
            dataProcessInfo.UpdateDatas(_modbusData);
        }

        /// <summary>
        /// Data  ProcessInfo aktualisieren
        /// </summary>
        internal void UpdateDataSetupExecution(IhtModbusData _modbusData)
        {
            dataSetupExecution.UpdateDatas(_modbusData);
        }

        internal void UpdateCmdExec(IhtModbusData _modbusData)
        {
            dataCmdExecution.UpdateDatas(_modbusData);
        }
        #endregion // UpdateDataParam...

        /*
        /// <summary>
        /// Alle Geräte- Daten/Parameter aktualisieren
        /// </summary>
        internal void UpdateDatas(IhtModbus.IhtModbusData _modbusData)
        {
          UpdateDataParamConstTechnology(_modbusData);
          UpdateDataParamDynTechnology(_modbusData);

          UpdateDataParamConstProcess(_modbusData);
          UpdateDataParamDynProcess(_modbusData);

          UpdateDataParamConstConfig(_modbusData);
          UpdateDataParamDynConfig(_modbusData);

          UpdateDataParamConstService(_modbusData);
          UpdateDataParamDynService(_modbusData);

          UpdateDataProcessInfo(_modbusData);
        }
    */
        #region Background
        /// <summary>
        /// Status-Hintergrund für Fehler setzen/loeschen
        /// </summary>
        internal void SetStatusErrorBackground()
        {
            IsError = true;
        }
        internal void ClrStatusErrorBackground()
        {
            IsError = false;
        }

        /// <summary>
        /// Status-Hintergrund für Warnung setzen/loeschen
        /// </summary>
        internal void SetStatusWarningBackground()
        {
            IsWarning = true;
        }
        internal void ClrStatusWarningBackground()
        {
            IsWarning = false;
        }

        /// <summary>
        /// Status-Hintergrund für Verbunden setzen/loeschen
        /// </summary>
        internal void SetStatusOkBackground()
        {
            IsOk = true;
        }
        internal void ClrStatusOkBackground()
        {
            IsOk = false;
        }

        /// <summary>
        /// Alle Status-Hintergrund loeschen
        /// </summary>
        internal void ClrStatusBackground()
        {
            IsError = false;
            IsWarning = false;
            IsOk = false;
        }

        /// <summary>
        /// PartNo abfragen
        /// </summary>
        internal int GetPartNo()
        {
            return dataDeviceInfo.PartNo;
        }
        #endregion // Background

    }

}
