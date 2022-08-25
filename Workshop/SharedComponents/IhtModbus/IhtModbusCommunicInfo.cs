using System;
using System.Threading.Tasks;
using System.Windows;
using System.IO.Ports;
using System.Net.Sockets;
//using log4net;
using Modbus.Device;
using System.Collections;
using SharedComponents;
using SharedComponents.Helpers;
using SharedComponents.IhtModbusCmd;
using System.Threading;
using SharedComponents.IhtMsg;
using SharedComponents.IhtData;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbusTable;
using SharedComponents.Cultures;
using System.Collections.Generic;
using SharedComponents.Services.APCHardwareMockDBServices;
using SharedComponents.StatusInfo;

namespace SharedComponents.IhtModbus
{
    public class IhtModbusCommunicInfo
    {

        public IhtDevices _ihtDevices;
        public readonly IAPCSimulationDataMockDBService _apcSimulationDataMockDBService;

        // TODO: remove when we will read from command line 
        static bool IsSimulation = true;

        private IModbusMaster modbusMaster = null;

        public IhtModbusCommunicInfo(
            IhtDevices ihtDevices, 
            IAPCSimulationDataMockDBService apcSimulationDataMockDBService)
        {
            _ihtDevices = ihtDevices;
            _apcSimulationDataMockDBService = apcSimulationDataMockDBService;
        }

        private async Task<object> Rd_AddrPreAreasAsync(int slaveId, IhtModbusResult ihtModbusResult)
        {
            //Result = IsSimulation;
            // Ab StartAdresse 10 Eintraege lesen
            ushort startAddress = (ushort)IhtModbusData.eAddress.StartAddress;
            ushort numRegisters = (ushort)IhtModbusData.eIdxAddr.StartDeviceInfo;
            // var values = await _apcSimulationDataMockDBService.ReadHoldingRegistersAsync((byte)slaveId, startAddress, numRegisters, ihtModbusResult).ConfigureAwait(false);
            var values = !IsSimulation ? await ReadHoldingRegistersAsync((byte)slaveId, startAddress, numRegisters, ihtModbusResult).ConfigureAwait(false)
                                       : await _apcSimulationDataMockDBService.ReadHoldingRegistersAsync((byte)slaveId, startAddress, numRegisters, ihtModbusResult).ConfigureAwait(false); ;
            return values;
        }

        public async Task ConnectAsync()
        {
            ArrayList slaveIds = _ihtDevices.GetVisibleSlaveIds();

            IhtModbusResult ihtModbusResult = new IhtModbusResult();

            foreach (int slaveId in slaveIds)
            {
                var values = await Rd_AddrPreAreasAsync(slaveId, ihtModbusResult).ConfigureAwait(false);

                IhtModbusData ihtModbusData = new IhtModbusData(slaveId, (ushort[])values, IsSimulation);

                // Adress-Bereiche auslesen
                ihtModbusResult.Result = ihtModbusResult.Result && (ihtModbusResult.Result = await _ihtDevices.Read_AddrAreasAsync(ihtModbusData).ConfigureAwait(false));
            
            }

        }

        private async Task<UInt16[]> ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numRegisters, IhtModbusResult ihtModbusResult)
        {
            return await ModbusMaster_ReadHoldingRegistersAsync(slaveAddress, startAddress, numRegisters, ihtModbusResult).ConfigureAwait(false);
        }

        private enum Communic { Delay_ms = 10 }
        SemaphoreSlim mutexModbusMaster = new SemaphoreSlim(1);

        private async Task<ushort[]> ModbusMaster_ReadHoldingRegistersAsync(byte slaveAddress, ushort startAddress, ushort numRegisters, IhtModbusResult ihtModbusResult)
        {
            ihtModbusResult.Result = false;
            await mutexModbusMaster.WaitAsync().ConfigureAwait(false);
            await Task.Delay((int)Communic.Delay_ms).ConfigureAwait(false);
            ushort[] datas = null;
            try
            {
                if (!IsSimulation)
                {
                    datas = modbusMaster.ReadHoldingRegisters(slaveAddress, startAddress, numRegisters);
                }
                else
                {
                    datas = await _apcSimulationDataMockDBService.ReadHoldingRegistersAsync(slaveAddress, startAddress, numRegisters);
                }
                ihtModbusResult.Result = true;
                _ihtDevices.ClrCommunicError((int)slaveAddress);
            }
            catch (Exception exc)
            {
                ihtModbusResult.Result = false;
                string txtSlaveId = CultureResources.GetString("_CultureSlaveId");
                string msg = String.Format("{0}={1}: {2}", txtSlaveId, slaveAddress.ToString(), exc.Message);
                // mainWndHlp.SetStatusMsg(IhtMsgLog.Info.Error, msg);
                _ihtDevices.SetCommunicError((int)slaveAddress);
            }
            finally
            {
                mutexModbusMaster.Release();
            }

            return datas;
        }

    }
}
