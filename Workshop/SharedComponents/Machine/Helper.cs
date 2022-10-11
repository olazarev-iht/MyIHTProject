using CutDataRepository.Utils;
using SharedComponents.Helpers;
using SharedComponents.IhtModbus;
using SharedComponents.IhtMsg;
using System.Globalization;

namespace SharedComponents.Machine
{
  class Helper
  {
    public static readonly string PreInfoApc     = "APC -> MACHINE";
    public static readonly string PreInfoMachine = "MACHINE -> APC";

    public static string GetTimeStamp    () => DateTime.Now.ToString("yyyy_MM_dd__HH_mm_ss", CultureInfo.InvariantCulture);
    public static string GetDateTimeDebug() => DateTime.Now.ToString("HH:mm:ss.FFF");

    public static string TimeStamp => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
    
      /// <summary>
    /// Zugehörige Düse und Gasart setzen.
    /// true  -> Gas-Art stimmt mit eingestellter Gas-Art überein
    /// false -> Gas-Art stimmt mit eingestellter Gas-Art nicht überein
    /// </summary>
    public static bool IsAssociatedGasType(CCutData cutData)
    {
      #if false
      IhtCutDataBase ihtCutDataBase = IhtCutDataBase.GetIhtCutDataBase();
      // Zugehörige Düse suchen
      foreach (CNozzle noz in ihtCutDataBase.nozzles)
      {
        if (cutData.IdNozzle == noz.IdNozzle)
        {
          // Düse übernehmen
          cutData.Nozzle = noz;
          break;
        }
      }
      // Zugehörige Gas-Art suchen
      bool gasFound = false;
      foreach (CGas gas in ihtCutDataBase.gases)
      {
        if (cutData.IdGas == gas.IdGas)
        {
          // Gas-Art übernehmen
          cutData.Gas = gas;
          gasFound    = true;
          break;
        }
      }
          
      if (gasFound)
      {
         todo
        return MainWindow.GetMainWindow().IsAssociatedGasType(cutData.Gas);
        return true;
      }
      return false;
      #else
      // todo
      return true;
      #endif
    }

    /// <summary>
    /// Technologie-Daten in Gerät(e) laden
    /// </summary>
    public static async Task<bool> LoadTechnologyDataAsync(CCutData cutData, int slaveId = (int)IhtModbusCommunic.SlaveId.Id_Broadcast)
    {
      // todo
      //return await MainWindow.GetMainWindow().LoadTechnologyDataAsync(cutData, slaveId);
      return true;
    }

    /// <summary>
    /// Status-Info an Status-Fenster setzen
    /// </summary>
    /// <param name="warning"></param>
    /// <param name="msg"></param>
    public static void SetStatusMsg(IhtMsgLog.Info info, string msg)
    {
      MainWndHelper.GetMainWndHelper().SetStatusMsg(info, msg);
    }

  }
}
