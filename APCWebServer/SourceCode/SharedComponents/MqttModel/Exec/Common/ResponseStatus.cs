using SharedComponents.Machine;
using Newtonsoft.Json;

namespace SharedComponents.MqttModel.Exec.Common
{
  /// <summary>
  /// 
  /// </summary>
  class ResponseStatus
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="response"></param>
    /// <param name="resultStatus"></param>
    public ResponseStatus(string response, ResultStatus resultStatus)
    {
      Response = response;
      Status   = resultStatus.Value;
      StatusDescription = resultStatus.Descprition;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="response"></param>
    /// <param name="status"></param>
    /// <param name="statusDescription"></param>
    public ResponseStatus(string response, int status, string statusDescription)
    {
      Response = response;
      Status   = status;
      StatusDescription = statusDescription;
    }

    [JsonProperty("Response")]
    public string Response { get; set; }

    [JsonProperty("Status")]
    public int Status { get; set; }

    [JsonProperty("StatusDescription")]
    public string StatusDescription { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  class ResponseStatusStation : ResponseStatus
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="response"></param>
    /// <param name="resultStatus"></param>
    public ResponseStatusStation(int? station, string response, ResultStatus resultStatus)
      : this(station, response, resultStatus.Value, resultStatus.Descprition)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="station"></param>
    /// <param name="response"></param>
    /// <param name="status"></param>
    /// <param name="statusDescription"></param>
    public ResponseStatusStation(int? station, string response, int status, string statusDescription)
     : base(response, status, statusDescription)
    {
      Station = station;
    }

    [JsonProperty("Station")]
    public int? Station { get; set; }
  }

}
