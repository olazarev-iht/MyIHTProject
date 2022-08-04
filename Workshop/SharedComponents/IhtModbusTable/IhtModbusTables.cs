using SharedComponents.IhtModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.IhtModbusTable
{
    internal class IhtModbusTables
    {

        internal IhtModbusTableCutCycleStateLabels ihtModbusTableCutCycleStateLabels;
        internal IhtModbusTableCutCycleStateCurrTbl ihtModbusTableCutCycleStateCurrTbl;
        internal IhtModbusTableCutCycleStatePrevTbl ihtModbusTableCutCycleStatePrevTbl;
        internal IhtModbusTableErrorLabels ihtModbusTableErrorLabels;
        internal IhtModbusTableErrorTbl ihtModbusTableErrorTbl;
        internal IhtModbusTableMenuParamTbl ihtModbusTableMenuParamTbl;
        internal IhtModbusTableOxyProcCutCycleStateLabels ihtModbusTableOxyProcCutCycleStateLabels;
        internal IhtModbusTableOxyProcCutCycleStateCurrTbl ihtModbusTableOxyProcCutCycleStateCurrTbl;
        internal IhtModbusTableOxyProcCutCycleStatePrevTbl ihtModbusTableOxyProcCutCycleStatePrevTbl;
        internal IhtModbusTableTempHistogramuCTbl ihtModbusTableTempHistogramuCTbl;
        internal IhtModbusTableHistogramCommonTbl ihtModbusTableHistogramCommonTbl;
        internal IhtModbusTableHistogramCommonCustomTbl ihtModbusTableHistogramCommonCustomTbl;
        internal IhtModbusTableErrorCustomTbl ihtModbusTableErrorCustomTbl;
        internal IhtModbusTableFitPlus3HistoErrorTbl ihtModbusTableFitPlus3HistoErrorTbl;
        internal IhtModbusTableFitPlus3HistoErrorCustomTbl ihtModbusTableFitPlus3HistoErrorCustomTbl;
        internal IhtModbusTableFitPlus3HistoTempuCTbl ihtModbusTableFitPlus3HistoTempuCTbl;
        internal IhtModbusTableFitPlus3HistoTempTopTbl ihtModbusTableFitPlus3HistoTempTopTbl;
        internal IhtModbusTableFitPlus3HistoTempBottomTbl ihtModbusTableFitPlus3HistoTempBottomTbl;
        internal IhtModbusTableStatusInfoTbl ihtModbusTableStatusInfoTbl;
        internal IhtModbusTableStatusInfoSpecificTbl ihtModbusTableStatusInfoSpecificTbl;


        internal IhtModbusTables(IhtModbusCommunic _ihtModbusCommunic)
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
    internal class IhtModbusTableCutCycleStateLabels : IhtModbusTableBase
    {
        internal IhtModbusTableCutCycleStateLabels(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.CutCycleStateLabelTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableCutCycleStateCurrTbl : IhtModbusTableBase
    {
        internal IhtModbusTableCutCycleStateCurrTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.CutCycleStateCurrTbl)
        {
        }
    }


    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableCutCycleStatePrevTbl : IhtModbusTableBase
    {
        internal IhtModbusTableCutCycleStatePrevTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.CutCycleStatePrevTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableErrorLabels : IhtModbusTableBase
    {
        internal IhtModbusTableErrorLabels(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.ErrorLabelTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableErrorTbl : IhtModbusTableBase
    {
        internal IhtModbusTableErrorTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.ErrorEepromTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableMenuParamTbl : IhtModbusTableBase
    {
        internal IhtModbusTableMenuParamTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.MenuParamTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableOxyProcCutCycleStateLabels : IhtModbusTableBase
    {
        internal IhtModbusTableOxyProcCutCycleStateLabels(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.OxyProcCutCycleStateLabelTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableOxyProcCutCycleStateCurrTbl : IhtModbusTableBase
    {
        internal IhtModbusTableOxyProcCutCycleStateCurrTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.OxyProcCutCycleStateCurrTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableOxyProcCutCycleStatePrevTbl : IhtModbusTableBase
    {
        internal IhtModbusTableOxyProcCutCycleStatePrevTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.OxyProcCutCycleStatePrevTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableTempHistogramuCTbl : IhtModbusTableBase
    {
        internal IhtModbusTableTempHistogramuCTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.TempHistogramuCTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableHistogramCommonTbl : IhtModbusTableBase
    {
        internal IhtModbusTableHistogramCommonTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.HistogramCommonTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableHistogramCommonCustomTbl : IhtModbusTableBase
    {
        internal IhtModbusTableHistogramCommonCustomTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.HistogramCommonCustomTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableErrorCustomTbl : IhtModbusTableBase
    {
        internal IhtModbusTableErrorCustomTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.ErrorCustomTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableFitPlus3HistoErrorTbl : IhtModbusTableBase
    {
        internal IhtModbusTableFitPlus3HistoErrorTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.FitPlus3HistoErrorTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableFitPlus3HistoErrorCustomTbl : IhtModbusTableBase
    {
        internal IhtModbusTableFitPlus3HistoErrorCustomTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.FitPlus3HistoErrorCustomTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableFitPlus3HistoTempuCTbl : IhtModbusTableBase
    {
        internal IhtModbusTableFitPlus3HistoTempuCTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.FitPlus3HistoTempuCTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableFitPlus3HistoTempTopTbl : IhtModbusTableBase
    {
        internal IhtModbusTableFitPlus3HistoTempTopTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.FitPlus3HistoTempTopTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableFitPlus3HistoTempBottomTbl : IhtModbusTableBase
    {
        internal IhtModbusTableFitPlus3HistoTempBottomTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.FitPlus3HistoTempBottomTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableStatusInfoTbl : IhtModbusTableBase
    {
        internal IhtModbusTableStatusInfoTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.StatusInfoTbl)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class IhtModbusTableStatusInfoSpecificTbl : IhtModbusTableBase
    {
        internal IhtModbusTableStatusInfoSpecificTbl(IhtModbusCommunic _ihtModbusCommunic)
          : base(_ihtModbusCommunic, IhtModbusParamDyn.eIdxTable.StatusInfoSpecificTbl)
        {
        }

    }

}
