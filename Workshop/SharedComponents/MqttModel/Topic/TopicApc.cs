using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.MqttModel.Topic
{
  class TopicApc
  {
    static public readonly string Root                 = $"{TopicCommon.Root}/Apc";

    static public readonly string SystemRequest        = $"{Root}/System/Request";        // System-Daten anfordern 
    static public readonly string SystemResponse       = $"{Root}/System/Response";       // Rückmeldung der System-Daten Anforderung
    static public readonly string SystemNotification   = $"{Root}/System/Notification";   // System-Benachrichtigungen publizieren
    static public readonly string SystemCommand        = $"{Root}/System/Command";        // Befehlsanforderungen an das System
                                                       
    static public readonly string StationRequest       = $"{Root}/Station/Request";       // Stations-Daten anfordern 
    static public readonly string StationResponse      = $"{Root}/Station/Response";      // Rückmeldung der Stations-Daten Anforderung
    static public readonly string StationNotification  = $"{Root}/Station/Notification";  // Stations-Benachrichtigungen publizieren
    static public readonly string StationCommand       = $"{Root}/Station/Command";       // Befehlsanforderungen an die Station
                                                       
    static public readonly string DataBaseRequest      = $"{Root}/DataBase/Request";      // Datenbank-Daten anfordern 
    static public readonly string DataBaseResponse     = $"{Root}/DataBase/Response";     // Rückmeldung der Datenbank-Daten Anforderung
    static public readonly string DataBaseNotification = $"{Root}/DataBase/Notification"; // Datenbank-Benachrichtigungen publizieren
  }
}
