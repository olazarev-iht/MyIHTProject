using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtData
{
    public class DataParamConstConfig : INotifyPropertyChanged
    {
        private int _linearDriveUpSpeedFastMin { get; set; }
        private int _linearDriveUpSpeedFastMax { get; set; }
        private int _linearDriveUpSpeedFastStep { get; set; }

        private int _linearDriveUpSpeedSlowMin { get; set; }
        private int _linearDriveUpSpeedSlowMax { get; set; }
        private int _linearDriveUpSpeedSlowStep { get; set; }

        private int _linearDriveDnSpeedFastMin { get; set; }
        private int _linearDriveDnSpeedFastMax { get; set; }
        private int _linearDriveDnSpeedFastStep { get; set; }

        private int _linearDriveDnSpeedSlowMin { get; set; }
        private int _linearDriveDnSpeedSlowMax { get; set; }
        private int _linearDriveDnSpeedSlowStep { get; set; }

        private int _dynamicMin { get; set; }
        private int _dynamicMax { get; set; }
        private int _dynamicStep { get; set; }

        private int _sensorCollisionDelayMin { get; set; }
        private int _sensorCollisionDelayMax { get; set; }
        private int _sensorCollisionDelayStep { get; set; }

        private int _linearDriveRefSpeedMin { get; set; }
        private int _linearDriveRefSpeedMax { get; set; }
        private int _linearDriveRefSpeedStep { get; set; }

        private int _linearDrivePosSpeedMin { get; set; }
        private int _linearDrivePosSpeedMax { get; set; }
        private int _linearDrivePosSpeedStep { get; set; }

        private int _tactileInitialPosFindingMin { get; set; }
        private int _tactileInitialPosFindingMax { get; set; }
        private int _tactileInitialPosFindingStep { get; set; }

        private int _distanceCalibrationMin { get; set; }
        private int _distanceCalibrationMax { get; set; }
        private int _distanceCalibrationStep { get; set; }

        private int _hoseLengthMin { get; set; }
        private int _hoseLengthMax { get; set; }
        private int _hoseLengthStep { get; set; }

        private int _cutO2BlowOutTimeMin { get; set; }
        private int _cutO2BlowOutTimeMax { get; set; }
        private int _cutO2BlowOutTimeStep { get; set; }

        private int _cutO2BlowOutPressureMin { get; set; }
        private int _cutO2BlowOutPressureMax { get; set; }
        private int _cutO2BlowOutPressureStep { get; set; }

        private int _cutO2BlowOutTimeOutMin { get; set; }
        private int _cutO2BlowOutTimeOutMax { get; set; }
        private int _cutO2BlowOutTimeOutStep { get; set; }

        private int _capSetpointFlameOffsMin { get; set; }
        private int _capSetpointFlameOffsMax { get; set; }
        private int _capSetpointFlameOffsStep { get; set; }

        private int _loadDefaultParameterMin { get; set; }
        private int _loadDefaultParameterMax { get; set; }
        private int _loadDefaultParameterStep { get; set; }

        public int LinearDriveUpSpeedFastMin
        {
            get { return _linearDriveUpSpeedFastMin; }
            set { _linearDriveUpSpeedFastMin = value; RaisePropertyChanged("LinearDriveUpSpeedFastMin"); }
        }
        public int LinearDriveUpSpeedFastMax
        {
            get { return _linearDriveUpSpeedFastMax; }
            set { _linearDriveUpSpeedFastMax = value; RaisePropertyChanged("LinearDriveUpSpeedFastMax"); }
        }
        public int LinearDriveUpSpeedFastStep
        {
            get { return _linearDriveUpSpeedFastStep; }
            set { _linearDriveUpSpeedFastStep = value; RaisePropertyChanged("LinearDriveUpSpeedFastStep"); }
        }

        public int LinearDriveUpSpeedSlowMin
        {
            get { return _linearDriveUpSpeedSlowMin; }
            set { _linearDriveUpSpeedSlowMin = value; RaisePropertyChanged("LinearDriveUpSpeedSlowMin"); }
        }
        public int LinearDriveUpSpeedSlowMax
        {
            get { return _linearDriveUpSpeedSlowMax; }
            set { _linearDriveUpSpeedSlowMax = value; RaisePropertyChanged("LinearDriveUpSpeedSlowMax"); }
        }
        public int LinearDriveUpSpeedSlowStep
        {
            get { return _linearDriveUpSpeedSlowStep; }
            set { _linearDriveUpSpeedSlowStep = value; RaisePropertyChanged("LinearDriveUpSpeedSlowStep"); }
        }

        public int LinearDriveDnSpeedFastMin
        {
            get { return _linearDriveDnSpeedFastMin; }
            set { _linearDriveDnSpeedFastMin = value; RaisePropertyChanged("LinearDriveDnSpeedFastMin"); }
        }
        public int LinearDriveDnSpeedFastMax
        {
            get { return _linearDriveDnSpeedFastMax; }
            set { _linearDriveDnSpeedFastMax = value; RaisePropertyChanged("LinearDriveDnSpeedFastMax"); }
        }
        public int LinearDriveDnSpeedFastStep
        {
            get { return _linearDriveDnSpeedFastStep; }
            set { _linearDriveDnSpeedFastStep = value; RaisePropertyChanged("LinearDriveDnSpeedFastStep"); }
        }

        public int LinearDriveDnSpeedSlowMin
        {
            get { return _linearDriveDnSpeedSlowMin; }
            set { _linearDriveDnSpeedSlowMin = value; RaisePropertyChanged("LinearDriveDnSpeedSlowMin"); }
        }
        public int LinearDriveDnSpeedSlowMax
        {
            get { return _linearDriveDnSpeedSlowMax; }
            set { _linearDriveDnSpeedSlowMax = value; RaisePropertyChanged("LinearDriveDnSpeedSlowMax"); }
        }
        public int LinearDriveDnSpeedSlowStep
        {
            get { return _linearDriveDnSpeedSlowStep; }
            set { _linearDriveDnSpeedSlowStep = value; RaisePropertyChanged("LinearDriveDnSpeedSlowStep"); }
        }

        public int DynamicMin
        {
            get { return _dynamicMin; }
            set { _dynamicMin = value; RaisePropertyChanged("DynamicMin"); }
        }
        public int DynamicMax
        {
            get { return _dynamicMax; }
            set { _dynamicMax = value; RaisePropertyChanged("DynamicMax"); }
        }
        public int DynamicStep
        {
            get { return _dynamicStep; }
            set { _dynamicStep = value; RaisePropertyChanged("DynamicStep"); }
        }

        public int SensorCollisionDelayMin
        {
            get { return _sensorCollisionDelayMin; }
            set { _sensorCollisionDelayMin = value; RaisePropertyChanged("SensorCollisionDelayMin"); }
        }
        public int SensorCollisionDelayMax
        {
            get { return _sensorCollisionDelayMax; }
            set { _sensorCollisionDelayMax = value; RaisePropertyChanged("SensorCollisionDelayMax"); }
        }
        public int SensorCollisionDelayStep
        {
            get { return _sensorCollisionDelayStep; }
            set { _sensorCollisionDelayStep = value; RaisePropertyChanged("SensorCollisionDelayStep"); }
        }

        public int LinearDriveRefSpeedMin
        {
            get { return _linearDriveRefSpeedMin; }
            set { _linearDriveRefSpeedMin = value; RaisePropertyChanged("LinearDriveRefSpeedMin"); }
        }
        public int LinearDriveRefSpeedMax
        {
            get { return _linearDriveRefSpeedMax; }
            set { _linearDriveRefSpeedMax = value; RaisePropertyChanged("LinearDriveRefSpeedMax"); }
        }
        public int LinearDriveRefSpeedStep
        {
            get { return _linearDriveRefSpeedStep; }
            set { _linearDriveRefSpeedStep = value; RaisePropertyChanged("LinearDriveRefSpeedStep"); }
        }

        public int LinearDrivePosSpeedMin
        {
            get { return _linearDrivePosSpeedMin; }
            set { _linearDrivePosSpeedMin = value; RaisePropertyChanged("LinearDrivePosSpeedMin"); }
        }
        public int LinearDrivePosSpeedMax
        {
            get { return _linearDrivePosSpeedMax; }
            set { _linearDrivePosSpeedMax = value; RaisePropertyChanged("LinearDrivePosSpeedMax"); }
        }
        public int LinearDrivePosSpeedStep
        {
            get { return _linearDrivePosSpeedStep; }
            set { _linearDrivePosSpeedStep = value; RaisePropertyChanged("LinearDrivePosSpeedStep"); }
        }

        public int TactileInitialPosFindingMin
        {
            get { return _tactileInitialPosFindingMin; }
            set { _tactileInitialPosFindingMin = value; RaisePropertyChanged("TactileInitialPosFindingMin"); }
        }
        public int TactileInitialPosFindingMax
        {
            get { return _tactileInitialPosFindingMax; }
            set { _tactileInitialPosFindingMax = value; RaisePropertyChanged("TactileInitialPosFindingMax"); }
        }
        public int TactileInitialPosFindingStep
        {
            get { return _tactileInitialPosFindingStep; }
            set { _tactileInitialPosFindingStep = value; RaisePropertyChanged("TactileInitialPosFindingStep"); }
        }

        public int DistanceCalibrationMin
        {
            get { return _distanceCalibrationMin; }
            set { _distanceCalibrationMin = value; RaisePropertyChanged("DistanceCalibrationMin"); }
        }
        public int DistanceCalibrationMax
        {
            get { return _distanceCalibrationMax; }
            set { _distanceCalibrationMax = value; RaisePropertyChanged("DistanceCalibrationMax"); }
        }
        public int DistanceCalibrationStep
        {
            get { return _distanceCalibrationStep; }
            set { _distanceCalibrationStep = value; RaisePropertyChanged("DistanceCalibrationStep"); }
        }

        public int HoseLengthMin
        {
            get { return _hoseLengthMin; }
            set { _hoseLengthMin = value; RaisePropertyChanged("HoseLengthMin"); }
        }
        public int HoseLengthMax
        {
            get { return _hoseLengthMax; }
            set { _hoseLengthMax = value; RaisePropertyChanged("HoseLengthMax"); }
        }
        public int HoseLengthStep
        {
            get { return _hoseLengthStep; }
            set { _hoseLengthStep = value; RaisePropertyChanged("HoseLengthStep"); }
        }

        public int CutO2BlowOutTimeMin
        {
            get { return _cutO2BlowOutTimeMin; }
            set { _cutO2BlowOutTimeMin = value; RaisePropertyChanged("CutO2BlowOutTimeMin"); }
        }
        public int CutO2BlowOutTimeMax
        {
            get { return _cutO2BlowOutTimeMax; }
            set { _cutO2BlowOutTimeMax = value; RaisePropertyChanged("CutO2BlowOutTimeMax"); }
        }
        public int CutO2BlowOutTimeStep
        {
            get { return _cutO2BlowOutTimeStep; }
            set { _cutO2BlowOutTimeStep = value; RaisePropertyChanged("CutO2BlowOutTimeStep"); }
        }

        public int CutO2BlowOutPressureMin
        {
            get { return _cutO2BlowOutPressureMin; }
            set { _cutO2BlowOutPressureMin = value; RaisePropertyChanged("CutO2BlowOutPressureMin"); }
        }
        public int CutO2BlowOutPressureMax
        {
            get { return _cutO2BlowOutPressureMax; }
            set { _cutO2BlowOutPressureMax = value; RaisePropertyChanged("CutO2BlowOutPressureMax"); }
        }
        public int CutO2BlowOutPressureStep
        {
            get { return _cutO2BlowOutPressureStep; }
            set { _cutO2BlowOutPressureStep = value; RaisePropertyChanged("CutO2BlowOutPressureStep"); }
        }

        public int CutO2BlowOutTimeOutMin
        {
            get { return _cutO2BlowOutTimeOutMin; }
            set { _cutO2BlowOutTimeOutMin = value; RaisePropertyChanged("CutO2BlowOutTimeOutMin"); }
        }
        public int CutO2BlowOutTimeOutMax
        {
            get { return _cutO2BlowOutTimeOutMax; }
            set { _cutO2BlowOutTimeOutMax = value; RaisePropertyChanged("CutO2BlowOutTimeOutMax"); }
        }
        public int CutO2BlowOutTimeOutStep
        {
            get { return _cutO2BlowOutTimeOutStep; }
            set { _cutO2BlowOutTimeOutStep = value; RaisePropertyChanged("CutO2BlowOutTimeOutStep"); }
        }

        public int CapSetpointFlameOffsMin
        {
            get { return _capSetpointFlameOffsMin; }
            set { _capSetpointFlameOffsMin = value; RaisePropertyChanged("CapSetpointFlameOffsMin"); }
        }
        public int CapSetpointFlameOffsMax
        {
            get { return _capSetpointFlameOffsMax; }
            set { _capSetpointFlameOffsMax = value; RaisePropertyChanged("CapSetpointFlameOffsMax"); }
        }
        public int CapSetpointFlameOffsStep
        {
            get { return _capSetpointFlameOffsStep; }
            set { _capSetpointFlameOffsStep = value; RaisePropertyChanged("CapSetpointFlameOffsStep"); }
        }

        public int LoadDefaultParameterMin
        {
            get { return _loadDefaultParameterMin; }
            set { _loadDefaultParameterMin = value; RaisePropertyChanged("LoadDefaultParameterMin"); }
        }
        public int LoadDefaultParameterMax
        {
            get { return _loadDefaultParameterMax; }
            set { _loadDefaultParameterMax = value; RaisePropertyChanged("LoadDefaultParameterMax"); }
        }
        public int LoadDefaultParameterStep
        {
            get { return _loadDefaultParameterStep; }
            set { _loadDefaultParameterStep = value; RaisePropertyChanged("LoadDefaultParameterStep"); }
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
            LinearDriveUpSpeedFastMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveUpSpeedFastMin);
            LinearDriveUpSpeedFastMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveUpSpeedFastMax);
            LinearDriveUpSpeedFastStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveUpSpeedFastStep);
            LinearDriveUpSpeedSlowMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveUpSpeedSlowMin);
            LinearDriveUpSpeedSlowMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveUpSpeedSlowMax);
            LinearDriveUpSpeedSlowStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveUpSpeedSlowStep);
            LinearDriveDnSpeedFastMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveDnSpeedFastMin);
            LinearDriveDnSpeedFastMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveDnSpeedFastMax);
            LinearDriveDnSpeedFastStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveDnSpeedFastStep);
            LinearDriveDnSpeedSlowMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveDnSpeedSlowMin);
            LinearDriveDnSpeedSlowMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveDnSpeedSlowMax);
            LinearDriveDnSpeedSlowStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveDnSpeedSlowStep);
            DynamicMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.DynamicMin);
            DynamicMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.DynamicMax);
            DynamicStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.DynamicStep);
            SensorCollisionDelayMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.SensorCollisionDelayMin);
            SensorCollisionDelayMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.SensorCollisionDelayMax);
            SensorCollisionDelayStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.SensorCollisionDelayStep);
            LinearDriveRefSpeedMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveRefSpeedMin);
            LinearDriveRefSpeedMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveRefSpeedMax);
            LinearDriveRefSpeedStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDriveRefSpeedStep);
            LinearDrivePosSpeedMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDrivePosSpeedMin);
            LinearDrivePosSpeedMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDrivePosSpeedMax);
            LinearDrivePosSpeedStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LinearDrivePosSpeedStep);
            TactileInitialPosFindingMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.TactileInitialPosFindingMin);
            TactileInitialPosFindingMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.TactileInitialPosFindingMax);
            TactileInitialPosFindingStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.TactileInitialPosFindingStep);
            DistanceCalibrationMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.DistanceCalibrationMin);
            DistanceCalibrationMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.DistanceCalibrationMax);
            DistanceCalibrationStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.DistanceCalibrationStep);
            HoseLengthMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.HoseLengthMin);
            HoseLengthMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.HoseLengthMax);
            HoseLengthStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.HoseLengthStep);
            CutO2BlowOutTimeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.CutO2BlowOutTimeMin);
            CutO2BlowOutTimeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.CutO2BlowOutTimeMax);
            CutO2BlowOutTimeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.CutO2BlowOutTimeStep);
            CutO2BlowOutPressureMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.CutO2BlowOutPressureMin);
            CutO2BlowOutPressureMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.CutO2BlowOutPressureMax);
            CutO2BlowOutPressureStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.CutO2BlowOutPressureStep);
            CutO2BlowOutTimeOutMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.CutO2BlowOutTimeOutMin);
            CutO2BlowOutTimeOutMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.CutO2BlowOutTimeOutMax);
            CutO2BlowOutTimeOutStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.CutO2BlowOutTimeOutStep);
            CapSetpointFlameOffsMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.CapSetpointFlameOffsMin);
            CapSetpointFlameOffsMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.CapSetpointFlameOffsMax);
            CapSetpointFlameOffsStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.CapSetpointFlameOffsStep);
            LoadDefaultParameterMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LoadDefaultParameterMin);
            LoadDefaultParameterMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LoadDefaultParameterMax);
            LoadDefaultParameterStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxConfig.LoadDefaultParameterStep);
        }

    }
}
