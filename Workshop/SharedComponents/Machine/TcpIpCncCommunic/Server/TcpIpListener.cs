using SharedComponents.Helpers;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using SharedComponents.IhtMsg;

namespace SharedComponents.Machine.TcpIpCncCommunic.Server
{
  class TcpIpListener
  {
    public bool      Initialized { get; private set; } = false;

    public IPAddress IPAddress { get; private set; } = IPAddress.Parse("127.0.0.1");
    public int       Port      { get; private set; } = 50000;
    public int       Limit     { get; private set; } = 1; // concurrent clients
    
    public string StatusMsgPending   { get; private set; } = "not available";
    public string StatusMsgConnected { get; private set; } = "not available";
    public bool   IsServerPending    { get; private set; } = false;
    public bool   IsClientConnect    { get; private set; } = false;

    private TcpListener             _tcpListener;
    private CancellationTokenSource _cts;
    private Task                    _tskbgWorker;
//    private Task                    _doTask;

    private CmdCodeManager _cmdCodeManager;
    /// <summary>
    /// Konstruktor
    /// </summary>
    public TcpIpListener()
    {
      _cmdCodeManager = new CmdCodeManager();
    }

    /// <summary>
    /// Initialisierung
    /// </summary>
    /// <param name="iPAddress"></param>
    /// <param name="port"></param>
    /// <param name="limit"></param>
    public void Init(IPAddress iPAddress, int port, int limit=1)
    {
      IPAddress = iPAddress ?? throw new ArgumentNullException(nameof(iPAddress));
      Port      = port;
      Limit     = limit;
//      _tcpListener = new TcpListener(IPAddress, Port);
//      Initialized  = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void StartListener()
    {
      if (!Initialized)
      {
        try
        {
          _tcpListener = new TcpListener(IPAddress, Port);
          Initialized  = true;
        }
        catch (Exception ex)
        {
          Debug.Print($"{Helper.GetDateTimeDebug()}: {ex.Message}");
          SetStatusMsg(IhtMsgLog.Info.Warning, ex.Message);
          return;
        }
      }

      if (_tskbgWorker == null || _tskbgWorker.IsCompleted)
      {
        _cts         = new CancellationTokenSource();
        _tskbgWorker = Task.Run(() => ListenerAsync());
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public void StopListener()
    {
      if (!Initialized)
      {
        return;
      }

      if (_cts != null)
      {
        _cts.Cancel();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    private async Task ListenerAsync()
    {
      /*
         https://www.codeproject.com/Questions/1247521/How-to-detect-client-disconnection-from-server-usi
         https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.socket.connected?redirectedfrom=MSDN&view=net-5.0#System_Net_Sockets_Socket_Connected
         Each side of a connection should inform the other side when it closes the connection.
         This must be done at data protocol level. For example one side sends a request to stop
         communication and the other answers with an acknowledge response. The side sending the
         request closes the connection when the response has been received and the other side
         after the response has been send.
       */
      #if true
      Socket tcpClient = null;
      #else
      TcpClient tcpClient = _tcpListener.AcceptTcpClient();
      #endif

      try
      {
        _tcpListener.Start();
        Debug.Print($"{Helper.GetDateTimeDebug()}: TcpIpListener.ListenerAsync() started");

        var token = _cts.Token; 

        while (!token.IsCancellationRequested)
        {
          Debug.Print($"{Helper.GetDateTimeDebug()}: TcpIpListener.ListenerAsync() pending");
          StatusMsgPending = $"TCP-Server is pending at {_tcpListener.LocalEndpoint.ToString()}";
          IsServerPending  = true;
          Debug.Print($"{Helper.GetDateTimeDebug()}: {StatusMsgPending}");
          SetStatusMsg(IhtMsgLog.Info.Info, StatusMsgPending);
          do
          {
            await Task.Delay(10);
            token.ThrowIfCancellationRequested();
          } while (!_tcpListener.Pending());

          Debug.Print($"{Helper.GetDateTimeDebug()}: TcpIpListener.ListenerAsync() acceptSocket");
          #if true
          tcpClient = _tcpListener.AcceptSocket();
          StatusMsgConnected = $"TCP-Client ({tcpClient.RemoteEndPoint.ToString()}) is connected";
          #else
          tcpClient = _tcpListener.AcceptTcpClient();
          StatusMsgConnected = $"TCP-Client ({tcpClient.Client.RemoteEndPoint.ToString()}) is connected";
          #endif
          Debug.Print($"{Helper.GetDateTimeDebug()}: {StatusMsgConnected}");
          SetStatusMsg(IhtMsgLog.Info.Info, StatusMsgConnected);
          IsClientConnect = true;

          try
          {
            int bytesRead = 0;
            bool doLoop = true;
            do
            { 
              if (tcpClient.Available == 0)
              {
                await Task.Delay(10);
                token.ThrowIfCancellationRequested();
                continue;
              }
                
              using (NetworkStream ns = new NetworkStream(tcpClient))
              {
                if (ns.CanRead)
                {
                  // Reads NetworkStream into a byte buffer.
                  byte[] bytes = new byte[tcpClient.ReceiveBufferSize];

                  // Read can return anything from 0 to numBytesToRead.
                  bytesRead = await ns.ReadAsync(bytes, 0, (int)tcpClient.ReceiveBufferSize, token);

                  token.ThrowIfCancellationRequested();

                  if (bytesRead > 0)
                  {
                    bool result = await _cmdCodeManager.CmdHandler(ns, token, bytes, bytesRead);
                    if (result && _cmdCodeManager.IsExecCmdConnectionClosed)
                    {
                      _cmdCodeManager.IsExecCmdConnectionClosed = false;
                      string msg = $"TCP-Client ({tcpClient.RemoteEndPoint}) has sent command to close the connection";
                      Debug.Print($"{Helper.GetDateTimeDebug()}: {msg}");
                      SetStatusMsg(IhtMsgLog.Info.Info, msg);
                      await Task.Delay(2000);
                      msg = $"TCP-Client ({tcpClient.RemoteEndPoint}) connection is closed";
                      Debug.Print($"{Helper.GetDateTimeDebug()}: {msg}");
                      SetStatusMsg(IhtMsgLog.Info.Info, msg);
                      IsClientConnect = false;
                      tcpClient.Close();
                      doLoop = false;
                    }
                  }
                  else
                  {
                  }
                }
              } // using (NetworkStream ns = new NetworkStream(tcpClient))
            }  while (doLoop);
          }
          catch (OperationCanceledException)
          {
            _cts = null;
            Debug.Print($"{Helper.GetDateTimeDebug()}: TcpIpListener.ListenerAsync() OperationCanceledException");
          }
          catch (Exception ex)
          {
            _cts = null;
            Debug.Print($"{Helper.GetDateTimeDebug()}: {ex.Message}");
            SetStatusMsg(IhtMsgLog.Info.Warning, ex.Message);
          }
          finally
          {
            if (tcpClient != null && IsServerPending && IsClientConnect)
            {
              await SendInfoCloseConnectionAsync(tcpClient);
              tcpClient.Close();
              IsClientConnect = false;
            }
          }
        } // while (!token.IsCancellationRequested)
      } 
      catch (OperationCanceledException)
      {
        _cts = null;
        Debug.Print($"{Helper.GetDateTimeDebug()}: TcpIpListener.ListenerAsync() OperationCanceledException");
      }
      catch (Exception ex)
      {
        Debug.Print($"{Helper.GetDateTimeDebug()}: {ex.Message}");
        SetStatusMsg(IhtMsgLog.Info.Warning, ex.Message);
        _cts = null;
      }
      finally
      {
        if (tcpClient != null && IsServerPending && IsClientConnect)
        {
          await SendInfoCloseConnectionAsync(tcpClient);
          tcpClient.Close();
          IsClientConnect = false;
        }
        _tcpListener.Stop();
        IsServerPending = false;
        IsClientConnect = false;
        Debug.Print($"{Helper.GetDateTimeDebug()}: TcpIpListener.ListenerAsync() stopped");
        string msg = $"TCP-Server ({_tcpListener.LocalEndpoint.ToString()}) is stopped";
        Debug.Print($"{Helper.GetDateTimeDebug()}: {msg}");
        SetStatusMsg(IhtMsgLog.Info.Info, msg);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tcpClient"></param>
    /// <returns></returns>
    private async Task SendInfoCloseConnectionAsync(Socket tcpClient)
    {
      try
      {
        using (NetworkStream ns = new NetworkStream(tcpClient))
        {
          if (ns.CanWrite)
          {
            UInt16 cmdCode   = Convert.ToUInt16(CmdCodeManager.CmdCode.CloseConnection); // 2
            byte[] sendBytes = new byte[2];
            BitConverter.GetBytes(cmdCode).CopyTo(sendBytes, 0);
            ns.Write(sendBytes, 0, sendBytes.Length);
            string msg = $"TCP-Server ({_tcpListener.LocalEndpoint.ToString()}) has sent command to the client ({tcpClient.RemoteEndPoint.ToString()}) to close the connection";
            Debug.Print($"{Helper.GetDateTimeDebug()}: {msg}");
            SetStatusMsg(IhtMsgLog.Info.Info, msg);
            
            int loopDelay_ms =   10;
            int maxDelay_ms  = 2000;
            int sumDelay_ms  =    0;
            
            while (tcpClient.Available == 0 && sumDelay_ms < maxDelay_ms)
            { 
              await Task.Delay(loopDelay_ms);
              sumDelay_ms += loopDelay_ms;
            }

            if (ns.CanRead)
            {
              // Reads NetworkStream into a byte buffer.
              byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
            
              int bytesRead = ns.Read(bytes, 0, (int)tcpClient.ReceiveBufferSize);
              if (bytesRead >= 4)
              {
                      cmdCode = BitConverter.ToUInt16(bytes,  0);
                Int16 status  = BitConverter.ToInt16 (bytes,  2);
              }
            }
            
            int delay_ms = maxDelay_ms - sumDelay_ms;
            if (delay_ms < 0)
            {
              await Task.Delay(delay_ms);
            }

            msg = $"TCP-Client ({tcpClient.RemoteEndPoint.ToString()}) connection is closed";
            Debug.Print($"{Helper.GetDateTimeDebug()}: {msg}");
            SetStatusMsg(IhtMsgLog.Info.Info, msg);
            IsClientConnect = false;
          }
        } // using (NetworkStream ns = new NetworkStream(tcpClient))
      }
      catch (Exception ex)
      {
        SetStatusMsg(IhtMsgLog.Info.Warning, ex.Message);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="info"></param>
    /// <param name="message"></param>
    private void SetStatusMsg(IhtMsgLog.Info info, string msg)
    {
      MainWndHelper.GetMainWndHelper().SetStatusMsg(info, msg);
    }
  }
}
