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
  public class IhtModbusCmdExecInputEmulation : IhtModbusCmdBase
    {
    public enum eCmdBit
    {
      None           = 0x0000,
      MoveManUp      = 0x0001,
      MoveManDown    = 0x0002,
      Calibrate      = 0x0004,
      HeightCtrlUp   = 0x0008,
      HeightCtrlDown = 0x0010
    }

    public enum eCmdIdx
    {
      MoveManUp,
      StopManUp,
      MoveManDown,
      StopManDown,
      CalibrateOn,
      CalibrateOff,
      HeightCtrlUp,
      StopHeightCtrlUp,
      HeightCtrlDown,
      StopHeightCtrlDown,

      Length
    }

    private IhtModbusCmdHeartbeat ihtModbusCmdHeartbeat;
    private Dictionary<int, UInt16> registers = new Dictionary<int, UInt16>();

    public IhtModbusCmdExecInputEmulation(IhtModbusCommunic _ihtModbusCommunic)
      : base(_ihtModbusCommunic, (UInt16)IhtModbusParamDyn.eIdxCmdExec.InputEmulation)
    {
      ihtModbusCmdHeartbeat = new IhtModbusCmdHeartbeat(this.SetHeartbeatAsync, 250);
    }

    override protected UInt16 GetStartAddr(IhtModbusData ihtModbusData)
    {
      return ihtModbusData.GetAddrInfo_CmdExec().u16StartAddr;
    }

    private UInt16 GetRegister(int _slaveId)
    {
      if (!registers.ContainsKey(_slaveId))
      {
        registers.Add(_slaveId, 0);
      }
      return registers[_slaveId];
    }


    static readonly object _lock = new object();
    private UInt16 SetBit(int _slaveId, eCmdBit eCmdBit)
    {
      UInt16 register = 0;
      lock (_lock)
      {
        register = GetRegister(_slaveId);
        register |= (UInt16)eCmdBit;
        registers[_slaveId] = register;
      }
      return register;
    }

    private UInt16 ClrBit(int _slaveId, eCmdBit eCmdBit)
    {
      UInt16 bit = 0;
      UInt16 register = 0;
      lock (_lock)
      {
        bit = (UInt16)eCmdBit;
        register = GetRegister(_slaveId);
        register &= (UInt16)~bit;
        registers[_slaveId] = register;
      }
      return register;
    }

    private async Task SetAsync(int slaveId, eCmdIdx eCmdIdx, eCmdBit eCmdBit)
    {
      UInt16 register = SetBit(slaveId, eCmdBit);
      await WriteAsync(slaveId, register).ConfigureAwait(false);
#if DEBUG
      string msg = String.Format("IhtModbusCmdExecInputEmulation.Set: SlaveId={0}, CmdBit{1}", slaveId, eCmdIdx.ToString());
      Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,FFF") + " " + msg);
#endif
    }

    private async Task ClrAsync(int slaveId, eCmdIdx eCmdIdx, eCmdBit eCmdBit)
    {
      UInt16 register = ClrBit(slaveId, eCmdBit);

      await WriteAsync(slaveId/*, sema*/, register).ConfigureAwait(false);
#if DEBUG
      string msg = String.Format("IhtModbusCmdExecInputEmulation.Clr: SlaveId={0}, CmdBit{1}", slaveId, eCmdIdx.ToString());
      Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,FFF") + " " + msg);
#endif
    }

    public async Task MoveManUpAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdIdx.MoveManUp, eCmdBit.MoveManUp).ConfigureAwait(false);
    }
    public async Task StopManUpAsync(int slaveId)
    {
      await ClrAsync(slaveId, eCmdIdx.StopManUp, eCmdBit.MoveManUp).ConfigureAwait(false);
    }

    public async Task MoveManDownAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdIdx.MoveManDown, eCmdBit.MoveManDown).ConfigureAwait(false);
    }
    public async Task StopManDownAsync(int slaveId)
    {
      await ClrAsync(slaveId, eCmdIdx.StopManDown, eCmdBit.MoveManDown).ConfigureAwait(false);
    }

    public async Task CalibrateOnAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdIdx.CalibrateOn, eCmdBit.Calibrate).ConfigureAwait(false);
    }
    public async Task CalibrateOffAsync(int slaveId)
    {
      await ClrAsync(slaveId, eCmdIdx.CalibrateOff, eCmdBit.Calibrate).ConfigureAwait(false);
    }

    public async Task HeightCtrlUpAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdIdx.HeightCtrlUp, eCmdBit.HeightCtrlUp).ConfigureAwait(false);
    }
    public async Task StopHeightCtrlUpAsync(int slaveId)
    {
      await ClrAsync(slaveId, eCmdIdx.StopHeightCtrlUp, eCmdBit.HeightCtrlUp).ConfigureAwait(false);
    }

    public async Task HeightCtrlDownAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdIdx.HeightCtrlDown, eCmdBit.HeightCtrlDown).ConfigureAwait(false);
    }
    public async Task StopHeightCtrlDownAsync(int slaveId)
    {
      await ClrAsync(slaveId, eCmdIdx.StopHeightCtrlDown, eCmdBit.HeightCtrlDown).ConfigureAwait(false);
    }


    internal async Task StartCalibrationAsync(int slaveId)
    {
      //u16Register |= (UInt16)eCmdBit.Calibrate;
      await SetAsync(slaveId, eCmdIdx.CalibrateOn, eCmdBit.Calibrate).ConfigureAwait(false);
      await ihtModbusCmdHeartbeat.StartHeartbeatAsync(slaveId).ConfigureAwait(false);
    }
    internal async Task StopCalibrationAsync(int slaveId)
    {
      await ihtModbusCmdHeartbeat.StopHeartbeatAsync(slaveId).ConfigureAwait(false);
      await ClrAsync(slaveId, eCmdIdx.CalibrateOff, eCmdBit.Calibrate).ConfigureAwait(false);
      //UInt16 bit = (UInt16)eCmdBit.Calibrate;
      //u16Register &= (UInt16)~bit;
      //Write(slaveId);
    }

    private async Task SetHeartbeatAsync(int slaveId)
    {
//      Write(slaveId);
      UInt16 register = GetRegister(slaveId);
      await WriteAsync(slaveId, register).ConfigureAwait(false);
    }

  }
}
