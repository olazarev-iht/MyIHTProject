using SharedComponents.Machine.Mqtt;
using Newtonsoft.Json;
using SharedComponents.IhtModbus;
using SharedComponents.IhtDev;

namespace SharedComponents.MqttModel.Exec.Station
{
  class ExecStationCommand
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
      Helper.CommandStation request = Helper.JsonHelper.ToClass<Helper.CommandStation>(payload, jsonSerializerSettings);

      if (errorContext != null && errorContext.Error != null)
      {
        return new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
      }
      else if (request == null || request.Station == null || request.CommandTag == null)
      {
        return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
      }

      switch (request.CommandTag)
      {
        case Helper.RequestHelper.ClearError: return await ClearErrorAsync(mqttClient, request.Station);
      }

      return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mqttClient"></param>
    /// <param name="station"></param>
    /// <returns></returns>
    private static async Task<Machine.ResultStatus> ClearErrorAsync(MqttClientWrapper mqttClient, int? station)
    {
      int slaveId = station.Value + (int)IhtModbusCommunic.SlaveId.Id_Default;
      IhtDevices ihtDevices = IhtDevices.GetIhtDevices();
      await ihtDevices.ClrErrorCodeAsync(slaveId);
      return Machine.ResultStatus.NoError;
    }
  }
}
