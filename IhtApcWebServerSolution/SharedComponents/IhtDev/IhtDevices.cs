using SharedComponents;
using SharedComponents.IhtData;
using SharedComponents.Helpers;
using SharedComponents.IhtModbus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace SharedComponents.IhtDev
{
    public class IhtDevices : INotifyPropertyChanged
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

        public enum PressureUnit
        {
            IsPressureBar,
            IsPressurePsi
        }

        public enum LengthUnit
        {
            IsUnitMm,
            IsUnitInch,
            IsUnitInchFractional
        }

        public enum UnitType
        {
            none, bar, psi, mm, inch
        }

        public enum TorchType
        {
            Invalid = -1,
            [Description("Propan")]
            Propane = 0,
            [Description("Acetylene")]
            Acetylane = 1,
            [Description("NaturalGas")]
            NaturalGas = 2
        }

        public enum ErrorCode
        {
            Code_07 = 7,
            Code_08 = 8
        }

        #region INotifyPropertyChanged
        // PasswordLevel_Software
        private int _passwordLevel_Software { get; set; }
        public int PasswordLevel_Software
        {
            get { return _passwordLevel_Software; }
            set
            {
                _passwordLevel_Software = value;
                bool PasswordValid = (_passwordLevel_Software == (int)PasswordLevel_SW.Level_3) ? true : false;
                IhtModbusUnitParam.IsPasswordValid = PasswordValid;
                IhtModbusUnitParam.PasswordLevel_Software = value;
                IhtModbusDescriptionParamConst.IsPasswordValid = PasswordValid;
                IhtModbusDescriptionParamConst.PasswordLevel_Software = value;
                IhtModbusDescriptionParamDyn.IsPasswordValid = PasswordValid;
                IhtModbusDescriptionParamDyn.PasswordLevel_Software = value;
                RealMultiplierParam.IsPasswordValid = PasswordValid;
                RealMultiplierParam.PasswordLevel_Software = value;
                IhtModbusRealMultiplierParam.IsPasswordValid = PasswordValid;
                IhtModbusRealMultiplierParam.PasswordLevel_Software = value;
                RaisePropertyChanged("PasswordLevel_Software");
            }
        }

        // IsCutDataSetEditable
        private bool _isCutDataSetEditable { get; set; }
        public bool IsCutDataSetEditable
        {
            get { return _isCutDataSetEditable; }
            set { _isCutDataSetEditable = value; RaisePropertyChanged("IsCutDataSetEditable"); }
        }

        // IsFlameOnAtProcessEndCommon
        private bool _isFlameOnAtProcessEndCommon { get; set; }
        public bool IsFlameOnAtProcessEndCommon
        {
            get { return _isFlameOnAtProcessEndCommon; }
            set { _isFlameOnAtProcessEndCommon = value; RaisePropertyChanged("IsFlameOnAtProcessEndCommon"); }
        }

        // IsClearenceCtrlManualCommon
        private bool _isClearenceCtrlManualCommon { get; set; }
        public bool IsClearenceCtrlManualCommon
        {
            get { return _isClearenceCtrlManualCommon; }
            set { _isClearenceCtrlManualCommon = value; RaisePropertyChanged("IsClearenceCtrlManualCommon"); }
        }

        // IsClearenceCtrlOffCommon
        private bool _isClearenceCtrlOffCommon { get; set; }
        public bool IsClearenceCtrlOffCommon
        {
            get { return _isClearenceCtrlOffCommon; }
            set { _isClearenceCtrlOffCommon = value; RaisePropertyChanged("IsClearenceCtrlOffCommon"); }
        }

        // IsPropane
        private bool _isPropane { get; set; }
        public bool IsPropane
        {
            get { return _isPropane; }
            set { _isPropane = value; RaisePropertyChanged("IsPropane"); }
        }

        // IsAcetylane
        private bool _isAcetylane { get; set; }
        public bool IsAcetylane
        {
            get { return _isAcetylane; }
            set { _isAcetylane = value; RaisePropertyChanged("IsAcetylane"); }
        }

        // IsNaturalGas
        private bool _isNaturalGas { get; set; }
        public bool IsNaturalGas
        {
            get { return _isNaturalGas; }
            set { _isNaturalGas = value; RaisePropertyChanged("IsNaturalGas"); }
        }

        // IsPressureBar
        private bool _isPressureBar { get; set; }
        public bool IsPressureBar
        {
            get { return _isPressureBar; }
            set { _isPressureBar = value; RaisePropertyChanged("IsPressureBar"); }
        }

        // IsPressurePsi
        private bool _isPressurePsi { get; set; }
        public bool IsPressurePsi
        {
            get { return _isPressurePsi; }
            set
            {
                _isPressurePsi = value;
                Units.IsPressurePsi = _isPressurePsi;
                RaisePropertyChanged("IsPressurePsi");
            }
        }

        // IsUnitMm
        private bool _isUnitMm { get; set; }
        public bool IsUnitMm
        {
            get { return _isUnitMm; }
            set { _isUnitMm = value; RaisePropertyChanged("IsUnitMm"); }
        }

        // IsUnitInch -> Anzeige z.B. 1,125
        private bool _isUnitInch { get; set; }
        public bool IsUnitInch
        {
            get { return _isUnitInch; }
            set
            {
                _isUnitInch = value;
                Units.IsUnitInch = _isUnitInch;
                RaisePropertyChanged("IsUnitInch");
            }
        }

        //private PressureUnit _currPressureUnit;
        public PressureUnit CurrPressureUnit { get; set; } = PressureUnit.IsPressureBar;

        public LengthUnit CurrLengthUnit { get; set; } = LengthUnit.IsUnitMm;

        private TorchType _torchTypeSetup;
        public TorchType TorchTypeSetup
        {
            get
            {
                return _torchTypeSetup;
            }

            set
            {
                _torchTypeSetup = value;

                //switch (TorchTypeSetup)
                //{
                //    case TorchType.Propane:
                //        IsPropane = true;
                //        IsAcetylane = false;
                //        IsNaturalGas = false;
                //        break;
                //    case TorchType.Acetylane:
                //        IsPropane = false;
                //        IsAcetylane = true;
                //        IsNaturalGas = false;
                //        break;
                //    case TorchType.NaturalGas:
                //        IsPropane = false;
                //        IsAcetylane = false;
                //        IsNaturalGas = true;
                //        break;
                //    default:
                //        return;
                //}
            }
        }
        // IsUnitInchFractional -> Anzeige z.B. 1 1/8
        private bool _isUnitInchFractional { get; set; }
        public bool IsUnitInchFractional
        {
            get { return _isUnitInchFractional; }
            set
            {
                _isUnitInchFractional = value;
                Units.IsUnitInchFractional = _isUnitInchFractional;
                RaisePropertyChanged("IsUnitInchFractional");
            }
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

        private static IServiceProvider _provider;

        public IhtModbusCommunic ihtModbusCommunic; // { get { return IhtModbusCommunic.GetIhtModbusCommunic(); } }

        static private IhtDevices _ihtDevices_ = null;
        static public IhtDevices GetIhtDevices()
        {
            if (_ihtDevices_ == null)
            {
                _ihtDevices_ = _provider?.GetService<IhtDevices>(); //Application.Current.MainWindow.FindResource("ihtDevices") as IhtDevices;
            }
            return _ihtDevices_;
        }

        private static Dictionary<int, IhtDevice> _ihtDevicesDictionary_ = null;
        public static Dictionary<int, IhtDevice> ihtDevices
        {
            get
            {
                if (_ihtDevicesDictionary_ == null)
                {
                    CreateIhtDevices();
                }
                return _ihtDevicesDictionary_;
            }
        }

        private ErrorCodeLablesDevices errorCodeLablesDevices = new ErrorCodeLablesDevices();

        /// <summary>
        /// Konstruktor
        /// </summary>
        public IhtDevices(
            IServiceProvider provider,
            IhtModbusCommunic ihtModbusCommunic)
        {
            _provider = provider ??
               throw new ArgumentNullException($"{nameof(provider)}");

            this.ihtModbusCommunic = ihtModbusCommunic ??
               throw new ArgumentNullException($"{nameof(ihtModbusCommunic)}");
        }

        /// <summary>
        /// Geräte erzeugen
        /// </summary>
        private static void CreateIhtDevices()
        {
            _ihtDevicesDictionary_ = new Dictionary<int, IhtDevice>();
            var _ihtDevice = _provider?.GetService<IhtDevice>();
            //MainWindow _mainWindow = MainWindow.GetMainWindow();
            // Device 1
            _ihtDevice.DeviceNumber = (int)DeviceNumber.Device_01; //_mainWindow.FindResource("ihtDevice_1") as IhtDevice;
            _ihtDevice.SetData(IhtModbusCommunic.SlaveId.Id_11, 
                               IhtDevices.DeviceNumber.Device_01
                               //, new DataDeviceInfo(), new DataProcessInfo(), new DataParamConstTechnology(), 
                               //null, null, null, null, null, null, null, null, null
                               //(DataDeviceInfo)GetIhtDeviceDataModelByName("dataDeviceInfo_1"), //_mainWindow.FindResource("dataDeviceInfo_1"),
                               //(DataProcessInfo)GetIhtDeviceDataModelByName("dataProcessInfo_1"),
                               //(DataParamConstTechnology)GetIhtDeviceDataModelByName("dataParamConstTechnology_1"),
                               //(DataParamDynTechnology)GetIhtDeviceDataModelByName("dataParamDynTechnology_1"),
                               //(DataParamConstProcess)GetIhtDeviceDataModelByName("dataParamConstProcess_1"),
                               //(DataParamDynProcess)GetIhtDeviceDataModelByName("dataParamDynProcess_1"),
                               //(DataParamConstConfig)GetIhtDeviceDataModelByName("dataParamConstConfig_1"),
                               //(DataParamDynConfig)GetIhtDeviceDataModelByName("dataParamDynConfig_1"),
                               //(DataParamConstService)GetIhtDeviceDataModelByName("dataParamConstService_1"),
                               //(DataParamDynService)GetIhtDeviceDataModelByName("dataParamDynService_1"),
                               //(DataSetupExecution)GetIhtDeviceDataModelByName("dataSetupExecution_1"),
                               //(DataCmdExecution)GetIhtDeviceDataModelByName("dataCmdExecution_1")
                              );
            _ihtDevice.IsVisible = true;
            _ihtDevice.IsEnabledChbx = false;
            _ihtDevice.IsCheckedTorch = true;
            _ihtDevicesDictionary_.Add(_ihtDevice.SlaveId /*_mainWindow.mainCtrl_1.SlaveId*/, _ihtDevice);
            // Device 2
            _ihtDevice = _provider?.GetService<IhtDevice>();
            _ihtDevice.DeviceNumber = (int)DeviceNumber.Device_02;
            _ihtDevice.SetData(IhtModbusCommunic.SlaveId.Id_12, 
                               IhtDevices.DeviceNumber.Device_02
                               //, new DataDeviceInfo(), null, null, null, null, null, null, null, null, null, null, null
                               //(DataDeviceInfo)GetIhtDeviceDataModelByName("dataDeviceInfo_2"),
                               //(DataProcessInfo)GetIhtDeviceDataModelByName("dataProcessInfo_2"),
                               //(DataParamConstTechnology)GetIhtDeviceDataModelByName("dataParamConstTechnology_2"),
                               //(DataParamDynTechnology)GetIhtDeviceDataModelByName("dataParamDynTechnology_2"),
                               //(DataParamConstProcess)GetIhtDeviceDataModelByName("dataParamConstProcess_2"),
                               //(DataParamDynProcess)GetIhtDeviceDataModelByName("dataParamDynProcess_2"),
                               //(DataParamConstConfig)GetIhtDeviceDataModelByName("dataParamConstConfig_2"),
                               //(DataParamDynConfig)GetIhtDeviceDataModelByName("dataParamDynConfig_2"),
                               //(DataParamConstService)GetIhtDeviceDataModelByName("dataParamConstService_2"),
                               //(DataParamDynService)GetIhtDeviceDataModelByName("dataParamDynService_2"),
                               //(DataSetupExecution)GetIhtDeviceDataModelByName("dataSetupExecution_2"),
                               //(DataCmdExecution)GetIhtDeviceDataModelByName("dataCmdExecution_2")
                              );
            _ihtDevicesDictionary_.Add(_ihtDevice.SlaveId /*_mainWindow.mainCtrl_1.SlaveId*/, _ihtDevice);
            _ihtDevice.IsEnabledChbx = true;
            // Device 3
            _ihtDevice = _provider?.GetService<IhtDevice>();
            _ihtDevice.DeviceNumber = (int)DeviceNumber.Device_03;
            _ihtDevice.SetData(IhtModbusCommunic.SlaveId.Id_13,
                               IhtDevices.DeviceNumber.Device_03
                               //, null, null, null, null, null, null, null, null, null, null, null, null
                               //(DataDeviceInfo)GetIhtDeviceDataModelByName("dataDeviceInfo_3"),
                               //(DataProcessInfo)GetIhtDeviceDataModelByName("dataProcessInfo_3"),
                               //(DataParamConstTechnology)GetIhtDeviceDataModelByName("dataParamConstTechnology_3"),
                               //(DataParamDynTechnology)GetIhtDeviceDataModelByName("dataParamDynTechnology_3"),
                               //(DataParamConstProcess)GetIhtDeviceDataModelByName("dataParamConstProcess_3"),
                               //(DataParamDynProcess)GetIhtDeviceDataModelByName("dataParamDynProcess_3"),
                               //(DataParamConstConfig)GetIhtDeviceDataModelByName("dataParamConstConfig_3"),
                               //(DataParamDynConfig)GetIhtDeviceDataModelByName("dataParamDynConfig_3"),
                               //(DataParamConstService)GetIhtDeviceDataModelByName("dataParamConstService_3"),
                               //(DataParamDynService)GetIhtDeviceDataModelByName("dataParamDynService_3"),
                               //(DataSetupExecution)GetIhtDeviceDataModelByName("dataSetupExecution_3"),
                               //(DataCmdExecution)GetIhtDeviceDataModelByName("dataCmdExecution_3")
                              );
            _ihtDevicesDictionary_.Add(_ihtDevice.SlaveId /*_mainWindow.mainCtrl_1.SlaveId*/, _ihtDevice);
            // Device 4
            _ihtDevice = _provider?.GetService<IhtDevice>();
            _ihtDevice.DeviceNumber = (int)DeviceNumber.Device_04;
            _ihtDevice.SetData(IhtModbusCommunic.SlaveId.Id_14,
                               IhtDevices.DeviceNumber.Device_04
                               //, null, null, null, null, null, null, null, null, null, null, null, null
                               //(DataDeviceInfo)GetIhtDeviceDataModelByName("dataDeviceInfo_4"),
                               //(DataProcessInfo)GetIhtDeviceDataModelByName("dataProcessInfo_4"),
                               //(DataParamConstTechnology)GetIhtDeviceDataModelByName("dataParamConstTechnology_4"),
                               //(DataParamDynTechnology)GetIhtDeviceDataModelByName("dataParamDynTechnology_4"),
                               //(DataParamConstProcess)GetIhtDeviceDataModelByName("dataParamConstProcess_4"),
                               //(DataParamDynProcess)GetIhtDeviceDataModelByName("dataParamDynProcess_4"),
                               //(DataParamConstConfig)GetIhtDeviceDataModelByName("dataParamConstConfig_4"),
                               //(DataParamDynConfig)GetIhtDeviceDataModelByName("dataParamDynConfig_4"),
                               //(DataParamConstService)GetIhtDeviceDataModelByName("dataParamConstService_4"),
                               //(DataParamDynService)GetIhtDeviceDataModelByName("dataParamDynService_4"),
                               //(DataSetupExecution)GetIhtDeviceDataModelByName("dataSetupExecution_4"),
                               //(DataCmdExecution)GetIhtDeviceDataModelByName("dataCmdExecution_4")
                              );
            _ihtDevicesDictionary_.Add(_ihtDevice.SlaveId /*_mainWindow.mainCtrl_1.SlaveId*/, _ihtDevice);
            // Device 5
            _ihtDevice = _provider?.GetService<IhtDevice>();
            _ihtDevice.DeviceNumber = (int)DeviceNumber.Device_05;
            _ihtDevice.SetData(IhtModbusCommunic.SlaveId.Id_15,
                               IhtDevices.DeviceNumber.Device_05
                               //, null, null, null, null, null, null, null, null, null, null, null, null
                               //(DataDeviceInfo)GetIhtDeviceDataModelByName("dataDeviceInfo_5"),
                               //(DataProcessInfo)GetIhtDeviceDataModelByName("dataProcessInfo_5"),
                               //(DataParamConstTechnology)GetIhtDeviceDataModelByName("dataParamConstTechnology_5"),
                               //(DataParamDynTechnology)GetIhtDeviceDataModelByName("dataParamDynTechnology_5"),
                               //(DataParamConstProcess)GetIhtDeviceDataModelByName("dataParamConstProcess_5"),
                               //(DataParamDynProcess)GetIhtDeviceDataModelByName("dataParamDynProcess_5"),
                               //(DataParamConstConfig)GetIhtDeviceDataModelByName("dataParamConstConfig_5"),
                               //(DataParamDynConfig)GetIhtDeviceDataModelByName("dataParamDynConfig_5"),
                               //(DataParamConstService)GetIhtDeviceDataModelByName("dataParamConstService_5"),
                               //(DataParamDynService)GetIhtDeviceDataModelByName("dataParamDynService_5"),
                               //(DataSetupExecution)GetIhtDeviceDataModelByName("dataSetupExecution_5"),
                               //(DataCmdExecution)GetIhtDeviceDataModelByName("dataCmdExecution_5")
                              );
            _ihtDevicesDictionary_.Add(_ihtDevice.SlaveId /*_mainWindow.mainCtrl_1.SlaveId*/, _ihtDevice);
            // Device 6
            _ihtDevice = _provider?.GetService<IhtDevice>();
            _ihtDevice.DeviceNumber = (int)DeviceNumber.Device_06;
            _ihtDevice.SetData(IhtModbusCommunic.SlaveId.Id_16,
                               IhtDevices.DeviceNumber.Device_06
                               //, null, null, null, null, null, null, null, null, null, null, null, null
                               //(DataDeviceInfo)GetIhtDeviceDataModelByName("dataDeviceInfo_6"),
                               //(DataProcessInfo)GetIhtDeviceDataModelByName("dataProcessInfo_6"),
                               //(DataParamConstTechnology)GetIhtDeviceDataModelByName("dataParamConstTechnology_6"),
                               //(DataParamDynTechnology)GetIhtDeviceDataModelByName("dataParamDynTechnology_6"),
                               //(DataParamConstProcess)GetIhtDeviceDataModelByName("dataParamConstProcess_6"),
                               //(DataParamDynProcess)GetIhtDeviceDataModelByName("dataParamDynProcess_6"),
                               //(DataParamConstConfig)GetIhtDeviceDataModelByName("dataParamConstConfig_6"),
                               //(DataParamDynConfig)GetIhtDeviceDataModelByName("dataParamDynConfig_6"),
                               //(DataParamConstService)GetIhtDeviceDataModelByName("dataParamConstService_6"),
                               //(DataParamDynService)GetIhtDeviceDataModelByName("dataParamDynService_6"),
                               //(DataSetupExecution)GetIhtDeviceDataModelByName("dataSetupExecution_6"),
                               //(DataCmdExecution)GetIhtDeviceDataModelByName("dataCmdExecution_6")
                              );
            _ihtDevicesDictionary_.Add(_ihtDevice.SlaveId /*_mainWindow.mainCtrl_1.SlaveId*/, _ihtDevice);
            // Device 7
            _ihtDevice = _provider?.GetService<IhtDevice>();
            _ihtDevice.DeviceNumber = (int)DeviceNumber.Device_07;
            _ihtDevice.SetData(IhtModbusCommunic.SlaveId.Id_17,
                               IhtDevices.DeviceNumber.Device_07
                               //, null, null, null, null, null, null, null, null, null, null, null, null
                               //(DataDeviceInfo)GetIhtDeviceDataModelByName("dataDeviceInfo_7"),
                               //(DataProcessInfo)GetIhtDeviceDataModelByName("dataProcessInfo_7"),
                               //(DataParamConstTechnology)GetIhtDeviceDataModelByName("dataParamConstTechnology_7"),
                               //(DataParamDynTechnology)GetIhtDeviceDataModelByName("dataParamDynTechnology_7"),
                               //(DataParamConstProcess)GetIhtDeviceDataModelByName("dataParamConstProcess_7"),
                               //(DataParamDynProcess)GetIhtDeviceDataModelByName("dataParamDynProcess_7"),
                               //(DataParamConstConfig)GetIhtDeviceDataModelByName("dataParamConstConfig_7"),
                               //(DataParamDynConfig)GetIhtDeviceDataModelByName("dataParamDynConfig_7"),
                               //(DataParamConstService)GetIhtDeviceDataModelByName("dataParamConstService_7"),
                               //(DataParamDynService)GetIhtDeviceDataModelByName("dataParamDynService_7"),
                               //(DataSetupExecution)GetIhtDeviceDataModelByName("dataSetupExecution_7"),
                               //(DataCmdExecution)GetIhtDeviceDataModelByName("dataCmdExecution_7")
                              );
            _ihtDevicesDictionary_.Add(_ihtDevice.SlaveId /*_mainWindow.mainCtrl_1.SlaveId*/, _ihtDevice);
            // Device 8
            _ihtDevice = _provider?.GetService<IhtDevice>();
            _ihtDevice.DeviceNumber = (int)DeviceNumber.Device_08;
            _ihtDevice.SetData(IhtModbusCommunic.SlaveId.Id_18,
                               IhtDevices.DeviceNumber.Device_08
                               //, null, null, null, null, null, null, null, null, null, null, null, null
                               //(DataDeviceInfo)GetIhtDeviceDataModelByName("dataDeviceInfo_8"),
                               //(DataProcessInfo)GetIhtDeviceDataModelByName("dataProcessInfo_8"),
                               //(DataParamConstTechnology)GetIhtDeviceDataModelByName("dataParamConstTechnology_8"),
                               //(DataParamDynTechnology)GetIhtDeviceDataModelByName("dataParamDynTechnology_8"),
                               //(DataParamConstProcess)GetIhtDeviceDataModelByName("dataParamConstProcess_8"),
                               //(DataParamDynProcess)GetIhtDeviceDataModelByName("dataParamDynProcess_8"),
                               //(DataParamConstConfig)GetIhtDeviceDataModelByName("dataParamConstConfig_8"),
                               //(DataParamDynConfig)GetIhtDeviceDataModelByName("dataParamDynConfig_8"),
                               //(DataParamConstService)GetIhtDeviceDataModelByName("dataParamConstService_8"),
                               //(DataParamDynService)GetIhtDeviceDataModelByName("dataParamDynService_8"),
                               //(DataSetupExecution)GetIhtDeviceDataModelByName("dataSetupExecution_8"),
                               //(DataCmdExecution)GetIhtDeviceDataModelByName("dataCmdExecution_8")
                              );
            _ihtDevicesDictionary_.Add(_ihtDevice.SlaveId /*_mainWindow.mainCtrl_1.SlaveId*/, _ihtDevice);
            // Device 9
            _ihtDevice = _provider?.GetService<IhtDevice>();
            _ihtDevice.DeviceNumber = (int)DeviceNumber.Device_09;
            _ihtDevice.SetData(IhtModbusCommunic.SlaveId.Id_19,
                               IhtDevices.DeviceNumber.Device_09
                               //, null, null, null, null, null, null, null, null, null, null, null, null
                               //(DataDeviceInfo)GetIhtDeviceDataModelByName("dataDeviceInfo_9"),
                               //(DataProcessInfo)GetIhtDeviceDataModelByName("dataProcessInfo_9"),
                               //(DataParamConstTechnology)GetIhtDeviceDataModelByName("dataParamConstTechnology_9"),
                               //(DataParamDynTechnology)GetIhtDeviceDataModelByName("dataParamDynTechnology_9"),
                               //(DataParamConstProcess)GetIhtDeviceDataModelByName("dataParamConstProcess_9"),
                               //(DataParamDynProcess)GetIhtDeviceDataModelByName("dataParamDynProcess_9"),
                               //(DataParamConstConfig)GetIhtDeviceDataModelByName("dataParamConstConfig_9"),
                               //(DataParamDynConfig)GetIhtDeviceDataModelByName("dataParamDynConfig_9"),
                               //(DataParamConstService)GetIhtDeviceDataModelByName("dataParamConstService_9"),
                               //(DataParamDynService)GetIhtDeviceDataModelByName("dataParamDynService_9"),
                               //(DataSetupExecution)GetIhtDeviceDataModelByName("dataSetupExecution_9"),
                               //(DataCmdExecution)GetIhtDeviceDataModelByName("dataCmdExecution_9")
                              );
            _ihtDevicesDictionary_.Add(_ihtDevice.SlaveId /*_mainWindow.mainCtrl_1.SlaveId*/, _ihtDevice);
            // Device 10
            _ihtDevice = _provider?.GetService<IhtDevice>();
            _ihtDevice.DeviceNumber = (int)DeviceNumber.Device_10;
            _ihtDevice.SetData(IhtModbusCommunic.SlaveId.Id_20,
                               IhtDevices.DeviceNumber.Device_10
                               //, null, null, null, null, null, null, null, null, null, null, null, null
                               //(DataDeviceInfo)GetIhtDeviceDataModelByName("dataDeviceInfo_10"),
                               //(DataProcessInfo)GetIhtDeviceDataModelByName("dataProcessInfo_10"),
                               //(DataParamConstTechnology)GetIhtDeviceDataModelByName("dataParamConstTechnology_10"),
                               //(DataParamDynTechnology)GetIhtDeviceDataModelByName("dataParamDynTechnology_10"),
                               //(DataParamConstProcess)GetIhtDeviceDataModelByName("dataParamConstProcess_10"),
                               //(DataParamDynProcess)GetIhtDeviceDataModelByName("dataParamDynProcess_10"),
                               //(DataParamConstConfig)GetIhtDeviceDataModelByName("dataParamConstConfig_10"),
                               //(DataParamDynConfig)GetIhtDeviceDataModelByName("dataParamDynConfig_10"),
                               //(DataParamConstService)GetIhtDeviceDataModelByName("dataParamConstService_10"),
                               //(DataParamDynService)GetIhtDeviceDataModelByName("dataParamDynService_10"),
                               //(DataSetupExecution)GetIhtDeviceDataModelByName("dataSetupExecution_10"),
                               //(DataCmdExecution)GetIhtDeviceDataModelByName("dataCmdExecution_10")
                              );
            _ihtDevicesDictionary_.Add(_ihtDevice.SlaveId /*_mainWindow.mainCtrl_1.SlaveId*/, _ihtDevice);
        }

        /// <summary>
        /// Abfragen ob Kommunikation gestartet ist
        /// </summary>
        public bool IsCommunicStarted()
        {
            return ihtModbusCommunic.IsStarted;
        }

        /// <summary>
        /// Alle Geräte abfragen
        /// </summary>
        public List<IhtDevice> GetDevices()
        {
            var _ihtDevices = new List<IhtDevice>();
            foreach (KeyValuePair<int, IhtDevice> kvp in ihtDevices)
            {
                IhtDevice _ihtDevice = kvp.Value;
                _ihtDevices.Add(_ihtDevice);
            }
            return _ihtDevices;
        }

        public List<IhtDevice> GetEnabledDevices()
        {
            var _ihtDevices = ihtDevices.Select(d => d.Value).Where(d => d.IsConnected && d.IsEnabledMainControl).ToList();

            return _ihtDevices;
        }

        /// <summary>
        /// Alle sichtbaren Geräte abfragen
        /// </summary>
        public ArrayList GetVisibleDevices()
        {
            ArrayList _ihtDevices = new ArrayList();
            foreach (KeyValuePair<int, IhtDevice> kvp in ihtDevices)
            {
                IhtDevice _ihtDevice = kvp.Value;
                if (!_ihtDevice.IsVisible)
                {
                    continue;
                }
                _ihtDevices.Add(_ihtDevice);
            }
            return _ihtDevices;
        }

        public ArrayList GetConnectedDevices()
        {
            ArrayList _ihtDevices = new ArrayList();
            foreach (KeyValuePair<int, IhtDevice> kvp in ihtDevices)
            {
                IhtDevice _ihtDevice = kvp.Value;
                if (!_ihtDevice.IsConnected)
                {
                    continue;
                }
                _ihtDevices.Add(_ihtDevice);
            }
            return _ihtDevices;
        }

        /// <summary>
        /// Alle sichtbaren Geräte die eingeschaltet sind abfragen
        /// </summary>
        public ArrayList GetOnDevices()
        {
            ArrayList _ihtDevices = new ArrayList();
            foreach (KeyValuePair<int, IhtDevice> kvp in ihtDevices)
            {
                IhtDevice _ihtDevice = kvp.Value;
                if (!_ihtDevice.IsVisible || !_ihtDevice.IsOn)
                {
                    continue;
                }
                _ihtDevices.Add(_ihtDevice);
            }
            return _ihtDevices;
        }

        /// <summary>
        /// Von alle sichtbaren Geräte die eingeschaltet sind, die SlaveId's abfragen 
        /// </summary>
        public ArrayList GetOnDevicesSlaveIds()
        {
            ArrayList _SlaveIds = new ArrayList();
            ArrayList _ihtDevices = GetOnDevices();
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                _SlaveIds.Add(_ihtDevice.SlaveId);
            }
            return _SlaveIds;
        }

        /// <summary>
        /// Gerät in Abhängigkeit der Slave-Id abfragen
        /// </summary>
        public IhtDevice GetDevice(int slaveId)
        {
            IhtDevice _device = null;
            ihtDevices.TryGetValue(slaveId, out _device);
            //Debug.Assert(_device != null, this.ToString() + ".GetDevice(...)");
            return _device;
        }

        /// <summary>
        /// Sichtbares Gerät in Abhängigkeit der Slave-Id abfragen
        /// </summary>
        public IhtDevice GetVisibleDevice(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                return _ihtDevice;
            }
            return null;
        }

        /// <summary>
        /// ProcessInfo-Daten vom sichtbarem Gerät in Abhängigkeit der Slave-Id abfragen
        /// </summary>
        public DataProcessInfo? GetDataProcessInfo(int slaveId)
        {
            IhtDevice _ihtDevice = GetVisibleDevice(slaveId);
            if (_ihtDevice != null)
            {
                return _ihtDevice.dataProcessInfo;
            }
            return null;
        }

        /// <summary>
        /// CmdExec-Daten vom sichtbarem Gerät in Abhängigkeit der Slave-Id abfragen
        /// </summary>
        public DataCmdExecution? GetDataCmdExecution(int slaveId)
        {
            IhtDevice _ihtDevice = GetVisibleDevice(slaveId);
            if (_ihtDevice != null)
            {
                return _ihtDevice.dataCmdExecution;
            }
            return null;
        }

        /// <summary>
        /// Slave-Id vom aktuellen MainControl bei dem der TorchButton Checked ist, abfragen
        /// </summary>
        public int GetSlaveIdFromCheckedTorch()
        {
            // Slave-Id's der sichtbaren MainCtontrols abfragen
            ArrayList SlaveIds = GetVisibleSlaveIds();

            foreach (int _slaveId in SlaveIds)
            {
                IhtDevice _ihtDevice = GetDevice(_slaveId);
                if (_ihtDevice != null && _ihtDevice.IsCheckedTorch)
                {
                    return _slaveId;
                }
            }
            return (int)IhtModbusCommunic.SlaveId.Id_Invalid;
        }

        /// <summary>
        /// Slave-Id's der sichtbaren MainCtontrols abfragen
        /// </summary>
        public ArrayList GetVisibleSlaveIds()
        {
            ArrayList SlaveIds = new ArrayList();
            // Alle sichtbaren Geräte abfragen
            ArrayList _ihtDevices = GetVisibleDevices();
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                if (!_ihtDevice.IsVisible)
                {
                    continue;
                }
                SlaveIds.Add((int)_ihtDevice.SlaveId);
            }
            // Die SlaveId 0 für Broadcast-Funktionalität am Ende anhängen
            SlaveIds.Add((int)IhtModbusCommunic.SlaveId.Id_Broadcast);
            return SlaveIds;
        }

        /// <summary>
        /// Für alle sichtbaren Geräten die ProcessInfo-Daten holen
        /// </summary>
        public ArrayList GetDatasProcInfosIsVisibleDevices()
        {
            ArrayList datasProcInfos = new ArrayList();
            // Alle sichtbaren Geräte abfragen
            ArrayList _ihtDevices = GetVisibleDevices();
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                datasProcInfos.Add(_ihtDevice.dataProcessInfo);
            }
            return datasProcInfos;
        }

        /// <summary>
        /// Für alle über OnOff eingeschalteten Geräten die ProcessInfo-Daten holen
        /// </summary>
        public ArrayList GetDatasProcInfosCheckedOnOffDevices()
        {
            ArrayList datasProcInfos = new ArrayList();
            // Alle sichtbaren Geräte abfragen
            ArrayList _ihtDevices = GetVisibleDevices();
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                if (_ihtDevice.IsOn == false)
                {
                    continue;
                }
                datasProcInfos.Add(_ihtDevice.dataProcessInfo);
            }
            return datasProcInfos;
        }

        /// <summary>
        /// Alle Geräte in den Default-Zustand versetzen
        /// </summary>
        public void SetDefaults()
        {
            // Den Error-Zustand der Process-Info zurücksetzen
            ArrayList _ihtDevices = GetVisibleDevices();
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                if (_ihtDevice.dataProcessInfo == null) return;

                // Evt. zuletzt gesetzter Fehler und/oder Warnung löschen
                _ihtDevice.dataProcessInfo.IsError = false;
                _ihtDevice.dataProcessInfo.IsWarning = false;
            }

            // Für alle Geräte die Verbindung auf ungültig setzen
            SetUnconnecteds();
            // Für alle Geräte den Status-Hintergrund löschen
            ClrStatusBackgrounds();
            // Für alle Geräte den On-Button auf Aus stellen
            SetOffs();
            // Alle Geräte disablen
            Disables();
        }

        /// <summary>
        /// Alle Geräte disablen
        /// </summary>
        public void Disables()
        {
            // Alle sichtbaren Geräte abfragen
            ArrayList _ihtDevices = GetVisibleDevices();
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                _ihtDevice.IsEnabledMainControl = false;
                _ihtDevice.IsEnabledOn = false;
            }
        }

        /// <summary>
        /// Alle Geräte die verbunden sind enablen
        /// </summary>
        public void EnableConnecteds(ushort u16OnSlaveIdBits)
        {
            // Alle sichtbaren Geräte abfragen
            ArrayList _ihtDevices = GetVisibleDevices();
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                _ihtDevice.ClrStatusOkBackground();
                if (_ihtDevice.IsConnected)
                {
                    _ihtDevice.IsEnabledMainControl = true;
                    _ihtDevice.IsEnabledOn = true;
                    _ihtDevice.IsEnabledOnLast = true;
                    if ((u16OnSlaveIdBits & _ihtDevice.GetSlaveIdBit()) != 0)
                    {
                        _ihtDevice.IsOn = true;
                    }
                }
                else
                {
                    _ihtDevice.SetStatusErrorBackground();
                }
            }
        }

        /// <summary>
        /// Für alle Geräte die Verbindung als ungültig setzen
        /// </summary>
        public void SetUnconnecteds()
        {
            // Alle sichtbaren Geräte abfragen
            ArrayList _ihtDevices = GetVisibleDevices();
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                _ihtDevice.IsConnected = false;
            }
        }

        /// <summary>
        /// Für das Gerät mit der entsprechenden Slave-ID die Verbindung als gültig setzen
        /// </summary>
        public void SetConnected(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.IsConnected = true;
            }
        }

        /// <summary>
        /// Abfragen, ob mindestens ein Gerät verbunden ist
        /// </summary>
        public bool IsConneteds()
        {
            // Alle sichtbaren Geräte abfragen
            ArrayList _ihtDevices = GetVisibleDevices();
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                if (_ihtDevice.IsConnected)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// Status-Hintergrund für Fehler setzen
        /// </summary>
        public void SetStatusErrorBackground(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.SetStatusErrorBackground();
            }
        }

        /// <summary>
        /// Status-Hintergrund für Fehler löschen
        /// </summary>
        public void ClrStatusErrorBackground(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.ClrStatusErrorBackground();
            }
        }

        /// <summary>
        /// Status-Hintergrund für Warnung setzen
        /// </summary>
        public void SetStatusWarningBackground(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.SetStatusWarningBackground();
            }
        }

        /// <summary>
        /// Status-Hintergrund für Verbunden setzen
        /// </summary>
        public void SetStatusOkBackground(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.SetStatusOkBackground();
            }
        }

        /// <summary>
        /// Status-Hintergrund Default setzen
        /// </summary>
        public void ClrStatusBackground(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.ClrStatusBackground();
            }
        }

        /// <summary>
        /// Status-Hintergrund für alle sichtbaren Geräte löschen
        /// </summary>
        public void ClrStatusBackgrounds()
        {
            ArrayList _ihtDevices = GetVisibleDevices();
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                _ihtDevice.ClrStatusBackground();
            }
        }

        /// <summary>
        /// Info für falschen TorchType setzen/löschen
        /// </summary>
        public void SetWrongTorchType(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.IsWrongTorchType = true;
            }
        }
        public void ClrWrongTorchType(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.IsWrongTorchType = false;
            }
        }

        /// <summary>
        /// Info für FW-Update setzen/löschen
        /// </summary>
        public void SetFwUpdate(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.IsFwUpdate = true;
            }
        }
        public void ClrFwUpdate(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.IsFwUpdate = false;
            }
        }

        /// <summary>
        /// Info für FW-Special setzen/löschen
        /// </summary>
        public void SetFwSpecial(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.IsFwSpecial = true;
            }
        }
        public void ClrFwSpecial(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.IsFwSpecial = false;
            }
        }

        /// <summary>
        /// Für alle Geräte den On-Button auf Aus stellen
        /// </summary>
        public void SetOffs()
        {
            // Alle sichtbaren Geräte abfragen
            ArrayList _ihtDevices = GetVisibleDevices();
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                _ihtDevice.IsOn = false;
            }
        }

        /// <summary>
        /// Kommunikations-Fehler setzen/löschen
        /// </summary>
        public void SetCommunicError(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.IsCommunicError = true;
                IhtModbusData _ihtModbusData = GetModbusData(_ihtDevice.SlaveId);
                if (_ihtModbusData != null)
                {
                    // Teilnehmer nimmt nicht mehr an Kommunikation teil
                    _ihtModbusData.Connected = false;
                }
                // Die Meldung Reconnection erzwingen
                _ihtDevice.dataProcessInfo.CurrPasswordLevel = 0;
            }
        }
        public void ClrCommunicError(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.IsCommunicError = false;
            }
        }

        /// <summary>
        /// Der Befehl Connect darf nur dann ausgeführt werden, wenn bei allen sichtbaren Geräten
        /// der OnOff disabled ist
        /// </summary>
        public bool CmdConnectCanExecute()
        {
            // Alle sichtbaren Geräte abfragen
            ArrayList _ihtDevices = GetVisibleDevices();
            foreach (IhtDevice _ihtDevice in _ihtDevices)
            {
                if (_ihtDevice.IsVisible && _ihtDevice.IsEnabledOn)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Abfragen, ob alle sichtbaren Geräte auf der obere Endlage stehen
        /// </summary>
        public bool UpperPositionIsVisibleDevice()
        {
            // Für alle sichtbaren Geräten die ProcessInfo-Daten holen
            ArrayList datasProcInfos = GetDatasProcInfosIsVisibleDevices();
            bool IsUpperPosition = true;
            foreach (DataProcessInfo _dataProcInfo in datasProcInfos)
            {
                if (!_dataProcInfo.IsUpperPosition)
                {
                    IsUpperPosition = false;
                    break;
                }
            }
            return IsUpperPosition;
        }

        /// <summary>
        /// Abfragen, ob alle über On eingeschalteten Geräte auf der obere Endlage stehen
        /// </summary>
        public bool UpperPositionIsCheckedOns()
        {
            // Für alle über OnOff eingeschalteten Geräten die ProcessInfo-Daten holen
            ArrayList datasProcInfos = GetDatasProcInfosCheckedOnOffDevices();
            bool IsUpperPosition = true;
            foreach (DataProcessInfo _dataProcInfo in datasProcInfos)
            {
                if (!_dataProcInfo.IsUpperPosition)
                {
                    IsUpperPosition = false;
                    break;
                }
            }
            return IsUpperPosition;
        }

        /// <summary>
        /// Alle über On eingeschalteten Geräte auf die obere Endlage fahren
        /// </summary>
        public async Task<bool> MoveToUpperPositionIsCheckedOnAsync(ArrayList datasProcInfos, long TimeOut_ms = 10000)
        {
            bool IsUpperPosition = true;

            // Warten bis alle Brenner oben sind oder TimeOut abgelaufen ist
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (stopWatch.ElapsedMilliseconds < TimeOut_ms)
            {
                IsUpperPosition = true;
                // Alle Brenner die gezündet werden aufwärts fahren
                await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.MoveManUpAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
                IsUpperPosition = true;
                foreach (DataProcessInfo _dataProcInfo in datasProcInfos)
                {
                    if (!_dataProcInfo.IsUpperPosition)
                    {
                        IsUpperPosition = false;
                        break;
                    }
                }
                if (IsUpperPosition)
                {
                    break;
                }
                await Task.Delay(200).ConfigureAwait(false);
            }
            return IsUpperPosition;
        }

        /// <summary>
        /// Technologie-Parameter Const. aktualisieren
        /// </summary>
        public void UpdateParamConstTechnology(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            IhtModbusData _ihtModbusData = GetModbusData(slaveId);
            if (_ihtDevice != null && _ihtModbusData != null)
            {
                _ihtDevice.UpdateDataParamConstTechnology(_ihtModbusData);
            }
        }
        /// <summary>
        /// Technologie-Parameter Const. aktualisieren
        /// </summary>
        public void UpdateParamConstTechnology(IhtModbusData _ihtModbusData)
        {
            IhtDevice _ihtDevice = GetDevice(_ihtModbusData.SlaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.UpdateDataParamConstTechnology(_ihtModbusData);
            }
        }

        /// <summary>
        /// Technologie-Parameter Dyn. aktualisieren
        /// </summary>
        public void UpdateParamDynTechnology(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            IhtModbusData _ihtModbusData = GetModbusData(slaveId);
            if (_ihtDevice != null && _ihtModbusData != null)
            {
                _ihtDevice.UpdateDataParamDynTechnology(_ihtModbusData);
            }
        }
        /// <summary>
        /// Technologie-Parameter Dyn. aktualisieren
        /// </summary>
        public void UpdateParamDynTechnology(IhtModbusData _ihtModbusData)
        {
            IhtDevice _ihtDevice = GetDevice(_ihtModbusData.SlaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.UpdateDataParamDynTechnology(_ihtModbusData);
            }
        }

        /// <summary>
        /// Technologie-Parameter Dyn. aller Geräte aktualisieren
        /// </summary>
        public void UpdateParamDynTechnologys()
        {
            ArrayList modbusDatas = GetModbusDatas();
            foreach (IhtModbusData _modbusData in modbusDatas)
            {
                IhtDevice _ihtDevice = GetDevice(_modbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateDataParamDynTechnology(_modbusData);
                }
            }
        }

        /// <summary>
        /// CmdExec aktualisieren
        /// </summary>
        public void UpdateCmdExec(int slaveId)
        {
            IhtDevice _ihtDevice = GetDevice(slaveId);
            IhtModbusData _ihtModbusData = GetModbusData(slaveId);
            if (_ihtDevice != null && _ihtModbusData != null)
            {
                _ihtDevice.UpdateCmdExec(_ihtModbusData);
            }
        }
        /// <summary>
        /// CmdExec aktualisieren
        /// </summary>
        public void UpdateCmdExec(IhtModbusData _ihtModbusData)
        {
            IhtDevice _ihtDevice = GetDevice(_ihtModbusData.SlaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.UpdateCmdExec(_ihtModbusData);
            }
        }

        /*
            /// <summary>
            /// Geräte-Daten bzw. Parameter aktualisieren
            /// </summary>
            public void UpdateDatas()
            {
              ArrayList modbusDatas = GetModbusDatas();
              foreach (IhtModbusData _modbusData in modbusDatas)
              {
                IhtDevice _ihtDevice = GetDevice(_modbusData.SlaveId);
                if (_ihtDevice != null)
                {
                  _ihtDevice.UpdateDatas(_modbusData);
                }
              }
            }
        */
        /// <summary>
        /// Modbus-Daten der verbundenen Geräte abfragen
        /// </summary>
        public ArrayList GetModbusDatas()
        {
            return ihtModbusCommunic.GetConnectedModbusDatas();
        }

        /// <summary>
        /// Modbus-Daten entsprechend der Slave-Id abfragen
        /// </summary>
        public IhtModbusData GetModbusData(int _slaveId)
        {
            IhtModbusData _modbusData = ihtModbusCommunic.GetConnectedModbusData(_slaveId);
            return _modbusData;
        }


        /// <summary>
        /// Für alle nict verbundenen Geräte die Process-Info Daten löschen
        /// </summary>
        public void ClrProcessInfoDatas()
        {

            // Für alle verbunden SlaveIds
            ArrayList slaveIds = new ArrayList();

            // Für alle verbundenen Geräte die Slave-Id merken
            ArrayList modbusDatas = GetModbusDatas();
            foreach (IhtModbusData modbusData in modbusDatas)
            {
                IhtDevice ihtDevice = GetDevice(modbusData.SlaveId);
                if (modbusData.Connected)
                {
                    slaveIds.Add(modbusData.SlaveId);
                }
            }

            // Für alle über OnOff eingeschalteten Geräten die ProcessInfo-Daten holen
            ArrayList datasProcInfos = new ArrayList();
            datasProcInfos = GetDatasProcInfosCheckedOnOffDevices();

            // Für alle nicht verbundenen Geräte die Process-Onfo daten löschen
            foreach (DataProcessInfo dataProcessInfo in datasProcInfos)
            {
                bool find = false;
                foreach (int slaveId in slaveIds)
                {
                    if (slaveId == dataProcessInfo.SlaveId)
                    {
                        find = true;
                        break;
                    }
                }
                if (!find)
                {
                    dataProcessInfo.ClearAll();
                    break;
                }
            }

        }


        #region Write...
        /// <summary>
        /// Parameter ParamDyn schreiben
        /// </summary>
        public async Task<bool> Write_TechnologyDynAsync(IhtModbusData _ihtModbusData, bool updateDataParam)
        {
            bool result = await ihtModbusCommunic.Write_TechnologyDynAsync(_ihtModbusData).ConfigureAwait(false);
            if (result && updateDataParam)
            {
                result = await Read_TechnologyDynAsync(_ihtModbusData, true).ConfigureAwait(false);
            }
            return result;
        }

        /// <summary>
        /// Parameter ProcesDyn schreiben
        /// </summary>
        public async Task<bool> Write_ProcessDynAsync(IhtModbusData _ihtModbusData, bool updateDataParam)
        {
            bool result = await ihtModbusCommunic.Write_ProcessDynAsync(_ihtModbusData).ConfigureAwait(false);
            if (result && updateDataParam)
            {
                result = await Read_ProcessDynAsync(_ihtModbusData, true).ConfigureAwait(false);
            }
            return result;
        }

        /// <summary>
        /// Parameter ConfigDyn schreiben
        /// </summary>
        public async Task<bool> Write_ConfigDynAsync(IhtModbusData _ihtModbusData, bool updateDataParam)
        {
            bool result = await ihtModbusCommunic.Write_ConfigDynAsync(_ihtModbusData);
            if (result && updateDataParam)
            {
                result = await Read_ConfigDynAsync(_ihtModbusData, true).ConfigureAwait(false);
            }
            return result;
        }

        /// <summary>
        /// Parameter ServiceDyn schreiben
        /// </summary>
        public async Task<bool> Write_ServiceDynAsync(IhtModbusData _ihtModbusData, bool updateDataParam)
        {
            bool result = await ihtModbusCommunic.Write_ServiceDynAsync(_ihtModbusData).ConfigureAwait(false);
            if (result && updateDataParam)
            {
                result = await Read_ServiceDynAsync(_ihtModbusData, true).ConfigureAwait(false);
            }
            return result;
        }

        /// <summary>
        /// Parameter CmdExec schreiben
        /// </summary>
        public async Task<bool> Write_CmdExecAsync(IhtModbusData _ihtModbusData, bool updateDataParam)
        {
            bool result = await ihtModbusCommunic.Write_CmdExecAsync(_ihtModbusData).ConfigureAwait(false);
            if (result && updateDataParam)
            {
                result = await Read_CmdExecAsync(_ihtModbusData, true).ConfigureAwait(false);
            }
            return result;
        }

        /// <summary>
        /// Parameter SetupExec schreiben
        /// </summary>
        public async Task<bool> Write_SetupExecAsync(IhtModbusData _ihtModbusData, bool updateDataParam)
        {
            bool result = await ihtModbusCommunic.Write_SetupExecAsync(_ihtModbusData).ConfigureAwait(false);
            if (result && updateDataParam)
            {
                result = await Read_SetupExecAsync(_ihtModbusData, true).ConfigureAwait(false);
            }
            return result;
        }
        #endregion // Write_...


        #region Read_...
        /// <summary>
        /// Adress-Bereiche auslesen
        /// </summary>
        public async Task<bool> Read_AddrAreasAsync(IhtModbusData ihtModbusData)
        {
            return await ihtModbusCommunic.Read_AddrAreasAsync(ihtModbusData).ConfigureAwait(false);
        }

        /// <summary>
        /// Geraete-Info auslesen 
        /// </summary>
        public async Task<bool> Read_DeviceInfoAsync(IhtModbusData ihtModbusData, bool updateData)
        {
            bool blResult = await ihtModbusCommunic.Read_DeviceInfoAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateData)
            {
                IhtDevice _ihtDevice = GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateDataDeviceInfo(ihtModbusData);
                }
            }
            return blResult;
        }

        /// <summary>
        /// Technologie-Parameter Const. auslesen 
        /// </summary>
        public async Task<bool> Read_TechnologyConstAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await ihtModbusCommunic.Read_TechnologyConstAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateDataParamConstTechnology(ihtModbusData);
                }
            }
            return blResult;
        }

        /// <summary>
        /// Process-Parameter Const. auslesen 
        /// </summary>
        public async Task<bool> Read_ProcessConstAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await ihtModbusCommunic.Read_ProcessConstAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = GetDevice(ihtModbusData.SlaveId);
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
        public async Task<bool> Read_ConfigConstAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await ihtModbusCommunic.Read_ConfigConstAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = GetDevice(ihtModbusData.SlaveId);
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
        public async Task<bool> Read_ServiceConstAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await ihtModbusCommunic.Read_ServiceConstAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = GetDevice(ihtModbusData.SlaveId);
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
        public async Task<bool> Read_TechnologyDynAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await ihtModbusCommunic.Read_TechnologyDynAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                UpdateParamDynTechnology(ihtModbusData);
            }
            return blResult;
        }

        /// <summary>
        /// Process-Parameter Dyn. auslesen
        /// </summary>
        public async Task<bool> Read_ProcessDynAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await ihtModbusCommunic.Read_ProcessDynAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = GetDevice(ihtModbusData.SlaveId);
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
        public async Task<bool> Read_ConfigDynAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await ihtModbusCommunic.Read_ConfigDynAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = GetDevice(ihtModbusData.SlaveId);
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
        public async Task<bool> Read_ServiceDynAsync(IhtModbusData ihtModbusData, bool updateDataParam)
        {
            bool blResult = await ihtModbusCommunic.Read_ServiceDynAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataParam)
            {
                IhtDevice _ihtDevice = GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateParamDynService(ihtModbusData);
                }
            }
            return blResult;
        }

        /// <summary>
        /// Process-Info auslesen
        /// </summary>
        public async Task<bool> Read_ProcessInfoAsync(IhtModbusData ihtModbusData, bool updateDataProcessInfo)
        {
            bool blResult = await ihtModbusCommunic.Read_ProcessInfoAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataProcessInfo)
            {
                IhtDevice _ihtDevice = GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateDataProcessInfo(ihtModbusData);
                }
            }
            return blResult;
        }

        /// <summary>
        /// Cmd-Exec. auslesen
        /// </summary>
        public async Task<bool> Read_CmdExecAsync(IhtModbusData ihtModbusData, bool updateCmdExec)
        {
            bool blResult = await ihtModbusCommunic.Read_CmdExecAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateCmdExec)
            {
                IhtDevice _ihtDevice = GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateCmdExec(ihtModbusData);
                }
            }
            return blResult;
        }

        /// <summary>
        /// Setup-Exec. auslesen
        /// </summary>
        public async Task<bool> Read_SetupExecAsync(IhtModbusData ihtModbusData, bool updateDataSetupExec)
        {
            bool blResult = await ihtModbusCommunic.Read_SetupExecAsync(ihtModbusData).ConfigureAwait(false);
            if (blResult && updateDataSetupExec)
            {
                IhtDevice _ihtDevice = GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.UpdateDataSetupExecution(ihtModbusData);
                }
            }
            return blResult;
        }

        /// <summary>
        /// Data auslesen
        /// </summary>
        public async Task<bool> Read_DataAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_DataAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }

        /// <summary>
        /// TableData auslesen
        /// </summary>
        public async Task<bool> Read_TableDataAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_TableDataAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }

        /// <summary>
        /// ErrorCode-Labels auslesen
        /// </summary>
        public async Task<bool> Read_ErrorCodeLabelsAsync(IhtModbusData ihtModbusData)
        {
            string fwVersion = ihtModbusData.GetDeviceInfoValue(IhtModbusData.DataDeviceInfoValue.FwVersion, IhtModbusData.DescriptionData.OnlyValue);
            ErrorCodeLables _errorCodeLables = errorCodeLablesDevices.GetErrorCodeLabels(fwVersion);

            bool blResult = true;
            if (_errorCodeLables == null)
            {
                blResult = await ihtModbusCommunic.Read_TableErrorCodeLabelsAsync(ihtModbusData).ConfigureAwait(false);
                if (blResult)
                {
                    SetErrorCodeLabels(ihtModbusData, ihtModbusCommunic.ihtModbusTableErrorLabels.GetListText());
                }
            }
            else
            {
                IhtDevice _ihtDevice = GetDevice(ihtModbusData.SlaveId);
                if (_ihtDevice != null)
                {
                    _ihtDevice.SetErrorCodeLabels(_errorCodeLables);
                }
            }
            return blResult;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetErrorCodeLabels(IhtModbusData ihtModbusData, List<string> list)
        {
            string fwVersion = ihtModbusData.GetDeviceInfoValue(IhtModbusData.DataDeviceInfoValue.FwVersion, IhtModbusData.DescriptionData.OnlyValue);
            errorCodeLablesDevices.SetErrorCodeLabels(fwVersion, list);
            ErrorCodeLables _errorCodeLables = errorCodeLablesDevices.GetErrorCodeLabels(fwVersion);
            IhtDevice _ihtDevice = GetDevice(ihtModbusData.SlaveId);
            if (_ihtDevice != null)
            {
                _ihtDevice.SetErrorCodeLabels(_errorCodeLables);
            }
        }

        /// <summary>
        /// ErrorCode-Counts auslesen
        /// </summary>
        public async Task<bool> Read_ErrorAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_TableErrorAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }
        public List<string> GetErrorList()
        {
            return ihtModbusCommunic.ihtModbusTableErrorTbl.GetListText();
        }

        /// <summary>
        /// OxyProc CutCycleHistory Current  auslesen
        /// </summary>
        public async Task<bool> Read_OxyProcCutCycleHistoryCurrentAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_TableOxyProcCutCycleHistoryCurrentAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }
        public List<string> GetOxyProcCutCycleHistoryCurrentList()
        {
            return ihtModbusCommunic.ihtModbusTableOxyProcCutCycleStateCurrTbl.GetListText();
        }
        /// <summary>
        /// OxyProc CutCycleHistory Previous  auslesen
        /// </summary>
        public async Task<bool> Read_OxyProcCutCycleHistoryPreviousAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_TableOxyProcCutCycleHistoryPreviousAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }
        public List<string> GetOxyProcCutCycleHistoryPreviousList()
        {
            return ihtModbusCommunic.ihtModbusTableOxyProcCutCycleStatePrevTbl.GetListText();
        }

        /// <summary>
        /// Temperatur Histogramm fuer µC auslesen
        /// </summary>
        public async Task<bool> Read_TempHistogramuCAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_TableTempHistogramuCTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }
        public List<string> GetTempHistogramuCList()
        {
            return ihtModbusCommunic.ihtModbusTableTempHistogramuCTbl.GetListText();
        }

        /// <summary>
        /// Histogramm  Common auslesen
        /// </summary>
        public async Task<bool> Read_HistogramCommonAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_TableHistogramCommonTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }
        public List<string> GetHistogramCommonList()
        {
            return ihtModbusCommunic.ihtModbusTableHistogramCommonTbl.GetListText();
        }

        /// <summary>
        /// Histogramm Common fuer Kunde auslesen
        /// </summary>
        public async Task<bool> Read_HistogramCommonCustomAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_TableHistogramCommonCustomTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }
        public List<string> GetHistogramCommonCustomList()
        {
            return ihtModbusCommunic.ihtModbusTableHistogramCommonCustomTbl.GetListText();
        }

        /// <summary>
        /// Fehler Histogramm fuer Kunde auslesen
        /// </summary>
        public async Task<bool> Read_ErrorCustomAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_TableErrorCustomTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }
        public List<string> GetErrorCustomList()
        {
            return ihtModbusCommunic.ihtModbusTableErrorCustomTbl.GetListText();
        }

        /// <summary>
        /// FIT+3 Fehler Histogramm fuer µC auslesen
        /// </summary>
        public async Task<bool> Read_FitPlus3HistoErrorAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_TableFitPlus3HistoErrorTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }
        public List<string> GetFitPlus3HistoErrorList()
        {
            return ihtModbusCommunic.ihtModbusTableFitPlus3HistoErrorTbl.GetListText();
        }

        /// <summary>
        /// FIT+3 Temperatur Histogramm fuer µC auslesen
        /// </summary>
        public async Task<bool> Read_FitPlus3HistoErrorCustomAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_TableFitPlus3HistoErrorCustomTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }
        public List<string> GetFitPlus3HistoErrorCustomList()
        {
            return ihtModbusCommunic.ihtModbusTableFitPlus3HistoErrorCustomTbl.GetListText();
        }

        /// <summary>
        /// FIT+3 Temperatur Histogramm fuer µC auslesen
        /// </summary>
        public async Task<bool> Read_FitPlus3HistoTempuCAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_TableFitPlus3HistoTempuCTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }
        public List<string> GetFitPlus3HistoTempuCList()
        {
            return ihtModbusCommunic.ihtModbusTableFitPlus3HistoTempuCTbl.GetListText();
        }

        /// <summary>
        /// FIT+3 Temperatur-Oben Histogramm auslesen
        /// </summary>
        public async Task<bool> Read_FitPlus3HistoTempTopAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_TableFitPlus3HistoTempTopTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }
        public List<string> GetFitPlus3HistoTempTopList()
        {
            return ihtModbusCommunic.ihtModbusTableFitPlus3HistoTempTopTbl.GetListText();
        }

        /// <summary>
        /// FIT+3 Temperatur-Unen Histogramm auslesen
        /// </summary>
        public async Task<bool> Read_FitPlus3HistoTempBottomAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Read_TableFitPlus3HistoTempBottomTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }
        public List<string> GetFitPlus3HistoTempBottomList()
        {
            return ihtModbusCommunic.ihtModbusTableFitPlus3HistoTempBottomTbl.GetListText();
        }

        /// <summary>
        /// Status-Info auslesen
        /// </summary>
        public async Task<bool> Read_StatusInfoAsync(IhtModbusData ihtModbusData, int dataOffsetAddr = 0, int dataCounts = (int)IhtModbusParamDyn.eIdxData.DataMaxLength)
        {
            bool blResult = await ihtModbusCommunic.Read_TableStatusInfoTblAsync(ihtModbusData, dataOffsetAddr, dataCounts).ConfigureAwait(false);
            return blResult;
        }
        public List<UInt16> GetStatusInfoList()
        {
            return ihtModbusCommunic.ihtModbusTableStatusInfoTbl.GetListValue();
        }

        /// <summary>
        /// Status-Info Specific auslesen
        /// </summary>
        public async Task<bool> Read_StatusInfoSpecificAsync(IhtModbusData ihtModbusData, int dataOffsetAddr = 0, int dataCounts = (int)IhtModbusParamDyn.eIdxData.DataMaxLength)
        {
            bool blResult = await ihtModbusCommunic.Read_TableStatusInfoSpecificTblAsync(ihtModbusData, dataOffsetAddr, dataCounts).ConfigureAwait(false);
            return blResult;
        }
        public List<UInt16> GetStatusInfoSpecificList()
        {
            return ihtModbusCommunic.ihtModbusTableStatusInfoSpecificTbl.GetListValue();
        }


        /// <summary>
        /// Dynamische Daten auslesen
        /// </summary>
        public async Task<bool> Read_AllDataDynAsync(IhtModbusData ihtModbusData, bool updateData)
        {
            bool blResult = true;
            // Technologie-Parameter Dyn. auslesen
            blResult = blResult && (blResult = await Read_TechnologyDynAsync(ihtModbusData, updateData).ConfigureAwait(false));
            // Process-Parameter Dyn. auslesen
            blResult = blResult && (blResult = await Read_ProcessDynAsync(ihtModbusData, updateData).ConfigureAwait(false));
            // Config-Parameter Dyn. auslesen
            blResult = blResult && (blResult = await Read_ConfigDynAsync(ihtModbusData, updateData).ConfigureAwait(false));
            // Sevice-Parameter Dyn. auslesen
            blResult = blResult && (blResult = await Read_ServiceDynAsync(ihtModbusData, updateData).ConfigureAwait(false));
            // Process-Info auslesen
            blResult = blResult && (blResult = await Read_ProcessInfoAsync(ihtModbusData, updateData).ConfigureAwait(false));
            // Cmd-Exec. auslesen
            blResult = blResult && (blResult = await Read_CmdExecAsync(ihtModbusData, updateData).ConfigureAwait(false));
            // Setup-Exec. auslesen
            blResult = blResult && (blResult = await Read_SetupExecAsync(ihtModbusData, updateData).ConfigureAwait(false));
            return blResult;
        }
        public async Task<bool> Read_AllDataDynAsync(int _slaveId, bool updateData)
        {
            IhtModbusData ihtModbusData = GetModbusData(_slaveId);
            if (ihtModbusData != null)
            {
                return await Read_AllDataDynAsync(ihtModbusData, updateData).ConfigureAwait(false);
            }
            return false;
        }
        #endregion // Read_...


        #region Histogramme löschen
        /// <summary>
        /// Fehler Histogramm fuer löschen
        /// </summary>
        public async Task<bool> Write_EraseTableErrorTblAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Write_EraseTableErrorTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }

        /// <summary>
        /// Temperatur Histogramm fuer µC löschen
        /// </summary>
        public async Task<bool> Write_EraseTableTempHistogramuCTblcAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Write_EraseTableTempHistogramuCTblcAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }

        /// <summary>
        /// Histogramm  Common löschen
        /// </summary>
        public async Task<bool> Write_EraseTableHistogramCommonTblAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Write_EraseTableHistogramCommonTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }

        /// <summary>
        /// Histogramm Common fuer Kunde löschen
        /// </summary>
        public async Task<bool> Write_EraseTableHistogramCommonCustomTblAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Write_EraseTableHistogramCommonCustomTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }

        /// <summary>
        /// Fehler Histogramm fuer Kunde löschen
        /// </summary>
        public async Task<bool> Write_EraseTableErrorCustomTblAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Write_EraseTableErrorCustomTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }

        /// <summary>
        /// FIT+3 Fehler Histogramm löschen
        /// </summary>
        public async Task<bool> Write_EraseTableFitPlus3HistoErrorTblAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Write_EraseTableFitPlus3HistoErrorTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }

        /// <summary>
        /// FIT+3 Fehler Histogramm für Kunde löschen
        /// </summary>
        public async Task<bool> Write_EraseTableFitPlus3HistoErrorCustomTblAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Write_EraseTableFitPlus3HistoErrorCustomTblAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }

        /// <summary>
        /// FIT+3 Alle Fehler Histogramme löschen
        /// </summary>
        public async Task<bool> Write_EraseTableFitPlus3HistoErrorAllAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Write_EraseTableFitPlus3HistoErrorAllAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }

        /// <summary>
        /// FIT+3 Alle Temperatur Histogramm löschen
        /// </summary>
        public async Task<bool> Write_EraseTableFitPlus3HistoTempuAllAsync(IhtModbusData ihtModbusData)
        {
            bool blResult = await ihtModbusCommunic.Write_EraseTableFitPlus3HistoTempuAllAsync(ihtModbusData).ConfigureAwait(false);
            return blResult;
        }
        #endregion // Histogramme löschen


        #region Manuelle Auf-/Ab-Bewegung
        /// <summary>
        /// Manuelle Aufwärtsbewegung
        /// </summary>
        public async Task MoveManUpAsync(int _slaveId)
        {
            if (ihtModbusCommunic.ihtModbusCmdExecInputEmulation != null)
            {
                await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.MoveManUpAsync(_slaveId).ConfigureAwait(false);
            }
        }
        public async Task StopManUpAsync(int _slaveId)
        {
            if (ihtModbusCommunic.ihtModbusCmdExecInputEmulation != null)
            {
                await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.StopManUpAsync(_slaveId).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Manuelle Abwärtsbewegung
        /// </summary>
        public async Task MoveManDownAsync(int _slaveId)
        {
            if (ihtModbusCommunic.ihtModbusCmdExecInputEmulation != null)
            {
                await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.MoveManDownAsync(_slaveId).ConfigureAwait(false);
            }
        }
        public async Task StopManDownAsync(int _slaveId)
        {
            if (ihtModbusCommunic.ihtModbusCmdExecInputEmulation != null)
            {
                await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.StopManDownAsync(_slaveId).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Abstandseinstellung nach oben
        /// </summary>
        public async Task HeightCtrlUpAsync(int _slaveId)
        {
            if (ihtModbusCommunic.ihtModbusCmdExecInputEmulation != null)
            {
                await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.HeightCtrlUpAsync(_slaveId).ConfigureAwait(false);
            }
        }
        public async Task StopHeightCtrlUpAsync(int _slaveId)
        {
            if (ihtModbusCommunic.ihtModbusCmdExecInputEmulation != null)
            {
                await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.StopHeightCtrlUpAsync(_slaveId).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Abstandseinstellung nach unten
        /// </summary>
        public async Task HeightCtrlDownAsync(int _slaveId)
        {
            if (ihtModbusCommunic.ihtModbusCmdExecInputEmulation != null)
            {
                await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.HeightCtrlDownAsync(_slaveId).ConfigureAwait(false);
            }
        }
        public async Task StopHeightCtrlDownAsync(int _slaveId)
        {
            if (ihtModbusCommunic.ihtModbusCmdExecInputEmulation != null)
            {
                await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.StopHeightCtrlDownAsync(_slaveId).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Manuelle Aufwärtsbewegung Gemeinsam
        /// </summary>
        public async Task MoveManUpCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.MoveManUpAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }
        public async Task StopManUpCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.StopManUpAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }

        /// <summary>
        /// Manuelle Abwärtsbewegung Gemeinsam
        /// </summary>
        public async Task MoveManDownCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.MoveManDownAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }
        public async Task StopManDownCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.StopManDownAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }
        #endregion // Manuelle Auf-/Ab-Bewegung


        #region Manuelle Gas-Steuerung
        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand Off setzen
        /// </summary>
        public async Task SetupCtrl_SetOffAsync(int _slaveId)
        {
            if (ihtModbusCommunic.ihtModbusCmdSetupCtrl != null)
            {
                await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetOffAsync(_slaveId).ConfigureAwait(false);
            }
            else
            {
                throw new Exception("Device is not connected");
            }
        }
        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand Off setzen, Gemeinsam
        /// </summary>
        public async Task SetupCtrl_SetOffCommonAsync()
        {
            // Alle gemeinsam ausschalten
            await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetOffAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
            // Einzelnen Heartbeat ausschalten
            ArrayList devices = GetOnDevices();
            foreach (IhtDevice device in devices)
            {
                await SetupCtrl_SetOffAsync(device.SlaveId).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand Start setzen
        /// </summary>
        public async Task SetupCtrl_SetStartAsync(int _slaveId)
        {
            if (ihtModbusCommunic.ihtModbusCmdSetupCtrl != null)
            {
                await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetStartAsync(_slaveId).ConfigureAwait(false);
            }
            else
            {
                throw new Exception("Device is not connected");
            }
        }
        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand Start setzen, Gemeinsam
        /// </summary>
        public async Task SetupCtrl_SetStartCommonAsync()
        {
            // Alle gemeinsam einschalten
            await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetStartAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
            // Einzelnen Heartbeat einschalten
            ArrayList devices = GetOnDevices();
            bool ignoreStartDelay = true;
            foreach (IhtDevice device in devices)
            {
                await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetStartAsync(device.SlaveId, ignoreStartDelay).ConfigureAwait(false);
            }
            // Nur gemeinsamen Heartbaet ausschalten
            bool setCmdOff = false;
            await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetOffAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast, setCmdOff).ConfigureAwait(false);
        }

        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand Ignition setzen
        /// </summary>
        public async Task SetupCtrl_SetIgnitionAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetIgnitionAsync(_slaveId).ConfigureAwait(false);
        }
        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand Ignition setzen, Gemeinsam
        /// </summary>
        public async Task SetupCtrl_SetIgnitionCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetIgnitionAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }

        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand PreHeating setzen
        /// </summary>
        public async Task SetupCtrl_SetPreHeatingAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetPreHeatingAsync(_slaveId).ConfigureAwait(false);
        }
        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand PreHeating setzen, Gemeinsam
        /// </summary>
        public async Task SetupCtrl_SetPreHeatingCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetPreHeatingAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }

        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand Piercing setzen
        /// </summary>
        public async Task SetupCtrl_SetPiercingAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetPiercingAsync(_slaveId).ConfigureAwait(false);
        }
        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand Piercing setzen, Gemeinsam
        /// </summary>
        public async Task SetupCtrl_SetPiercingCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetPiercingAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }

        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand Cutting setzen
        /// </summary>
        public async Task SetupCtrl_SetCuttingAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetCuttingAsync(_slaveId).ConfigureAwait(false);
        }
        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand Cutting setzen, Gemeinsam
        /// </summary>
        public async Task SetupCtrl_SetCuttingCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetCuttingAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }

        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand Heating setzen
        /// </summary>
        public async Task SetupCtrl_SetHeatingAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetHeatingAsync(_slaveId).ConfigureAwait(false);
        }
        /// <summary>
        /// Manuelle Gas-Steuerung in den Zustand Heating setzen, Gemeinsam
        /// </summary>
        public async Task SetupCtrl_SetHeatingCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdSetupCtrl.SetHeatingAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }
        #endregion // Manuelle Gas-Steuerung


        #region Prozess Start/Stop
        /// <summary>
        /// Prozess starten, Gemeinsam
        /// </summary>
        public async Task StartProcessOnCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecInputEmulation_2.StartProcessOnAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }
        /// <summary>
        /// Prozess stoppen, Gemeinsam
        /// </summary>
        public async Task StopProcessOnCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecInputEmulation_2.StopProcessOnAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }
        #endregion // Prozess Start/Stop

        #region Prozess DelayStartPreHeatTime
        /// <summary>
        /// Starten der Heizzeit verzoegern, bis alle aktiven Brenner den Abstand erreicht haben, aktivieren. Gemeinsam
        /// </summary>
        public async Task DelayStartPreHeatTime_ActiveAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecInputEmulation_2.DelayStartPreHeatTime_ActiveAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }
        /// <summary>
        /// Starten der Heizzeit verzoegern, bis alle aktiven Benner den Abstand erreicht haben, deaktivieren. Gemeinsam
        /// </summary>
        public async Task DelayStartPreHeatTime_InActiveAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecInputEmulation_2.DelayStartPreHeatTime_InActiveAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }
        #endregion // Prozess Start/Stop


        #region ClrErrorCode
        public async Task ClrErrorCodeCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecTactile.ClrErrorCode((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }
        public async Task ClrErrorCodeAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdExecTactile.ClrErrorCode(_slaveId).ConfigureAwait(false);
        }
        #endregion // ClrErrorCode

        #region PreHeatTime Reload/Stop
        public async Task ReloadPreHeatTimeCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecTactile.ReloadPreHeatTimeAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }

        public async Task StopPreHeatTimeCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecTactile.StopPreHeatTimeAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }
        #endregion // PreHeatTime Reload/Stop


        #region ClearenceCtrlOff Set/Clr
        public async Task SetClearenceCtrlOffCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.SetClearanceControlOffAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast, GetOnDevicesSlaveIds()).ConfigureAwait(false);
        }
        public async Task ClrClearenceCtrlOffCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.ClrClearanceControlOffAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast, GetOnDevicesSlaveIds()).ConfigureAwait(false);
        }
        public async Task SetClearenceCtrlOffAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.SetClearanceControlOffAsync(_slaveId).ConfigureAwait(false);
        }
        public async Task ClrClearenceCtrlOffAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.ClrClearanceControlOffAsync(_slaveId).ConfigureAwait(false);
        }
        #endregion // ClearenceCtrlOff Set/Clr

        #region FlameOnAtProcessEnd Set/Clr
        public async Task SetFlameOnAtProcessEndCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.SetFlameOnAtProcessEndAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast, GetOnDevicesSlaveIds()).ConfigureAwait(false);
        }
        public async Task ClrFlameOnAtProcessEndCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.ClrFlameOnAtProcessEndAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast, GetOnDevicesSlaveIds()).ConfigureAwait(false);
        }
        public async Task SetFlameOnAtProcessEndAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.SetFlameOnAtProcessEndAsync(_slaveId).ConfigureAwait(false);
        }
        public async Task ClrFlameOnAtProcessEndAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.ClrFlameOnAtProcessEndAsync(_slaveId).ConfigureAwait(false);
        }
        #endregion // FlameOnAtProcessEnd Set/Clr

        #region ClearenceCtrlManual Set/Clr
        public async Task SetClearenceCtrlManualCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.SetClearenceCtrlManualAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast, GetOnDevicesSlaveIds()).ConfigureAwait(false);
        }
        public async Task ClrClearenceCtrlManualCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.ClrClearenceCtrlManualAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast, GetOnDevicesSlaveIds()).ConfigureAwait(false);
        }
        public async Task SetClearenceCtrlManualAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.SetClearenceCtrlManualAsync(_slaveId).ConfigureAwait(false);
        }
        public async Task ClrClearenceCtrlManualAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.ClrClearenceCtrlManualAsync(_slaveId).ConfigureAwait(false);
        }
        #endregion // ClearenceCtrlManual Set/Clr

        #region SetClearenceCtrlManualHeightCommon
        public async Task SetClearenceCtrlManualHeightCommonAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdExecTactile.SetClearenceCtrlManualHeightAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }
        #endregion // SetClearenceCtrlManualHeightCommon

        #region ExecuteClearanceSignalAdjust
        public async Task ExecuteClearanceSignalAdjustAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdExecTactile.ExecuteClearanceSignalAdjust(_slaveId).ConfigureAwait(false);
        }
        #endregion // ExecuteClearanceSignalAdjust

        #region TorchOff Set/Clr
        public async Task SetTorchOffAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.SetTorchOffAsync(_slaveId).ConfigureAwait(false);
            // Falls ClrClearenceCtrlOff zuvor aktiv war, löschen
            await ClrClearenceCtrlOffAsync(_slaveId).ConfigureAwait(false);
        }
        public async Task ClrTorchOffAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdExecSwitch.ClrTorchOffAsync(_slaveId).ConfigureAwait(false);
            // FlameOnAtProcessEnd entsprechend setzen
            await UpdateFlameOnAtProcessEndAsync(_slaveId).ConfigureAwait(false);
            // ClearenceCtrlManual entsprechend setzen
            await UpdateClearenceCtrlManualAsync(_slaveId).ConfigureAwait(false);
        }
        #endregion // TorchOff Set/Clr

        #region UpdateFlameOnAtProcessEnd
        /// <summary>
        /// FlameOnAtProcessEnd entsprechend setzen
        /// </summary>
        public async Task UpdateFlameOnAtProcessEndAsync(int _slaveId)
        {
            if (IsFlameOnAtProcessEndCommon)
            {
                await SetFlameOnAtProcessEndAsync(_slaveId).ConfigureAwait(false);
            }
            else
            {
                await ClrFlameOnAtProcessEndAsync(_slaveId).ConfigureAwait(false);
            }
        }
        #endregion // UpdateFlameOnAtProcessEnd

        #region UpdateClearenceCtrlManual
        /// <summary>
        /// ClearenceCtrlManual entsprechend setzen
        /// </summary>
        public async Task UpdateClearenceCtrlManualAsync(int _slaveId)
        {
            if (IsClearenceCtrlManualCommon)
            {
                await SetClearenceCtrlManualAsync(_slaveId).ConfigureAwait(false);
            }
            else
            {
                await ClrClearenceCtrlManualAsync(_slaveId).ConfigureAwait(false);
            }
        }
        #endregion // UpdateClearenceCtrlManual


        #region Abstands-Kalibrierung
        public async Task StartCalibrationAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.StartCalibrationAsync(_slaveId).ConfigureAwait(false);
        }
        public async Task StopCalibrationAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdExecInputEmulation.StopCalibrationAsync(_slaveId).ConfigureAwait(false);
        }
        #endregion Abstands-Kalibrierung


        #region Abstands-Regelung
        public async Task HeightControlOffsaAsync()
        {
            await ihtModbusCommunic.ihtModbusCmdHeightCtrl.OffAsync((int)IhtModbusCommunic.SlaveId.Id_Broadcast).ConfigureAwait(false);
        }
        public async Task HeightControlOffAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdHeightCtrl.OffAsync(_slaveId).ConfigureAwait(false);
        }
        public async Task HeightControlPreHeatingAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdHeightCtrl.PreHeatingAsync(_slaveId).ConfigureAwait(false);
        }
        public async Task HeightControlPiercingAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdHeightCtrl.PiercingAsync(_slaveId).ConfigureAwait(false);
        }
        public async Task HeightControlCuttingAsync(int _slaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdHeightCtrl.CuttingAsync(_slaveId).ConfigureAwait(false);
        }
        #endregion Abstands-Regelung


        #region Test Pressure Out
        public async Task SetTestPressureHeatO2Async(int SlaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdTestPressureOut.SetPressureOutHeatO2Async(SlaveId).ConfigureAwait(false);
        }
        public async Task ClrTestPressureHeatO2Async(int SlaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdTestPressureOut.ClrPressureOutHeatO2Async(SlaveId).ConfigureAwait(false);
        }

        public async Task SetTestPressureCutO2Async(int SlaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdTestPressureOut.SetPressureOutCutO2Async(SlaveId).ConfigureAwait(false);
        }
        public async Task ClrTestPressureCutO2Async(int SlaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdTestPressureOut.ClrPressureOutCutO2Async(SlaveId).ConfigureAwait(false);
        }

        public async Task SetTestPressureFuelGasAsync(int SlaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdTestPressureOut.SetPressureOutFuelGasAsync(SlaveId).ConfigureAwait(false);
        }
        public async Task ClrTestPressureFuelGasAsync(int SlaveId)
        {
            await ihtModbusCommunic.ihtModbusCmdTestPressureOut.ClrPressureOutFuelGasAsync(SlaveId).ConfigureAwait(false);
        }
        #endregion // Test Pressure Out


        #region PasswordLevelSoftware
        public void ClrPasswordLevelSoftware()
        {
            PasswordLevel_Software = (int)PasswordLevel_SW.Level_0;
            IsCutDataSetEditable = false;
        }

        public void SetPasswordLevelSoftware(int passwordLevel)
        {
            switch (passwordLevel)
            {
                case (int)IhtModbusData.ePasswordCode.Level_1:
                    PasswordLevel_Software = (int)PasswordLevel_SW.Level_1;
                    break;
                case (int)IhtModbusData.ePasswordCode.Level_2:
                    PasswordLevel_Software = (int)PasswordLevel_SW.Level_2;
                    break;
                case (int)IhtModbusData.ePasswordCode.Level_GCE:
                    PasswordLevel_Software = (int)PasswordLevel_SW.Level_2;
                    IsCutDataSetEditable = true;
                    break;
                case (int)IhtModbusData.ePasswordCode.Level_3:
                    PasswordLevel_Software = (int)PasswordLevel_SW.Level_3;
                    IsCutDataSetEditable = true;
                    break;
                default:
                    PasswordLevel_Software = (int)PasswordLevel_SW.Level_0;
                    IsCutDataSetEditable = false;
                    break;
            }
        }
        #endregion


        #region Tables
        /// <summary>
        /// Error-Code Label abfragen
        /// </summary>
        public string GetErrorCodeLabel(int _slaveId, int errorCode)
        {
            IhtDevice _ihtDevice = GetDevice(_slaveId);
            if (_ihtDevice != null)
            {
                return _ihtDevice.GetErrorCodeLabel(errorCode);
            }
            return "Er." + errorCode.ToString();
        }
        #endregion // Tables


    }

}
