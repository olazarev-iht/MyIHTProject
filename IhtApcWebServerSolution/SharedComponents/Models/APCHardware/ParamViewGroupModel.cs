using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.APCHardware
{
    public class ParamViewGroupModel
    {
        public string Id { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
        public int GroupOrder { get; set; }
    }
}
