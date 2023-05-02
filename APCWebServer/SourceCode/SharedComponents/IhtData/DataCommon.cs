using SharedComponents.IhtModbus;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SharedComponents.IhtData
{
#if false
  public class DataCommon : INotifyPropertyChanged
    {
        private int _currOutHeatO2;
        public int CurrOutHeatO2
        {
            get { return _currOutHeatO2; }
            set { RaisePropertyChanged(ref _currOutHeatO2, value); }
        }

        private int _currOutCutO2;
        public int CurrOutCutO2
        {
            get { return _currOutCutO2; }
            set { RaisePropertyChanged(ref _currOutCutO2, value); }
        }

        private int _currOutFuelGas;
        public int CurrOutFuelGas
        {
            get { return _currOutFuelGas; }
            set { RaisePropertyChanged(ref _currOutFuelGas, value); }
        }

        private int _currHeatTime;
        public int CurrHeatTime
        {
            get { return _currHeatTime; }
            set { RaisePropertyChanged(ref _currHeatTime, value); }
        }

        private int _preHeatTime;
        public int PreHeatTime
        {
            get { return _preHeatTime; }
            set { RaisePropertyChanged(ref _preHeatTime, value); }
        }

        private int _preHeatTimeMin;
        public int PreHeatTimeMin
        {
            get { return _preHeatTimeMin; }
            set { RaisePropertyChanged(ref _preHeatTimeMin, value); }
        }

        private int _preHeatTimeMax;
        public int PreHeatTimeMax
        {
            get { return _preHeatTimeMax; }
            set { RaisePropertyChanged(ref _preHeatTimeMax, value); }
        }

        private int _preHeatTimeStep;
        public int PreHeatTimeStep
        {
            get { return _preHeatTimeStep; }
            set { RaisePropertyChanged(ref _preHeatTimeStep, value); }
        }

        private int _currPasswordLevel;
        public int CurrPasswordLevel
        {
            get { return _currPasswordLevel; }
            set { RaisePropertyChanged(ref _currPasswordLevel, value); }
        }

        private bool _isHeightControlActive;
        public bool IsHeightControlActive
        {
            get { return _isHeightControlActive; }
            set { RaisePropertyChanged(ref _isHeightControlActive, value); }
        }

        private bool _isProcessActive;
        public bool IsProcessActive
        {
            get { return _isProcessActive; }
            set { RaisePropertyChanged(ref _isProcessActive, value); }
        }

        private bool _isAckErrorActive;
        public bool IsAckErrorActive
        {
            get { return _isAckErrorActive; }
            set { RaisePropertyChanged(ref _isAckErrorActive, value); }
        }

        private bool _isEnabledManDown;
        public bool IsEnabledManDown
        {
            get { return _isEnabledManDown; }
            set { RaisePropertyChanged(ref _isEnabledManDown, value); }
        }

        #region StatusLeds
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
        #endregion // StatusLeds

        private bool _isPropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public DataCommon()
        {
          PropertyChanged += IsProcessInfoChangedHandler;
        }

        public void IsProcessInfoChangedHandler(object? sender, PropertyChangedEventArgs eventArgs)
        {
          _isPropertyChanged = true;
        }

        // Helper-Methode, um nicht in jedem Set-Accessor zu prüfen, ob PropertyRaisePropertyChanged!=null
        private void RaisePropertyChanged<T>(ref T oldValue, T newValue, [CallerMemberName] string propertyName = "")
        {
          if (oldValue != null && !oldValue.Equals(newValue))
          {
            oldValue = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
          }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool UpdateDatas(IhtModbusData ihtModbusData)
        {
            _isPropertyChanged = false;

            CurrOutHeatO2 = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrOutHeatO2) : 0;
            CurrOutCutO2 = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrOutCutO2) : 0;
            CurrOutFuelGas = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrOutFuelGas) : 0;
            CurrHeatTime = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrHeatTime) : 0;
            CurrPasswordLevel = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.CurrPasswordLevel) : 0;

            #region StatusLeds
            UInt16 StatusLeds = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.StatusLeds) : (UInt16)0;
            IsLedPreHeating = (StatusLeds & (int)IhtModbusParamDyn.eStatusLedBit.PreHeating) != 0 ? true : false;
            IsLedPiercing = (StatusLeds & (int)IhtModbusParamDyn.eStatusLedBit.Piercing) != 0 ? true : false;
            IsLedCutting = (StatusLeds & (int)IhtModbusParamDyn.eStatusLedBit.Cutting) != 0 ? true : false;
            #endregion // StatusLeds

            #region Status-Inputs
            UInt16 StatusInputs = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.StatusInputs) : (UInt16)0;
            bool IsInpClearanceCtrlOff = (StatusInputs & (int)IhtModbusParamDyn.eStatusInpBit.ClearanceCtrlOff) != 0 ? true : false;
            #endregion // Status-Inputs

            #region HeightControl-Status
            UInt16 StatusHeightControl = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.StatusHeightControl) : (UInt16)0;
            //    IsHeightControlActive      = (StatusHeightControl != (int)IhtModbusParamDyn.eStatusHeightCtrl.Off);
            IsHeightControlActive = (StatusHeightControl != (int)IhtModbusParamDyn.eStatusHeightCtrl.Off) && !IsInpClearanceCtrlOff;
            #endregion // HeightControl-Status

            UInt16 Status = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.Status) : (UInt16)0;
            IsProcessActive = (Status & (int)IhtModbusParamDyn.eStatusBit.ProcessActive) != 0 ? true : false;
            IsAckErrorActive = (Status & (int)IhtModbusParamDyn.eStatusBit.AckErrorActive) != 0 ? true : false;

            #region Status-Register 2
            UInt16 Status2 = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcessInfo.Status2) : (UInt16)0;
            bool IsFlameOn = (Status2 & (int)IhtModbusParamDyn.eStatus2Bit.FlameOn) != 0 ? true : false;
            bool IsClearanceControlOff = (Status2 & (int)IhtModbusParamDyn.eStatus2Bit.ClearanceControlOff) != 0 ? true : false;
            bool IsClearanceControlManual = (Status2 & (int)IhtModbusParamDyn.eStatus2Bit.ClearanceControlManual) != 0 ? true : false;
            #endregion // Status-Register 2

            #region Ohters
            IsEnabledManDown = ((IsHeightControlActive || IsProcessActive)
                                  && !IsClearanceControlOff
                                  && !IsInpClearanceCtrlOff
                                  && !IsClearanceControlManual
                                ) ? false : true;
            #endregion Ohters

            PreHeatTime = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PreHeatTime) : 0;
            PreHeatTimeMin = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PreHeatTimeMin) : 0;
            PreHeatTimeMax = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PreHeatTimeMax) : 0;
            PreHeatTimeStep = ihtModbusData != null ? ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PreHeatTimeStep) : 0;
            
            return _isPropertyChanged;
        }
    }
#endif
}
