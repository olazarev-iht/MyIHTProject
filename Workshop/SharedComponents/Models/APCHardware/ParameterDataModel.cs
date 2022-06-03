using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.APCHardware
{
    public class ParameterDataModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public int DeviceId { get; set; }
        public Guid? ConstParamsId { get; set; }
        public ConstParamsModel? ConstParams { get; set; }
        public Guid? DynParamsId { get; set; }
        public DynParamsModel? DynParams { get; set; }

    }
}
