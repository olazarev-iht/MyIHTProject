using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtData
{
    public class DataSetupExecution : INotifyPropertyChanged
    {
        private int _heartbeatTimeout { get; set; }
        public int HeartbeatTimeout
        {
            get { return _heartbeatTimeout; }
            set { _heartbeatTimeout = value; RaisePropertyChanged("HeartbeatTimeout"); }
        }

        private int _heartbeat { get; set; }
        public int Heartbeat
        {
            get { return _heartbeat; }
            set { _heartbeat = value; RaisePropertyChanged("Heartbeat"); }
        }

        private int _setup { get; set; }
        public int Setup
        {
            get { return _setup; }
            set { _setup = value; RaisePropertyChanged("Setup"); }
        }

        private int _testPressureOut { get; set; }
        public int TestPressureOut
        {
            get { return _testPressureOut; }
            set { _testPressureOut = value; RaisePropertyChanged("TestPressureOut"); }
        }

        private int _heatO2 { get; set; }
        public int HeatO2
        {
            get { return _heatO2; }
            set { _heatO2 = value; RaisePropertyChanged("HeatO2"); }
        }

        private int _cutO2 { get; set; }
        public int CutO2
        {
            get { return _cutO2; }
            set { _cutO2 = value; RaisePropertyChanged("CutO2"); }
        }

        private int _fuelGas { get; set; }
        public int FuelGas
        {
            get { return _fuelGas; }
            set { _fuelGas = value; RaisePropertyChanged("FuelGas"); }
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
            HeartbeatTimeout = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxSetupExec.HeartbeatTimeout);
            Heartbeat = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxSetupExec.Heartbeat);
            Setup = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxSetupExec.Setup);
            TestPressureOut = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxSetupExec.TestPressureOut);
            HeatO2 = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxSetupExec.HeatO2);
            CutO2 = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxSetupExec.CutO2);
            FuelGas = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxSetupExec.FuelGas);
        }
    }
}
