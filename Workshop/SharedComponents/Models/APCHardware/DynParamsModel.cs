using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.APCHardware
{
    public class DynParamsModel
    {
        // may be delete the Id
        public Guid Id { get; set; }
        public ParamIds ParamId { get; set; }
        public Guid? ConstParamsId { get; set; }
        public ConstParamsModel? ConstParams { get; set; }
        public Guid? ParameterDataInfoId { get; set; }
        public ParameterDataInfoModel? ParameterDataInfo { get; set; }
        public int Value { get; set; }
        public string? Format { get; set; }
    }
}
