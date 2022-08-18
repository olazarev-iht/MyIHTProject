using Microsoft.EntityFrameworkCore;
using BlazorServerHost.Data.Models.APCHardware;
using SharedComponents.Models.APCHardware;

namespace BlazorServerHost.Data
{
	public class APCHardwareDBContext : DbContext
	{
		private static readonly object Lock = new();

		public DbSet<APCDevice> APCDevices { get; set; } = null!;

		public DbSet<ConstParams> ConstParams { get; set; } = null!;

		public DbSet<DynParams> DynParams { get; set; } = null!;

		public DbSet<LiveParams> LiveParams { get; set; } = null!;

		public DbSet<ParameterData> ParameterDatas { get; set; } = null!;

		public DbSet<ParameterDataInfo> ParameterDataInfos { get; set; } = null!;

		public APCHardwareDBContext(DbContextOptions<APCHardwareDBContext> options)
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

				//return Task.FromResult(0);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);

			//Seed Departments Table

			//modelBuilder.Entity<ParameterData>()
			//	.HasOne(pd => pd.APCDevice)
			//	.WithMany(d => d.parameterDatas)
			//	.HasForeignKey(t => t.APCDeviceId);

			//Seed Departments Table
			var APCDeviceId1 = Guid.NewGuid();
			var APCDeviceId2 = Guid.NewGuid();
			var APCDeviceId3 = Guid.NewGuid();
			var APCDeviceId4 = Guid.NewGuid();
			var APCDeviceId5 = Guid.NewGuid();
			var APCDeviceId6 = Guid.NewGuid();
			var APCDeviceId7 = Guid.NewGuid();
			var APCDeviceId8 = Guid.NewGuid();
			var APCDeviceId9 = Guid.NewGuid();
			var APCDeviceId10 = Guid.NewGuid();

			var APCDeviceList = new List<APCDevice>();

			var APCDevice1 = new APCDevice { Id = APCDeviceId1, Num = 1, Name = "APCDevice_1" };
			APCDeviceList.Add(APCDevice1);
			var APCDevice2 = new APCDevice { Id = APCDeviceId2, Num = 2, Name = "APCDevice_2" };
			APCDeviceList.Add(APCDevice2);
			var APCDevice3 = new APCDevice { Id = APCDeviceId3, Num = 3, Name = "APCDevice_3" };
			APCDeviceList.Add(APCDevice3);
			var APCDevice4 = new APCDevice { Id = APCDeviceId4, Num = 4, Name = "APCDevice_4" };
			APCDeviceList.Add(APCDevice4);
			var APCDevice5 = new APCDevice { Id = APCDeviceId5, Num = 5, Name = "APCDevice_5" };
			APCDeviceList.Add(APCDevice5);
			var APCDevice6 = new APCDevice { Id = APCDeviceId6, Num = 6, Name = "APCDevice_6" };
			APCDeviceList.Add(APCDevice6);
			var APCDevice7 = new APCDevice { Id = APCDeviceId7, Num = 7, Name = "APCDevice_7" };
			APCDeviceList.Add(APCDevice7);
			var APCDevice8 = new APCDevice { Id = APCDeviceId8, Num = 8, Name = "APCDevice_8" };
			APCDeviceList.Add(APCDevice8);
			var APCDevice9 = new APCDevice { Id = APCDeviceId9, Num = 9, Name = "APCDevice_9" };
			APCDeviceList.Add(APCDevice9);
			var APCDevice10 = new APCDevice { Id = APCDeviceId10, Num = 10, Name = "APCDevice_10" };
			APCDeviceList.Add(APCDevice10);


			// var APCDeviceList1 = APCDeviceList.ToDictionary(d => d.Num);
			// var APCDeviceList1 = APCDeviceList.ToArray();

			modelBuilder.Entity<APCDevice>().HasData(APCDeviceList);
		}
	}
}


