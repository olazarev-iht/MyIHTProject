using Microsoft.EntityFrameworkCore;
using BlazorServerHost.Data.Models.CuttingData;

namespace BlazorServerHost.Data
{
	public class CuttingDataDbContext : DbContext
	{
		private static readonly object Lock = new();

		public DbSet<Gas> Gas { get; set; } = null!;
		public DbSet<Material> Material { get; set; } = null!;
		public DbSet<Nozzle> Nozzle { get; set; } = null!;
		public DbSet<CuttingData> CuttingData { get; set; } = null!;
		public DbSet<APCCuttingParametersIHT> APCCuttingParametersIHT { get; set; } = null!;

		public CuttingDataDbContext(DbContextOptions<CuttingDataDbContext> options)
			: base(options)
		{
		}

		public override int SaveChanges()
		{
			throw new NotSupportedException("Use SaveChangesAsync instead");
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			lock (Lock)
			{
				return base.SaveChangesAsync(cancellationToken);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<APCCuttingParametersIHT>().HasNoKey();

            modelBuilder.Entity<CuttingData>().Property(x => x.Id).HasDefaultValueSql(
                @"(lower(hex(randomblob(4))) || '-' || lower(hex(randomblob(2))) || '-4' || substr(lower(hex(randomblob(2))),2) || '-' || substr('89ab',abs(random()) % 4 + 1, 1) || substr(lower(hex(randomblob(2))),2) || '-' || lower(hex(randomblob(6))))"
                );

            modelBuilder.Entity<Gas>().HasData(new Gas { Id = Guid.NewGuid(), GasId = 0, Name = "Propan" });
			modelBuilder.Entity<Gas>().HasData(new Gas { Id = Guid.NewGuid(), GasId = 1, Name = "Acetylene" });
			modelBuilder.Entity<Gas>().HasData(new Gas { Id = Guid.NewGuid(), GasId = 2, Name = "NaturalGas" });

			modelBuilder.Entity<Material>().HasData(new Material { Id = Guid.NewGuid(), Name = "Mild Steel" });

			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ARC 3-40" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ARC 3-70" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PRC 5-40" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PRC 5-70" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 3-5" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 6-10" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 10-25" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 25-40" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 40-60" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 60-100" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 100-150" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 150-230" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 230-300" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 3-6" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 7-15" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 15-25" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 25-40" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 40-60" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 60-100" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 100-150" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 100-200" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 150-200" });			
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 200-250" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 250-300" });


//			this.Database.ExecuteSqlRaw(@"insert into [CuttingData]
// ( MaterialId, NozzleId, Thickness, LeadInLength, Kerf, GasId, CuttingSpeed, IgnitionFlameAdjustment, PI0, PI1, PreHeatHeight, PreHeatHeatingOxygenPressure, 
// PreHeatFuelGasPressure, PreHeatTime, PierceHeight, PierceHeatingOxygenPressure, PierceCuttingOxygenPressure, PierceFuelGasPressure, PierceCuttingSpeedChange, 
// PierceTime, PP0, PP1, PP2, PP3, PP4, CutHeight, CutHeatingOxygenPressure, CutCuttingOxygenPressure, CutFuelGasPressure, Remark, ExtKey, ControlBits ) 
//SELECT Material.Id, Nozzle.Id as NozId, apc.Thickness, apc.LeadInLength, apc.Kerf, Gas.Id as GasId , apc.CuttingSpeed, apc.IgnitionFlameAdjustment, apc.PI0, 
//apc.PI1, apc.PreHeatHeight, apc.PreHeatHeatingOxygenPressure, apc.PreHeatFuelGasPressure, apc.PreHeatTime, apc.PierceHeight, apc.PierceHeatingOxygenPressure, 
//apc.PierceCuttingOxygenPressure, apc.PierceFuelGasPressure, apc.PierceCuttingSpeedChange, apc.PierceTime, apc.PP0, apc.PP1, apc.PP2, apc.PP3, 
//apc.PP4, apc.CutHeight, apc.CutHeatingOxygenPressure, apc.CutCuttingOxygenPressure, apc.CutFuelGasPressure, apc.Remark, apc.ExtKey, apc.ControlBits
//FROM APCCuttingParametersIHT apc LEFT JOIN Nozzle ON apc.Nozzle = Nozzle.Name LEFT JOIN Material ON apc.Material = Material.Name LEFT JOIN Gas on apc.IdGas = Gas.GasId");

		}
	}
}
