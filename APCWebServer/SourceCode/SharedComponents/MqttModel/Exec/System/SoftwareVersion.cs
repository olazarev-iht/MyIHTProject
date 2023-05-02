using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.MqttModel.Exec.System
{
  /// <summary>
  /// 
  /// </summary>
  public class SoftwareVersion
  {
    [JsonProperty("Response")]
    public string Response { get; set; } = Helper.RequestHelper.SoftwareVersion;

    [JsonProperty("Major")]
    public int Major { get; set; }

    [JsonProperty("Minor")]
    public int Minor { get; set; }

    [JsonProperty("Revision")]
    public int Revision { get; set; }

    [JsonProperty("Build")]
    public int Build { get; set; }
  }

}
