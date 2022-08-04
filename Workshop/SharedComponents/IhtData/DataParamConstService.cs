using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtData
{
    public class DataParamConstService : INotifyPropertyChanged
    {
        private int _ignitionPreFlowMultiplierMin { get; set; }
        private int _ignitionPreFlowMultiplierMax { get; set; }
        private int _ignitionPreFlowMultiplierStep { get; set; }

        private int _ignitionOnDurationTimeMin { get; set; }
        private int _ignitionOnDurationTimeMax { get; set; }
        private int _ignitionOnDurationTimeStep { get; set; }

        private int _heatO2PostFlowMultiplierMin { get; set; }
        private int _heatO2PostFlowMultiplierMax { get; set; }
        private int _heatO2PostFlowMultiplierStep { get; set; }

        private int _heatO2PostFlowPressureMin { get; set; }
        private int _heatO2PostFlowPressureMax { get; set; }
        private int _heatO2PostFlowPressureStep { get; set; }

        private int _slagCuttingSpeedReductionMin { get; set; }
        private int _slagCuttingSpeedReductionMax { get; set; }
        private int _slagCuttingSpeedReductionStep { get; set; }

        private int _sensorCollisionOutputDisableMin { get; set; }
        private int _sensorCollisionOutputDisableMax { get; set; }
        private int _sensorCollisionOutputDisableStep { get; set; }

        private int _pidErrorThresholdDelayMin { get; set; }
        private int _pidErrorThresholdDelayMax { get; set; }
        private int _pidErrorThresholdDelayStep { get; set; }

        private int _toleranceInPositionMin { get; set; }
        private int _toleranceInPositionMax { get; set; }
        private int _toleranceInPositionStep { get; set; }

        private int _fit3ValveDelayMin { get; set; }
        private int _fit3ValveDelayMax { get; set; }
        private int _fit3ValveDelayStep { get; set; }

        private int _fit3ValveDurationMin { get; set; }
        private int _fit3ValveDurationMax { get; set; }
        private int _fit3ValveDurationStep { get; set; }

        private int _fit3GlowPlugDelayMin { get; set; }
        private int _fit3GlowPlugDelayMax { get; set; }
        private int _fit3GlowPlugDelayStep { get; set; }

        private int _fit3GlowPlugDurationMin { get; set; }
        private int _fit3GlowPlugDurationMax { get; set; }
        private int _fit3GlowPlugDurationStep { get; set; }

        private int _fit3GlowPlugSetpointMin { get; set; }
        private int _fit3GlowPlugSetpointMax { get; set; }
        private int _fit3GlowPlugSetpointStep { get; set; }

        private int _fit3SaveIgnitionDataMin { get; set; }
        private int _fit3SaveIgnitionDataMax { get; set; }
        private int _fit3SaveIgnitionDataStep { get; set; }

        #region IgnitionPreFlowMultiplier
        public int IgnitionPreFlowMultiplierMin
        {
            get { return _ignitionPreFlowMultiplierMin; }
            set { _ignitionPreFlowMultiplierMin = value; RaisePropertyChanged("IgnitionPreFlowMultiplierMin"); }
        }
        public int IgnitionPreFlowMultiplierMax
        {
            get { return _ignitionPreFlowMultiplierMax; }
            set { _ignitionPreFlowMultiplierMax = value; RaisePropertyChanged("IgnitionPreFlowMultiplierMax"); }
        }
        public int IgnitionPreFlowMultiplierStep
        {
            get { return _ignitionPreFlowMultiplierStep; }
            set { _ignitionPreFlowMultiplierStep = value; RaisePropertyChanged("IgnitionPreFlowMultiplierStep"); }
        }
        #endregion // IgnitionPreFlowMultiplier

        #region IgnitionOnDurationTime
        public int IgnitionOnDurationTimeMin
        {
            get { return _ignitionOnDurationTimeMin; }
            set { _ignitionOnDurationTimeMin = value; RaisePropertyChanged("IgnitionOnDurationTimeMin"); }
        }
        public int IgnitionOnDurationTimeMax
        {
            get { return _ignitionOnDurationTimeMax; }
            set { _ignitionOnDurationTimeMax = value; RaisePropertyChanged("IgnitionOnDurationTimeMax"); }
        }
        public int IgnitionOnDurationTimeStep
        {
            get { return _ignitionOnDurationTimeStep; }
            set { _ignitionOnDurationTimeStep = value; RaisePropertyChanged("IgnitionOnDurationTimeStep"); }
        }
        #endregion // IgnitionOnDurationTime

        #region HeatO2PostFlowMultiplier
        public int HeatO2PostFlowMultiplierMin
        {
            get { return _heatO2PostFlowMultiplierMin; }
            set { _heatO2PostFlowMultiplierMin = value; RaisePropertyChanged("HeatO2PostFlowMultiplierMin"); }
        }
        public int HeatO2PostFlowMultiplierMax
        {
            get { return _heatO2PostFlowMultiplierMax; }
            set { _heatO2PostFlowMultiplierMax = value; RaisePropertyChanged("HeatO2PostFlowMultiplierMax"); }
        }
        public int HeatO2PostFlowMultiplierStep
        {
            get { return _heatO2PostFlowMultiplierStep; }
            set { _heatO2PostFlowMultiplierStep = value; RaisePropertyChanged("HeatO2PostFlowMultiplierStep"); }
        }
        #endregion // HeatO2PostFlowMultiplier

        #region HeatO2PostFlowPressure
        public int HeatO2PostFlowPressureMin
        {
            get { return _heatO2PostFlowPressureMin; }
            set { _heatO2PostFlowPressureMin = value; RaisePropertyChanged("HeatO2PostFlowPressureMin"); }
        }
        public int HeatO2PostFlowPressureMax
        {
            get { return _heatO2PostFlowPressureMax; }
            set { _heatO2PostFlowPressureMax = value; RaisePropertyChanged("HeatO2PostFlowPressureMax"); }
        }
        public int HeatO2PostFlowPressureStep
        {
            get { return _heatO2PostFlowPressureStep; }
            set { _heatO2PostFlowPressureStep = value; RaisePropertyChanged("HeatO2PostFlowPressureStep"); }
        }
        #endregion // HeatO2PostFlowPressure

        #region SlagCuttingSpeedReduction
        public int SlagCuttingSpeedReductionMin
        {
            get { return _slagCuttingSpeedReductionMin; }
            set { _slagCuttingSpeedReductionMin = value; RaisePropertyChanged("SlagCuttingSpeedReductionMin"); }
        }
        public int SlagCuttingSpeedReductionMax
        {
            get { return _slagCuttingSpeedReductionMax; }
            set { _slagCuttingSpeedReductionMax = value; RaisePropertyChanged("SlagCuttingSpeedReductionMax"); }
        }
        public int SlagCuttingSpeedReductionStep
        {
            get { return _slagCuttingSpeedReductionStep; }
            set { _slagCuttingSpeedReductionStep = value; RaisePropertyChanged("SlagCuttingSpeedReductionStep"); }
        }
        #endregion // SlagCuttingSpeedReduction

        #region SensorCollisionOutputDisable
        public int SensorCollisionOutputDisableMin
        {
            get { return _sensorCollisionOutputDisableMin; }
            set { _sensorCollisionOutputDisableMin = value; RaisePropertyChanged("SensorCollisionOutputDisableMin"); }
        }
        public int SensorCollisionOutputDisableMax
        {
            get { return _sensorCollisionOutputDisableMax; }
            set { _sensorCollisionOutputDisableMax = value; RaisePropertyChanged("SensorCollisionOutputDisableMax"); }
        }
        public int SensorCollisionOutputDisableStep
        {
            get { return _sensorCollisionOutputDisableStep; }
            set { _sensorCollisionOutputDisableStep = value; RaisePropertyChanged("SensorCollisionOutputDisableStep"); }
        }
        #endregion // SensorCollisionOutputDisable

        #region PidErrorThresholdDelay
        public int PidErrorThresholdDelayMin
        {
            get { return _pidErrorThresholdDelayMin; }
            set { _pidErrorThresholdDelayMin = value; RaisePropertyChanged("PidErrorThresholdDelayMin"); }
        }
        public int PidErrorThresholdDelayMax
        {
            get { return _pidErrorThresholdDelayMax; }
            set { _pidErrorThresholdDelayMax = value; RaisePropertyChanged("PidErrorThresholdDelayMax"); }
        }
        public int PidErrorThresholdDelayStep
        {
            get { return _pidErrorThresholdDelayStep; }
            set { _pidErrorThresholdDelayStep = value; RaisePropertyChanged("PidErrorThresholdDelayStep"); }
        }
        #endregion // PidErrorThresholdDelay

        #region ToleranceInPosition
        public int ToleranceInPositionMin
        {
            get { return _toleranceInPositionMin; }
            set { _toleranceInPositionMin = value; RaisePropertyChanged("ToleranceInPositionMin"); }
        }
        public int ToleranceInPositionMax
        {
            get { return _toleranceInPositionMax; }
            set { _toleranceInPositionMax = value; RaisePropertyChanged("ToleranceInPositionMax"); }
        }
        public int ToleranceInPositionStep
        {
            get { return _toleranceInPositionStep; }
            set { _toleranceInPositionStep = value; RaisePropertyChanged("ToleranceInPositionStep"); }
        }
        #endregion // ToleranceInPosition

        #region Fit3ValveDelay
        public int Fit3ValveDelayMin
        {
            get { return _fit3ValveDelayMin; }
            set { _fit3ValveDelayMin = value; RaisePropertyChanged("Fit3ValveDelayMin"); }
        }
        public int Fit3ValveDelayMax
        {
            get { return _fit3ValveDelayMax; }
            set { _fit3ValveDelayMax = value; RaisePropertyChanged("Fit3ValveDelayMax"); }
        }
        public int Fit3ValveDelayStep
        {
            get { return _fit3ValveDelayStep; }
            set { _fit3ValveDelayStep = value; RaisePropertyChanged("Fit3ValveDelayStep"); }
        }
        #endregion // Fit3ValveDelay

        #region Fit3ValveDuration
        public int Fit3ValveDurationMin
        {
            get { return _fit3ValveDurationMin; }
            set { _fit3ValveDurationMin = value; RaisePropertyChanged("Fit3ValveDurationMin"); }
        }
        public int Fit3ValveDurationMax
        {
            get { return _fit3ValveDurationMax; }
            set { _fit3ValveDurationMax = value; RaisePropertyChanged("Fit3ValveDurationMax"); }
        }
        public int Fit3ValveDurationStep
        {
            get { return _fit3ValveDurationStep; }
            set { _fit3ValveDurationStep = value; RaisePropertyChanged("Fit3ValveDurationStep"); }
        }
        #endregion // Fit3ValveDuration

        #region Fit3GlowPlugDelay
        public int Fit3GlowPlugDelayMin
        {
            get { return _fit3GlowPlugDelayMin; }
            set { _fit3GlowPlugDelayMin = value; RaisePropertyChanged("Fit3GlowPlugDelayMin"); }
        }
        public int Fit3GlowPlugDelayMax
        {
            get { return _fit3GlowPlugDelayMax; }
            set { _fit3GlowPlugDelayMax = value; RaisePropertyChanged("Fit3GlowPlugDelayMax"); }
        }
        public int Fit3GlowPlugDelayStep
        {
            get { return _fit3GlowPlugDelayStep; }
            set { _fit3GlowPlugDelayStep = value; RaisePropertyChanged("Fit3GlowPlugDelayStep"); }
        }
        #endregion // Fit3GlowPlugDelay

        #region Fit3GlowPlugDuration
        public int Fit3GlowPlugDurationMin
        {
            get { return _fit3GlowPlugDurationMin; }
            set { _fit3GlowPlugDurationMin = value; RaisePropertyChanged("Fit3GlowPlugDurationMin"); }
        }
        public int Fit3GlowPlugDurationMax
        {
            get { return _fit3GlowPlugDurationMax; }
            set { _fit3GlowPlugDurationMax = value; RaisePropertyChanged("Fit3GlowPlugDurationMax"); }
        }
        public int Fit3GlowPlugDurationStep
        {
            get { return _fit3GlowPlugDurationStep; }
            set { _fit3GlowPlugDurationStep = value; RaisePropertyChanged("Fit3GlowPlugDurationStep"); }
        }
        #endregion // Fit3GlowPlugDuration

        #region Fit3GlowPlugSetpoint
        public int Fit3GlowPlugSetpointMin
        {
            get { return _fit3GlowPlugSetpointMin; }
            set { _fit3GlowPlugSetpointMin = value; RaisePropertyChanged("Fit3GlowPlugSetpointMin"); }
        }
        public int Fit3GlowPlugSetpointMax
        {
            get { return _fit3GlowPlugSetpointMax; }
            set { _fit3GlowPlugSetpointMax = value; RaisePropertyChanged("Fit3GlowPlugSetpointMax"); }
        }
        public int Fit3GlowPlugSetpointStep
        {
            get { return _fit3GlowPlugSetpointStep; }
            set { _fit3GlowPlugSetpointStep = value; RaisePropertyChanged("Fit3GlowPlugSetpointStep"); }
        }
        #endregion // Fit3GlowPlugSetpoint

        #region Fit3SaveIgnitionData
        public int Fit3SaveIgnitionDataMin
        {
            get { return _fit3SaveIgnitionDataMin; }
            set { _fit3SaveIgnitionDataMin = value; RaisePropertyChanged("Fit3SaveIgnitionDataMin"); }
        }
        public int Fit3SaveIgnitionDataMax
        {
            get { return _fit3SaveIgnitionDataMax; }
            set { _fit3SaveIgnitionDataMax = value; RaisePropertyChanged("Fit3SaveIgnitionDataMax"); }
        }
        public int Fit3SaveIgnitionDataStep
        {
            get { return _fit3SaveIgnitionDataStep; }
            set { _fit3SaveIgnitionDataStep = value; RaisePropertyChanged("Fit3SaveIgnitionDataStep"); }
        }
        #endregion // Fit3SaveIgnitionData


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
            IgnitionPreFlowMultiplierMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.IgnitionPreFlowMultiplierMin);
            IgnitionPreFlowMultiplierMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.IgnitionPreFlowMultiplierMax);
            IgnitionPreFlowMultiplierStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.IgnitionPreFlowMultiplierStep);
            IgnitionOnDurationTimeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.IgnitionOnDurationTimeMin);
            IgnitionOnDurationTimeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.IgnitionOnDurationTimeMax);
            IgnitionOnDurationTimeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.IgnitionOnDurationTimeStep);
            HeatO2PostFlowMultiplierMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.HeatO2PostFlowMultiplierMin);
            HeatO2PostFlowMultiplierMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.HeatO2PostFlowMultiplierMax);
            HeatO2PostFlowMultiplierStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.HeatO2PostFlowMultiplierStep);
            HeatO2PostFlowPressureMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.HeatO2PostFlowPressureMin);
            HeatO2PostFlowPressureMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.HeatO2PostFlowPressureMax);
            HeatO2PostFlowPressureStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.HeatO2PostFlowPressureStep);
            SlagCuttingSpeedReductionMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.SlagCuttingSpeedReductionMin);
            SlagCuttingSpeedReductionMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.SlagCuttingSpeedReductionMax);
            SlagCuttingSpeedReductionStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.SlagCuttingSpeedReductionStep);
            SensorCollisionOutputDisableMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.SensorCollisionOutputDisableMin);
            SensorCollisionOutputDisableMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.SensorCollisionOutputDisableMax);
            SensorCollisionOutputDisableStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.SensorCollisionOutputDisableStep);
            PidErrorThresholdDelayMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.PidErrorThresholdDelayMin);
            PidErrorThresholdDelayMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.PidErrorThresholdDelayMax);
            PidErrorThresholdDelayStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.PidErrorThresholdDelayStep);
            ToleranceInPositionMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.ToleranceInPositionMin);
            ToleranceInPositionMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.ToleranceInPositionMax);
            ToleranceInPositionStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.ToleranceInPositionStep);
            Fit3ValveDelayMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3ValveDelayMin);
            Fit3ValveDelayMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3ValveDelayMax);
            Fit3ValveDelayStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3ValveDelayStep);
            Fit3ValveDurationMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3ValveDurationMin);
            Fit3ValveDurationMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3ValveDurationMax);
            Fit3ValveDurationStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3ValveDurationStep);
            Fit3GlowPlugDelayMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3GlowPlugDelayMin);
            Fit3GlowPlugDelayMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3GlowPlugDelayMax);
            Fit3GlowPlugDelayStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3GlowPlugDelayStep);
            Fit3GlowPlugDurationMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3GlowPlugDurationMin);
            Fit3GlowPlugDurationMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3GlowPlugDurationMax);
            Fit3GlowPlugDurationStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3GlowPlugDurationStep);
            Fit3GlowPlugSetpointMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3GlowPlugSetpointMin);
            Fit3GlowPlugSetpointMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3GlowPlugSetpointMax);
            Fit3GlowPlugSetpointStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3GlowPlugSetpointStep);
            Fit3SaveIgnitionDataMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3SaveIgnitionDataMin);
            Fit3SaveIgnitionDataMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3SaveIgnitionDataMax);
            Fit3SaveIgnitionDataStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxService.Fit3SaveIgnitionDataStep);
        }

    }
}
