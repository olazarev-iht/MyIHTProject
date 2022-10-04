using SharedComponents.IhtModbus;
using SharedComponents.IhtModbusCmd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtData
{
    public class DataCommon : INotifyPropertyChanged
    {
        private int _currOutHeatO2 { get; set; }
        public int CurrOutHeatO2
        {
            get { return _currOutHeatO2; }
            set { _currOutHeatO2 = value; RaisePropertyChanged("CurrOutHeatO2"); }
        }

        private int _currOutCutO2 { get; set; }
        public int CurrOutCutO2
        {
            get { return _currOutCutO2; }
            set { _currOutCutO2 = value; RaisePropertyChanged("CurrOutCutO2"); }
        }

        private int _currOutFuelGas { get; set; }
        public int CurrOutFuelGas
        {
            get { return _currOutFuelGas; }
            set { _currOutFuelGas = value; RaisePropertyChanged("CurrOutFuelGas"); }
        }

        private int _currHeatTime { get; set; }
        public int CurrHeatTime
        {
            get { return _currHeatTime; }
            set { _currHeatTime = value; RaisePropertyChanged("CurrHeatTime"); }
        }

        private int _preHeatTime { get; set; }
        public int PreHeatTime
        {
            get { return _preHeatTime; }
            set { _preHeatTime = value; RaisePropertyChanged("PreHeatTime"); }
        }

        private int _preHeatTimeMin { get; set; }
        public int PreHeatTimeMin
        {
            get { return _preHeatTimeMin; }
            set { _preHeatTimeMin = value; RaisePropertyChanged("PreHeatTimeMin"); }
        }
        private int _preHeatTimeMax { get; set; }
        public int PreHeatTimeMax
        {
            get { return _preHeatTimeMax; }
            set { _preHeatTimeMax = value; RaisePropertyChanged("PreHeatTimeMax"); }
        }
        private int _preHeatTimeStep { get; set; }
        public int PreHeatTimeStep
        {
            get { return _preHeatTimeStep; }
            set { _preHeatTimeStep = value; RaisePropertyChanged("PreHeatTimeStep"); }
        }

        private int _currPasswordLevel { get; set; }
        public int CurrPasswordLevel
        {
            get { return _currPasswordLevel; }
            set { _currPasswordLevel = value; RaisePropertyChanged("CurrPasswordLevel"); }
        }

        private bool _isHeightControlActive { get; set; }
        public bool IsHeightControlActive
        {
            get { return _isHeightControlActive; }
            set { _isHeightControlActive = value; RaisePropertyChanged("IsHeightControlActive"); }
        }

        private bool _isProcessActive { get; set; }
        public bool IsProcessActive
        {
            get { return _isProcessActive; }
            set { _isProcessActive = value; RaisePropertyChanged("IsProcessActive"); }
        }

        private bool _isAckErrorActive { get; set; }
        public bool IsAckErrorActive
        {
            get { return _isAckErrorActive; }
            set { _isAckErrorActive = value; RaisePropertyChanged("IsAckErrorActive"); }
        }

        private bool _isEnabledManDown { get; set; }
        public bool IsEnabledManDown
        {
            get { return _isEnabledManDown; }
            set { _isEnabledManDown = value; RaisePropertyChanged("IsEnabledManDown"); }
        }

        #region StatusLeds
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
        #endregion // StatusLeds

        // Helper-Methode, um nicht in jedem Set-Accessor zu prüfen, ob PropertyRaisePropertyChanged!=null
        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// 
        /// </summary>
        public void UpdateDatas(IhtModbusData ihtModbusData)
        {
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
        }
    }
}
