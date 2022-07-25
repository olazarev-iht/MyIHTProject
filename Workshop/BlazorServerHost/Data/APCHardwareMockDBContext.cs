using Microsoft.EntityFrameworkCore;
using BlazorServerHost.Data.Models.APCHardwareMock;
using SharedComponents.Models.APCHardware;
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
				if (device.Num > 0)
				{
					CreateParameterDataForDevice(modelBuilder, device);
					CreateParameterDataForSystem(modelBuilder, device);
				}
            }
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

			var RetractHeight_Const = new ConstParams { Id = RetractHeight_Const_Id, Min = 0, Max = 500, Step = 25 }; // System param
			var RetractPosition_Const = new ConstParams { Id = RetractPosition_Const_Id, Min = 0, Max = 1, Step = 1 }; // System param - Enabled/Disabled
			var SlagSensitivity_Const = new ConstParams { Id = SlagSensitivity_Const_Id, Min = 0, Max = 3, Step = 1 }; // System param - Off/Low/Default/High
			var SlagPostTime_Const = new ConstParams { Id = SlagPostTime_Const_Id, Min = 0, Max = 100, Step = 5 }; // System param
			var SlagCuttingSpeedReduction_Const = new ConstParams { Id = SlagCuttingSpeedReduction_Const_Id, Min = 50, Max = 100, Step = 1 }; // System param
			var StartPreflow_Const = new ConstParams { Id = StartPreflow_Const_Id, Min = 0, Max = 1, Step = 1 }; // System param - Yes/No
			var PreflowActive_Const = new ConstParams { Id = PreflowActive_Const_Id, Min = 0, Max = 1, Step = 1 }; // System param - Yes/No
			var PiercingHeightControl_Const = new ConstParams { Id = PiercingHeightControl_Const_Id, Min = 0, Max = 1, Step = 1 }; // System param - Enabled/Disabled
			var PiercingDetection_Const = new ConstParams { Id = PiercingDetection_Const_Id, Min = 0, Max = 1, Step = 1 }; // System param - Enabled/Disabled

			modelBuilder.Entity<ConstParams>().HasData(RetractHeight_Const);
			modelBuilder.Entity<ConstParams>().HasData(RetractPosition_Const);
			modelBuilder.Entity<ConstParams>().HasData(SlagSensitivity_Const);
			modelBuilder.Entity<ConstParams>().HasData(SlagPostTime_Const);
			modelBuilder.Entity<ConstParams>().HasData(SlagCuttingSpeedReduction_Const);
			modelBuilder.Entity<ConstParams>().HasData(StartPreflow_Const);
			modelBuilder.Entity<ConstParams>().HasData(PreflowActive_Const);
			modelBuilder.Entity<ConstParams>().HasData(PiercingHeightControl_Const);
			modelBuilder.Entity<ConstParams>().HasData(PiercingDetection_Const);

			var RetractHeight_Dyn_Id = Guid.NewGuid();
			var RetractPosition_Dyn_Id = Guid.NewGuid();
			var SlagSensitivity_Dyn_Id = Guid.NewGuid();
			var SlagPostTime_Dyn_Id = Guid.NewGuid();
			var SlagCuttingSpeedReduction_Dyn_Id = Guid.NewGuid();
			var StartPreflow_Dyn_Id = Guid.NewGuid();
			var PreflowActive_Dyn_Id = Guid.NewGuid();
			var PiercingHeightControl_Dyn_Id = Guid.NewGuid();
			var PiercingDetection_Dyn_Id = Guid.NewGuid();
			

			var RetractHeight_Dyn = new DynParams { Id = RetractHeight_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.RetractHeight, ConstParamsId = RetractHeight_Const_Id, Value = 100 };
			var RetractPosition_Dyn = new DynParams { Id = RetractPosition_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxAdditional.RetractPosition, ConstParamsId = RetractPosition_Const_Id, Value = 0 };
			var SlagSensitivity_Dyn = new DynParams { Id = SlagSensitivity_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.SlagSensitivity, ConstParamsId = SlagSensitivity_Const_Id, Value = 2 };
			var SlagPostTime_Dyn = new DynParams { Id = SlagPostTime_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxProcess.SlagPostTime, ConstParamsId = SlagPostTime_Const_Id, Value = 20 };
			var SlagCuttingSpeedReduction_Dyn = new DynParams { Id = SlagCuttingSpeedReduction_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction, ConstParamsId = SlagCuttingSpeedReduction_Const_Id, Value = 100 };
			var StartPreflow_Dyn = new DynParams { Id = StartPreflow_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxAdditional.StartPreflow, ConstParamsId = StartPreflow_Const_Id, Value = 0 };
			var PreflowActive_Dyn = new DynParams { Id = PreflowActive_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxAdditional.PreflowActive, ConstParamsId = PreflowActive_Const_Id, Value = 0 };
			var PiercingHeightControl_Dyn = new DynParams { Id = PiercingHeightControl_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxAdditional.PiercingHeightControl, ConstParamsId = PiercingHeightControl_Const_Id, Value = 0 };
			var PiercingDetection_Dyn = new DynParams { Id = PiercingDetection_Dyn_Id, ParamId = (int)IhtModbusParamDyn.eIdxAdditional.PiercingDetection, ConstParamsId = PiercingDetection_Const_Id, Value = 0 };

			modelBuilder.Entity<DynParams>().HasData(RetractHeight_Dyn);
			modelBuilder.Entity<DynParams>().HasData(RetractPosition_Dyn);
			modelBuilder.Entity<DynParams>().HasData(SlagSensitivity_Dyn);
			modelBuilder.Entity<DynParams>().HasData(SlagPostTime_Dyn);
			modelBuilder.Entity<DynParams>().HasData(SlagCuttingSpeedReduction_Dyn);
			modelBuilder.Entity<DynParams>().HasData(StartPreflow_Dyn);
			modelBuilder.Entity<DynParams>().HasData(PreflowActive_Dyn);
			modelBuilder.Entity<DynParams>().HasData(PiercingHeightControl_Dyn);
			modelBuilder.Entity<DynParams>().HasData(PiercingDetection_Dyn);

			var ParameterData_RetractHeight = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_RetractHeight", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = RetractHeight_Dyn_Id };
			var ParameterData_RetractPosition = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_RetractPosition", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Additional, DynParamsId = RetractPosition_Dyn_Id };
			var ParameterData_SlagSensitivity = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagSensitivity", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = SlagSensitivity_Dyn_Id };
			var ParameterData_SlagPostTime = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagPostTime", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Process, DynParamsId = SlagPostTime_Dyn_Id };
			var ParameterData_SlagCuttingSpeedReduction = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_SlagCuttingSpeedReduction", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Service, DynParamsId = SlagCuttingSpeedReduction_Dyn_Id };
			var ParameterData_StartPreflow = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_StartPreflow", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Additional, DynParamsId = StartPreflow_Dyn_Id };
			var ParameterData_PreflowActive = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PreflowActive", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Additional, DynParamsId = PreflowActive_Dyn_Id };
			var ParameterData_PiercingHeightControl = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PiercingHeightControl", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Additional, DynParamsId = PiercingHeightControl_Dyn_Id };
			var ParameterData_PiercingDetection = new ParameterData { Id = Guid.NewGuid(), ParamName = $"Device{apcDevice.Num}_PiercingDetection", APCDeviceId = apcDevice.Id, ParamGroupId = ParamGroup.Additional, DynParamsId = PiercingDetection_Dyn_Id };

			modelBuilder.Entity<ParameterData>().HasData(ParameterData_RetractHeight);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_RetractPosition);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagSensitivity);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagPostTime);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_SlagCuttingSpeedReduction);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_StartPreflow);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_PreflowActive);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_PiercingHeightControl);
			modelBuilder.Entity<ParameterData>().HasData(ParameterData_PiercingDetection);
		}
	}
}
