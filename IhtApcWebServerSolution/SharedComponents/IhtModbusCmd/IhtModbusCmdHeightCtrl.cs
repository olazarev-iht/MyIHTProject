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
  class CmdHeightCtrlData
  {
    public UInt16 u16Register;
    public bool   IsHeartbeatActive;
  }
  
  public class IhtModbusCmdHeightCtrl : IhtModbusCmdBase
  {
    public enum eCmdValue
    {
      Off = 0,
      HeightPreHeat,
      HeightPierce,
      HeightCut,
      HeightPierceRamp,
      HeightCutRamp,
      HeightTemper,
      HeightHeartbeat = 0x8000
    }

    private IhtModbusCmdHeartbeat ihtModbusCmdHeartbeat;
    private Dictionary<int, CmdHeightCtrlData> cmdHeightCtrlDatas = new Dictionary<int, CmdHeightCtrlData>();

    public IhtModbusCmdHeightCtrl(IhtModbusCommunic _ihtModbusCommunic)
      : base(_ihtModbusCommunic, (UInt16)IhtModbusParamDyn.eIdxCmdExec.HeightCtrl)
    {
      ihtModbusCmdHeartbeat = new IhtModbusCmdHeartbeat(this.SetHeartbeatAsync, 250);
    }

    override protected UInt16 GetStartAddr(IhtModbusData ihtModbusData)
    {
      return ihtModbusData.GetAddrInfo_CmdExec().u16StartAddr;
    }

    private UInt16 GetRegister(int _slaveId)
    {
      CmdHeightCtrlData _cmdHeightCtrlData = null;
      if (!cmdHeightCtrlDatas.ContainsKey(_slaveId))
      {
        _cmdHeightCtrlData = new CmdHeightCtrlData();
        cmdHeightCtrlDatas.Add(_slaveId, _cmdHeightCtrlData);
      }
      else
      {
        _cmdHeightCtrlData = cmdHeightCtrlDatas[_slaveId];
      }
      return _cmdHeightCtrlData.u16Register;
    }

    private UInt16 GetRegister(int _slaveId, eCmdValue eCmdValue)
    {
      CmdHeightCtrlData _cmdHeightCtrlData = null;
      if (!cmdHeightCtrlDatas.ContainsKey(_slaveId))
      {
        _cmdHeightCtrlData = new CmdHeightCtrlData();
        _cmdHeightCtrlData.u16Register = (UInt16)eCmdValue;
        cmdHeightCtrlDatas.Add(_slaveId, _cmdHeightCtrlData);
      }
      else
      {
        _cmdHeightCtrlData = cmdHeightCtrlDatas[_slaveId];
        _cmdHeightCtrlData.u16Register = (UInt16)eCmdValue;
      }
      return _cmdHeightCtrlData.u16Register;
    }

    SemaphoreSlim mutex = new SemaphoreSlim(1);
    private async Task<UInt16> SetValueAsync(int _slaveId, eCmdValue eCmdValue)
    {
      await mutex.WaitAsync().ConfigureAwait(false);
      if (_slaveId == (int)IhtModbusCommunic.SlaveId.Id_Broadcast)
      {
        await ihtModbusCmdHeartbeat.StopHeartbeatsAsync().ConfigureAwait(false);
        foreach (KeyValuePair<int, CmdHeightCtrlData> kvp in cmdHeightCtrlDatas)
        {
          CmdHeightCtrlData _data = kvp.Value;
          _data.IsHeartbeatActive = false;
          _data.u16Register = 0;
        }
        mutex.Release();
        return 0;
      }

      UInt16 register = GetRegister(_slaveId, eCmdValue);
      CmdHeightCtrlData _cmdHeightCtrlData = cmdHeightCtrlDatas[_slaveId];

      if (eCmdValue == eCmdValue.Off)
      {
        await ihtModbusCmdHeartbeat.StopHeartbeatAsync(_slaveId).ConfigureAwait(false);
        _cmdHeightCtrlData.IsHeartbeatActive = false;
      }
      else if (_cmdHeightCtrlData.IsHeartbeatActive == false)
      {
        await ihtModbusCmdHeartbeat.StartHeartbeatAsync(_slaveId).ConfigureAwait(false);
        _cmdHeightCtrlData.IsHeartbeatActive = true;
      }

      mutex.Release();
      return (eCmdValue == eCmdValue.Off) ? register : register |= (UInt16)eCmdValue.HeightHeartbeat;
    }

    private async Task SetAsync(int slaveId, eCmdValue eCmdValue)
    {
      UInt16 register = await SetValueAsync(slaveId, eCmdValue).ConfigureAwait(false);
      await WriteAsync(slaveId, register).ConfigureAwait(false);
#if DEBUG
      string msg = String.Format("IhtModbusCmdHeightCtrl.Set: SlaveId={0}, CmdValue={1}", slaveId, eCmdValue.ToString());
      Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,FFF") + " " + msg);
#endif
    }

    public async Task OffAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdValue.Off).ConfigureAwait(false);
    }

    public async Task PreHeatingAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdValue.HeightPreHeat).ConfigureAwait(false);
    }

    public async Task PiercingAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdValue.HeightPierce).ConfigureAwait(false);
    }

    public async Task CuttingAsync(int slaveId)
    {
      await SetAsync(slaveId, eCmdValue.HeightCut).ConfigureAwait(false);
    }

    private async Task SetHeartbeatAsync(int slaveId)
    {
      UInt16 register = GetRegister(slaveId);
      await WriteAsync(slaveId, register).ConfigureAwait(false);
    }
  }
}
