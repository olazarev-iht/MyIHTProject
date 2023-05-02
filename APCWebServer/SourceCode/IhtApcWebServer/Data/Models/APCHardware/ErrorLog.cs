namespace IhtApcWebServer.Data.Models.APCHardware
{
    public class ErrorLog
    {
        public Guid Id { get; set; }
        public int? SlaveId { get; set; }
        public string? ErrorCode { get; set; }
        public string? Description { get; set; }
		public string? Params { get; set; }
		public DateTime? TimeStamp { get; set; }
    }
}
