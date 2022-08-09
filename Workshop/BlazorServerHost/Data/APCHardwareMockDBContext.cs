using Microsoft.EntityFrameworkCore;
using BlazorServerHost.Data.Models.APCHardwareMock;
using SharedComponents.Models.APCHardware;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;

namespace BlazorServerHost.Data
{
	public class APCHardwareMockDBContext : DbContext
	{
		private static readonly object Lock = new();

		public DbSet<APCDevice> APCDevices { get; set; } = null!;

		public DbSet<ConstParams> ConstParams { get; set; } = null!;

		public DbSet<DynParams> DynParams { get; set; } = null!;

		public DbSet<LiveParams> LiveParams { get; set; } = null!;

		public DbSet<ParameterData> ParameterDatas { get; set; } = null!;

		public DbSet<APCSimulationData> APCSimulationDatas { get; set; } = null!;


		public APCHardwareMockDBContext(DbContextOptions<APCHardwareMockDBContext> options)
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

            //modelBuilder.Entity<APCSimulationData>()
            //    .HasIndex(u => u.Address)
            //    .IsUnique();

            //Seed Departments Table
            var APCDeviceId1 = Guid.NewGuid();
			var APCDeviceId2 = Guid.NewGuid();
			var APCDeviceId3 = Guid.NewGuid();

			var APCDeviceList = new List<APCDevice>();

			var APCDevice1 = new APCDevice { Id = APCDeviceId1, Num = 1, Name = "APCDevice_1" };
			APCDeviceList.Add(APCDevice1);
			var APCDevice2 = new APCDevice { Id = APCDeviceId2, Num = 2, Name = "APCDevice_2" };
			APCDeviceList.Add(APCDevice2);
			var APCDevice3 = new APCDevice { Id = APCDeviceId3, Num = 3, Name = "APCDevice_3" };
			APCDeviceList.Add(APCDevice3);

			// var APCDeviceList1 = APCDeviceList.ToDictionary(d => d.Num);
			// var APCDeviceList1 = APCDeviceList.ToArray();

			modelBuilder.Entity<APCDevice>().HasData(APCDeviceList);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            foreach (var device in APCDeviceList)
            {
				if (device.Num > 0)
				{
					CreateParameterDataForDevice(modelBuilder, device);
					CreateParameterDataForSystem(modelBuilder, device);
				}
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            for (var apcDeviceNum = 1; apcDeviceNum <= 10; apcDeviceNum++)
            {
                CreateAPCSimulationDataForDevice(modelBuilder, apcDeviceNum);
            }

        }

        public void CreateAPCSimulationDataForDevice(ModelBuilder modelBuilder, int apcDevice)
        {
            var APCSimulationDataList = new List<APCSimulationData>();

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4000, Value = 264 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4001, Value = 14 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4002, Value = 256 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4003, Value = 65000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4004, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4005, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4006, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4007, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4008, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4009, Value = 0 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4010, Value = 4100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4011, Value = 16 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4012, Value = 4200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4013, Value = 72 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4014, Value = 4300 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4015, Value = 24 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4016, Value = 4400 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4017, Value = 42 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4018, Value = 4450 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4019, Value = 14 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4020, Value = 4500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4021, Value = 48 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4022, Value = 4550 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4023, Value = 16 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4024, Value = 4600 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4025, Value = 42 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4026, Value = 4650 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4027, Value = 14 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4028, Value = 4700 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4029, Value = 22 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4030, Value = 4800 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4031, Value = 11 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4032, Value = 4850 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4033, Value = 7 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4034, Value = 6000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4035, Value = 69 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4036, Value = 6100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4037, Value = 9 });

