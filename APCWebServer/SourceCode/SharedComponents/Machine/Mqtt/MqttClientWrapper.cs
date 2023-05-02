using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Diagnostics;
using MQTTnet.Packets;
using MQTTnet.Protocol;

namespace SharedComponents.Machine.Mqtt
{
  #region topic: single- and multi-level
  // https://www.hivemq.com/blog/mqtt-essentials-part-5-mqtt-topics-best-practices/
  /*
   * Single Level: +
   * As the name suggests, a single-level wildcard replaces one topic level. 
   * The plus symbol represents a single-level wildcard in a topic.
   * 
   *           single level wildcard
   *                    |
   * myhome/groundfloor/+/temperature
   * 
   * Any topic matches a topic with single-level wildcard if it contains an arbitrary string instead of the wildcard.
   * For example a subscription to myhome/groundfloor/+/temperature can produce the following results:
   * ok : myhome/groundfloor/livingroom/temperature
   * ok : myhome/groundfloor/kitchen/temperature
   * nok: myhome/firsfloor/kitchen/temperature
   * nok: myhome/groundfloor/kitchen/fridge/temperature
   */

  /* 
   * Multi Level: #
   * The multi-level wildcard covers many topic levels. 
   * The hash symbol represents the multi-level wild card in the topic.
   * For the broker to determine which topics match, the multi-level wildcard must
   * be placed as the last character in the topic and preceded by a forward slash.
   * 
   *           multi level wildcard
   *                    |
   * myhome/groundfloor/#
   * 
   * ok : myhome/groundfloor/livingroom/temperature
   * ok : myhome/groundfloor/kitchen/temperature
   * ok : myhome/groundfloor/kitchen/brightness
   * nok: myhome/firstfloor/kitchen/temperature
   * 
   * When a client subscribes to a topic with a multi-level wildcard, it receives all messages
   * of a topic that begins with the pattern before the wildcard character, no matter how long
   * or deep the topic is. If you specify only the multi-level wildcard as a topic (#), 
   * you receive all messages that are sent to the MQTT broker. If you expect high throughput,
   * subscription with a multi-level wildcard alone is an anti-pattern (see the best practices below).
   * 
   * Best practices
   * Never use a leading forward slash
   * A leading forward slash is permitted in MQTT. For example, /myhome/groundfloor/livingroom.
   * However, the leading forward slash introduces an unnecessary topic level with a zero character at the front.
   * The zero does not provide any benefit and often leads to confusion.
   *
   * Never use spaces in a topic
   * A space is the natural enemy of every programmer. When things are not going the way they should,
   * spaces make it much harder to read and debug topics. As with leading forward slashes,
   * just because something is allowed, doesn’t mean it should be used. UTF-8 has many different white space types,
   * such uncommon characters should be avoided.
   * 
   * Keep the topic short and concise
   * Each topic is included in every message in which it is used. Make your topics as short and concise as possible.
   * When it comes to small devices, every byte counts and topic length has a big impact.
   * 
   * Use only ASCII characters, avoid non printable characters
   * Because non-ASCII UTF-8 characters often display incorrectly, it is very difficult to find typos or issues related
   * to the character set. Unless it is absolutely necessary, we recommend avoiding the use of non-ASCII characters in a topic.
   * 
   * Embed a unique identifier or the Client Id into the topic
   * It can be very helpful to include the unique identifier of the publishing client in the topic.
   * The unique identifier in the topic helps you identify who sent the message.
   * The embedded ID can be used to enforce authorization. Only a client that has the same client ID
   * as the ID in the topic is allowed to publish to that topic. For example, a client with the client1 ID
   * is allowed to publish to client1/status, but not permitted to publish to client2/status.
   * 
   * Don’t subscribe to #
   * Sometimes, it is necessary to subscribe to all messages that are transferred over the broker.
   * For example, to persist all messages into a database. Do not subscribe to all messages on a broker
   * by using an MQTT client and subscribing to a multi-level wildcard. Frequently, the subscribing client
   * is not able to process the load of messages that results from this method (especially if you have a massive throughput).
   * Our recommendation is to implement an extension in the MQTT broker. For example, with the plugin system of HiveMQ you can
   * hook into the behavior of HiveMQ and add an asynchronous routine to process each incoming message and persist it to a database.
   * 
   * Don’t forget extensibility
   * Topics are a flexible concept and there is no need to preallocate them in any way. However,
   * both the publisher and the subscriber need to be aware of the topic. It is important to think about how topics can be extended
   * to allow for new features or products. For example, if your smart-home solution adds new sensors, it should be possible
   * to add these to your topic tree without changing the whole topic hierarchy.
   * 
   * Use specific topics, not general ones
   * When you name topics, don’t use them in the same way as in a queue. Differentiate your topics as much as possible.
   * For example, if you have three sensors in your living room, create topics for myhome/livingroom/temperature,
   * myhome/livingroom/brightness and myhome/livingroom/humidity. Do not send all values over myhome/livingroom.
   * Use of a single topic for all messages is a anti pattern. Specific naming also makes it possible for you to
   * use other MQTT features such as retained messages. For more on retained messages, see part 8 of the Essentials series.
   * 
   */
  #endregion // topic: single- and multi-level

