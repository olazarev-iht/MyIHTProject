using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtData
{
    public class DataParamDynTechnology : INotifyPropertyChanged
    {
        private int _preHeatHeight { get; set; }
        private int _pierceHeight { get; set; }
        private int _cutHeight { get; set; }
        private int _heatO2Ignition { get; set; }
        private int _heatO2PreHeat { get; set; }
        private int _heatO2Pierce { get; set; }
        private int _heatO2Cut { get; set; }
        private int _cutO2Pierce { get; set; }
        private int _cutO2Cut { get; set; }
        private int _fuelGasIgnition { get; set; }
        private int _fuelGasPreHeat { get; set; }
        private int _fuelGasPierce { get; set; }
        private int _fuelGasCut { get; set; }
        private int _preHeatTime { get; set; }
        private int _piercePreTime { get; set; }
        private int _pierceTime { get; set; }
        private int _piercePostTime { get; set; }
        private int _pierceHeightRampTime { get; set; }
        private int _cutHeightRampTime { get; set; }
        private int _pierceMode { get; set; }
        private int _ignitionFlameAdjust { get; set; }
        private int _gasType { get; set; }
        private int _cuttingSpeed { get; set; }
        private int _pierceCuttingSpeedChange { get; set; }
        private int _ctrlBits { get; set; }

        public int PreHeatHeight
        {
            get { return _preHeatHeight; }
            set { _preHeatHeight = value; RaisePropertyChanged("PreHeatHeight"); }
        }

        public int PierceHeight
        {
            get { return _pierceHeight; }
            set { _pierceHeight = value; RaisePropertyChanged("PierceHeight"); }
        }

        public int CutHeight
        {
            get { return _cutHeight; }
            set { _cutHeight = value; RaisePropertyChanged("CutHeight"); }
        }

        public int HeatO2Ignition
        {
            get { return _heatO2Ignition; }
            set { _heatO2Ignition = value; RaisePropertyChanged("HeatO2Ignition"); }
        }

        public int HeatO2PreHeat
        {
            get { return _heatO2PreHeat; }
            set { _heatO2PreHeat = value; RaisePropertyChanged("HeatO2PreHeat"); }
        }

        public int HeatO2Pierce
        {
            get { return _heatO2Pierce; }
            set { _heatO2Pierce = value; RaisePropertyChanged("HeatO2Pierce"); }
        }

        public int HeatO2Cut
        {
            get { return _heatO2Cut; }
            set { _heatO2Cut = value; RaisePropertyChanged("HeatO2Cut"); }
        }

        public int CutO2Pierce
        {
            get { return _cutO2Pierce; }
            set { _cutO2Pierce = value; RaisePropertyChanged("CutO2Pierce"); }
        }

        public int CutO2Cut
        {
            get { return _cutO2Cut; }
            set { _cutO2Cut = value; RaisePropertyChanged("CutO2Cut"); }
        }

        public int FuelGasIgnition
        {
            get { return _fuelGasIgnition; }
            set { _fuelGasIgnition = value; RaisePropertyChanged("FuelGasIgnition"); }
        }

        public int FuelGasPreHeat
        {
            get { return _fuelGasPreHeat; }
            set { _fuelGasPreHeat = value; RaisePropertyChanged("FuelGasPreHeat"); }
        }

        public int FuelGasPierce
        {
            get { return _fuelGasPierce; }
            set { _fuelGasPierce = value; RaisePropertyChanged("FuelGasPierce"); }
        }

        public int FuelGasCut
        {
            get { return _fuelGasCut; }
            set { _fuelGasCut = value; RaisePropertyChanged("FuelGasCut"); }
        }

        public int PreHeatTime
        {
            get { return _preHeatTime; }
            set { _preHeatTime = value; RaisePropertyChanged("PreHeatTime"); }
        }

        public int PiercePreTime
        {
            get { return _piercePreTime; }
            set { _piercePreTime = value; RaisePropertyChanged("PiercePreTime"); }
        }

        public int PierceTime
        {
            get { return _pierceTime; }
            set { _pierceTime = value; RaisePropertyChanged("PierceTime"); }
        }

        public int PiercePostTime
        {
            get { return _piercePostTime; }
            set { _piercePostTime = value; RaisePropertyChanged("PiercePostTime"); }
        }

        public int PierceHeightRampTime
        {
            get { return _pierceHeightRampTime; }
            set { _pierceHeightRampTime = value; RaisePropertyChanged("PierceHeightRampTime"); }
        }

        public int CutHeightRampTime
        {
            get { return _cutHeightRampTime; }
            set { _cutHeightRampTime = value; RaisePropertyChanged("CutHeightRampTime"); }
        }

        public int PierceMode
        {
            get { return _pierceMode; }
            set { _pierceMode = value; RaisePropertyChanged("PierceMode"); }
        }

        public int IgnitionFlameAdjust
        {
            get { return _ignitionFlameAdjust; }
            set { _ignitionFlameAdjust = value; RaisePropertyChanged("IgnitionFlameAdjust"); }
        }

        public int GasType
        {
            get { return _gasType; }
            set { _gasType = value; RaisePropertyChanged("GasType"); }
        }

        public int CuttingSpeed
        {
            get { return _cuttingSpeed; }
            set { _cuttingSpeed = value; RaisePropertyChanged("CuttingSpeed"); }
        }

        public int PierceCuttingSpeedChange
        {
            get { return _pierceCuttingSpeedChange; }
            set { _pierceCuttingSpeedChange = value; RaisePropertyChanged("PierceCuttingSpeedChange"); }
        }

        public int CtrlBits
        {
            get { return _ctrlBits; }
            set { _ctrlBits = value; RaisePropertyChanged("CtrlBits"); }
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
            PreHeatHeight = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PreHeatHeight);
            PierceHeight = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PierceHeight);
            CutHeight = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.CutHeight);
            HeatO2Ignition = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition);
            HeatO2PreHeat = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.HeatO2PreHeat);
            HeatO2Pierce = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.HeatO2Pierce);
            HeatO2Cut = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.HeatO2Cut);
            CutO2Pierce = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.CutO2Pierce);
            CutO2Cut = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.CutO2Cut);
            FuelGasIgnition = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition);
            FuelGasPreHeat = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.FuelGasPreHeat);
            FuelGasPierce = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.FuelGasPierce);
            FuelGasCut = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.FuelGasCut);
            PreHeatTime = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PreHeatTime);
            PiercePreTime = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PiercePreTime);
            PierceTime = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PierceTime);
            PiercePostTime = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PiercePostTime);
            PierceHeightRampTime = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PierceHeightRampTime);
            CutHeightRampTime = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.CutHeightRampTime);
            PierceMode = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PierceMode);
            IgnitionFlameAdjust = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.IgnitionFlameAdjust);
            GasType = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.GasType);
            CuttingSpeed = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.CuttingSpeed);
            PierceCuttingSpeedChange = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PierceCuttingSpeedChange);
            CtrlBits = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.ControlBits);
        }

    }
}
