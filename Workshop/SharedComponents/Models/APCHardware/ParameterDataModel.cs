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
        public string ParamName { get; set; } = "";
        public Guid APCDeviceId { get; set; }
        public APCDeviceModel? APCDevice { get; set; } = new();
        public Guid? DynParamsId { get; set; }
        public DynParamsModel? DynParams { get; set; } = new();

    }
}
