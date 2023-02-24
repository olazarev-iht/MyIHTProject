namespace IhtApcWebServer.Data.Models.APCHardware
{
    public class ErrorLog
    {
        public Guid Id { get; set; }
        public int? DeviceId { get; set; }
        public string? ErrorCode { get; set; }
        public string? Descritpion { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
