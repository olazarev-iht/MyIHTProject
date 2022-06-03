using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.APCHardware
{
    public class ParameterDataInfoModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Unit { get; set; }
        public string? Format { get; set; }
        public string? Description { get; set; }
        public int Multiplier { get; set; }

    }
}
