using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Machine
{
  public class ResultStatus
  {
    /// <value>Value of return value</value>
    public int    Value        { get; private set; }
    /// <value>Description of return value</value>
    public string Descprition  { get; private set; }

    /// <summary>
    /// Value comparison
    /// </summary>
    /// <param name="infoResult"></param>
    /// <returns>True if Value ar equals</returns>
    public bool IsValueEqual(ResultStatus resultStatus)
    {
      return this.Value == resultStatus.Value;
    }
    
    /// <summary>
    /// Konstruktor
    /// </summary>
    /// <param name="value"></param>
    /// <param name="descprition"></param>
    private ResultStatus(int value, string descprition)
    {
      Value       = value;
      Descprition = descprition;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="descprition"></param>
    public ResultStatus(string descprition, int value)
    {
      Value       = value;
      Descprition = descprition;
    }

    public static ResultStatus NoError                          {get; } = new ResultStatus(  0, "No Error"                                                  );// Initialisiserungswert
    public static ResultStatus DataRecordNotFound               {get; } = new ResultStatus( -1, "Requested data record not found in the database"           );// Angeforderten Datensatz in der Datenbank nicht gefunden
    public static ResultStatus DataRecordUserLoaded             {get; } = new ResultStatus( -2, "Data record loaded into device(s) by operator"             );// Datensatz durch Bediener in Gerät(e) geladen
    public static ResultStatus LoadError                        {get; } = new ResultStatus( -3, "Error loading requested data record into device(s)"        );// Fehler beim Laden vom angeforderten Datensatz in Gerät(e)
    public static ResultStatus WrongGasType                     {get; } = new ResultStatus( -4, "Gas type from the data set does not match the gas type set");// Gasart vom Datensatz stimmt nicht mit eingstellter Gasart überein
    public static ResultStatus Invalid                          {get; } = new ResultStatus( -5, "Invalid data record"                                       );// Ungültiger Datensatz
    public static ResultStatus CmdCodeUnknown                   {get; } = new ResultStatus( -6, "Command Code unknown"                                      );// Befehls-Code unbekannt
    public static ResultStatus RxDataToSmall                    {get; } = new ResultStatus( -7, "Received data smaller than expected data"                  );// Empfangene Daten kleiner als erwartete Daten
    public static ResultStatus GeneralError                     {get; } = new ResultStatus( -8, "General error"                                             );// Allgemeiner Fehler

    public static ResultStatus DataRecordsEndIsMissing          {get; } = new ResultStatus( -9, "Request DataRecords end value is missing"                  );
    public static ResultStatus DataRecordsStartIsLowerOne       {get; } = new ResultStatus(-10, "Request DataRecords start value must be greater 0"         );
    public static ResultStatus DataRecordsStartIsGreaterEnd     {get; } = new ResultStatus(-11, "Request DataRecords start value is greater than end value" );
    public static ResultStatus DataRecordsMaximumNoExceeded     {get; } = new ResultStatus(-12, "Request DataRecords the maximum number is exceeded"        );
    public static ResultStatus ApcStationNotAvailable           { get;} = new ResultStatus(-13, "APC-Station is not available"                              );
    public static ResultStatus JsonError                        {get; } = new ResultStatus(-80, "JSON error"                                                );
    public static ResultStatus JsonStringIsNullOrEmptyOrMissing {get; } = new ResultStatus(-81, "JSON string is null, empty or missing"                     );
    public static ResultStatus NotImplemented_Todo              {get; } = new ResultStatus(-99, "Function is not implemented. Todo!"                        );

    /// <summary>
    /// Beschreibung für entsprechende InfoDataSetNo abfragen
    /// </summary>
    internal static string GetDescription(int resultValue)
    {
      ResultStatus resultStatus  = null;
      if (IsMember(resultValue, ref resultStatus))
      {
        return resultStatus.Descprition;
      }
      return "Status not found";
    }

    /// <summary>
    /// 
    /// </summary>
    public static bool IsMember(int resultValue, ref ResultStatus resultStatus)
    {
      foreach (ResultStatus data in List())
      {
        if (resultValue == data.Value)
        {
          resultStatus = data;
          return true;
        }
      }
      return false;
    }


    /// <value>IEnumerable</value>
    public static IEnumerable<ResultStatus> List()
    {
      // alternately, use a dictionary keyed by value
      return new[]
      {
        NoError       ,
        DataRecordNotFound  ,
        DataRecordUserLoaded,
        LoadError     ,
        WrongGasType  ,
        Invalid       ,
        CmdCodeUnknown,
        RxDataToSmall ,
        GeneralError  ,

        DataRecordsEndIsMissing         , 
        DataRecordsStartIsLowerOne      ,
        DataRecordsStartIsGreaterEnd    ,
        DataRecordsMaximumNoExceeded    ,
        ApcStationNotAvailable          ,
        JsonError                       ,
        JsonStringIsNullOrEmptyOrMissing,
        NotImplemented_Todo             ,
      };
    }
  }
}
