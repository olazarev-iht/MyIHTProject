using CutDataRepository.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.CutDataRepository.Utils
{
  /// <summary>
  /// Only for test
  /// </summary>
  static public class Repository
  {
    internal static async Task findCutDatasAsync(CMaterial Material, CThickness Thickness, CNozzle Nozzle, CGas gas, object cutDatas)
    {
      // todo
      await Task.Delay(0);
    }

    internal static async Task<bool> isRemarkPresentAsync(string dataSetName, CCutData cutData)
    {
      await Task.Delay(0);
      return true;
    }
  }
}
