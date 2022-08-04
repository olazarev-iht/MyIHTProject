using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.StatusInfo
{
    class StatusInfoData
    {
        public enum InfoData
        {
            RegisterLength,
            Register,
            Value,
            ValueLWord,
            ValueHWord,
        }

        public readonly string Unit;
        public readonly string Description;
        public readonly double Multiplier;
        public readonly Func<int, double, string> FormattedValue;
        public readonly InfoData Info;

        private int rawValue = 0;
        public int RawValue
        {
            get => rawValue;
            set
            {
                rawValue = value;
                Value = FormattedValue(rawValue, Multiplier);
            }
        }

        public string Value { get; protected set; } = "0";

        public StatusInfoData(
           string unit,
           string description,
           double multiplier,
           Func<int, double, string> formattedValue,
           InfoData info)
        {
            Unit = unit;
            Description = description;
            Multiplier = multiplier;
            FormattedValue = formattedValue;
            Info = info;
        }

        static public string GetFormattedInt16(int rawValue, double multiplier)
        {
            Int16 rawValue16 = (Int16)rawValue;
            return Convert.ToInt32(rawValue16 * multiplier).ToString(CultureInfo.InvariantCulture);
        }

        static public string GetFormattedUInt16(int rawValue, double multiplier)
        {
            UInt16 rawValue16 = (UInt16)rawValue;
            return Convert.ToInt32(rawValue16 * multiplier).ToString(CultureInfo.InvariantCulture);
        }

        static public string GetFormattedDouble(int rawValue, double multiplier)
        {
            double Value = rawValue * multiplier;
            return String.Format(CultureInfo.InvariantCulture, "{0:0.000}", Value);
        }

        static public string GetFormattedHex(int rawValue, double multiplier)
        {
            return String.Format(CultureInfo.InvariantCulture, "0x{0:X4}", rawValue);
        }
    }
}
