using SharedComponents.Machine.Mqtt;
using Newtonsoft.Json;
using CutDataRepository.Utils;
using SharedComponents.MqttModel.Topic;
using SharedComponents.IhtModbus;
using SharedComponents.Models.CuttingData;
using SharedComponents.MqttModel.Exec.DataBase;

namespace SharedComponents.MqttModel.Exec.Station
{
  class ExecStationRequest
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    internal static async Task<Machine.ResultStatus> RequestAsync(MqttClientWrapper mqttClient, string payload)
    {
      Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      JsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);

      // Convert to C# Class typed object
      Helper.RequestStation request = Helper.JsonHelper.ToClass<Helper.RequestStation>(payload, jsonSerializerSettings);

      if (errorContext != null && errorContext.Error != null)
      {
        return new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
      }
      else if (request == null || request.Station == null || request.RequestTag == null)
      {
        return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
      }

      switch (request.RequestTag)
      {
        case Helper.RequestHelper.SoftwareVersion: return await SoftwareVersionAsync(mqttClient, request.Station.Value);
        case Helper.RequestHelper.HardwareVersion: return await HardwareVersionAsync(mqttClient, request.Station.Value);
        case Helper.RequestHelper.LoadDataRecord : return await LoadDataRecordAsync (mqttClient, request.Station.Value, payload);
      }

