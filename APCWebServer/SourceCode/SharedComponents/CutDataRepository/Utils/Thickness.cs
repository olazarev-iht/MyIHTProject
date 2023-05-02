using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutDataRepository.Utils
{
    public class CThickness
    {
        private double _dThickness;

        ///////////////////////////////////////////////////////////////////////
        public CThickness()
        {
            _dThickness = 0.0;
        }

        ///////////////////////////////////////////////////////////////////////
        public double Thickness
        {
            get { return _dThickness; }
            set { _dThickness = value; }
        }
    }
}
