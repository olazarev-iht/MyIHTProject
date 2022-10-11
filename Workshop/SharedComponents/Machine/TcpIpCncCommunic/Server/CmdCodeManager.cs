using CutDataRepository.Utils;
using SharedComponents.CutDataRepository;
using SharedComponents.CutDataRepository.Utils;
using SharedComponents.Helpers;
using SharedComponents.IhtModbus;
using SharedComponents.IhtMsg;
using System.Diagnostics;
using System.Net.Sockets;

namespace SharedComponents.Machine.TcpIpCncCommunic.Server
{
  /// <summary>
  /// 
  /// </summary>
  class CmdCodeManager
  {
    public bool IsExecCmdConnectionClosed { get; set; } = false;

    /// <summary>
    /// 
    /// </summary>
    public enum CmdCode : ushort
    {
      CloseConnection = 1010,
      DataSetRequest  = 1100,
    }

    private CmdCode GetCmdCode  (byte[] bytes) => (CmdCode)BitConverter.ToUInt16(bytes, 0);
    private UInt16  GetJobNo    (byte[] bytes) =>          BitConverter.ToUInt16(bytes, 2);
    private UInt16  GetDataSetNo(byte[] bytes) =>          BitConverter.ToUInt16(bytes, 4);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="networkStream"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="bytes"></param>
    /// <param name="bytesRead"></param>
    /// <returns></returns>
    public async Task<bool> CmdHandler(NetworkStream networkStream, CancellationToken cancellationToken, byte[] bytes, int bytesRead)
    {
      //CmdCode cmdCode = CmdCode.None;
      bool result = false;
      // Behandlung vom Befehls-Code (2 bytes)
      if (bytesRead >= 2)
      {
        CmdCode cmdCode = GetCmdCode(bytes);
        result = await ExecuteCmd(networkStream, cancellationToken, bytes, bytesRead, cmdCode);
      }
      return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="networkStream"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="bytes"></param>
    /// <param name="bytesRead"></param>
    /// <param name="cmdCode"></param>
    /// <returns></returns>
    private async Task<bool> ExecuteCmd(NetworkStream networkStream, CancellationToken cancellationToken, byte[] bytes, int bytesRead, CmdCode cmdCode)
    {
      bool result = false;
      switch (cmdCode)
      {
        case CmdCode.DataSetRequest:
          result = await ExecCmdDataSetRequest(networkStream, cancellationToken, bytes, bytesRead);
          break;
        case CmdCode.CloseConnection:
          result = await ExecCmdCloseConnection(networkStream, cancellationToken);
          break;
        default:
          await WriteErrorStatusAsync(networkStream, cancellationToken, cmdCode, ResultStatus.CmdCodeUnknown);
          break;
      }
      return result;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="networkStream"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="bytes"></param>
    /// <param name="bytesRead"></param>
    /// <returns></returns>
    private async Task<bool> ExecCmdCloseConnection(NetworkStream networkStream, CancellationToken cancellationToken)
    {
      UInt16 cmdCode = (UInt16)CmdCode.CloseConnection; //  2
      Int16  status  = Convert.ToInt16(0);              //  4 
      byte[] byteWrites = new byte[4];
      BitConverter.GetBytes(cmdCode).CopyTo(byteWrites,  0);
      BitConverter.GetBytes(status ).CopyTo(byteWrites,  2);
      await networkStream.WriteAsync(byteWrites, 0, byteWrites.Length, cancellationToken);
      IsExecCmdConnectionClosed = true;
      return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="networkStream"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="bytes"></param>
    /// <param name="bytesRead"></param>
    /// <returns></returns>
    private async Task<bool> ExecCmdDataSetRequest(NetworkStream networkStream, CancellationToken cancellationToken, byte[] bytes, int bytesRead)
    {
      bool result = false;
      // Behandlung der JobNumber(2 bytes) und DataSetNumber(2 bytes)
      if (bytesRead >= 6 && networkStream.CanWrite)
      {
        string   dataSetName   = GetDataSetNo(bytes).ToString();
        CCutData cutData       = new CCutData();
        bool     dataSetFound  = await Repository.isRemarkPresentAsync(dataSetName, cutData);

        ResultStatus resultStatus = ResultStatus.NoError;

        // Wenn Datensatz nicht gefunden wurde
        if (!dataSetFound)
        {
          // Status: Datensatz nicht gefunden
          resultStatus = ResultStatus.DataRecordNotFound;
        }
        else
        {
          // Datensatz mit eingestelter Gas-Art überprüfen 
          bool isAssociatedGasType = Helper.IsAssociatedGasType(cutData);
          if (!isAssociatedGasType)
          {
            // Status: Gasart vom Datensatz stimmt nicht mit eingstellter Gasart überein
            resultStatus = ResultStatus.WrongGasType;
          }
          else
          {
            // Technologie-Daten in Gerät(e) laden
            bool loadTechnologyData = await Helper.LoadTechnologyDataAsync(cutData);
            // Bei Erfolg
            if (loadTechnologyData)
            {
              Debug.Print($"{Helper.GetDateTimeDebug()}: CmdCodeManager.ExecCmdDataSetRequest() status = 0, No error");
            }
            else
            {
              // Status: Fehler beim Laden vom angeforderten Datensatz in Gerät(e)
              resultStatus = ResultStatus.LoadError;
            }
            result = loadTechnologyData;
          }
        }

        if (result)
        {
          // Um auf die Rohdaten zugreifen zu können 
          var values = IhtModbusData.GetAreasDataSimulationData();
          IhtModbusData ihtModbusData = new IhtModbusData((int)IhtModbusCommunic.SlaveId.Id_Default, (ushort[])values, _IsSimulation: true);
          IhtCutDataAddressMap ihtCutDataAddressMap = new IhtCutDataAddressMap(); //todo IhtCutDataBase.GetIhtCutDataBase().ihtCutDataAddressMap;
          ihtCutDataAddressMap.SetData(cutData, ihtModbusData);

          UInt16 cmdCode          = (UInt16)CmdCode.DataSetRequest;                                         //  2
          Int16  status           = Convert.ToInt16(resultStatus.Value);                                    //  4 
          UInt16 jobNo            = GetJobNo    (bytes);                                                    //  6
          UInt16 dataSetNo        = GetDataSetNo(bytes);                                                    //  8
          UInt16 paramLength      = 8;                                                                      // 10
          UInt16 cuttingSpeed     = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.CuttingSpeed);  // 12
          UInt16 kerf             = Convert.ToUInt16(cutData.Kerf * 10);                                    // 14
          UInt16 preHeatingHeight = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PreHeatHeight); // 16
          UInt16 piercingHeight   = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PierceHeight ); // 18
          UInt16 cuttingHeight    = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.CutHeight    ); // 20
          UInt16 preHeatingTime   = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PreHeatTime  ); // 22
          UInt16 piercingTime     = ihtModbusData.GetValue(IhtModbusParamDyn.eIdxTechnology.PierceTime   ); // 24
          UInt16 leadInLength     = Convert.ToUInt16(cutData.LeadInLength * 10);                            // 26
          //UInt32 testDWORD        = 0x12345678; // 305419896

          byte[] byteWrites = new byte[26];
          BitConverter.GetBytes(cmdCode         ).CopyTo(byteWrites,  0);
          BitConverter.GetBytes(status          ).CopyTo(byteWrites,  2);
          BitConverter.GetBytes(jobNo           ).CopyTo(byteWrites,  4);
          BitConverter.GetBytes(dataSetNo       ).CopyTo(byteWrites,  6);
          BitConverter.GetBytes(paramLength     ).CopyTo(byteWrites,  8);
          BitConverter.GetBytes(cuttingSpeed    ).CopyTo(byteWrites, 10);
          BitConverter.GetBytes(kerf            ).CopyTo(byteWrites, 12);
          BitConverter.GetBytes(preHeatingHeight).CopyTo(byteWrites, 14);
          BitConverter.GetBytes(piercingHeight  ).CopyTo(byteWrites, 16);
          BitConverter.GetBytes(cuttingHeight   ).CopyTo(byteWrites, 18);
          BitConverter.GetBytes(preHeatingTime  ).CopyTo(byteWrites, 20);
          BitConverter.GetBytes(piercingTime    ).CopyTo(byteWrites, 22);
          BitConverter.GetBytes(leadInLength    ).CopyTo(byteWrites, 24);
          //BitConverter.GetBytes(testDWORD       ).CopyTo(byteWrite, 18);
        
          await networkStream.WriteAsync(byteWrites, 0, byteWrites.Length, cancellationToken);
        }
        else
        {
          Debug.Print($"{Helper.GetDateTimeDebug()}: CmdCodeManager.ExecCmdDataSetRequest() status = {resultStatus.Value}, {resultStatus.Descprition}");
          await WriteErrorStatusAsync(networkStream, cancellationToken, CmdCode.DataSetRequest, resultStatus);
        }
      }
      else
      {
        Debug.Print($"{Helper.GetDateTimeDebug()}: CmdCodeManager.ExecCmdDataSetRequest() status = {ResultStatus.RxDataToSmall.Value}, {ResultStatus.RxDataToSmall.Descprition}");
        await WriteErrorStatusAsync(networkStream, cancellationToken, CmdCode.DataSetRequest, ResultStatus.RxDataToSmall);
      }
      return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="networkStream"></param>
    /// <param name="bytes"></param>
    /// <param name="infoDataSetNo"></param>
    /// <returns></returns>
    private async Task WriteErrorStatusAsync(NetworkStream networkStream, CancellationToken cancellationToken, CmdCode cmdCode_, ResultStatus resultStatus)
    {
      UInt16 cmdCode = (UInt16)cmdCode_;                    //  2
      Int16  status  = Convert.ToInt16(resultStatus.Value); //  4 
      byte[] byteWrites = new byte[4];
      BitConverter.GetBytes(cmdCode).CopyTo(byteWrites,  0);
      BitConverter.GetBytes(status ).CopyTo(byteWrites,  2);

      await networkStream.WriteAsync(byteWrites, 0, byteWrites.Length, cancellationToken);
      string msg = $"{Helper.PreInfoApc}: ({resultStatus.Value}) {resultStatus.Descprition}";
      Debug.Print($"{Helper.GetDateTimeDebug()}: {msg}");
      SetStatusMsg(IhtMsgLog.Info.Warning, msg);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="warning"></param>
    /// <param name="msg"></param>
    private void SetStatusMsg(IhtMsgLog.Info info, string msg)
    {
      MainWndHelper.GetMainWndHelper().SetStatusMsg(info, msg);
    }
  }
}
