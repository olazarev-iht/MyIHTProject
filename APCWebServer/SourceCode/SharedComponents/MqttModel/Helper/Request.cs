using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.MqttModel.Helper
{
  /// <summary>
  /// 
  /// </summary>
  public class RequestSystem
  {
    [JsonProperty("Request")]
    public string RequestTag { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class CommandSystem
  {
    [JsonProperty("Command")]
    public string CommandTag { get; set; }
  }

  public class RequestStation
  {
    [JsonProperty("Station")]
    public int? Station { get; set; }

    [JsonProperty("Request")]
    public string RequestTag { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class CommandStation
  {
    [JsonProperty("Station")]
    public int? Station { get; set; }

    [JsonProperty("Command")]
    public string CommandTag { get; set; }
  }

  /// <summary>
  /// 
  /// </summary>
  public class RequestDataBase
  {
    [JsonProperty("DataBase")]
    public int Station { get; set; }

    [JsonProperty("Request")]
    public string RequestTag { get; set; }
  }
}
