using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.MqttModel
{
  /// <summary>
  /// 
  /// </summary>
  public class MqttResult
  {
    /// <summary>
    /// 
    /// </summary>
    public MqttResult()
    {
      Result = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="result"></param>
    public MqttResult(bool result)
    {
      Result  = result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="result"></param>
    /// <param name="message"></param>
    public MqttResult(bool result, string message)
    {
      Result = result;
      Message = message;
    }

    public bool Result     { get; set; }
    public string Message  { get; set; } = string.Empty;
  }
}
