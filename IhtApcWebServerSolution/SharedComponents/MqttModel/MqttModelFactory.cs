using SharedComponents.Machine.Mqtt;
using SharedComponents.MqttModel.Actions;
using SharedComponents.MqttModel.Topic;
using MQTTnet.Protocol;
using Microsoft.Extensions.DependencyInjection;
using SharedComponents.IhtModbus;
using SharedComponents.IhtMsg;

namespace SharedComponents.MqttModel
{

  /// <summary>
  /// Erzeugung der Models
  /// </summary>
  public partial class MqttModelFactory
  {
    /// <summary>
    /// Aktuelle Models
    /// </summary>
    public enum Model
    {
      Machine,
      Apc
    }

    /// <summary>
    /// 
    /// </summary>
    public enum PublishId
    {
      //TestErrorNo,
      StationErrorNotification,
      DataRecordUpdatedNotification,
      DataRecordCreatedNotification,
      DataRecordDeletedNotification,
      DataRecordUserLoadedNotification,
    }

    #region PublishData
    /// <summary>
    /// 
    /// </summary>
    class PublishData
    {
      public PublishData(Model model, string topic, Func<string, string>? action)
      {
        Model  = model;
        Topic  = topic;
        Action = action;
      }

      public Model                Model  {get; private set;}
      public string               Topic  {get; private set;}
      public Func<string, string> Action {get; private set;}
    }
    #endregion //PublishData

    public string Server      { get; private set; } = "localhost";
    public int    ServerPort  { get; private set; } = 1883;

    
    #region Singleton
    public  static bool IsInstanced { get; private set; } = false;
    
    private static MqttModel.StatusMsg _statusMsg = SetStatusMsg;

    private static void SetStatusMsg(IhtMsgLog.Info info, string msg)
    {
    }

    /// <summary>
    /// Singleton
    /// </summary>
    /// <param name="tcpServer"></param>
    /// <param name="tcpServerPort"></param>
    /// <returns></returns>
    public static MqttModelFactory Instance(/*MqttModel.StatusMsg statusMsg,*/ string tcpServer = "localhost" , int tcpServerPort = 1883)
    { 
      IsInstanced = true;
      //_statusMsg  = statusMsg;

      var instance =  lazy.Value;
      instance.Server     = tcpServer;
      instance.ServerPort = tcpServerPort;
      
      return instance;
    }
    public static MqttModelFactory Instance()
    { 
      return lazy.Value;
    }
    private static IServiceProvider _provider;
    /// <summary>
    /// Konstruktor
    /// </summary>
    public MqttModelFactory(IServiceProvider provider)
    {
      _provider = provider ?? throw new ArgumentNullException($"{nameof(provider)}");

      _mqttManager = new MqttManager();

      _models = new Dictionary<Model, MqttModel>
      {
        //{ Model.Machine, new MqttModelMachine(CreateClient(), _statusMsg) },
        { Model.Apc    , new MqttModelApc    (CreateClient(), _statusMsg) },
        // Hier nachfolgende Models eintragen
      };
    }

    /*
    public static MqttModelFactory Instance
    { 
        get { return lazy.Value; } 
    }
    */
    //private static readonly Lazy<MqttModelFactory> lazy = new Lazy<MqttModelFactory>(() => new MqttModelFactory());
    private static readonly Lazy<MqttModelFactory> lazy = new Lazy<MqttModelFactory>(() => _provider?.GetService<MqttModelFactory>());
    
    #endregion // Singleton

    private readonly MqttManager _mqttManager;

    private readonly Dictionary<Model, MqttModel> _models;
    private Dictionary<PublishId, PublishData> _publisherTopics = new Dictionary<PublishId, PublishData>();

    public bool IsClientsError => _mqttManager.IsClientsError;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsClientsConnected()
    {
      foreach (var item in _models)
      {
        MqttModel mqttModel = item.Value;
        if (!mqttModel.IsConnected)
        {
          return false;
        }
      }
      return true;
    }

    public void ClearClientsError() => _mqttManager.ClearClientsError();

    /// <summary>
    /// Konstruktor privat
    /// </summary>
    private MqttModelFactory()
    {
      _mqttManager = new MqttManager();
      
      _models = new Dictionary<Model, MqttModel>
      {
        //{ Model.Machine, new MqttModelMachine(CreateClient(), _statusMsg) },
        { Model.Apc    , new MqttModelApc    (CreateClient(), _statusMsg) },
        // Hier nachfolgende Models eintragen
      };    
    }

    /// <summary>
    /// MQTT Clinet erzeugen
    /// </summary>
    /// <returns></returns>
    private MqttClientWrapper CreateClient()
    {
      return _mqttManager.CreateClient(Server, ServerPort);
    }

