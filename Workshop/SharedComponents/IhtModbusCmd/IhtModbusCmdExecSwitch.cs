using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;
using SharedComponents.IhtModbusCmd;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtModbusCmd
{
  /// <summary>
  /// 
  /// </summary>
  public class IhtModbusCmdExecSwitch : IhtModbusCmdBase
  {
    public enum eCmdBit
    {
      LockPressureOutput     = 0x0001,
      FlameOnAtProcessEnd    = 0x0002,
      RetractPosAtProcessEnd = 0x0004,
      Temper                 = 0x0008,
      ClearanceControlOff    = 0x0010,
      ClearanceControlManual = 0x0020,
      TorchOff               = 0x0040,
    }

    public enum eCmdIdx
    {
      LockPressureOutput,
      FlameOnAtProcessEnd,
      RetractPosAtProcessEnd,
      Temper,
      ClearanceControlOff,
      ClearanceControlManual,
      TorchOff,

      Length
    }

    private Dictionary<int, UInt16> registers = new Dictionary<int, UInt16>();
    private Dictionary<int, ArrayList> slavesSemaphores = new Dictionary<int, ArrayList>();

    /// <summary>
    /// 
    /// </summary>
    public IhtModbusCmdExecSwitch(IhtModbusCommunic _ihtModbusCommunic)
      : base(_ihtModbusCommunic, (UInt16)IhtModbusParamDyn.eIdxCmdExec.Switch)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    override protected UInt16 GetStartAddr(IhtModbusData ihtModbusData)
    {
      return ihtModbusData.GetAddrInfo_CmdExec().u16StartAddr;
    }

    /// <summary>
    /// 
    /// </summary>
    private UInt16 GetRegister(int _slaveId)
    {
      if (!registers.ContainsKey(_slaveId))
      {
        registers.Add(_slaveId, 0);
      }
      return registers[_slaveId];
    }

    /// <summary>
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// </summary>
    private async Task<UInt16> SetAsync(int slaveId, eCmdIdx eCmdIdx, eCmdBit eCmdBit, ArrayList SlaveIds)
    {
      if (slaveId == (int)IhtModbusCommunic.SlaveId.Id_Broadcast)
      {
        if (SlaveIds != null)
        {
          foreach (int _SlaveId in SlaveIds)
          {
            SetBit(_SlaveId, eCmdBit);
          }
        }
        await WriteWithOffsAsync(slaveId, (UInt16)eCmdBit, (UInt16)IhtModbusParamDyn.eIdxCmdExec.SwitchSet).ConfigureAwait(false);
#if DEBUG
        string msg = String.Format("IhtModbusCmdExecSwitch.Set: SlaveId={0}, CmdBit{1}", slaveId, eCmdIdx.ToString());
        Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,FFF") + " " + msg);
#endif
      }
      else
      {
        UInt16 register = SetBit(slaveId, eCmdBit);
        await WriteAsync(slaveId, register).ConfigureAwait(false);
#if DEBUG
        string msg = String.Format("IhtModbusCmdExecSwitch.Set: SlaveId={0}, CmdBit{1}", slaveId, eCmdIdx.ToString());
        Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,FFF") + " " + msg);
#endif
        return register;
      }
      return GetRegister(slaveId);
    }

    /// <summary>
    /// 
    /// </summary>
    private async Task<UInt16> ClrAsync(int slaveId, eCmdIdx eCmdIdx, eCmdBit eCmdBit, ArrayList SlaveIds)
    {
      UInt16 register = ClrBit(slaveId, eCmdBit);
      if (slaveId == (int)IhtModbusCommunic.SlaveId.Id_Broadcast && SlaveIds != null)
      {
        foreach (int _SlaveId in SlaveIds)
        {
          ClrBit(_SlaveId, eCmdBit);
        }
      }

      if (slaveId == (int)IhtModbusCommunic.SlaveId.Id_Broadcast)
      {
        await WriteWithOffsAsync(slaveId, (UInt16)eCmdBit, (UInt16)IhtModbusParamDyn.eIdxCmdExec.SwitchClr).ConfigureAwait(false);
        #if DEBUG
        string msg = String.Format("IhtModbusCmdExecSwitch.Clr: SlaveId={0}, CmdBit{1}", slaveId, eCmdIdx.ToString());
        Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,FFF") + " " + msg);
        #endif
      }
      else
      {
        await WriteAsync(slaveId, register).ConfigureAwait(false);
        #if DEBUG
        string msg = String.Format("IhtModbusCmdExecSwitch.Clr: SlaveId={0}, CmdBit{1}", slaveId, eCmdIdx.ToString());
        Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,FFF") + " " + msg);
        #endif
        return register;
      }
      return GetRegister(slaveId);
    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdateRegister(int _slaveId, UInt16 register)
    {
      if (!registers.ContainsKey(_slaveId))
      {
        registers.Add(_slaveId, register);
      }
      else
      {
        registers[_slaveId] = register;
      }
    }

    public async Task<UInt16> LockPressureOutputAsync(int slaveId, ArrayList SlaveIds=null)
    {
      return await SetAsync(slaveId, eCmdIdx.LockPressureOutput, eCmdBit.LockPressureOutput, SlaveIds).ConfigureAwait(false);
    }
    public async Task<UInt16> UnlockPressureOutputAsync(int slaveId, ArrayList SlaveIds = null)
    {
      return await ClrAsync(slaveId, eCmdIdx.LockPressureOutput, eCmdBit.LockPressureOutput, SlaveIds).ConfigureAwait(false);
    }

    public async Task<UInt16> EnableRetractPosAtProcessEndAsync(int slaveId, ArrayList SlaveIds = null)
    {
      return await SetAsync(slaveId, eCmdIdx.RetractPosAtProcessEnd, eCmdBit.RetractPosAtProcessEnd, SlaveIds).ConfigureAwait(false);
    }
    public async Task<UInt16> DisableRetractPosAtProcessEndAsync(int slaveId, ArrayList SlaveIds = null)
    {
      return await ClrAsync(slaveId, eCmdIdx.RetractPosAtProcessEnd, eCmdBit.RetractPosAtProcessEnd, SlaveIds).ConfigureAwait(false);
    }

    public async Task<UInt16> SetClearanceControlOffAsync(int slaveId, ArrayList SlaveIds = null)
    {
      return await SetAsync(slaveId, eCmdIdx.ClearanceControlOff, eCmdBit.ClearanceControlOff, SlaveIds).ConfigureAwait(false);
    }
    public async Task<UInt16> ClrClearanceControlOffAsync(int slaveId, ArrayList SlaveIds = null)
    {
      return await ClrAsync(slaveId, eCmdIdx.ClearanceControlOff, eCmdBit.ClearanceControlOff, SlaveIds).ConfigureAwait(false);
    }

    public async Task<UInt16> SetFlameOnAtProcessEndAsync(int slaveId, ArrayList SlaveIds = null)
    {
      return await SetAsync(slaveId, eCmdIdx.FlameOnAtProcessEnd, eCmdBit.FlameOnAtProcessEnd, SlaveIds).ConfigureAwait(false);
    }
    public async Task<UInt16> ClrFlameOnAtProcessEndAsync(int slaveId, ArrayList SlaveIds = null)
    {
      return await ClrAsync(slaveId, eCmdIdx.FlameOnAtProcessEnd, eCmdBit.FlameOnAtProcessEnd, SlaveIds).ConfigureAwait(false);
    }

    public async Task<UInt16> SetClearenceCtrlManualAsync(int slaveId, ArrayList SlaveIds = null)
    {
      return await SetAsync(slaveId, eCmdIdx.ClearanceControlManual, eCmdBit.ClearanceControlManual, SlaveIds).ConfigureAwait(false);
    }
    public async Task<UInt16> ClrClearenceCtrlManualAsync(int slaveId, ArrayList SlaveIds = null)
    {
      return await ClrAsync(slaveId, eCmdIdx.ClearanceControlManual, eCmdBit.ClearanceControlManual, SlaveIds).ConfigureAwait(false);
    }

    public async Task<UInt16> SetTorchOffAsync(int slaveId, ArrayList SlaveIds = null)
    {
      return await SetAsync(slaveId, eCmdIdx.TorchOff, eCmdBit.TorchOff, SlaveIds).ConfigureAwait(false);
    }
    public async Task<UInt16> ClrTorchOffAsync(int slaveId, ArrayList SlaveIds = null)
    {
      return await ClrAsync(slaveId, eCmdIdx.TorchOff, eCmdBit.TorchOff, SlaveIds).ConfigureAwait(false);
    }
  }

}
