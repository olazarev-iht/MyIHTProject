using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SharedComponents.IhtModbusCmd
{
  public class IhtModbusCmdSetupCtrl : IhtModbusCmdBase
  {
    public enum eCmd
    {
      Off = 0,
      Start,
      Ignition,
      PreHeating,
      Piercing,
      Cutting,
      CheckFlame,
      Ramp,
      Temper,

      Length
    }
    
    private enum eSema
    {
      Cmd,
      Heartbeat,

      Length
    }
    private enum Heartbeat  
    { 
      StartDelayTime_ms = 500
    }

    IhtModbusCmdHeartbeat ihtModbusCmdHeartbeat;

    public IhtModbusCmdSetupCtrl(IhtModbusCommunic _ihtModbusCommunic)
      : base(_ihtModbusCommunic, (UInt16)IhtModbusParamDyn.eIdxSetupExec.Setup)
    {
      ihtModbusCmdHeartbeat = new IhtModbusCmdHeartbeat(this.SetHeartbeatAsync, 500);
    }

    override protected UInt16 GetStartAddr(IhtModbusData ihtModbusData)
    {
      return ihtModbusData.GetAddrInfo_SetupExec().u16StartAddr;
    }

    private async Task SetAsync(int slaveId, eCmd eCmd)
    {
      u16Register = (UInt16)eCmd;
      await WriteAsync(slaveId/*, sema*/).ConfigureAwait(false);
#if DEBUG
      string msg = String.Format("IhtModbusCmdSetupCtrl.Set: SlaveId={0}, CmdBit{1}", slaveId, eCmd.ToString());
      Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,FFF") + " " + msg);
#endif
    }

    public async Task SetOffAsync(int slaveId, bool setCmdOff=true)
    {
      if (setCmdOff)
      {
        await SetAsync(slaveId, eCmd.Off).ConfigureAwait(false);
      }
      await ihtModbusCmdHeartbeat.StopHeartbeatAsync(slaveId).ConfigureAwait(false);
    }
    public async Task SetStartAsync(int slaveId, bool ignoreStartDelay = false)
    {
      await ihtModbusCmdHeartbeat.StartHeartbeatAsync(slaveId).ConfigureAwait(false);
      
      // Der Control-Unit etwas Zeit geben, um den Heartbeat zu starten
      if (!ignoreStartDelay)
      {
        await Task.Delay((int)Heartbeat.StartDelayTime_ms).ConfigureAwait(false);
      }
      await SetAsync(slaveId, eCmd.Start).ConfigureAwait(false);
    }
    public async Task SetIgnitionAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmd.Ignition);
    }
    public async Task SetPreHeatingAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmd.PreHeating).ConfigureAwait(false);
    }
    public async Task SetPiercingAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmd.Piercing).ConfigureAwait(false);
    }
    public async Task SetCuttingAsync(int slaveId)
    {
      await SetAsync(slaveId, /*eCmd.Cutting*/eCmd.Ramp).ConfigureAwait(false);
    }
    public async Task SetHeatingAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmd.CheckFlame).ConfigureAwait(false);
    }
    public async Task SetRampAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmd.Ramp).ConfigureAwait(false);
    }
    public async Task SetTemperAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmd.Temper).ConfigureAwait(false);
    }

    private async Task SetHeartbeatAsync(int slaveId)
    {
      IhtModbusData ihtModbusData = ihtModbusCommunic.GetData(slaveId) as IhtModbusData;
      if (ihtModbusData != null)
      {
        UInt16 u16StartAddr = ihtModbusData.GetAddrInfo_SetupExec().u16StartAddr;
        u16StartAddr += (UInt16)IhtModbusParamDyn.eIdxSetupExec.Heartbeat;
        UInt16 u16Register = IhtModbusParamDyn.u16SetupExecHeartbeatValue;
        await ihtModbusCommunic.WriteAsync(slaveId, u16StartAddr, u16Register).ConfigureAwait(false);
      }
    }

  }
}
