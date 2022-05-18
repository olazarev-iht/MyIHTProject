using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.CuttingData
{
    public class NozzleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string ImgPathBegin { get; set; } = String.Empty;
        public string ImgPathEnd { get; set; } = String.Empty;
    }
}
