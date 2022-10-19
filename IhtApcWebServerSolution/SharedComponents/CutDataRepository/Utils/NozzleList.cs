using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutDataRepository.Utils
{
    public class CNozzleList : List<CNozzle>
    {
        ///////////////////////////////////////////////////////////////////////
        public CNozzle getNozzleById(Guid idNozzle)
        {
            CNozzle Result = null;
            for (int idx = 0; idx < Count; idx++)
            {
                if (this[idx].IdNozzle.Equals(idNozzle))
                {
                    Result = this[idx];
                    break;
                }
            }
            return Result;
        }
    }
}

