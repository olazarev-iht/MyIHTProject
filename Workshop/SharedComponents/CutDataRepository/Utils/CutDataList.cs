using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutDataRepository.Utils
{
    public class CCutDataList : List<CCutData>
    {
        ///////////////////////////////////////////////////////////////////////
        public CCutData getCutDataById(Guid idCutData)
        {
            CCutData Result = null;
            for (int idx = 0; idx < Count; idx++)
            {
                if (this[idx].IdCutData.Equals(idCutData))
                {
                    Result = this[idx];
                    break;
                }
            }
            return Result;
        }
    }
}
