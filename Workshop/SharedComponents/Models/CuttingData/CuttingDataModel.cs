using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.CuttingData
{
    public class CuttingDataModel
    {
        public string? Id { get; set; }
        public Guid MaterialId { get; set; }
        public MaterialModel Material { get; set; } = new MaterialModel();
        public Guid NozzleId { get; set; }
        public NozzleModel Nozzle { get; set; } = new NozzleModel();
        public Guid GasId { get; set; }
        public GasModel Gas { get; set; } = new GasModel();
        public float Thickness { get; set; } = 0;
        public float Kerf { get; set; } = 0;
        public int LeadInLength { get; set; } = 0;
        public int CuttingSpeed { get; set; } = 0;
        public int IgnitionFlameAdjustment { get; set; } = 0;
        public int PreHeatHeight { get; set; } = 0;
        public float PreHeatHeatingOxygenPressure { get; set; } = 0;
        public float PreHeatFuelGasPressure { get; set; } = 0;
        public int PreHeatTime { get; set; } = 0;
        public int PierceHeight { get; set; } = 0;
        public float PierceHeatingOxygenPressure { get; set; } = 0;
        public float PierceCuttingOxygenPressure { get; set; } = 0;
        public float PierceFuelGasPressure { get; set; } = 0;
        public int PierceCuttingSpeedChange { get; set; } = 0;
        public float PierceTime { get; set; } = 0;
        public int CutHeight { get; set; } = 0;
        public float CutHeatingOxygenPressure { get; set; } = 0;
        public float CutCuttingOxygenPressure { get; set; } = 0;
        public float CutFuelGasPressure { get; set; } = 0;
        public float PI0 { get; set; } = 0;
        public float PI1 { get; set; } = 0;
        public float PP0 { get; set; } = 0;
        public float PP1 { get; set; } = 0;
        public float PP2 { get; set; } = 0;
        public float PP3 { get; set; } = 0;
        public float PP4 { get; set; } = 0;
        public string? Remark { get; set; }
        public string? idCutDataParent { get; set; }
        public int Controlbits { get; set; } = 0;
    }
}
