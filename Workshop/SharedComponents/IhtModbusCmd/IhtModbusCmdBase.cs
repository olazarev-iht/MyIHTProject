using SharedComponents.IhtModbus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtModbusCmd
{
  public abstract class IhtModbusCmdBase
  {
    protected UInt16 u16OffsAddr = 0;
    protected UInt16 u16Register = 0;
    protected IhtModbusCommunic ihtModbusCommunic = null;

    public IhtModbusCmdBase(IhtModbusCommunic _ihtModbusCommunic, UInt16 _u16OffsAddr)
    {
      this.ihtModbusCommunic = _ihtModbusCommunic;
      this.u16OffsAddr = _u16OffsAddr;
    }

    abstract protected UInt16 GetStartAddr(IhtModbusData ihtModbusData);

    protected void ClrRegister() { u16Register = 0; }

    protected async Task WriteWithOffsAsync(int slaveId, UInt16 u16Data, UInt16 u16Offs)
    {
      if (ihtModbusCommunic != null)
      {
        IhtModbusData ihtModbusData = ihtModbusCommunic.GetData(slaveId);
        if (ihtModbusData != null)
        {
          UInt16 u16StartAddr = (UInt16)(GetStartAddr(ihtModbusData) + u16Offs);
          await ihtModbusCommunic.WriteAsync(slaveId, u16StartAddr, u16Data).ConfigureAwait(false);
        }
      }
    }

    protected async Task WriteAsync(int slaveId)
    {
      if (ihtModbusCommunic != null)
      {
        IhtModbusData ihtModbusData = ihtModbusCommunic.GetData(slaveId);
        if (ihtModbusData != null)
        {
          UInt16 u16StartAddr = (UInt16)(GetStartAddr(ihtModbusData) + u16OffsAddr);
          await ihtModbusCommunic.WriteAsync(slaveId, u16StartAddr, u16Register).ConfigureAwait(false);
        }
      }
    }

    protected async Task WriteAsync(int slaveId, UInt16 u16Data)
    {
      if (ihtModbusCommunic != null)
      {
        IhtModbusData ihtModbusData = ihtModbusCommunic.GetData(slaveId);
        if (ihtModbusData != null)
        {
          UInt16 u16StartAddr = (UInt16)(GetStartAddr(ihtModbusData) + u16OffsAddr);
          await ihtModbusCommunic.WriteAsync(slaveId, u16StartAddr, u16Data).ConfigureAwait(false);
        }
      }
    }

    protected async Task WriteAsync(int slaveId, UInt16 u16Addr, UInt16 u16Data)
    {
      if (ihtModbusCommunic != null)
      {
        IhtModbusData ihtModbusData = ihtModbusCommunic.GetData(slaveId);
        if (ihtModbusData != null)
        {
          await ihtModbusCommunic.WriteAsync(slaveId, u16Addr, u16Data).ConfigureAwait(false);
        }
      }
    }

  }
}
