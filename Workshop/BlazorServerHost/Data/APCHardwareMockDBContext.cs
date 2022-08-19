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

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            foreach (var device in APCDeviceList)
            {
				if (device.Num > 0)
				{
					CreateParameterDataForDevice(modelBuilder, device);
					//CreateParameterDataForSystem(modelBuilder, device);
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
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4303, Value = 2000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4304, Value = 2000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4305, Value = 4000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4306, Value = 2000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4307, Value = 1500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4308, Value = 6000 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4309, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4310, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4311, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4312, Value = 200 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4313, Value = 150 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4314, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4315, Value = 10 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4316, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4317, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4318, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4319, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4320, Value = 500 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4321, Value = 0 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4322, Value = 460 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4323, Value = 100 });
            APCSimulationDataList.Add(new APCSimulationData { Id = Guid.NewGuid(), Device = apcDevice, Address = 4324, Value = 0 });

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

            //Technology Params Const
            var PreHeatHeight_Const_Id = Guid.NewGuid();
            var PierceHeight_Const_Id = Guid.NewGuid();
            var CutHeight_Const_Id = Guid.NewGuid();
            var HeatO2Ignition_Const_Id = Guid.NewGuid();
			var HeatO2PreHeat_Const_Id = Guid.NewGuid();
			var HeatO2Pierce_Const_Id = Guid.NewGuid();
			var HeatO2Cut_Const_Id = Guid.NewGuid();
            var CutO2Pierce_Const_Id = Guid.NewGuid();
            var CutO2Cut_Const_Id = Guid.NewGuid();
            var FuelGasIgnition_Const_Id = Guid.NewGuid();
            var FuelGasPreHeat_Const_Id = Guid.NewGuid();
            var FuelGasPierce_Const_Id = Guid.NewGuid();
            var FuelGasCut_Const_Id = Guid.NewGuid();
            var PreHeatTime_Const_Id = Guid.NewGuid();
            var PiercePreTime_Const_Id = Guid.NewGuid();
            var PierceTime_Const_Id = Guid.NewGuid();
            var PiercePostTime_Const_Id = Guid.NewGuid();
            var PierceHeightRampTime_Const_Id = Guid.NewGuid();
            var CutHeightRampTime_Const_Id = Guid.NewGuid();
            var PierceMode_Const_Id = Guid.NewGuid();
            var IgnitionFlameAdjust_Const_Id = Guid.NewGuid();
            var GasType_Const_Id = Guid.NewGuid();
            var CuttingSpeed_Const_Id = Guid.NewGuid();
            var PierceCuttingSpeedChange_Const_Id = Guid.NewGuid();
            var ControlBits_Const_Id = Guid.NewGuid();

            var PreHeatHeight_Const = new ConstParams { Id = PreHeatHeight_Const_Id, Min = 20, Max = 200, Step = 5 };
            var PierceHeight_Const = new ConstParams { Id = PierceHeight_Const_Id, Min = 20, Max = 500, Step = 5 };
            var CutHeight_Const = new ConstParams { Id = CutHeight_Const_Id, Min = 500, Max = 5000, Step = 10 };
            var HeatO2Ignition_Const = new ConstParams { Id = HeatO2Ignition_Const_Id, Min = 500, Max = 5000, Step = 10 };
			var HeatO2PreHeat_Const = new ConstParams { Id = HeatO2PreHeat_Const_Id, Min = 500, Max = 5000, Step = 10 };
			var HeatO2Pierce_Const = new ConstParams { Id = HeatO2Pierce_Const_Id, Min = 500, Max = 5000, Step = 10 };
			var HeatO2Cut_Const = new ConstParams { Id = HeatO2Cut_Const_Id, Min = 500, Max = 5000, Step = 10 };
            var CutO2Pierce_Const = new ConstParams { Id = CutO2Pierce_Const_Id, Min = 0, Max = 1000, Step = 10 };
            var CutO2Cut_Const = new ConstParams { Id = CutO2Cut_Const_Id, Min = 0, Max = 1000, Step = 10 };
            var FuelGasIgnition_Const = new ConstParams { Id = FuelGasIgnition_Const_Id, Min = 0, Max = 1000, Step = 10 };
            var FuelGasPreHeat_Const = new ConstParams { Id = FuelGasPreHeat_Const_Id, Min = 0, Max = 1000, Step = 10 };
            var FuelGasPierce_Const = new ConstParams { Id = FuelGasPierce_Const_Id, Min = 0, Max = 1000, Step = 10 };
            var FuelGasCut_Const = new ConstParams { Id = FuelGasCut_Const_Id, Min = 0, Max = 1000, Step = 10 };
            var PreHeatTime_Const = new ConstParams { Id = PreHeatTime_Const_Id, Min = 0, Max = 3000, Step = 10 };
            var PiercePreTime_Const = new ConstParams { Id = PiercePreTime_Const_Id, Min = 0, Max = 100, Step = 1 };
            var PierceTime_Const = new ConstParams { Id = PierceTime_Const_Id, Min = 0, Max = 100, Step = 1 };
            var PiercePostTime_Const = new ConstParams { Id = PiercePostTime_Const_Id, Min = 0, Max = 100, Step = 1 };
            var PierceHeightRampTime_Const = new ConstParams { Id = PierceHeightRampTime_Const_Id, Min = 0, Max = 30, Step = 1 };
            var CutHeightRampTime_Const = new ConstParams { Id = CutHeightRampTime_Const_Id, Min = 0, Max = 30, Step = 1 };
            var PierceMode_Const = new ConstParams { Id = PierceMode_Const_Id, Min = 0, Max = 1, Step = 1 };
            var IgnitionFlameAdjust_Const = new ConstParams { Id = IgnitionFlameAdjust_Const_Id, Min = 200, Max = 1000, Step = 1 };
            var GasType_Const = new ConstParams { Id = GasType_Const_Id, Min = 0, Max = 1, Step = 1 };
            var CuttingSpeed_Const = new ConstParams { Id = CuttingSpeed_Const_Id, Min = 0, Max = 2000, Step = 1 };
            var PierceCuttingSpeedChange_Const = new ConstParams { Id = PierceCuttingSpeedChange_Const_Id, Min = 50, Max = 150, Step = 1 };
            var ControlBits_Const = new ConstParams { Id = ControlBits_Const_Id, Min = 0, Max = 65535, Step = 1 };

            modelBuilder.Entity<ConstParams>().HasData(PreHeatHeight_Const);
            modelBuilder.Entity<ConstParams>().HasData(PierceHeight_Const);
            modelBuilder.Entity<ConstParams>().HasData(CutHeight_Const);
            modelBuilder.Entity<ConstParams>().HasData(HeatO2Ignition_Const);
            modelBuilder.Entity<ConstParams>().HasData(HeatO2PreHeat_Const);
            modelBuilder.Entity<ConstParams>().HasData(HeatO2Pierce_Const);
            modelBuilder.Entity<ConstParams>().HasData(HeatO2Cut_Const);
            modelBuilder.Entity<ConstParams>().HasData(CutO2Pierce_Const);
            modelBuilder.Entity<ConstParams>().HasData(CutO2Cut_Const);
            modelBuilder.Entity<ConstParams>().HasData(FuelGasIgnition_Const);
            modelBuilder.Entity<ConstParams>().HasData(FuelGasPreHeat_Const);
            modelBuilder.Entity<ConstParams>().HasData(FuelGasPierce_Const);
            modelBuilder.Entity<ConstParams>().HasData(FuelGasCut_Const);
            modelBuilder.Entity<ConstParams>().HasData(PreHeatTime_Const);
            modelBuilder.Entity<ConstParams>().HasData(PiercePreTime_Const);
            modelBuilder.Entity<ConstParams>().HasData(PierceTime_Const);
            modelBuilder.Entity<ConstParams>().HasData(PiercePostTime_Const);
            modelBuilder.Entity<ConstParams>().HasData(PierceHeightRampTime_Const);
            modelBuilder.Entity<ConstParams>().HasData(CutHeightRampTime_Const);
            modelBuilder.Entity<ConstParams>().HasData(PierceMode_Const);
            modelBuilder.Entity<ConstParams>().HasData(IgnitionFlameAdjust_Const);
            modelBuilder.Entity<ConstParams>().HasData(GasType_Const);
            modelBuilder.Entity<ConstParams>().HasData(CuttingSpeed_Const);
            modelBuilder.Entity<ConstParams>().HasData(PierceCuttingSpeedChange_Const);
            modelBuilder.Entity<ConstParams>().HasData(ControlBits_Const);

            //Technology Params Dyn
            var PreHeatHeight_Dyn_Id = Guid.NewGuid();
            var PierceHeight_Dyn_Id = Guid.NewGuid();
            var CutHeight_Dyn_Id = Guid.NewGuid();
            var HeatO2Ignition_Dyn_Id = Guid.NewGuid();
            var HeatO2PreHeat_Dyn_Id = Guid.NewGuid();
            var HeatO2Pierce_Dyn_Id = Guid.NewGuid();
            var HeatO2Cut_Dyn_Id = Guid.NewGuid();
            var CutO2Pierce_Dyn_Id = Guid.NewGuid();
            var CutO2Cut_Dyn_Id = Guid.NewGuid();
            var FuelGasIgnition_Dyn_Id = Guid.NewGuid();
            var FuelGasPreHeat_Dyn_Id = Guid.NewGuid();
            var FuelGasPierce_Dyn_Id = Guid.NewGuid();
            var FuelGasCut_Dyn_Id = Guid.NewGuid();
            var PreHeatTime_Dyn_Id = Guid.NewGuid();
            var PiercePreTime_Dyn_Id = Guid.NewGuid();
            var PierceTime_Dyn_Id = Guid.NewGuid();
            var PiercePostTime_Dyn_Id = Guid.NewGuid();
            var PierceHeightRampTime_Dyn_Id = Guid.NewGuid();
            var CutHeightRampTime_Dyn_Id = Guid.NewGuid();
            var PierceMode_Dyn_Id = Guid.NewGuid();
            var IgnitionFlameAdjust_Dyn_Id = Guid.NewGuid();
            var GasType_Dyn_Id = Guid.NewGuid();
            var CuttingSpeed_Dyn_Id = Guid.NewGuid();
            var PierceCuttingSpeedChange_Dyn_Id = Guid.NewGuid();
            var ControlBits_Dyn_Id = Guid.NewGuid();

            var PreHeatHeight_Dyn = new DynParams { Id = PreHeatHeight_Dyn_Id, ParamId = (int)ParamIds.PreHeatHeight, ConstParamsId = PreHeatHeight_Const_Id, Value = 80 };
            var PierceHeight_Dyn = new DynParams { Id = PierceHeight_Dyn_Id, ParamId = (int)ParamIds.PierceHeight, ConstParamsId = PierceHeight_Const_Id, Value = 100 };
            var CutHeight_Dyn = new DynParams { Id = CutHeight_Dyn_Id, ParamId = (int)ParamIds.CutHeight, ConstParamsId = CutHeight_Const_Id, Value = 50 };
            var HeatO2Ignition_Dyn = new DynParams { Id = HeatO2Ignition_Dyn_Id, ParamId = (int)ParamIds.HeatO2Ignition, ConstParamsId = HeatO2Ignition_Const_Id, Value = 2000 };
            var HeatO2PreHeat_Dyn = new DynParams { Id = HeatO2PreHeat_Dyn_Id, ParamId = (int)ParamIds.HeatO2PreHeat, ConstParamsId = HeatO2PreHeat_Const_Id, Value = 2000 };
            var HeatO2Pierce_Dyn = new DynParams { Id = HeatO2Pierce_Dyn_Id, ParamId = (int)ParamIds.HeatO2Pierce, ConstParamsId = HeatO2Pierce_Const_Id, Value = 4000 };
            var HeatO2Cut_Dyn = new DynParams { Id = HeatO2Cut_Dyn_Id, ParamId = (int)ParamIds.HeatO2Cut, ConstParamsId = HeatO2Cut_Const_Id, Value = 2000 };
            var CutO2Pierce_Dyn = new DynParams { Id = CutO2Pierce_Dyn_Id, ParamId = (int)ParamIds.CutO2Pierce, ConstParamsId = CutO2Pierce_Const_Id, Value = 1500 };
            var CutO2Cut_Dyn = new DynParams { Id = CutO2Cut_Dyn_Id, ParamId = (int)ParamIds.CutO2Cut, ConstParamsId = CutO2Cut_Const_Id, Value = 6000 };
            var FuelGasIgnition_Dyn = new DynParams { Id = FuelGasIgnition_Dyn_Id, ParamId = (int)ParamIds.FuelGasIgnition, ConstParamsId = FuelGasIgnition_Const_Id, Value = 200 };
            var FuelGasPreHeat_Dyn = new DynParams { Id = FuelGasPreHeat_Dyn_Id, ParamId = (int)ParamIds.FuelGasPreHeat, ConstParamsId = FuelGasPreHeat_Const_Id, Value = 200 };
            var FuelGasPierce_Dyn = new DynParams { Id = FuelGasPierce_Dyn_Id, ParamId = (int)ParamIds.FuelGasPierce, ConstParamsId = FuelGasPierce_Const_Id, Value = 200 };
            var FuelGasCut_Dyn = new DynParams { Id = FuelGasCut_Dyn_Id, ParamId = (int)ParamIds.FuelGasCut, ConstParamsId = FuelGasCut_Const_Id, Value = 200 };
            var PreHeatTime_Dyn = new DynParams { Id = PreHeatTime_Dyn_Id, ParamId = (int)ParamIds.PreHeatTime, ConstParamsId = PreHeatTime_Const_Id, Value = 150 };
            var PiercePreTime_Dyn = new DynParams { Id = PiercePreTime_Dyn_Id, ParamId = (int)ParamIds.PiercePreTime, ConstParamsId = PiercePreTime_Const_Id, Value = 0 };
            var PierceTime_Dyn = new DynParams { Id = PierceTime_Dyn_Id, ParamId = (int)ParamIds.PierceTime, ConstParamsId = PierceTime_Const_Id, Value = 10 };
            var PiercePostTime_Dyn = new DynParams { Id = PiercePostTime_Dyn_Id, ParamId = (int)ParamIds.PiercePostTime, ConstParamsId = PiercePostTime_Const_Id, Value = 0 };
            var PierceHeightRampTime_Dyn = new DynParams { Id = PierceHeightRampTime_Dyn_Id, ParamId = (int)ParamIds.PierceHeightRampTime, ConstParamsId = PierceHeightRampTime_Const_Id, Value = 0 };
            var CutHeightRampTime_Dyn = new DynParams { Id = CutHeightRampTime_Dyn_Id, ParamId = (int)ParamIds.CutHeightRampTime, ConstParamsId = CutHeightRampTime_Const_Id, Value = 0 };
            var PierceMode_Dyn = new DynParams { Id = PierceMode_Dyn_Id, ParamId = (int)ParamIds.PierceMode, ConstParamsId = PierceMode_Const_Id, Value = 0 };
            var IgnitionFlameAdjust_Dyn = new DynParams { Id = IgnitionFlameAdjust_Dyn_Id, ParamId = (int)ParamIds.IgnitionFlameAdjust, ConstParamsId = IgnitionFlameAdjust_Const_Id, Value = 500 };
            var GasType_Dyn = new DynParams { Id = GasType_Dyn_Id, ParamId = (int)ParamIds.GasType, ConstParamsId = GasType_Const_Id, Value = 0 };
            var CuttingSpeed_Dyn = new DynParams { Id = CuttingSpeed_Dyn_Id, ParamId = (int)ParamIds.CuttingSpeed, ConstParamsId = CuttingSpeed_Const_Id, Value = 460 };
            var PierceCuttingSpeedChange_Dyn = new DynParams { Id = PierceCuttingSpeedChange_Dyn_Id, ParamId = (int)ParamIds.PierceCuttingSpeedChange, ConstParamsId = PierceCuttingSpeedChange_Const_Id, Value = 100 };
            var ControlBits_Dyn = new DynParams { Id = ControlBits_Dyn_Id, ParamId = (int)ParamIds.ControlBits, ConstParamsId = ControlBits_Const_Id, Value = 0 };

            modelBuilder.Entity<DynParams>().HasData(PreHeatHeight_Dyn);
            modelBuilder.Entity<DynParams>().HasData(PierceHeight_Dyn);
            modelBuilder.Entity<DynParams>().HasData(CutHeight_Dyn);
            modelBuilder.Entity<DynParams>().HasData(HeatO2Ignition_Dyn);
            modelBuilder.Entity<DynParams>().HasData(HeatO2PreHeat_Dyn);
            modelBuilder.Entity<DynParams>().HasData(HeatO2Pierce_Dyn);
            modelBuilder.Entity<DynParams>().HasData(HeatO2Cut_Dyn);
            modelBuilder.Entity<DynParams>().HasData(CutO2Pierce_Dyn);
            modelBuilder.Entity<DynParams>().HasData(CutO2Cut_Dyn);
            modelBuilder.Entity<DynParams>().HasData(FuelGasIgnition_Dyn);
            modelBuilder.Entity<DynParams>().HasData(FuelGasPreHeat_Dyn);
            modelBuilder.Entity<DynParams>().HasData(FuelGasPierce_Dyn);
            modelBuilder.Entity<DynParams>().HasData(FuelGasCut_Dyn);
            modelBuilder.Entity<DynParams>().HasData(PreHeatTime_Dyn);
            modelBuilder.Entity<DynParams>().HasData(PiercePreTime_Dyn);
            modelBuilder.Entity<DynParams>().HasData(PierceTime_Dyn);
            modelBuilder.Entity<DynParams>().HasData(PiercePostTime_Dyn);
            modelBuilder.Entity<DynParams>().HasData(PierceHeightRampTime_Dyn);
            modelBuilder.Entity<DynParams>().HasData(CutHeightRampTime_Dyn);
            modelBuilder.Entity<DynParams>().HasData(PierceMode_Dyn);
            modelBuilder.Entity<DynParams>().HasData(IgnitionFlameAdjust_Dyn);
            modelBuilder.Entity<DynParams>().HasData(GasType_Dyn);
            modelBuilder.Entity<DynParams>().HasData(CuttingSpeed_Dyn);
            modelBuilder.Entity<DynParams>().HasData(PierceCuttingSpeedChange_Dyn);
            modelBuilder.Entity<DynParams>().HasData(ControlBits_Dyn);

            // Process Const
            var RetractHeight_Const_Id = Guid.NewGuid();
            var SlagSensitivity_Const_Id = Guid.NewGuid();
            var HeatO2Temper_Const_Id = Guid.NewGuid();
            var FuelGasTemper_Const_Id = Guid.NewGuid();
            var HeightTemper_Const_Id = Guid.NewGuid();
            var LinearDriveManualPosSpeed_Const_Id = Guid.NewGuid();
            var FuelGasOffset_Const_Id = Guid.NewGuid();
            var FlashbackSensivitity_Const_Id = Guid.NewGuid();
            var SlagIntervalTime_Const_Id = Guid.NewGuid();
            var SlagFirstSlagTime_Const_Id = Guid.NewGuid();
            var SlagSecurityTime_Const_Id = Guid.NewGuid();
            var SlagPostTime_Const_Id = Guid.NewGuid();
            var SlagActiveGradient_Const_Id = Guid.NewGuid();
            var SlagInActiveGradient_Const_Id = Guid.NewGuid();
            var IgnitionDetectionEnable_Const_Id = Guid.NewGuid();
            var PiercingSensorMode_Const_Id = Guid.NewGuid();

            var RetractHeight_Const = new ConstParams { Id = RetractHeight_Const_Id, Min = 0, Max = 500, Step = 25 };
            var SlagSensitivity_Const = new ConstParams { Id = SlagSensitivity_Const_Id, Min = 0, Max = 3, Step = 1 };
            var HeatO2Temper_Const = new ConstParams { Id = HeatO2Temper_Const_Id, Min = 500, Max = 5000, Step = 10 };
            var FuelGasTemper_Const = new ConstParams { Id = FuelGasTemper_Const_Id, Min = 0, Max = 1000, Step = 10 };
            var HeightTemper_Const = new ConstParams { Id = HeightTemper_Const_Id, Min = 20, Max = 200, Step = 5 };
            var LinearDriveManualPosSpeed_Const = new ConstParams { Id = LinearDriveManualPosSpeed_Const_Id, Min = 10, Max = 100, Step = 1 };
            var FuelGasOffset_Const = new ConstParams { Id = FuelGasOffset_Const_Id, Min = 50, Max = 150, Step = 1 };
            var FlashbackSensivitity_Const = new ConstParams { Id = FlashbackSensivitity_Const_Id, Min = 1, Max = 3, Step = 1 };
            var SlagIntervalTime_Const = new ConstParams { Id = SlagIntervalTime_Const_Id, Min = 25, Max = 150, Step = 5 };
            var SlagFirstSlagTime_Const = new ConstParams { Id = SlagFirstSlagTime_Const_Id, Min = 10, Max = 50, Step = 5 };
            var SlagSecurityTime_Const = new ConstParams { Id = SlagSecurityTime_Const_Id, Min = 50, Max = 300, Step = 5 };
            var SlagPostTime_Const = new ConstParams { Id = SlagPostTime_Const_Id, Min = 0, Max = 100, Step = 5 };
            var SlagActiveGradient_Const = new ConstParams { Id = SlagActiveGradient_Const_Id, Min = 50, Max = 150, Step = 5 };
            var SlagInActiveGradient_Const = new ConstParams { Id = SlagInActiveGradient_Const_Id, Min = 50, Max = 150, Step = 5 };
            var IgnitionDetectionEnable_Const = new ConstParams { Id = IgnitionDetectionEnable_Const_Id, Min = 0, Max = 1, Step = 1 };
            var PiercingSensorMode_Const = new ConstParams { Id = PiercingSensorMode_Const_Id, Min = 0, Max = 1, Step = 1 };

            modelBuilder.Entity<ConstParams>().HasData(RetractHeight_Const);
            modelBuilder.Entity<ConstParams>().HasData(SlagSensitivity_Const);
            modelBuilder.Entity<ConstParams>().HasData(HeatO2Temper_Const);
            modelBuilder.Entity<ConstParams>().HasData(FuelGasTemper_Const);
            modelBuilder.Entity<ConstParams>().HasData(HeightTemper_Const);
            modelBuilder.Entity<ConstParams>().HasData(LinearDriveManualPosSpeed_Const);
            modelBuilder.Entity<ConstParams>().HasData(FuelGasOffset_Const);
            modelBuilder.Entity<ConstParams>().HasData(FlashbackSensivitity_Const);
            modelBuilder.Entity<ConstParams>().HasData(SlagIntervalTime_Const);
            modelBuilder.Entity<ConstParams>().HasData(SlagFirstSlagTime_Const);
            modelBuilder.Entity<ConstParams>().HasData(SlagSecurityTime_Const);
            modelBuilder.Entity<ConstParams>().HasData(SlagPostTime_Const);
            modelBuilder.Entity<ConstParams>().HasData(SlagActiveGradient_Const);
            modelBuilder.Entity<ConstParams>().HasData(SlagInActiveGradient_Const);
            modelBuilder.Entity<ConstParams>().HasData(IgnitionDetectionEnable_Const);
            modelBuilder.Entity<ConstParams>().HasData(PiercingSensorMode_Const);

            // Process Dyn
            var RetractHeight_Dyn_Id = Guid.NewGuid();
            var SlagSensitivity_Dyn_Id = Guid.NewGuid();
            var HeatO2Temper_Dyn_Id = Guid.NewGuid();
            var FuelGasTemper_Dyn_Id = Guid.NewGuid();
            var HeightTemper_Dyn_Id = Guid.NewGuid();
            var LinearDriveManualPosSpeed_Dyn_Id = Guid.NewGuid();
            var FuelGasOffset_Dyn_Id = Guid.NewGuid();
            var FlashbackSensivitity_Dyn_Id = Guid.NewGuid();
            var SlagIntervalTime_Dyn_Id = Guid.NewGuid();
            var SlagFirstSlagTime_Dyn_Id = Guid.NewGuid();
            var SlagSecurityTime_Dyn_Id = Guid.NewGuid();
            var SlagPostTime_Dyn_Id = Guid.NewGuid();
            var SlagActiveGradient_Dyn_Id = Guid.NewGuid();
            var SlagInActiveGradient_Dyn_Id = Guid.NewGuid();
            var IgnitionDetectionEnable_Dyn_Id = Guid.NewGuid();
            var PiercingSensorMode_Dyn_Id = Guid.NewGuid();

            var RetractHeight_Dyn = new DynParams { Id = RetractHeight_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.RetractHeight, ConstParamsId = RetractHeight_Const_Id, Value = 100 };
            var SlagSensitivity_Dyn = new DynParams { Id = SlagSensitivity_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.SlagSensitivity, ConstParamsId = SlagSensitivity_Const_Id, Value = 2 };
            var HeatO2Temper_Dyn = new DynParams { Id = HeatO2Temper_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.HeatO2Temper, ConstParamsId = HeatO2Temper_Const_Id, Value = 500 };
            var FuelGasTemper_Dyn = new DynParams { Id = FuelGasTemper_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.FuelGasTemper, ConstParamsId = FuelGasTemper_Const_Id, Value = 0 };
            var HeightTemper_Dyn = new DynParams { Id = HeightTemper_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.HeightTemper, ConstParamsId = HeightTemper_Const_Id, Value = 80 };
            var LinearDriveManualPosSpeed_Dyn = new DynParams { Id = LinearDriveManualPosSpeed_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.LinearDriveManualPosSpeed, ConstParamsId = LinearDriveManualPosSpeed_Const_Id, Value = 20 };
            var FuelGasOffset_Dyn = new DynParams { Id = FuelGasOffset_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.FuelGasOffset, ConstParamsId = FuelGasOffset_Const_Id, Value = 100 };
            var FlashbackSensivitity_Dyn = new DynParams { Id = FlashbackSensivitity_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.FlashbackSensivitity, ConstParamsId = FlashbackSensivitity_Const_Id, Value = 2 };
            var SlagIntervalTime_Dyn = new DynParams { Id = SlagIntervalTime_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.SlagIntervalTime, ConstParamsId = SlagIntervalTime_Const_Id, Value = 50 };
            var SlagFirstSlagTime_Dyn = new DynParams { Id = SlagFirstSlagTime_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.SlagFirstSlagTime, ConstParamsId = SlagFirstSlagTime_Const_Id, Value = 25 };
            var SlagSecurityTime_Dyn = new DynParams { Id = SlagSecurityTime_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.SlagSecurityTime, ConstParamsId = SlagSecurityTime_Const_Id, Value = 100 };
            var SlagPostTime_Dyn = new DynParams { Id = SlagPostTime_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.SlagPostTime, ConstParamsId = SlagPostTime_Const_Id, Value = 20 };
            var SlagActiveGradient_Dyn = new DynParams { Id = SlagActiveGradient_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.SlagActiveGradient, ConstParamsId = SlagActiveGradient_Const_Id, Value = 100 };
            var SlagInActiveGradient_Dyn = new DynParams { Id = SlagInActiveGradient_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.SlagInActiveGradient, ConstParamsId = SlagInActiveGradient_Const_Id, Value = 100 };
            var IgnitionDetectionEnable_Dyn = new DynParams { Id = IgnitionDetectionEnable_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.IgnitionDetectionEnable, ConstParamsId = IgnitionDetectionEnable_Const_Id, Value = 1 };
            var PiercingSensorMode_Dyn = new DynParams { Id = PiercingSensorMode_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.PiercingSensorMode, ConstParamsId = PiercingSensorMode_Const_Id, Value = 1 };

            modelBuilder.Entity<DynParams>().HasData(RetractHeight_Dyn);
            modelBuilder.Entity<DynParams>().HasData(SlagSensitivity_Dyn);
            modelBuilder.Entity<DynParams>().HasData(HeatO2Temper_Dyn);
            modelBuilder.Entity<DynParams>().HasData(FuelGasTemper_Dyn);
            modelBuilder.Entity<DynParams>().HasData(HeightTemper_Dyn);
            modelBuilder.Entity<DynParams>().HasData(LinearDriveManualPosSpeed_Dyn);
            modelBuilder.Entity<DynParams>().HasData(FuelGasOffset_Dyn);
            modelBuilder.Entity<DynParams>().HasData(FlashbackSensivitity_Dyn);
            modelBuilder.Entity<DynParams>().HasData(SlagIntervalTime_Dyn);
            modelBuilder.Entity<DynParams>().HasData(SlagFirstSlagTime_Dyn);
            modelBuilder.Entity<DynParams>().HasData(SlagSecurityTime_Dyn);
            modelBuilder.Entity<DynParams>().HasData(SlagPostTime_Dyn);
            modelBuilder.Entity<DynParams>().HasData(SlagActiveGradient_Dyn);
            modelBuilder.Entity<DynParams>().HasData(SlagInActiveGradient_Dyn);
            modelBuilder.Entity<DynParams>().HasData(IgnitionDetectionEnable_Dyn);
            modelBuilder.Entity<DynParams>().HasData(PiercingSensorMode_Dyn);

            // Config Params Const
            var LinearDriveUpSpeedFast_Const_Id = Guid.NewGuid();
            var LinearDriveUpSpeedSlow_Const_Id = Guid.NewGuid();
            var LinearDriveDnSpeedFast_Const_Id = Guid.NewGuid();
            var LinearDriveDnSpeedSlow_Const_Id = Guid.NewGuid();
            var Dynamic_Const_Id = Guid.NewGuid();
            var SensorCollisionDelay_Const_Id = Guid.NewGuid();
            var LinearDriveRefSpeed_Const_Id = Guid.NewGuid();
            var LinearDrivePosSpeed_Const_Id = Guid.NewGuid();
            var TactileInitialPosFinding_Const_Id = Guid.NewGuid();
            var DistanceCalibration_Const_Id = Guid.NewGuid();
            var HoseLength_Const_Id = Guid.NewGuid();
            var CutO2BlowOutTime_Const_Id = Guid.NewGuid();
            var CutO2BlowOutPressure_Const_Id = Guid.NewGuid();
            var CutO2BlowOutTimeOut_Const_Id = Guid.NewGuid();
            var CapSetpointFlameOffs_Const_Id = Guid.NewGuid();
            var LoadDefaultParameter_Const_Id = Guid.NewGuid();

            var LinearDriveUpSpeedFast_Const = new ConstParams { Id = LinearDriveUpSpeedFast_Const_Id, Min = 10, Max = 100, Step = 1 };
            var LinearDriveUpSpeedSlow_Const = new ConstParams { Id = LinearDriveUpSpeedSlow_Const_Id, Min = 10, Max = 100, Step = 1 };
            var LinearDriveDnSpeedFast_Const = new ConstParams { Id = LinearDriveDnSpeedFast_Const_Id, Min = 10, Max = 100, Step = 1 };
            var LinearDriveDnSpeedSlow_Const = new ConstParams { Id = LinearDriveDnSpeedSlow_Const_Id, Min = 10, Max = 100, Step = 1 };
            var Dynamic_Const = new ConstParams { Id = Dynamic_Const_Id, Min = 10, Max = 100, Step = 1 };
            var SensorCollisionDelay_Const = new ConstParams { Id = SensorCollisionDelay_Const_Id, Min = 0, Max = 20, Step = 1 };
            var LinearDriveRefSpeed_Const = new ConstParams { Id = LinearDriveRefSpeed_Const_Id, Min = 0, Max = 0, Step = 0 };
            var LinearDrivePosSpeed_Const = new ConstParams { Id = LinearDrivePosSpeed_Const_Id, Min = 10, Max = 100, Step = 1 };
            var TactileInitialPosFinding_Const = new ConstParams { Id = TactileInitialPosFinding_Const_Id, Min = 0, Max = 1, Step = 1 };
			var DistanceCalibration_Const = new ConstParams { Id = DistanceCalibration_Const_Id, Min = 0, Max = 100, Step = 10 };
			var HoseLength_Const = new ConstParams { Id = HoseLength_Const_Id, Min = 500, Max = 20000, Step = 10 }; 
			var CutO2BlowOutTime_Const = new ConstParams { Id = CutO2BlowOutTime_Const_Id, Min = 0, Max = 30, Step = 1 }; 
			var CutO2BlowOutPressure_Const = new ConstParams { Id = CutO2BlowOutPressure_Const_Id, Min = 0, Max = 5000, Step = 10 };
            var CutO2BlowOutTimeOut_Const = new ConstParams { Id = CutO2BlowOutTimeOut_Const_Id, Min = 0, Max = 240, Step = 1 };
			var CapSetpointFlameOffs_Const = new ConstParams { Id = CapSetpointFlameOffs_Const_Id, Min = 0, Max = 1, Step = 1 };
			var LoadDefaultParameter_Const = new ConstParams { Id = LoadDefaultParameter_Const_Id, Min = 0, Max = 1, Step = 1 };

			modelBuilder.Entity<ConstParams>().HasData(LinearDriveUpSpeedFast_Const);
			modelBuilder.Entity<ConstParams>().HasData(LinearDriveUpSpeedSlow_Const);
			modelBuilder.Entity<ConstParams>().HasData(LinearDriveDnSpeedFast_Const);
			modelBuilder.Entity<ConstParams>().HasData(LinearDriveDnSpeedSlow_Const);
            modelBuilder.Entity<ConstParams>().HasData(SensorCollisionDelay_Const);
			modelBuilder.Entity<ConstParams>().HasData(LinearDriveRefSpeed_Const);
			modelBuilder.Entity<ConstParams>().HasData(LinearDrivePosSpeed_Const);
            modelBuilder.Entity<ConstParams>().HasData(TactileInitialPosFinding_Const);
            modelBuilder.Entity<ConstParams>().HasData(DistanceCalibration_Const);
            modelBuilder.Entity<ConstParams>().HasData(Dynamic_Const);
            modelBuilder.Entity<ConstParams>().HasData(HoseLength_Const);
            modelBuilder.Entity<ConstParams>().HasData(CutO2BlowOutTime_Const);
            modelBuilder.Entity<ConstParams>().HasData(CutO2BlowOutPressure_Const);
            modelBuilder.Entity<ConstParams>().HasData(CutO2BlowOutTimeOut_Const);
            modelBuilder.Entity<ConstParams>().HasData(CapSetpointFlameOffs_Const);
            modelBuilder.Entity<ConstParams>().HasData(LoadDefaultParameter_Const);

            // Config Params Dyn
            var LinearDriveUpSpeedFast_Dyn_Id = Guid.NewGuid();
            var LinearDriveUpSpeedSlow_Dyn_Id = Guid.NewGuid();
            var LinearDriveDnSpeedFast_Dyn_Id = Guid.NewGuid();
            var LinearDriveDnSpeedSlow_Dyn_Id = Guid.NewGuid();
            var Dynamic_Dyn_Id = Guid.NewGuid();
            var SensorCollisionDelay_Dyn_Id = Guid.NewGuid();
            var LinearDriveRefSpeed_Dyn_Id = Guid.NewGuid();
            var LinearDrivePosSpeed_Dyn_Id = Guid.NewGuid();
            var TactileInitialPosFinding_Dyn_Id = Guid.NewGuid();
			var DistanceCalibration_Dyn_Id = Guid.NewGuid();
            var HoseLength_Dyn_Id = Guid.NewGuid();
            var CutO2BlowOutTime_Dyn_Id = Guid.NewGuid();
            var CutO2BlowOutPressure_Dyn_Id = Guid.NewGuid();
            var CutO2BlowOutTimeOut_Dyn_Id = Guid.NewGuid();
            var CapSetpointFlameOffs_Dyn_Id = Guid.NewGuid();
            var LoadDefaultParameter_Dyn_Id = Guid.NewGuid();

            var LinearDriveUpSpeedFast_Dyn = new DynParams { Id = LinearDriveUpSpeedFast_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedFast, ConstParamsId = LinearDriveUpSpeedFast_Const_Id, Value = 90 };
            var LinearDriveUpSpeedSlow_Dyn = new DynParams { Id = LinearDriveUpSpeedSlow_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.LinearDriveUpSpeedSlow, ConstParamsId = LinearDriveUpSpeedSlow_Const_Id, Value = 45 };
            var LinearDriveDnSpeedFast_Dyn = new DynParams { Id = LinearDriveDnSpeedFast_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedFast, ConstParamsId = LinearDriveDnSpeedFast_Const_Id, Value = 65 };
            var LinearDriveDnSpeedSlow_Dyn = new DynParams { Id = LinearDriveDnSpeedSlow_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.LinearDriveDnSpeedSlow, ConstParamsId = LinearDriveDnSpeedSlow_Const_Id, Value = 45 };
            var Dynamic_Dyn = new DynParams { Id = Dynamic_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.Dynamic, ConstParamsId = Dynamic_Const_Id, Value = 35 };
            var SensorCollisionDelay_Dyn = new DynParams { Id = SensorCollisionDelay_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.SensorCollisionDelay, ConstParamsId = SensorCollisionDelay_Const_Id, Value = 10 };
            var LinearDriveRefSpeed_Dyn = new DynParams { Id = LinearDriveRefSpeed_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.LinearDriveRefSpeed, ConstParamsId = LinearDriveRefSpeed_Const_Id, Value = 43 };
            var LinearDrivePosSpeed_Dyn = new DynParams { Id = LinearDrivePosSpeed_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.LinearDrivePosSpeed, ConstParamsId = LinearDrivePosSpeed_Const_Id, Value = 95 };
            var TactileInitialPosFinding_Dyn = new DynParams { Id = TactileInitialPosFinding_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding, ConstParamsId = TactileInitialPosFinding_Const_Id, Value = 0 };
			var DistanceCalibration_Dyn = new DynParams { Id = DistanceCalibration_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.DistanceCalibration, ConstParamsId = DistanceCalibration_Const_Id, Value = 1 };
			var HoseLength_Dyn = new DynParams { Id = HoseLength_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.HoseLength, ConstParamsId = HoseLength_Const_Id, Value = 1500 };
			var CutO2BlowOutTime_Dyn = new DynParams { Id = CutO2BlowOutTime_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime, ConstParamsId = CutO2BlowOutTime_Const_Id, Value = 5 };
			var CutO2BlowOutPressure_Dyn = new DynParams { Id = CutO2BlowOutPressure_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure, ConstParamsId = CutO2BlowOutPressure_Const_Id, Value = 2500 };
			var CutO2BlowOutTimeOut_Dyn = new DynParams { Id = CutO2BlowOutTimeOut_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut, ConstParamsId = CutO2BlowOutTimeOut_Const_Id, Value = 240 };
			var CapSetpointFlameOffs_Dyn = new DynParams { Id = CapSetpointFlameOffs_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.CapSetpointFlameOffs, ConstParamsId = CapSetpointFlameOffs_Const_Id, Value = 0 };
			var LoadDefaultParameter_Dyn = new DynParams { Id = LoadDefaultParameter_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxConfig.LoadDefaultParameter, ConstParamsId = LoadDefaultParameter_Const_Id, Value = 0 };

			modelBuilder.Entity<DynParams>().HasData(LinearDriveUpSpeedFast_Dyn);
			modelBuilder.Entity<DynParams>().HasData(LinearDriveUpSpeedSlow_Dyn);
			modelBuilder.Entity<DynParams>().HasData(LinearDriveDnSpeedFast_Dyn);
			modelBuilder.Entity<DynParams>().HasData(LinearDriveDnSpeedSlow_Dyn);
			modelBuilder.Entity<DynParams>().HasData(Dynamic_Dyn);
			modelBuilder.Entity<DynParams>().HasData(SensorCollisionDelay_Dyn);
			modelBuilder.Entity<DynParams>().HasData(LinearDriveRefSpeed_Dyn);
			modelBuilder.Entity<DynParams>().HasData(LinearDrivePosSpeed_Dyn);
            modelBuilder.Entity<DynParams>().HasData(TactileInitialPosFinding_Dyn);
            modelBuilder.Entity<DynParams>().HasData(DistanceCalibration_Dyn);
            modelBuilder.Entity<DynParams>().HasData(HoseLength_Dyn);
            modelBuilder.Entity<DynParams>().HasData(CutO2BlowOutTime_Dyn);
            modelBuilder.Entity<DynParams>().HasData(CutO2BlowOutPressure_Dyn);
            modelBuilder.Entity<DynParams>().HasData(CutO2BlowOutTimeOut_Dyn);
            modelBuilder.Entity<DynParams>().HasData(CapSetpointFlameOffs_Dyn);
            modelBuilder.Entity<DynParams>().HasData(LoadDefaultParameter_Dyn);


            // Service Params Const
            //var HeightControlActive_Const_Id = Guid.NewGuid();
            //var Off_Const_Id = Guid.NewGuid();
            //var HeightPreHeat_Const_Id = Guid.NewGuid();
            //var HeightPierce_Const_Id = Guid.NewGuid();
            //var HeightCut_Const_Id = Guid.NewGuid();

            var IgnitionPreFlowMultiplier_Const_Id = Guid.NewGuid();
            var IgnitionOnDurationTime_Const_Id = Guid.NewGuid();
            var HeatO2PostFlowMultiplier_Const_Id = Guid.NewGuid();
            var HeatO2PostFlowPressure_Const_Id = Guid.NewGuid();
            var SlagCuttingSpeedReduction_Const_Id = Guid.NewGuid();
            var SensorCollisionOutputDisable_Const_Id = Guid.NewGuid();
            var PidErrorThresholdDelay_Const_Id = Guid.NewGuid();
            var ToleranceInPosition_Const_Id = Guid.NewGuid();
            var Fit3ValveDelay_Const_Id = Guid.NewGuid();
            var Fit3ValveDuration_Const_Id = Guid.NewGuid();
            var Fit3GlowPlugDelay_Const_Id = Guid.NewGuid();
            var Fit3GlowPlugDuration_Const_Id = Guid.NewGuid();
            var Fit3GlowPlugSetpoint_Const_Id = Guid.NewGuid();
            var Fit3SaveIgnitionData_Const_Id = Guid.NewGuid();

            var IgnitionPreFlowMultiplier_Const = new ConstParams { Id = IgnitionPreFlowMultiplier_Const_Id, Min = 10, Max = 100, Step = 1 };
            var IgnitionOnDurationTime_Const = new ConstParams { Id = IgnitionOnDurationTime_Const_Id, Min = 10, Max = 100, Step = 1 };
            var HeatO2PostFlowMultiplier_Const = new ConstParams { Id = HeatO2PostFlowMultiplier_Const_Id, Min = 10, Max = 100, Step = 1 };
            var HeatO2PostFlowPressure_Const = new ConstParams { Id = HeatO2PostFlowPressure_Const_Id, Min = 10, Max = 100, Step = 1 };
            var SlagCuttingSpeedReduction_Const = new ConstParams { Id = SlagCuttingSpeedReduction_Const_Id, Min = 10, Max = 100, Step = 1 };
            var SensorCollisionOutputDisable_Const = new ConstParams { Id = SensorCollisionOutputDisable_Const_Id, Min = 0, Max = 20, Step = 1 };
            var PidErrorThresholdDelay_Const = new ConstParams { Id = PidErrorThresholdDelay_Const_Id, Min = 0, Max = 0, Step = 0 };
            var ToleranceInPosition_Const = new ConstParams { Id = ToleranceInPosition_Const_Id, Min = 10, Max = 100, Step = 1 };
            var Fit3ValveDelay_Const = new ConstParams { Id = Fit3ValveDelay_Const_Id, Min = 0, Max = 1, Step = 1 };
            var Fit3ValveDuration_Const = new ConstParams { Id = Fit3ValveDuration_Const_Id, Min = 0, Max = 100, Step = 10 };
            var Fit3GlowPlugDelay_Const = new ConstParams { Id = Fit3GlowPlugDelay_Const_Id, Min = 500, Max = 20000, Step = 10 };
            var Fit3GlowPlugDuration_Const = new ConstParams { Id = Fit3GlowPlugDuration_Const_Id, Min = 0, Max = 30, Step = 1 };
            var Fit3GlowPlugSetpoint_Const = new ConstParams { Id = Fit3GlowPlugSetpoint_Const_Id, Min = 0, Max = 5000, Step = 10 };
            var Fit3SaveIgnitionData_Const = new ConstParams { Id = Fit3SaveIgnitionData_Const_Id, Min = 0, Max = 240, Step = 1 };

            modelBuilder.Entity<ConstParams>().HasData(IgnitionPreFlowMultiplier_Const);
            modelBuilder.Entity<ConstParams>().HasData(IgnitionOnDurationTime_Const);
            modelBuilder.Entity<ConstParams>().HasData(HeatO2PostFlowMultiplier_Const);
            modelBuilder.Entity<ConstParams>().HasData(HeatO2PostFlowPressure_Const);
            modelBuilder.Entity<ConstParams>().HasData(SlagCuttingSpeedReduction_Const);
            modelBuilder.Entity<ConstParams>().HasData(SensorCollisionOutputDisable_Const);
            modelBuilder.Entity<ConstParams>().HasData(PidErrorThresholdDelay_Const);
            modelBuilder.Entity<ConstParams>().HasData(ToleranceInPosition_Const);
            modelBuilder.Entity<ConstParams>().HasData(Fit3ValveDelay_Const);
            modelBuilder.Entity<ConstParams>().HasData(Fit3ValveDuration_Const);
            modelBuilder.Entity<ConstParams>().HasData(Fit3GlowPlugDelay_Const);
            modelBuilder.Entity<ConstParams>().HasData(Fit3GlowPlugDuration_Const);
            modelBuilder.Entity<ConstParams>().HasData(Fit3GlowPlugSetpoint_Const);
            modelBuilder.Entity<ConstParams>().HasData(Fit3SaveIgnitionData_Const);

            // Service Params Dyn
            var IgnitionPreFlowMultiplier_Dyn_Id = Guid.NewGuid();
            var IgnitionOnDurationTime_Dyn_Id = Guid.NewGuid();
            var HeatO2PostFlowMultiplier_Dyn_Id = Guid.NewGuid();
            var HeatO2PostFlowPressure_Dyn_Id = Guid.NewGuid();
            var SlagCuttingSpeedReduction_Dyn_Id = Guid.NewGuid();
            var SensorCollisionOutputDisable_Dyn_Id = Guid.NewGuid();
            var PidErrorThresholdDelay_Dyn_Id = Guid.NewGuid();
            var ToleranceInPosition_Dyn_Id = Guid.NewGuid();
            var Fit3ValveDelay_Dyn_Id = Guid.NewGuid();
            var Fit3ValveDuration_Dyn_Id = Guid.NewGuid();
            var Fit3GlowPlugDelay_Dyn_Id = Guid.NewGuid();
            var Fit3GlowPlugDuration_Dyn_Id = Guid.NewGuid();
            var Fit3GlowPlugSetpoint_Dyn_Id = Guid.NewGuid();
            var Fit3SaveIgnitionData_Dyn_Id = Guid.NewGuid();

            var IgnitionPreFlowMultiplier_Dyn = new DynParams { Id = IgnitionPreFlowMultiplier_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.IgnitionPreFlowMultiplier, ConstParamsId = IgnitionPreFlowMultiplier_Const_Id, Value = 90 };
            var IgnitionOnDurationTime_Dyn = new DynParams { Id = IgnitionOnDurationTime_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.IgnitionOnDurationTime, ConstParamsId = IgnitionOnDurationTime_Const_Id, Value = 45 };
            var HeatO2PostFlowMultiplier_Dyn = new DynParams { Id = HeatO2PostFlowMultiplier_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.HeatO2PostFlowMultiplier, ConstParamsId = HeatO2PostFlowMultiplier_Const_Id, Value = 65 };
            var HeatO2PostFlowPressure_Dyn = new DynParams { Id = HeatO2PostFlowPressure_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.HeatO2PostFlowPressure, ConstParamsId = HeatO2PostFlowPressure_Const_Id, Value = 45 };
            var SlagCuttingSpeedReduction_Dyn = new DynParams { Id = SlagCuttingSpeedReduction_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction, ConstParamsId = SlagCuttingSpeedReduction_Const_Id, Value = 35 };
            var SensorCollisionOutputDisable_Dyn = new DynParams { Id = SensorCollisionOutputDisable_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.SensorCollisionOutputDisable, ConstParamsId = SensorCollisionOutputDisable_Const_Id, Value = 10 };
            var PidErrorThresholdDelay_Dyn = new DynParams { Id = PidErrorThresholdDelay_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.PidErrorThresholdDelay, ConstParamsId = PidErrorThresholdDelay_Const_Id, Value = 43 };
            var ToleranceInPosition_Dyn = new DynParams { Id = ToleranceInPosition_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.ToleranceInPosition, ConstParamsId = ToleranceInPosition_Const_Id, Value = 95 };
            var Fit3ValveDelay_Dyn = new DynParams { Id = Fit3ValveDelay_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.Fit3ValveDelay, ConstParamsId = Fit3ValveDelay_Const_Id, Value = 0 };
            var Fit3ValveDuration_Dyn = new DynParams { Id = Fit3ValveDuration_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.Fit3ValveDuration, ConstParamsId = Fit3ValveDuration_Const_Id, Value = 1 };
            var Fit3GlowPlugDelay_Dyn = new DynParams { Id = Fit3GlowPlugDelay_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.Fit3GlowPlugDelay, ConstParamsId = Fit3GlowPlugDelay_Const_Id, Value = 1500 };
            var Fit3GlowPlugDuration_Dyn = new DynParams { Id = Fit3GlowPlugDuration_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.Fit3GlowPlugDuration, ConstParamsId = Fit3GlowPlugDuration_Const_Id, Value = 5 };
            var Fit3GlowPlugSetpoint_Dyn = new DynParams { Id = Fit3GlowPlugSetpoint_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.Fit3GlowPlugSetpoint, ConstParamsId = Fit3GlowPlugSetpoint_Const_Id, Value = 2500 };
            var Fit3SaveIgnitionData_Dyn = new DynParams { Id = Fit3SaveIgnitionData_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.Fit3SaveIgnitionData, ConstParamsId = Fit3SaveIgnitionData_Const_Id, Value = 240 };

            modelBuilder.Entity<DynParams>().HasData(IgnitionPreFlowMultiplier_Dyn);
            modelBuilder.Entity<DynParams>().HasData(IgnitionOnDurationTime_Dyn);
            modelBuilder.Entity<DynParams>().HasData(HeatO2PostFlowMultiplier_Dyn);
            modelBuilder.Entity<DynParams>().HasData(HeatO2PostFlowPressure_Dyn);
            modelBuilder.Entity<DynParams>().HasData(SlagCuttingSpeedReduction_Dyn);
            modelBuilder.Entity<DynParams>().HasData(SensorCollisionOutputDisable_Dyn);
            modelBuilder.Entity<DynParams>().HasData(PidErrorThresholdDelay_Dyn);
            modelBuilder.Entity<DynParams>().HasData(ToleranceInPosition_Dyn);
            modelBuilder.Entity<DynParams>().HasData(Fit3ValveDelay_Dyn);
            modelBuilder.Entity<DynParams>().HasData(Fit3ValveDuration_Dyn);
            modelBuilder.Entity<DynParams>().HasData(Fit3GlowPlugDelay_Dyn);
            modelBuilder.Entity<DynParams>().HasData(Fit3GlowPlugDuration_Dyn);
            modelBuilder.Entity<DynParams>().HasData(Fit3GlowPlugSetpoint_Dyn);
            modelBuilder.Entity<DynParams>().HasData(Fit3SaveIgnitionData_Dyn);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //ParameterData

            //var ParameterData_HeightControlActive = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeightControlActive", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Additional, DynParamsId = HeightControlActive_Dyn_Id };
            //var ParameterData_Off = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_Off", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.StatusHeightCtrl, DynParamsId = Off_Dyn_Id };
            //var ParameterData_HeightPreHeat = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeightPreHeat", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.StatusHeightCtrl, DynParamsId = HeightPreHeat_Dyn_Id };
            //var ParameterData_HeightPierce = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeightPierce", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.StatusHeightCtrl, DynParamsId = HeightPierce_Dyn_Id };
            //var ParameterData_HeightCut = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeightCut", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.StatusHeightCtrl, DynParamsId = HeightCut_Dyn_Id };
            //modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeightControlActive);
            //modelBuilder.Entity<ParameterData>().HasData(ParameterData_Off);
            //modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeightPreHeat);
            //modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeightPierce);
            //modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeightCut);

            // Technology
            var ParameterData_PreHeatHeight = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PreHeatHeight", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = PreHeatHeight_Dyn_Id };
            var ParameterData_PierceHeight = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PierceHeight", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = PierceHeight_Dyn_Id };
            var ParameterData_CutHeight = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutHeight", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = CutHeight_Dyn_Id };
            var ParameterData_HeatO2Ignition = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2Ignition", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = HeatO2Ignition_Dyn_Id };
			var ParameterData_HeatO2PreHeat = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2PreHeat", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = HeatO2PreHeat_Dyn_Id };
			var ParameterData_HeatO2Pierce = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2Pierce", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = HeatO2Pierce_Dyn_Id };
			var ParameterData_HeatO2Cut = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2Cut", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = HeatO2Cut_Dyn_Id };
            var ParameterData_CutO2Pierce = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutO2Pierce", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = CutO2Pierce_Dyn_Id };
            var ParameterData_CutO2Cut = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutO2Cut", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = CutO2Cut_Dyn_Id };
            var ParameterData_FuelGasIgnition = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasIgnition", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = FuelGasIgnition_Dyn_Id };
			var ParameterData_FuelGasPreHeat = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasPreHeat", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = FuelGasPreHeat_Dyn_Id };
			var ParameterData_FuelGasPierce = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasPierce", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = FuelGasPierce_Dyn_Id };
			var ParameterData_FuelGasCut = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasCut", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = FuelGasCut_Dyn_Id };
            var ParameterData_PreHeatTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PreHeatTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = PreHeatTime_Dyn_Id };
            var ParameterData_PiercePreTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PiercePreTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = PiercePreTime_Dyn_Id };
            var ParameterData_PierceTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PierceTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = PierceTime_Dyn_Id };
            var ParameterData_PiercePostTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PiercePostTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = PiercePostTime_Dyn_Id };
            var ParameterData_PierceHeightRampTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PierceHeightRampTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = PierceHeightRampTime_Dyn_Id };
            var ParameterData_CutHeightRampTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutHeightRampTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = CutHeightRampTime_Dyn_Id };
            var ParameterData_PierceMode = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PierceMode", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = PierceMode_Dyn_Id };
            var ParameterData_IgnitionFlameAdjust = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_IgnitionFlameAdjust", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = IgnitionFlameAdjust_Dyn_Id };
            var ParameterData_GasType = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_GasType", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = GasType_Dyn_Id };
            var ParameterData_CuttingSpeed = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CuttingSpeed", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = CuttingSpeed_Dyn_Id };
            var ParameterData_PierceCuttingSpeedChange = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PierceCuttingSpeedChange", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = PierceCuttingSpeedChange_Dyn_Id };
            var ParameterData_ControlBits = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_ControlBits", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Technology, DynParamsId = ControlBits_Dyn_Id };

            modelBuilder.Entity<ParameterData>().HasData(ParameterData_PreHeatHeight);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_PierceHeight);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_CutHeight);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeatO2Ignition);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeatO2PreHeat);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeatO2Pierce);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeatO2Cut);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_CutO2Pierce);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_CutO2Cut);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_FuelGasIgnition);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_FuelGasPreHeat);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_FuelGasPierce);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_FuelGasCut);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_PreHeatTime);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_PiercePreTime);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_PierceTime);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_PiercePostTime);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_PierceHeightRampTime);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_CutHeightRampTime);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_PierceMode);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_IgnitionFlameAdjust);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_GasType);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_CuttingSpeed);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_PierceCuttingSpeedChange);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_ControlBits);

            // Process
            var ParameterData_RetractHeight = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_RetractHeight", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = RetractHeight_Dyn_Id };
            var ParameterData_SlagSensitivity = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagSensitivity", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = SlagSensitivity_Dyn_Id };
            var ParameterData_HeatO2Temper = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2Temper", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = HeatO2Temper_Dyn_Id };
            var ParameterData_FuelGasTemper = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasTemper", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = FuelGasTemper_Dyn_Id };
            var ParameterData_HeightTemper = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeightTemper", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = HeightTemper_Dyn_Id };
            var ParameterData_LinearDriveManualPosSpeed = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_LinearDriveManualPosSpeed", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = LinearDriveManualPosSpeed_Dyn_Id };
            var ParameterData_FuelGasOffset = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasOffset", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = FuelGasOffset_Dyn_Id };
            var ParameterData_FlashbackSensivitity = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FlashbackSensivitity", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = FlashbackSensivitity_Dyn_Id };
            var ParameterData_SlagIntervalTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagIntervalTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = SlagIntervalTime_Dyn_Id };
            var ParameterData_SlagFirstSlagTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagFirstSlagTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = SlagFirstSlagTime_Dyn_Id };
            var ParameterData_SlagSecurityTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagSecurityTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = SlagSecurityTime_Dyn_Id };
            var ParameterData_SlagPostTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagPostTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = SlagPostTime_Dyn_Id };
            var ParameterData_SlagActiveGradient = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagActiveGradient", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = SlagActiveGradient_Dyn_Id };
            var ParameterData_SlagInActiveGradient = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagInActiveGradient", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = SlagInActiveGradient_Dyn_Id };
            var ParameterData_IgnitionDetectionEnable = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_IgnitionDetectionEnable", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = IgnitionDetectionEnable_Dyn_Id };
            var ParameterData_PiercingSensorMode = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PiercingSensorMode", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = PiercingSensorMode_Dyn_Id };

            modelBuilder.Entity<ParameterData>().HasData(ParameterData_RetractHeight);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagSensitivity);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeatO2Temper);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_FuelGasTemper);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeightTemper);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_LinearDriveManualPosSpeed);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_FuelGasOffset);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_FlashbackSensivitity);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagIntervalTime);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagFirstSlagTime);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagSecurityTime);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagPostTime);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagActiveGradient);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagInActiveGradient);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_IgnitionDetectionEnable);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_PiercingSensorMode);

            // Config
            var ParameterData_LinearDriveUpSpeedFast = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_LinearDriveUpSpeedFast", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = LinearDriveUpSpeedFast_Dyn_Id };
            var ParameterData_LinearDriveUpSpeedSlow = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_LinearDriveUpSpeedSlow", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = LinearDriveUpSpeedSlow_Dyn_Id };
            var ParameterData_LinearDriveDnSpeedFast = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_LinearDriveDnSpeedFast", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = LinearDriveDnSpeedFast_Dyn_Id };
            var ParameterData_LinearDriveDnSpeedSlow = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_LinearDriveDnSpeedSlow", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = LinearDriveDnSpeedSlow_Dyn_Id };
            var ParameterData_Dynamic = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_Dynamic", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = Dynamic_Dyn_Id };
            var ParameterData_SensorCollisionDelay = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SensorCollisionDelay", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = SensorCollisionDelay_Dyn_Id };
            var ParameterData_LinearDriveRefSpeed = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_LinearDriveRefSpeed", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = LinearDriveRefSpeed_Dyn_Id };
            var ParameterData_LinearDrivePosSpeed = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_LinearDrivePosSpeed", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = LinearDrivePosSpeed_Dyn_Id };
            var ParameterData_TactileInitialPosFinding = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_TactileInitialPosFinding", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = TactileInitialPosFinding_Dyn_Id };
            var ParameterData_DistanceCalibration = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_DistanceCalibration", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = DistanceCalibration_Dyn_Id };
            var ParameterData_HoseLength = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HoseLength", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = HoseLength_Dyn_Id };
            var ParameterData_CutO2BlowOutTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutO2BlowOutTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = CutO2BlowOutTime_Dyn_Id };
            var ParameterData_CutO2BlowOutPressure = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutO2BlowOutPressure", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = CutO2BlowOutPressure_Dyn_Id };
            var ParameterData_CutO2BlowOutTimeOut = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutO2BlowOutTimeOut", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = CutO2BlowOutTimeOut_Dyn_Id };
            var ParameterData_CapSetpointFlameOffs = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CapSetpointFlameOffs", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = CapSetpointFlameOffs_Dyn_Id };
            var ParameterData_LoadDefaultParameter = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_LoadDefaultParameter", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Config, DynParamsId = LoadDefaultParameter_Dyn_Id };

            modelBuilder.Entity<ParameterData>().HasData(ParameterData_LinearDriveUpSpeedFast);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_LinearDriveUpSpeedSlow);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_LinearDriveDnSpeedFast);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_LinearDriveDnSpeedSlow);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_Dynamic);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_SensorCollisionDelay);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_LinearDriveRefSpeed);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_LinearDrivePosSpeed);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_TactileInitialPosFinding);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_DistanceCalibration);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_HoseLength);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_CutO2BlowOutTime);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_CutO2BlowOutPressure);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_CutO2BlowOutTimeOut);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_CapSetpointFlameOffs);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_LoadDefaultParameter);

            // Service
            var ParameterData_IgnitionPreFlowMultiplier = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_IgnitionPreFlowMultiplier", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = IgnitionPreFlowMultiplier_Dyn_Id };
            var ParameterData_IgnitionOnDurationTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_IgnitionOnDurationTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = IgnitionOnDurationTime_Dyn_Id };
            var ParameterData_HeatO2PostFlowMultiplier = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2PostFlowMultiplier", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = HeatO2PostFlowMultiplier_Dyn_Id };
            var ParameterData_HeatO2PostFlowPressure = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2PostFlowPressure", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = HeatO2PostFlowPressure_Dyn_Id };
            var ParameterData_SlagCuttingSpeedReduction = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagCuttingSpeedReduction", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = SlagCuttingSpeedReduction_Dyn_Id };
            var ParameterData_SensorCollisionOutputDisable = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SensorCollisionOutputDisable", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = SensorCollisionOutputDisable_Dyn_Id };
            var ParameterData_PidErrorThresholdDelay = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PidErrorThresholdDelay", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = PidErrorThresholdDelay_Dyn_Id };
            var ParameterData_ToleranceInPosition = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_ToleranceInPosition", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = ToleranceInPosition_Dyn_Id };
            var ParameterData_Fit3ValveDelay = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_Fit3ValveDelay", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = Fit3ValveDelay_Dyn_Id };
            var ParameterData_Fit3ValveDuration = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_Fit3ValveDuration", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = Fit3ValveDuration_Dyn_Id };
            var ParameterData_Fit3GlowPlugDelay = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_Fit3GlowPlugDelay", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = Fit3GlowPlugDelay_Dyn_Id };
            var ParameterData_Fit3GlowPlugDuration = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_Fit3GlowPlugDuration", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = Fit3GlowPlugDuration_Dyn_Id };
            var ParameterData_Fit3GlowPlugSetpoint = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_Fit3GlowPlugSetpoint", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = Fit3GlowPlugSetpoint_Dyn_Id };
            var ParameterData_Fit3SaveIgnitionData = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_LinearDriveUpSpeedFast", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = Fit3SaveIgnitionData_Dyn_Id };

            modelBuilder.Entity<ParameterData>().HasData(ParameterData_IgnitionPreFlowMultiplier);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_IgnitionOnDurationTime);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeatO2PostFlowMultiplier);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_HeatO2PostFlowPressure);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagCuttingSpeedReduction);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_SensorCollisionOutputDisable);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_PidErrorThresholdDelay);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_ToleranceInPosition);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_Fit3ValveDelay);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_Fit3ValveDuration);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_Fit3GlowPlugDelay);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_Fit3GlowPlugDuration);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_Fit3GlowPlugSetpoint);
            modelBuilder.Entity<ParameterData>().HasData(ParameterData_Fit3SaveIgnitionData);
        }
		
	}
}
