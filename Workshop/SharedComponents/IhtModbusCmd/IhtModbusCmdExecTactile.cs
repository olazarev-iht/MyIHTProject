using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtModbusCmd
{
  public class IhtModbusCmdExecTactile : IhtModbusCmdBase
  {
    /// <summary>
    /// 
    /// </summary>
    public enum eCmdBit
    {
      ClrErrorCode                 = 0x0001,
      Ignite                       = 0x0002,
      ReloadPreHeatTime            = 0x0004,
      StopPreHeatTime              = 0x0008,
      ClrCapSetpointFlameOffsets   = 0x0010,
      ClrPressureOutputs           = 0x0020,
      CutO2Blowout                 = 0x0040,
      CutO2BlowoutBreak            = 0x0080,
      ClearenceCtrlManualPosition  = 0x0100,

      ExecuteClearanceSignalAdjust = 0x4000,
      ExecuteReset                 = 0x8000
    }

    public enum eCmdIdx
    {
      ClrErrorCode,
      Ignite,
      ReloadPreHeatTime,
      StopPreHeatTime,
      ClrCapSetpointFlameOffsets,
      ClrPressureOutputs,
      CutO2Blowout,
      CutO2BlowoutBreak,
      ClearenceCtrlManualHeight,

      ExecuteClearanceSignalAdjust,
      ExecuteReset,

      Length
    }

    public IhtModbusCmdExecTactile(IhtModbusCommunic _ihtModbusCommunic)
      : base(_ihtModbusCommunic, (UInt16)IhtModbusParamDyn.eIdxCmdExec.Tactile)
    {
    }

    override protected UInt16 GetStartAddr(IhtModbusData ihtModbusData)
    {
      return ihtModbusData.GetAddrInfo_CmdExec().u16StartAddr;
    }

    private async Task SetAsync(int slaveId, eCmdIdx eCmdIdx, eCmdBit eCmdBit)
    {
      u16Register = (UInt16)eCmdBit;
      await WriteAsync(slaveId).ConfigureAwait(false);
      UInt16 bit = (UInt16)eCmdBit;
      u16Register &= (UInt16)~bit;
#if DEBUG
      string msg = String.Format("IhtModbusCmdExecTactile.Set: SlaveId={0}, CmdBit{1}", slaveId, eCmdIdx.ToString());
      Debug.Print(DateTime.Now.ToString("yyyy-MM-dd,FFF") + " " + msg);
#endif
    }

    public async Task ClrErrorCode(int slaveId)
    {
      await SetAsync(slaveId, eCmdIdx.ClrErrorCode, eCmdBit.ClrErrorCode).ConfigureAwait(false);
    }

    public async Task ReloadPreHeatTimeAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdIdx.ReloadPreHeatTime, eCmdBit.ReloadPreHeatTime).ConfigureAwait(false);
    }
    public async Task StopPreHeatTimeAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdIdx.StopPreHeatTime, eCmdBit.StopPreHeatTime).ConfigureAwait(false);
    }

    public async Task StartCutO2BlowoutAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdIdx.CutO2Blowout, eCmdBit.CutO2Blowout).ConfigureAwait(false);
    }
    public async Task BreakCutO2BlowoutAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdIdx.CutO2BlowoutBreak, eCmdBit.CutO2BlowoutBreak).ConfigureAwait(false);
    }

    internal async Task SetClearenceCtrlManualHeightAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdIdx.ClearenceCtrlManualHeight, eCmdBit.ClearenceCtrlManualPosition).ConfigureAwait(false);
    }

    internal async Task ExecuteClearanceSignalAdjust(int slaveId)
    {
      await SetAsync(slaveId, eCmdIdx.ExecuteClearanceSignalAdjust, eCmdBit.ExecuteClearanceSignalAdjust).ConfigureAwait(false);
    }

    internal async Task ExecuteResetAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdIdx.ExecuteReset, eCmdBit.ExecuteReset).ConfigureAwait(false);
    }
  }
}
