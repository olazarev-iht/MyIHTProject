using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutDataRepository.Utils
{
    public class CGasList : List<CGas>
    {
        ///////////////////////////////////////////////////////////////////////
        public CGas getGasById(int idGas)
        {
            CGas Result = null;
            for (int idx = 0; idx < Count; idx++)
            {
                if (this[idx].IdGas == idGas)
                {
                    Result = this[idx];
                    break;
                }
            }
            return Result;
        }
    }
}
