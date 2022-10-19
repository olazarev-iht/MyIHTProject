using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutDataRepository.Utils
{
    public class CGas
    {
        private int _IdGas;
        private string _strGas;

        ///////////////////////////////////////////////////////////////////////
        public CGas()
        {
            _IdGas = 0;
            _strGas = "";
        }

        ///////////////////////////////////////////////////////////////////////
        public int IdGas
        {
            get { return _IdGas; }
            set { _IdGas = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public string Gas
        {
            get { return _strGas; }
            set { _strGas = value; }
        }

    }
}
