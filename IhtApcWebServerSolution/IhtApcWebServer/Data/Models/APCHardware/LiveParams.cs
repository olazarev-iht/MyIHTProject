using SharedComponents.Models.APCHardware;

namespace IhtApcWebServer.Data.Models.APCHardware
{
    public class LiveParams
    {
        public Guid Id { get; set; }
        public ParamIds ParamId { get; set; }
        public Guid? ParameterDataInfoId { get; set; }
        public ParameterDataInfo? ParameterDataInfo { get; set; }
        public int Value { get; set; }
    }
}
