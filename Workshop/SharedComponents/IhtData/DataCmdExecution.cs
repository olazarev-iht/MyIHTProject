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
    public class DataCmdExecution : INotifyPropertyChanged
    {

        private int _tactile { get; set; }
        public int Tactile
        {
            get { return _tactile; }
            set { _tactile = value; RaisePropertyChanged("Tactile"); }
        }

        private int _switch { get; set; }
        public int Switch
        {
            get { return _switch; }
            set { _switch = value; RaisePropertyChanged("Switch"); }
        }

        private int _heightCtrl { get; set; }
        public int HeightCtrl
        {
            get { return _heightCtrl; }
            set { _heightCtrl = value; RaisePropertyChanged("HeightCtrl"); }
        }

        private int _inputEmulation { get; set; }
        public int InputEmulation
        {
            get { return _inputEmulation; }
            set { _inputEmulation = value; RaisePropertyChanged("InputEmulation"); }
        }

        private int _inputEmulation_2 { get; set; }
        public int InputEmulation_2
        {
            get { return _inputEmulation_2; }
            set { _inputEmulation_2 = value; RaisePropertyChanged("InputEmulation_2"); }
        }

        #region Switch
        private bool _isLockPressureOutput { get; set; }
        public bool IsLockPressureOutput
        {
            get { return _isLockPressureOutput; }
            set { _isLockPressureOutput = value; RaisePropertyChanged("IsLockPressureOutput"); }
        }

        private bool _isFlameOnAtProcessEnd { get; set; }
        public bool IsFlameOnAtProcessEnd
        {
            get { return _isFlameOnAtProcessEnd; }
            set { _isFlameOnAtProcessEnd = value; RaisePropertyChanged("IsFlameOnAtProcessEnd"); }
        }

        private bool _isRetractPosAtProcessEnd { get; set; }
        public bool IsRetractPosAtProcessEnd
        {
            get { return _isRetractPosAtProcessEnd; }
            set { _isRetractPosAtProcessEnd = value; RaisePropertyChanged("IsRetractPosAtProcessEnd"); }
        }

        private bool _isTemper { get; set; }
        public bool IsTemper
        {
            get { return _isTemper; }
            set { _isTemper = value; RaisePropertyChanged("IsTemper"); }
        }

        public bool IsTorchUpActive { get; set; }
        public bool IsTorchDownActive { get; set; }
        public bool IsCalibrationActive { get; set; }
        public bool IsStartPiercingActive { get; set; }
        public bool IsReloadPreHeatingTimeActive { get; set; }
        public bool IsHCTorchUpActive { get; set; }
        public bool IsHCTorchDownActive { get; set; }
        public bool IsFlameOnEndActive { get; set; }
        public bool IsFlameOn { get; set; }
        #endregion // Switch

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
        internal void UpdateDatas(IhtModbusData ihtModbusData)
        {
            Tactile = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxCmdExec.Tactile);
            Switch = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxCmdExec.Switch);
            HeightCtrl = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxCmdExec.HeightCtrl);
            InputEmulation = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxCmdExec.InputEmulation);
            InputEmulation_2 = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxCmdExec.InputEmulation_2);

            #region Switch
            IsLockPressureOutput = (Switch & (int)IhtModbusCmdExecSwitch.eCmdBit.LockPressureOutput) != 0 ? true : false;
            IsFlameOnAtProcessEnd = (Switch & (int)IhtModbusCmdExecSwitch.eCmdBit.FlameOnAtProcessEnd) != 0 ? true : false;
            IsRetractPosAtProcessEnd = (Switch & (int)IhtModbusCmdExecSwitch.eCmdBit.RetractPosAtProcessEnd) != 0 ? true : false;
            IsTemper = (Switch & (int)IhtModbusCmdExecSwitch.eCmdBit.Temper) != 0 ? true : false;
            #endregion // Switch
        }

    }
}
