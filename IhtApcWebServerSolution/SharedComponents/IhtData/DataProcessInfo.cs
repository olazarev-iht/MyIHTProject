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
        private int _slaveId;
        public int SlaveId
        {
            get { return _slaveId; }
            set { RaisePropertyChanged(ref _slaveId, value); }
        }

        // IsCommunicError
        private bool _isCommunicError;
        public bool IsCommunicError
        {
            get { return _isCommunicError; }
            set
            {
                if (value)
                {
                    ErrorCode = IhtDevice.ErrorCodeCommunic;
                    IsError = true;
                }
                RaisePropertyChanged(ref _isCommunicError, value);
            }
        }

        #region ProcessInfo-Daten
        private int _errorCode;
        private int _status;
        private int _status2;
        private int _statusLeds;
        private int _statusInputs;
        private int _statusOutputs;
        private int _statusHeightControl;
        private int _currOutHeatO2;
        private int _currOutCutO2;
        private int _currOutFuelGas;
        private int _currHeatTime;
        private int _currOxyfuelProcState;
        private int _currCutCycleState;
        private int _currUB24V;
        private int _uB24VMin;
        private int _uB24VMax;
        private int _linearDrivePosition;
        private int _ignitionFlameAdjustParamDisabled;
        private int _currCutO2BlowoutTime;
        private int _currSetupExecSetup;
        private int _currSetupExecTestPressureOut;
        private int _currPasswordLevel;
        private int _clearanceOut_digit;
        private int _clearanceOut_mV;


        IAPCWorker? _IAPCWorker
        {
            get
            {
                return _provider?.GetService<IAPCWorker>();
            }
        }

        private bool IsPropertyChanged;
        private string? ChangedPropertyName;
        public bool IsProcessInfoUpdating;

        public int ErrorCode
        {
            get { return _errorCode; }
            set { RaisePropertyChanged(ref _errorCode, value); }
        }

        public int Status
        {
            get { return _status; }
            set { RaisePropertyChanged(ref _status, value); }
        }

        public int Status2
        {
            get { return _status2; }
            set { RaisePropertyChanged(ref _status2, value); }
        }

        public int StatusLeds
        {
            get { return _statusLeds; }
            set { RaisePropertyChanged(ref _statusLeds, value); }
        }

        public int StatusInputs
        {
            get { return _statusInputs; }
            set { RaisePropertyChanged(ref _statusInputs, value); }
        }

        public int StatusOutputs
        {
            get { return _statusOutputs; }
            set { RaisePropertyChanged(ref _statusOutputs, value); }
        }

        public int StatusHeightControl
        {
            get { return _statusHeightControl; }
            set { RaisePropertyChanged(ref _statusHeightControl, value); }
        }

        public int CurrOutHeatO2
        {
            get { return _currOutHeatO2; }
            set { RaisePropertyChanged(ref _currOutHeatO2, value); }
        }

        public int CurrOutCutO2
        {
            get { return _currOutCutO2; }
            set { RaisePropertyChanged(ref _currOutCutO2, value); }
        }

        public int CurrOutFuelGas
        {
            get { return _currOutFuelGas; }
            set { RaisePropertyChanged(ref _currOutFuelGas, value); }
        }

        public int CurrHeatTime
        {
            get { return _currHeatTime; }
            set { RaisePropertyChanged(ref _currHeatTime, value); }
        }

        public int CurrOxyfuelProcState
        {
            get { return _currOxyfuelProcState; }
            set { RaisePropertyChanged(ref _currOxyfuelProcState, value); }
        }

        public int CurrCutCycleState
        {
            get { return _currCutCycleState; }
            set { RaisePropertyChanged(ref _currCutCycleState, value); }
        }

        public int CurrUB24V
        {
            get { return _currUB24V; }
            set { RaisePropertyChanged(ref _currUB24V, value); }
        }

        public int UB24VMin
        {
            get { return _uB24VMin; }
            set { RaisePropertyChanged(ref _uB24VMin, value); }
        }

        public int UB24VMax
        {
            get { return _uB24VMax; }
            set { RaisePropertyChanged(ref _uB24VMax, value); }
        }

        public int LinearDrivePosition
        {
            get { return _linearDrivePosition; }
            set { RaisePropertyChanged(ref _linearDrivePosition, value); }
        }

        public int IgnitionFlameAdjustParamDisabled
        {
            get { return _ignitionFlameAdjustParamDisabled; }
            set { RaisePropertyChanged(ref _ignitionFlameAdjustParamDisabled, value); }
        }

        public int CurrCutO2BlowoutTime
        {
            get { return _currCutO2BlowoutTime; }
            set { RaisePropertyChanged(ref _currCutO2BlowoutTime, value); }
        }

        public int CurrSetupExecSetup
        {
            get { return _currSetupExecSetup; }
            set { RaisePropertyChanged(ref _currSetupExecSetup, value); }
        }

        public int CurrSetupExecTestPressureOut
        {
            get { return _currSetupExecTestPressureOut; }
            set { RaisePropertyChanged(ref _currSetupExecTestPressureOut, value); }
        }

        public int CurrPasswordLevel
        {
            get { return _currPasswordLevel; }
            set { RaisePropertyChanged(ref _currPasswordLevel, value); }
        }

        public int ClearanceOut_digit
        {
            get { return _clearanceOut_digit; }
            set { RaisePropertyChanged(ref _clearanceOut_digit, value); }
        }

        public int ClearanceOut_mV
        {
            get { return _clearanceOut_mV; }
            set { RaisePropertyChanged(ref _clearanceOut_mV, value); }
        }
        #endregion

        static IServiceProvider? _provider;

        public event PropertyChangedEventHandler? PropertyChanged;

        public DataProcessInfo(IServiceProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));

            PropertyChanged += IsProcessInfoChangedHandler;
        }

        public void IsProcessInfoChangedHandler(object? sender, PropertyChangedEventArgs eventArgs)
        {
            IsPropertyChanged = true;

            ChangedPropertyName = eventArgs.PropertyName;

            if (!IsProcessInfoUpdating)
            {
                if (_IAPCWorker != null)
                {
                    _IAPCWorker._apcWorkerService_LiveDataChanged(eventArgs.PropertyName);
                }
            }

        }

        private void RaisePropertyChanged<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (oldValue != null && !oldValue.Equals(newValue))
            {
                oldValue = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //private void RaisePropertyChanged(ref int oldValue, int newValue, [CallerMemberName] string propertyName = "")
        //{
        //    if (oldValue != newValue)
        //    {
        //        oldValue = newValue;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        #region Status-Register
        private bool _isReady;
        private bool _isProcessActive;
        private bool _isEmergencyMode;
        private bool _isUpperPosition;
        private bool _isControlActive;
        private bool _isInPosition;
        private bool _isCalibrationValid;
        private bool _isCalibrationActive;
        private bool _isTactileInitPosFindEnabled;
        private bool _isLockPressureOutputActive;
        private bool _isFlameOnAtProcessEndEnabled;
        private bool _isRetractPosAtProcessEndEnabled;
        private bool _isCapSetpointFlameOffsEnabled;
        private bool _isCutO2BlowoutActive;
        private bool _isTemperProcessActive;
        private bool _isAckErrorActive;

        public bool IsReady
        {
            get { return _isReady; }
            set { RaisePropertyChanged(ref _isReady, value); }
        }
        public bool IsProcessActive
        {
            get { return _isProcessActive; }
            set { RaisePropertyChanged(ref _isProcessActive, value); }
        }
        public bool IsEmergencyMode
        {
            get { return _isEmergencyMode; }
            set { RaisePropertyChanged(ref _isEmergencyMode, value); }
        }
        public bool IsUpperPosition
        {
            get { return _isUpperPosition; }
            set { RaisePropertyChanged(ref _isUpperPosition, value); }
        }
        public bool IsControlActive
        {
            get { return _isControlActive; }
            set { RaisePropertyChanged(ref _isControlActive, value); }
        }
        public bool IsInPosition
        {
            get { return _isInPosition; }
            set { RaisePropertyChanged(ref _isInPosition, value); }
        }
        public bool IsCalibrationValid
        {
            get { return _isCalibrationValid; }
            set { RaisePropertyChanged(ref _isCalibrationValid, value); }
        }
        public bool IsCalibrationActive
        {
            get { return _isCalibrationActive; }
            set { RaisePropertyChanged(ref _isCalibrationActive, value); }
        }
        public bool IsTactileInitPosFindEnabled
        {
            get { return _isTactileInitPosFindEnabled; }
            set { RaisePropertyChanged(ref _isTactileInitPosFindEnabled, value); }
        }
        public bool IsLockPressureOutputActive
        {
            get { return _isLockPressureOutputActive; }
            set { RaisePropertyChanged(ref _isLockPressureOutputActive, value); }
        }
        public bool IsFlameOnAtProcessEndEnabled
        {
            get { return _isFlameOnAtProcessEndEnabled; }
            set { RaisePropertyChanged(ref _isFlameOnAtProcessEndEnabled, value); }
        }
        public bool IsRetractPosAtProcessEndEnabled
        {
            get { return _isRetractPosAtProcessEndEnabled; }
            set { RaisePropertyChanged(ref _isRetractPosAtProcessEndEnabled, value); }
        }
        public bool IsCapSetpointFlameOffsEnabled
        {
            get { return _isCapSetpointFlameOffsEnabled; }
            set { RaisePropertyChanged(ref _isCapSetpointFlameOffsEnabled, value); }
        }
        public bool IsCutO2BlowoutActive
        {
            get { return _isCutO2BlowoutActive; }
            set { RaisePropertyChanged(ref _isCutO2BlowoutActive, value); }
        }
        public bool IsTemperProcessActive
        {
            get { return _isTemperProcessActive; }
            set { RaisePropertyChanged(ref _isTemperProcessActive, value); }
        }
        public bool IsAckErrorActive
        {
            get { return _isAckErrorActive; }
            set { RaisePropertyChanged(ref _isAckErrorActive, value); }
        }
        #endregion // Status-Register 1


        #region HeightControl-Status
        private bool _isHeightControlActive;
        public bool IsHeightControlActive
        {
            get { return _isHeightControlActive; }
            set { RaisePropertyChanged(ref _isHeightControlActive, value); }
        }
        #endregion // Status-Register


        #region Status-Register 2
        private bool _isFlameOn;
        public bool IsFlameOn
        {
            get { return _isFlameOn; }
            set { RaisePropertyChanged(ref _isFlameOn, value); }
        }

        private bool _isClearanceControlOff;
        public bool IsClearanceControlOff
        {
            get { return _isClearanceControlOff; }
            set { RaisePropertyChanged(ref _isClearanceControlOff, value); }
        }

        private bool _isClearanceControlManual;
        public bool IsClearanceControlManual
        {
            get { return _isClearanceControlManual; }
            set { RaisePropertyChanged(ref _isClearanceControlManual, value); }
        }

        private bool _isTorchOff;
        public bool IsTorchOff
        {
            get { return _isTorchOff; }
            set { RaisePropertyChanged(ref _isTorchOff, value); }
        }

        private bool _isIgnitionDetectionEnabled;
        public bool IsIgnitionDetectionEnabled
        {
            get { return _isIgnitionDetectionEnabled; }
            set { RaisePropertyChanged(ref _isIgnitionDetectionEnabled, value); }
        }

        private bool _isPiercingSensorMode;
        public bool IsPiercingSensorMode
        {
            get { return _isPiercingSensorMode; }
            set { RaisePropertyChanged(ref _isPiercingSensorMode, value); }
        }
        #endregion // Status-Register 2


        #region Ohters
        private bool _isError;
        public bool IsError
        {
            get { return _isError; }
            set { RaisePropertyChanged(ref _isError, value); }
        }

        private bool _isCalibrationInValid;
        public bool IsCalibrationInValid
        {
            get { return _isCalibrationInValid; }
            set { RaisePropertyChanged(ref _isCalibrationInValid, value); }
        }

        private bool _isWarning;
        public bool IsWarning
        {
            get { return _isWarning; }
            set { RaisePropertyChanged(ref _isWarning, value); }
        }

        private bool _isProcessInActive;
        public bool IsProcessInActive
        {
            get { return _isProcessInActive; }
            set { RaisePropertyChanged(ref _isProcessInActive, value); }
        }

        private bool _isEnabledTestPressureOut;
        public bool IsEnabledTestPressureOut
        {
            get { return _isEnabledTestPressureOut; }
            set { RaisePropertyChanged(ref _isEnabledTestPressureOut, value); }
        }

        private bool _isEnabledManDown;
        public bool IsEnabledManDown
        {
            get { return _isEnabledManDown; }
            set { RaisePropertyChanged(ref _isEnabledManDown, value); }
        }

        private bool _isEnabledHeightControlOff;
        public bool IsEnabledHeightControlOff
        {
            get { return _isEnabledHeightControlOff; }
            set { RaisePropertyChanged(ref _isEnabledHeightControlOff, value); }
        }
        #endregion // Ohters


        #region Status-Inputs
        private bool _isInpManUp;
        public bool IsInpManUp
        {
            get { return _isInpManUp; }
            set { RaisePropertyChanged(ref _isInpManUp, value); }
        }

        private bool _isInpManDown;
        public bool IsInpManDown
        {
            get { return _isInpManDown; }
            set { RaisePropertyChanged(ref _isInpManDown, value); }
        }

        private bool _isInpAutomatic;
        public bool IsInpAutomatic
        {
            get { return _isInpAutomatic; }
            set { RaisePropertyChanged(ref _isInpAutomatic, value); }
        }

        private bool _isInpStartProcess;
        public bool IsInpStartProcess
        {
            get { return _isInpStartProcess; }
            set { RaisePropertyChanged(ref _isInpStartProcess, value); }
        }

        private bool _isInpIgnite;
        public bool IsInpIgnite
        {
            get { return _isInpIgnite; }
            set { RaisePropertyChanged(ref _isInpIgnite, value); }
        }

        private bool _isInpTorchDisabled;
        public bool IsInpTorchDisabled
        {
            get { return _isInpTorchDisabled; }
            set { RaisePropertyChanged(ref _isInpTorchDisabled, value); }
        }

        private bool _isInpClearanceCtrlOff;
        public bool IsInpClearanceCtrlOff
        {
            get { return _isInpClearanceCtrlOff; }
            set { RaisePropertyChanged(ref _isInpClearanceCtrlOff, value); }
        }

        private bool _isInpStopHeating;
        public bool IsInpStopHeating
        {
            get { return _isInpStopHeating; }
            set { RaisePropertyChanged(ref _isInpStopHeating, value); }
        }

        private bool _isInputCuSync;
        public bool IsInputCuSync
        {
            get { return _isInputCuSync; }
            set { RaisePropertyChanged(ref _isInputCuSync, value); }
        }

        private bool _isInputClearanceSignalAdjust;
        public bool IsInputClearanceSignalAdjust
        {
            get { return _isInputClearanceSignalAdjust; }
            set { RaisePropertyChanged(ref _isInputClearanceSignalAdjust, value); }
        }
        #endregion // Status-Inputs


        #region Status-Outputs
        private bool _isOutputFault;
        public bool IsOutputFault
        {
            get { return _isOutputFault; }
            set { RaisePropertyChanged(ref _isOutputFault, value); }
        }

        private bool _isOutputInPosition;
        public bool IsOutputInPosition
        {
            get { return _isOutputInPosition; }
            set { RaisePropertyChanged(ref _isOutputInPosition, value); }
        }

        private bool _isOutputUpperPosition;
        public bool IsOutputUpperPosition
        {
            get { return _isOutputUpperPosition; }
            set { RaisePropertyChanged(ref _isOutputUpperPosition, value); }
        }

        private bool _isOutputOk2Move;
        public bool IsOutputOk2Move
        {
            get { return _isOutputOk2Move; }
            set { RaisePropertyChanged(ref _isOutputOk2Move, value); }
        }

        private bool _isOutputSlowSpeed;
        public bool IsOutputSlowSpeed
        {
            get { return _isOutputSlowSpeed; }
            set { RaisePropertyChanged(ref _isOutputSlowSpeed, value); }
        }

        private bool _isOutputFit3_InputIgnition;
        public bool IsOutputFit3_InputIgnition
        {
            get { return _isOutputFit3_InputIgnition; }
            set { RaisePropertyChanged(ref _isOutputFit3_InputIgnition, value); }
        }

        private bool _isOutputFit3_SolenoidValve;
        public bool IsOutputFit3_SolenoidValve
        {
            get { return _isOutputFit3_SolenoidValve; }
            set { RaisePropertyChanged(ref _isOutputFit3_SolenoidValve, value); }
        }

        private bool _isOutputFit3_GlowPlug;
        public bool IsOutputFit3_GlowPlug
        {
            get { return _isOutputFit3_GlowPlug; }
            set { RaisePropertyChanged(ref _isOutputFit3_GlowPlug, value); }
        }

        private bool _isOutputFit3_FlameFlashback;
        public bool IsOutputFit3_FlameFlashback
        {
            get { return _isOutputFit3_FlameFlashback; }
            set { RaisePropertyChanged(ref _isOutputFit3_FlameFlashback, value); }
        }

        private bool _isOutputFit3_Error;
        public bool IsOutputFit3_Error
        {
            get { return _isOutputFit3_Error; }
            set { RaisePropertyChanged(ref _isOutputFit3_Error, value); }
        }

        private bool _isOutputFit3_ErrUB24V;
        public bool IsOutputFit3_ErrUB24V
        {
            get { return _isOutputFit3_ErrUB24V; }
            set { RaisePropertyChanged(ref _isOutputFit3_ErrUB24V, value); }
        }

        private bool _isOutputFit3_ErrucTemperature;
        public bool IsOutputFit3_ErrucTemperature
        {
            get { return _isOutputFit3_ErrucTemperature; }
            set { RaisePropertyChanged(ref _isOutputFit3_ErrucTemperature, value); }
        }

        private bool _isOutputFit3_ErrSolenoidValve;
        public bool IsOutputFit3_ErrSolenoidValve
        {
            get { return _isOutputFit3_ErrSolenoidValve; }
            set { RaisePropertyChanged(ref _isOutputFit3_ErrSolenoidValve, value); }
        }

        private bool _isOutputFit3_ErrGlowPlug;
        public bool IsOutputFit3_ErrGlowPlug
        {
            get { return _isOutputFit3_ErrGlowPlug; }
            set { RaisePropertyChanged(ref _isOutputFit3_ErrGlowPlug, value); }
        }

        private bool _isOutputFit3_ErrCommunic;
        public bool IsOutputFit3_ErrCommunic
        {
            get { return _isOutputFit3_ErrCommunic; }
            set { RaisePropertyChanged(ref _isOutputFit3_ErrCommunic, value); }
        }
        #endregion // StatusOutputs


        #region StatusLeds
        private bool _isLedIgnition;
        public bool IsLedIgnition
        {
            get { return _isLedIgnition; }
            set { RaisePropertyChanged(ref _isLedIgnition, value); }
        }

        private bool _isLedPreHeating;
        public bool IsLedPreHeating
        {
            get { return _isLedPreHeating; }
            set { RaisePropertyChanged(ref _isLedPreHeating, value); }
        }

        private bool _isLedPiercing;
        public bool IsLedPiercing
        {
            get { return _isLedPiercing; }
            set { RaisePropertyChanged(ref _isLedPiercing, value); }
        }

        private bool _isLedCutting;
        public bool IsLedCutting
        {
            get { return _isLedCutting; }
            set { RaisePropertyChanged(ref _isLedCutting, value); }
        }

        private bool _isLedTemper;
        public bool IsLedTemper
        {
            get { return _isLedTemper; }
            set { RaisePropertyChanged(ref _isLedTemper, value); }
        }

        private bool _isLedCutO2Blowout;
        public bool IsLedCutO2Blowout
        {
            get { return _isLedCutO2Blowout; }
            set { RaisePropertyChanged(ref _isLedCutO2Blowout, value); }
        }

        private bool _isLedRetractPosition;
        public bool IsLedRetractPosition
        {
            get { return _isLedRetractPosition; }
            set { RaisePropertyChanged(ref _isLedRetractPosition, value); }
        }

        private bool _isLedUpperPosition;
        public bool IsLedUpperPosition
        {
            get { return _isLedUpperPosition; }
            set { RaisePropertyChanged(ref _isLedUpperPosition, value); }
        }

        private bool _isLedError;
        public bool IsLedError
        {
            get { return _isLedError; }
            set { RaisePropertyChanged(ref _isLedError, value); }
        }
        #endregion // StatusLeds


        /// <summary>
        /// 
        /// </summary>
        internal void UpdateDatas(IhtModbusData ihtModbusData)
        {
            #region ProcessInfo-Daten

            IsPropertyChanged = false;
            IsProcessInfoUpdating = true;

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
            CurrCutCycleState    = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrCutCycleState);
            
            int value = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrUB24V);
            value /= 10;
            CurrUB24V = value * 10;

            UB24VMin = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.UB24VMin);
            UB24VMax = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.UB24VMax);
            LinearDrivePosition = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.LinearDrivePosition);
            IgnitionFlameAdjustParamDisabled = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.IgnitionFlameAdjustParamDisabled);
            CurrCutO2BlowoutTime = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrCutO2BlowoutTime);
            CurrSetupExecSetup = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrSetupExecSetup);
            CurrSetupExecTestPressureOut = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrSetupExecTestPressureOut);
            CurrPasswordLevel = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrPasswordLevel);

            value = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.ClearanceOut_digit);
            value /= 10;
            ClearanceOut_digit = value * 10;

            value = (ihtModbusData == null) ? 0 : ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.ClearanceOut_mV);
            value /= 10;
            ClearanceOut_mV = value * 10;
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
                _IAPCWorker._apcWorkerService_LiveDataChanged(ChangedPropertyName);
            }

            IsProcessInfoUpdating = false;
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
