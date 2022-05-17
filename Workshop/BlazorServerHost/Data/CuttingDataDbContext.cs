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
			modelBuilder.Entity<Gas>().HasData(new Gas { Id = 0, Name = "Propan" });
			modelBuilder.Entity<Gas>().HasData(new Gas { Id = 1, Name = "Acetylene" });
			modelBuilder.Entity<Gas>().HasData(new Gas { Id = 2, Name = "NaturalGas" });

			modelBuilder.Entity<Material>().HasData(new Material { Id = Guid.NewGuid(), Name = "Structural Steel" });

			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ARC 3-40" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ARC 3-70" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 100–150" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 10–25" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 150–230" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 230-300" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 25–40" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 3–5" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 40–60" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 60–100" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "ASF 6–10" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PRC 5-40" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PRC 5-70" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 100–200" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 15–25" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 200–250" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 250-300" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 25–40" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 3–6" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 40–60" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 60–100" });
			modelBuilder.Entity<Nozzle>().HasData(new Nozzle { Id = Guid.NewGuid(), Name = "PSF 7–15" });
		}
	}
}
