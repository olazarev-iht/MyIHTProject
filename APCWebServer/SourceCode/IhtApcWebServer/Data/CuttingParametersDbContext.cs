using Microsoft.EntityFrameworkCore;

namespace IhtApcWebServer.Data
{
	public class CuttingParametersDbContext : DbContext
	{
		private static readonly object Lock = new();

		public DbSet<CuttingParameterSet> CuttingParameters { get; set; } = null!;

		public CuttingParametersDbContext(DbContextOptions<CuttingParametersDbContext> options)
			: base(options)
		{
		}

		public override int SaveChanges()
		{
			throw new NotSupportedException("Use SaveChangesAsync instead");
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			lock(Lock)
			{
				return base.SaveChangesAsync(cancellationToken);
			}
		}
	}

	public class CuttingParameterSet
	{
		public Guid Id { get; set; }
		public float Thickness { get; set; }
		public float HeatingHeight { get; set; }
		public float CuttingHeight { get; set; }
	}
}
