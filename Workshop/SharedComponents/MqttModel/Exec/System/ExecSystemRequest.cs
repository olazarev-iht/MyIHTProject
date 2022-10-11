using SharedComponents.Machine.Mqtt;
using Newtonsoft.Json;
using System.Reflection;
using SharedComponents.MqttModel.Topic;
using CutDataRepository.Utils;
using SharedComponents.IhtModbus;

namespace SharedComponents.MqttModel.Exec.System
{
  /// <summary>
  /// 
  /// </summary>
  class ExecSystemRequest
  {
    /// <summary>
    /// Handling the requests for the system
    /// </summary>
    /// <param name="mqttClient"></param>
    /// <param name="payload"></param>
    /// <returns></returns>
    internal static async Task<Machine.ResultStatus> RequestAsync(MqttClientWrapper mqttClient, string payload)
    {
      Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      JsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);

      // Convert to C# Class typed object
      Helper.RequestSystem request = Helper.JsonHelper.ToClass<Helper.RequestSystem>(payload, jsonSerializerSettings);

      if (errorContext != null && errorContext.Error != null)
      {
        return new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
      }
      else if (request == null || request.RequestTag == null)
      {
        return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
      }

      switch (request.RequestTag)
      {
        case Helper.RequestHelper.SoftwareVersion: return await SoftwareVersionAsync(mqttClient);
        case Helper.RequestHelper.LoadDataRecord : return await LoadDataRecordAsync (mqttClient, payload);
      }

      return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
    }

    /// <summary>
    /// Handling the request for software version of the system
    /// </summary>
    /// <param name="mqttClient"></param>
    /// <returns></returns>
    private static async Task<Machine.ResultStatus> SoftwareVersionAsync(MqttClientWrapper mqttClient)
    {
      int major         = Assembly.GetExecutingAssembly().GetName().Version.Major;
      int majorRevision = Assembly.GetExecutingAssembly().GetName().Version.MajorRevision;
      int minor         = Assembly.GetExecutingAssembly().GetName().Version.Minor;
      int minorRevision = Assembly.GetExecutingAssembly().GetName().Version.MinorRevision;
      int revision      = Assembly.GetExecutingAssembly().GetName().Version.Build;
      int build         = Assembly.GetExecutingAssembly().GetName().Version.Revision;
      SoftwareVersion softwareVersion = new SoftwareVersion();
      softwareVersion.Major    = major;
      softwareVersion.Minor    = minor;
      softwareVersion.Revision = revision;
      softwareVersion.Build    = build;

      Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      JsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);

      var jsonString = Helper.JsonHelper.FromClass<SoftwareVersion>(softwareVersion, true, jsonSerializerSettings);
      
      if (errorContext != null && errorContext.Error != null)
      {
        return new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
      }
      else if (string.IsNullOrEmpty(jsonString))
      {
        return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
      }

      // Antwort senden
      await mqttClient.PublishAsync(TopicApc.SystemResponse, jsonString);

