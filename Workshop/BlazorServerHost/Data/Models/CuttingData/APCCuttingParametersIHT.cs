namespace BlazorServerHost.Data.Models.CuttingData
{
    public class APCCuttingParametersIHT
    {
        public Guid Id { get; set; }
        public string? Material { get; set; }
        public string? Remark { get; set; }
        public int Thickness { get; set; }
        public int LeadInLength { get; set; }
        public float Kerf { get; set; }
        public int idGas { get; set; }
        public int CuttingSpeed { get; set; }
        public int IgnitionFlameAdjustment { get; set; }
        public float PI0 { get; set; }
        public float PI1 { get; set; }
        public int PreHeatHeight { get; set; }
        public float PierceHeatingOxygenPressure { get; set; }
        public float PierceCuttingOxygenPressure { get; set; }
        public float PierceFuelGasPressure { get; set; }
        public int PierceCuttingSpeedChange { get; set; }
        public float PierceTime { get; set; }
        public int PP0 { get; set; }
        public float PP1 { get; set; }
        public float PP2 { get; set; }
        public float PP3 { get; set; }
        public float PP4 { get; set; }
        public int CutHeight { get; set; }
        public float CutHeatingOxygenPressure { get; set; }
        public float CutCuttingOxygenPressure { get; set; }
        public float CutFuelGasPressure { get; set; }
        public string? ExtKey { get; set; }
        public int ControlBits { get; set; }
    }
}
