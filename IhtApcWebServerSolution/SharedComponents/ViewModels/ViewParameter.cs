using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.ViewModels
{
    public class ViewParameter
    {
        public string Name { get; set; } = string.Empty;
        public string Mode { get; set; } = string.Empty;
        public string[] Values { get; set; } = Array.Empty<string>();
        public bool? ReadOnly { get; set; }
        public bool? Unit { get; set; }
    }
}
