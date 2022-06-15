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


        public ParameterDataInfoModel(ParamIds? paramId)
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
    }
}
