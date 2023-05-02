using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutDataRepository.Utils
{
    public class CMaterial
    {
        private Guid _IdMaterial;
        private string _strMaterial;

        ///////////////////////////////////////////////////////////////////////
        public CMaterial()
        {
            _IdMaterial = Guid.Empty;
            _strMaterial = "";
        }

        ///////////////////////////////////////////////////////////////////////
        public Guid IdMaterial
        {
            get { return _IdMaterial; }
            set { _IdMaterial = value; }
        }

        ///////////////////////////////////////////////////////////////////////
        public string Material
        {
            get { return _strMaterial; }
            set { _strMaterial = value; }
        }

    }
}
