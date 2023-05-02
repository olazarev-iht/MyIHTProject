using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IhtApcWebServer.Data.Models.CuttingData
{
    public class CuttingData
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public Guid? MaterialId { get; set; }
        public Material? Material { get; set; }
        public Guid? NozzleId { get; set; }
        public Nozzle? Nozzle { get; set; }
        public Guid? GasId { get; set; }
        public Gas? Gas { get; set; }
        public float Thickness { get; set; }
        public float Kerf { get; set; }
        public int LeadInLength { get; set; }
        public int CuttingSpeed { get; set; }
        public int IgnitionFlameAdjustment { get; set; }
        public float PreHeatHeight { get; set; }
        public float PreHeatHeatingOxygenPressure { get; set; }
        public float PreHeatFuelGasPressure { get; set; }
        public int PreHeatTime { get; set; }
        public float PierceHeight { get; set; }
        public float PierceHeatingOxygenPressure { get; set; }
        public float PierceCuttingOxygenPressure { get; set; }
        public float PierceFuelGasPressure { get; set; }
        public int PierceCuttingSpeedChange { get; set; }
        public float PierceTime { get; set; }
        public float CutHeight { get; set; }
        public float CutHeatingOxygenPressure { get; set; }
        public float CutCuttingOxygenPressure { get; set; }
        public float CutFuelGasPressure { get; set; }
        public float PI0 { get; set; }
        //[Column(TypeName = "decimal(5, 2)")]
        public float PI1 { get; set; }
        public float PP0 { get; set; }
        public float PP1 { get; set; }
        public float PP2 { get; set; }
        public float PP3 { get; set; }
        public float PP4 { get; set; }
        public string? Remark { get; set; }
        public string? ExtKey { get; set; }
        public int? idCutDataParent { get; set; }
        public int Controlbits { get; set; }
    }
}
