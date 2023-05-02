using CutDataRepository.Utils;
using SharedComponents.Helpers;
using SharedComponents.IhtModbus;
using SharedComponents.IhtMsg;
using SharedComponents.Models.CuttingData;
using SharedComponents.MqttModel.Exec.DataBase;
using System.Collections;
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
      return false; // todo
    }

    /// <summary>
    /// Zugehörige Düse und Gasart setzen.
    /// true  -> Gas-Art stimmt mit eingestellter Gas-Art überein
    /// false -> Gas-Art stimmt mit eingestellter Gas-Art nicht überein
    /// </summary>
    public static bool IsAssociatedGasType(CuttingDataModel? cuttingDataModel)
    {
      return (int)ExecDataBaseRequest.InstanceIhtDevices().TorchTypeSetup == cuttingDataModel.Gas.GasId;
    }

    /// <summary>
    /// Technologie-Daten in Gerät(e) laden
    /// </summary>
    public static async Task<bool> LoadTechnologyDataAsync(CCutData cutData, int slaveId = (int)IhtModbusCommunic.SlaveId.Id_Broadcast)
    {
      return false; // todo
    }

    public static async Task<bool> LoadTechnologyDataAsync(CuttingDataModel? cuttingDataModel, int slaveId = (int)IhtModbusCommunic.SlaveId.Id_Broadcast)
    {
      ArrayList arrayList = new ArrayList();
      var modbusDatas = ExecDataBaseRequest.InstanceIhtDevices().ihtModbusCommunic.GetConnectedModbusDatas();
      if (slaveId != (int)IhtModbusCommunic.SlaveId.Id_Broadcast)
      {
        foreach (IhtModbusData modbusData in modbusDatas)
        {
          if (modbusData.SlaveId == slaveId)
          {
            arrayList.Add(modbusData);
            modbusDatas = arrayList;
            break;
          }
        }
        if (arrayList.Count == 0)
        {
          return false;
        }
      }
      await ExecDataBaseRequest.InstanceParameterDataInfoManager().LoadCuttingDataParamsFromDBAsync(modbusDatas, cuttingDataModel);

      ExecDataBaseRequest.InstanceAPCWorker()._apcWorkerService_DynDataLoaded();

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
