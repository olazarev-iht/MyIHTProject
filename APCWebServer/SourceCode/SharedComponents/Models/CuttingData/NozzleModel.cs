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
        public string Name1
        {
            get
            {
                return ArrNames != null ? ArrNames[0] : string.Empty;
            }
        }
        public string Name2 {
            get 
            {
                return ArrNames != null && ArrNames.Count() > 1 ? ArrNames[1] : string.Empty;
            }
        } 

        private string[] ArrNames
        {
            get
            {
                return Name.Split(' ');
            }
        }
    }
}
