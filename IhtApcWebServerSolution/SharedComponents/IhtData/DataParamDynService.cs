using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtData
{
    public class DataParamDynService : INotifyPropertyChanged
    {
        private int _ignitionPreFlowMultiplier { get; set; }
        private int _ignitionOnDurationTime { get; set; }
        private int _heatO2PostFlowMultiplier { get; set; }
        private int _heatO2PostFlowPressure { get; set; }
        private int _slagCuttingSpeedReduction { get; set; }
        private int _sensorCollisionOutputDisable { get; set; }
        private int _pidErrorThresholdDelay { get; set; }
        private int _toleranceInPosition { get; set; }
        private int _fit3ValveDelay { get; set; }
        private int _fit3ValveDuration { get; set; }
        private int _fit3GlowPlugDelay { get; set; }
        private int _fit3GlowPlugDuration { get; set; }
        private int _fit3GlowPlugSetpoint { get; set; }
        private int _fit3SaveIgnitionData { get; set; }

        public int IgnitionPreFlowMultiplier
        {
            get { return _ignitionPreFlowMultiplier; }
            set { _ignitionPreFlowMultiplier = value; RaisePropertyChanged("IgnitionPreFlowMultiplier"); }
        }
        public int IgnitionOnDurationTime
        {
            get { return _ignitionOnDurationTime; }
            set { _ignitionOnDurationTime = value; RaisePropertyChanged("IgnitionOnDurationTime"); }
        }
        public int HeatO2PostFlowMultiplier
        {
            get { return _heatO2PostFlowMultiplier; }
            set { _heatO2PostFlowMultiplier = value; RaisePropertyChanged("HeatO2PostFlowMultiplier"); }
        }
        public int HeatO2PostFlowPressure
        {
            get { return _heatO2PostFlowPressure; }
            set { _heatO2PostFlowPressure = value; RaisePropertyChanged("HeatO2PostFlowPressure"); }
        }
        public int SlagCuttingSpeedReduction
        {
            get { return _slagCuttingSpeedReduction; }
            set { _slagCuttingSpeedReduction = value; RaisePropertyChanged("SlagCuttingSpeedReduction"); }
        }
        public int SensorCollisionOutputDisable
        {
            get { return _sensorCollisionOutputDisable; }
            set { _sensorCollisionOutputDisable = value; RaisePropertyChanged("SensorCollisionOutputDisable"); }
        }
        public int PidErrorThresholdDelay
        {
            get { return _pidErrorThresholdDelay; }
            set { _pidErrorThresholdDelay = value; RaisePropertyChanged("PidErrorThresholdDelay"); }
        }
        public int ToleranceInPosition
        {
            get { return _toleranceInPosition; }
            set { _toleranceInPosition = value; RaisePropertyChanged("ToleranceInPosition"); }
        }
        public int Fit3ValveDelay
        {
            get { return _fit3ValveDelay; }
            set { _fit3ValveDelay = value; RaisePropertyChanged("Fit3ValveDelay"); }
        }
        public int Fit3ValveDuration
        {
            get { return _fit3ValveDuration; }
            set { _fit3ValveDuration = value; RaisePropertyChanged("Fit3ValveDuration"); }
        }
        public int Fit3GlowPlugDelay
        {
            get { return _fit3GlowPlugDelay; }
            set { _fit3GlowPlugDelay = value; RaisePropertyChanged("Fit3GlowPlugDelay"); }
        }
        public int Fit3GlowPlugDuration
        {
            get { return _fit3GlowPlugDuration; }
            set { _fit3GlowPlugDuration = value; RaisePropertyChanged("Fit3GlowPlugDuration"); }
        }
        public int Fit3GlowPlugSetpoint
        {
            get { return _fit3GlowPlugSetpoint; }
            set { _fit3GlowPlugSetpoint = value; RaisePropertyChanged("Fit3GlowPlugSetpoint"); }
        }
        public int Fit3SaveIgnitionData
        {
            get { return _fit3SaveIgnitionData; }
            set { _fit3SaveIgnitionData = value; RaisePropertyChanged("Fit3SaveIgnitionData"); }
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
            IgnitionPreFlowMultiplier = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.IgnitionPreFlowMultiplier);
            IgnitionOnDurationTime = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.IgnitionOnDurationTime);
            HeatO2PostFlowMultiplier = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.HeatO2PostFlowMultiplier);
            HeatO2PostFlowPressure = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.HeatO2PostFlowPressure);
            SlagCuttingSpeedReduction = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction);
            SensorCollisionOutputDisable = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.SensorCollisionOutputDisable);
            PidErrorThresholdDelay = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.PidErrorThresholdDelay);
            ToleranceInPosition = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.ToleranceInPosition);
            Fit3ValveDelay = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.Fit3ValveDelay);
            Fit3ValveDuration = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.Fit3ValveDuration);
            Fit3GlowPlugDelay = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.Fit3GlowPlugDelay);
            Fit3GlowPlugDuration = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.Fit3GlowPlugDuration);
            Fit3GlowPlugSetpoint = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.Fit3GlowPlugSetpoint);
            Fit3SaveIgnitionData = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxService.Fit3SaveIgnitionData);
        }
    }
}
