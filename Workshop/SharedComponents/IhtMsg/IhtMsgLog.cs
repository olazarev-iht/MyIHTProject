using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtMsg
{
    public class IhtMsgLog : INotifyPropertyChanged
    {
        public enum Info
        {
            Ask,
            Error,
            Info,
            Ok,
            Warning,
            None
        }

        private string _msg { get; set; }
        private Info _eInfo { get; set; }
        private string _timeStamp { get; set; }
        private int _no { get; set; }

        public IhtMsgLog() { }

        public IhtMsgLog(Info info, string msg, int no)
        {
            this._eInfo = info;
            this._msg = msg;
            this._timeStamp = (msg.Length > 0 && info != IhtMsgLog.Info.None) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
            this._no = no;
        }

        public string Msg
        {
            get { return _msg; }
            set
            {
                _msg = value;
                RaisePropertyChanged("Msg");
            }
        }

        public Info eInfo
        {
            get { return _eInfo; }
            set
            {
                _eInfo = value;
                RaisePropertyChanged("eInfo");
            }
        }

        public string TimeStamp
        {
            get { return _timeStamp; }
            set
            {
                _timeStamp = value;
                RaisePropertyChanged("TimeStamp");
            }
        }

        public int No
        {
            get { return _no; }
            set
            {
                _no = value;
                RaisePropertyChanged("No");
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
