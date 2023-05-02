using Microsoft.EntityFrameworkCore;
using IhtApcWebServer.Data.Models.CuttingData;

namespace IhtApcWebServer.Data
{
    public class CuttingDataArchiveDbContext : DbContext
    {
        private static readonly object Lock = new();

        public DbSet<Gas> Gas { get; set; } = null!;
        public DbSet<Material> Material { get; set; } = null!;
        public DbSet<Nozzle> Nozzle { get; set; } = null!;
        public DbSet<CuttingData> CuttingData { get; set; } = null!;
        public DbSet<APCCuttingParametersIHT> APCCuttingParametersIHT { get; set; } = null!;
        public DbSet<CustomCounter> CustomCounter { get; set; } = null!;

        public CuttingDataArchiveDbContext(DbContextOptions<CuttingDataArchiveDbContext> options)
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

            modelBuilder.Entity<CuttingData>().Property(f => f.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<CustomCounter>().HasData(new CustomCounter { Id = Guid.NewGuid(), CounterId = 1 });
        }
    }
}
