﻿using SharedComponents.IhtDev;
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
  public class IhtModbusCmdParam : IhtModbusCmdBase
  {
    protected enum eSema
    {
      Technology,
      Config,
      Password,
      Process,
      Service,
      SetupExec,
      CmdExec,

      Length,
    }

    private Dictionary<int, ArrayList> slavesSemaphores = new Dictionary<int, ArrayList>();

    public IhtModbusCmdParam(IhtModbusCommunic _ihtModbusCommunic)
      : base(_ihtModbusCommunic, 0)
    {
    }

    override protected UInt16 GetStartAddr(IhtModbusData ihtModbusData)
    {
      return 0;
    }

    /// <summary>
    /// Daten für IhtModbusParamDyn.eIdxTechnology schreiben
    /// </summary>
    public async Task<bool> WriteAsync(int slaveId, IhtModbusParamDyn.eIdxTechnology eIdx, UInt16 u16Data, bool updateRegister = true)
    {
      bool _result = await WriteAsync(slaveId, (UInt16)eIdx, u16Data, eSema.Technology, IhtModbusAddrAreas.eIdxAddrInfo.TechnologyDyn).ConfigureAwait(false);
      if (_result && updateRegister)
      {
        if (slaveId == (int)IhtModbusCommunic.SlaveId.Id_Broadcast)
        {
          ArrayList _modbusDatas = IhtDevices.GetIhtDevices().GetModbusDatas();
          foreach (IhtModbusData _modbusData in _modbusDatas)
          {
            _modbusData.SetValue(eIdx, u16Data);
          }
          IhtDevices.GetIhtDevices().UpdateParamDynTechnologys();
        }
        else
        {
          ihtModbusCommunic.GetData(slaveId).SetValue(eIdx, u16Data);
          IhtDevices.GetIhtDevices().UpdateParamDynTechnology(slaveId);
        }
      }
      return _result;
    }

    /// <summary>
    /// Daten für IhtModbusParamDyn.eIdxConfig schreiben
    /// </summary>
    public async Task<bool> WriteAsync(int slaveId, IhtModbusParamDyn.eIdxConfig eIdx, UInt16 u16Data, bool updateRegister = true)
    {
      bool _result = await WriteAsync(slaveId, (UInt16)eIdx, u16Data, eSema.Config, IhtModbusAddrAreas.eIdxAddrInfo.ConfigDyn).ConfigureAwait(false);
      if (_result && updateRegister)
      {
        if (slaveId == (int)IhtModbusCommunic.SlaveId.Id_Broadcast)
        {
          ArrayList _modbusDatas = IhtDevices.GetIhtDevices().GetModbusDatas();
          foreach (IhtModbusData _modbusData in _modbusDatas)
          {
            _modbusData.SetValue(eIdx, u16Data);
          }
        }
        else
        {
          ihtModbusCommunic.GetData(slaveId).SetValue(eIdx, u16Data);
        }
      }
      return _result;
    }

    /// <summary>
    /// Daten für IhtModbusParamDyn.eIdxProcess schreiben
    /// </summary>
    public async Task<bool> WriteAsync(int slaveId, IhtModbusParamDyn.eIdxProcess eIdx, UInt16 u16Data, bool updateRegister = true)
    {
      bool _result = await WriteAsync(slaveId, (UInt16)eIdx, u16Data, eSema.Process, IhtModbusAddrAreas.eIdxAddrInfo.ProcessDyn).ConfigureAwait(false);
      if (_result && updateRegister)
      {
        if (slaveId == (int)IhtModbusCommunic.SlaveId.Id_Broadcast)
        {
          ArrayList _modbusDatas = IhtDevices.GetIhtDevices().GetModbusDatas();
          foreach (IhtModbusData _modbusData in _modbusDatas)
          {
            _modbusData.SetValue(eIdx, u16Data);
          }
        }
        else
        {
          ihtModbusCommunic.GetData(slaveId).SetValue(eIdx, u16Data);
        }
      }
      return _result;
    }

    /// <summary>
    /// Daten für IhtModbusParamDyn.eIdxService schreiben
    /// </summary>
    public async Task<bool> WriteAsync(int slaveId, IhtModbusParamDyn.eIdxService eIdx, UInt16 u16Data, bool updateRegister = true)
    {
      bool _result = await WriteAsync(slaveId, (UInt16)eIdx, u16Data, eSema.Service, IhtModbusAddrAreas.eIdxAddrInfo.ServiceDyn).ConfigureAwait(false);
      if (_result && updateRegister)
      {
        //ihtModbusCommunic.GetData(slaveId).SetValue(eIdx, u16Data);
        if (slaveId == (int)IhtModbusCommunic.SlaveId.Id_Broadcast)
        {
          ArrayList _modbusDatas = IhtDevices.GetIhtDevices().GetModbusDatas();
          foreach (IhtModbusData _modbusData in _modbusDatas)
          {
            _modbusData.SetValue(eIdx, u16Data);
          }
        }
        else
        {
          ihtModbusCommunic.GetData(slaveId).SetValue(eIdx, u16Data);
        }
      }
      return _result;
    }

    /// <summary>
    /// Daten für IhtModbusParamDyn.eIdxSetupExec schreiben
    /// </summary>
    public async Task<bool> WriteAsync(int slaveId, IhtModbusParamDyn.eIdxSetupExec eIdx, UInt16 u16Data, bool updateRegister = true)
    {
      bool _result = await WriteAsync(slaveId, (UInt16)eIdx, u16Data, eSema.SetupExec, IhtModbusAddrAreas.eIdxAddrInfo.SetupExec).ConfigureAwait(false);
      if (_result && updateRegister)
      {
        if (slaveId == (int)IhtModbusCommunic.SlaveId.Id_Broadcast)
        {
          ArrayList _modbusDatas = IhtDevices.GetIhtDevices().GetModbusDatas();
          foreach (IhtModbusData _modbusData in _modbusDatas)
          {
            _modbusData.SetValue(eIdx, u16Data);
          }
        }
        else
        {
          ihtModbusCommunic.GetData(slaveId).SetValue(eIdx, u16Data);
        }
      }
      return _result;
    }

    /// <summary>
    /// Daten für IhtModbusParamDyn.eIdxCmdExec schreiben
    /// </summary>
    internal async Task<bool> WriteAsync(int slaveId, IhtModbusParamDyn.eIdxCmdExec eIdx, UInt16 u16Data, bool updateRegister = true)
    {
      bool _result = await WriteAsync(slaveId, (UInt16)eIdx, u16Data, eSema.CmdExec, IhtModbusAddrAreas.eIdxAddrInfo.CmdExec).ConfigureAwait(false);
      if (_result && updateRegister)
      {
        if (slaveId == (int)IhtModbusCommunic.SlaveId.Id_Broadcast)
        {
          ArrayList _modbusDatas = IhtDevices.GetIhtDevices().GetModbusDatas();
          foreach (IhtModbusData _modbusData in _modbusDatas)
          {
            _modbusData.SetValue(eIdx, u16Data);
          }
        }
        else
        {
          ihtModbusCommunic.GetData(slaveId).SetValue(eIdx, u16Data);
        }
      }
      return _result;
    }

    /// <summary>
    /// Daten auf Adresse schreiben
    /// </summary>
    internal async Task<bool> WriteAsync(int slaveId, IhtModbusData.ePassword _password, UInt16 u16PasswordValue=0, bool updateRegister = true)
    {
      UInt16 u16Data = 0;
      switch (_password)
      {
        case IhtModbusData.ePassword.Level_0    : u16Data = (UInt16)IhtModbusData.ePasswordCode.Level_0; break;
        case IhtModbusData.ePassword.Level_1    : u16Data = (UInt16)IhtModbusData.ePasswordCode.Level_1; break;
        case IhtModbusData.ePassword.Level_2    : u16Data = (UInt16)IhtModbusData.ePasswordCode.Level_2; break;
        case IhtModbusData.ePassword.Level_Value: u16Data = u16PasswordValue; break;
      }
      bool _result = await WriteAsync(slaveId, (UInt16)IhtModbusData.eAddress.PasswordAddress, u16Data, eSema.Password).ConfigureAwait(false);
      if (_result && updateRegister)
      {
        ihtModbusCommunic.GetData(slaveId).UpdatePasswordRegister(u16Data);
      }
      return _result;
    }

    /// <summary>
    /// Daten schreiben
    /// </summary>
    private async Task<bool> WriteAsync(int slaveId, ushort u16OffsAddr, ushort u16Data, eSema _eSema, IhtModbusAddrAreas.eIdxAddrInfo eIdxAddrInfo)
    {
      IhtModbusData _ihtModbusData = ihtModbusCommunic.GetData(slaveId);
      if (_ihtModbusData != null)
      {
        UInt16 u16StartAddr  = (UInt16)_ihtModbusData.GetAddrInfo(eIdxAddrInfo).u16StartAddr;
                u16StartAddr += u16OffsAddr;
                await ihtModbusCommunic.WriteAsync(slaveId, u16StartAddr, u16Data/*, sema*/).ConfigureAwait(false);
#if DEBUG
        string msg = String.Format("IhtModbusCmdParam.Write: SlaveId={0}, Addr={1}", slaveId, u16StartAddr);
        Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,FFF") + " " + msg);
#endif
        return true;
      }
      return false;
    }

    /// <summary>
    /// Daten schreiben
    /// </summary>
    private async Task<bool> WriteAsync(int slaveId, ushort u16Addr, ushort u16Data, eSema _eSema)
    {
      IhtModbusData _ihtModbusData = ihtModbusCommunic.GetData(slaveId);
      if (_ihtModbusData != null)
      {
        await ihtModbusCommunic.WriteAsync(slaveId, u16Addr, u16Data/*, sema*/).ConfigureAwait(false);
#if DEBUG
        string msg = String.Format("IhtModbusCmdParam.Write: SlaveId={0}, Addr={1}", slaveId, u16Addr);
        Debug.Print(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,FFF") + " " + msg);
#endif
        return true;
      }
      return false;
    }

  }
}