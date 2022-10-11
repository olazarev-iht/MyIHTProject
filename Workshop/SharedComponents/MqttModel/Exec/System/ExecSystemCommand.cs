using SharedComponents.Machine;
using SharedComponents.Machine.Mqtt;
using Newtonsoft.Json;
using SharedComponents.IhtModbus;
using SharedComponents.IhtDev;

namespace SharedComponents.MqttModel.Exec.System
{
  class ExecSystemCommand
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mqttClient"></param>
    /// <param name="payload"></param>
    /// <returns></returns>
    internal static async Task<Machine.ResultStatus> CommandAsync(MqttClientWrapper mqttClient, string payload)
    {
      Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      JsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);

      // Convert to C# Class typed object
      Helper.CommandSystem request = Helper.JsonHelper.ToClass<Helper.CommandSystem>(payload, jsonSerializerSettings);

      if (errorContext != null && errorContext.Error != null)
      {
        return new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
      }
      else if (request.CommandTag == null)
      {
        return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
      }

      switch (request.CommandTag)
      {
        case Helper.RequestHelper.ClearError  : return await ClearErrorAsync();
        case Helper.RequestHelper.Reconnection: return await ReconnectionAsync();
      }

      return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static async Task<Machine.ResultStatus> ClearErrorAsync()
    {
      int slaveId = (int)IhtModbusCommunic.SlaveId.Id_Broadcast;
      IhtDevices ihtDevices = IhtDevices.GetIhtDevices();
      await ihtDevices.ClrErrorCodeAsync(slaveId);
      return Machine.ResultStatus.NoError;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private static async Task<ResultStatus> ReconnectionAsync()
    {
      /*
      MainWindow mainWindow = MainWindow.GetMainWindow();
      await mainWindow.Dispatcher.BeginInvoke(new Action(async () => 
      {
        await mainWindow.CmdConnectExecAsync();
        mainWindow.TestingExecClickEvent(mainWindow.eventDisplay.btnCloseListViewStatus);
      }));
      */
      return Machine.ResultStatus.NoError;
    }
  }
}
