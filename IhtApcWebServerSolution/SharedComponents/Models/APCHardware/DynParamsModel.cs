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
        public int ParamId { get; set; }
        public int Address { get; set; }
        public Guid? ConstParamsId { get; set; }
        public ConstParamsModel? ConstParams { get; set; } = new();
        public Guid? ParameterDataInfoId { get; set; }
        public ParameterDataInfoModel? ParameterDataInfo { get; set; } = new();
        public int Value { get; set; }
    }
}
