using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharedComponents.IhtModbusTable
{
    internal class IhtModbusTableBase
    {
        private SemaphoreSlim mutexTable = new SemaphoreSlim(1);

        protected IhtModbusCommunic ihtModbusCommunic = null;
        protected IhtModbusParamDyn.eIdxTable eIdxTable;
        protected List<string> tableDataText;
        protected List<UInt16> tableDataValue;

        static public bool IsSimulation { get; set; } = false;

        internal IhtModbusTableBase(IhtModbusCommunic _ihtModbusCommunic, IhtModbusParamDyn.eIdxTable _eIdxTableData)
        {
            this.ihtModbusCommunic = _ihtModbusCommunic;
            this.eIdxTable = _eIdxTableData;
            tableDataText = new List<string>();
            tableDataValue = new List<UInt16>();
        }

        /// <summary>
        /// Liste der ausgelesene Text-Daten
        /// </summary>
        internal List<string> GetListText()
        {
#if false
      List<string> list = new List<string>();
      list.AddRange(tableDataText);
      return list;
#else
            return tableDataText;
#endif
        }

        /// <summary>
        /// Liste der ausgelesene Werte-Daten
        /// </summary>
        internal List<UInt16> GetListValue()
        {
#if false
      List<UInt16> list = new List<UInt16>();
      list.AddRange(tableDataValue);
      return list;
#else
            return tableDataValue;
#endif
        }


        /// <summary>
        /// Tabelle mit Texten auslesen
        /// </summary>
        internal async Task<bool> Read_TableTextAsync(IhtModbusData ihtModbusData)
        {
            if (IsSimulation)
            {
                return true;
            }

            // Bereichsüberprüfung
            int addrInfosLength = ihtModbusData.GetAddrInfos().Length;
            int tableDataLength = ihtModbusData.GetAddrInfo_TableData().u16AddrNumber;
            int dataLength = ihtModbusData.GetAddrInfo_Data().u16AddrNumber;

            if (addrInfosLength < (int)IhtModbusAddrAreas.eIdxAddrInfo.TableData
                || addrInfosLength < (int)IhtModbusAddrAreas.eIdxAddrInfo.Data
                || (int)eIdxTable >= tableDataLength
                || (int)IhtModbusParamDyn.eIdxData.DataIdx >= dataLength
                )
            {
                return false;
            }

            await mutexTable.WaitAsync().ConfigureAwait(false);

            IhtModbusAddrInfo addrInfo = ihtModbusData.GetAddrInfo_TableData();
            UInt16 addressNextTblIdx = (UInt16)(addrInfo.u16StartAddr + eIdxTable);

            addrInfo = ihtModbusData.GetAddrInfo_Data();
            UInt16 addressDataLength = (UInt16)(addrInfo.u16StartAddr + IhtModbusParamDyn.eIdxData.DataLength);
            UInt16 addressDataStart = (UInt16)(addrInfo.u16StartAddr + IhtModbusParamDyn.eIdxData.Data00);

            tableDataText.Clear();

            // Anzahl Tabellen-Einträge auslesen
            IhtModbusResult ihtModbusResult = new IhtModbusResult();
            int tblLength = await ihtModbusCommunic.ReadAsync(ihtModbusData.SlaveId, addressNextTblIdx, ihtModbusResult).ConfigureAwait(false);
            tblLength = (tblLength > (int)IhtModbusParamDyn.eIdxData.DataMaxLength) ? (int)IhtModbusParamDyn.eIdxData.DataMaxLength : tblLength;

            // Breichsüberprüfung
            if (tblLength == 0)
            {
                ihtModbusResult.Result = false;
            }

            int tblCnt = 0;
            // Alle Tabellen-Einträge auslesen
            for (; tblCnt < tblLength && ihtModbusResult.Result; tblCnt++)
            {
                // Tabellen-Eintraege nacheinander abholen. Auf nächsten Tabelleneintrag zeigen
                ihtModbusResult.Result = await ihtModbusCommunic.WriteAsync(ihtModbusData.SlaveId, addressNextTblIdx, (UInt16)tblCnt).ConfigureAwait(false);

                // Anzahl Daten fuer Tabellen-Eintrag auslesen
                UInt16 u16DataLength = 0;
                if (ihtModbusResult.Result == true)
                {
                    u16DataLength = await ihtModbusCommunic.ReadAsync(ihtModbusData.SlaveId, addressDataLength, ihtModbusResult).ConfigureAwait(false);
                }

                // Daten fuer Tabellen-Eintrag auslesen
                if (ihtModbusResult.Result == true)
                {
                    UInt16[] u16Datas = await ihtModbusCommunic.ReadAsync(ihtModbusData.SlaveId, addressDataStart, u16DataLength, ihtModbusResult).ConfigureAwait(false);
                    // Daten aus Puffer entnehmem
                    if (ihtModbusResult.Result == true)
                    {
                        List<char> listChar = new List<char>();
                        string RowText = "";
                        foreach (UInt16 u16Data in u16Datas)
                        {
                            char c1 = (char)(u16Data & 0x00FF);
                            char c2 = (char)(u16Data >> 8 & 0x00FF);
                            if (c1 != '\0')
                            {
                                listChar.Add(c1);
                                if (c2 != '\0')
                                {
                                    listChar.Add(c2);
                                }
                            }
                        }
                        RowText = String.Concat(listChar);
                        tableDataText.Add(RowText);
                    }
                }
            }
            mutexTable.Release();
            return ihtModbusResult.Result;
        }

        /// <summary>
        /// Tabelle mit Werten auslesen
        /// </summary>
        internal async Task<bool> Read_TableValueAsync(IhtModbusData ihtModbusData, int dataOffsetAddr = 0, int dataCounts = (int)IhtModbusParamDyn.eIdxData.DataMaxLength)
        {
            if (IsSimulation)
            {
                return true;
            }

            // Bereichsüberprüfung
            int addrInfosLength = ihtModbusData.GetAddrInfos().Length;
            int tableDataLength = ihtModbusData.GetAddrInfo_TableData().u16AddrNumber;
            int dataLength = ihtModbusData.GetAddrInfo_Data().u16AddrNumber;

            if (addrInfosLength < (int)IhtModbusAddrAreas.eIdxAddrInfo.TableData
                || addrInfosLength < (int)IhtModbusAddrAreas.eIdxAddrInfo.Data
                || (int)eIdxTable >= tableDataLength
                || (int)IhtModbusParamDyn.eIdxData.DataIdx >= dataLength
                )
            {
                return false;
            }

            await mutexTable.WaitAsync().ConfigureAwait(false);

            IhtModbusAddrInfo addrInfo = ihtModbusData.GetAddrInfo_TableData();
            UInt16 addressTblIdx = (UInt16)(addrInfo.u16StartAddr + eIdxTable);

            addrInfo = ihtModbusData.GetAddrInfo_Data();
            UInt16 addressDataIdx = (UInt16)(addrInfo.u16StartAddr + IhtModbusParamDyn.eIdxData.DataIdx);
            UInt16 addressDataLength = (UInt16)(addrInfo.u16StartAddr + IhtModbusParamDyn.eIdxData.DataLength);
            UInt16 addressDataStart = (UInt16)(addrInfo.u16StartAddr + IhtModbusParamDyn.eIdxData.Data00);

            tableDataValue.Clear();

            // Anzahl maximal verfügbarer Tabellen-Einträge auslesen
            IhtModbusResult ihtModbusResult = new IhtModbusResult();
            int tblLength = await ihtModbusCommunic.ReadAsync(ihtModbusData.SlaveId, addressTblIdx, ihtModbusResult).ConfigureAwait(false);
            tblLength = (tblLength > (int)IhtModbusParamDyn.eIdxData.DataMaxLength) ? (int)IhtModbusParamDyn.eIdxData.DataMaxLength : tblLength;

            // Bereichsüberprüfung
            dataOffsetAddr = (dataOffsetAddr > tblLength) ? tblLength - 1 : dataOffsetAddr;
            dataCounts = ((dataCounts + dataOffsetAddr) > tblLength) ? (tblLength - dataOffsetAddr) : dataCounts;

            // Tabelle ab OffsetAdresse und Anzahl befüllen lassen
            UInt16 u16Data = (UInt16)((dataOffsetAddr & 0x00FF) + ((dataCounts & 0x00FF) << 8));// ==> LowByte: OffsAddr, HighByte: Anzahl
            ihtModbusResult.Result = ihtModbusResult.Result && await ihtModbusCommunic.WriteAsync(ihtModbusData.SlaveId, addressTblIdx, u16Data).ConfigureAwait(false);


            UInt16 u16DataLength = 0;
            if (ihtModbusResult.Result)
            {
                // Zurück gelieferte Anzahl Daten auslesen
                u16DataLength = await ihtModbusCommunic.ReadAsync(ihtModbusData.SlaveId, addressDataLength, ihtModbusResult).ConfigureAwait(false);
            }

            // Bereichsüberprüfung
            if (u16DataLength == 0)
            {
                ihtModbusResult.Result = false;
            }

            // Index im Geraet zuruecksetzen: -> Nicht notwendig, FW wurde dahingehend geändert, dass nach dem Befüllen, der Index auf 0 gesetzt wird. Somit wird ein Schreibzugriff eingespart.
            //ihtModbusResult.Result = ihtModbusResult.Result && await ihtModbusCommunic.WriteAsync(ihtModbusData.SlaveId, addressDataIdx, 0).ConfigureAwait(false);

            UInt16[] u16Datas = null;
            if (ihtModbusResult.Result)
            {
                // Daten auslesen
                u16Datas = await ihtModbusCommunic.ReadAsync(ihtModbusData.SlaveId, addressDataStart, u16DataLength, ihtModbusResult).ConfigureAwait(false);
            }

            if (ihtModbusResult.Result)
            {
                // Ausgelesene Daten übernehmen
                tableDataValue.AddRange(u16Datas);
            }

            mutexTable.Release();

            return ihtModbusResult.Result;
        }
    }

}
