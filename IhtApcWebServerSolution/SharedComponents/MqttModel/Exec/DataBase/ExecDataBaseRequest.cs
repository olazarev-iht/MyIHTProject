using CutDataRepository.Utils;
using SharedComponents.Machine.Mqtt;
using SharedComponents.MqttModel.Topic;
using Newtonsoft.Json;
using SharedComponents.Models.CuttingData;
using Microsoft.Extensions.DependencyInjection;
using SharedComponents.Services.CuttingDataDBServices;
using SharedComponents.IhtDev;
using SharedComponents.Services.APCHardwareManagers;
using SharedComponents.Services.APCWorkerService;

namespace SharedComponents.MqttModel.Exec.DataBase
{
  public class ExecDataBaseRequest
  {
    internal static readonly int MaximumNoOfRecords = 50;


    private static ICuttingDataDBService? _cuttingDataDBService;
    private static IhtDevices? _ihtDevices;
    private static IParameterDataInfoManager? _parameterDataInfoManager;
    private static IAPCWorker? _apcWorker;
    public static void CuttingDataDBServiceConfigure(ICuttingDataDBService? context)
    {
      _cuttingDataDBService = context;
    }
    public static ICuttingDataDBService? InstanceCuttingDataDBService()
    {
      return _cuttingDataDBService;
    }

    public static void IhtDevicesConfigure(IhtDevices? context)
    {
      _ihtDevices = context;
    }
    public static IhtDevices? InstanceIhtDevices()
    {
      return _ihtDevices;
    }

    public static void ParameterDataInfoManagerConfigure(IParameterDataInfoManager? context)
    {
      _parameterDataInfoManager = context;
    }
    public static IParameterDataInfoManager? InstanceParameterDataInfoManager()
    {
      return _parameterDataInfoManager;
    }

    public static void APCWorkerConfigure(IAPCWorker? context)
    {
      _apcWorker = context;
    }
    public static IAPCWorker? InstanceAPCWorker()
    {
      return _apcWorker;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mqttClient"></param>
    /// <param name="payload"></param>
    /// <returns></returns>
    internal static async Task<Machine.ResultStatus> RequestAsync(MqttClientWrapper mqttClient, string payload)
    {
      //Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      Helper.IhtJsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.IhtCreateSerializerSettings();

      // Convert to C# Class typed object
      Helper.RequestDataBase request = Helper.JsonHelper.ToClass<Helper.RequestDataBase>(payload, jsonSerializerSettings);

      if (jsonSerializerSettings.errorContext != null && jsonSerializerSettings.errorContext.Error != null)
      {
        return new Machine.ResultStatus(jsonSerializerSettings.errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
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
      //Newtonsoft.Json.Serialization.ErrorContext? errorContext = null;
      Helper.IhtJsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.IhtCreateSerializerSettings();

      List<CuttingDataModel> cuttingDataModelList = new List<CuttingDataModel>();
      cuttingDataModelList = await InstanceCuttingDataDBService().GetEntriesByGasTypeAsync(
        (int)InstanceIhtDevices().TorchTypeSetup, CancellationToken.None);
      int noOfDataRecords = cuttingDataModelList.Count;

      ResponseNoOfDataRecords responseNoOfDataRecords = new ResponseNoOfDataRecords(noOfDataRecords);
      var jsonString = Helper.JsonHelper.FromClass<ResponseNoOfDataRecords>(responseNoOfDataRecords, true, jsonSerializerSettings);

      if (jsonSerializerSettings.errorContext != null && jsonSerializerSettings.errorContext.Error != null)
      {
        return new Machine.ResultStatus(jsonSerializerSettings.errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
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
      //Newtonsoft.Json.Serialization.ErrorContext? errorContext = null;
      Helper.IhtJsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.IhtCreateSerializerSettings();

      // Convert to C# Class typed object
      RequestDataRecords requestDataRecords = Helper.JsonHelper.ToClass<RequestDataRecords>(payload, jsonSerializerSettings);

      Machine.ResultStatus?  resultStatus   = null;
      Common.ResponseStatus? responseStatus = null;
      var jsonString = string.Empty;

      if (jsonSerializerSettings.errorContext != null && jsonSerializerSettings.errorContext.Error != null)
      {
        resultStatus   = new Machine.ResultStatus(jsonSerializerSettings.errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
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
      List<Exec.DataBase.Data> datas = new List<Exec.DataBase.Data>();
      List<CuttingDataModel> cuttingDataModelList = new List<CuttingDataModel>();
      cuttingDataModelList = await InstanceCuttingDataDBService().GetEntriesByGasTypeAsync(
        (int)InstanceIhtDevices().TorchTypeSetup, CancellationToken.None);

      int dataRecordsCnt = 1;
      int dataRecordNos  = 0;
      foreach (CuttingDataModel cuttingDataModel in cuttingDataModelList)
      {
        if (dataRecordsCnt >= start && dataRecordsCnt <= end)
        {
          datas.Add(new Data(cuttingDataModel));
          ++dataRecordNos;
        }
        ++dataRecordsCnt;
      }

      // Antwort mit Datenssätze
      ResponseDataRecords responseDataRecords = new ResponseDataRecords
        (Machine.ResultStatus.NoError,
        dataRecordNos,
        datas);

      jsonSerializerSettings = Helper.JsonHelper.IhtCreateSerializerSettings();

      jsonString = Helper.JsonHelper.FromClass<ResponseDataRecords>(responseDataRecords, true, jsonSerializerSettings);

      if (jsonSerializerSettings.errorContext != null && jsonSerializerSettings.errorContext.Error != null)
      {
        return new Machine.ResultStatus(jsonSerializerSettings.errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
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
      //Newtonsoft.Json.Serialization.ErrorContext? errorContext = null;
      Helper.IhtJsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.IhtCreateSerializerSettings();

      // Convert to C# Class typed object
      RequestDataRecord requestDataRecord = Helper.JsonHelper.ToClass<RequestDataRecord>(payload, jsonSerializerSettings);

      Machine.ResultStatus?  resultStatus   = null;
      Common.ResponseStatus? responseStatus = null;
      var jsonString = string.Empty;

      if (jsonSerializerSettings.errorContext != null && jsonSerializerSettings.errorContext.Error != null)
      {
        resultStatus   = new Machine.ResultStatus(jsonSerializerSettings.errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
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

      CuttingDataModel cuttingDataModel = await InstanceCuttingDataDBService().GetEntryByGasIdAndIdAsync(
         requestDataRecord.DataRecordId.Value, (int)InstanceIhtDevices().TorchTypeSetup, CancellationToken.None);

      // Wenn Datensatz nicht vorhanden
      if (cuttingDataModel == null)
      {
        resultStatus = Machine.ResultStatus.DataRecordNotFound;
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
        cuttingDataModel);

      jsonSerializerSettings = Helper.JsonHelper.IhtCreateSerializerSettings();
      jsonString = Helper.JsonHelper.FromClass<ResponseDataRecord>(responseDataRecord, true, jsonSerializerSettings);

      if (jsonSerializerSettings.errorContext != null && jsonSerializerSettings.errorContext.Error != null)
      {
        return new Machine.ResultStatus(jsonSerializerSettings.errorContext.Error.Message, Machine.ResultStatus.JsonError.Value);
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
    public static IhtDevices.TorchType GetGasType()
    {
      return InstanceIhtDevices().TorchTypeSetup;
    }

  }
}
