using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.MqttModel.Exec.Common
{
  /// <summary>
  /// 
  /// </summary>
  public class ErrorNotification
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="errorCode"></param>
    /// <param name="errorDescription"></param>
    /// <param name="timeStamp"></param>
    public ErrorNotification(string notification, int errorCode, string errorDescription)
    {
      Notification     = notification ?? throw new ArgumentNullException(nameof(notification));
      ErrorCode        = errorCode;
      ErrorDescription = errorDescription ?? throw new ArgumentNullException(nameof(errorDescription));
      TimeStamp        = Machine.Helper.TimeStamp;
    }

    [JsonProperty("Notification")]
    public string Notification { get; set; }

    [JsonProperty("ErrorCode")]
    public int ErrorCode { get; set; }

    [JsonProperty("ErrorDescription")]
    public string ErrorDescription { get; set; }

    [JsonProperty("TimeStamp")]
    public string TimeStamp { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class StationErrorNotification : ErrorNotification
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="station"></param>
    /// <param name="notification"></param>
    /// <param name="errorCode"></param>
    /// <param name="errorDescription"></param>
    /// <param name="timeStamp"></param>
    public StationErrorNotification(int station, int errorCode, string errorDescription)
      : base(Helper.NotificationHelper.Error, errorCode, errorDescription)
    {
      Station = station;
    }

    [JsonProperty("Station")]
    public int Station { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class DataRecordNotification
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="dataRecordId"></param>
    public DataRecordNotification(string notification, int dataRecordId)
    {
      Notification = notification;
      DataRecordId = dataRecordId;
      TimeStamp    = Machine.Helper.TimeStamp;
    }

    [JsonProperty("Notification")]
    public string Notification { get; set; }

    [JsonProperty("DataRecordId")]
    public int DataRecordId { get; set; }

    [JsonProperty("TimeStamp")]
    public string TimeStamp { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class DataRecordUpdatedNotification : DataRecordNotification
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataRecordId"></param>
    public DataRecordUpdatedNotification(int dataRecordId)
      : base(Helper.NotificationHelper.DataRecordUpdated, dataRecordId)
    {
    }
  }

  /// <summary>
  /// 
  /// </summary>
  public class DataRecordCreatedNotification : DataRecordNotification
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataRecordId"></param>
    public DataRecordCreatedNotification(int dataRecordId)
      : base(Helper.NotificationHelper.DataRecordCreated, dataRecordId)
    {
    }
  }

  /// <summary>
  /// 
  /// </summary>
  public class DataRecordDeletedNotification : DataRecordNotification
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataRecordId"></param>
    public DataRecordDeletedNotification(int dataRecordId)
      : base(Helper.NotificationHelper.DataRecordDeleted, dataRecordId)
    {
    }
  }

  /// <summary>
  /// 
  /// </summary>
  public class DataRecordUserLoadedNotification : DataRecordNotification
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataRecordId"></param>
    public DataRecordUserLoadedNotification(int dataRecordId)
      : base(Helper.NotificationHelper.DataRecordUserLoaded, dataRecordId)
    {
    }
  }

}
