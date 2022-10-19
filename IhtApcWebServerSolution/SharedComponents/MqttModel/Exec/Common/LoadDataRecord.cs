using CutDataRepository.Utils;
using Newtonsoft.Json;
using SharedComponents.Machine;
using SharedComponents.Models.CuttingData;

namespace SharedComponents.MqttModel.Exec.Common
{
  /// <summary>
  /// 
  /// </summary>
  public class SystemRequestLoadDataRecord
  {
    [JsonProperty("Request")]
    public string Request { get; set; } = Helper.RequestHelper.LoadDataRecord;

    [JsonProperty("DataRecordId")]
    public int? DataRecordId { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class StationRequestLoadDataRecord: SystemRequestLoadDataRecord
  {
    [JsonProperty("Station")]
    public int? Station { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class StationResponseLoadDataRecord : DataBase.ResponseDataRecord
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="station"></param>
    /// <param name="status"></param>
    /// <param name="statusDescription"></param>
    /// <param name="dataRecordId"></param>
    /// <param name="cCutData"></param>
    public StationResponseLoadDataRecord(int? station, int status, string statusDescription, int? dataRecordId, CCutData cCutData)
     : base(Helper.RequestHelper.LoadDataRecord, status, statusDescription, dataRecordId, cCutData)
    {
      Station = station;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="station"></param>
    /// <param name="status"></param>
    /// <param name="dataRecordId"></param>
    /// <param name="cCutData"></param>
    public StationResponseLoadDataRecord(int? station, Machine.ResultStatus status, int? dataRecordId, CCutData cCutData)
     : base(Helper.RequestHelper.LoadDataRecord, status.Value, status.Descprition, dataRecordId, cCutData)
    {
      Station = station;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="station"></param>
    /// <param name="status"></param>
    /// <param name="cuttingDataModel"></param>
    public StationResponseLoadDataRecord(int station, ResultStatus status, CuttingDataModel? cuttingDataModel)
     : base(Helper.RequestHelper.LoadDataRecord, status, cuttingDataModel)
    {
      Station = station;
    }

    [JsonProperty("Station")]
    public int? Station { get; set; }
  }

}