    /// <summary>
    /// Model abfragen
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public MqttModel GetModel(Model model)
    {
      MqttModel mqttModel;
      if (_models.TryGetValue(model, out mqttModel))
      {
        return mqttModel;
      }
      return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public List<string> GetSubscibedTopics(Model model)
    {
      MqttModel mqttModel;
      if (_models.TryGetValue(model, out mqttModel))
      {
        return mqttModel.GetSubscibedTopics();
      }
      return new List<string>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<string> GetSubscibedTopicsAll()
    {
      List<string> topicsAll = new List<string>();
      foreach (var item in _models)
      {
        MqttModel mqttModel = item.Value;
        List<string> topicsModel = mqttModel.GetSubscibedTopics();
        if (topicsModel.Count > 0)
        {
          topicsAll.AddRange(topicsModel);
        }
      }
      return topicsAll;
    }

    /// <summary>
    /// Für alle Clients eine Verbindung mit Server (Broker) herstellen
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task ConnectClientsAsync(TimeSpan timeSpan, CancellationToken cancellationToken)
    {
      foreach (var item in _models)
      {
        MqttModel mqttModel = item.Value;
        await mqttModel.ConnectAsync(timeSpan, cancellationToken);
      }
    }

    /// <summary>
    /// Für alle Models eine Verbindung mit Server (Broker) herstellen
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task ConnectClientsAsync(TimeSpan timeSpan, string username, string password, CancellationToken cancellationToken)
    {
      foreach (var item in _models)
      {
        MqttModel mqttModel = item.Value;
        await mqttModel.ConnectAsync(timeSpan, username, password, cancellationToken);
      }
    }
    
    /// <summary>
    /// Für alle Models die Verbindung vom Server (Broker) trennen
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task DisconnectClientsAsync(CancellationToken cancellationToken)
    {
      foreach (var item in _models)
      {
        MqttModel mqttModel = item.Value;
        await mqttModel.DisconnectAsync(cancellationToken);
      }
    }

    /// <summary>
    /// Für alle Topics der Models einen Subscribe vornehmen
    /// </summary>
    /// <param name="qOs"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task SubscribeClientsAsync(MqttQualityOfServiceLevel qOs, CancellationToken cancellationToken)
    {
      foreach (var item in _models)
      {
        MqttModel mqttModel = item.Value;
        await mqttModel.SubscribeAsync(qOs, cancellationToken);
      }
    }

    /// <summary>
    /// Für alle Topics der Models einen Unsubscribe vornehmen
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task UnsubscribeClientsAsync(CancellationToken cancellationToken)
    {
      foreach (var item in _models)
      {
        MqttModel mqttModel = item.Value;
        await mqttModel.UnsubscribeAsync(cancellationToken);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="model"></param>
    /// <param name="publishId"></param>
    /// <param name="topic"></param>
    public void RegisterPublisherTopic(Model model, PublishId publishId, string topic, Func<string, string>? action = null)
    {
      // Modell holen
      MqttModel mqttModel = GetModel(model);
      if (mqttModel == null)
      {
        throw new ArgumentNullException(nameof(mqttModel));
      }

      // Registrier-Daten für entsprechendes Model
      PublishData? publishData = null;
      // Wenn Registrier-Daten noch nicht vorhanden, dann erzeugen
      if (!_publisherTopics.TryGetValue(publishId, out publishData))
      {
        // Registrier-Daten für entsprechendes Model jetzt erstellen und übernehmen
        publishData = new PublishData(model, topic, action);
        _publisherTopics.Add(publishId, publishData);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public void RegisterPublishers()
    {
      //RegisterPublisherTopic(Model.Machine, PublishId.TestErrorNo, TopicMachine.TestPublishError, ActionPublisher.TestErrorNo);
      RegisterPublisherTopic(Model.Apc, PublishId.StationErrorNotification        , TopicApc.StationNotification , ActionPublisher.StationErrorNotification        );
      RegisterPublisherTopic(Model.Apc, PublishId.DataRecordUpdatedNotification   , TopicApc.DataBaseNotification, ActionPublisher.DataRecordUpdatedNotification   );
      RegisterPublisherTopic(Model.Apc, PublishId.DataRecordCreatedNotification   , TopicApc.DataBaseNotification, ActionPublisher.DataRecordCreatedNotification   );
      RegisterPublisherTopic(Model.Apc, PublishId.DataRecordDeletedNotification   , TopicApc.DataBaseNotification, ActionPublisher.DataRecordDeletedNotification   );
      RegisterPublisherTopic(Model.Apc, PublishId.DataRecordUserLoadedNotification, TopicApc.DataBaseNotification, ActionPublisher.DataRecordUserLoadedNotification);
      // Hier nachfolgende Einträge vornehmen
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="publishId"></param>
    /// <param name="payload"></param>
    /// <param name="qOs"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task Publish(PublishId publishId, string payload, MqttQualityOfServiceLevel qOs, CancellationToken cancellationToken)
    {
      PublishData publishData;
      if (_publisherTopics.TryGetValue(publishId, out publishData))
      {
        MqttModel mqttModel = GetModel(publishData.Model);
        if (mqttModel != null)
        {
          if (publishData.Action != null)
          {
            payload = publishData.Action(payload);
          }
          await mqttModel.PublishAsync(publishData.Topic, payload, qOs, cancellationToken);
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="publishId"></param>
    /// <param name="payload"></param>
    /// <param name="qOs"></param>
    /// <returns></returns>
    public async Task Publish(PublishId publishId, string payload, MqttQualityOfServiceLevel qOs = MqttQualityOfServiceLevel.AtMostOnce)
    {
      await Publish(publishId, payload, qOs, CancellationToken.None);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
      _mqttManager.Dispose();
    }

  }
}
