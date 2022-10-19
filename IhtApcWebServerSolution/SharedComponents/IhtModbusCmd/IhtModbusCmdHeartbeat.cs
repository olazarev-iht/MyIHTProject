using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharedComponents.IhtModbusCmd
{
  class IhtModbusCmdHeartbeat
  {
    public delegate Task SetHeartbeatDelegate(int slaveId);
    private SetHeartbeatDelegate setHeartbeat;
    
    private bool stopHeartbeatTask { get; set; }
    private Task tskHeartbeat { get; set; }
    private Stopwatch stopwatch = new Stopwatch();

    // https://www.dotnetperls.com/dictionary
    private Dictionary<int, int> heartbeatSlaveIds = new Dictionary<int, int>();

    public int IntervalTime_ms { get; set; }

    public IhtModbusCmdHeartbeat(SetHeartbeatDelegate _setHeartbeatDelegate, int _intervalTime_ms)
    {
      setHeartbeat    = _setHeartbeatDelegate;
      IntervalTime_ms = _intervalTime_ms;
    }

    SemaphoreSlim mutexHeartbeat = new SemaphoreSlim(1);
    private async Task WorkTask()
    {
      while (!stopHeartbeatTask)
      {
        await mutexHeartbeat.WaitAsync().ConfigureAwait(false);
        stopwatch.Reset();
        stopwatch.Start();
        foreach (KeyValuePair<int, int> kvp in heartbeatSlaveIds)
        {
          string msg = String.Format("Thread Heartbeat: SlaveId={0}", kvp.Value);
          Debug.Print(DateTime.Now.ToString("yyyy-MM-dd,FFF") + " " + msg);
          if (setHeartbeat != null && !stopHeartbeatTask)
          {
            await setHeartbeat(kvp.Value).ConfigureAwait(false);
          }
        }
        stopwatch.Stop();
        Debug.Print("Thread Heartbeat: " + stopwatch.ElapsedMilliseconds.ToString() + "ms");
        mutexHeartbeat.Release();
        await Task.Delay(IntervalTime_ms).ConfigureAwait(false);
      }
    }
    
    public async Task StartHeartbeatAsync(int SlaveId)
    {
      await mutexHeartbeat.WaitAsync().ConfigureAwait(false);
      if (!heartbeatSlaveIds.ContainsKey(SlaveId))
      {
        heartbeatSlaveIds.Add(SlaveId, SlaveId);
      }
      // Wenn mindestens ein Eintrag vorhanden ist, task freigeben
      if (heartbeatSlaveIds.Count > 0)
      {
        stopHeartbeatTask = false;
      }
      mutexHeartbeat.Release();

      if (tskHeartbeat == null || tskHeartbeat.IsCompleted)
      {
        //tskHeartbeat = Task.Factory.StartNew(() => WorkTask());
        tskHeartbeat = Task.Run(() => WorkTask());
      }
    }

    public async Task StopHeartbeatAsync(int SlaveId)
    {
      await mutexHeartbeat.WaitAsync().ConfigureAwait(false);
      if (heartbeatSlaveIds.ContainsKey(SlaveId))
      {
        heartbeatSlaveIds.Remove(SlaveId);
      }
      // Wenn kein Eintrag vorhanden ist, task beenden
      if (heartbeatSlaveIds.Count == 0)
      {
        stopHeartbeatTask = true;
      }
      mutexHeartbeat.Release();
    }

    public async Task StopHeartbeatsAsync()
    {
      await mutexHeartbeat.WaitAsync().ConfigureAwait(false);
      // Alle eingetragenen Slave-Id's loeschen
      heartbeatSlaveIds.Clear();
      // Task beenden
      stopHeartbeatTask = true;
      mutexHeartbeat.Release();
    }
  }
}
