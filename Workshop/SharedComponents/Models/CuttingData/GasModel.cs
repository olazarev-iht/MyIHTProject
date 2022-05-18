using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.CuttingData
{
    public class GasModel
    {
        public Guid Id { get; set; }
        public int GasId { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
