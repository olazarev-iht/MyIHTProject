using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using Microsoft.Win32;
using SharedComponents.IhtDev;
using SharedComponents.Models;

namespace SharedComponents.IhtModbus
{
    public class IhtModbusCommunicData : INotifyPropertyChanged
    {
        private bool _isTcp { get; set; }
        private bool _isRtu { get; set; }
        private string _ipAddress { get; set; }
        private int _ipPort { get; set; }
        private string _comPort { get; set; }
        private string _comPortLast { get; set; }
        private int _baudrate { get; set; }
        private int _dataBits { get; set; }
        private Parity _parity { get; set; }
        private StopBits _stopBits { get; set; }
        private int _writeTimeout_ms { get; set; }
        private int _readTimeout_ms { get; set; }
        private int _slaveId { get; set; }
        private int _testSlaveId { get; set; }
        private bool _isExecReset { get; set; }

        public IhtModbusCommunicData()
        {
            _isTcp = false;
            _isRtu = true;
            _ipAddress = "10.0.0.21";
            _ipPort = 502;
            _comPort = "COM1";
            _comPortLast = "COM1";
            _baudrate = 57600;
            _dataBits = 8;
            _parity = Parity.Even;
            _stopBits = StopBits.One;
            _writeTimeout_ms = 1000;
            _readTimeout_ms = 1000;
            _slaveId = 11;
            _isExecReset = false;
        }

        internal void UpdateSettings(Settings settings)
        {
            settings.Mode = (IsTcp == true) ? 0 : 1;
            settings.TcpPort = IpPort.ToString();
            settings.IpAddr = IpAddress;
            settings.ComPort = ComPort;
            settings.ComPortLast = ComPortLast;
            settings.Baudrate = Baudrate.ToString();
            settings.DataBits = DataBits.ToString();
            settings.Parity = Parity.ToString();
            settings.StopBits = StopBits.ToString();
            settings.Identifier = SlaveId.ToString();
            settings.ExecReset = IsExecReset;
        }

        internal void LoadSettings(SystemSettings settings)
        {
            IsTcp = settings.Mode == 0;
            IsRtu = !IsTcp;
            IpPort = int.Parse(settings.TcpPort ?? "");
            IpAddress = settings.IpAddr ?? "";
            ComPort = settings.ComPort ?? "";
            ComPortLast = settings.ComPortLast ?? "";
            Baudrate = int.Parse(settings.Baudrate ?? "");
            DataBits = int.Parse(settings.DataBits ?? "");
            Parity = (Parity)Enum.Parse(typeof(Parity), settings.Parity 
                ?? throw new Exception("Parity setting value is empty when getting settings"));
            StopBits = (StopBits)Enum.Parse(typeof(StopBits), settings.StopBits
                ?? throw new Exception("StopBits setting value is empty when getting settings"));
            SlaveId = int.Parse(settings.Identifier ?? "");
            IsExecReset = settings.ExecReset ?? false;
        }

        internal void UpdateSettings(SystemSettings settings)
        {
            settings.Mode = (IsTcp == true) ? 0 : 1;
            settings.TcpPort = IpPort.ToString();
            settings.IpAddr = IpAddress;
            settings.ComPort = ComPort;
            settings.ComPortLast = ComPortLast;
            settings.Baudrate = Baudrate.ToString();
            settings.DataBits = DataBits.ToString();
            settings.Parity = Parity.ToString();
            settings.StopBits = StopBits.ToString();
            settings.Identifier = SlaveId.ToString();
            settings.ExecReset = IsExecReset;
        }

        public bool IsTcp
        {
            get { return _isTcp; }
            set
            {
                _isTcp = value;
                RaisePropertyChanged("IsTcp");
            }
        }

        public bool IsRtu
        {
            get { return _isRtu; }
            set
            {
                _isRtu = value;
                RaisePropertyChanged("IsRtu");
            }
        }


        public string IpAddress
        {
            get { return _ipAddress; }
            set
            {
                _ipAddress = value;
                RaisePropertyChanged("IpAddress");
            }
        }

        public int IpPort
        {
            get { return _ipPort; }
            set
            {
                _ipPort = value;
                RaisePropertyChanged("IpPort");
            }
        }

        public string ComPort
        {
            get { return _comPort; }
            set
            {
                _comPort = value;
                RaisePropertyChanged("ComPort");
            }
        }

        public string ComPortLast
        {
            get { return _comPortLast; }
            set
            {
                _comPortLast = value;
                RaisePropertyChanged("ComPortLast");
            }
        }

        public int Baudrate
        {
            get { return _baudrate; }
            set
            {
                _baudrate = value;
                RaisePropertyChanged("Baudrate");
            }
        }

        public int DataBits
        {
            get { return _dataBits; }
            set
            {
                _dataBits = value;
                RaisePropertyChanged("DataBits");
            }
        }

        public Parity Parity
        {
            get { return _parity; }
            set
            {
                _parity = value;
                RaisePropertyChanged("Parity");
            }
        }

        public StopBits StopBits
        {
            get { return _stopBits; }
            set
            {
                _stopBits = value;
                RaisePropertyChanged("StopBits");
            }
        }

        public int WriteTimeout_ms
        {
            get { return _writeTimeout_ms; }
            set
            {
                _writeTimeout_ms = value;
                RaisePropertyChanged("WriteTimeout_ms");
            }
        }

        public int ReadTimeout_ms
        {
            get { return _readTimeout_ms; }
            set
            {
                _readTimeout_ms = value;
                RaisePropertyChanged("ReadTimeout_ms");
            }
        }

        public int SlaveId
        {
            get { return _slaveId; }
            set
            {
                _slaveId = value;
                RaisePropertyChanged("SlaveId");
            }
        }


        public bool IsExecReset
        {
            get { return _isExecReset; }
            set
            {
                _isExecReset = value;
                RaisePropertyChanged("IsExecReset");
            }
        }

        // Helper-Methode, um nicht in jedem Set-Accessor zu prüfen, ob PropertyRaisePropertyChanged!=null
        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }

}