  #region QoS
  /*
   * QoS: Quality of Service
   * At most once  (best effort delivery "fire and forgett)
   * At least once (guaranteed that a message will be delivered at least once)
   * Exactly once  (guarantees that each message is received only one once by counterpart)
   */
  #endregion // QoS

  /// <summary>
  /// Implementierung für den MQTT Client
  /// </summary>
  public class MqttClientWrapper
  {
    private readonly MqttManager _mqttManager;

    public readonly string TcpServer;
    public readonly int    TcpServerPort;

    /// <summary>
    /// Konstuktor
    /// </summary>
    /// <param name="implementation"></param>
    public MqttClientWrapper(MqttManager mqttManager, IMqttClient implementation, string tcpServer = "localhost", int tcpServerPort = 1883)
    {
      _mqttManager   = mqttManager;
      Implementation = implementation;
      TcpServer      = tcpServer;
      TcpServerPort  = tcpServerPort;
    }

    public IMqttClient Implementation { get; }


    public bool IsConnected => Implementation.IsConnected;

    public MqttClientOptions Options => Implementation.Options;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="message"></param>
    /// <param name="mqttNetLogLevel"></param>
    private void Log(string source, string message, MqttNetLogLevel mqttNetLogLevel = MqttNetLogLevel.Info)
    {
      _mqttManager.ClientLogger.Publish(mqttNetLogLevel, source, message, null, null);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> ConnectAsync(TimeSpan timeSpan, CancellationToken cancellationToken)
    {
      var options = new MqttClientOptionsBuilder()
          .WithTcpServer(TcpServer, TcpServerPort)
          .WithTimeout(timeSpan)
          .Build();
      MqttClientConnectResult mqttClientConnectResult = await Implementation.ConnectAsync(options, cancellationToken);
      bool isSuccess       = mqttClientConnectResult.ResultCode == MqttClientConnectResultCode.Success;
      bool isAtMostOnce    = mqttClientConnectResult.MaximumQoS == MqttQualityOfServiceLevel.AtMostOnce;
      bool isAtLeastOnce   = mqttClientConnectResult.MaximumQoS == MqttQualityOfServiceLevel.AtLeastOnce;
      bool isAtExactlyOnce = mqttClientConnectResult.MaximumQoS == MqttQualityOfServiceLevel.ExactlyOnce;
      string message = $"MQTT: ResultCode={mqttClientConnectResult.ResultCode} MaximumQoS={mqttClientConnectResult.MaximumQoS}";
      Log(nameof(ConnectAsync), message);
      return isSuccess;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<MqttClientConnectResult> ConnectAsync(TimeSpan timeSpan, string username, string password, CancellationToken cancellationToken)
    {
      var options = new MqttClientOptionsBuilder()
          .WithTcpServer(TcpServer, TcpServerPort)
          .WithTimeout(timeSpan)
          .WithUserProperty(username, password)
          .Build();
      return await ConnectAsync(options, cancellationToken);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<MqttClientConnectResult> ConnectAsync(MqttClientOptions options, CancellationToken cancellationToken)
    {
      return await Implementation.ConnectAsync(options, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task DisconnectAsync(CancellationToken cancellationToken)
    {
      await Implementation.DisconnectAsync(new MqttClientDisconnectOptions(), cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
      Implementation.Dispose();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="payload"></param>
    /// <param name="qOs"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<MqttClientPublishResult> PublishAsync(string topic, string payload, MqttQualityOfServiceLevel qOs, CancellationToken cancellationToken)
    {
      var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
              //.WithAtLeastOnceQoS()
                .WithPayload(payload)
                .Build();
      applicationMessage.QualityOfServiceLevel = qOs;
      return await PublishAsync(applicationMessage, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="payload"></param>
    /// <param name="qOs"></param>
    /// <returns></returns>
    public async Task<MqttClientPublishResult> PublishAsync(string topic, string payload, MqttQualityOfServiceLevel qOs = MqttQualityOfServiceLevel.AtMostOnce)
    {
      return await PublishAsync(topic, payload, qOs, CancellationToken.None);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationMessage"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<MqttClientPublishResult> PublishAsync(MqttApplicationMessage applicationMessage, CancellationToken cancellationToken)
    {
      return await Implementation.PublishAsync(applicationMessage, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="qualityOfServiceLevel"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<MqttClientSubscribeResult> SubscribeAsync(string topic, MqttQualityOfServiceLevel qualityOfServiceLevel, CancellationToken cancellationToken)
    {
      var options =  new MqttClientSubscribeOptions
      {
        TopicFilters = new List<MqttTopicFilter> 
        { 
          new MqttTopicFilter 
          { 
            Topic = topic,
            QualityOfServiceLevel = qualityOfServiceLevel,
          } 
        },
      };
      return await SubscribeAsync(options, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="qualityOfServiceLevel"></param>
    /// <returns></returns>
    public async Task<MqttClientSubscribeResult> SubscribeAsync(string topic, MqttQualityOfServiceLevel qualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce)
    {
      return await SubscribeAsync(topic, qualityOfServiceLevel, CancellationToken.None);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<MqttClientSubscribeResult> SubscribeAsync(MqttClientSubscribeOptions options, CancellationToken cancellationToken)
    {
      return await Implementation.SubscribeAsync(options, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="topic"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<MqttClientUnsubscribeResult> UnsubscribeAsync(string topic, CancellationToken cancellationToken)
    {
      MqttClientUnsubscribeOptions options = new MqttClientUnsubscribeOptions
      {
        TopicFilters = new List<string> 
        { 
          topic,
        },
      };
      return await Implementation.UnsubscribeAsync(options, cancellationToken);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<MqttClientUnsubscribeResult> UnsubscribeAsync(MqttClientUnsubscribeOptions options, CancellationToken cancellationToken)
    {
      return await Implementation.UnsubscribeAsync(options, cancellationToken);
    }

    #if false
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task PingAsync(CancellationToken cancellationToken)
    {
      return Implementation.PingAsync(cancellationToken);
    }
    #endif

    #if false
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public Task SendExtendedAuthenticationExchangeDataAsync(MqttExtendedAuthenticationExchangeData data)
    {
      return Implementation.SendExtendedAuthenticationExchangeDataAsync(data);
    }
    #endif

    #if false
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task SendExtendedAuthenticationExchangeDataAsync(MqttExtendedAuthenticationExchangeData data, CancellationToken cancellationToken)
    {
      return Implementation.SendExtendedAuthenticationExchangeDataAsync(data, cancellationToken);
    }
    #endif
  }
}
