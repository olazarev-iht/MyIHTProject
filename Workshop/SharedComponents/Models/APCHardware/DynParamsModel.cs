using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.APCHardware
{
    public class DynParamsModel
    {
        public Guid Id { get; set; }
        public string? Value { get; set; }
        public string? Format { get; set; }
    }
}
