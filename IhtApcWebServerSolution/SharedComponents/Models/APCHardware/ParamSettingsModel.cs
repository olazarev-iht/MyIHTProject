using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.APCHardware
{
    public class ParamSettingsModel
    {
        public Guid Id { get; set; }
        public string ParamId { get; set; } = string.Empty;
        public string ParamType { get; set; } = string.Empty;
        public string ParamName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public int PasswordLevel { get; set; }
        public string? ParamViewGroupId { get; set; }
        public ParamViewGroupModel? ParamViewGroup { get; set; }
        public int ParamOrder { get; set; }
    }
}
