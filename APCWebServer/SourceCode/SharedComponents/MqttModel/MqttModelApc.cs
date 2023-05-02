using CutDataRepository.Utils;
using SharedComponents.Machine.Mqtt;
using SharedComponents.MqttModel.Topic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace SharedComponents.MqttModel
{
  internal class MqttModelApc : MqttModel
  {
    /// <summary>
    /// Konstruktor, wird in der Regel von MqttModelFactory aufgerufen
    /// </summary>
    /// <param name="mqttClient"></param>
    public MqttModelApc(MqttClientWrapper mqttClient, StatusMsg statusMsg)
      : base(mqttClient, statusMsg)
    {
      _subscriberDatas = new Dictionary<string, Data>
      {
        
        { TopicApc.SystemRequest       , new Data(ExecSystemRequestAsync       ) },  // System-Daten anfordern 
        //{ TopicApc.SystemResponse      , new Data(ExecSystemResponseAsync      ) },  // Rückmeldung der System-Daten Anforderung
        //{ TopicApc.SystemNotification  , new Data(ExecSystemNotificationAsync  ) },  // System-Benachrichtigungen publizieren
        { TopicApc.SystemCommand       , new Data(ExecSystemCommandAsync       ) },  // Befehlsanforderungen an das System
                                                                               
        { TopicApc.StationRequest      , new Data(ExecStationRequestAsync      ) },  // Stations-Daten anfordern 
        //{ TopicApc.StationResponse     , new Data(ExecStationResponseAsync     ) },  // Rückmeldung der Stations-Daten Anforderung
        //{ TopicApc.StationNotification , new Data(ExecStationNotificationAsync ) },  // Stations-Benachrichtigungen publizieren
        { TopicApc.StationCommand      , new Data(ExecStationCommandAsync      ) },  // Befehlsanforderungen an die Station

        { TopicApc.DataBaseRequest     , new Data(ExecDataBaseRequestAsync     ) },  // Datenbank-Daten anfordern 
        //{ TopicApc.DataBaseResponse    , new Data(ExecDataBaseResponseAsync    ) },  // Rückmeldung der Datenbank-Daten Anforderung
        //{ TopicApc.DataBaseNotification, new Data(ExecDataBaseNotificationAsync) },  // Datenbank-Benachrichtigungen publizieren
        // Nachfolgende Subscribes eintragen
      };

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private async Task<Machine.ResultStatus> ExecSystemRequestAsync(string payload)
    {
      return await Exec.System.ExecSystemRequest.RequestAsync(MqttClient, payload);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private async Task<Machine.ResultStatus> ExecSystemCommandAsync(string payload)
    {
      return await Exec.System.ExecSystemCommand.CommandAsync(MqttClient, payload);
    }

#if false
    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private async Task<Machine.ResultStatus> ExecSystemResponseAsync(string payload)
    {
      throw new NotImplementedException();
    }
#endif

#if false
    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private async Task<Machine.ResultStatus> ExecSystemNotificationAsync(string payload)
    {
      throw new NotImplementedException();
    }
#endif


    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private async Task<Machine.ResultStatus> ExecStationRequestAsync(string payload)
    {
      return await Exec.Station.ExecStationRequest.RequestAsync(MqttClient, payload);
    }

#if false
    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private Task<Machine.ResultStatus> ExecStationResponseAsync(string payload)
    {
      throw new NotImplementedException();
    }
#endif

#if false
    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private async Task<Machine.ResultStatus> ExecStationNotificationAsync(string payload)
    {
      throw new NotImplementedException();
    }
#endif

    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private async Task<Machine.ResultStatus> ExecStationCommandAsync(string payload)
    {
      return await Exec.Station.ExecStationCommand.CommandAsync(MqttClient, payload);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private async Task<Machine.ResultStatus> ExecDataBaseRequestAsync(string payload)
    {
      return await Exec.DataBase.ExecDataBaseRequest.RequestAsync(MqttClient, payload);
    }

#if false
    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private async Task<Machine.ResultStatus> ExecDataBaseResponseAsync(string payload)
    {
      throw new NotImplementedException();
    }
#endif

#if false
    /// <summary>
    /// 
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private async Task<Machine.ResultStatus> ExecDataBaseNotificationAsync(string payload)
    {
      throw new NotImplementedException();
    }
#endif
  }
}
