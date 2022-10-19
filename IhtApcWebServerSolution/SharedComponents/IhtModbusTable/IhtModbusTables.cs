using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtModbusTable
{
    public class IhtModbusTables
    {

        public IhtModbusTableCutCycleStateLabels ihtModbusTableCutCycleStateLabels;
        public IhtModbusTableCutCycleStateCurrTbl ihtModbusTableCutCycleStateCurrTbl;
        public IhtModbusTableCutCycleStatePrevTbl ihtModbusTableCutCycleStatePrevTbl;
        public IhtModbusTableErrorLabels ihtModbusTableErrorLabels;
        public IhtModbusTableErrorTbl ihtModbusTableErrorTbl;
        public IhtModbusTableMenuParamTbl ihtModbusTableMenuParamTbl;
        public IhtModbusTableOxyProcCutCycleStateLabels ihtModbusTableOxyProcCutCycleStateLabels;
        public IhtModbusTableOxyProcCutCycleStateCurrTbl ihtModbusTableOxyProcCutCycleStateCurrTbl;
        public IhtModbusTableOxyProcCutCycleStatePrevTbl ihtModbusTableOxyProcCutCycleStatePrevTbl;
        public IhtModbusTableTempHistogramuCTbl ihtModbusTableTempHistogramuCTbl;
        public IhtModbusTableHistogramCommonTbl ihtModbusTableHistogramCommonTbl;
        public IhtModbusTableHistogramCommonCustomTbl ihtModbusTableHistogramCommonCustomTbl;
        public IhtModbusTableErrorCustomTbl ihtModbusTableErrorCustomTbl;
        public IhtModbusTableFitPlus3HistoErrorTbl ihtModbusTableFitPlus3HistoErrorTbl;
        public IhtModbusTableFitPlus3HistoErrorCustomTbl ihtModbusTableFitPlus3HistoErrorCustomTbl;
        public IhtModbusTableFitPlus3HistoTempuCTbl ihtModbusTableFitPlus3HistoTempuCTbl;
        public IhtModbusTableFitPlus3HistoTempTopTbl ihtModbusTableFitPlus3HistoTempTopTbl;
        public IhtModbusTableFitPlus3HistoTempBottomTbl ihtModbusTableFitPlus3HistoTempBottomTbl;
        public IhtModbusTableStatusInfoTbl ihtModbusTableStatusInfoTbl;
        public IhtModbusTableStatusInfoSpecificTbl ihtModbusTableStatusInfoSpecificTbl;


        public IhtModbusTables(IhtModbusCommunic _ihtModbusCommunic)
        {
            ihtModbusTableCutCycleStateLabels = new IhtModbusTableCutCycleStateLabels(_ihtModbusCommunic);
            ihtModbusTableCutCycleStateCurrTbl = new IhtModbusTableCutCycleStateCurrTbl(_ihtModbusCommunic);
            ihtModbusTableCutCycleStatePrevTbl = new IhtModbusTableCutCycleStatePrevTbl(_ihtModbusCommunic);
            ihtModbusTableErrorLabels = new IhtModbusTableErrorLabels(_ihtModbusCommunic);
            ihtModbusTableErrorTbl = new IhtModbusTableErrorTbl(_ihtModbusCommunic);
            ihtModbusTableMenuParamTbl = new IhtModbusTableMenuParamTbl(_ihtModbusCommunic);
            ihtModbusTableOxyProcCutCycleStateLabels = new IhtModbusTableOxyProcCutCycleStateLabels(_ihtModbusCommunic);
            ihtModbusTableOxyProcCutCycleStateCurrTbl = new IhtModbusTableOxyProcCutCycleStateCurrTbl(_ihtModbusCommunic);
            ihtModbusTableOxyProcCutCycleStatePrevTbl = new IhtModbusTableOxyProcCutCycleStatePrevTbl(_ihtModbusCommunic);
            ihtModbusTableTempHistogramuCTbl = new IhtModbusTableTempHistogramuCTbl(_ihtModbusCommunic);
            ihtModbusTableHistogramCommonTbl = new IhtModbusTableHistogramCommonTbl(_ihtModbusCommunic);
            ihtModbusTableHistogramCommonCustomTbl = new IhtModbusTableHistogramCommonCustomTbl(_ihtModbusCommunic);
            ihtModbusTableErrorCustomTbl = new IhtModbusTableErrorCustomTbl(_ihtModbusCommunic);
            ihtModbusTableFitPlus3HistoErrorTbl = new IhtModbusTableFitPlus3HistoErrorTbl(_ihtModbusCommunic);
            ihtModbusTableFitPlus3HistoErrorCustomTbl = new IhtModbusTableFitPlus3HistoErrorCustomTbl(_ihtModbusCommunic);
            ihtModbusTableFitPlus3HistoTempuCTbl = new IhtModbusTableFitPlus3HistoTempuCTbl(_ihtModbusCommunic);
            ihtModbusTableFitPlus3HistoTempTopTbl = new IhtModbusTableFitPlus3HistoTempTopTbl(_ihtModbusCommunic);
            ihtModbusTableFitPlus3HistoTempBottomTbl = new IhtModbusTableFitPlus3HistoTempBottomTbl(_ihtModbusCommunic);
            ihtModbusTableStatusInfoTbl = new IhtModbusTableStatusInfoTbl(_ihtModbusCommunic);
            ihtModbusTableStatusInfoSpecificTbl = new IhtModbusTableStatusInfoSpecificTbl(_ihtModbusCommunic);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableCutCycleStateLabels : IhtModbusTableBase
    {
        public IhtModbusTableCutCycleStateLabels(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.CutCycleStateLabelTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableCutCycleStateCurrTbl : IhtModbusTableBase
    {
        public IhtModbusTableCutCycleStateCurrTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.CutCycleStateCurrTbl)
        {
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableCutCycleStatePrevTbl : IhtModbusTableBase
    {
        public IhtModbusTableCutCycleStatePrevTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.CutCycleStatePrevTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableErrorLabels : IhtModbusTableBase
    {
        public IhtModbusTableErrorLabels(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.ErrorLabelTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableErrorTbl : IhtModbusTableBase
    {
        public IhtModbusTableErrorTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.ErrorEepromTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableMenuParamTbl : IhtModbusTableBase
    {
        public IhtModbusTableMenuParamTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.MenuParamTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableOxyProcCutCycleStateLabels : IhtModbusTableBase
    {
        public IhtModbusTableOxyProcCutCycleStateLabels(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.OxyProcCutCycleStateLabelTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableOxyProcCutCycleStateCurrTbl : IhtModbusTableBase
    {
        public IhtModbusTableOxyProcCutCycleStateCurrTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.OxyProcCutCycleStateCurrTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableOxyProcCutCycleStatePrevTbl : IhtModbusTableBase
    {
        public IhtModbusTableOxyProcCutCycleStatePrevTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.OxyProcCutCycleStatePrevTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableTempHistogramuCTbl : IhtModbusTableBase
    {
        public IhtModbusTableTempHistogramuCTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.TempHistogramuCTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableHistogramCommonTbl : IhtModbusTableBase
    {
        public IhtModbusTableHistogramCommonTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.HistogramCommonTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableHistogramCommonCustomTbl : IhtModbusTableBase
    {
        public IhtModbusTableHistogramCommonCustomTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.HistogramCommonCustomTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableErrorCustomTbl : IhtModbusTableBase
    {
        public IhtModbusTableErrorCustomTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.ErrorCustomTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableFitPlus3HistoErrorTbl : IhtModbusTableBase
    {
        public IhtModbusTableFitPlus3HistoErrorTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.FitPlus3HistoErrorTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableFitPlus3HistoErrorCustomTbl : IhtModbusTableBase
    {
        public IhtModbusTableFitPlus3HistoErrorCustomTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.FitPlus3HistoErrorCustomTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableFitPlus3HistoTempuCTbl : IhtModbusTableBase
    {
        public IhtModbusTableFitPlus3HistoTempuCTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.FitPlus3HistoTempuCTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableFitPlus3HistoTempTopTbl : IhtModbusTableBase
    {
        public IhtModbusTableFitPlus3HistoTempTopTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.FitPlus3HistoTempTopTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableFitPlus3HistoTempBottomTbl : IhtModbusTableBase
    {
        public IhtModbusTableFitPlus3HistoTempBottomTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.FitPlus3HistoTempBottomTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableStatusInfoTbl : IhtModbusTableBase
    {
        public IhtModbusTableStatusInfoTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.StatusInfoTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IhtModbusTableStatusInfoSpecificTbl : IhtModbusTableBase
    {
        public IhtModbusTableStatusInfoSpecificTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.StatusInfoSpecificTbl)
        {
        }

    }

}