      return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mqttClient"></param>
    /// <param name="station"></param>
    /// <returns></returns>
    private static async Task<Machine.ResultStatus> SoftwareVersionAsync(MqttClientWrapper mqttClient, int station)
    {
      IhtModbusCommunic ihtModbusCommunic = IhtModbusCommunic.GetIhtModbusCommunic();
      int slaveId = IhtModbusCommunic.GetSlaveId(station);
      IhtModbusData ihtModbusData = ihtModbusCommunic.GetData(slaveId);
      if (ihtModbusData == null)
      {
        return Machine.ResultStatus.ApcStationNotAvailable;
      }
      int fwVersion    = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.FwVersion);
      int fwSubVersion = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.FwSubVersion);

      Version softwareVersion  = new Version(station, Helper.RequestHelper.SoftwareVersion);
      softwareVersion.Major    = (fwVersion & 0xFF00) >> 8;
      softwareVersion.Minor    = (fwVersion & 0x00FF);
      softwareVersion.Revision = fwSubVersion;

      Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      JsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);

      var jsonString = Helper.JsonHelper.FromClass<Version>(softwareVersion, true, jsonSerializerSettings);
      
      if (errorContext != null && errorContext.Error != null)
      {
        return new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
      }
      else if (string.IsNullOrEmpty(jsonString))
      {
        return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
      }

      // Antwort senden
      await mqttClient.PublishAsync(TopicApc.StationResponse, jsonString);

      return Machine.ResultStatus.NoError;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mqttClient"></param>
    /// <param name="station"></param>
    /// <returns></returns>
    private static async Task<Machine.ResultStatus> HardwareVersionAsync(MqttClientWrapper mqttClient, int station)
    {
      IhtModbusCommunic ihtModbusCommunic = IhtModbusCommunic.GetIhtModbusCommunic();
      int slaveId = IhtModbusCommunic.GetSlaveId(station);
      IhtModbusData ihtModbusData = ihtModbusCommunic.GetData(slaveId);
      if (ihtModbusData == null)
      {
        return Machine.ResultStatus.ApcStationNotAvailable;
      }
      int hwVersion    = ihtModbusData.GetValueDeviceInfo(IhtModbusParamConst.eIdxDeviceInfo.HwVersion);
      int hwSubVersion = 0; // Wird aktuell vom Gerät nicht untertsützt

      Version hardVersion = new Version(station, Helper.RequestHelper.HardwareVersion);
      hardVersion.Major    = (hwVersion & 0xFF00) >> 8;
      hardVersion.Minor    = (hwVersion & 0x00FF);
      hardVersion.Revision = hwSubVersion;

      Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      JsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);

      var jsonString = Helper.JsonHelper.FromClass<Version>(hardVersion, true, jsonSerializerSettings);
      
      if (errorContext != null && errorContext.Error != null)
      {
        return new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
      }
      else if (string.IsNullOrEmpty(jsonString))
      {
        return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
      }

      // Antwort senden
      await mqttClient.PublishAsync(TopicApc.StationResponse, jsonString);

      return Machine.ResultStatus.NoError;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mqttClient"></param>
    /// <param name="station"></param>
    /// <param name="payload"></param>
    /// <returns></returns>
    private static async Task<Machine.ResultStatus> LoadDataRecordAsync(MqttClientWrapper mqttClient, int station, string payload)
    {
      Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      JsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);

      // Convert to C# Class typed object
      Exec.Common.StationRequestLoadDataRecord requestLoadDataRecord = Helper.JsonHelper.ToClass<Exec.Common.StationRequestLoadDataRecord>(payload, jsonSerializerSettings);

      Machine.ResultStatus         resultStatus   = null;
      Common.ResponseStatusStation responseStatus = null;
      var jsonString = string.Empty;

      // If the conversion went wrong
      if (errorContext != null && errorContext.Error != null)
      {
        resultStatus   = new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
        responseStatus = new Common.ResponseStatusStation(station, Helper.RequestHelper.LoadDataRecord, resultStatus);
        jsonString = Helper.JsonHelper.FromClass<Common.ResponseStatusStation>(responseStatus, true, jsonSerializerSettings);
      }
      // If the DataRecordID is missing
      else if (requestLoadDataRecord == null || requestLoadDataRecord.DataRecordId == null)
      {
        resultStatus   = Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
        responseStatus = new Common.ResponseStatusStation(station, Helper.RequestHelper.LoadDataRecord, resultStatus);
        jsonString = Helper.JsonHelper.FromClass<Common.ResponseStatusStation>(responseStatus, true, jsonSerializerSettings);
      }

      if (responseStatus != null)
      {
        jsonString = Helper.JsonHelper.FromClass<Common.ResponseStatusStation>(responseStatus, true, jsonSerializerSettings);
        // Antwort senden
        await mqttClient.PublishAsync(TopicApc.StationResponse, jsonString);
        return resultStatus;
      }
      else
      {
        IhtModbusCommunic ihtModbusCommunic = IhtModbusCommunic.GetIhtModbusCommunic();
        int slaveId = IhtModbusCommunic.GetSlaveId(station);
        IhtModbusData ihtModbusData = ihtModbusCommunic.GetData(slaveId);
        if (ihtModbusData == null)
        {
          resultStatus   = Machine.ResultStatus.ApcStationNotAvailable;
          responseStatus = new Common.ResponseStatusStation(station, Helper.RequestHelper.LoadDataRecord, resultStatus);
          jsonString = Helper.JsonHelper.FromClass<Common.ResponseStatusStation>(responseStatus, true, jsonSerializerSettings);
          // Antwort senden
          await mqttClient.PublishAsync(TopicApc.StationResponse, jsonString);
          return resultStatus;
        }
      }


      // Load data record in all APC-Stations
      CuttingDataModel cuttingDataModel = null;

      CCutData cCutData = new CCutData();
      resultStatus = await System.ExecSystemRequest.LoadDataRecordAsync(requestLoadDataRecord.DataRecordId.Value, cuttingDataModel, IhtModbusCommunic.GetSlaveId(station));

      // If loading went wrong
      if (resultStatus.Value != Machine.ResultStatus.NoError.Value)
      {
        responseStatus = new Common.ResponseStatusStation(station, Helper.RequestHelper.LoadDataRecord, resultStatus);
        jsonString     = Helper.JsonHelper.FromClass<Common.ResponseStatusStation>(responseStatus, true, jsonSerializerSettings);
        // Send response
        await mqttClient.PublishAsync(TopicApc.StationResponse, jsonString);
        return resultStatus;
      }

      // Send the loaded data record back
      Exec.Common.StationResponseLoadDataRecord loadDataRecord = new Exec.Common.StationResponseLoadDataRecord
        (station,
        resultStatus,
        requestLoadDataRecord.DataRecordId,
        cCutData);

      jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);
      jsonString = Helper.JsonHelper.FromClass<DataBase.ResponseDataRecord>(loadDataRecord, true, jsonSerializerSettings);

      // If the conversion went wrong
      if (errorContext != null && errorContext.Error != null)
      {
        return new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
      }
      else if (string.IsNullOrEmpty(jsonString))
      {
        return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
      }

      // Send response
      await mqttClient.PublishAsync(TopicApc.StationResponse, jsonString);
      return Machine.ResultStatus.NoError;
    }
  }
}
