using Newtonsoft.Json;

namespace SharedComponents.MqttModel.Exec.Station
{
  /// <summary>
  /// 
  /// </summary>
  public class Version
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="response"></param>
    public Version(int? station, string response)
    {
      Response = response;
      Station  = station;
    }

    [JsonProperty("Station")]
    public int? Station { get; set; }

    [JsonProperty("Response")]
    public string Response { get; set; }

    [JsonProperty("Major")]
    public int Major { get; set; }

    [JsonProperty("Minor")]
    public int Minor { get; set; }

    [JsonProperty("Revision")]
    public int Revision { get; set; }
  }
}
