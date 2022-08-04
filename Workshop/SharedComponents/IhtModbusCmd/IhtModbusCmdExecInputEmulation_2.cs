using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SharedComponents.IhtModbusCmd
{
  public class IhtModbusCmdExecInputEmulation_2 : IhtModbusCmdBase
  {
    /// <summary>
    /// 
    /// </summary>
    public enum eCmdBit
    {
      None = 0x0000,
      StartProcess = 0x0001,
      DelayStartPreHeatTime = 0x0002,
    }

    public enum eCmdIdx
    {
      StartProcessOn,
      StartProcessOff,
      
      DelayStartPreHeatTime_Active,
      DelayStartPreHeatTime_InActive,
      
      Length
    }

    private IhtModbusCmdHeartbeat ihtModbusCmdHeartbeat;

    public IhtModbusCmdExecInputEmulation_2(IhtModbusCommunic _ihtModbusCommunic)
      : base(_ihtModbusCommunic, (UInt16)IhtModbusParamDyn.eIdxCmdExec.InputEmulation_2)
    {
      ihtModbusCmdHeartbeat = new IhtModbusCmdHeartbeat(this.SetHeartbeatAsync, 250);
    }

    override protected UInt16 GetStartAddr(IhtModbusData ihtModbusData)
    {
      return ihtModbusData.GetAddrInfo_CmdExec().u16StartAddr;
    }

    public async Task StartProcessOnAsync(int slaveId)
    {
      u16Register |= (UInt16)eCmdBit.StartProcess;
      await ihtModbusCmdHeartbeat.StartHeartbeatAsync(slaveId).ConfigureAwait(false);
    }
    public async Task StopProcessOnAsync(int slaveId)
    {
      await ihtModbusCmdHeartbeat.StopHeartbeatAsync(slaveId).ConfigureAwait(false);
      UInt16 bit = (UInt16)eCmdBit.StartProcess;
      u16Register &= (UInt16)~bit;
      await WriteAsync(slaveId).ConfigureAwait(false);
    }

    public async Task DelayStartPreHeatTime_ActiveAsync(int slaveId)
    {
      u16Register |= (UInt16)eCmdBit.DelayStartPreHeatTime;
      // Nur wenn kein StartProcess aktiv ist
      if ((u16Register & (UInt16)eCmdBit.StartProcess) == 0)
      {
        await ihtModbusCmdHeartbeat.StartHeartbeatAsync(slaveId).ConfigureAwait(false);
      }
    }
    public async Task DelayStartPreHeatTime_InActiveAsync(int slaveId)
    {
      UInt16 bit = (UInt16)eCmdBit.DelayStartPreHeatTime;
      u16Register &= (UInt16)~bit;
      // Nur wenn kein StartProcess aktiv ist
      if ((u16Register & (UInt16)eCmdBit.StartProcess) == 0)
      {
        await ihtModbusCmdHeartbeat.StopHeartbeatAsync(slaveId).ConfigureAwait(false);
        await WriteAsync(slaveId).ConfigureAwait(false);
      }
    }

    private async Task SetHeartbeatAsync(int slaveId)
    {
      await WriteAsync(slaveId).ConfigureAwait(false);
    }

  }
}
