using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Helpers
{
    public class Units
    {
        public static readonly string txtMm = "mm";
        public static readonly string txtInch = "inch";
        public static readonly string txtBar = "bar";
        public static readonly string txtPsi = "psi";

        public static readonly string txtMm_min = "mm/min";
        public static readonly string txtInch_min = "inch/min";

        public static bool IsPressurePsi { get; set; }
        public static bool IsUnitInch { get; set; }
        public static bool IsUnitInchFractional { get; set; }

        public static readonly double psiMultiplier = 14.50377438972831;
        public static readonly double psiToIntValueMultiplier = 1.0 / 0.01450377438972831;
        public static readonly double inchMultiplier = 1.0 / 25.4;

        public static readonly Dictionary<int, string> mmToinchFractions = new Dictionary<int, string>();

        /// <summary>
        /// 
        /// </summary>
        static Units()
        {
            mmToinchFractions.Add(3, "1/8");
            mmToinchFractions.Add(4, "1/6");
            mmToinchFractions.Add(5, "1/5");
            mmToinchFractions.Add(6, "1/4");
            mmToinchFractions.Add(7, "2/7");
            mmToinchFractions.Add(8, "1/3");
            mmToinchFractions.Add(10, "2/5");
            mmToinchFractions.Add(12, "1/2");
            mmToinchFractions.Add(15, "3/5");
            mmToinchFractions.Add(20, "4/5");
            mmToinchFractions.Add(25, "1");
            mmToinchFractions.Add(30, "1 1/5");
            mmToinchFractions.Add(35, "1 2/5");
            mmToinchFractions.Add(40, "1 3/5");
            mmToinchFractions.Add(50, "2");
            mmToinchFractions.Add(60, "2 2/5");
            mmToinchFractions.Add(70, "2 4/5");
            mmToinchFractions.Add(80, "3 1/5");
            mmToinchFractions.Add(90, "3 3/5");
            mmToinchFractions.Add(100, "4");
            mmToinchFractions.Add(120, "4 4/5");
            mmToinchFractions.Add(130, "5 1/5");
            mmToinchFractions.Add(150, "5 7/8");
            mmToinchFractions.Add(200, "7 7/8");
            mmToinchFractions.Add(230, "9 1/12");
            mmToinchFractions.Add(250, "9 7/8");
            mmToinchFractions.Add(300, "11 4/5");
        }

        /// <summary>
        /// 
        /// </summary>
        internal static string GetUnitTxt()
        {
            return (IsUnitInch || IsUnitInchFractional) ? txtInch : txtMm;
        }

        /// <summary>
        /// 
        /// </summary>
        internal static string Get_ms_10mm()
        {
            return (IsUnitInch || IsUnitInchFractional) ? "ms/0.394inch" : "ms/10mm";
        }

        /// <summary>
        /// 
        /// </summary>
        internal static string GetPosition(int linearDrivePosition_100um)
        {
            return (IsUnitInch || IsUnitInchFractional) ? GetFormattedUnitInch(linearDrivePosition_100um * 0.1 * inchMultiplier, false) + "inch" : String.Format("{0,1:0.0mm}", linearDrivePosition_100um * 0.1);
        }

        /// <summary>
        /// 
        /// </summary>
        internal static string GetThickness(double thickness, bool blAppendUnitTxt = true)
        {
            bool blFraction = IsUnitInchFractional;
            string inchData;
            if (blFraction)
            {
                mmToinchFractions.TryGetValue((int)thickness, out inchData);
                if (inchData == null)
                {
                    inchData = Units.GetFormattedUnitInch(thickness * Units.inchMultiplier);
                }
            }
            else
            {
                inchData = Units.GetFormattedUnitInch(thickness * Units.inchMultiplier);
            }

            return (IsUnitInch || IsUnitInchFractional) ? inchData + " " + ((blAppendUnitTxt) ? Units.txtInch : String.Empty)
                                                        : thickness.ToString() + " " + ((blAppendUnitTxt) ? Units.txtMm : String.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        internal static string GetCuttingSpeed(int cuttingSpeed, bool blAppendUintTxt = true)
        {
#if false
      return (IsUnitInch) ? Units.GetFormattedUnitInch(cuttingSpeed * Units.inchMultiplier) + " " + Units.txtInch + "/min"
                          : cuttingSpeed.ToString() + " " + Units.txtMm + "/min";
#else
            bool blFraction = IsUnitInchFractional;
            string inchData;
            double inchValue = cuttingSpeed * Units.inchMultiplier;
            if (blFraction)
            {
                int intInchValue = (int)inchValue;
                int inchFraction = Convert.ToInt32((inchValue - intInchValue) * 10);
                // Anzeige als X y/5
                if (inchFraction > 0 && inchFraction < 10 && inchFraction % 2 == 0)
                {
                    inchData = intInchValue.ToString() + " " + (inchFraction / 2).ToString() + "/5";
                }
                // Anzeige als X y/2
                else if (inchFraction == 5)
                {
                    inchData = intInchValue.ToString() + " " + "1/2";
                }
                // Anzeige als X 
                else if (inchFraction >= 10)
                {
                    inchData = (intInchValue + 1).ToString();
                }
                // Anzeige als X y/10 oder X
                else
                {
                    inchData = (inchFraction > 0) ? intInchValue.ToString() + " " + inchFraction.ToString() + "/10"
                                                  : (intInchValue).ToString();
                }
            }
            else
            {
                inchData = Units.GetFormattedUnitInch(inchValue);
            }

            return (IsUnitInch || IsUnitInchFractional) ? inchData + " " + ((blAppendUintTxt) ? Units.txtInch + "/min" : String.Empty)
                                                        : cuttingSpeed.ToString() + " " + ((blAppendUintTxt) ? Units.txtMm + "/min" : String.Empty);
#endif
        }

        /// <summary>
        /// http://www.csharp-examples.net/string-format-double/
        /// </summary>
        static public string GetFormattedUnitInch(double valueInch, bool with4Digits = true)
        {
            string result = String.Empty;
            //      result = (valueInch > 10.0 && with4Digits) ? String.Format("{0,2:0.00}", valueInch) : String.Format("{0,3:0.000}", valueInch);
            result = (with4Digits) ? String.Format("{0,2:0.00}", valueInch) : String.Format("{0,3:0.000}", valueInch);
            return result;
        }

        /// <summary>
        /// http://www.csharp-examples.net/string-format-double/
        /// </summary>
        static public string GetFormattedPressurePsi(double valuePsi, double maxValue = 0d, string parameterFormat = "")
        {
            string result = String.Empty;

            if (string.IsNullOrWhiteSpace(parameterFormat))
            {
                if (maxValue >= 5000)
                {
                    result = String.Format("{0,0:0}", valuePsi);
                }
                else if (maxValue >= 1000)
                {
                    result = String.Format("{0,1:0.0}", valuePsi);
                }
                else
                {
                    result = String.Format("{0,2:0.00}", valuePsi);
                }
            }
            else
            {
                result = String.Format(parameterFormat, valuePsi);
            }
            return result;
        }

        static public string GetFormattedPressureBar(double valuePsi, double maxValue = 0d, string parameterFormat = "")
        {
            string result = String.Empty;

            if (string.IsNullOrWhiteSpace(parameterFormat))
            {
                if (maxValue >= 5000)
                {
                    result = String.Format("{0,1:0.0}", valuePsi);
                }
                else if (maxValue >= 1000)
                {
                    result = String.Format("{0,2:0.00}", valuePsi);
                }
                else
                {
                    result = String.Format("{0,3:0.000}", valuePsi);
                }
            }
            else
            {
                result = String.Format(parameterFormat, valuePsi);
            }
            return result;
        }

        static public string GetFormattedPressurePsi(double valuePsi, bool with4Digits = true)
        {
            string result = String.Empty;
            if (with4Digits)
            {
                if (valuePsi >= 100)
                {
                    result = String.Format("{0,1:0.0}", valuePsi);
                }
                else if (valuePsi >= 10)
                {
                    result = String.Format("{0,2:0.00}", valuePsi);
                }
                else
                {
                    result = String.Format("{0,3:0.000}", valuePsi);
                }
            }
            else
            {
                result = String.Format("{0,3:0.000}", valuePsi);
            }
            return result;
        }

    }
}
