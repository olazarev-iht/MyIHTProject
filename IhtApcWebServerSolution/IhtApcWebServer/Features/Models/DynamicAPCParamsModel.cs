using SharedComponents.Models;

namespace IhtApcWebServer.Features.Models
{
    public class DynamicAPCParamsModel
    {
        public Dictionary<int, DynamicParamsInfo> DynamicParamsInfos { get; set; } = new Dictionary<int, DynamicParamsInfo>();

        public DynamicAPCParamsModel()
        {
            DynamicParamsInfos.Add(1, new DynamicParamsInfo());
            DynamicParamsInfos.Add(2, new DynamicParamsInfo());
            DynamicParamsInfos.Add(3, new DynamicParamsInfo());
        }
    }
}
