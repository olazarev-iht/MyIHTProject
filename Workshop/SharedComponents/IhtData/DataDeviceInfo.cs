using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtData
{
    public class DataDeviceInfo : INotifyPropertyChanged
    {
        private int _partNoLWord { get; set; }
        public int PartNoLWord
        {
            get { return _partNoLWord; }
            set { _partNoLWord = value; RaisePropertyChanged("PartNoLWord"); }
        }

        private int _partNoHWord { get; set; }
        public int PartNoHWord
        {
            get { return _partNoHWord; }
            set { _partNoHWord = value; RaisePropertyChanged("PartNoHWord"); }
        }

        private int _serialNoLWord { get; set; }
        public int SerialNoLWord
        {
            get { return _serialNoLWord; }
            set { _serialNoLWord = value; RaisePropertyChanged("SerialNoLWord"); }
        }

        private int _serialNoHWord { get; set; }
        public int SerialNoHWord
        {
            get { return _serialNoHWord; }
            set { _serialNoHWord = value; RaisePropertyChanged("SerialNoHWord"); }
        }

        private int _hwVersion { get; set; }
        public int HwVersion
        {
            get { return _hwVersion; }
            set { _hwVersion = value; RaisePropertyChanged("_hwVersion"); }
        }

        private int _fwVersion { get; set; }
        public int FwVersion
        {
            get { return _fwVersion; }
            set { _fwVersion = value; RaisePropertyChanged("FwVersion"); }
        }

        private int _fwSubVersion { get; set; }
        public int FwSubVersion
        {
            get { return _fwSubVersion; }
            set { _fwSubVersion = value; RaisePropertyChanged("FwSubVersion"); }
        }

        private int _torchPartNoLWord { get; set; }
        public int TorchPartNoLWord
        {
            get { return _torchPartNoLWord; }
            set { _torchPartNoLWord = value; RaisePropertyChanged("TorchPartNoLWord"); }
        }

        private int _torchPartNoHWord { get; set; }
        public int TorchPartNoHWord
        {
            get { return _torchPartNoHWord; }
            set { _torchPartNoHWord = value; RaisePropertyChanged("TorchPartNoHWord"); }
        }

        private int _torchSerialNoLWord { get; set; }
        public int TorchSerialNoLWord
        {
            get { return _torchSerialNoLWord; }
            set { _torchSerialNoLWord = value; RaisePropertyChanged("TorchSerialNoLWord"); }
        }

        private int _torchSerialNoHWord { get; set; }
        public int TorchSerialNoHWord
        {
            get { return _torchSerialNoHWord; }
            set { _torchSerialNoHWord = value; RaisePropertyChanged("TorchSerialNoHWord"); }
        }

        private int _torchHwVersion { get; set; }
        public int TorchHwVersion
        {
            get { return _torchHwVersion; }
            set { _torchHwVersion = value; RaisePropertyChanged("TorchHwVersion"); }
        }

        private int _torchFwVersion { get; set; }
        public int TorchFwVersion
        {
            get { return _torchFwVersion; }
            set { _torchFwVersion = value; RaisePropertyChanged("TorchFwVersion"); }
        }

        private int _torchFwSubVersion { get; set; }
        public int TorchFwSubVersion
        {
            get { return _torchFwSubVersion; }
            set { _torchFwSubVersion = value; RaisePropertyChanged("TorchFwSubVersion"); }
        }

        private int _torchHwFunctions { get; set; }
        public int TorchHwFunctions
        {
            get { return _torchHwFunctions; }
            set { _torchHwFunctions = value; RaisePropertyChanged("TorchHwFunctions"); }
        }

        private int _torchTypeIdx { get; set; }
        public int TorchTypeIdx
        {
            get { return _torchTypeIdx; }
            set { _torchTypeIdx = value; RaisePropertyChanged("TorchTypeIdx"); }
        }


        private int _partNo { get; set; }
        public int PartNo
        {
            get { return _partNo; }
            set { _partNo = value; RaisePropertyChanged("PartNo"); }
        }

        private int _torchPartNo { get; set; }
        public int TorchPartNo
        {
            get { return _torchPartNo; }
            set { _torchPartNo = value; RaisePropertyChanged("TorchPartNo"); }
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
            PartNoLWord = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.PartNoLWord);
            PartNoHWord = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.PartNoHWord);
            SerialNoLWord = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.SerialNoLWord);
            SerialNoHWord = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.SerialNoHWord);
            HwVersion = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.HwVersion);
            FwVersion = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.FwVersion);
            FwSubVersion = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.FwSubVersion);

            TorchPartNoLWord = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchPartNoLWord);
            TorchPartNoHWord = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchPartNoHWord);
            TorchSerialNoLWord = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchSerialNoLWord);
            TorchSerialNoHWord = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchSerialNoHWord);
            TorchHwVersion = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchHwVersion);
            TorchFwVersion = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchFwVersion);
            TorchFwSubVersion = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchFwSubVersion);
            TorchHwFunctions = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchHwFunctions);
            TorchTypeIdx = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.TorchTypeIdx);

            PartNo = PartNoLWord + (PartNoHWord << 16);
            TorchPartNo = TorchPartNoLWord + (TorchPartNoHWord << 16);
        }


    }
}

