using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Diagnostics;
using System.Diagnostics;

namespace SharedComponents.Machine.Mqtt
{
  /// <summary>
  /// Erzeugung MQTT-Clients
  /// </summary>
  public sealed class MqttManager : IDisposable
  {
    private readonly MqttFactory       _mqttFactory  = new MqttFactory();
    private readonly List<IMqttClient> _clients      = new List<IMqttClient>();
    private readonly List<string>      _clientErrors = new List<string>();
    private readonly List<Exception>   _exceptions   = new List<Exception>();

    public bool   IgnoreClientLogErrors { get; set; } = true;

    public MqttNetEventLogger ClientLogger { get; } = new MqttNetEventLogger("client");

    public bool IsClientsError => _clientErrors.Count > 0;

    public void ClearClientsError() => _clientErrors.Clear();

    public MqttManager()
    {
      ClientLogger.LogMessagePublished += (s, e) =>
      {
        if (Debugger.IsAttached)
        {
          Debug.WriteLine(e.LogMessage.ToString());
        }

        if (e.LogMessage.Level == MqttNetLogLevel.Error)
        {
          lock (_clientErrors)
          {
            _clientErrors.Add(e.LogMessage.ToString());
          }
        }
      };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public MqttClientWrapper CreateClient(string server = "localhost", int serverPort = 1883)
    {
      lock (_clients)
      {
        var client = _mqttFactory.CreateMqttClient(ClientLogger);
        _clients.Add(client);

        return new MqttClientWrapper(this, client, server, serverPort);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public void ThrowIfLogErrors()
    {
      lock (_clientErrors)
      {
        if (!IgnoreClientLogErrors && _clientErrors.Count > 0)
        {
            throw new Exception($"Client(s) had {_clientErrors.Count} errors (${string.Join(Environment.NewLine, _clientErrors)}).");
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="exception"></param>
    public void TrackException(Exception exception)
    {
      lock (_exceptions)
      {
        _exceptions.Add(exception);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
      foreach (var mqttClient in _clients)
      {
        try
        {
          mqttClient.DisconnectAsync().GetAwaiter().GetResult();
        }
        catch
        {
          // This can happen when the test already disconnected the client.
        }
        finally
        {
          mqttClient?.Dispose();
        }
      }

      ThrowIfLogErrors();

      if (_exceptions.Any())
      {
          //throw new Exception($"{_exceptions.Count} exceptions tracked.\r\n" + string.Join(Environment.NewLine, _exceptions));
      }
    }
  }
}
