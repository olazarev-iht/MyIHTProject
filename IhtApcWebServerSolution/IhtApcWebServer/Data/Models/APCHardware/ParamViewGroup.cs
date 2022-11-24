namespace IhtApcWebServer.Data.Models.APCHardware
{
    public class ParamViewGroup
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public int GroupOrder { get; set; }
    }
}
