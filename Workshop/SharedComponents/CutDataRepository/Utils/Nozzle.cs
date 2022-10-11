using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutDataRepository.Utils
{
    public class CNozzle
    {
        private Guid _IdNozzle;
        private string _strNozzle;

        ///////////////////////////////////////////////////////////////////////
        public CNozzle()
        {
            _IdNozzle = Guid.Empty;
            _strNozzle = "";
        }

        ///////////////////////////////////////////////////////////////////////
        public Guid IdNozzle
        {
            get { return _IdNozzle; }
            set { _IdNozzle = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public string Nozzle
        {
            get { return _strNozzle; }
            set { _strNozzle = value; }
        }

    }
}
