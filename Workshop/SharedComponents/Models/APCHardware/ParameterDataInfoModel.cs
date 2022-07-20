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

        public ParameterDataInfoModel(ParamGroup paramGroup, ParamIds ? paramId)
        {
            if (paramId is null) throw new ArgumentNullException($"{nameof(paramId)}");

            ushort u16IdxTechnology = (ushort)paramId;
            bool IgnorePasswordValid = true;

            Id = Guid.NewGuid();
            Unit = IhtModbusUnitParam.GetTechnology(u16IdxTechnology);

            var idx = (ushort)(u16IdxTechnology * 3);
            var minId = (ushort)(idx + 0);
            var maxId = (ushort)(idx + 1);
            var stepId = (ushort)(idx + 2);

            MinDescription = IhtModbusDescriptionParamConst.GetTechnology(minId);
            MaxDescription = IhtModbusDescriptionParamConst.GetTechnology(maxId);
            StepDescription = IhtModbusDescriptionParamConst.GetTechnology(stepId);

            ValueDescription = IhtModbusDescriptionParamDyn.GetTechnology(u16IdxTechnology);

            Multiplier = IhtModbusRealMultiplierParam.GetTechnology(u16IdxTechnology, IgnorePasswordValid);
        }

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
                case ParamGroup.ProcessInfo:
                    return IhtModbusDescriptionParamConst.GetProcessInfo(u16Idx);
                case ParamGroup.CmdExec:
                    return IhtModbusDescriptionParamConst.GetCmdExec(u16Idx);
                case ParamGroup.SetupExec:
                    return IhtModbusDescriptionParamConst.GetSetupExec(u16Idx);
                default:
                    return string.Empty;
            }
        }
    }
}
