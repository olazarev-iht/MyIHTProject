using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharedComponents.ViewModels;

namespace SharedComponents.Models.APCHardware
{
    public class ParamSettingsModel
    {
        public Guid Id { get; set; }
        public string ParamId { get; set; } = string.Empty;
        public string ParamType { get; set; } = string.Empty;
        public string ParamName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public int PasswordLevel { get; set; }
        public string? ParamViewGroupId { get; set; }
        public ParamViewGroupModel? ParamViewGroup { get; set; }
        public int ParamOrder { get; set; }

        public ViewParameter ViewParameter
        {
            get
            {
                if (this.Format == null) return new ViewParameter();

                var formatDetails = JsonConvert.DeserializeObject<ViewParameter>(this.Format);

                return new ViewParameter
                {
                    Name = formatDetails?.Name != null ? formatDetails.Name : string.Empty,
                    Mode = formatDetails?.Mode != null ? formatDetails.Mode : string.Empty,
                    Values = formatDetails?.Values != null ? formatDetails.Values : Array.Empty<string>(),
                    ReadOnly = formatDetails?.ReadOnly != null ? formatDetails.ReadOnly : false,
                    Unit = formatDetails?.Unit != null ? formatDetails.Unit : false,
                };
            }
        }
    }
}
