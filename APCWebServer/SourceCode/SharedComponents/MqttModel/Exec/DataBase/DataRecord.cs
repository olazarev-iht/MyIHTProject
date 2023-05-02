using SharedComponents.Machine;
using Newtonsoft.Json;
using CutDataRepository.Utils;
using SharedComponents.Models.CuttingData;
using static IhtCommunic.SlaveInfo;
using SharedComponents.MqttModel.Helper;

namespace SharedComponents.MqttModel.Exec.DataBase
{
  /// <summary>
  /// 
  /// </summary>
  public class Data
  {
    /// <summary>
    /// 
    /// </summary>
    //public Data()
    //{
    //}

    public Data(CuttingDataModel cuttingDataModel)
    {
      Material            = cuttingDataModel.Material.Name;
      Remark              = cuttingDataModel.Remark;
      Nozzle              = cuttingDataModel.Nozzle.Name;
      Thickness_mm        = cuttingDataModel.Thickness;
      CuttingSpeed_mm_min = cuttingDataModel.CuttingSpeed;
      Kerf_mm             = cuttingDataModel.Kerf;
      PreHeatHeight_mm    = cuttingDataModel.PreHeatHeight;
      PiercingHeight_mm   = cuttingDataModel.PierceHeight;
      CuttingHeight_mm    = cuttingDataModel.CutHeight;
      PreHeatTime_s       = cuttingDataModel.PreHeatTime;
      PierceTime_s        = cuttingDataModel.PierceTime;
      LeadInLength_mm     = cuttingDataModel.LeadInLength;
      GasType             = cuttingDataModel.Gas.Name;
      DataRecordId        = cuttingDataModel.Id;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cCutData"></param>
    public Data(CCutData cCutData, int? dataRecordId)
    {
      Material            = cCutData.MaterialName;
      Remark              = cCutData.Remark;
      Nozzle              = cCutData.NozzleName;
      Thickness_mm        = cCutData.Thickness;
      CuttingSpeed_mm_min = cCutData.CuttingSpeed;
      Kerf_mm             = cCutData.Kerf;
      PreHeatHeight_mm    = cCutData.PreHeatHeight;
      PiercingHeight_mm   = cCutData.PierceHeight;
      CuttingHeight_mm    = cCutData.CutHeight;
      PreHeatTime_s       = cCutData.PreHeatTime;
      PierceTime_s        = cCutData.PierceTime;
      LeadInLength_mm     = cCutData.LeadInLength;
      GasType             = cCutData.GasName;
      DataRecordId        = dataRecordId;
    }

    [JsonProperty("DataRecordId")]
    public int? DataRecordId { get; set; }

    [JsonProperty("Material")]
    public string? Material { get; set; }

    [JsonProperty("Remark")]
    public string? Remark { get; set; }

    [JsonProperty("Nozzle")]
    public string? Nozzle { get; set; }

    [JsonProperty("Thickness_mm")]
    public double Thickness_mm { get; set; }

    [JsonProperty("CuttingSpeed_mm_min")]
    public double CuttingSpeed_mm_min { get; set; }

    //[JsonProperty("Kerf_mm"), JsonConverter(typeof(JsonHelper.FloatFormatConverter), "{0:F3}")]
    [JsonProperty("Kerf_mm")]
    public double Kerf_mm { get; set; }

    [JsonProperty("PreHeatHeight_mm")]
    public double PreHeatHeight_mm { get; set; }

    [JsonProperty("PiercingHeight_mm")]
    public double PiercingHeight_mm { get; set; }

    [JsonProperty("CuttingHeight_mm")]
    public double CuttingHeight_mm { get; set; }

    [JsonProperty("PreHeatTime_s")]
    public double PreHeatTime_s { get; set; }

    [JsonProperty("PierceTime_s")]
    public double PierceTime_s { get; set; }

    [JsonProperty("LeadInLength_mm")]
    public double LeadInLength_mm { get; set; }

    [JsonProperty("GasType")]
    public string GasType { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class ResponseNoOfDataRecords
  {
    public ResponseNoOfDataRecords(int noOfDataRecords)
    {
      NoOfDataRecords = noOfDataRecords;
    }

    [JsonProperty("Response")]
    public string Response { get; set; } = Helper.RequestHelper.NoOfDataRecords;

    [JsonProperty("NoOfDataRecords")]
    public int NoOfDataRecords { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class RequestDataRecords
  {
    [JsonProperty("Request")]
    public string? Request { get; set; }

    [JsonProperty("DataRecordNos")]
    public IList<int> DataRecordNos { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class ResponseDataRecords
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""></param>
    /// <param name="dataRecordNos"></param>
    /// <param name="datas"></param>
    public ResponseDataRecords(Machine.ResultStatus resultStatus, int dataRecordNos, IList<Data> datas)
      : this(resultStatus.Value, resultStatus.Descprition, dataRecordNos, datas)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="status"></param>
    /// <param name="statusDescription"></param>
    /// <param name="dataRecordNos"></param>
    /// <param name="datas"></param>
    public ResponseDataRecords(int status, string statusDescription, int dataRecordNos, IList<Data> datas)
    {
      Status = status;
      StatusDescription = statusDescription ?? throw new ArgumentNullException(nameof(statusDescription));
      DataRecordNos = dataRecordNos;
      Datas = datas ?? throw new ArgumentNullException(nameof(datas));
    }

    [JsonProperty("Response")]
    public string Response { get; set; } = Helper.RequestHelper.DataRecords;

    [JsonProperty("Status")]
    public int Status { get; set; }

    [JsonProperty("StatusDescription")]
    public string StatusDescription { get; set; }

    [JsonProperty("DataRecordNos")]
    public int DataRecordNos { get; set; }

    [JsonProperty("Datas")]
    public IList<Data> Datas { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class RequestDataRecord
  {
    [JsonProperty("Request")]
    public string? Request { get; set; }

    [JsonProperty("DataRecordId")]
    public int? DataRecordId { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class ResponseDataRecord
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="status"></param>
    /// <param name="statusDescription"></param>
    /// <param name="response"></param>
    /// <param name="dataRecordId"></param>
    /// <param name="cCutData"></param>
    public ResponseDataRecord(string response, int status, string statusDescription, int? dataRecordId, CCutData cCutData)
    {
      Response = response;
      Status   = status;
      StatusDescription = statusDescription;
      Data = new Data(cCutData, dataRecordId.Value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="response"></param>
    /// <param name="resultStatus"></param>
    /// <param name="dataRecordId"></param>
    /// <param name="cCutData"></param>
    public ResponseDataRecord(string response, ResultStatus resultStatus, int? dataRecordId, CCutData cCutData)
      : this(response, resultStatus.Value, resultStatus.Descprition, dataRecordId, cCutData)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataRecord"></param>
    /// <param name="noError"></param>
    /// <param name="value"></param>
    /// <param name="cuttingDataModel"></param>
    public ResponseDataRecord(string response, ResultStatus resultStatus, CuttingDataModel cuttingDataModel)
    {
      Response = response;
      Status   = resultStatus.Value;
      StatusDescription = resultStatus.Descprition;
      Data = new Data(cuttingDataModel);
    }

    [JsonProperty("Response")]
    public string Response { get; set; }

    [JsonProperty("Status")]
    public int Status { get; set; }

    [JsonProperty("StatusDescription")]
    public string StatusDescription { get; set; }

    [JsonProperty("Data")]
    public Data Data { get; set; }
  }
}
