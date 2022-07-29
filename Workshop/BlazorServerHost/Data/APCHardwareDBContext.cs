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

		public DbSet<ViewParamGroup> ViewGroups { get; set; } = null!;

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
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);

			//Seed Departments Table
			// TO DO: Add Indexes to the tables
			modelBuilder.Entity<ParameterData>()
				.HasOne(pd => pd.APCDevice)
				.WithMany(d => d.parameterDatas)
				.HasForeignKey(t => t.APCDeviceId);


			////////////////////////////////////////////

			var ViewParamGroupId1 = Guid.NewGuid();
			var ViewParamGroupId2 = Guid.NewGuid();
			var ViewParamGroupId3 = Guid.NewGuid();
			var ViewParamGroupId4 = Guid.NewGuid();
			var ViewParamGroupId5 = Guid.NewGuid();
			var ViewParamGroupId6 = Guid.NewGuid();

			var ViewParamGroupList = new List<ViewParamGroup>();

			var ViewParamGroup1 = new ViewParamGroup { Id = ViewParamGroupId1, Name = "Height Calibration", ViewOrder = 1 };
			ViewParamGroupList.Add(ViewParamGroup1);
			var ViewParamGroup2 = new ViewParamGroup { Id = ViewParamGroupId2, Name = "Retract Position", ViewOrder = 2 };
			ViewParamGroupList.Add(ViewParamGroup2);
			var ViewParamGroup3 = new ViewParamGroup { Id = ViewParamGroupId3, Name = "Slag", ViewOrder = 3 };
			ViewParamGroupList.Add(ViewParamGroup3);
			var ViewParamGroup4 = new ViewParamGroup { Id = ViewParamGroupId4, Name = "Pre Flow", ViewOrder = 4 };
			ViewParamGroupList.Add(ViewParamGroup4);
			var ViewParamGroup5 = new ViewParamGroup { Id = ViewParamGroupId5, Name = "Piercing", ViewOrder = 5 };
			ViewParamGroupList.Add(ViewParamGroup5);
			var ViewParamGroup6 = new ViewParamGroup { Id = ViewParamGroupId6, Name = "Height Control", ViewOrder = 6 };
			ViewParamGroupList.Add(ViewParamGroup6);

			modelBuilder.Entity<APCDevice>().HasData(ViewParamGroupList);
		}
	}
}


