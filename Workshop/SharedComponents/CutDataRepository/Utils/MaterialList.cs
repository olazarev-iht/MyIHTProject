using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutDataRepository.Utils
{
    public class CMaterialList : List<CMaterial>
    {
        ///////////////////////////////////////////////////////////////////////
        public CMaterial getMaterialById(Guid idMaterial)
        {
            CMaterial Result = null;
            for (int idx = 0; idx < Count; idx++)
            {
                if (this[idx].IdMaterial.Equals(idMaterial))
                {
                    Result = this[idx];
                    break;
                }
            }
            return Result;
        }
    }
}
