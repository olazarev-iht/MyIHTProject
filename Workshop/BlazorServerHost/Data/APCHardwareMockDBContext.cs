using Microsoft.EntityFrameworkCore;
using BlazorServerHost.Data.Models.APCHardwareMock;
using SharedComponents.Models.APCHardware;

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
                CreateParameterDataForDevice(modelBuilder, device);
            }

            //CreateParameterDataForDevice(modelBuilder, APCDevice1);
        }

		public void CreateParameterDataForDevice(ModelBuilder modelBuilder, APCDevice apcDevice)
        {
			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
			var HeatO2Ignition_Const_Id = Guid.NewGuid();
			var HeatO2PreHeat_Const_Id = Guid.NewGuid();
			var HeatO2Pierce_Const_Id = Guid.NewGuid();
			var HeatO2Cut_Const_Id = Guid.NewGuid();

			var HeatO2Ignition_Const = new ConstParams { Id = HeatO2Ignition_Const_Id, Min = 500, Max = 5000, Step = 10 };
			var HeatO2PreHeat_Const = new ConstParams { Id = HeatO2PreHeat_Const_Id, Min = 500, Max = 5000, Step = 10 };
			var HeatO2Pierce_Const = new ConstParams { Id = HeatO2Pierce_Const_Id, Min = 500, Max = 5000, Step = 10 };
			var HeatO2Cut_Const = new ConstParams { Id = HeatO2Cut_Const_Id, Min = 500, Max = 5000, Step = 10 };

			modelBuilder.Entity<ConstParams>().HasData(HeatO2Ignition_Const);
			modelBuilder.Entity<ConstParams>().HasData(HeatO2PreHeat_Const);
			modelBuilder.Entity<ConstParams>().HasData(HeatO2Pierce_Const);
			modelBuilder.Entity<ConstParams>().HasData(HeatO2Cut_Const);

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

			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			//DynParams
			//H-O
			var HeatO2Ignition_Dyn_Id = Guid.NewGuid();
			var HeatO2PreHeat_Dyn_Id = Guid.NewGuid();
			var HeatO2Pierce_Dyn_Id = Guid.NewGuid();
			var HeatO2Cut_Dyn_Id = Guid.NewGuid();

			var HeatO2Ignition_Dyn = new DynParams { Id = HeatO2Ignition_Dyn_Id, ParamId = ParamIds.HeatO2Ignition, ConstParamsId = HeatO2Ignition_Const_Id, Value = 2000 };
			var HeatO2PreHeat_Dyn = new DynParams { Id = HeatO2PreHeat_Dyn_Id, ParamId = ParamIds.HeatO2PreHeat, ConstParamsId = HeatO2PreHeat_Const_Id, Value = 2000 };
			var HeatO2Pierce_Dyn = new DynParams { Id = HeatO2Pierce_Dyn_Id, ParamId = ParamIds.HeatO2Pierce, ConstParamsId = HeatO2Pierce_Const_Id, Value = 4000 };
			var HeatO2Cut_Dyn = new DynParams { Id = HeatO2Cut_Dyn_Id, ParamId = ParamIds.HeatO2Cut, ConstParamsId = HeatO2Cut_Const_Id, Value = 2000 };

			modelBuilder.Entity<DynParams>().HasData(HeatO2Ignition_Dyn);
			modelBuilder.Entity<DynParams>().HasData(HeatO2PreHeat_Dyn);
			modelBuilder.Entity<DynParams>().HasData(HeatO2Pierce_Dyn);
			modelBuilder.Entity<DynParams>().HasData(HeatO2Cut_Dyn);

			//F-G
			var FuelGasIgnition_Dyn_Id = Guid.NewGuid();
			var FuelGasPreHeat_Dyn_Id = Guid.NewGuid();
			var FuelGasPierce_Dyn_Id = Guid.NewGuid();
			var FuelGasCut_Dyn_Id = Guid.NewGuid();

			var FuelGasIgnition_Dyn = new DynParams { Id = FuelGasIgnition_Dyn_Id, ParamId = ParamIds.FuelGasIgnition, ConstParamsId = FuelGasIgnition_Const_Id, Value = 200 };
			var FuelGasPreHeat_Dyn = new DynParams { Id = FuelGasPreHeat_Dyn_Id, ParamId = ParamIds.FuelGasPreHeat, ConstParamsId = FuelGasPreHeat_Const_Id, Value = 200 };
			var FuelGasPierce_Dyn = new DynParams { Id = FuelGasPierce_Dyn_Id, ParamId = ParamIds.FuelGasPierce, ConstParamsId = FuelGasPierce_Const_Id, Value = 200 };
			var FuelGasCut_Dyn = new DynParams { Id = FuelGasCut_Dyn_Id, ParamId = ParamIds.FuelGasCut, ConstParamsId = FuelGasCut_Const_Id, Value = 200 };

			modelBuilder.Entity<DynParams>().HasData(FuelGasIgnition_Dyn);
			modelBuilder.Entity<DynParams>().HasData(FuelGasPreHeat_Dyn);
			modelBuilder.Entity<DynParams>().HasData(FuelGasPierce_Dyn);
			modelBuilder.Entity<DynParams>().HasData(FuelGasCut_Dyn);

			//C-O
			var CutO2Pierce_Dyn_Id = Guid.NewGuid();
			var CutO2Cut_Dyn_Id = Guid.NewGuid();

			var CutO2Pierce_Dyn = new DynParams { Id = CutO2Pierce_Dyn_Id, ParamId = ParamIds.CutO2Pierce, ConstParamsId = CutO2Pierce_Const_Id, Value = 1500 };
			var CutO2Cut_Dyn = new DynParams { Id = CutO2Cut_Dyn_Id, ParamId = ParamIds.CutO2Cut, ConstParamsId = CutO2Cut_Const_Id, Value = 6000 };

			modelBuilder.Entity<DynParams>().HasData(CutO2Pierce_Dyn);
			modelBuilder.Entity<DynParams>().HasData(CutO2Cut_Dyn);

			///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			//ParameterData

			var ParameterData_HeatO2Ignition = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2Ignition", APCDeviceId = apcDevice.Id, DynParamsId = HeatO2Ignition_Dyn_Id };
			var ParameterData_HeatO2PreHeat = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2PreHeat", APCDeviceId = apcDevice.Id, DynParamsId = HeatO2PreHeat_Dyn_Id };
			var ParameterData_HeatO2Pierce = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2Pierce", APCDeviceId = apcDevice.Id, DynParamsId = HeatO2Pierce_Dyn_Id };
			var ParameterData_HeatO2Cut = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_HeatO2Cut", APCDeviceId = apcDevice.Id, DynParamsId = HeatO2Cut_Dyn_Id };
			var ParameterData_FuelGasIgnition = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasIgnition", APCDeviceId = apcDevice.Id, DynParamsId = FuelGasIgnition_Dyn_Id };
			var ParameterData_FuelGasPreHeat = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasPreHeat", APCDeviceId = apcDevice.Id, DynParamsId = FuelGasPreHeat_Dyn_Id };
			var ParameterData_FuelGasPierce = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasPierce", APCDeviceId = apcDevice.Id, DynParamsId = FuelGasPierce_Dyn_Id };
			var ParameterData_FuelGasCut = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_FuelGasCut", APCDeviceId = apcDevice.Id, DynParamsId = FuelGasCut_Dyn_Id };
			var ParameterData_CutO2Pierce = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutO2Pierce", APCDeviceId = apcDevice.Id, DynParamsId = CutO2Pierce_Dyn_Id };
			var ParameterData_CutO2Cut = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_CutO2Cut", APCDeviceId = apcDevice.Id, DynParamsId = CutO2Cut_Dyn_Id };

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
		}
	}
}
