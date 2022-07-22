using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.IhtModbus;

namespace SharedComponents.Models.APCHardware
{
    public enum ParamGroup
    {
        Technology = 1,
        Process,
        Config,
        Service,
        ProcessInfo,
        CmdExec,
        SetupExec,
        StatusHeightCtrl, // ???
        Additional,
    }

    public class ParamGroupHelper
    {
        public static Dictionary<ParamGroup, int[]> ParamGroupToParamEnum = new Dictionary<ParamGroup, int[]>()
        {
            { ParamGroup.Technology, (int[])Enum.GetValues(typeof(ParamIds)) },
            { ParamGroup.Process, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxProcess)) },
            { ParamGroup.Config, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxConfig)) },
            { ParamGroup.Service, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxService)) },
            { ParamGroup.ProcessInfo, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxProcessInfo)) },
            { ParamGroup.CmdExec, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxCmdExec)) },
            { ParamGroup.SetupExec, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxSetupExec)) },
            { ParamGroup.StatusHeightCtrl, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eStatusHeightCtrl)) },
            { ParamGroup.Additional, (int[])Enum.GetValues(typeof(IhtModbusParamDyn.eIdxAdditional)) }
        };

        public static Dictionary<ParamGroup, Type> ParamGroupToEnumType = new Dictionary<ParamGroup, Type>()
        {
            { ParamGroup.Technology, typeof(ParamIds) },
            { ParamGroup.Process, typeof(IhtModbusParamDyn.eIdxProcess) },
            { ParamGroup.Config, typeof(IhtModbusParamDyn.eIdxConfig) },
            { ParamGroup.Service, typeof(IhtModbusParamDyn.eIdxService) },
            { ParamGroup.ProcessInfo, typeof(IhtModbusParamDyn.eIdxProcessInfo) },
            { ParamGroup.CmdExec, typeof(IhtModbusParamDyn.eIdxCmdExec) },
            { ParamGroup.SetupExec, typeof(IhtModbusParamDyn.eIdxSetupExec) },
            { ParamGroup.StatusHeightCtrl, typeof(IhtModbusParamDyn.eStatusHeightCtrl) },
            { ParamGroup.Additional, typeof(IhtModbusParamDyn.eIdxAdditional) }
        };
    }
}
