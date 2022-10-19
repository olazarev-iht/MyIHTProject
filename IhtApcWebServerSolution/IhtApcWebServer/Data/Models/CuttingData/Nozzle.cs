namespace IhtApcWebServer.Data.Models.CuttingData
{
    public class Nozzle
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string ImgPathBegin { get; set; } = String.Empty;
        public string ImgPathEnd { get; set; } = String.Empty;
    }
}
