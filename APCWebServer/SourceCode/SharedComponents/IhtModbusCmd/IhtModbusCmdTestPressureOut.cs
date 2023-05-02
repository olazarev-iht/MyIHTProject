using SharedComponents.IhtModbus;
using SharedComponents.IhtModbusCmd;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharedComponents.IhtModbusCmd
{
  class CmdTestPressureOutData
  {
    public UInt16 u16Register;
    public bool IsHeartbeatActive;
  }

  public class IhtModbusCmdTestPressureOut : IhtModbusCmdBase
  {
    public enum eCmdBit
    {
      HeatO2  = 0x0001,
      CutO2   = 0x0002,
      FuelGas = 0x0004
    }

    private enum Heartbeat
    {
      StartDelayTime_ms = 500
    }

    private IhtModbusCmdHeartbeat ihtModbusCmdHeartbeat;
    private Dictionary<int, CmdTestPressureOutData> cmdTestPressureOutDatas = new Dictionary<int, CmdTestPressureOutData>();

    public IhtModbusCmdTestPressureOut(IhtModbusCommunic _ihtModbusCommunic)
      : base(_ihtModbusCommunic, (UInt16)IhtModbusParamDyn.eIdxSetupExec.TestPressureOut)
    {
      ihtModbusCmdHeartbeat = new IhtModbusCmdHeartbeat(this.SetHeartbeatAsync, 250);
    }

    override protected UInt16 GetStartAddr(IhtModbusData ihtModbusData)
    {
      return ihtModbusData.GetAddrInfo_SetupExec().u16StartAddr;
    }

    private UInt16 SetRegister(int _slaveId, eCmdBit eCmdBit)
    {
      CmdTestPressureOutData _cmdTestPressureOutData = null;
      if (!cmdTestPressureOutDatas.ContainsKey(_slaveId))
      {
        _cmdTestPressureOutData = new CmdTestPressureOutData();
        _cmdTestPressureOutData.u16Register = (UInt16)eCmdBit;
        cmdTestPressureOutDatas.Add(_slaveId, _cmdTestPressureOutData);
      }
      else
      {
        _cmdTestPressureOutData = cmdTestPressureOutDatas[_slaveId];
        _cmdTestPressureOutData.u16Register |= (UInt16)eCmdBit;
      }
      return _cmdTestPressureOutData.u16Register;
    }

    private UInt16 ClrRegister(int _slaveId, eCmdBit eCmdBit)
    {
      CmdTestPressureOutData _cmdTestPressureOutData = null;
      if (!cmdTestPressureOutDatas.ContainsKey(_slaveId))
      {
        _cmdTestPressureOutData = new CmdTestPressureOutData();
        _cmdTestPressureOutData.u16Register = 0;
        cmdTestPressureOutDatas.Add(_slaveId, _cmdTestPressureOutData);
      }
      else
      {
        UInt16 bit = (UInt16)eCmdBit;
        _cmdTestPressureOutData = cmdTestPressureOutDatas[_slaveId];
        _cmdTestPressureOutData.u16Register &= (UInt16)~bit;
      }
      return _cmdTestPressureOutData.u16Register;
    }

    SemaphoreSlim mutex = new SemaphoreSlim(1);
    private async Task<UInt16> SetValueAsync(int _slaveId, eCmdBit eCmdBit)
    {
      await mutex.WaitAsync().ConfigureAwait(false);
      UInt16 register = SetRegister(_slaveId, eCmdBit);
      CmdTestPressureOutData _cmdTestPressureOutData = cmdTestPressureOutDatas[_slaveId];

      if (_cmdTestPressureOutData.IsHeartbeatActive == false)
      {
        await ihtModbusCmdHeartbeat.StartHeartbeatAsync(_slaveId).ConfigureAwait(false);
        await Task.Delay((int)Heartbeat.StartDelayTime_ms).ConfigureAwait(false);
        _cmdTestPressureOutData.IsHeartbeatActive = true;
      }
      mutex.Release();
      return register;
    }

    private async Task<UInt16> ClrValueasync(int _slaveId, eCmdBit eCmdBit)
    {
      await mutex.WaitAsync().ConfigureAwait(false);
      UInt16 register = ClrRegister(_slaveId, eCmdBit);
      CmdTestPressureOutData _cmdTestPressureOutData = cmdTestPressureOutDatas[_slaveId];

      if (register == 0 && _cmdTestPressureOutData.IsHeartbeatActive == true)
      {
        await ihtModbusCmdHeartbeat.StopHeartbeatAsync(_slaveId).ConfigureAwait(false);
        _cmdTestPressureOutData.IsHeartbeatActive = false;
      }

      mutex.Release();
      return register;
    }

    private async Task SetAsync(int slaveId, eCmdBit eCmdBit)
    {
      UInt16 register = await SetValueAsync(slaveId, eCmdBit).ConfigureAwait(false);
      await WriteAsync(slaveId, register).ConfigureAwait(false);
#if DEBUG
      string msg = String.Format("IhtModbusCmdTestPressureOut.Set: SlaveId={0}, CmdBit={1}", slaveId, eCmdBit.ToString());
      Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,FFF") + " " + msg);
#endif
    }

    private async Task ClrAsync(int slaveId, eCmdBit eCmdBit)
    {
      UInt16 register = await ClrValueasync(slaveId, eCmdBit).ConfigureAwait(false);
      await WriteAsync(slaveId, register).ConfigureAwait(false);
#if DEBUG
      string msg = String.Format("IhtModbusCmdTestPressureOut.Clr: SlaveId={0}, CmdBit={1}", slaveId, eCmdBit.ToString());
      Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,FFF") + " " + msg);
#endif
    }

    public async Task SetPressureOutHeatO2Async(int slaveId)
    {
      await SetAsync(slaveId, eCmdBit.HeatO2).ConfigureAwait(false);
    }
    public async Task ClrPressureOutHeatO2Async(int slaveId)
    {
      await ClrAsync(slaveId, eCmdBit.HeatO2).ConfigureAwait(false);
    }

    public async Task SetPressureOutCutO2Async(int slaveId)
    {
      await SetAsync(slaveId, eCmdBit.CutO2).ConfigureAwait(false);
    }
    public async Task ClrPressureOutCutO2Async(int slaveId)
    {
      await ClrAsync(slaveId, eCmdBit.CutO2).ConfigureAwait(false);
    }

    public async Task SetPressureOutFuelGasAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdBit.FuelGas).ConfigureAwait(false);
    }
    public async Task ClrPressureOutFuelGasAsync(int slaveId)
    {
      await ClrAsync(slaveId, eCmdBit.FuelGas).ConfigureAwait(false);
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
