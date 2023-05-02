using Newtonsoft.Json;
using SharedComponents.MqttModel.Helper;
using System.Diagnostics;

namespace SharedComponents.MqttModel.Actions
{
  /// <summary>
  /// 
  /// </summary>
  class JsonTestErrorNo
  {
    public JsonTestErrorNo(string[] datas)
      : this(datas[0], datas[1], datas[2])
    {
    }

    public JsonTestErrorNo(string station, string errorCode, string errorDescription)
    {
      Station          = station;
      ErrorCode        = errorCode;
      ErrorDescription = errorDescription;
      TimeStamp        = Machine.Helper.TimeStamp;
    }

    public string Station          {get; private set;}
    public string ErrorCode        {get; private set;}
    public string ErrorDescription {get; private set;}
    public string TimeStamp { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class ActionPublisher
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string TestErrorNo(string data)
    {
      //string payload = $"{_this.SlaveId},{_ErrorCode},{_this.GetDescritpion(_ErrorCode)}";
      string[] datas = data.Split(',');
      Debug.Assert(datas.Length >= 3);
      if (datas.Length >= 3)
      {
        JsonTestErrorNo jsonTestErrorNo = new JsonTestErrorNo(datas);
        string jsonString = JsonConvert.SerializeObject(jsonTestErrorNo, Formatting.Indented);
        return jsonString;
      }
      return data;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string StationErrorNotification(string data)
    {
      string[] datas = data.Split(',');
      Debug.Assert(datas.Length >= 3);
      if (datas.Length >= 3)
      {
        int    station          = 0;
        int    errorCode        = 0;
        string errorDescription = datas[2];
        
        // Station
        int.TryParse(datas[0], out station);
        // ErroCode
        int.TryParse(datas[1], out errorCode);

        // Replace "None" with "No Error"
        if (errorDescription.Equals("None"))
        {
          errorDescription = Machine.ResultStatus.NoError.Descprition;
        }
        
        //Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
        Helper.IhtJsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.IhtCreateSerializerSettings();
        Exec.Common.StationErrorNotification errorNotification      = new Exec.Common.StationErrorNotification(station, errorCode, errorDescription);
        // Convert C# Class typed object to JSON string
        string jsonString = JsonHelper.FromClass<Exec.Common.ErrorNotification>(errorNotification, true, jsonSerializerSettings);

        if (jsonSerializerSettings.errorContext != null && jsonSerializerSettings.errorContext.Error != null)
        {
          return jsonSerializerSettings.errorContext.Error.Message;
        }
        else if (string.IsNullOrEmpty(jsonString))
        {
          return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing.Descprition;
        }

        return jsonString;
      }

      return data;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string DataRecordNotification(Newtonsoft.Json.Serialization.ErrorContext errorContext, string jsonString)
    {
      if (errorContext != null && errorContext.Error != null)
      {
        return errorContext.Error.Message;
      }
      else if (string.IsNullOrEmpty(jsonString))
      {
        return Machine.ResultStatus.JsonStringIsNullOrEmptyOrMissing.Descprition;
      }

      return jsonString;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string DataRecordUpdatedNotification(string data)
    {
      int dataRecordId = 0;
      // Station
      int.TryParse(data, out dataRecordId);

      //Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      Helper.IhtJsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.IhtCreateSerializerSettings();
      Exec.Common.DataRecordUpdatedNotification notification = new Exec.Common.DataRecordUpdatedNotification(dataRecordId);
      // Convert C# Class typed object to JSON string
      string jsonString = JsonHelper.FromClass<Exec.Common.DataRecordUpdatedNotification>(notification, true, jsonSerializerSettings);

      return DataRecordNotification(jsonSerializerSettings.errorContext, jsonString);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string DataRecordCreatedNotification(string data)
    {
      int dataRecordId = 0;
      // Station
      int.TryParse(data, out dataRecordId);

      //Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      Helper.IhtJsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.IhtCreateSerializerSettings();
      Exec.Common.DataRecordCreatedNotification notification = new Exec.Common.DataRecordCreatedNotification(dataRecordId);
      // Convert C# Class typed object to JSON string
      string jsonString = JsonHelper.FromClass<Exec.Common.DataRecordCreatedNotification>(notification, true, jsonSerializerSettings);

      return DataRecordNotification(jsonSerializerSettings.errorContext, jsonString);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string DataRecordDeletedNotification(string data)
    {
      int dataRecordId = 0;
      // Station
      int.TryParse(data, out dataRecordId);

      //Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      Helper.IhtJsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.IhtCreateSerializerSettings();
      Exec.Common.DataRecordDeletedNotification notification = new Exec.Common.DataRecordDeletedNotification(dataRecordId);
      // Convert C# Class typed object to JSON string
      string jsonString = JsonHelper.FromClass<Exec.Common.DataRecordDeletedNotification>(notification, true, jsonSerializerSettings);

      return DataRecordNotification(jsonSerializerSettings.errorContext, jsonString);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string DataRecordUserLoadedNotification(string data)
    {
      int dataRecordId = 0;
      // Station
      int.TryParse(data, out dataRecordId);

      //Newtonsoft.Json.Serialization.ErrorContext errorContext = null;
      Helper.IhtJsonSerializerSettings jsonSerializerSettings = Helper.JsonHelper.IhtCreateSerializerSettings();
      Exec.Common.DataRecordUserLoadedNotification notification = new Exec.Common.DataRecordUserLoadedNotification(dataRecordId);
      // Convert C# Class typed object to JSON string
      string jsonString = JsonHelper.FromClass<Exec.Common.DataRecordUserLoadedNotification>(notification, true, jsonSerializerSettings);

      return DataRecordNotification(jsonSerializerSettings.errorContext, jsonString);
    }
    
  }
}
