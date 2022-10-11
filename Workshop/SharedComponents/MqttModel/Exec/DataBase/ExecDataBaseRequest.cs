using CutDataRepository;
using CutDataRepository.Utils;
using SharedComponents.Machine.Mqtt;
using SharedComponents.MqttModel.Topic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.CutDataRepository.Utils;

namespace SharedComponents.MqttModel.Exec.DataBase
{
  class ExecDataBaseRequest
  {
    internal static readonly int MaximumNoOfRecords = 50;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mqttClient"></param>
    /// <param name="payload"></param>
    /// <returns></returns>
    internal static async Task<Machine.ResultStatus> RequestAsync(MqttClientWrapper mqttClient, string payload)
    {
      Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      JsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);

      // Convert to C# Class typed object
      Helper.RequestDataBase request = Helper.JsonHelper.ToClass<Helper.RequestDataBase>(payload, jsonSerializerSettings);

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
        case Helper.RequestHelper.NoOfDataRecords: return await NoOfDataRecordsAsync(mqttClient);
        case Helper.RequestHelper.DataRecords    : return await DataRecordsAsync    (mqttClient, payload);
        case Helper.RequestHelper.DataRecord     : return await DataRecordAsync     (mqttClient, payload);
      }

      return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mqttClient"></param>
    /// <param name="payload"></param>
    /// <returns></returns>
    private static async Task<Machine.ResultStatus> NoOfDataRecordsAsync(MqttClientWrapper mqttClient)
    {
      Newtonsoft.Json.Serialization.ErrorContext? errorContext = null;
      JsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);

      CGas gas = GetGasType();
      #if false // todo
      IhtCutDataBase ihtCutDataBase = new IhtCutDataBase(IhtCutDataBase.GetIhtCutDataBase().dbRepositoryPath);
      await Repository.findCutDatasAsync(null, null, null, gas, ihtCutDataBase.cutDatas);
      int noOfDataRecords = ihtCutDataBase.cutDatas.Count;
      #else
      int noOfDataRecords = 25;
      #endif

      ResponseNoOfDataRecords responseNoOfDataRecords = new ResponseNoOfDataRecords(noOfDataRecords);
      var jsonString = Helper.JsonHelper.FromClass<ResponseNoOfDataRecords>(responseNoOfDataRecords, true, jsonSerializerSettings);

      if (errorContext != null && errorContext.Error != null)
      {
        return new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
      }
      else if (string.IsNullOrEmpty(jsonString))
      {
        return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
      }

      // Antwort senden
      await mqttClient.PublishAsync(TopicApc.DataBaseResponse, jsonString);

      return Machine.ResultStatus.NoError;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mqttClient"></param>
    /// <param name="payload"></param>
    /// <returns></returns>
    private static async Task<Machine.ResultStatus> DataRecordsAsync(MqttClientWrapper mqttClient, string payload)
    {
      Newtonsoft.Json.Serialization.ErrorContext? errorContext = null;
      JsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);

      // Convert to C# Class typed object
      RequestDataRecords requestDataRecords = Helper.JsonHelper.ToClass<RequestDataRecords>(payload, jsonSerializerSettings);

      Machine.ResultStatus?  resultStatus   = null;
      Common.ResponseStatus? responseStatus = null;
      var jsonString = string.Empty;

      if (errorContext != null && errorContext.Error != null)
      {
        resultStatus   = new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
        responseStatus = new Common.ResponseStatus(Helper.RequestHelper.DataRecords, resultStatus);
      }
      else if (requestDataRecords == null || requestDataRecords.DataRecordNos == null)
      {
        resultStatus   = Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
        responseStatus = new Common.ResponseStatus(Helper.RequestHelper.DataRecords, resultStatus);
      }
      else if (requestDataRecords.DataRecordNos.Count < 2)
      {
        resultStatus   = Machine.ResultStatus.DataRecordsEndIsMissing;
        responseStatus = new Common.ResponseStatus(Helper.RequestHelper.DataRecords, resultStatus);
      }

