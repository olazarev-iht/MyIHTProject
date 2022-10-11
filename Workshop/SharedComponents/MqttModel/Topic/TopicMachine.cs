using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.MqttModel.Topic
{
  /// <summary>
  /// Topics für die Kommuniaktion mit der CNC
  /// </summary>
  public class TopicMachine
  {
    public const           string Root               = "Machine";                      // 
    static public readonly string DataBaseSetRequest = $"{Root}/DataBaseSet/Request";  // Schneid-Datensatz anfordern 
    static public readonly string DataBaseSetReply   = $"{Root}/DataBaseSet/Reply";    // Rückmeldung der Schneid-Datensatz Anforderung
    
    static public readonly string TestCmdRequest     = $"{Root}/Test/CmdRequest";      // Test Befehlsanforderungen

    static public readonly string TestPublishError   = $"{Root}/Test/PublishError";     // Error publizieren
  }
}
