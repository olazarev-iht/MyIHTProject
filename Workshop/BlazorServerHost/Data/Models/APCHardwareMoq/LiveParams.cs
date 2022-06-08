using SharedComponents.Models.APCHardware;

namespace BlazorServerHost.Data.Models.APCHardwareMoq
{
    public class LiveParams
    {
        public Guid Id { get; set; }
        public ParamIds ParamId { get; set; }
        public int Value { get; set; }
    }
}