      if (responseStatus != null)
      {
        jsonString = Helper.JsonHelper.FromClass<Common.ResponseStatus>(responseStatus, true, jsonSerializerSettings);
        // Antwort senden
        await mqttClient.PublishAsync(TopicApc.DataBaseResponse, jsonString);
        return resultStatus;
      }

      int start = requestDataRecords.DataRecordNos[0];
      int end   = requestDataRecords.DataRecordNos[1];
      
      if (start < 1)
      {
        resultStatus   = Machine.ResultStatus.DataRecordsStartIsLowerOne;
        responseStatus = new Common.ResponseStatus(Helper.RequestHelper.DataRecords, resultStatus);
      }
      else if (start > end)
      {
        resultStatus   = Machine.ResultStatus.DataRecordsStartIsGreaterEnd;
        responseStatus = new Common.ResponseStatus(Helper.RequestHelper.DataRecords, resultStatus);
      }
      else if ((end - start) > MaximumNoOfRecords - 1)
      {
        resultStatus   = Machine.ResultStatus.DataRecordsMaximumNoExceeded;
        responseStatus = new Common.ResponseStatus(Helper.RequestHelper.DataRecords, resultStatus);
      }

      if (responseStatus != null)
      {
        jsonString = Helper.JsonHelper.FromClass<Common.ResponseStatus>(responseStatus, true, jsonSerializerSettings);
        // Antwort senden
        await mqttClient.PublishAsync(TopicApc.DataBaseResponse, jsonString);
        return resultStatus;
      }

      // Datensätze zusammenstellen
      #if false // todo
      CGas gas = GetGasType();
      List<Exec.DataBase.Data> datas = new List<Exec.DataBase.Data>();
      IhtCutDataBase ihtCutDataBase  = new IhtCutDataBase(IhtCutDataBase.GetIhtCutDataBase().dbRepositoryPath);
      await Repository.findCutDatasAsync(null, null, null, gas, ihtCutDataBase.cutDatas);
      IhtUserControls.DataBaseControl.ApplyMaterialNozzleGasToCutDatas(ihtCutDataBase);
      int dataRecordsCnt = 1;
      int dataRecordNos  = 0;
      foreach (CCutData cCutData in ihtCutDataBase.cutDatas)
      {
        if (dataRecordsCnt >= start && dataRecordsCnt <= end)
        {
          datas.Add(new Data(cCutData, IhtCutDataBase.GetDataRecordId(cCutData.IdCutData)));
          ++dataRecordNos;
        }
        ++dataRecordsCnt;
      }
      #else
      List<Exec.DataBase.Data> datas = new List<Exec.DataBase.Data>();
      int dataRecordsCnt = 1;
      int dataRecordNos  = 0;
      for (int i = start; i < end; i++)
      {
        datas.Add(new Data(new CCutData(), dataRecordNos));
        ++dataRecordsCnt;
      }
      #endif

      // Antwort mit Datenssätze
      ResponseDataRecords responseDataRecords = new ResponseDataRecords
        (Machine.ResultStatus.NoError,
        dataRecordNos,
        datas);

      jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);

      jsonString = Helper.JsonHelper.FromClass<ResponseDataRecords>(responseDataRecords, true, jsonSerializerSettings);

      if (errorContext != null && errorContext.Error != null)
      {
        return new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
      }
      else if (string.IsNullOrEmpty(jsonString))
      {
        return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
      }

      // Antwort senden
      await mqttClient.PublishAsync(TopicApc.DataBaseResponse, jsonString);

      return Machine.ResultStatus.NoError;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mqttClient"></param>
    /// <param name="payload"></param>
    /// <returns></returns>
    private static async Task<Machine.ResultStatus> DataRecordAsync(MqttClientWrapper mqttClient, string payload)
    {
      Newtonsoft.Json.Serialization.ErrorContext? errorContext = null;
      JsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);

      // Convert to C# Class typed object
      RequestDataRecord requestDataRecord = Helper.JsonHelper.ToClass<RequestDataRecord>(payload, jsonSerializerSettings);

      Machine.ResultStatus?  resultStatus   = null;
      Common.ResponseStatus? responseStatus = null;
      var jsonString = string.Empty;

      if (errorContext != null && errorContext.Error != null)
      {
        resultStatus   = new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
        responseStatus = new Common.ResponseStatus(Helper.RequestHelper.DataRecords, resultStatus);
      }
      else if (requestDataRecord == null || requestDataRecord.DataRecordId == null)
      {
        resultStatus   = Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
        responseStatus = new Common.ResponseStatus(Helper.RequestHelper.DataRecords, resultStatus);
      }

      if (responseStatus != null)
      {
        jsonString = Helper.JsonHelper.FromClass<Common.ResponseStatus>(responseStatus, true, jsonSerializerSettings);
        // Antwort senden
        await mqttClient.PublishAsync(TopicApc.DataBaseResponse, jsonString);
        return resultStatus;
      }

      CGas gas = GetGasType();
      #if false
      IhtCutDataBase ihtCutDataBase = new IhtCutDataBase(IhtCutDataBase.GetIhtCutDataBase().dbRepositoryPath);
      await Repository.findCutDatasAsync(null, null, null, gas, ihtCutDataBase.cutDatas);
      IhtUserControls.DataBaseControl.ApplyMaterialNozzleGasToCutDatas(ihtCutDataBase);

      CCutData cCutDataRequested = null;
      Guid guid = IhtCutDataBase.GetDataRecordGuid(requestDataRecord.DataRecordId.Value);
      foreach (CCutData cCutData in ihtCutDataBase.cutDatas)
      {
        if (cCutData.IdCutData == guid)
        {
          cCutDataRequested = cCutData;
          break;
        }
      }
      #else
      CCutData cCutDataRequested = new CCutData();
      #endif

      // Wenn Datensatz nicht vorhanden
      if (cCutDataRequested == null)
      {
        resultStatus   = Machine.ResultStatus.DataRecordNotFound;
        responseStatus = new Common.ResponseStatus(Helper.RequestHelper.DataRecord, resultStatus);
        jsonString = Helper.JsonHelper.FromClass<Common.ResponseStatus>(responseStatus, true, jsonSerializerSettings);
        // Antwort senden
        await mqttClient.PublishAsync(TopicApc.DataBaseResponse, jsonString);
        return resultStatus;
      }

      // Antwort mit Datenssatz
      ResponseDataRecord responseDataRecord = new ResponseDataRecord
        (Helper.RequestHelper.DataRecord,
        Machine.ResultStatus.NoError,
        requestDataRecord.DataRecordId.Value,
        cCutDataRequested);

      jsonSerializerSettings = Helper.JsonHelper.CreateSerializerSettings(errorContext);
      jsonString = Helper.JsonHelper.FromClass<ResponseDataRecord>(responseDataRecord, true, jsonSerializerSettings);

      if (errorContext != null && errorContext.Error != null)
      {
        return new Machine.ResultStatus(errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
      }
      else if (string.IsNullOrEmpty(jsonString))
      {
        return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing;
      }

      // Antwort senden
      await mqttClient.PublishAsync(TopicApc.DataBaseResponse, jsonString);

      return Machine.ResultStatus.NoError;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static CGas GetGasType()
    {
      #if false
      Properties.Settings settings = new Properties.Settings();
      IhtCutDataBase ihtCutDataBase = IhtCutDataBase.GetIhtCutDataBase();
      CGas gas = new CGas();
      foreach (CGas cGas in ihtCutDataBase.gases)
      {
        if (cGas.IdGas == settings.TorchType)
        {
          gas = cGas;
          break;
        }
      }
      return gas;
      #else
      CGas cGas = new CGas();
      cGas.IdGas = 0;
      cGas.Gas   = "Propane";
      return cGas;
      #endif
    }

  }
}
