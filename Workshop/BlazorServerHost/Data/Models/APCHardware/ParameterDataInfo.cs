namespace BlazorServerHost.Data.Models.APCHardware
{
    public class ParameterDataInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Unit { get; set; }
        public string? Format { get; set; }
        public string? Description { get; set; }
        public int Multiplier { get; set; }
    }
}
