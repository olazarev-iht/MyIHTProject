using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;
using SharedComponents.Services.APCWorkerService;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace SharedComponents.IhtData
{
    public class DataProcessInfo : INotifyPropertyChanged
    {
        // Zur Identifizierung zum welchen Gerät die Date gehören
        private int _slaveId { get; set; }
        public int SlaveId
        {
            get { return _slaveId; }
            set { _slaveId = value; RaisePropertyChanged("SlaveId"); }
        }
        // IsCommunicError
        private bool _isCommunicError { get; set; }
        public bool IsCommunicError
        {
            get { return _isCommunicError; }
            set
            {
                _isCommunicError = value;
                if (value)
                {
                    ErrorCode = IhtDevice.ErrorCodeCommunic;
                    IsError = true;
                }
                RaisePropertyChanged("IsCommunicError");
            }
        }

        #region ProcessInfo-Daten
        private int _errorCode { get; set; }
        private int _status { get; set; }
        private int _status2 { get; set; }
        private int _statusLeds { get; set; }
        private int _statusInputs { get; set; }
        private int _statusOutputs { get; set; }
        private int _statusHeightControl { get; set; }
        private int _currOutHeatO2 { get; set; }
        private int _currOutCutO2 { get; set; }
        private int _currOutFuelGas { get; set; }
        private int _currHeatTime { get; set; }
        private int _currOxyfuelProcState { get; set; }
        private int _currCutCycleState { get; set; }
        private int _currUB24V { get; set; }
        private int _uB24VMin { get; set; }
        private int _uB24VMax { get; set; }
        private int _linearDrivePosition { get; set; }
        private int _ignitionFlameAdjustParamDisabled { get; set; }
        private int _currCutO2BlowoutTime { get; set; }
        private int _currSetupExecSetup { get; set; }
        private int _currSetupExecTestPressureOut { get; set; }
        private int _currPasswordLevel { get; set; }
        private int _clearanceOut_digit { get; set; }
        private int _clearanceOut_mV { get; set; }


        IAPCWorker? _IAPCWorker
        {
            get
            {
                return _provider?.GetService<IAPCWorker>();
            }
        }

        private bool IsPropertyChanged;
        // private bool IsUpdateFinished;

        public int ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; RaisePropertyChanged("ErrorCode"); }
        }

        public int Status
        {
            get { return _status; }
            set { 
                if(value != _status)
                {
                    _status = value;
                    RaisePropertyChanged();
                }
                
            }
        }

        public int Status2
        {
            get { return _status2; }
            set { _status2 = value; RaisePropertyChanged("Status2"); }
        }

        public int StatusLeds
        {
            get { return _statusLeds; }
            set { _statusLeds = value; RaisePropertyChanged("StatusLeds"); }
        }

        public int StatusInputs
        {
            get { return _statusInputs; }
            set { _statusInputs = value; RaisePropertyChanged("StatusInputs"); }
        }

        public int StatusOutputs
        {
            get { return _statusOutputs; }
            set { _statusOutputs = value; RaisePropertyChanged("StatusOutputs"); }
        }

        public int StatusHeightControl
        {
            get { return _statusHeightControl; }
            set { _statusHeightControl = value; RaisePropertyChanged("StatusHeightControl"); }
        }

        public int CurrOutHeatO2
        {
            get { return _currOutHeatO2; }
            set { _currOutHeatO2 = value; RaisePropertyChanged("CurrOutHeatO2"); }
        }

        public int CurrOutCutO2
        {
            get { return _currOutCutO2; }
            set { _currOutCutO2 = value; RaisePropertyChanged("CurrOutCutO2"); }
        }

        public int CurrOutFuelGas
        {
            get { return _currOutFuelGas; }
            set { _currOutFuelGas = value; RaisePropertyChanged("CurrOutFuelGas"); }
        }

        public int CurrHeatTime
        {
            get { return _currHeatTime; }
            set { _currHeatTime = value; RaisePropertyChanged("CurrHeatTime"); }
        }

        public int CurrOxyfuelProcState
        {
            get { return _currOxyfuelProcState; }
            set { _currOxyfuelProcState = value; RaisePropertyChanged("CurrOxyfuelProcState"); }
        }

        public int CurrCutCycleState
        {
            get { return _currCutCycleState; }
            set { _currCutCycleState = value; RaisePropertyChanged("CurrCutCycleState"); }
        }

        public int CurrUB24V
        {
            get { return _currUB24V; }
            set { _currUB24V = value; RaisePropertyChanged("CurrUB24V"); }
        }

        public int UB24VMin
        {
            get { return _uB24VMin; }
            set { _uB24VMin = value; RaisePropertyChanged("UB24VMin"); }
        }

        public int UB24VMax
        {
            get { return _uB24VMax; }
            set { _uB24VMax = value; RaisePropertyChanged("UB24VMax"); }
        }

        public int LinearDrivePosition
        {
            get { return _linearDrivePosition; }
            set { _linearDrivePosition = value; RaisePropertyChanged("LinearDrivePosition"); }
        }

        public int IgnitionFlameAdjustParamDisabled
        {
            get { return _ignitionFlameAdjustParamDisabled; }
            set { _ignitionFlameAdjustParamDisabled = value; RaisePropertyChanged("IgnitionFlameAdjustParamDisabled"); }
        }

        public int CurrCutO2BlowoutTime
        {
            get { return _currCutO2BlowoutTime; }
            set { _currCutO2BlowoutTime = value; RaisePropertyChanged("CurrCutO2BlowoutTime"); }
        }

        public int CurrSetupExecSetup
        {
            get { return _currSetupExecSetup; }
            set { _currSetupExecSetup = value; RaisePropertyChanged("CurrSetupExecSetup"); }
        }

        public int CurrSetupExecTestPressureOut
        {
            get { return _currSetupExecTestPressureOut; }
            set { _currSetupExecTestPressureOut = value; RaisePropertyChanged("CurrSetupExecTestPressureOut"); }
        }

        public int CurrPasswordLevel
        {
            get { return _currPasswordLevel; }
            set { _currPasswordLevel = value; RaisePropertyChanged("CurrPasswordLevel"); }
        }

        public int ClearanceOut_digit
        {
            get { return _clearanceOut_digit; }
            set { _clearanceOut_digit = value; RaisePropertyChanged("ClearanceOut_digit"); }
        }

        public int ClearanceOut_mV
        {
            get { return _clearanceOut_mV; }
            set { _clearanceOut_mV = value; RaisePropertyChanged("ClearanceOut_mV"); }
        }
        #endregion

        //public DataProcessInfo()
        //{
        //}

        static IServiceProvider _provider;

        public DataProcessInfo(IServiceProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));

            PropertyChanged += IsProcessInfoChangedHandler;
        }

        public void IsProcessInfoChangedHandler(object? sender, PropertyChangedEventArgs eventArgs)
        {
            //eventArgs.PropertyName

            IsPropertyChanged = true;

            //if(IsUpdateFinished)
            //if (_IAPCWorker != null)
            //{
            //    _IAPCWorker._apcWorkerService_LiveDataChanged(sender, eventArgs);
            //}

        }

        #region Status-Register
        private bool _isReady { get; set; }
        private bool _isProcessActive { get; set; }
        private bool _isEmergencyMode { get; set; }
        private bool _isUpperPosition { get; set; }
        private bool _isControlActive { get; set; }
        private bool _isInPosition { get; set; }
        private bool _isCalibrationValid { get; set; }
        private bool _isCalibrationActive { get; set; }
        private bool _isTactileInitPosFindEnabled { get; set; }
        private bool _isLockPressureOutputActive { get; set; }
        private bool _isFlameOnAtProcessEndEnabled { get; set; }
        private bool _isRetractPosAtProcessEndEnabled { get; set; }
        private bool _isCapSetpointFlameOffsEnabled { get; set; }
        private bool _isCutO2BlowoutActive { get; set; }
        private bool _isTemperProcessActive { get; set; }
        private bool _isAckErrorActive { get; set; }

        public bool IsReady
        {
            get { return _isReady; }
            set { _isReady = value; RaisePropertyChanged("IsReady"); }
        }
        public bool IsProcessActive
        {
            get { return _isProcessActive; }
            set { _isProcessActive = value; RaisePropertyChanged("IsProcessActive"); }
        }
        public bool IsEmergencyMode
        {
            get { return _isEmergencyMode; }
            set { _isEmergencyMode = value; RaisePropertyChanged("IsEmergencyMode"); }
        }
        public bool IsUpperPosition
        {
            get { return _isUpperPosition; }
            set { _isUpperPosition = value; RaisePropertyChanged("IsUpperPosition"); }
        }
        public bool IsControlActive
        {
            get { return _isControlActive; }
            set { _isControlActive = value; RaisePropertyChanged("IsControlActive"); }
        }
        public bool IsInPosition
        {
            get { return _isInPosition; }
            set { _isInPosition = value; RaisePropertyChanged("IsInPosition"); }
        }
        public bool IsCalibrationValid
        {
            get { return _isCalibrationValid; }
            set { _isCalibrationValid = value; RaisePropertyChanged("IsCalibrationValid"); }
        }
        public bool IsCalibrationActive
        {
            get { return _isCalibrationActive; }
            set { _isCalibrationActive = value; RaisePropertyChanged("IsCalibrationActive"); }
        }
        public bool IsTactileInitPosFindEnabled
        {
            get { return _isTactileInitPosFindEnabled; }
            set { _isTactileInitPosFindEnabled = value; RaisePropertyChanged("IsTactileInitPosFindEnabled"); }
        }
        public bool IsLockPressureOutputActive
        {
            get { return _isLockPressureOutputActive; }
            set { _isLockPressureOutputActive = value; RaisePropertyChanged("IsLockPressureOutputActive"); }
        }
        public bool IsFlameOnAtProcessEndEnabled
        {
            get { return _isFlameOnAtProcessEndEnabled; }
            set { _isFlameOnAtProcessEndEnabled = value; RaisePropertyChanged("IsFlameOnAtProcessEndEnabled"); }
        }
        public bool IsRetractPosAtProcessEndEnabled
        {
            get { return _isRetractPosAtProcessEndEnabled; }
            set { _isRetractPosAtProcessEndEnabled = value; RaisePropertyChanged("IsRetractPosAtProcessEndEnabled"); }
        }
        public bool IsCapSetpointFlameOffsEnabled
        {
            get { return _isCapSetpointFlameOffsEnabled; }
            set { _isCapSetpointFlameOffsEnabled = value; RaisePropertyChanged("IsCapSetpointFlameOffsEnabled"); }
        }
        public bool IsCutO2BlowoutActive
        {
            get { return _isCutO2BlowoutActive; }
            set { _isCutO2BlowoutActive = value; RaisePropertyChanged("IsCutO2BlowoutActive"); }
        }
        public bool IsTemperProcessActive
        {
            get { return _isTemperProcessActive; }
            set { _isTemperProcessActive = value; RaisePropertyChanged("IsTemperProcessActive"); }
        }
        public bool IsAckErrorActive
        {
            get { return _isAckErrorActive; }
            set { _isAckErrorActive = value; RaisePropertyChanged("IsAckErrorActive"); }
        }
        #endregion // Status-Register 1


        #region HeightControl-Status
        private bool _isHeightControlActive { get; set; }
        public bool IsHeightControlActive
        {
            get { return _isHeightControlActive; }
            set { _isHeightControlActive = value; RaisePropertyChanged("IsHeightControlActive"); }
        }
        #endregion // Status-Register


        #region Status-Register 2
        private bool _isFlameOn { get; set; }
        public bool IsFlameOn
        {
            get { return _isFlameOn; }
            set { _isFlameOn = value; RaisePropertyChanged("IsFlameOn"); }
        }
        private bool _isClearanceControlOff { get; set; }
        public bool IsClearanceControlOff
        {
            get { return _isClearanceControlOff; }
            set { _isClearanceControlOff = value; RaisePropertyChanged("IsClearanceControlOff"); }
        }
        private bool _isClearanceControlManual { get; set; }
        public bool IsClearanceControlManual
        {
            get { return _isClearanceControlManual; }
            set { _isClearanceControlManual = value; RaisePropertyChanged("IsClearanceControlManual"); }
        }
        private bool _isTorchOff { get; set; }
        public bool IsTorchOff
        {
            get { return _isTorchOff; }
            set { _isTorchOff = value; RaisePropertyChanged("IsTorchOff"); }
        }
        private bool _isIgnitionDetectionEnabled { get; set; }
        public bool IsIgnitionDetectionEnabled
        {
            get { return _isIgnitionDetectionEnabled; }
            set { _isIgnitionDetectionEnabled = value; RaisePropertyChanged("IsIgnitionDetectionEnabled"); }
        }
        private bool _isPiercingSensorMode { get; set; }
        public bool IsPiercingSensorMode
        {
            get { return _isPiercingSensorMode; }
            set { _isPiercingSensorMode = value; RaisePropertyChanged("IsPiercingSensorMode"); }
        }
        #endregion // Status-Register 2


        #region Ohters
        private bool _isError { get; set; }
        public bool IsError
        {
            get { return _isError; }
            set { _isError = value; RaisePropertyChanged("IsError"); }
        }

        private bool _isCalibrationInValid { get; set; }
        public bool IsCalibrationInValid
        {
            get { return _isCalibrationInValid; }
            set { _isCalibrationInValid = value; RaisePropertyChanged("IsCalibrationInValid"); }
        }

        private bool _isWarning { get; set; }
        public bool IsWarning
        {
            get { return _isWarning; }
            set { _isWarning = value; RaisePropertyChanged("IsWarning"); }
        }

        private bool _isProcessInActive { get; set; }
        public bool IsProcessInActive
        {
            get { return _isProcessInActive; }
            set { _isProcessInActive = value; RaisePropertyChanged("IsProcessInActive"); }
        }

        private bool _isEnabledTestPressureOut { get; set; }
        public bool IsEnabledTestPressureOut
        {
            get { return _isEnabledTestPressureOut; }
            set { _isEnabledTestPressureOut = value; RaisePropertyChanged("IsEnabledTestPressureOut"); }
        }

        private bool _isEnabledManDown { get; set; }
        public bool IsEnabledManDown
        {
            get { return _isEnabledManDown; }
            set { _isEnabledManDown = value; RaisePropertyChanged("IsEnabledManDown"); }
        }

        private bool _isEnabledHeightControlOff { get; set; }
        public bool IsEnabledHeightControlOff
        {
            get { return _isEnabledHeightControlOff; }
            set { _isEnabledHeightControlOff = value; RaisePropertyChanged("IsEnabledHeightControlOff"); }
        }
        #endregion // Ohters


        #region Status-Inputs
        private bool _isInpManUp { get; set; }
        public bool IsInpManUp
        {
            get { return _isInpManUp; }
            set { _isInpManUp = value; RaisePropertyChanged("IsInpManUp"); }
        }

        private bool _isInpManDown { get; set; }
        public bool IsInpManDown
        {
            get { return _isInpManDown; }
            set { _isInpManDown = value; RaisePropertyChanged("IsInpManDown"); }
        }

        private bool _isInpAutomatic { get; set; }
        public bool IsInpAutomatic
        {
            get { return _isInpAutomatic; }
            set { _isInpAutomatic = value; RaisePropertyChanged("IsInpAutomatic"); }
        }

        private bool _isInpStartProcess { get; set; }
        public bool IsInpStartProcess
        {
            get { return _isInpStartProcess; }
            set { _isInpStartProcess = value; RaisePropertyChanged("IsInpStartProcess"); }
        }

        private bool _isInpIgnite { get; set; }
        public bool IsInpIgnite
        {
            get { return _isInpIgnite; }
            set { _isInpIgnite = value; RaisePropertyChanged("IsInpIgnite"); }
        }

        private bool _isInpTorchDisabled { get; set; }
        public bool IsInpTorchDisabled
        {
            get { return _isInpTorchDisabled; }
            set { _isInpTorchDisabled = value; RaisePropertyChanged("IsInpTorchDisabled"); }
        }

        private bool _isInpClearanceCtrlOff { get; set; }
        public bool IsInpClearanceCtrlOff
        {
            get { return _isInpClearanceCtrlOff; }
            set { _isInpClearanceCtrlOff = value; RaisePropertyChanged("IsInpClearanceCtrlOff"); }
        }

        private bool _isInpStopHeating { get; set; }
        public bool IsInpStopHeating
        {
            get { return _isInpStopHeating; }
            set { _isInpStopHeating = value; RaisePropertyChanged("IsStopHeating"); }
        }

        private bool _isInputCuSync { get; set; }
        public bool IsInputCuSync
        {
            get { return _isInputCuSync; }
            set { _isInputCuSync = value; RaisePropertyChanged("IsInputCuSync"); }
        }

        private bool _isInputClearanceSignalAdjust { get; set; }
        public bool IsInputClearanceSignalAdjust
        {
            get { return _isInputClearanceSignalAdjust; }
            set { _isInputClearanceSignalAdjust = value; RaisePropertyChanged("IsInputClearanceSignalAdjust"); }
        }
        #endregion // Status-Inputs


        #region Status-Outputs
        private bool _isOutputFault { get; set; }
        public bool IsOutputFault
        {
            get { return _isOutputFault; }
            set { _isOutputFault = value; RaisePropertyChanged("IsOutputFault"); }
        }

        private bool _isOutputInPosition { get; set; }
        public bool IsOutputInPosition
        {
            get { return _isOutputInPosition; }
            set { _isOutputInPosition = value; RaisePropertyChanged("IsOutputInPosition"); }
        }

        private bool _isOutputUpperPosition { get; set; }
        public bool IsOutputUpperPosition
        {
            get { return _isOutputUpperPosition; }
            set { _isOutputUpperPosition = value; RaisePropertyChanged("IsOutputUpperPosition"); }
        }

        private bool _isOutputOk2Move { get; set; }
        public bool IsOutputOk2Move
        {
            get { return _isOutputOk2Move; }
            set { _isOutputOk2Move = value; RaisePropertyChanged("IsOutputOk2Move"); }
        }

        private bool _isOutputSlowSpeed { get; set; }
        public bool IsOutputSlowSpeed
        {
            get { return _isOutputSlowSpeed; }
            set { _isOutputSlowSpeed = value; RaisePropertyChanged("IsOutputSlowSpeed"); }
        }

        private bool _isOutputFit3_InputIgnition { get; set; }
        public bool IsOutputFit3_InputIgnition
        {
            get { return _isOutputFit3_InputIgnition; }
            set { _isOutputFit3_InputIgnition = value; RaisePropertyChanged("IsOutputFit3_InputIgnition"); }
        }

        private bool _isOutputFit3_SolenoidValve { get; set; }
        public bool IsOutputFit3_SolenoidValve
        {
            get { return _isOutputFit3_SolenoidValve; }
            set { _isOutputFit3_SolenoidValve = value; RaisePropertyChanged("IsOutputFit3_SolenoidValve"); }
        }

        private bool _isOutputFit3_GlowPlug { get; set; }
        public bool IsOutputFit3_GlowPlug
        {
            get { return _isOutputFit3_GlowPlug; }
            set { _isOutputFit3_GlowPlug = value; RaisePropertyChanged("IsOutputFit3_GlowPlug"); }
        }

        private bool _isOutputFit3_FlameFlashback { get; set; }
        public bool IsOutputFit3_FlameFlashback
        {
            get { return _isOutputFit3_FlameFlashback; }
            set { _isOutputFit3_FlameFlashback = value; RaisePropertyChanged("IsOutputFit3_FlameFlashback"); }
        }

        private bool _isOutputFit3_Error { get; set; }
        public bool IsOutputFit3_Error
        {
            get { return _isOutputFit3_Error; }
            set { _isOutputFit3_Error = value; RaisePropertyChanged("IsOutputFit3_Error"); }
        }

        private bool _isOutputFit3_ErrUB24V { get; set; }
        public bool IsOutputFit3_ErrUB24V
        {
            get { return _isOutputFit3_ErrUB24V; }
            set { _isOutputFit3_ErrUB24V = value; RaisePropertyChanged("IsOutputFit3_ErrUB24V"); }
        }

        private bool _isOutputFit3_ErrucTemperature { get; set; }
        public bool IsOutputFit3_ErrucTemperature
        {
            get { return _isOutputFit3_ErrucTemperature; }
            set { _isOutputFit3_ErrucTemperature = value; RaisePropertyChanged("IsOutputFit3_ErrucTemperature"); }
        }

        private bool _isOutputFit3_ErrSolenoidValve { get; set; }
        public bool IsOutputFit3_ErrSolenoidValve
        {
            get { return _isOutputFit3_ErrSolenoidValve; }
            set { _isOutputFit3_ErrSolenoidValve = value; RaisePropertyChanged("IsOutputFit3_ErrSolenoidValve"); }
        }

        private bool _isOutputFit3_ErrGlowPlug { get; set; }
        public bool IsOutputFit3_ErrGlowPlug
        {
            get { return _isOutputFit3_ErrGlowPlug; }
            set { _isOutputFit3_ErrGlowPlug = value; RaisePropertyChanged("IsOutputFit3_ErrGlowPlug"); }
        }

        private bool _isOutputFit3_ErrCommunic { get; set; }
        public bool IsOutputFit3_ErrCommunic
        {
            get { return _isOutputFit3_ErrCommunic; }
            set { _isOutputFit3_ErrCommunic = value; RaisePropertyChanged("IsOutputFit3_ErrCommunic"); }
        }
        #endregion // StatusOutputs


        #region StatusLeds
        private bool _isLedIgnition { get; set; }
        public bool IsLedIgnition
        {
            get { return _isLedIgnition; }
            set { _isLedIgnition = value; RaisePropertyChanged("IsLedIgnition"); }
        }

        private bool _isLedPreHeating { get; set; }
        public bool IsLedPreHeating
        {
            get { return _isLedPreHeating; }
            set { _isLedPreHeating = value; RaisePropertyChanged("IsLedPreHeating"); }
        }

        private bool _isLedPiercing { get; set; }
        public bool IsLedPiercing
        {
            get { return _isLedPiercing; }
            set { _isLedPiercing = value; RaisePropertyChanged("IsLedPiercing"); }
        }

        private bool _isLedCutting { get; set; }
        public bool IsLedCutting
        {
            get { return _isLedCutting; }
            set { _isLedCutting = value; RaisePropertyChanged("IsLedCutting"); }
        }

        private bool _isLedTemper { get; set; }
        public bool IsLedTemper
        {
            get { return _isLedTemper; }
            set { _isLedTemper = value; RaisePropertyChanged("IsLedTemper"); }
        }

        private bool _isLedCutO2Blowout { get; set; }
        public bool IsLedCutO2Blowout
        {
            get { return _isLedCutO2Blowout; }
            set { _isLedCutO2Blowout = value; RaisePropertyChanged("IsLedCutO2Blowout"); }
        }

        private bool _isLedRetractPosition { get; set; }
        public bool IsLedRetractPosition
        {
            get { return _isLedRetractPosition; }
            set { _isLedRetractPosition = value; RaisePropertyChanged("IsLedRetractPosition"); }
        }

        private bool _isLedUpperPosition { get; set; }
        public bool IsLedUpperPosition
        {
            get { return _isLedUpperPosition; }
            set { _isLedUpperPosition = value; RaisePropertyChanged("IsLedUpperPosition"); }
        }

        private bool _isLedError { get; set; }
        public bool IsLedError
        {
            get { return _isLedError; }
            set { _isLedError = value; RaisePropertyChanged("IsLedError"); }
        }
        #endregion // StatusLeds

        // Helper-Methode, um nicht in jedem Set-Accessor zu prüfen, ob PropertyRaisePropertyChanged!=null
        //private void RaisePropertyChanged(string propertyName)
        //{
        //    var handler = PropertyChanged;
        //    if (handler != null)
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //}
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };


        /// <summary>
        /// 
        /// </summary>
        internal void UpdateDatas(IhtModbusData ihtModbusData)
        {
            #region ProcessInfo-Daten

            IsPropertyChanged = false;

            if (IsCommunicError)
            {
                ErrorCode = IhtDevice.ErrorCodeCommunic;
            }
            else if (ihtModbusData != null)
            {
                ErrorCode = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.ErrorCode);
            }
            Status = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.Status);
            Status2 = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.Status2);
            StatusLeds = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.StatusLeds);
            StatusInputs = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.StatusInputs);
            StatusOutputs = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.StatusOutputs);
            StatusHeightControl = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.StatusHeightControl);
            CurrOutHeatO2 = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrOutHeatO2);
            CurrOutCutO2 = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrOutCutO2);
            CurrOutFuelGas = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrOutFuelGas);
            CurrHeatTime = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrHeatTime);
            CurrOxyfuelProcState = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrOxyfuelProcState);
            CurrCutCycleState = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrCutCycleState);
            CurrUB24V = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrUB24V);
            UB24VMin = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.UB24VMin);
            UB24VMax = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.UB24VMax);
            LinearDrivePosition = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.LinearDrivePosition);
            IgnitionFlameAdjustParamDisabled = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.IgnitionFlameAdjustParamDisabled);
            CurrCutO2BlowoutTime = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrCutO2BlowoutTime);
            CurrSetupExecSetup = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrSetupExecSetup);
            CurrSetupExecTestPressureOut = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrSetupExecTestPressureOut);
            CurrPasswordLevel = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrPasswordLevel);
            ClearanceOut_digit = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.ClearanceOut_digit);
            ClearanceOut_mV = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.ClearanceOut_mV);
            #endregion // ProcessInfo-Daten

            #region Status-Register
            IsReady = (Status & (int)IhtModbusParamDyn.eStatusBit.Ready) != 0 ? true : false;
            //    IsProcessActive                 = (Status & (int)IhtModbusParamDyn.eStatusBit.ProcessActive                ) != 0 ? true : false;
            IsEmergencyMode = (Status & (int)IhtModbusParamDyn.eStatusBit.EmergencyMode) != 0 ? true : false;
            IsUpperPosition = (Status & (int)IhtModbusParamDyn.eStatusBit.UpperPosition) != 0 ? true : false;
            IsControlActive = (Status & (int)IhtModbusParamDyn.eStatusBit.ControlActive) != 0 ? true : false;
            IsInPosition = (Status & (int)IhtModbusParamDyn.eStatusBit.InPosition) != 0 ? true : false;
            // Damit nicht die Info-Meldung erscheint
            if (ihtModbusData != null)
            {
                IsCalibrationValid = (Status & (int)IhtModbusParamDyn.eStatusBit.CalibrationValid) != 0 ? true : false;
            }
            IsCalibrationActive = (Status & (int)IhtModbusParamDyn.eStatusBit.CalibrationActive) != 0 ? true : false;
            IsTactileInitPosFindEnabled = (Status & (int)IhtModbusParamDyn.eStatusBit.TactileInitPosFindEnabled) != 0 ? true : false;
            IsLockPressureOutputActive = (Status & (int)IhtModbusParamDyn.eStatusBit.LockPressureOutputActive) != 0 ? true : false;
            IsFlameOnAtProcessEndEnabled = (Status & (int)IhtModbusParamDyn.eStatusBit.FlameOnAtProcessEndEnabled) != 0 ? true : false;
            IsRetractPosAtProcessEndEnabled = (Status & (int)IhtModbusParamDyn.eStatusBit.RetractPosAtProcessEndEnabled) != 0 ? true : false;
            IsCapSetpointFlameOffsEnabled = (Status & (int)IhtModbusParamDyn.eStatusBit.CapSetpointFlameOffsEnabled) != 0 ? true : false;
            IsCutO2BlowoutActive = (Status & (int)IhtModbusParamDyn.eStatusBit.CutO2BlowoutActive) != 0 ? true : false;
            IsTemperProcessActive = (Status & (int)IhtModbusParamDyn.eStatusBit.TemperProcessActive) != 0 ? true : false;
            IsAckErrorActive = (Status & (int)IhtModbusParamDyn.eStatusBit.AckErrorActive) != 0 ? true : false;

            IsProcessActive = (Status & (int)IhtModbusParamDyn.eStatusBit.ProcessActive) != 0
                                             || (IsCutO2BlowoutActive && CurrOxyfuelProcState != 1);
            #endregion // Status-Register

            #region Status-Register 2
            IsFlameOn = (Status2 & (int)IhtModbusParamDyn.eStatus2Bit.FlameOn) != 0 ? true : false;
            IsClearanceControlOff = (Status2 & (int)IhtModbusParamDyn.eStatus2Bit.ClearanceControlOff) != 0 ? true : false;
            IsClearanceControlManual = (Status2 & (int)IhtModbusParamDyn.eStatus2Bit.ClearanceControlManual) != 0 ? true : false;
            IsTorchOff = (Status2 & (int)IhtModbusParamDyn.eStatus2Bit.TorchOff) != 0 ? true : false;
            IsIgnitionDetectionEnabled = (Status2 & (int)IhtModbusParamDyn.eStatus2Bit.IsIgnitionDetectionEnabled) != 0 ? true : false;
            IsPiercingSensorMode = (Status2 & (int)IhtModbusParamDyn.eStatus2Bit.IsIsPiercingSensorMode) != 0 ? true : false;
            #endregion // Status-Register 2

            #region StatusLeds
            IsLedIgnition = (StatusLeds & (int)IhtModbusParamDyn.eStatusLedBit.Ignition) != 0 ? true : false;
            IsLedPreHeating = (StatusLeds & (int)IhtModbusParamDyn.eStatusLedBit.PreHeating) != 0 ? true : false;
            IsLedPiercing = (StatusLeds & (int)IhtModbusParamDyn.eStatusLedBit.Piercing) != 0 ? true : false;
            IsLedCutting = (StatusLeds & (int)IhtModbusParamDyn.eStatusLedBit.Cutting) != 0 ? true : false;
            IsLedTemper = (StatusLeds & (int)IhtModbusParamDyn.eStatusLedBit.Temper) != 0 ? true : false;
            IsLedCutO2Blowout = (StatusLeds & (int)IhtModbusParamDyn.eStatusLedBit.CutO2Blowout) != 0 ? true : false;
            IsLedRetractPosition = (StatusLeds & (int)IhtModbusParamDyn.eStatusLedBit.RetractPosition) != 0 ? true : false;
            IsLedUpperPosition = (StatusLeds & (int)IhtModbusParamDyn.eStatusLedBit.UpperPosition) != 0 ? true : false;
            IsLedError = (StatusLeds & (int)IhtModbusParamDyn.eStatusLedBit.Error) != 0 ? true : false;
            #endregion // StatusLeds

            #region Status-Inputs
            IsInpManUp = (StatusInputs & (int)IhtModbusParamDyn.eStatusInpBit.ManUp) != 0 ? true : false;
            IsInpManDown = (StatusInputs & (int)IhtModbusParamDyn.eStatusInpBit.ManDown) != 0 ? true : false;
            IsInpAutomatic = (StatusInputs & (int)IhtModbusParamDyn.eStatusInpBit.Automatic) != 0 ? true : false;
            IsInpStartProcess = (StatusInputs & (int)IhtModbusParamDyn.eStatusInpBit.StartProcess) != 0 ? true : false;
            IsInpIgnite = (StatusInputs & (int)IhtModbusParamDyn.eStatusInpBit.Ignite) != 0 ? true : false;
            IsInpTorchDisabled = (StatusInputs & (int)IhtModbusParamDyn.eStatusInpBit.TorchDisabled) != 0 ? true : false;
            IsInpClearanceCtrlOff = (StatusInputs & (int)IhtModbusParamDyn.eStatusInpBit.ClearanceCtrlOff) != 0 ? true : false;
            IsInpStopHeating = (StatusInputs & (int)IhtModbusParamDyn.eStatusInpBit.StopHeating) != 0 ? true : false;
            IsInputCuSync = (StatusInputs & (int)IhtModbusParamDyn.eStatusInpBit.CuSync) == 0 ? true : false; // negiert
            IsInputClearanceSignalAdjust = (StatusInputs & (int)IhtModbusParamDyn.eStatusInpBit.ClearanceSignalAdjust) != 0 ? true : false;
            #endregion // Status-Inputs

            #region Status-Outputs
            IsOutputFault = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.Fault) != 0 ? true : false;
            IsOutputInPosition = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.InPosition) != 0 ? true : false;
            IsOutputUpperPosition = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.UpperPosition) != 0 ? true : false;
            IsOutputOk2Move = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.Ok2Move) != 0 ? true : false;
            IsOutputSlowSpeed = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.SlowSpeed) != 0 ? true : false;
            IsOutputFit3_InputIgnition = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.Fit3_InputIgnition) != 0 ? true : false;
            IsOutputFit3_SolenoidValve = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.Fit3_SolenoidValve) != 0 ? true : false;
            IsOutputFit3_GlowPlug = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.Fit3_GlowPlug) != 0 ? true : false;
            IsOutputFit3_FlameFlashback = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.Fit3_FlameFlashback) != 0 ? true : false;
            IsOutputFit3_Error = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.Fit3_Error) != 0 ? true : false;
            IsOutputFit3_ErrUB24V = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.Fit3_ErrUB24V) != 0 ? true : false;
            IsOutputFit3_ErrucTemperature = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.Fit3_ErrucTemperature) != 0 ? true : false;
            IsOutputFit3_ErrSolenoidValve = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.Fit3_ErrSolenoidValve) != 0 ? true : false;
            IsOutputFit3_ErrGlowPlug = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.Fit3_ErrGlowPlug) != 0 ? true : false;
            IsOutputFit3_ErrCommunic = (StatusOutputs & (int)IhtModbusParamDyn.eStatusOutBit.Fit3_ErrCommunic) != 0 ? true : false;
            #endregion // StatusOutputs

            #region HeightControl-Status
            IsHeightControlActive = (StatusHeightControl != (int)IhtModbusParamDyn.eStatusHeightCtrl.Off) && !IsInpClearanceCtrlOff;
            #endregion // HeightControl-Status

            #region Ohters
            IsError = (ErrorCode != 0) ? true : false;
            IsCalibrationInValid = !IsCalibrationValid;
            IsWarning = IsCalibrationInValid;
            IsProcessInActive = !IsProcessActive;
            IsEnabledTestPressureOut = /*!IsError &&*/ !IsProcessActive && !IsCalibrationActive;
            IsEnabledManDown = ((IsHeightControlActive || IsProcessActive)
                                         && !IsClearanceControlOff
                                         && !IsInpClearanceCtrlOff
                                         && !IsClearanceControlManual
                                        ) ? false : true;

            IsEnabledHeightControlOff = ((IsLedPreHeating || IsLedPiercing || IsLedCutting) && !IsInpClearanceCtrlOff) || IsClearanceControlOff;
            #endregion Ohters

            // Call event LiveDataChanged
            if (_IAPCWorker != null && IsPropertyChanged)
            {
                _IAPCWorker._apcWorkerService_LiveDataChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Process-Info Daten löschen
        /// </summary>
        internal void ClearAll(bool setErrorCodeCommunic = true)
        {
            UpdateDatas(null);
            if (setErrorCodeCommunic)
            {
                ErrorCode = IhtDevice.ErrorCodeCommunic;
            }
        }
    }
}
