using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtDev
{
    /// <summary>
    /// Klasse
    /// </summary>
    public class ErrorCodeLables
    {
        internal Dictionary<int, string> errorCodeLabels = new Dictionary<int, string>();

        /// <summary>
        /// Konstruktor
        /// </summary>
        internal protected ErrorCodeLables()
        {

        }

        /// <summary>
        /// Error-Code Labels setzen
        /// </summary>
        internal void SetErrorCodeLabels(List<string> list)
        {
            errorCodeLabels.Clear();
            foreach (string label in list)
            {
                if (label.Length == 0)
                {
                    continue;
                }
                int idx = label.IndexOf('.');
                string errNumber = label.Substring(idx + 1, 2);
                idx = label.IndexOf(':');
                string errCode = label.Substring(idx + 2);
                int number = 0;
                try
                {
                    if (errNumber != "--")
                    {
                        number = Convert.ToInt32(errNumber);
                    }
                    errorCodeLabels.Add(number, errCode);
                }
                catch (System.FormatException ex)
                {
                    Debug.Print($"ErrorCodeLabels->SetErrorCodeLabels(): Message: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Debug.Print($"ErrorCodeLabels->SetErrorCodeLabels(): Message: {ex.Message}");
                }
            }
            // Er.100 Modbus Kommunikations-Fehler
            errorCodeLabels.Add(IhtDevice.ErrorCodeCommunic, "Error Modbus Communication");
        }

        /// <summary>
        /// Error-Code Label abfragen
        /// </summary>
        internal string GetErrorCodeLabel(int errorCode)
        {
            if (errorCodeLabels.ContainsKey(errorCode))
            {
                return errorCodeLabels[errorCode];
            }
            return "Er." + errorCode.ToString();
        }
    }

    /// <summary>
    /// Klasse ErrorCodeLablesDevices
    /// </summary>
    internal class ErrorCodeLablesDevices
    {
        internal Dictionary<string, ErrorCodeLables> errorCodes = new Dictionary<string, ErrorCodeLables>();

        /// <summary>
        /// Konstruktor
        /// </summary>
        internal ErrorCodeLablesDevices()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        internal void SetErrorCodeLabels(string fwVersion, List<string> list)
        {
            if (!errorCodes.ContainsKey(fwVersion))
            {
                ErrorCodeLables _errorCodeLables = new ErrorCodeLables();
                _errorCodeLables.SetErrorCodeLabels(list);
                errorCodes.Add(fwVersion, _errorCodeLables);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal ErrorCodeLables GetErrorCodeLabels(string fwVersion)
        {
            ErrorCodeLables _errorCodeLabels;
            errorCodes.TryGetValue(fwVersion, out _errorCodeLabels);
            return _errorCodeLabels;
        }

    }
}