            // SetDevInfoSimulationData(ref UInt16[] au16DeviceInfo) Device Info
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4100, Value = 35653 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4101, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4102, Value = 12345 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4103, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4104, Value = 0 });
            int fwMinimumVersion = IhtDevices.GetFwMinimumVersion(isRobot: false);
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4105, Value = (UInt16)((fwMinimumVersion & 0xFFFF) >> 8) });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4106, Value = (UInt16)(fwMinimumVersion & 0xFF) });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4107, Value = 9430 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4108, Value = 2 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4109, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4110, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4111, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4112, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4113, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4114, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4115, Value = (UInt16)IhtDevices.TorchType.Propane });

            // SetTechnologySimulationData(ref UInt16[] au16TechnologyConst) Technology Const
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4200, Value = 20 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4201, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4202, Value = 5 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4203, Value = 20 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4204, Value = 500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4205, Value = 5 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4206, Value = 20 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4207, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4208, Value = 5 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4209, Value = 500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4210, Value = 5000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4211, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4212, Value = 500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4213, Value = 5000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4214, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4215, Value = 500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4216, Value = 5000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4217, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4218, Value = 500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4219, Value = 5000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4220, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4221, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4222, Value = 10000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4223, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4224, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4225, Value = 10000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4226, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4227, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4228, Value = 1000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4229, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4230, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4231, Value = 1000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4232, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4233, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4234, Value = 1000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4235, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4236, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4237, Value = 1000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4238, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4239, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4240, Value = 3000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4241, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4242, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4243, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4244, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4245, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4246, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4247, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4248, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4249, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4250, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4251, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4252, Value = 30 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4253, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4254, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4255, Value = 30 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4256, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4257, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4258, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4259, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4260, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4261, Value = 1000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4262, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4263, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4264, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4265, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4266, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4267, Value = 2000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4268, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4269, Value = 50 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4270, Value = 150 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4271, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4272, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4273, Value = 65535 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4274, Value = 1 });

            // SetTechnologySimulationData(ref UInt16[] au16TechnologyDyn) Technology Dyn
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4300, Value = 80 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4301, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4302, Value = 50 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4303, Value = 30 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4304, Value = 2000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4305, Value = 2000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4306, Value = 4000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4307, Value = 2000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4308, Value = 1500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4309, Value = 6000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4310, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4311, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4312, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4313, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4314, Value = 150 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4315, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4316, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4317, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4318, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4319, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4320, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4321, Value = 500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4322, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4323, Value = 460 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4324, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4325, Value = 0 });

            // SetProcessSimulationData(ref UInt16[] au16ProcessConst) Process Const
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4400, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4401, Value = 500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4402, Value = 25 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4403, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4404, Value = 3 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4405, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4406, Value = 500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4407, Value = 5000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4408, Value = 10 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4409, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4410, Value = 1000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4411, Value = 10 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4412, Value = 20 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4413, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4414, Value = 5 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4415, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4416, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4417, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4418, Value = 50 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4419, Value = 150 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4420, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4421, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4422, Value = 3 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4423, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4424, Value = 25 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4425, Value = 150 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4426, Value = 5 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4427, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4428, Value = 50 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4429, Value = 5 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4430, Value = 50 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4431, Value = 300 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4432, Value = 5 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4433, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4434, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4435, Value = 5 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4436, Value = 50 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4437, Value = 150 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4438, Value = 5 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4439, Value = 50 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4440, Value = 150 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4441, Value = 5 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4442, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4443, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4444, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4445, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4446, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4447, Value = 1 });

            // SetProcessSimulationData(ref UInt16[] au16ProcessDyn) Process Dyn 
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4450, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4451, Value = 2 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4452, Value = 500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4453, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4454, Value = 80 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4455, Value = 20 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4456, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4457, Value = 2 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4458, Value = 50 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4459, Value = 25 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4460, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4461, Value = 20 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4462, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4463, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4464, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4465, Value = 1 });

            // SetConfigSimulationData(ref UInt16[] au16ConfigConst) Config Const
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4500, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4501, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4502, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4503, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4504, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4505, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4506, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4507, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4508, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4509, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4510, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4511, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4512, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4513, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4514, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4515, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4516, Value = 20 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4517, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4518, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4519, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4520, Value = 0 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4521, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4522, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4523, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4524, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4525, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4526, Value = 10 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4527, Value = 500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4528, Value = 20000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4529, Value = 10 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4530, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4531, Value = 30 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4532, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4533, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4534, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4535, Value = 5 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4536, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4537, Value = 5000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4538, Value = 10 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4539, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4540, Value = 240 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4541, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4542, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4543, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4544, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4545, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4546, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4547, Value = 1 });

            // SetConfigSimulationData(ref UInt16[] au16ConfigDyn) Config Dyn
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4550, Value = 90 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4551, Value = 45 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4552, Value = 65 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4553, Value = 45 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4554, Value = 35 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4555, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4556, Value = 43 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4557, Value = 95 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4558, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4559, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4560, Value = 1500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4561, Value = 5 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4562, Value = 2500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4563, Value = 240 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4564, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4565, Value = 0 });

            // SetServiceSimulationData(ref UInt16[] au16ServiceConst) Service Const
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4600, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4601, Value = 20 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4602, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4603, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4604, Value = 3000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4605, Value = 100 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4606, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4607, Value = 20 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4608, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4609, Value = 500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4610, Value = 5000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4611, Value = 250 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4612, Value = 50 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4613, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4614, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4615, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4616, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4617, Value = 1 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4618, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4619, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4620, Value = 10 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4621, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4622, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4623, Value = 10 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4624, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4625, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4626, Value = 10 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4627, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4628, Value = 5000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4629, Value = 50 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4630, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4631, Value = 5000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4632, Value = 50 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4633, Value = 1000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4634, Value = 5000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4635, Value = 50 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4636, Value = 1200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4637, Value = 1800 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4638, Value = 50 });

            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4639, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4640, Value = 1 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4641, Value = 1 });

            // SetServiceSimulationData(ref UInt16[] au16ServiceDyn) Service Dyn
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4650, Value = 4 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4651, Value = 1000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4652, Value = 7 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4653, Value = 1000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4654, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4655, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4656, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4657, Value = 50 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4658, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4659, Value = 3200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4660, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4661, Value = 3000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4662, Value = 1400 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4663, Value = 0 });

            // SetProcessInfoSimulationData(ref UInt16[] au16ProcInfo) Process Info
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4700, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4701, Value = 2369 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4702, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4703, Value = 64 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4704, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4705, Value = 4 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4706, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4707, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4708, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4709, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4710, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4711, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4712, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4713, Value = 240 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4714, Value = 239 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4715, Value = 241 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4716, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4717, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4718, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4719, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4720, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4721, Value = (UInt16)IhtModbusData.ePassword.Level_2 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4722, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4723, Value = 0 });

            // SetCmdExecSimulationData(ref UInt16[] au16CmdExec) Cmd Exec
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4800, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4801, Value = 4 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4802, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4803, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4804, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4805, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4806, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4807, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4808, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4809, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4810, Value = 0 });

            // SetSetupExecSimulationData(ref UInt16[] au16SetupExec) Setup Exec
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4850, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4851, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4852, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4853, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4854, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4855, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4856, Value = 0 });

            // 

            modelBuilder.Entity<APCSimulationData>().HasData(APCSimulationDataList);
        }

        public void CreateParameterDataForDevice(ModelBuilder modelBuilder, APCDevice apcDevice)
        {
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			//
			//ConstParams
			//
			//HeatO2IgnitionMin  : FuelGasIgnitionMin
			//HeatO2IgnitionMax  : FuelGasIgnitionMax
			//HeatO2IgnitionStep : FuelGasIgnitionStep
			//
			//HeatO2PreHeatMin  : FuelGasPreHeatMin
			//HeatO2PreHeatMax  : FuelGasPreHeatMax
			//HeatO2PreHeatStep : FuelGasPreHeatStep
			//
			//HeatO2PierceMin   : FuelGasPierceMin  : CutO2PierceMin
			//HeatO2PierceMax   : FuelGasPierceMax  : CutO2PierceMax
			//HeatO2PierceStep  : FuelGasPierceStep : CutO2PierceStep
			//
			//HeatO2CutMin  : FuelGasCutMin  : CutO2CutMin
			//HeatO2CutMax  : FuelGasCutMax  : CutO2CutMax
			//HeatO2CutStep : FuelGasCutStep : CutO2CutStep
			//
			//H-O

			//Technology Params
			var HeatO2Ignition_Const_Id = Guid.NewGuid();
			var HeatO2PreHeat_Const_Id = Guid.NewGuid();
			var HeatO2Pierce_Const_Id = Guid.NewGuid();
			var HeatO2Cut_Const_Id = Guid.NewGuid();

			// Setup Params
			var TactileInitialPosFinding_Const_Id = Guid.NewGuid();
			var DistanceCalibration_Const_Id = Guid.NewGuid();
			var Dynamic_Const_Id = Guid.NewGuid();
			var HeightControlActive_Const_Id = Guid.NewGuid();
			var Off_Const_Id = Guid.NewGuid();
			var HeightPreHeat_Const_Id = Guid.NewGuid();
			var HeightPierce_Const_Id = Guid.NewGuid();
			var HeightCut_Const_Id = Guid.NewGuid();

			var HeatO2Ignition_Const = new ConstParams { Id = HeatO2Ignition_Const_Id, Min = 500, Max = 5000, Step = 10 };
			var HeatO2PreHeat_Const = new ConstParams { Id = HeatO2PreHeat_Const_Id, Min = 500, Max = 5000, Step = 10 };
			var HeatO2Pierce_Const = new ConstParams { Id = HeatO2Pierce_Const_Id, Min = 500, Max = 5000, Step = 10 };
			var HeatO2Cut_Const = new ConstParams { Id = HeatO2Cut_Const_Id, Min = 500, Max = 5000, Step = 10 };

			// Setup Params
			var TactileInitialPosFinding_Const = new ConstParams { Id = TactileInitialPosFinding_Const_Id, Min = 0, Max = 1, Step = 1 };
			var DistanceCalibration_Const = new ConstParams { Id = DistanceCalibration_Const_Id, Min = 0, Max = 100, Step = 10 };
			var Dynamic_Const = new ConstParams { Id = Dynamic_Const_Id, Min = 10, Max = 100, Step = 1 }; 
			var HeightControlActive_Const = new ConstParams { Id = HeightControlActive_Const_Id, Min = 0, Max = 1, Step = 1 }; // Yes/No
			var Off_Const = new ConstParams { Id = Off_Const_Id, Min = 0, Max = 1, Step = 1 }; // Yes/No
            var HeightPreHeat_Const = new ConstParams { Id = HeightPreHeat_Const_Id, Min = 0, Max = 1, Step = 1 }; // Yes/No
			var HeightPierce_Const = new ConstParams { Id = HeightPierce_Const_Id, Min = 0, Max = 1, Step = 1 }; // Yes/No
			var HeightCut_Const = new ConstParams { Id = HeightCut_Const_Id, Min = 0, Max = 1, Step = 1 }; // Yes/No

			modelBuilder.Entity<ConstParams>().HasData(HeatO2Ignition_Const);
			modelBuilder.Entity<ConstParams>().HasData(HeatO2PreHeat_Const);
			modelBuilder.Entity<ConstParams>().HasData(HeatO2Pierce_Const);
			modelBuilder.Entity<ConstParams>().HasData(HeatO2Cut_Const);

			// Setup Params
			modelBuilder.Entity<ConstParams>().HasData(TactileInitialPosFinding_Const);
			modelBuilder.Entity<ConstParams>().HasData(DistanceCalibration_Const);
			modelBuilder.Entity<ConstParams>().HasData(Dynamic_Const);
			modelBuilder.Entity<ConstParams>().HasData(HeightControlActive_Const);
			modelBuilder.Entity<ConstParams>().HasData(Off_Const);
			modelBuilder.Entity<ConstParams>().HasData(HeightPreHeat_Const);
			modelBuilder.Entity<ConstParams>().HasData(HeightPierce_Const);
			modelBuilder.Entity<ConstParams>().HasData(HeightCut_Const);

			//F-G
			var FuelGasIgnition_Const_Id = Guid.NewGuid();
			var FuelGasPreHeat_Const_Id = Guid.NewGuid();
			var FuelGasPierce_Const_Id = Guid.NewGuid();
			var FuelGasCut_Const_Id = Guid.NewGuid();

			var FuelGasIgnition_Const = new ConstParams { Id = FuelGasIgnition_Const_Id, Min = 0, Max = 1000, Step = 10 };
			var FuelGasPreHeat_Const = new ConstParams { Id = FuelGasPreHeat_Const_Id, Min = 0, Max = 1000, Step = 10 };
			var FuelGasPierce_Const = new ConstParams { Id = FuelGasPierce_Const_Id, Min = 0, Max = 1000, Step = 10 };
			var FuelGasCut_Const = new ConstParams { Id = FuelGasCut_Const_Id, Min = 0, Max = 1000, Step = 10 };

			modelBuilder.Entity<ConstParams>().HasData(FuelGasIgnition_Const);
			modelBuilder.Entity<ConstParams>().HasData(FuelGasPreHeat_Const);
			modelBuilder.Entity<ConstParams>().HasData(FuelGasPierce_Const);
			modelBuilder.Entity<ConstParams>().HasData(FuelGasCut_Const);

			//C-O
			var CutO2Pierce_Const_Id = Guid.NewGuid();
			var CutO2Cut_Const_Id = Guid.NewGuid();

			var CutO2Pierce_Const = new ConstParams { Id = CutO2Pierce_Const_Id, Min = 0, Max = 1000, Step = 10 };
			var CutO2Cut_Const = new ConstParams { Id = CutO2Cut_Const_Id, Min = 0, Max = 1000, Step = 10 };

			modelBuilder.Entity<ConstParams>().HasData(CutO2Pierce_Const);
			modelBuilder.Entity<ConstParams>().HasData(CutO2Cut_Const);

			//IgnitionFlameAdjust
			var IgnitionFlameAdjust_Const_Id = Guid.NewGuid();
			var IgnitionFlameAdjust_Const = new ConstParams { Id = IgnitionFlameAdjust_Const_Id, Min = 200, Max = 1000, Step = 1 };

			modelBuilder.Entity<ConstParams>().HasData(IgnitionFlameAdjust_Const);

			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			//DynParams
			//H-O
			var HeatO2Ignition_Dyn_Id = Guid.NewGuid();
			var HeatO2PreHeat_Dyn_Id = Guid.NewGuid();
			var HeatO2Pierce_Dyn_Id = Guid.NewGuid();
			var HeatO2Cut_Dyn_Id = Guid.NewGuid();

			var HeatO2Ignition_Dyn = new DynParams { Id = HeatO2Ignition_Dyn_Id, ParamId = (int)ParamIds.HeatO2Ignition, ConstParamsId = HeatO2Ignition_Const_Id, Value = 2000 };
			var HeatO2PreHeat_Dyn = new DynParams { Id = HeatO2PreHeat_Dyn_Id, ParamId = (int)ParamIds.HeatO2PreHeat, ConstParamsId = HeatO2PreHeat_Const_Id, Value = 2000 };
			var HeatO2Pierce_Dyn = new DynParams { Id = HeatO2Pierce_Dyn_Id, ParamId = (int)ParamIds.HeatO2Pierce, ConstParamsId = HeatO2Pierce_Const_Id, Value = 4000 };
			var HeatO2Cut_Dyn = new DynParams { Id = HeatO2Cut_Dyn_Id, ParamId = (int)ParamIds.HeatO2Cut, ConstParamsId = HeatO2Cut_Const_Id, Value = 2000 };

			modelBuilder.Entity<DynParams>().HasData(HeatO2Ignition_Dyn);
			modelBuilder.Entity<DynParams>().HasData(HeatO2PreHeat_Dyn);
			modelBuilder.Entity<DynParams>().HasData(HeatO2Pierce_Dyn);
			modelBuilder.Entity<DynParams>().HasData(HeatO2Cut_Dyn);

			//F-G
			var FuelGasIgnition_Dyn_Id = Guid.NewGuid();
			var FuelGasPreHeat_Dyn_Id = Guid.NewGuid();
			var FuelGasPierce_Dyn_Id = Guid.NewGuid();
			var FuelGasCut_Dyn_Id = Guid.NewGuid();

			var FuelGasIgnition_Dyn = new DynParams { Id = FuelGasIgnition_Dyn_Id, ParamId = (int)ParamIds.FuelGasIgnition, ConstParamsId = FuelGasIgnition_Const_Id, Value = 200 };
			var FuelGasPreHeat_Dyn = new DynParams { Id = FuelGasPreHeat_Dyn_Id, ParamId = (int)ParamIds.FuelGasPreHeat, ConstParamsId = FuelGasPreHeat_Const_Id, Value = 200 };
			var FuelGasPierce_Dyn = new DynParams { Id = FuelGasPierce_Dyn_Id, ParamId = (int)ParamIds.FuelGasPierce, ConstParamsId = FuelGasPierce_Const_Id, Value = 200 };
			var FuelGasCut_Dyn = new DynParams { Id = FuelGasCut_Dyn_Id, ParamId = (int)ParamIds.FuelGasCut, ConstParamsId = FuelGasCut_Const_Id, Value = 200 };

			modelBuilder.Entity<DynParams>().HasData(FuelGasIgnition_Dyn);
			modelBuilder.Entity<DynParams>().HasData(FuelGasPreHeat_Dyn);
			modelBuilder.Entity<DynParams>().HasData(FuelGasPierce_Dyn);
			modelBuilder.Entity<DynParams>().HasData(FuelGasCut_Dyn);

			//C-O
			var CutO2Pierce_Dyn_Id = Guid.NewGuid();
			var CutO2Cut_Dyn_Id = Guid.NewGuid();

			var CutO2Pierce_Dyn = new DynParams { Id = CutO2Pierce_Dyn_Id, ParamId = (int)ParamIds.CutO2Pierce, ConstParamsId = CutO2Pierce_Const_Id, Value = 1500 };
			var CutO2Cut_Dyn = new DynParams { Id = CutO2Cut_Dyn_Id, ParamId = (int)ParamIds.CutO2Cut, ConstParamsId = CutO2Cut_Const_Id, Value = 6000 };

			modelBuilder.Entity<DynParams>().HasData(CutO2Pierce_Dyn);
			modelBuilder.Entity<DynParams>().HasData(CutO2Cut_Dyn);

			//IgnitionFlameAdjust
			var IgnitionFlameAdjust_Dyn_Id = Guid.NewGuid();
			var IgnitionFlameAdjust_Dyn = new DynParams { Id = IgnitionFlameAdjust_Dyn_Id, ParamId = (int)ParamIds.IgnitionFlameAdjust, ConstParamsId = IgnitionFlameAdjust_Const_Id, Value = 500 };

			modelBuilder.Entity<DynParams>().HasData(IgnitionFlameAdjust_Dyn);

			// Setup Params
			var TactileInitialPosFinding_Dyn_Id = Guid.NewGuid();
			var DistanceCalibration_Dyn_Id = Guid.NewGuid();
			var Dynamic_Dyn_Id = Guid.NewGuid();
			var HeightControlActive_Dyn_Id = Guid.NewGuid();
			var Off_Dyn_Id = Guid.NewGuid();
			var HeightPreHeat_Dyn_Id = Guid.NewGuid();
			var HeightPierce_Dyn_Id = Guid.NewGuid();
			var HeightCut_Dyn_Id = Guid.NewGuid();

			var TactileInitialPosFinding_Dyn = new DynParams { Id = TactileInitialPosFinding_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding, ConstParamsId = TactileInitialPosFinding_Const_Id, Value = 1 };
			var DistanceCalibration_Dyn = new DynParams { Id = DistanceCalibration_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.DistanceCalibration, ConstParamsId = DistanceCalibration_Const_Id, Value = 0 };
			var Dynamic_Dyn = new DynParams { Id = Dynamic_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.Dynamic, ConstParamsId = Dynamic_Const_Id, Value = 35 };
			var HeightControlActive_Dyn = new DynParams { Id = HeightControlActive_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxAdditional.HeightControlActive, ConstParamsId = HeightControlActive_Const_Id, Value = 0 };
			var Off_Dyn = new DynParams { Id = Off_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eStatusHeightCtrl.Off, ConstParamsId = Off_Const_Id, Value = 0 };
			var HeightPreHeat_Dyn = new DynParams { Id = HeightPreHeat_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eStatusHeightCtrl.HeightPreHeat, ConstParamsId = HeightPreHeat_Const_Id, Value = 0 };
			var HeightPierce_Dyn = new DynParams { Id = HeightPierce_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce, ConstParamsId = HeightPierce_Const_Id, Value = 0 };
			var HeightCut_Dyn = new DynParams { Id = HeightCut_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eStatusHeightCtrl.HeightCut, ConstParamsId = HeightCut_Const_Id, Value = 0 };

			modelBuilder.Entity<DynParams>().HasData(TactileInitialPosFinding_Dyn);
			modelBuilder.Entity<DynParams>().HasData(DistanceCalibration_Dyn);
			modelBuilder.Entity<DynParams>().HasData(Dynamic_Dyn);
			modelBuilder.Entity<DynParams>().HasData(HeightControlActive_Dyn);
			modelBuilder.Entity<DynParams>().HasData(Off_Dyn);
			modelBuilder.Entity<DynParams>().HasData(HeightPreHeat_Dyn);
			modelBuilder.Entity<DynParams>().HasData(HeightPierce_Dyn);
			modelBuilder.Entity<DynParams>().HasData(HeightCut_Dyn);
			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			//ParameterData

			var ParameterData_HeatO2Ignition = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2Ignition", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = HeatO2Ignition_Dyn_Id };
			var ParameterData_HeatO2PreHeat = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2PreHeat", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = HeatO2PreHeat_Dyn_Id };
			var ParameterData_HeatO2Pierce = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2Pierce", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = HeatO2Pierce_Dyn_Id };
			var ParameterData_HeatO2Cut = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2Cut", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = HeatO2Cut_Dyn_Id };
			var ParameterData_FuelGasIgnition = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasIgnition", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = FuelGasIgnition_Dyn_Id };
			var ParameterData_FuelGasPreHeat = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasPreHeat", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = FuelGasPreHeat_Dyn_Id };
			var ParameterData_FuelGasPierce = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasPierce", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = FuelGasPierce_Dyn_Id };
			var ParameterData_FuelGasCut = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasCut", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = FuelGasCut_Dyn_Id };
			var ParameterData_CutO2Pierce = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutO2Pierce", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = CutO2Pierce_Dyn_Id };
			var ParameterData_CutO2Cut = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutO2Cut", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = CutO2Cut_Dyn_Id };
			var ParameterData_IgnitionFlameAdjust = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_IgnitionFlameAdjust", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = IgnitionFlameAdjust_Dyn_Id };

			var ParameterData_TactileInitialPosFinding = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_TactileInitialPosFinding", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = TactileInitialPosFinding_Dyn_Id };
			var ParameterData_DistanceCalibration = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_DistanceCalibration", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = DistanceCalibration_Dyn_Id };
			var ParameterData_Dynamic = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_Dynamic", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = Dynamic_Dyn_Id };
			var ParameterData_HeightControlActive = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeightControlActive", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Additional, DynParamsId = HeightControlActive_Dyn_Id };
			var ParameterData_Off = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_Off", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.StatusHeightCtrl, DynParamsId = Off_Dyn_Id };
			var ParameterData_HeightPreHeat = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeightPreHeat", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.StatusHeightCtrl, DynParamsId = HeightPreHeat_Dyn_Id };
			var ParameterData_HeightPierce = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeightPierce", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.StatusHeightCtrl, DynParamsId = HeightPierce_Dyn_Id };
			var ParameterData_HeightCut = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeightCut", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.StatusHeightCtrl, DynParamsId = HeightCut_Dyn_Id };


			modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeatO2Ignition);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeatO2PreHeat);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeatO2Pierce);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeatO2Cut);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_FuelGasIgnition);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_FuelGasPreHeat);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_FuelGasPierce);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_FuelGasCut);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_CutO2Pierce);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_CutO2Cut);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_IgnitionFlameAdjust);

			modelBuilder.Entity<ParameterData>().HasData(ParameterData_TactileInitialPosFinding);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_DistanceCalibration);			
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_Dynamic);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeightControlActive);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_Off);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeightPreHeat);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeightPierce);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeightCut);
		}

		public void CreateParameterDataForSystem(ModelBuilder modelBuilder, APCDevice apcDevice)
        {
			var RetractHeight_Const_Id = Guid.NewGuid();
			var RetractPosition_Const_Id = Guid.NewGuid();
			var SlagSensitivity_Const_Id = Guid.NewGuid();
			var SlagPostTime_Const_Id = Guid.NewGuid();
			var SlagCuttingSpeedReduction_Const_Id = Guid.NewGuid();
			var StartPreflow_Const_Id = Guid.NewGuid();
			var PreflowActive_Const_Id = Guid.NewGuid();
			var PiercingHeightControl_Const_Id = Guid.NewGuid();
			var PiercingDetection_Const_Id = Guid.NewGuid();
			var CutO2BlowOutTime_Const_Id = Guid.NewGuid();
			var CutO2BlowOutPressure_Const_Id = Guid.NewGuid();
			var CutO2BlowOutTimeOut_Const_Id = Guid.NewGuid();

			var RetractHeight_Const = new ConstParams { Id = RetractHeight_Const_Id, Min = 0, Max = 500, Step = 25 }; // System param
			var RetractPosition_Const = new ConstParams { Id = RetractPosition_Const_Id, Min = 0, Max = 1, Step = 1 }; // System param - Enabled/Disabled
			var SlagSensitivity_Const = new ConstParams { Id = SlagSensitivity_Const_Id, Min = 0, Max = 3, Step = 1 }; // System param - Off/Low/Default/High
			var SlagPostTime_Const = new ConstParams { Id = SlagPostTime_Const_Id, Min = 0, Max = 100, Step = 5 }; // System param
			var SlagCuttingSpeedReduction_Const = new ConstParams { Id = SlagCuttingSpeedReduction_Const_Id, Min = 50, Max = 100, Step = 1 }; // System param
			var StartPreflow_Const = new ConstParams { Id = StartPreflow_Const_Id, Min = 0, Max = 1, Step = 1 }; // System param - Yes/No
			var PreflowActive_Const = new ConstParams { Id = PreflowActive_Const_Id, Min = 0, Max = 1, Step = 1 }; // System param - Yes/No
			var PiercingHeightControl_Const = new ConstParams { Id = PiercingHeightControl_Const_Id, Min = 0, Max = 1, Step = 1 }; // System param - Enabled/Disabled
			var PiercingDetection_Const = new ConstParams { Id = PiercingDetection_Const_Id, Min = 0, Max = 1, Step = 1 }; // System param - Enabled/Disabled
			var CutO2BlowOutTime_Const = new ConstParams { Id = CutO2BlowOutTime_Const_Id, Min = 0, Max = 30, Step = 1 }; 
			var CutO2BlowOutPressure_Const = new ConstParams { Id = CutO2BlowOutPressure_Const_Id, Min = 0, Max = 5000, Step = 10 }; 
			var CutO2BlowOutTimeOut_Const = new ConstParams { Id = CutO2BlowOutTimeOut_Const_Id, Min = 0, Max = 240, Step = 1 }; 

			modelBuilder.Entity<ConstParams>().HasData(RetractHeight_Const);
			modelBuilder.Entity<ConstParams>().HasData(RetractPosition_Const);
			modelBuilder.Entity<ConstParams>().HasData(SlagSensitivity_Const);
			modelBuilder.Entity<ConstParams>().HasData(SlagPostTime_Const);
			modelBuilder.Entity<ConstParams>().HasData(SlagCuttingSpeedReduction_Const);
			modelBuilder.Entity<ConstParams>().HasData(StartPreflow_Const);
			modelBuilder.Entity<ConstParams>().HasData(PreflowActive_Const);
			modelBuilder.Entity<ConstParams>().HasData(PiercingHeightControl_Const);
			modelBuilder.Entity<ConstParams>().HasData(PiercingDetection_Const);
			modelBuilder.Entity<ConstParams>().HasData(CutO2BlowOutTime_Const);
			modelBuilder.Entity<ConstParams>().HasData(CutO2BlowOutPressure_Const);
			modelBuilder.Entity<ConstParams>().HasData(CutO2BlowOutTimeOut_Const);

			var RetractHeight_Dyn_Id = Guid.NewGuid();
			var RetractPosition_Dyn_Id = Guid.NewGuid();
			var SlagSensitivity_Dyn_Id = Guid.NewGuid();
			var SlagPostTime_Dyn_Id = Guid.NewGuid();
			var SlagCuttingSpeedReduction_Dyn_Id = Guid.NewGuid();
			var StartPreflow_Dyn_Id = Guid.NewGuid();
			var PreflowActive_Dyn_Id = Guid.NewGuid();
			var PiercingHeightControl_Dyn_Id = Guid.NewGuid();
			var PiercingDetection_Dyn_Id = Guid.NewGuid();
			var CutO2BlowOutTime_Dyn_Id = Guid.NewGuid();
			var CutO2BlowOutPressure_Dyn_Id = Guid.NewGuid();
			var CutO2BlowOutTimeOut_Dyn_Id = Guid.NewGuid();

			var RetractHeight_Dyn = new DynParams { Id = RetractHeight_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.RetractHeight, ConstParamsId = RetractHeight_Const_Id, Value = 100 };
			var RetractPosition_Dyn = new DynParams { Id = RetractPosition_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxAdditional.RetractPosition, ConstParamsId = RetractPosition_Const_Id, Value = 0 };
			var SlagSensitivity_Dyn = new DynParams { Id = SlagSensitivity_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.SlagSensitivity, ConstParamsId = SlagSensitivity_Const_Id, Value = 2 };
			var SlagPostTime_Dyn = new DynParams { Id = SlagPostTime_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.SlagPostTime, ConstParamsId = SlagPostTime_Const_Id, Value = 20 };
			var SlagCuttingSpeedReduction_Dyn = new DynParams { Id = SlagCuttingSpeedReduction_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction, ConstParamsId = SlagCuttingSpeedReduction_Const_Id, Value = 100 };
			var StartPreflow_Dyn = new DynParams { Id = StartPreflow_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxAdditional.StartPreflow, ConstParamsId = StartPreflow_Const_Id, Value = 0 };
			var PreflowActive_Dyn = new DynParams { Id = PreflowActive_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxAdditional.PreflowActive, ConstParamsId = PreflowActive_Const_Id, Value = 0 };
			var PiercingHeightControl_Dyn = new DynParams { Id = PiercingHeightControl_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxAdditional.PiercingHeightControl, ConstParamsId = PiercingHeightControl_Const_Id, Value = 0 };
			var PiercingDetection_Dyn = new DynParams { Id = PiercingDetection_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxAdditional.PiercingDetection, ConstParamsId = PiercingDetection_Const_Id, Value = 0 };
			var CutO2BlowOutTime_Dyn = new DynParams { Id = CutO2BlowOutTime_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime, ConstParamsId = CutO2BlowOutTime_Const_Id, Value = 5 };
			var CutO2BlowOutPressure_Dyn = new DynParams { Id = CutO2BlowOutPressure_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure, ConstParamsId = CutO2BlowOutPressure_Const_Id, Value = 2500 };
			var CutO2BlowOutTimeOut_Dyn = new DynParams { Id = CutO2BlowOutTimeOut_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut, ConstParamsId = CutO2BlowOutTimeOut_Const_Id, Value = 240 };

			modelBuilder.Entity<DynParams>().HasData(RetractHeight_Dyn);
			modelBuilder.Entity<DynParams>().HasData(RetractPosition_Dyn);
			modelBuilder.Entity<DynParams>().HasData(SlagSensitivity_Dyn);
			modelBuilder.Entity<DynParams>().HasData(SlagPostTime_Dyn);
			modelBuilder.Entity<DynParams>().HasData(SlagCuttingSpeedReduction_Dyn);
			modelBuilder.Entity<DynParams>().HasData(StartPreflow_Dyn);
			modelBuilder.Entity<DynParams>().HasData(PreflowActive_Dyn);
			modelBuilder.Entity<DynParams>().HasData(PiercingHeightControl_Dyn);
			modelBuilder.Entity<DynParams>().HasData(PiercingDetection_Dyn);
			modelBuilder.Entity<DynParams>().HasData(CutO2BlowOutTime_Dyn);
			modelBuilder.Entity<DynParams>().HasData(CutO2BlowOutPressure_Dyn);
			modelBuilder.Entity<DynParams>().HasData(CutO2BlowOutTimeOut_Dyn);

			var ParameterData_RetractHeight = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_RetractHeight", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = RetractHeight_Dyn_Id };
			var ParameterData_RetractPosition = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_RetractPosition", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Additional, DynParamsId = RetractPosition_Dyn_Id };
			var ParameterData_SlagSensitivity = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagSensitivity", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = SlagSensitivity_Dyn_Id };
			var ParameterData_SlagPostTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagPostTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = SlagPostTime_Dyn_Id };
			var ParameterData_SlagCuttingSpeedReduction = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagCuttingSpeedReduction", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = SlagCuttingSpeedReduction_Dyn_Id };
			var ParameterData_StartPreflow = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_StartPreflow", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Additional, DynParamsId = StartPreflow_Dyn_Id };
			var ParameterData_PreflowActive = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PreflowActive", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Additional, DynParamsId = PreflowActive_Dyn_Id };
			var ParameterData_PiercingHeightControl = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PiercingHeightControl", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Additional, DynParamsId = PiercingHeightControl_Dyn_Id };
			var ParameterData_PiercingDetection = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PiercingDetection", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Additional, DynParamsId = PiercingDetection_Dyn_Id };
			var ParameterData_CutO2BlowOutTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutO2BlowOutTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = CutO2BlowOutTime_Dyn_Id };
			var ParameterData_CutO2BlowOutPressure = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutO2BlowOutPressure", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = CutO2BlowOutPressure_Dyn_Id };
			var ParameterData_CutO2BlowOutTimeOut = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutO2BlowOutTimeOut", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = CutO2BlowOutTimeOut_Dyn_Id };

			modelBuilder.Entity<ParameterData>().HasData(ParameterData_RetractHeight);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_RetractPosition);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagSensitivity);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagPostTime);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagCuttingSpeedReduction);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_StartPreflow);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_PreflowActive);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_PiercingHeightControl);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_PiercingDetection);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_CutO2BlowOutTime);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_CutO2BlowOutPressure);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_CutO2BlowOutTimeOut);
		}
	}
}
