using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.MqttModel.Helper
{
  /// <summary>
  /// 
  /// </summary>
  class ResultHelper
  {
    public const string JsonStringIsNullOrEmpty      = "JSON string is null or empty";
    public const string DataRecordsEndIsMissing      = "Request DataRecords end value is missing";
    public const string DataRecordsStartIsLowerOne   = "Request DataRecords start value must be greater 0";
    public const string DataRecordsStartIsGreaterEnd = "Request DataRecords start value is greater then end value";
    public const string DataRecordsMaximumNoExceeded = "Request DataRecords the maximum number is exceeded";
    public const string NotImplemented_Todo          = "Function is not implemented. Todo!";
  }
}
