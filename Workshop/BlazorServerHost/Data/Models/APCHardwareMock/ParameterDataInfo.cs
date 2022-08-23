namespace BlazorServerHost.Data.Models.APCHardwareMock
{
    public class ParameterDataInfo
    {
        public Guid Id { get; set; }
        public string? Unit { get; set; }
        public string? Format { get; set; }
        public string? MinDescription { get; set; }
        public string? MaxDescription { get; set; }
        public string? StepDescription { get; set; }
        public string? ValueDescription { get; set; }
        public double Multiplier { get; set; }
    }
}
