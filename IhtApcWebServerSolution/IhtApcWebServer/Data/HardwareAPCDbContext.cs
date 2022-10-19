using Microsoft.EntityFrameworkCore;
using SharedComponents.Models;

namespace IhtApcWebServer.Data
{
	public class HardwareAPCDbContext : DbContext
	{
		private static readonly object Lock = new();

		public DbSet<DynamicParamsInfo> DynamicParams { get; set; } = null!;

		public DbSet<LiveParamsInfo> LiveParams { get; set; } = null!;

		public DbSet<ConstParamsInfo> ConstParams { get; set; } = null!;

		public DbSet<HardwareAPCModel> HardwareAPCModel { get; set; } = null!;


		public HardwareAPCDbContext(DbContextOptions<HardwareAPCDbContext> options)
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
			modelBuilder.Entity<HardwareAPCModel>()
			.HasKey(apc => apc.DeviceId);

			//base.OnModelCreating(modelBuilder);

			//Seed Departments Table
			var DynamicParamsInfoId1 = Guid.NewGuid();
			var DynamicParamsInfoId2 = Guid.NewGuid();
			var DynamicParamsInfoId3 = Guid.NewGuid();

			modelBuilder.Entity<DynamicParamsInfo>().HasData(
				new DynamicParamsInfo { Id = DynamicParamsInfoId1, DynamicParam1 = 1, DynamicParam2 = 1, DynamicParam3 = 1 });

			modelBuilder.Entity<DynamicParamsInfo>().HasData(
				new DynamicParamsInfo { Id = DynamicParamsInfoId2, DynamicParam1 = 2, DynamicParam2 = 2, DynamicParam3 = 2 });

			modelBuilder.Entity<DynamicParamsInfo>().HasData(
				new DynamicParamsInfo { Id = DynamicParamsInfoId3, DynamicParam1 = 3, DynamicParam2 = 3, DynamicParam3 = 3 });

			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			var LiveParamsInfoId1 = Guid.NewGuid();
			var LiveParamsInfoId2 = Guid.NewGuid();
			var LiveParamsInfoId3 = Guid.NewGuid();

			modelBuilder.Entity<LiveParamsInfo>().HasData(
				new LiveParamsInfo { Id = LiveParamsInfoId1, LiveParam1 = 1, LiveParam2 = 1, LiveParam3 = 1 });

			modelBuilder.Entity<LiveParamsInfo>().HasData(
				new LiveParamsInfo { Id = LiveParamsInfoId2, LiveParam1 = 2, LiveParam2 = 2, LiveParam3 = 2 });

			modelBuilder.Entity<LiveParamsInfo>().HasData(
				new LiveParamsInfo { Id = LiveParamsInfoId3, LiveParam1 = 3, LiveParam2 = 3, LiveParam3 = 3 });

			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			var ConstParamsInfoId1 = Guid.NewGuid();
			var ConstParamsInfoId2 = Guid.NewGuid();
			var ConstParamsInfoId3 = Guid.NewGuid();

			modelBuilder.Entity<ConstParamsInfo>().HasData(
				new ConstParamsInfo { Id = ConstParamsInfoId1, ConstParam1 = 1, ConstParam2 = 1, ConstParam3 = 1 });

			modelBuilder.Entity<ConstParamsInfo>().HasData(
				new ConstParamsInfo { Id = ConstParamsInfoId2, ConstParam1 = 2, ConstParam2 = 2, ConstParam3 = 2 });

			modelBuilder.Entity<ConstParamsInfo>().HasData(
				new ConstParamsInfo { Id = ConstParamsInfoId3, ConstParam1 = 3, ConstParam2 = 3, ConstParam3 = 3 });

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            var HardwareAPCModelId1 = Guid.NewGuid();
            var HardwareAPCModelId2 = Guid.NewGuid();
            var HardwareAPCModelId3 = Guid.NewGuid();

            modelBuilder.Entity<HardwareAPCModel>().HasData(
                new HardwareAPCModel
                {
                    DeviceId = HardwareAPCModelId1,
                    DeviceName = "Device1",
                    DynamicParamsId = DynamicParamsInfoId1,
                    LiveParamsId = LiveParamsInfoId1,
                    ConstParamsId = ConstParamsInfoId1
                });

            modelBuilder.Entity<HardwareAPCModel>().HasData(
                new HardwareAPCModel
                {
                    DeviceId = HardwareAPCModelId2,
                    DeviceName = "Device2",
                    DynamicParamsId = DynamicParamsInfoId2,
                    LiveParamsId = LiveParamsInfoId2,
                    ConstParamsId = ConstParamsInfoId2
                });

            modelBuilder.Entity<HardwareAPCModel>().HasData(
                new HardwareAPCModel
                {
                    DeviceId = HardwareAPCModelId3,
                    DeviceName = "Device3",
                    DynamicParamsId = DynamicParamsInfoId3,
                    LiveParamsId = LiveParamsInfoId3,
                    ConstParamsId = ConstParamsInfoId3
                });

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        }
	}
}
