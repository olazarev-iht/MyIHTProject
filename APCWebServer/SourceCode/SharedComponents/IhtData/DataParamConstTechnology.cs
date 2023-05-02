using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtData
{
    public class DataParamConstTechnology : INotifyPropertyChanged
    {
        private int _preHeatHeightMin { get; set; }
        private int _preHeatHeightMax { get; set; }
        private int _preHeatHeightStep { get; set; }
        private int _pierceHeightMin { get; set; }
        private int _pierceHeightMax { get; set; }
        private int _pierceHeightStep { get; set; }
        private int _cutHeightMin { get; set; }
        private int _cutHeightMax { get; set; }
        private int _cutHeightStep { get; set; }
        private int _heatO2IgnitionMin { get; set; }
        private int _heatO2IgnitionMax { get; set; }
        private int _heatO2IgnitionStep { get; set; }
        private int _heatO2PreHeatMin { get; set; }
        private int _heatO2PreHeatMax { get; set; }
        private int _heatO2PreHeatStep { get; set; }
        private int _heatO2PierceMin { get; set; }
        private int _heatO2PierceMax { get; set; }
        private int _heatO2PierceStep { get; set; }
        private int _heatO2CutMin { get; set; }
        private int _heatO2CutMax { get; set; }
        private int _heatO2CutStep { get; set; }
        private int _cutO2PierceMin { get; set; }
        private int _cutO2PierceMax { get; set; }
        private int _cutO2PierceStep { get; set; }
        private int _cutO2CutMin { get; set; }
        private int _cutO2CutMax { get; set; }
        private int _cutO2CutStep { get; set; }
        private int _fuelGasIgnitionMin { get; set; }
        private int _fuelGasIgnitionMax { get; set; }
        private int _fuelGasIgnitionStep { get; set; }
        private int _fuelGasPreHeatMin { get; set; }
        private int _fuelGasPreHeatMax { get; set; }
        private int _fuelGasPreHeatStep { get; set; }
        private int _fuelGasPierceMin { get; set; }
        private int _fuelGasPierceMax { get; set; }
        private int _fuelGasPierceStep { get; set; }
        private int _fuelGasCutMin { get; set; }
        private int _fuelGasCutMax { get; set; }
        private int _fuelGasCutStep { get; set; }
        private int _preHeatTimeMin { get; set; }
        private int _preHeatTimeMax { get; set; }
        private int _preHeatTimeStep { get; set; }
        private int _piercePreTimeMin { get; set; }
        private int _piercePreTimeMax { get; set; }
        private int _piercePreTimeStep { get; set; }
        private int _pierceTimeMin { get; set; }
        private int _pierceTimeMax { get; set; }
        private int _pierceTimeStep { get; set; }
        private int _piercePostTimeMin { get; set; }
        private int _piercePostTimeMax { get; set; }
        private int _piercePostTimeStep { get; set; }
        private int _pierceHeightRampTimeMin { get; set; }
        private int _pierceHeightRampTimeMax { get; set; }
        private int _pierceHeightRampTimeStep { get; set; }
        private int _cutHeightRampTimeMin { get; set; }
        private int _cutHeightRampTimeMax { get; set; }
        private int _cutHeightRampTimeStep { get; set; }
        private int _pierceModeMin { get; set; }
        private int _pierceModeMax { get; set; }
        private int _pierceModeStep { get; set; }
        private int _ignitionFlameAdjustMin { get; set; }
        private int _ignitionFlameAdjustMax { get; set; }
        private int _ignitionFlameAdjustStep { get; set; }
        private int _gasTypeMin { get; set; }
        private int _gasTypeMax { get; set; }
        private int _gasTypeStep { get; set; }
        private int _cuttingSpeedMin { get; set; }
        private int _cuttingSpeedMax { get; set; }
        private int _cuttingSpeedStep { get; set; }
        private int _pierceCuttingSpeedChangeMin { get; set; }
        private int _pierceCuttingSpeedChangeMax { get; set; }
        private int _pierceCuttingSpeedChangeStep { get; set; }
        private int _ctrlBitsMin { get; set; }
        private int _ctrlBitsMax { get; set; }
        private int _ctrlBitsStep { get; set; }
        private int _ignitonDetectionEnableMin { get; set; }
        private int _ignitonDetectionEnableMax { get; set; }
        private int _ignitonDetectionEnableStep { get; set; }

        public int PreHeatHeightMin
        {
            get { return _preHeatHeightMin; }
            set { _preHeatHeightMin = value; RaisePropertyChanged("PreHeatHeightMin"); }
        }
        public int PreHeatHeightMax
        {
            get { return _preHeatHeightMax; }
            set { _preHeatHeightMax = value; RaisePropertyChanged("PreHeatHeightMax"); }
        }
        public int PreHeatHeightStep
        {
            get { return _preHeatHeightStep; }
            set { _preHeatHeightStep = value; RaisePropertyChanged("PreHeatHeightStep"); }
        }

        public int PierceHeightMin
        {
            get { return _pierceHeightMin; }
            set { _pierceHeightMin = value; RaisePropertyChanged("PierceHeightMin"); }
        }
        public int PierceHeightMax
        {
            get { return _pierceHeightMax; }
            set { _pierceHeightMax = value; RaisePropertyChanged("PierceHeightMax"); }
        }
        public int PierceHeightStep
        {
            get { return _pierceHeightStep; }
            set { _pierceHeightStep = value; RaisePropertyChanged("PierceHeightStep"); }
        }

        public int CutHeightMin
        {
            get { return _cutHeightMin; }
            set { _cutHeightMin = value; RaisePropertyChanged("CutHeightMin"); }
        }
        public int CutHeightMax
        {
            get { return _cutHeightMax; }
            set { _cutHeightMax = value; RaisePropertyChanged("CutHeightMax"); }
        }
        public int CutHeightStep
        {
            get { return _cutHeightStep; }
            set { _cutHeightStep = value; RaisePropertyChanged("CutHeightStep"); }
        }

        public int HeatO2IgnitionMin
        {
            get { return _heatO2IgnitionMin; }
            set { _heatO2IgnitionMin = value; RaisePropertyChanged("HeatO2IgnitionMin"); }
        }
        public int HeatO2IgnitionMax
        {
            get { return _heatO2IgnitionMax; }
            set { _heatO2IgnitionMax = value; RaisePropertyChanged("HeatO2IgnitionMax"); }
        }
        public int HeatO2IgnitionStep
        {
            get { return _heatO2IgnitionStep; }
            set { _heatO2IgnitionStep = value; RaisePropertyChanged("HeatO2IgnitionStep"); }
        }

        public int HeatO2PreHeatMin
        {
            get { return _heatO2PreHeatMin; }
            set { _heatO2PreHeatMin = value; RaisePropertyChanged("HeatO2PreHeatMin"); }
        }
        public int HeatO2PreHeatMax
        {
            get { return _heatO2PreHeatMax; }
            set { _heatO2PreHeatMax = value; RaisePropertyChanged("HeatO2PreHeatMax"); }
        }
        public int HeatO2PreHeatStep
        {
            get { return _heatO2PreHeatStep; }
            set { _heatO2PreHeatStep = value; RaisePropertyChanged("HeatO2PreHeatStep"); }
        }

        public int HeatO2PierceMin
        {
            get { return _heatO2PierceMin; }
            set { _heatO2PierceMin = value; RaisePropertyChanged("HeatO2PierceMin"); }
        }
        public int HeatO2PierceMax
        {
            get { return _heatO2PierceMax; }
            set { _heatO2PierceMax = value; RaisePropertyChanged("HeatO2PierceMax"); }
        }
        public int HeatO2PierceStep
        {
            get { return _heatO2PierceStep; }
            set { _heatO2PierceStep = value; RaisePropertyChanged("HeatO2PierceStep"); }
        }

        public int HeatO2CutMin
        {
            get { return _heatO2CutMin; }
            set { _heatO2CutMin = value; RaisePropertyChanged("HeatO2CutMin"); }
        }
        public int HeatO2CutMax
        {
            get { return _heatO2CutMax; }
            set { _heatO2CutMax = value; RaisePropertyChanged("HeatO2CutMax"); }
        }
        public int HeatO2CutStep
        {
            get { return _heatO2CutStep; }
            set { _heatO2CutStep = value; RaisePropertyChanged("HeatO2CutStep"); }
        }

        public int CutO2PierceMin
        {
            get { return _cutO2PierceMin; }
            set { _cutO2PierceMin = value; RaisePropertyChanged("CutO2PierceMin"); }
        }
        public int CutO2PierceMax
        {
            get { return _cutO2PierceMax; }
            set { _cutO2PierceMax = value; RaisePropertyChanged("CutO2PierceMax"); }
        }
        public int CutO2PierceStep
        {
            get { return _cutO2PierceStep; }
            set { _cutO2PierceStep = value; RaisePropertyChanged("CutO2PierceStep"); }
        }

        public int CutO2CutMin
        {
            get { return _cutO2CutMin; }
            set { _cutO2CutMin = value; RaisePropertyChanged("CutO2CutMin"); }
        }
        public int CutO2CutMax
        {
            get { return _cutO2CutMax; }
            set { _cutO2CutMax = value; RaisePropertyChanged("CutO2CutMax"); }
        }
        public int CutO2CutStep
        {
            get { return _cutO2CutStep; }
            set { _cutO2CutStep = value; RaisePropertyChanged("CutO2CutStep"); }
        }

        public int FuelGasIgnitionMin
        {
            get { return _fuelGasIgnitionMin; }
            set { _fuelGasIgnitionMin = value; RaisePropertyChanged("FuelGasIgnitionMin"); }
        }
        public int FuelGasIgnitionMax
        {
            get { return _fuelGasIgnitionMax; }
            set { _fuelGasIgnitionMax = value; RaisePropertyChanged("FuelGasIgnitionMax"); }
        }
        public int FuelGasIgnitionStep
        {
            get { return _fuelGasIgnitionStep; }
            set { _fuelGasIgnitionStep = value; RaisePropertyChanged("FuelGasIgnitionStep"); }
        }

        public int FuelGasPreHeatMin
        {
            get { return _fuelGasPreHeatMin; }
            set { _fuelGasPreHeatMin = value; RaisePropertyChanged("FuelGasPreHeatMin"); }
        }
        public int FuelGasPreHeatMax
        {
            get { return _fuelGasPreHeatMax; }
            set { _fuelGasPreHeatMax = value; RaisePropertyChanged("FuelGasPreHeatMax"); }
        }
        public int FuelGasPreHeatStep
        {
            get { return _fuelGasPreHeatStep; }
            set { _fuelGasPreHeatStep = value; RaisePropertyChanged("FuelGasPreHeatStep"); }
        }

        public int FuelGasPierceMin
        {
            get { return _fuelGasPierceMin; }
            set { _fuelGasPierceMin = value; RaisePropertyChanged("FuelGasPierceMin"); }
        }
        public int FuelGasPierceMax
        {
            get { return _fuelGasPierceMax; }
            set { _fuelGasPierceMax = value; RaisePropertyChanged("FuelGasPierceMax"); }
        }
        public int FuelGasPierceStep
        {
            get { return _fuelGasPierceStep; }
            set { _fuelGasPierceStep = value; RaisePropertyChanged("FuelGasPierceStep"); }
        }

        public int FuelGasCutMin
        {
            get { return _fuelGasCutMin; }
            set { _fuelGasCutMin = value; RaisePropertyChanged("FuelGasCutMin"); }
        }
        public int FuelGasCutMax
        {
            get { return _fuelGasCutMax; }
            set { _fuelGasCutMax = value; RaisePropertyChanged("FuelGasCutMax"); }
        }
        public int FuelGasCutStep
        {
            get { return _fuelGasCutStep; }
            set { _fuelGasCutStep = value; RaisePropertyChanged("FuelGasCutStep"); }
        }

        public int PreHeatTimeMin
        {
            get { return _preHeatTimeMin; }
            set { _preHeatTimeMin = value; RaisePropertyChanged("PreHeatTimeMin"); }
        }
        public int PreHeatTimeMax
        {
            get { return _preHeatTimeMax; }
            set { _preHeatTimeMax = value; RaisePropertyChanged("PreHeatTimeMax"); }
        }
        public int PreHeatTimeStep
        {
            get { return _preHeatTimeStep; }
            set { _preHeatTimeStep = value; RaisePropertyChanged("PreHeatTimeStep"); }
        }

        public int PiercePreTimeMin
        {
            get { return _piercePreTimeMin; }
            set { _piercePreTimeMin = value; RaisePropertyChanged("PiercePreTimeMin"); }
        }
        public int PiercePreTimeMax
        {
            get { return _piercePreTimeMax; }
            set { _piercePreTimeMax = value; RaisePropertyChanged("PiercePreTimeMax"); }
        }
        public int PiercePreTimeStep
        {
            get { return _piercePreTimeStep; }
            set { _piercePreTimeStep = value; RaisePropertyChanged("PiercePreTimeStep"); }
        }

        public int PierceTimeMin
        {
            get { return _pierceTimeMin; }
            set { _pierceTimeMin = value; RaisePropertyChanged("PierceTimeMin"); }
        }
        public int PierceTimeMax
        {
            get { return _pierceTimeMax; }
            set { _pierceTimeMax = value; RaisePropertyChanged("PierceTimeMax"); }
        }
        public int PierceTimeStep
        {
            get { return _pierceTimeStep; }
            set { _pierceTimeStep = value; RaisePropertyChanged("PierceTimeStep"); }
        }

        public int PiercePostTimeMin
        {
            get { return _piercePostTimeMin; }
            set { _piercePostTimeMin = value; RaisePropertyChanged("PiercePostTimeMin"); }
        }
        public int PiercePostTimeMax
        {
            get { return _piercePostTimeMax; }
            set { _piercePostTimeMax = value; RaisePropertyChanged("PiercePostTimeMax"); }
        }
        public int PiercePostTimeStep
        {
            get { return _piercePostTimeStep; }
            set { _piercePostTimeStep = value; RaisePropertyChanged("PiercePostTimeStep"); }
        }

        public int PierceHeightRampTimeMin
        {
            get { return _pierceHeightRampTimeMin; }
            set { _pierceHeightRampTimeMin = value; RaisePropertyChanged("PierceHeightRampTimeMin"); }
        }
        public int PierceHeightRampTimeMax
        {
            get { return _pierceHeightRampTimeMax; }
            set { _pierceHeightRampTimeMax = value; RaisePropertyChanged("PierceHeightRampTimeMax"); }
        }
        public int PierceHeightRampTimeStep
        {
            get { return _pierceHeightRampTimeStep; }
            set { _pierceHeightRampTimeStep = value; RaisePropertyChanged("PierceHeightRampTimeStep"); }
        }

        public int CutHeightRampTimeMin
        {
            get { return _cutHeightRampTimeMin; }
            set { _cutHeightRampTimeMin = value; RaisePropertyChanged("CutHeightRampTimeMin"); }
        }
        public int CutHeightRampTimeMax
        {
            get { return _cutHeightRampTimeMax; }
            set { _cutHeightRampTimeMax = value; RaisePropertyChanged("CutHeightRampTimeMax"); }
        }
        public int CutHeightRampTimeStep
        {
            get { return _cutHeightRampTimeStep; }
            set { _cutHeightRampTimeStep = value; RaisePropertyChanged("CutHeightRampTimeStep"); }
        }

        public int PierceModeMin
        {
            get { return _pierceModeMin; }
            set { _pierceModeMin = value; RaisePropertyChanged("PierceModeMin"); }
        }
        public int PierceModeMax
        {
            get { return _pierceModeMax; }
            set { _pierceModeMax = value; RaisePropertyChanged("PierceModeMax"); }
        }
        public int PierceModeStep
        {
            get { return _pierceModeStep; }
            set { _pierceModeStep = value; RaisePropertyChanged("PierceModeStep"); }
        }

        public int IgnitionFlameAdjustMin
        {
            get { return _ignitionFlameAdjustMin; }
            set { _ignitionFlameAdjustMin = value; RaisePropertyChanged("IgnitionFlameAdjustMin"); }
        }
        public int IgnitionFlameAdjustMax
        {
            get { return _ignitionFlameAdjustMax; }
            set { _ignitionFlameAdjustMax = value; RaisePropertyChanged("IgnitionFlameAdjustMax"); }
        }
        public int IgnitionFlameAdjustStep
        {
            get { return _ignitionFlameAdjustStep; }
            set { _ignitionFlameAdjustStep = value; RaisePropertyChanged("IgnitionFlameAdjustStep"); }
        }

        public int GasTypeMin
        {
            get { return _gasTypeMin; }
            set { _gasTypeMin = value; RaisePropertyChanged("GasTypeMin"); }
        }
        public int GasTypeMax
        {
            get { return _gasTypeMax; }
            set { _gasTypeMax = value; RaisePropertyChanged("GasTypeMax"); }
        }
        public int GasTypeStep
        {
            get { return _gasTypeStep; }
            set { _gasTypeStep = value; RaisePropertyChanged("GasTypeStep"); }
        }

        public int CuttingSpeedMin
        {
            get { return _cuttingSpeedMin; }
            set { _cuttingSpeedMin = value; RaisePropertyChanged("CuttingSpeedMin"); }
        }
        public int CuttingSpeedMax
        {
            get { return _cuttingSpeedMax; }
            set { _cuttingSpeedMax = value; RaisePropertyChanged("CuttingSpeedMax"); }
        }
        public int CuttingSpeedStep
        {
            get { return _cuttingSpeedStep; }
            set { _cuttingSpeedStep = value; RaisePropertyChanged("CuttingSpeedStep"); }
        }

        public int PierceCuttingSpeedChangeMin
        {
            get { return _pierceCuttingSpeedChangeMin; }
            set { _pierceCuttingSpeedChangeMin = value; RaisePropertyChanged("PierceCuttingSpeedChangeMin"); }
        }
        public int PierceCuttingSpeedChangeMax
        {
            get { return _pierceCuttingSpeedChangeMax; }
            set { _pierceCuttingSpeedChangeMax = value; RaisePropertyChanged("PierceCuttingSpeedChangeMax"); }
        }
        public int PierceCuttingSpeedChangeStep
        {
            get { return _pierceCuttingSpeedChangeStep; }
            set { _pierceCuttingSpeedChangeStep = value; RaisePropertyChanged("PierceCuttingSpeedChangeStep"); }
        }

        public int CtrlBitsMin
        {
            get { return _ctrlBitsMin; }
            set { _ctrlBitsMin = value; RaisePropertyChanged("CtrlBitsMin"); }
        }
        public int CtrlBitsMax
        {
            get { return _ctrlBitsMax; }
            set { _ctrlBitsMax = value; RaisePropertyChanged("CtrlBitsMax"); }
        }
        public int CtrlBitsStep
        {
            get { return _ctrlBitsStep; }
            set { _ctrlBitsStep = value; RaisePropertyChanged("CtrlBitsStep"); }
        }

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
            PreHeatHeightMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PreHeatHeightMin);
            PreHeatHeightMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PreHeatHeightMax);
            PreHeatHeightStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PreHeatHeightStep);
            PierceHeightMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceHeightMin);
            PierceHeightMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceHeightMax);
            PierceHeightStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceHeightStep);
            CutHeightMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CutHeightMin);
            CutHeightMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CutHeightMax);
            CutHeightStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CutHeightStep);
            HeatO2IgnitionMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.HeatO2IgnitionMin);
            HeatO2IgnitionMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.HeatO2IgnitionMax);
            HeatO2IgnitionStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.HeatO2IgnitionStep);
            HeatO2PreHeatMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.HeatO2PreHeatMin);
            HeatO2PreHeatMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.HeatO2PreHeatMax);
            HeatO2PreHeatStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.HeatO2PreHeatStep);
            HeatO2PierceMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.HeatO2PierceMin);
            HeatO2PierceMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.HeatO2PierceMax);
            HeatO2PierceStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.HeatO2PierceStep);
            HeatO2CutMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.HeatO2CutMin);
            HeatO2CutMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.HeatO2CutMax);
            HeatO2CutStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.HeatO2CutStep);
            CutO2PierceMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CutO2PierceMin);
            CutO2PierceMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CutO2PierceMax);
            CutO2PierceStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CutO2PierceStep);
            CutO2CutMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CutO2CutMin);
            CutO2CutMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CutO2CutMax);
            CutO2CutStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CutO2CutStep);
            FuelGasIgnitionMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.FuelGasIgnitionMin);
            FuelGasIgnitionMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.FuelGasIgnitionMax);
            FuelGasIgnitionStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.FuelGasIgnitionStep);
            FuelGasPreHeatMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.FuelGasPreHeatMin);
            FuelGasPreHeatMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.FuelGasPreHeatMax);
            FuelGasPreHeatStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.FuelGasPreHeatStep);
            FuelGasPierceMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.FuelGasPierceMin);
            FuelGasPierceMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.FuelGasPierceMax);
            FuelGasPierceStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.FuelGasPierceStep);
            FuelGasCutMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.FuelGasCutMin);
            FuelGasCutMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.FuelGasCutMax);
            FuelGasCutStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.FuelGasCutStep);
            PreHeatTimeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PreHeatTimeMin);
            PreHeatTimeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PreHeatTimeMax);
            PreHeatTimeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PreHeatTimeStep);
            PiercePreTimeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PiercePreTimeMin);
            PiercePreTimeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PiercePreTimeMax);
            PiercePreTimeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PiercePreTimeStep);
            PierceTimeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceTimeMin);
            PierceTimeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceTimeMax);
            PierceTimeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceTimeStep);
            PiercePostTimeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PiercePostTimeMin);
            PiercePostTimeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PiercePostTimeMax);
            PiercePostTimeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PiercePostTimeStep);
            PierceHeightRampTimeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceHeightRampTimeMin);
            PierceHeightRampTimeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceHeightRampTimeMax);
            PierceHeightRampTimeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceHeightRampTimeStep);
            CutHeightRampTimeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CutHeightRampTimeMin);
            CutHeightRampTimeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CutHeightRampTimeMax);
            CutHeightRampTimeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CutHeightRampTimeStep);
            PierceModeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceModeMin);
            PierceModeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceModeMax);
            PierceModeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceModeStep);
            IgnitionFlameAdjustMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.IgnitionFlameAdjustMin);
            IgnitionFlameAdjustMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.IgnitionFlameAdjustMax);
            IgnitionFlameAdjustStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.IgnitionFlameAdjustStep);
            GasTypeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.GasTypeMin);
            GasTypeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.GasTypeMax);
            GasTypeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.GasTypeStep);
            CuttingSpeedMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CuttingSpeedMin);
            CuttingSpeedMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CuttingSpeedMax);
            CuttingSpeedStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.CuttingSpeedStep);
            PierceCuttingSpeedChangeMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceCuttingSpeedChangeMin);
            PierceCuttingSpeedChangeMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceCuttingSpeedChangeMax);
            PierceCuttingSpeedChangeStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.PierceCuttingSpeedChangeStep);
            CtrlBitsMin = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.ControlBitsMin);
            CtrlBitsMax = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.ControlBitsMax);
            CtrlBitsStep = ihtModbusData.GetValue(IhtModbusParamConst.eIdxTechnology.ControlBitsStep);
        }

    }
}
