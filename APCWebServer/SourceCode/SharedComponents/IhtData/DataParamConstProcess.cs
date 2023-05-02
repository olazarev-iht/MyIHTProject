using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtData
{
    public class DataParamConstProcess : INotifyPropertyChanged
    {
        private int _retractHeightMin { get; set; }
        private int _retractHeightMax { get; set; }
        private int _retractHeightStep { get; set; }

        private int _SlagSensitivityMin { get; set; }
        private int _SlagSensitivityMax { get; set; }
        private int _SlagSensitivityStep { get; set; }

        private int _heatO2TemperMin { get; set; }
        private int _heatO2TemperMax { get; set; }
        private int _heatO2TemperStep { get; set; }

        private int _fuelGasTemperMin { get; set; }
        private int _fuelGasTemperMax { get; set; }
        private int _fuelGasTemperStep { get; set; }

        private int _heightTemperMin { get; set; }
        private int _heightTemperMax { get; set; }
        private int _heightTemperStep { get; set; }

        private int _linearDriveManualPosSpeedMin { get; set; }
        private int _linearDriveManualPosSpeedMax { get; set; }
        private int _linearDriveManualPosSpeedStep { get; set; }

        private int _fuelGasOffsetMin { get; set; }
        private int _fuelGasOffsetMax { get; set; }
        private int _fuelGasOffsetStep { get; set; }

        private int _flashbackSensivitityMin { get; set; }
        private int _flashbackSensivitityMax { get; set; }
        private int _flashbackSensivitityStep { get; set; }

        private int _ignitonDetectionEnableMin { get; set; }
        private int _ignitonDetectionEnableMax { get; set; }
        private int _ignitonDetectionEnableStep { get; set; }

        #region Slag
        private int _slagIntervalTimeMin { get; set; }
        private int _slagIntervalTimeMax { get; set; }
        private int _slagIntervalTimeStep { get; set; }

        private int _slagFirstSlagTimeMin { get; set; }
        private int _slagFirstSlagTimeMax { get; set; }
        private int _slagFirstSlagTimeStep { get; set; }

        private int _slagSecurityTimeMin { get; set; }
        private int _slagSecurityTimeMax { get; set; }
        private int _slagSecurityTimeStep { get; set; }

        private int _slagPostTimeMin { get; set; }
        private int _slagPostTimeMax { get; set; }
        private int _slagPostTimeStep { get; set; }

        private int _slagActiveGradientMin { get; set; }
        private int _slagActiveGradientMax { get; set; }
        private int _slagActiveGradientStep { get; set; }

        private int _slagInActiveGradientMin { get; set; }
        private int _slagInActiveGradientMax { get; set; }
        private int _slagInActiveGradientStep { get; set; }
        #endregion // Slag


        #region RetractHeight
        public int RetractHeightMin
        {
            get { return _retractHeightMin; }
            set { _retractHeightMin = value; RaisePropertyChanged("RetractHeightMin"); }
        }
        public int RetractHeightMax
        {
            get { return _retractHeightMax; }
            set { _retractHeightMax = value; RaisePropertyChanged("RetractHeightMax"); }
        }
        public int RetractHeightStep
        {
            get { return _retractHeightStep; }
            set { _retractHeightStep = value; RaisePropertyChanged("RetractHeightStep"); }
        }
        #endregion // RetractHeight

        #region SlagSensitivity
        public int SlagSensitivityMin
        {
            get { return _SlagSensitivityMin; }
            set { _SlagSensitivityMin = value; RaisePropertyChanged("SlagSensitivityMin"); }
        }
        public int SlagSensitivityMax
        {
            get { return _SlagSensitivityMax; }
            set { _SlagSensitivityMax = value; RaisePropertyChanged("SlagSensitivityMax"); }
        }
        public int SlagSensitivityStep
        {
            get { return _SlagSensitivityStep; }
            set { _SlagSensitivityStep = value; RaisePropertyChanged("SlagSensitivityStep"); }
        }
        #endregion // SlagSensitivity

        #region HeatO2Temper
        public int HeatO2TemperMin
        {
            get { return _heatO2TemperMin; }
            set { _heatO2TemperMin = value; RaisePropertyChanged("HeatO2TemperMin"); }
        }
        public int HeatO2TemperMax
        {
            get { return _heatO2TemperMax; }
            set { _heatO2TemperMax = value; RaisePropertyChanged("HeatO2TemperMax"); }
        }
        public int HeatO2TemperStep
        {
            get { return _heatO2TemperStep; }
            set { _heatO2TemperStep = value; RaisePropertyChanged("HeatO2TemperStep"); }
        }
        #endregion // HeatO2Temper

        #region FuelGasTemper
        public int FuelGasTemperMin
        {
            get { return _fuelGasTemperMin; }
            set { _fuelGasTemperMin = value; RaisePropertyChanged("HeatO2TemperMin"); }
        }
        public int FuelGasTemperMax
        {
            get { return _fuelGasTemperMax; }
            set { _fuelGasTemperMax = value; RaisePropertyChanged("FuelGasTemperMax"); }
        }
        public int FuelGasTemperStep
        {
            get { return _fuelGasTemperStep; }
            set { _fuelGasTemperStep = value; RaisePropertyChanged("FuelGasTemperStep"); }
        }
        #endregion // FuelGasTemper

        #region HeightTemper
        public int HeightTemperMin
        {
            get { return _heightTemperMin; }
            set { _heightTemperMin = value; RaisePropertyChanged("HeightTemperMin"); }
        }
        public int HeightTemperMax
        {
            get { return _heightTemperMax; }
            set { _heightTemperMax = value; RaisePropertyChanged("HeightTemperMax"); }
        }
        public int HeightTemperStep
        {
            get { return _heightTemperStep; }
            set { _heightTemperStep = value; RaisePropertyChanged("HeightTemperStep"); }
        }
        #endregion // HeightTemper

        #region LinearDriveManualPosSpeed
        public int LinearDriveManualPosSpeedMin
        {
            get { return _linearDriveManualPosSpeedMin; }
            set { _linearDriveManualPosSpeedMin = value; RaisePropertyChanged("LinearDriveManualPosSpeedMin"); }
        }
        public int LinearDriveManualPosSpeedMax
        {
            get { return _linearDriveManualPosSpeedMax; }
            set { _linearDriveManualPosSpeedMax = value; RaisePropertyChanged("LinearDriveManualPosSpeedMax"); }
        }
        public int LinearDriveManualPosSpeedStep
        {
            get { return _linearDriveManualPosSpeedStep; }
            set { _linearDriveManualPosSpeedStep = value; RaisePropertyChanged("LinearDriveManualPosSpeedStep"); }
        }
        #endregion // LinearDriveManualPosSpeed

        #region FuelGasOffset
        public int FuelGasOffsetMin
        {
            get { return _fuelGasOffsetMin; }
            set { _fuelGasOffsetMin = value; RaisePropertyChanged("FuelGasOffsetMin"); }
        }
        public int FuelGasOffsetMax
        {
            get { return _fuelGasOffsetMax; }
            set { _fuelGasOffsetMax = value; RaisePropertyChanged("FuelGasOffsetMax"); }
        }
        public int FuelGasOffsetStep
        {
            get { return _fuelGasOffsetStep; }
            set { _fuelGasOffsetStep = value; RaisePropertyChanged("FuelGasOffsetStep"); }
        }
        #endregion // FuelGasOffset

        #region FlashbackSensivitity
        public int FlashbackSensivitityMin
        {
            get { return _flashbackSensivitityMin; }
            set { _flashbackSensivitityMin = value; RaisePropertyChanged("FlashbackSensivitityMin"); }
        }
        public int FlashbackSensivitityMax
        {
            get { return _flashbackSensivitityMax; }
            set { _flashbackSensivitityMax = value; RaisePropertyChanged("FlashbackSensivitityMax"); }
        }
        public int FlashbackSensivitityStep
        {
            get { return _flashbackSensivitityStep; }
            set { _flashbackSensivitityStep = value; RaisePropertyChanged("FlashbackSensivitityStep"); }
        }
        #endregion // FlashbackSensivitity

        #region Slag
        public int SlagIntervalTimeMin
        {
            get { return _slagIntervalTimeMin; }
            set { _slagIntervalTimeMin = value; RaisePropertyChanged("SlagIntervalTimeMin"); }
        }
        public int SlagIntervalTimeMax
        {
            get { return _slagIntervalTimeMax; }
            set { _slagIntervalTimeMax = value; RaisePropertyChanged("SlagIntervalTimeMax"); }
        }
        public int SlagIntervalTimeStep
        {
            get { return _slagIntervalTimeStep; }
            set { _slagIntervalTimeStep = value; RaisePropertyChanged("SlagIntervalTimeStep"); }
        }

        public int SlagFirstSlagTimeMin
        {
            get { return _slagFirstSlagTimeMin; }
            set { _slagFirstSlagTimeMin = value; RaisePropertyChanged("SlagFirstSlagTimeMin"); }
        }
        public int SlagFirstSlagTimeMax
        {
            get { return _slagFirstSlagTimeMax; }
            set { _slagFirstSlagTimeMax = value; RaisePropertyChanged("SlagFirstSlagTimeMax"); }
        }
        public int SlagFirstSlagTimeStep
        {
            get { return _slagFirstSlagTimeStep; }
            set { _slagFirstSlagTimeStep = value; RaisePropertyChanged("SlagFirstSlagTimeStep"); }
        }

        public int SlagSecurityTimeMin
        {
            get { return _slagSecurityTimeMin; }
            set { _slagSecurityTimeMin = value; RaisePropertyChanged("SlagSecurityTimeMin"); }
        }
        public int SlagSecurityTimeMax
        {
            get { return _slagSecurityTimeMax; }
            set { _slagSecurityTimeMax = value; RaisePropertyChanged("SlagSecurityTimeMax"); }
        }
        public int SlagSecurityTimeStep
        {
            get { return _slagSecurityTimeStep; }
            set { _slagSecurityTimeStep = value; RaisePropertyChanged("SlagSecurityTimeStep"); }
        }

        public int SlagPostTimeMin
        {
            get { return _slagPostTimeMin; }
            set { _slagPostTimeMin = value; RaisePropertyChanged("SlagPostTimeMin"); }
        }
        public int SlagPostTimeMax
        {
            get { return _slagPostTimeMax; }
            set { _slagPostTimeMax = value; RaisePropertyChanged("SlagPostTimeMax"); }
        }
        public int SlagPostTimeStep
        {
            get { return _slagPostTimeStep; }
            set { _slagPostTimeMax = value; RaisePropertyChanged("SlagPostTimeStep"); }
        }

        public int SlagActiveGradientMin
        {
            get { return _slagActiveGradientMin; }
            set { _slagActiveGradientMin = value; RaisePropertyChanged("SlagActiveGradientMin"); }
        }
        public int SlagActiveGradientMax
        {
            get { return _slagActiveGradientMax; }
            set { _slagActiveGradientMax = value; RaisePropertyChanged("SlagActiveGradientMax"); }
        }
        public int SlagActiveGradientStep
        {
            get { return _slagActiveGradientStep; }
            set { _slagActiveGradientStep = value; RaisePropertyChanged("SlagActiveGradientStep"); }
        }

        public int SlagInActiveGradientMin
        {
            get { return _slagInActiveGradientMin; }
            set { _slagInActiveGradientMin = value; RaisePropertyChanged("SlagInActiveGradientMin"); }
        }
        public int SlagInActiveGradientMax
        {
            get { return _slagInActiveGradientMax; }
            set { _slagInActiveGradientMax = value; RaisePropertyChanged("SlagInActiveGradientMax"); }
        }
        public int SlagInActiveGradientStep
        {
            get { return _slagInActiveGradientStep; }
            set { _slagInActiveGradientStep = value; RaisePropertyChanged("SlagInActiveGradientStep"); }
        }
        #endregion // Slag

        #region IgnitonDetectionEnable
        public int IgnitonDetectionEnableMin
        {
            get { return _ignitonDetectionEnableMin; }
            set { _ignitonDetectionEnableMin = value; RaisePropertyChanged("IgnitonDetectionEnableMin"); }
        }
        public int IgnitonDetectionEnableMax
        {
            get { return _ignitonDetectionEnableMax; }
            set { _ignitonDetectionEnableMax = value; RaisePropertyChanged("IgnitonDetectionEnableMax"); }
        }
        public int IgnitonDetectionEnableStep
        {
            get { return _ignitonDetectionEnableStep; }
            set { _ignitonDetectionEnableStep = value; RaisePropertyChanged("IgnitonDetectionEnableStep"); }
        }
        #endregion // IgnitonDetectionEnable


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
            RetractHeightMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.RetractHeightMin);
            RetractHeightMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.RetractHeightMax);
            RetractHeightStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.RetractHeightStep);
            SlagSensitivityMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagSensitivityMin);
            SlagSensitivityMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagSensitivityMax);
            SlagSensitivityStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagSensitivityStep);
            HeatO2TemperMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.HeatO2TemperMin);
            HeatO2TemperMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.HeatO2TemperMax);
            HeatO2TemperStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.HeatO2TemperStep);
            FuelGasTemperMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.FuelGasTemperMin);
            FuelGasTemperMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.FuelGasTemperMax);
            FuelGasTemperStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.FuelGasTemperStep);
            HeightTemperMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.HeightTemperMin);
            HeightTemperMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.HeightTemperMax);
            HeightTemperStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.HeightTemperStep);
            LinearDriveManualPosSpeedMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.LinearDriveManualPosSpeedMin);
            LinearDriveManualPosSpeedMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.LinearDriveManualPosSpeedMax);
            LinearDriveManualPosSpeedStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.LinearDriveManualPosSpeedStep);
            FuelGasOffsetMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.FuelGasOffsetMin);
            FuelGasOffsetMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.FuelGasOffsetMax);
            FuelGasOffsetStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.FuelGasOffsetStep);
            FlashbackSensivitityMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.FlashbackSensivitityMin);
            FlashbackSensivitityMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.FlashbackSensivitityMax);
            FlashbackSensivitityStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.FlashbackSensivitityStep);
            #region Slag
            SlagIntervalTimeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagIntervalTimeMin);
            SlagIntervalTimeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagIntervalTimeMax);
            SlagIntervalTimeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagIntervalTimeStep);

            SlagFirstSlagTimeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagFirstSlagTimeMin);
            SlagFirstSlagTimeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagFirstSlagTimeMax);
            SlagFirstSlagTimeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagFirstSlagTimeStep);

            SlagSecurityTimeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagSecurityTimeMin);
            SlagSecurityTimeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagSecurityTimeMax);
            SlagSecurityTimeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagSecurityTimeStep);

            SlagPostTimeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagPostTimeMin);
            SlagPostTimeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagPostTimeMax);
            SlagPostTimeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagPostTimeStep);

            SlagActiveGradientMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagActiveGradientMin);
            SlagActiveGradientMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagActiveGradientMax);
            SlagActiveGradientStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagActiveGradientStep);

            SlagInActiveGradientMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagInActiveGradientMin);
            SlagInActiveGradientMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagInActiveGradientMax);
            SlagInActiveGradientStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.SlagInActiveGradientStep);
            #endregion // Slag
            IgnitonDetectionEnableMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.IgnitionDetectionEnableMin);
            IgnitonDetectionEnableMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.IgnitionDetectionEnableMax);
            IgnitonDetectionEnableStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxProcess.IgnitionDetectionEnableStep);
        }
    }
}
