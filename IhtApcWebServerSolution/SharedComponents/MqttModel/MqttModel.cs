using SharedComponents.Machine.Mqtt;
using MQTTnet;
using MQTTnet.Protocol;
using System.Diagnostics;
using System.Text;
using SharedComponents.IhtMsg;
using MQTTnet.Client;

namespace SharedComponents.MqttModel
{
  /// <summary>
  /// MqttModel stellt die Basisklasse für die Kapselung der Subscriber Funktionalität zur Verfügung.
  /// </summary>
  public abstract class MqttModel
  {
    /// <summary>
    /// Bereitstellung der Daten für die Ausführung eines Subscribers wenn eine Botschaft anliegt.
    /// Aktuell ist nur ein Delegate vorhanden der die Möglichkeit beitet, ein Methode asynchron auszuführen.
    /// </summary>
    public class Data
    {
      public readonly Func<string, Task<Machine.ResultStatus>> funcAsync;

      public Data(Func<string, Task<Machine.ResultStatus>> funcAsync)
      {
        this.funcAsync = funcAsync ?? throw new ArgumentNullException(nameof(funcAsync));
      }
    }

    /// <summary>
    /// Dictionary für die Sammlung der Subscriber Daten.
    /// Der Key (string) stellt den Topic dar, für den ein Subscribe erfolgt
    /// </summary>
    protected Dictionary<string, Data> _subscriberDatas = new Dictionary<string, Data>();
    private readonly StatusMsg _statusMsg;

    /// <summary>
    /// Der Mqtt Client
    /// </summary>
    public MqttClientWrapper MqttClient { get; protected set; } 

    public bool IsConnected => MqttClient.IsConnected;

    public delegate /*Task*/ void StatusMsg(IhtMsgLog.Info info, string msg);
    private StatusMsg statusMsg;

    /// <summary>
    /// 
    /// </summary>
    public StatusMsg SetStatusMsgHandler
    {
      get => statusMsg;
      set => statusMsg = value;
    }

    public bool IsRequestToDisconnect { get; private set; } = false;

    /// <summary>
    /// Konstruktor
    /// </summary>
    /// <param name="mqttClient"></param>
    public MqttModel(MqttClientWrapper mqttClient, StatusMsg statusMsg)
    {
      _statusMsg = statusMsg;
      MqttClient = mqttClient;
      // Delegates
      MqttClient.Implementation.ConnectedAsync                  += ConnectedAsync;
      MqttClient.Implementation.DisconnectedAsync               += DisconnectedAsync;
      MqttClient.Implementation.ApplicationMessageReceivedAsync += ApplicationMessageReceivedAsync;
    }

    /// <summary>
    /// Verbindung mit Server (Broker) herstellen
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task ConnectAsync(TimeSpan timeSpan, string username, string password, CancellationToken cancellationToken)
    {
      MqttClientConnectResult mqttClientConnectResult = await MqttClient.ConnectAsync(timeSpan, username, password, cancellationToken);
    }

    /// <summary>
    /// Verbindung mit Server (Broker) herstellen
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> ConnectAsync(TimeSpan timeSpan, CancellationToken cancellationToken)
    {
      if (!IsConnected)
      {
        return await MqttClient.ConnectAsync(timeSpan, cancellationToken);
      }
      return true;
    }

    /// <summary>
    /// Verbindung vom Server (Broker) trennen
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task DisconnectAsync(CancellationToken cancellationToken)
    {
      if (IsConnected)
      {
        IsRequestToDisconnect = true;
        await MqttClient.DisconnectAsync(cancellationToken);
      }
    }

    /// <summary>
    /// Alle im Dictionary für die Sammlung der Subscriber Daten eingetragenen
    /// Topic's (Key's) einen Subscribe vornehmen
    /// </summary>
    /// <param name="qOs"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task SubscribeAsync(MqttQualityOfServiceLevel qOs, CancellationToken cancellationToken)
    {
      if (IsConnected)
      {
        MqttClientSubscribeResult mqttClientSubscribeResult;
        foreach (var item in _subscriberDatas)
        {
          string topic = item.Key;
          mqttClientSubscribeResult = await MqttClient.SubscribeAsync(topic, qOs, cancellationToken);
        }
      }
    }

