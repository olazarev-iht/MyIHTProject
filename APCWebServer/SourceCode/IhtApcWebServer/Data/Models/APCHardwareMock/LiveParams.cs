using SharedComponents.Models.APCHardware;

namespace IhtApcWebServer.Data.Models.APCHardwareMock
{
    public class LiveParams
    {
        public Guid Id { get; set; }
        public ParamIds ParamId { get; set; }
        public int Value { get; set; }
    }
}
