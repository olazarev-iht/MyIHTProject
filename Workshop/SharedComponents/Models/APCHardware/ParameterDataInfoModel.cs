using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.IhtModbus;

namespace SharedComponents.Models.APCHardware
{
    public class ParameterDataInfoModel
    {
        public Guid Id { get; set; }
        public string? Unit { get; set; }
        public string? Format { get; set; }
        public string? MinDescription { get; set; }
        public string? MaxDescription { get; set; }
        public string? StepDescription { get; set; }
        public string? ValueDescription { get; set; }
        public double Multiplier { get; set; }

        public ParameterDataInfoModel() { }

        public ParameterDataInfoModel(ParamGroup paramGroup, int? paramId)
        {
            if (paramId is null) throw new ArgumentNullException($"{nameof(paramId)}");

            ushort u16IdxTechnology = (ushort)paramId;
            bool IgnorePasswordValid = true;

            Id = Guid.NewGuid();
            Unit = GetIhtModbusUnitParam(paramGroup, u16IdxTechnology);

            var idx = (ushort)(u16IdxTechnology * 3);
            var minId = (ushort)(idx + 0);
            var maxId = (ushort)(idx + 1);
            var stepId = (ushort)(idx + 2);

            MinDescription = GetIhtModbusDescriptionParamConst(paramGroup, minId);

            MaxDescription = GetIhtModbusDescriptionParamConst(paramGroup, maxId);
            StepDescription = GetIhtModbusDescriptionParamConst(paramGroup, stepId);
            ValueDescription = GetIhtModbusDescriptionParamDyn(paramGroup, u16IdxTechnology);

            Multiplier = GetIhtModbusRealMultiplierParam(paramGroup, u16IdxTechnology, IgnorePasswordValid);
        }

        //private void SetUpFormat(ParamGroup paramGroup, int paramId)
        //{
        //    var paramName = ParamGroupHelper.ParamGroupToEnumType[paramGroup].GetEnumName(paramId);

        //    switch (paramName)
        //    {
        //        case ParamGroupHelper.
        //    }

        //}



        public string GetIhtModbusUnitParam(ParamGroup paramGroup, ushort u16Idx)
        {
            switch (paramGroup)
            {
                case ParamGroup.Technology:
                    return IhtModbusUnitParam.GetTechnology(u16Idx);
                case ParamGroup.Process:
                    return IhtModbusUnitParam.GetProcess(u16Idx);
                case ParamGroup.Config:
                    return IhtModbusUnitParam.GetConfig(u16Idx);
                case ParamGroup.Service:
                    return IhtModbusUnitParam.GetService(u16Idx);
                case ParamGroup.ProcessInfo:
                    return IhtModbusUnitParam.GetProcessInfo(u16Idx);
                case ParamGroup.CmdExec:
                    return IhtModbusUnitParam.GetCmdExec(u16Idx);
                case ParamGroup.SetupExec:
                    return IhtModbusUnitParam.GetSetupExec(u16Idx);
                default: 
                    return string.Empty;
            }
        }

        public string GetIhtModbusDescriptionParamConst(ParamGroup paramGroup, ushort u16Idx)
        {
            switch (paramGroup)
            {
                case ParamGroup.Technology:
                    return IhtModbusDescriptionParamConst.GetTechnology(u16Idx);
                case ParamGroup.Process:
                    return IhtModbusDescriptionParamConst.GetProcess(u16Idx);
                case ParamGroup.Config:
                    return IhtModbusDescriptionParamConst.GetConfig(u16Idx);
                case ParamGroup.Service:
                    return IhtModbusDescriptionParamConst.GetService(u16Idx);
                default:
                    return string.Empty;
            }
        }

        public string GetIhtModbusDescriptionParamDyn(ParamGroup paramGroup, ushort u16Idx)
        {
            switch (paramGroup)
            {
                case ParamGroup.Technology:
                    return IhtModbusDescriptionParamDyn.GetTechnology(u16Idx);
                case ParamGroup.Process:
                    return IhtModbusDescriptionParamDyn.GetProcess(u16Idx);
                case ParamGroup.Config:
                    return IhtModbusDescriptionParamDyn.GetConfig(u16Idx);
                case ParamGroup.Service:
                    return IhtModbusDescriptionParamDyn.GetService(u16Idx);
                case ParamGroup.ProcessInfo:
                    return IhtModbusDescriptionParamDyn.GetProcessInfo(u16Idx);
                case ParamGroup.CmdExec:
                    return IhtModbusDescriptionParamDyn.GetCmdExec(u16Idx);
                case ParamGroup.SetupExec:
                    return IhtModbusDescriptionParamDyn.GetSetupExec(u16Idx);
                case ParamGroup.Additional:
                    return IhtModbusDescriptionParamDyn.GetAdditional(u16Idx);
                case ParamGroup.StatusHeightCtrl:
                    return IhtModbusDescriptionParamDyn.GetStatusHeightCtrl(u16Idx);
                default:
                    return string.Empty;
            }
        }

        public double GetIhtModbusRealMultiplierParam(ParamGroup paramGroup, ushort u16Idx, bool IgnorePasswordValid)
        {
            switch (paramGroup)
            {
                case ParamGroup.Technology:
                    return IhtModbusRealMultiplierParam.GetTechnology(u16Idx, IgnorePasswordValid);
                case ParamGroup.Process:
                    return IhtModbusRealMultiplierParam.GetProcess(u16Idx);
                case ParamGroup.Config:
                    return IhtModbusRealMultiplierParam.GetConfig(u16Idx);
                case ParamGroup.Service:
                    return IhtModbusRealMultiplierParam.GetService(u16Idx);
                case ParamGroup.ProcessInfo:
                    return IhtModbusRealMultiplierParam.GetProcessInfo(u16Idx);
                case ParamGroup.CmdExec:
                    return IhtModbusRealMultiplierParam.GetCmdExec(u16Idx);
                case ParamGroup.SetupExec:
                    return IhtModbusRealMultiplierParam.GetSetupExec(u16Idx);
                default:
                    return 1.0;
            }
        }
    }
}
