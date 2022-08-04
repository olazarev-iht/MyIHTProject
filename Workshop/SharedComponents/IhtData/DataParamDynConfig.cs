using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtData
{
    public class DataParamDynConfig : INotifyPropertyChanged
    {
        private int _linearDriveUpSpeedFast { get; set; }
        private int _linearDriveUpSpeedSlow { get; set; }
        private int _linearDriveDnSpeedFast { get; set; }
        private int _linearDriveDnSpeedSlow { get; set; }
        private int _dynamic { get; set; }
        private int _sensorCollisionDelay { get; set; }
        private int _linearDriveRefSpeed { get; set; }
        private int _linearDrivePosSpeed { get; set; }
        private int _tactileInitialPosFinding { get; set; }
        private int _distanceCalibration { get; set; }
        private int _hoseLength { get; set; }
        private int _cutO2BlowOutTime { get; set; }
        private int _cutO2BlowOutPressure { get; set; }
        private int _cutO2BlowOutTimeOut { get; set; }
        private int _capSetpointFlameOffs { get; set; }
        private int _loadDefaultParameter { get; set; }

        public int LinearDriveUpSpeedFast
        {
            get { return _linearDriveUpSpeedFast; }
            set { _linearDriveUpSpeedFast = value; RaisePropertyChanged("LinearDriveUpSpeedFast"); }
        }

        public int LinearDriveUpSpeedSlow
        {
            get { return _linearDriveUpSpeedSlow; }
            set { _linearDriveUpSpeedSlow = value; RaisePropertyChanged("LinearDriveUpSpeedSlow"); }
        }

        public int LinearDriveDnSpeedFast
        {
            get { return _linearDriveDnSpeedFast; }
            set { _linearDriveDnSpeedFast = value; RaisePropertyChanged("LinearDriveDnSpeedFast"); }
        }

        public int LinearDriveDnSpeedSlow
        {
            get { return _linearDriveDnSpeedSlow; }
            set { _linearDriveDnSpeedSlow = value; RaisePropertyChanged("LinearDriveDnSpeedSlow"); }
        }

        public int Dynamic
        {
            get { return _dynamic; }
            set { _dynamic = value; RaisePropertyChanged("Dynamic"); }
        }

        public int SensorCollisionDelay
        {
            get { return _sensorCollisionDelay; }
            set { _sensorCollisionDelay = value; RaisePropertyChanged("SensorCollisionDelay"); }
        }

        public int LinearDriveRefSpeed
        {
            get { return _linearDriveRefSpeed; }
            set { _linearDriveRefSpeed = value; RaisePropertyChanged("LinearDriveRefSpeed"); }
        }

        public int LinearDrivePosSpeed
        {
            get { return _linearDrivePosSpeed; }
            set { _linearDrivePosSpeed = value; RaisePropertyChanged("LinearDrivePosSpeed"); }
        }

        public int TactileInitialPosFinding
        {
            get { return _tactileInitialPosFinding; }
            set { _tactileInitialPosFinding = value; RaisePropertyChanged("TactileInitialPosFinding"); }
        }

        public int DistanceCalibration
        {
            get { return _distanceCalibration; }
            set { _distanceCalibration = value; RaisePropertyChanged("DistanceCalibration"); }
        }

        public int HoseLength
        {
            get { return _hoseLength; }
            set { _hoseLength = value; RaisePropertyChanged("HoseLength"); }
        }

        public int CutO2BlowOutTime
        {
            get { return _cutO2BlowOutTime; }
            set { _cutO2BlowOutTime = value; RaisePropertyChanged("CutO2BlowOutTime"); }
        }

        public int CutO2BlowOutPressure
        {
            get { return _cutO2BlowOutPressure; }
            set { _cutO2BlowOutPressure = value; RaisePropertyChanged("CutO2BlowOutPressure"); }
        }

        public int CutO2BlowOutTimeOut
        {
            get { return _cutO2BlowOutTimeOut; }
            set { _cutO2BlowOutTimeOut = value; RaisePropertyChanged("CutO2BlowOutTimeOut"); }
        }

        public int CapSetpointFlameOffs
        {
            get { return _capSetpointFlameOffs; }
            set { _capSetpointFlameOffs = value; RaisePropertyChanged("CapSetpointFlameOffs"); }
        }

        public int LoadDefaultParameter
        {
            get { return _loadDefaultParameter; }
            set { _loadDefaultParameter = value; RaisePropertyChanged("LoadDefaultParameter"); }
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
            LinearDriveUpSpeedFast = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedFast);
            LinearDriveUpSpeedSlow = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedSlow);
            LinearDriveDnSpeedFast = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedFast);
            LinearDriveDnSpeedSlow = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedSlow);
            Dynamic = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.Dynamic);
            SensorCollisionDelay = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.SensorCollisionDelay);
            LinearDriveRefSpeed = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.LinearDriveRefSpeed);
            LinearDrivePosSpeed = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.LinearDrivePosSpeed);
            TactileInitialPosFinding = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding);
            DistanceCalibration = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.DistanceCalibration);
            HoseLength = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.HoseLength);
            CutO2BlowOutTime = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime);
            CutO2BlowOutPressure = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure);
            CutO2BlowOutTimeOut = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut);
            CapSetpointFlameOffs = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.CapSetpointFlameOffs);
            LoadDefaultParameter = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxConfig.LoadDefaultParameter);
        }
    }
}
