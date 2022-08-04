using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtData
{
    public class DataParamDynProcess : INotifyPropertyChanged
    {
        private int _retractHeight { get; set; }
        private int _SlagSensitivity { get; set; }
        private int _heatO2Temper { get; set; }
        private int _fuelGasTemper { get; set; }
        private int _heightTemper { get; set; }
        private int _linearDriveManualPosSpeed { get; set; }
        private int _fuelGasOffset { get; set; }
        private int _flashbackSensivitity { get; set; }
        #region Slag
        private int _slagIntervalTime { get; set; }
        private int _slagFirstSlagTime { get; set; }
        private int _slagSecurityTime { get; set; }
        private int _slagPostTime { get; set; }
        private int _slagActiveGradient { get; set; }
        private int _slagInActiveGradient { get; set; }
        #endregion // Slag
        private int _ignitonDetectionEnable { get; set; }
        private int _piercingSensorMode { get; set; }

        public int RetractHeight
        {
            get { return _retractHeight; }
            set { _retractHeight = value; RaisePropertyChanged("RetractHeight"); }
        }

        public int SlagSensitivity
        {
            get { return _SlagSensitivity; }
            set { _SlagSensitivity = value; RaisePropertyChanged("SlagSensitivity"); }
        }

        public int HeatO2Temper
        {
            get { return _heatO2Temper; }
            set { _heatO2Temper = value; RaisePropertyChanged("HeatO2Temper"); }
        }

        public int FuelGasTemper
        {
            get { return _fuelGasTemper; }
            set { _fuelGasTemper = value; RaisePropertyChanged("HeatO2Temper"); }
        }

        public int HeightTemper
        {
            get { return _heightTemper; }
            set { _heightTemper = value; RaisePropertyChanged("HeightTemper"); }
        }

        public int LinearDriveManualPosSpeed
        {
            get { return _linearDriveManualPosSpeed; }
            set { _linearDriveManualPosSpeed = value; RaisePropertyChanged("LinearDriveManualPosSpeed"); }
        }

        public int FuelGasOffset
        {
            get { return _fuelGasOffset; }
            set { _fuelGasOffset = value; RaisePropertyChanged("FuelGasOffset"); }
        }

        public int FlashbackSensivitity
        {
            get { return _flashbackSensivitity; }
            set { _flashbackSensivitity = value; RaisePropertyChanged("FlashbackSensivitity"); }
        }

        #region Slag
        public int SlagIntervalTime
        {
            get { return _slagIntervalTime; }
            set { _slagIntervalTime = value; RaisePropertyChanged("SlagIntervalTime"); }
        }
        public int SlagFirstSlagTime
        {
            get { return _slagFirstSlagTime; }
            set { _slagFirstSlagTime = value; RaisePropertyChanged("SlagFirstSlagTime"); }
        }
        public int SlagSecurityTime
        {
            get { return _slagSecurityTime; }
            set { _slagSecurityTime = value; RaisePropertyChanged("SlagSecurityTime"); }
        }
        public int SlagPostTime
        {
            get { return _slagPostTime; }
            set { _slagPostTime = value; RaisePropertyChanged("SlagPostTime"); }
        }
        public int SlagActiveGradient
        {
            get { return _slagActiveGradient; }
            set { _slagActiveGradient = value; RaisePropertyChanged("SlagActiveGradient"); }
        }
        public int SlagInActiveGradient
        {
            get { return _slagInActiveGradient; }
            set { _slagInActiveGradient = value; RaisePropertyChanged("SlagInActiveGradient"); }
        }
        #endregion // Slag

        public int IgnitonDetectionEnable
        {
            get { return _ignitonDetectionEnable; }
            set { _ignitonDetectionEnable = value; RaisePropertyChanged("IgnitonDetectionEnable"); }
        }

        public int PiercingSensorMode
        {
            get { return _piercingSensorMode; }
            set { _piercingSensorMode = value; RaisePropertyChanged("PiercingSensorMode"); }
        }

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
            RetractHeight = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.HeatO2Temper);
            FuelGasTemper = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.FuelGasTemper);
            HeightTemper = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.HeightTemper);
            LinearDriveManualPosSpeed = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.LinearDriveManualPosSpeed);
            FuelGasOffset = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.FuelGasOffset);
            FlashbackSensivitity = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.FlashbackSensivitity);
            #region Slag
            SlagIntervalTime = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.SlagIntervalTime);
            SlagFirstSlagTime = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.SlagFirstSlagTime);
            SlagSecurityTime = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.SlagSecurityTime);
            SlagPostTime = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.SlagPostTime);
            SlagActiveGradient = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.SlagActiveGradient);
            SlagInActiveGradient = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.SlagInActiveGradient);
            #endregion // Slag
            IgnitonDetectionEnable = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.IgnitionDetectionEnable);
            IgnitonDetectionEnable = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxProcess.PiercingSensorMode);
        }
    }
}