    /// <summary>
    /// Alle im Dictionary für die Sammlung der Subscriber Daten eingetragenen
    /// Topic's (Key's) einen Unsubscribe vornehmen
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task UnsubscribeAsync(CancellationToken cancellationToken)
    {
      if (IsConnected)
      {
        MqttClientUnsubscribeResult mqttClientUnsubscribeResult;
        foreach (var item in _subscriberDatas)
        {
          string topic = item.Key;
          mqttClientUnsubscribeResult = await MqttClient.UnsubscribeAsync(topic, cancellationToken);
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<string> GetSubscibedTopics()
    {
      List<string> topics = new List<string>();
      foreach (var item in _subscriberDatas)
      {
        string topic = item.Key;
        topics.Add(topic);
      }
      return topics;
    }

    /// <summary>
    /// Die in dem Dictionary hinterlegten Delegetate für den entsprechenden Topic ausführen
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="payload"></param>
    protected virtual async Task Execute(string topic, string payload)
    {
      foreach (var item in _subscriberDatas)
      {
        string itemTopic = item.Key;
        if (itemTopic == topic)
        {
          try
          {
            Data data = item.Value;
            await data.funcAsync(payload);
          }
          catch (Exception ex)
          {

          }
          return;
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="payload"></param>
    /// <param name="qOs"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task PublishAsync(string topic, string payload, MqttQualityOfServiceLevel qOs, CancellationToken cancellationToken)
    {
      if (IsConnected)
      {
        await MqttClient.PublishAsync(topic, payload, qOs, cancellationToken);
      }
    }

    /// <summary>
    /// Delegate für das Connect
    /// </summary>
    /// <param name="e"></param>
    private async Task ConnectedAsync(MqttClientConnectedEventArgs e)
    {
      MqttClientConnectResult mqttClientConnectResult = e.ConnectResult;
      bool isSuccess       = mqttClientConnectResult.ResultCode == MqttClientConnectResultCode.Success;
      bool isAtMostOnce    = mqttClientConnectResult.MaximumQoS == MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce;
      bool isAtLeastOnce   = mqttClientConnectResult.MaximumQoS == MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce;
      bool isAtExactlyOnce = mqttClientConnectResult.MaximumQoS == MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce;
      Console.WriteLine($"ConnectedAsync: ResultCode={mqttClientConnectResult.ResultCode} MaximumQoS={mqttClientConnectResult.MaximumQoS}");
      await Task.Delay(0);
    }

    /// <summary>
    /// Delegate für das Disonnect
    /// </summary>
    /// <param name="e"></param>
    private async Task DisconnectedAsync(MqttClientDisconnectedEventArgs e)
    {
      bool isRequestToDisconnect = IsRequestToDisconnect;
      IsRequestToDisconnect = false;

      MqttClientDisconnectReason   mqttClientDisconnectReason  = e.Reason;
      bool clientWasConnected = e.ClientWasConnected;
      Console.WriteLine($"DisconnectedAsync: Reason={e.Reason}");
      if (clientWasConnected && !isRequestToDisconnect)
      {
        string msg = $"Disconnected from server! Reason={e.Reason.ToString()}";
        if (e.Exception != null)
        {
          msg = e.Exception.Message;
        }
        Console.WriteLine(msg);
      }
      await Task.Delay(0);
    }

    /// <summary>
    /// Delegate für den Empfang eines Publisher
    /// </summary>
    /// <param name="e"></param>
    private async Task ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs e)
    {
      bool isSuccess        = e.ReasonCode == MqttApplicationMessageReceivedReasonCode.Success;
      if (Debugger.IsAttached)
      {
      bool processingFailed = e.ProcessingFailed;
      bool isHandled        = e.IsHandled;
      bool autoAcknwledge   = e.AutoAcknowledge; 
      string clientID       = e.ClientId;
      }

      MqttApplicationMessage mqttApplicationMessage = e.ApplicationMessage;
      bool isRetain  = mqttApplicationMessage.Retain;
      string topic   = mqttApplicationMessage.Topic;
      string payload = Encoding.UTF8.GetString(mqttApplicationMessage.Payload).TrimEnd('\0');
      //byte[] bytePayload = Encoding.UTF8.GetBytes(payload) ?? (byte[])Array.CreateInstance(typeof(byte), 0); //Array.Empty<byte>(); // might be null for string.empty

      Console.WriteLine($"ApplicationMessageReceivedAsync: ReasonCode={e.ReasonCode} ProcessingFailed={e.ProcessingFailed}");
      Console.WriteLine($"                               : ClientId={e.ClientId} Topic={mqttApplicationMessage.Topic}");
      Console.WriteLine($"                               : Payload={payload}");

      if (isSuccess)
      {
        // Die in dem Dictionary hinterlegten Delegetate für den entsprechenden Topic ausführen
        await Execute(topic, payload);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="info"></param>
    /// <param name="msg"></param>
    public void SetStatusMessage(IhtMsgLog.Info info, string msg)
    {
      _statusMsg?.Invoke(info, $"MQTT: {msg}");
    }
  }
}
