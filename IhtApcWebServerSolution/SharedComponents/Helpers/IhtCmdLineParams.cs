using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SharedComponents.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class IhtCmdLineParamTesting
    {
        // Bit_11..Bit_0: TorchInstalled_01..TorchInstalled_10
        public bool IsTorchInstalled_01 { get; protected internal set; } = false;
        public bool IsTorchInstalled_02 { get; protected internal set; } = false;
        public bool IsTorchInstalled_03 { get; protected internal set; } = false;
        public bool IsTorchInstalled_04 { get; protected internal set; } = false;
        public bool IsTorchInstalled_05 { get; protected internal set; } = false;
        public bool IsTorchInstalled_06 { get; protected internal set; } = false;
        public bool IsTorchInstalled_07 { get; protected internal set; } = false;
        public bool IsTorchInstalled_08 { get; protected internal set; } = false;
        public bool IsTorchInstalled_09 { get; protected internal set; } = false;
        public bool IsTorchInstalled_10 { get; protected internal set; } = false;
        // Bit_23..Bit_12: TorchEnabled_01..TorchEnabled_10
        public bool IsTorchEnabled_01 { get; protected internal set; } = false;
        public bool IsTorchEnabled_02 { get; protected internal set; } = false;
        public bool IsTorchEnabled_03 { get; protected internal set; } = false;
        public bool IsTorchEnabled_04 { get; protected internal set; } = false;
        public bool IsTorchEnabled_05 { get; protected internal set; } = false;
        public bool IsTorchEnabled_06 { get; protected internal set; } = false;
        public bool IsTorchEnabled_07 { get; protected internal set; } = false;
        public bool IsTorchEnabled_08 { get; protected internal set; } = false;
        public bool IsTorchEnabled_09 { get; protected internal set; } = false;
        public bool IsTorchEnabled_10 { get; protected internal set; } = false;
        // Bit_25..Bit_24: 0 = Propane; 1 = Acetylane; 2 = IsNaturalGas
        public int TorchType { get; protected internal set; } = 0;
        public bool IsPropane { get; protected internal set; } = false;
        public bool IsAcetylane { get; protected internal set; } = false;
        public bool IsNaturalGas { get; protected internal set; } = false;

        // Bit_31..Bit_28: CmdBits
        public bool IsStartCalibration { get; protected internal set; } = false; // Bit_28 = StartCalibration
        public bool IsStartManual { get; protected internal set; } = false; // Bit_29 = StartManual
        public bool IsStartHeightControl { get; protected internal set; } = false; // Bit_30 = StartHeightControl           
        public bool IsCloseWhenFinished { get; protected internal set; } = false; // Bit_31 = CloseWhenFinished
        public bool IsCloseAfterCutCycle { get; protected internal set; } = false; // // Nur Bit_31 gesetzt = CloseAfterCutCycle

    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtCmdLineParamBase
    {
        public readonly string IdNo;
        public readonly string IdText;
        public bool IsValid { get; protected set; }
        protected bool IsSetMinMax { get; set; }
        public IhtCmdLineParamBase(string _idNo, string _idText, bool _isSetMinMax = false)
        {
            IdNo = _idNo;
            IdText = _idText;
            IsSetMinMax = _isSetMinMax;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtCmdLineParamDouble : IhtCmdLineParamBase
    {
        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                _value = IsSetMinMax ? (value < Min) ? Min : (value > Max) ? Max : value
                                     : value;
                IsValid = true;
            }
        }
        public double Min { get; set; }
        public double Max { get; set; }
        public IhtCmdLineParamDouble(string _idNo, string _idText, bool isSetMinMax = false, double _min = 0, double _max = 0)
          : base(_idNo, _idText, isSetMinMax)
        {
            Min = _min;
            Max = _max;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtCmdLineParamInt : IhtCmdLineParamBase
    {
        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = IsSetMinMax ? (value < Min) ? Min : (value > Max) ? Max : value
                                     : value;
                IsValid = true;
            }
        }
        public int Min { get; set; }
        public int Max { get; set; }
        public IhtCmdLineParamInt(string _idNo, string _idText, bool _isSetMinMax = false, int _min = 0, int _max = 0)
          : base(_idNo, _idText, _isSetMinMax)
        {
            Min = _min;
            Max = _max;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtCmdLineParamString : IhtCmdLineParamBase
    {
        private string _value;
        public string Value { get { return _value; } set { _value = value; IsValid = true; } }
        public IhtCmdLineParamString(string _idNo, string _idText)
          : base(_idNo, _idText)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtCmdLineParams
    {
        public enum IdNo
        {
            MainWndWidth,
            MainWndHeight,
            MainWndLeft,
            MainWndTop,
            MainWndMaxized,
            Password,
            TorchDistance,
            ReduceButton,
            SimulationMode,
            //Frameless,
            BorderThickness,
            CornerRadius,
            BackButton,
            Setup,
            ComPort,
            LoadDataSet,
            Testing,
            MultipleProcess,
            Robot,
            ApcName,
            TcpIpAddrServer,
            TcpIpPortServer,
            Mqtt,
            GasController,
        }

        public bool IsSimulationDemo { get; private set; } = false;
        public bool IsSimulationExhibiton { get; private set; } = false;
        public bool IsBackButton { get; private set; } = false;
        public bool IsComPort { get; private set; } = false;
        public string ComPort { get; private set; } = string.Empty;
        public bool IsLoadDataSet { get; private set; } = false;
        public string LoadDataSetRemark { get; private set; } = string.Empty;
        public bool IsTesting { get; private set; } = false;
        //public bool   IsMultipleProcessAllowed { get; private set; } = false;
        //public bool   IsRobot                  { get; private set; } = false;

        public IhtCmdLineParamTesting ParamTesting { get; private set; } = new IhtCmdLineParamTesting();

        protected readonly string ParamTag = "--";

        protected Dictionary<IdNo, IhtCmdLineParamBase> cmdLineParams = new Dictionary<IdNo, IhtCmdLineParamBase>();

        //public static string[] CommandLineArgs = null;

#if false
    static private IhtCmdLineParams _ihtCmdLineParams = null;
    static public IhtCmdLineParams GetIhtCmdLineParams()
    {
      if (_ihtCmdLineParams == null)
      {
        _ihtCmdLineParams = new IhtCmdLineParams();
      }
      return _ihtCmdLineParams;
    }
#else
    private static readonly Lazy<IhtCmdLineParams> ihtCmdLineParamsInstance = new Lazy<IhtCmdLineParams>(() => new IhtCmdLineParams());

        static public IhtCmdLineParams GetIhtCmdLineParams()
        {
            return ihtCmdLineParamsInstance.Value;
        }
#endif
        /// <summary>
        /// 
        /// </summary>
        public IhtCmdLineParams(/*StartupEventArgs e*/)
        {
            cmdLineParams.Add(IdNo.MainWndWidth   , new IhtCmdLineParamDouble("--w"           , String.Empty));
            cmdLineParams.Add(IdNo.MainWndHeight  , new IhtCmdLineParamDouble("--h"           , String.Empty));
            cmdLineParams.Add(IdNo.MainWndLeft    , new IhtCmdLineParamDouble("--l"           , String.Empty));
            cmdLineParams.Add(IdNo.MainWndTop     , new IhtCmdLineParamDouble("--t"           , String.Empty));
            cmdLineParams.Add(IdNo.MainWndMaxized , new IhtCmdLineParamInt   ("--max"         , String.Empty));
            cmdLineParams.Add(IdNo.Password       , new IhtCmdLineParamInt   ("--pw"          , String.Empty));
            cmdLineParams.Add(IdNo.TorchDistance  , new IhtCmdLineParamDouble("--td"          , String.Empty, true, 1.0, 25.0));
            cmdLineParams.Add(IdNo.ReduceButton   , new IhtCmdLineParamInt   ("--rb"          , String.Empty));
            cmdLineParams.Add(IdNo.SimulationMode , new IhtCmdLineParamString("--m"           , "demo | messe"));
            cmdLineParams.Add(IdNo.BorderThickness, new IhtCmdLineParamDouble("--border"      , String.Empty, true, 0.0, 2.0));
            cmdLineParams.Add(IdNo.CornerRadius   , new IhtCmdLineParamDouble("--corner"      , String.Empty, true, 0.0, 5.0));
            cmdLineParams.Add(IdNo.BackButton     , new IhtCmdLineParamInt   ("--home"        , String.Empty));
            cmdLineParams.Add(IdNo.Setup          , new IhtCmdLineParamInt   ("--99"          , String.Empty));
            cmdLineParams.Add(IdNo.ComPort        , new IhtCmdLineParamString("--comport"     , String.Empty));
            cmdLineParams.Add(IdNo.LoadDataSet    , new IhtCmdLineParamString("--loaddataset" , String.Empty));
            cmdLineParams.Add(IdNo.Testing        , new IhtCmdLineParamString("--testing"     , String.Empty));
            cmdLineParams.Add(IdNo.MultipleProcess, new IhtCmdLineParamInt   ("--multiproc"   , String.Empty));
            cmdLineParams.Add(IdNo.Robot          , new IhtCmdLineParamInt   ("--robot"       , String.Empty));
            cmdLineParams.Add(IdNo.ApcName        , new IhtCmdLineParamString("--apcname"     , String.Empty));
            cmdLineParams.Add(IdNo.TcpIpAddrServer, new IhtCmdLineParamString("--tcpaddr"     , "--tcpaddr"));
            cmdLineParams.Add(IdNo.TcpIpPortServer, new IhtCmdLineParamInt   ("--tcpport"     , String.Empty));
            cmdLineParams.Add(IdNo.Mqtt           , new IhtCmdLineParamInt   ("--mqtt"        , String.Empty));
            cmdLineParams.Add(IdNo.GasController  , new IhtCmdLineParamInt   ("--gasctrl"     , String.Empty));

            string[] cmdParams = System.Environment.GetCommandLineArgs();//e.Args;
            int ParamsLength   = cmdParams != null ? cmdParams.Length : 0;
            int ParamsCount    = 1;//0;

            if (ParamsLength > 2/*1*/)
            {
                int nTagLength = ParamTag.Length;
                string strEnum, strParam;
                for (int nCount = 0; nCount < cmdLineParams.Count; nCount++)
                {
                    try
                    {
                        if (ParamsCount >= cmdParams.Length)
                        {
                            break;
                        }
                        // 1. Bezeichner z.B. --w
                        strEnum = cmdParams[ParamsCount++];
                        strEnum = strEnum.ToLower();
                        // Dem Bezeichner muss ein - vorangestellt sein 
                        if (strEnum.Length >= nTagLength && strEnum.IndexOf(ParamTag, 0, nTagLength) == 0)
                        {
                            IhtCmdLineParamBase ihtCmdLineParam = null;
                            foreach (KeyValuePair<IdNo, IhtCmdLineParamBase> kvp in cmdLineParams)
                            {
                                if (kvp.Value.IdNo.Equals(strEnum))
                                {
                                    ihtCmdLineParam = cmdLineParams[kvp.Key];
                                    break;
                                }
                            }
                            // Wenn Bezeichner vorhanden ist
                            if (ihtCmdLineParam != null && ParamsCount < ParamsLength)
                            {
                                if (ParamsCount >= cmdParams.Length)
                                {
                                    break;
                                }
                                // Parameter z.B. 800 übernehmen
                                strParam = cmdParams[ParamsCount++];
                                // Nur wenn kein -- vorangestellt
                                if (strParam.Length < nTagLength || (strParam.IndexOf(ParamTag, 0, nTagLength) != 0))
                                {
                                    IhtCmdLineParamString ihtCmdLineParamString = null;
                                    IhtCmdLineParamInt ihtCmdLineParamInt = null;
                                    IhtCmdLineParamDouble ihtCmdLineParamDouble = null;

                                    // IhtCmdLineParamDouble
                                    ihtCmdLineParamDouble = ihtCmdLineParam as IhtCmdLineParamDouble;
                                    if (ihtCmdLineParamDouble != null)
                                    {
                                        ihtCmdLineParamDouble.Value = Convert.ToDouble(strParam, CultureInfo.InvariantCulture);
                                    }

                                    // IhtCmdLineParamInt
                                    if (ihtCmdLineParamDouble == null)
                                    {
                                        ihtCmdLineParamInt = ihtCmdLineParam as IhtCmdLineParamInt;
                                        if (ihtCmdLineParamInt != null)
                                        {
                                            ihtCmdLineParamInt.Value = Convert.ToInt32(strParam);
                                        }
                                    }

                                    // IhtCmdLineParamString
                                    if (ihtCmdLineParamDouble == null
                                        && ihtCmdLineParamInt == null
                                       )
                                    {
                                        ihtCmdLineParamString = ihtCmdLineParam as IhtCmdLineParamString;
                                        if (ihtCmdLineParamString != null)
                                        {
                                            // SimulationMode
                                            //if (strEnum.Equals("--m"))
                                            if (strEnum.Equals(cmdLineParams[IdNo.SimulationMode].IdNo))
                                            {
                                                ConvertSimulationMode(strParam, ihtCmdLineParamString);
                                            }
                                            // ComPort
                                            //else if (strEnum.Equals("--comport"))
                                            else if (strEnum.Equals(cmdLineParams[IdNo.ComPort].IdNo))
                                            {
                                                ConvertComPort(strParam);
                                            }
                                            // LoadDataSet
                                            //else if (strEnum.Equals("--loaddataset"))
                                            else if (strEnum.Equals(cmdLineParams[IdNo.LoadDataSet].IdNo))
                                            {
                                                IsLoadDataSet = true;
                                                LoadDataSetRemark = strParam;
                                            }
                                            // Testing
                                            //else if (strEnum.Equals("--testing"))
                                            else if (strEnum.Equals(cmdLineParams[IdNo.Testing].IdNo))
                                            {
                                                IsTesting = true;
                                                ConvertTesting(strParam);
                                            }
                                            // ApcName
                                            else if (strEnum.Equals(cmdLineParams[IdNo.ApcName].IdNo))
                                            {
                                                // Verzeichnisname kann Leerzeichen enthalten, bis zum nächsten Parameter-Id alles übernehmen
                                                int idx = ParamsCount;
                                                while (idx < ParamsLength)
                                                {
                                                    string next = cmdParams[idx++];
                                                    if (next.Length < nTagLength)
                                                    {
                                                        strParam += " " + next;
                                                        break;
                                                    }
                                                    else if (next.IndexOf(ParamTag, 0, nTagLength) != 0)
                                                    {
                                                        strParam += " " + next;
                                                    }
                                                    else
                                                    {
                                                        break;
                                                    }
                                                }
                                                ParamsCount = idx;
                                                strParam = strParam.Replace("\r", "");
                                                ihtCmdLineParamString.Value = strParam;
                                            }
                                            // Alle anderen String-Parameter
                                            else if (strEnum.Equals(ihtCmdLineParamString.IdText))
                                            {
                                                ihtCmdLineParamString.Value = strParam;
                                            }
                                        }
                                    }

                                    // IhtCmdLineParamToDo
                                    if (ihtCmdLineParamDouble == null
                                        && ihtCmdLineParamInt == null
                                        && ihtCmdLineParamString == null
                                       )
                                    {

                                    }

                                }
                            }
                        }
                    }
                    catch (System.FormatException)
                    {
                        continue;
                    }
                    catch (System.OverflowException)
                    {
                        continue;
                    }
                    catch (System.IndexOutOfRangeException)
                    {
                        break;
                    }
                    catch (System.Exception)
                    {
                        break;
                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void ConvertSimulationMode(string strParam, IhtCmdLineParamString ihtCmdLineParamString)
        {
            if (strParam.Equals("demo"))
            {
                ihtCmdLineParamString.Value = strParam;
                IsSimulationDemo = true;
            }
            else if (strParam.Equals("messe"))
            {
                ihtCmdLineParamString.Value = strParam;
                IsSimulationExhibiton = true;
            }
            /*
            string[] idsText = ihtCmdLineParamString.IdText.Split('|');
            foreach (string _idText in idsText)
            {
              if (_idText.Equals("demo"))
              {
                IsSimulationDemo = true;
                ihtCmdLineParamString.Value = "demo";
                break;
              }
              if (_idText.Equals("messe"))
              {
                IsSimulationExhibiton = true;
                ihtCmdLineParamString.Value = "messe";
                break;
              }
            }
            */
        }

        /// <summary>
        /// 
        /// </summary>
        private void ConvertComPort(string strParam)
        {
            if (strParam.Length > 3)
            {
                string comName = strParam.Substring(0, 3).ToUpper();
                if (comName == "COM")
                {
                    try
                    {
                        int comNo = Convert.ToInt32(strParam.Substring(3));
                        if (comNo > 0 && comNo < 256)
                        {
                            ComPort = comName + comNo.ToString();
                            IsComPort = true;
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ConvertTesting(string strParam)
        {
            try
            {
                // x0001x0001x0001x8001
                string[] info16bits = strParam.Split(new char[] { 'h' }, StringSplitOptions.RemoveEmptyEntries);

#if true
                if (info16bits.Length > 0)
                {
                    UInt32 u32TorchInstalleds = Convert.ToUInt32(info16bits[0], 16);
                    // Bit_11..Bit_0: TorchInstalled_10..TorchInstalled_01
                    ParamTesting.IsTorchInstalled_01 = (u32TorchInstalleds & 0x0001) != 0;
                    ParamTesting.IsTorchInstalled_02 = (u32TorchInstalleds & 0x0002) != 0;
                    ParamTesting.IsTorchInstalled_03 = (u32TorchInstalleds & 0x0004) != 0;
                    ParamTesting.IsTorchInstalled_04 = (u32TorchInstalleds & 0x0008) != 0;
                    ParamTesting.IsTorchInstalled_05 = (u32TorchInstalleds & 0x0010) != 0;
                    ParamTesting.IsTorchInstalled_06 = (u32TorchInstalleds & 0x0020) != 0;
                    ParamTesting.IsTorchInstalled_07 = (u32TorchInstalleds & 0x0040) != 0;
                    ParamTesting.IsTorchInstalled_08 = (u32TorchInstalleds & 0x0080) != 0;
                    ParamTesting.IsTorchInstalled_09 = (u32TorchInstalleds & 0x0100) != 0;
                    ParamTesting.IsTorchInstalled_10 = (u32TorchInstalleds & 0x0200) != 0;
                }
                if (info16bits.Length > 1)
                {
                    // Bit_11..Bit_0: TorchEnabled_10..TorchEnabled_01
                    UInt32 u32TorchEnableds = Convert.ToUInt32(info16bits[1], 16);
                    ParamTesting.IsTorchEnabled_01 = (u32TorchEnableds & 0x0001) != 0;
                    ParamTesting.IsTorchEnabled_02 = (u32TorchEnableds & 0x0002) != 0;
                    ParamTesting.IsTorchEnabled_03 = (u32TorchEnableds & 0x0004) != 0;
                    ParamTesting.IsTorchEnabled_04 = (u32TorchEnableds & 0x0008) != 0;
                    ParamTesting.IsTorchEnabled_05 = (u32TorchEnableds & 0x0010) != 0;
                    ParamTesting.IsTorchEnabled_06 = (u32TorchEnableds & 0x0020) != 0;
                    ParamTesting.IsTorchEnabled_07 = (u32TorchEnableds & 0x0040) != 0;
                    ParamTesting.IsTorchEnabled_08 = (u32TorchEnableds & 0x0080) != 0;
                    ParamTesting.IsTorchEnabled_09 = (u32TorchEnableds & 0x0100) != 0;
                    ParamTesting.IsTorchEnabled_10 = (u32TorchEnableds & 0x0200) != 0;
                }
                if (info16bits.Length > 2)
                {
                    // Bit_1..Bit_0: 0 = Propane; 1 = Acetylane; 2 = IsNaturalGas
                    UInt32 u32GasType = Convert.ToUInt32(info16bits[2], 16);
                    ParamTesting.TorchType = (u32GasType > 2) ? 0 : (int)u32GasType;
                    ParamTesting.IsPropane = (ParamTesting.TorchType == 0);
                    ParamTesting.IsAcetylane = (ParamTesting.TorchType == 1);
                    ParamTesting.IsNaturalGas = (ParamTesting.TorchType == 2);
                }
                if (info16bits.Length > 3)
                {
                    // Bit_31..Bit_28: Befehls-Bits 
                    UInt32 u32CmdBits = Convert.ToUInt32(info16bits[3], 16);
                    ParamTesting.IsStartCalibration = (u32CmdBits & 0x0001) != 0; // Bit_0  = StartCalibration
                    ParamTesting.IsStartManual = (u32CmdBits & 0x0002) != 0; // Bit_1  = StartManual
                    ParamTesting.IsStartHeightControl = (u32CmdBits & 0x0004) != 0; // Bit_2  = StartHeightControl
                    ParamTesting.IsCloseAfterCutCycle = (u32CmdBits & 0x4000) != 0; // Bit_14 = CloseAfterCutCycle -> Nach einem Schneidzyklus schliessen
                    ParamTesting.IsCloseWhenFinished = (u32CmdBits & 0x8000) != 0; // Bit_15 = CloseWhenFinished
                }
#else
        UInt32 u32Value = Convert.ToUInt32(strParam, 16);

        // Bit_11..Bit_0: TorchInstalled_10..TorchInstalled_01
        UInt32 u32TorchInstalleds = u32Value & 0x000003FF;
        ParamTesting.IsTorchInstalled_01 = (u32TorchInstalleds & 0x001) != 0;
        ParamTesting.IsTorchInstalled_02 = (u32TorchInstalleds & 0x002) != 0;
        ParamTesting.IsTorchInstalled_03 = (u32TorchInstalleds & 0x004) != 0;
        ParamTesting.IsTorchInstalled_04 = (u32TorchInstalleds & 0x008) != 0;
        ParamTesting.IsTorchInstalled_05 = (u32TorchInstalleds & 0x010) != 0;
        ParamTesting.IsTorchInstalled_06 = (u32TorchInstalleds & 0x020) != 0;
        ParamTesting.IsTorchInstalled_07 = (u32TorchInstalleds & 0x040) != 0;
        ParamTesting.IsTorchInstalled_08 = (u32TorchInstalleds & 0x080) != 0;
        ParamTesting.IsTorchInstalled_09 = (u32TorchInstalleds & 0x100) != 0;
        ParamTesting.IsTorchInstalled_10 = (u32TorchInstalleds & 0x200) != 0;
        // Bit_23..Bit_12: TorchEnabled_10..TorchEnabled_01
        UInt32 u32TorchEnableds = (u32Value & 0x003FF000) >> 12;
        ParamTesting.IsTorchEnabled_01 = (u32TorchEnableds & 0x001) != 0;
        ParamTesting.IsTorchEnabled_02 = (u32TorchEnableds & 0x002) != 0;
        ParamTesting.IsTorchEnabled_03 = (u32TorchEnableds & 0x004) != 0;
        ParamTesting.IsTorchEnabled_04 = (u32TorchEnableds & 0x008) != 0;
        ParamTesting.IsTorchEnabled_05 = (u32TorchEnableds & 0x010) != 0;
        ParamTesting.IsTorchEnabled_06 = (u32TorchEnableds & 0x020) != 0;
        ParamTesting.IsTorchEnabled_07 = (u32TorchEnableds & 0x040) != 0;
        ParamTesting.IsTorchEnabled_08 = (u32TorchEnableds & 0x080) != 0;
        ParamTesting.IsTorchEnabled_09 = (u32TorchEnableds & 0x100) != 0;
        ParamTesting.IsTorchEnabled_10 = (u32TorchEnableds & 0x200) != 0;
        // Bit_25..Bit_24: 0 = Propane; 1 = Acetylane; 2 = IsNaturalGas
        UInt32 u32GasType = (u32Value & 0x03000000) >> 24;
        ParamTesting.TorchType    = (u32GasType > 2) ? 0 : (int)u32GasType;
        ParamTesting.IsPropane    = (ParamTesting.TorchType == 0);
        ParamTesting.IsAcetylane  = (ParamTesting.TorchType == 1);
        ParamTesting.IsNaturalGas = (ParamTesting.TorchType == 2);

        // Bit_31..Bit_28: Befehls-Bits 
        UInt32 u32CmdBits = (u32Value & 0xF0000000) >> 28;
        ParamTesting.IsStartCalibration   = (u32CmdBits &  0x1) != 0; // Bit_28 = StartCalibration
        ParamTesting.IsStartManual        = (u32CmdBits &  0x2) != 0; // Bit_29 = StartManual
        ParamTesting.IsStartHeightControl = (u32CmdBits &  0x4) != 0; // Bit_30 = StartHeightControl
        ParamTesting.IsCloseWhenFinished  = (u32CmdBits &  0x8) != 0; // Bit_31 = CloseWhenFinished
        ParamTesting.IsCloseAfterCutCycle = (u32CmdBits == 0x8);      // Nur Bit_31 gesetzt = CloseAfterCutCycle
#endif
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IhtCmdLineParamBase GetParam(IdNo _idNo)
        {
            if (cmdLineParams.ContainsKey(_idNo))
            {
                IhtCmdLineParamBase ihtCmdLineParam = cmdLineParams[_idNo];
                return ihtCmdLineParam;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool GetParam(IdNo _idNo, ref double param)
        {
            IhtCmdLineParamBase ihtCmdLineParam = GetParam(_idNo);
            if (ihtCmdLineParam != null)
            {
                IhtCmdLineParamDouble ihtCmdLineParamDouble = ihtCmdLineParam as IhtCmdLineParamDouble;
                if (ihtCmdLineParamDouble != null)
                {
                    param = ihtCmdLineParamDouble.Value;
                    return ihtCmdLineParamDouble.IsValid;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool GetParam(IdNo _idNo, ref int param)
        {
            IhtCmdLineParamBase ihtCmdLineParam = GetParam(_idNo);
            if (ihtCmdLineParam != null)
            {
                IhtCmdLineParamInt ihtCmdLineParamInt = ihtCmdLineParam as IhtCmdLineParamInt;
                if (ihtCmdLineParamInt != null)
                {
                    param = ihtCmdLineParamInt.Value;
                    return ihtCmdLineParamInt.IsValid;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool GetParam(IdNo _idNo, ref string param)
        {
            IhtCmdLineParamBase ihtCmdLineParam = GetParam(_idNo);
            if (ihtCmdLineParam != null)
            {
                IhtCmdLineParamString ihtCmdLineParamString = ihtCmdLineParam as IhtCmdLineParamString;
                if (ihtCmdLineParamString != null)
                {
                    param = ihtCmdLineParamString.Value;
                    return ihtCmdLineParamString.IsValid;
                }
            }
            return false;
        }

    }
}
