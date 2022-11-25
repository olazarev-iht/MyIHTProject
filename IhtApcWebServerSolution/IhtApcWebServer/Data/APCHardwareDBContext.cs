using Microsoft.EntityFrameworkCore;
using IhtApcWebServer.Data.Models.APCHardware;
using SharedComponents.IhtModbus;

namespace IhtApcWebServer.Data
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

		public DbSet<ParamViewGroup> ParamViewGroups { get; set; } = null!;

		public DbSet<ParamSettings> ParamSettings { get; set; } = null!;

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
            //modelBuilder.Entity<DynParams>()
            //.HasOne(s => s.ConstParams)
            //.WithMany(p => p.DynParams)
            //.HasForeignKey(t => t.ConstParamsId)
            //.OnDelete(DeleteBehavior.ClientCascade);

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

			modelBuilder.Entity<APCDevice>().HasData(APCDeviceList);


			//Seed ParamViewGroups Table
			var ParamViewGroupList = new List<ParamViewGroup>();

			var ParamViewGroup_HeightCalibration = new ParamViewGroup { Id = "HeightCalibration", GroupName = "Height Calibration", GroupOrder = 1 };
			ParamViewGroupList.Add(ParamViewGroup_HeightCalibration);
			var ParamViewGroup_RetractPosition = new ParamViewGroup { Id = "RetractPosition", GroupName = "Retract Position", GroupOrder = 2 };
			ParamViewGroupList.Add(ParamViewGroup_RetractPosition);
			var ParamViewGroup_Slag = new ParamViewGroup { Id = "Slag", GroupName = "Slag", GroupOrder = 3 };
			ParamViewGroupList.Add(ParamViewGroup_Slag);
			var ParamViewGroup_PreFlow = new ParamViewGroup { Id = "PreFlow", GroupName = "Pre Flow", GroupOrder = 4 };
			ParamViewGroupList.Add(ParamViewGroup_PreFlow);
			var ParamViewGroup_Piercing = new ParamViewGroup { Id = "Piercing", GroupName = "Piercing", GroupOrder = 5 };
			ParamViewGroupList.Add(ParamViewGroup_Piercing);
			var ParamViewGroup_HeightControl = new ParamViewGroup { Id = "HeightControl", GroupName = "Height Control", GroupOrder = 6 };
			ParamViewGroupList.Add(ParamViewGroup_HeightControl);

			modelBuilder.Entity<ParamViewGroup>().HasData(ParamViewGroupList);

			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			//Seed ParamSettings Table row for client - default
			var ParamSettingsList_default = new List<ParamSettings>();

			var ParamSettings1 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, ParamOrder = 1 };
			ParamSettingsList_default.Add(ParamSettings1);
			var ParamSettings2 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.DistanceCalibration.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, ParamOrder = 2 };
			ParamSettingsList_default.Add(ParamSettings2);
			
			var ParamSettings3 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcess.RetractHeight.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_RetractPosition.Id, ParamOrder = 1 };
			ParamSettingsList_default.Add(ParamSettings3);
			var ParamSettings4 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.RetractPosition.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_RetractPosition.Id, ParamOrder = 2 };
			ParamSettingsList_default.Add(ParamSettings4);

			var ParamSettings5 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcess.SlagSensitivity.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_Slag.Id, ParamOrder = 1 };
			ParamSettingsList_default.Add(ParamSettings5);
			var ParamSettings6 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcess.SlagPostTime.ToString(), ClientId = "default", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_Slag.Id, ParamOrder = 2 };
			ParamSettingsList_default.Add(ParamSettings6);
			var ParamSettings7 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction.ToString(), ClientId = "default", PasswordLevel = 2, ParamViewGroupId = ParamViewGroup_Slag.Id, ParamOrder = 3 };
			ParamSettingsList_default.Add(ParamSettings7);

			var ParamSettings8 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.StartPreflow.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 1 };
			ParamSettingsList_default.Add(ParamSettings8);
			var ParamSettings9 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.PreflowActive.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 2 };
			ParamSettingsList_default.Add(ParamSettings9);
			var ParamSettings10 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime.ToString(), ClientId = "default", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 3 };
			ParamSettingsList_default.Add(ParamSettings10);
			var ParamSettings11 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure.ToString(), ClientId = "default", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 4 };
			ParamSettingsList_default.Add(ParamSettings11);
			var ParamSettings12 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut.ToString(), ClientId = "default", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 5 };
			ParamSettingsList_default.Add(ParamSettings12);

			var ParamSettings13 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.PiercingHeightControl.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_Piercing.Id, ParamOrder = 1 };
			ParamSettingsList_default.Add(ParamSettings13);
			var ParamSettings14 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.PiercingDetection.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_Piercing.Id, ParamOrder = 2 };
			ParamSettingsList_default.Add(ParamSettings14);

			var ParamSettings15 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.Dynamic.ToString(), ClientId = "default", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 1 };
			ParamSettingsList_default.Add(ParamSettings15);
			var ParamSettings16 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.HeightControlActive.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 2 };
			ParamSettingsList_default.Add(ParamSettings16);
			var ParamSettings17 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.Off.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 3 };
			ParamSettingsList_default.Add(ParamSettings17);
			var ParamSettings18 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightPreHeat.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 4 };
			ParamSettingsList_default.Add(ParamSettings18);
			var ParamSettings19 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 5 };
			ParamSettingsList_default.Add(ParamSettings19);
			var ParamSettings20 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightCut.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 6 };
			ParamSettingsList_default.Add(ParamSettings20);

			modelBuilder.Entity<ParamSettings>().HasData(ParamSettingsList_default);

			//////////////////////////////////////////////////////////////////////////////////////////////
			
			//Seed ParamSettings Table row for client - client1
			var ParamSettingsList_client1 = new List<ParamSettings>();

			var ParamSettings_client1_1 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, ParamOrder = 1 };
			ParamSettingsList_client1.Add(ParamSettings_client1_1);
			var ParamSettings_client1_2 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.DistanceCalibration.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, ParamOrder = 2 };
			ParamSettingsList_client1.Add(ParamSettings_client1_2);

			var ParamSettings_client1_3 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcess.RetractHeight.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_RetractPosition.Id, ParamOrder = 1 };
			ParamSettingsList_client1.Add(ParamSettings_client1_3);
			var ParamSettings_client1_4 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.RetractPosition.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_RetractPosition.Id, ParamOrder = 2 };
			ParamSettingsList_client1.Add(ParamSettings_client1_4);

			var ParamSettings_client1_5 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcess.SlagSensitivity.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_Slag.Id, ParamOrder = 1 };
			ParamSettingsList_client1.Add(ParamSettings_client1_5);
			var ParamSettings_client1_6 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcess.SlagPostTime.ToString(), ClientId = "client1", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_Slag.Id, ParamOrder = 2 };
			ParamSettingsList_client1.Add(ParamSettings_client1_6);
			var ParamSettings_client1_7 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction.ToString(), ClientId = "client1", PasswordLevel = 2, ParamViewGroupId = ParamViewGroup_Slag.Id, ParamOrder = 3 };
			ParamSettingsList_client1.Add(ParamSettings_client1_7);

			var ParamSettings_client1_8 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.StartPreflow.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 1 };
			ParamSettingsList_client1.Add(ParamSettings_client1_8);
			var ParamSettings_client1_9 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.PreflowActive.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 2 };
			ParamSettingsList_client1.Add(ParamSettings_client1_9);
			var ParamSettings_client1_10 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime.ToString(), ClientId = "client1", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 3 };
			ParamSettingsList_client1.Add(ParamSettings_client1_10);
			var ParamSettings_client1_11 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure.ToString(), ClientId = "client1", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 4 };
			ParamSettingsList_client1.Add(ParamSettings_client1_11);
			var ParamSettings_client1_12 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut.ToString(), ClientId = "client1", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 5 };
			ParamSettingsList_client1.Add(ParamSettings_client1_12);

			var ParamSettings_client1_13 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.PiercingHeightControl.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_Piercing.Id, ParamOrder = 1 };
			ParamSettingsList_client1.Add(ParamSettings_client1_13);
			var ParamSettings_client1_14 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.PiercingDetection.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_Piercing.Id, ParamOrder = 2 };
			ParamSettingsList_client1.Add(ParamSettings_client1_14);

			var ParamSettings_client1_15 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.Dynamic.ToString(), ClientId = "client1", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 1 };
			ParamSettingsList_client1.Add(ParamSettings_client1_15);
			var ParamSettings_client1_16 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.HeightControlActive.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 2 };
			ParamSettingsList_client1.Add(ParamSettings_client1_16);
			var ParamSettings_client1_17 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.Off.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 3 };
			ParamSettingsList_client1.Add(ParamSettings_client1_17);
			var ParamSettings_client1_18 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightPreHeat.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 4 };
			ParamSettingsList_client1.Add(ParamSettings_client1_18);
			var ParamSettings_client1_19 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 5 };
			ParamSettingsList_client1.Add(ParamSettings_client1_19);
			var ParamSettings_client1_20 = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightCut.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 6 };
			ParamSettingsList_client1.Add(ParamSettings_client1_20);

			modelBuilder.Entity<ParamSettings>().HasData(ParamSettingsList_client1);
		}
	}
}


