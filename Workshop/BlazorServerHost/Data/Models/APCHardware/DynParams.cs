using SharedComponents.Models.APCHardware;

namespace BlazorServerHost.Data.Models.APCHardware
{
    public class DynParams
    {
        public Guid Id { get; set; }
        public ParamIds ParamId { get; set; }
        public Guid? ConstParamsId { get; set; }
        public ConstParams? ConstParams { get; set; }
        public Guid? ParameterDataInfoId { get; set; }
        public ParameterDataInfo? ParameterDataInfo { get; set; }
        public int Value { get; set; }
    }
}
