using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.APCHardware
{
    public class APCDefaultDataModel
    {
        public Guid Id { get; set; }
        public int Device { get; set; }
        public int Address { get; set; }
        public int Value { get; set; }
    }
}
