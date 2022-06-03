namespace BlazorServerHost.Data.Models.APCHardware
{
    public class ParameterData
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public int DeviceId { get; set; }
        public Guid? ConstParamsId { get; set; }
        public ConstParams? ConstParams { get; set; }
        public Guid? DynParamsId { get; set; }
        public DynParams? DynParams { get; set; }

    }
}
