namespace BlazorServerHost.Data.Models.APCHardware
{
    public class ConstParams
    {
        public Guid Id { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Step { get; set; }

        public ICollection<DynParams> DynParams { get; set; } = new List<DynParams>();
    }
}
