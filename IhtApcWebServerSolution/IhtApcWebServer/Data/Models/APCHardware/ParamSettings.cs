namespace IhtApcWebServer.Data.Models.APCHardware
{
    public class ParamSettings
    {
        public Guid Id { get; set; }
        public string ParamId { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public int PasswordLevel { get; set; }
        public Guid ParamViewGroupId { get; set; }
        public ParamViewGroup? ParamViewGroup { get; set; }
        public int ParamOrder { get; set; }
    }
}
