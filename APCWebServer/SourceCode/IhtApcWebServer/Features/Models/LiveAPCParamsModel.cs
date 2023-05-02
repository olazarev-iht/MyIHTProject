using SharedComponents.Models;

namespace IhtApcWebServer.Features.Models
{
    public class LiveAPCParamsModel
    {
        public Dictionary<int, LiveParamsInfo> LiveParamsInfos { get; set; } = new Dictionary<int, LiveParamsInfo>();

        public LiveAPCParamsModel()
        {
            LiveParamsInfos.Add(1, new LiveParamsInfo());
            LiveParamsInfos.Add(2, new LiveParamsInfo());
            LiveParamsInfos.Add(3, new LiveParamsInfo());
        }
    }
}
