using SharedComponents.Models.APCHardware;

namespace IhtApcWebServer.Data.Models.APCHardware
{
    public class ParameterData
    {
        public Guid Id { get; set; }
        public string ParamName { get; set; } = "";
        public Guid APCDeviceId { get; set; }
        public APCDevice? APCDevice { get; set; }
        public ParamGroup ParamGroupId { get; set; }
        public Guid? DynParamsId { get; set; }
        public DynParams? DynParams { get; set; }
    }
}