      return Machine.ResultStatus.NoError;
    }

    /// <summary>
    /// Handling the request for loading a data record in all stations
    /// </summary>
    /// <param name="mqttClient"></param>
    /// <param name="payload"></param>
    /// <returns></returns>
    private static async Task<Machine.ResultStatus> LoadDataRecordAsync(MqttClientWrapper mqttClient, string payload)
    {
      Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      JsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);

      // Convert to C# Class typed object
      Common.SystemRequestLoadDataRecord requestLoadDataRecord = Helper.JsonHelper.ToClass<Exec.Common.SystemRequestLoadDataRecord>(payload, jsonSerializerSettings);

      Machine.ResultStatus  resultStatus   = null;
      Common.ResponseStatus responseStatus = null;
      var jsonString = string.Empty;

      // If the conversion went wrong
      if (errorContext != null && errorContext.Error != null)
      {
        resultStatus   = new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
        responseStatus = new Common.ResponseStatus(Helper.RequestHelper.LoadDataRecord, resultStatus);
        jsonString = Helper.JsonHelper.FromClass<Common.ResponseStatus>(responseStatus, true, jsonSerializerSettings);
      }
      // If the DataRecordID is missing
      else if (requestLoadDataRecord == null || requestLoadDataRecord.DataRecordId == null)
      {
        resultStatus   = Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
        responseStatus = new Common.ResponseStatus(Helper.RequestHelper.LoadDataRecord, resultStatus);
        jsonString     = Helper.JsonHelper.FromClass<Common.ResponseStatus>(responseStatus, true, jsonSerializerSettings);
      }

      if (responseStatus != null)
      {
        jsonString = Helper.JsonHelper.FromClass<Common.ResponseStatus>(responseStatus, true, jsonSerializerSettings);
        // Antwort senden
        await mqttClient.PublishAsync(TopicApc.SystemResponse, jsonString);
        return resultStatus;
      }

      // Load data record in all APC-Stations
      CCutData cCutData = new CCutData();
      resultStatus = await LoadDataRecordAsync(requestLoadDataRecord.DataRecordId.Value, cCutData, (int)IhtModbusCommunic.SlaveId.Id_Broadcast);

      // If loading went wrong
      if (resultStatus.Value != Machine.ResultStatus.NoError.Value)
      {
        responseStatus = new Common.ResponseStatus(Helper.RequestHelper.LoadDataRecord, resultStatus);
        jsonString     = Helper.JsonHelper.FromClass<Common.ResponseStatus>(responseStatus, true, jsonSerializerSettings);
        // Send response
        await mqttClient.PublishAsync(TopicApc.SystemResponse, jsonString);
        return resultStatus;
      }
      
      // Send the loaded data record back
      DataBase.ResponseDataRecord loadDataRecord = new DataBase.ResponseDataRecord
        (Helper.RequestHelper.LoadDataRecord,
        Machine.ResultStatus.NoError,
        requestLoadDataRecord.DataRecordId,
        cCutData);

      jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);
      jsonString             = Helper.JsonHelper.FromClass<DataBase.ResponseDataRecord>(loadDataRecord, true, jsonSerializerSettings);

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
      await mqttClient.PublishAsync(TopicApc.SystemResponse, jsonString);
      return Machine.ResultStatus.NoError;
    }

    /// <summary>
    /// Load a data record in all stations
    /// </summary>
    /// <param name="dataRecordId"></param>
    /// <param name="cCutData"></param>
    /// <returns></returns>
    public static async Task<Machine.ResultStatus> LoadDataRecordAsync(int dataRecordId, CCutData cCutData, int slaveId)
    {
      Machine.ResultStatus resultStatus = Machine.ResultStatus.NoError;

      #if false // todo
      // Datensatz mit angeforderter ID in der Datenbank suchen
      Guid guid         = IhtCutDataBase.GetDataRecordGuid(dataRecordId);
      bool dataSetFound = await Repository.isGuidPresentAsync(guid, cCutData);

      // Wenn Datensatz nicht gefunden wurde
      if (!dataSetFound)
      {
        // Status: Datensatz nicht gefunden
        resultStatus = Machine.ResultStatus.DataRecordNotFound;
        string msg = $"{Machine.Helper.PreInfoApc}: ({resultStatus.Value}) {resultStatus.Descprition}";
        Machine.Helper.SetStatusMsg(IhtMsgLog.Info.Warning, msg);
      }
      else
      {
        CGas gas = DataBase.ExecDataBaseRequest.GetGasType();
        List<Exec.DataBase.Data> datas = new List<Exec.DataBase.Data>();
        IhtCutDataBase ihtCutDataBase  = new IhtCutDataBase(IhtCutDataBase.GetIhtCutDataBase().dbRepositoryPath);
        await Repository.findCutDatasAsync(null, null, null, gas, ihtCutDataBase.cutDatas);
        IhtUserControls.DataBaseControl.ApplyMaterialNozzleGasToCutData(ihtCutDataBase, cCutData);

        // Datensatz mit eingestelter Gas-Art überprüfen 
        bool isAssociatedGasType = Machine.Helper.IsAssociatedGasType(cCutData);
        if (!isAssociatedGasType)
        {
          // Status: Gasart vom Datensatz stimmt nicht mit eingstellter Gasart überein
          resultStatus = Machine.ResultStatus.WrongGasType;
          string msg = $"{Machine.Helper.PreInfoApc}: ({resultStatus.Value}) {resultStatus.Descprition}";
          Machine.Helper.SetStatusMsg(IhtMsgLog.Info.Warning, msg);
        }
        else
        {
          // Technologie-Daten in Gerät(e) laden
          bool loadTechnologyData = await Machine.Helper.LoadTechnologyDataAsync(cCutData, slaveId);
          // Bei Erfolg
          if (loadTechnologyData)
          {
            Debug.Print($"{Machine.Helper.GetDateTimeDebug()}: MqttModel.ExecData.DataBaseSet.LoadTechnologyDataAsync() status={resultStatus.Value}, {resultStatus.Descprition}");
          }
          else
          {
            // Status: Fehler beim Laden vom angeforderten Datensatz in Gerät(e)
            resultStatus = Machine.ResultStatus.LoadError;
          }
        }
      }
      #else
      cCutData = new CCutData();
      cCutData.DataRecordId = dataRecordId;
      #endif

      return resultStatus;
    }

  }
}
