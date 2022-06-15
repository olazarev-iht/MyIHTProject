namespace BlazorServerHost.Data.Models.APCHardware
{
    public class APCDevice
    {
        public Guid Id { get; set; }
        public int Num { get; set; }
        public string Name { get; set; }

        public ICollection<ParameterData> parameterDatas { get; set; } = new List<ParameterData>();
    }
}
