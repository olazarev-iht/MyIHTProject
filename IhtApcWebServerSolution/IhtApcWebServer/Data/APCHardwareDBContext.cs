using Microsoft.EntityFrameworkCore;
using IhtApcWebServer.Data.Models.APCHardware;
using IhtApcWebServer.Extensions;
using SharedComponents.IhtModbus;
using SharedComponents.IhtModbusCmd;
using SharedComponents.Models.APCHardware;

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

		public DbSet<ConfigSettings> ConfigSettings { get; set; } = null!;

        public DbSet<ErrorLog> ErrorLogs { get; set; } = null!;

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

			var ConfigSetting = new ConfigSettings { Id = Guid.NewGuid() };

			modelBuilder.Entity<ConfigSettings>().HasData(ConfigSetting);

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

			var ParamViewGroup_HeightCalibration_client1 = new ParamViewGroup { Id = "HeightCalibration_client1", GroupName = "Height Calibration", GroupOrder = 1 };
			ParamViewGroupList.Add(ParamViewGroup_HeightCalibration_client1);
			var ParamViewGroup_RetractPosition_client1 = new ParamViewGroup { Id = "RetractPosition_client1", GroupName = "Retract Position", GroupOrder = 3 };
			ParamViewGroupList.Add(ParamViewGroup_RetractPosition_client1);
			var ParamViewGroup_Slag_client1 = new ParamViewGroup { Id = "Slag_client1", GroupName = "Slag", GroupOrder = 2 };
			ParamViewGroupList.Add(ParamViewGroup_Slag_client1);
			var ParamViewGroup_PreFlow_client1 = new ParamViewGroup { Id = "PreFlow_client1", GroupName = "Pre Flow", GroupOrder = 4 };
			ParamViewGroupList.Add(ParamViewGroup_PreFlow_client1);
			var ParamViewGroup_Piercing_client1 = new ParamViewGroup { Id = "Piercing_client1", GroupName = "Piercing", GroupOrder = 5 };
			ParamViewGroupList.Add(ParamViewGroup_Piercing_client1);
			var ParamViewGroup_HeightControl_client1 = new ParamViewGroup { Id = "HeightControl_client1", GroupName = "Height Control", GroupOrder = 6 };
			ParamViewGroupList.Add(ParamViewGroup_HeightControl_client1);

			modelBuilder.Entity<ParamViewGroup>().HasData(ParamViewGroupList);

			////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

			//Seed ParamSettings Table row for client - default
			var ParamSettingsList_default = new List<ParamSettings>();

			//Automatic Height Calibration (Dyn) --- IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding
			var ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.TactileInitialPosFinding.ToString(), 
				//ParamGroup = ParamGroup.Config, 
				//DisplayName = SettingParamIds.TactileInitialPosFinding.GetDescription(), 
				//Format = @"{ 'Mode':'Switch', 'Values': ['Disable', 'Enable'] }", 
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, 
				ParamOrder = 1 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Manual Height Calibration (Dyn) --- IhtModbusParamDyn.eIdxConfig.DistanceCalibration
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.DistanceCalibration.ToString(), 
				//ParamGroup = ParamGroup.Config, 
				//DisplayName = SettingParamIds.DistanceCalibration.GetDescription(), 
				//Format = @"{ 'Mode':'Slider', 'Unit' : true }", 
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, 
				ParamOrder = 2 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Position (read only) (NonDyn) --- IhtModbusParamDyn.eIdxProcessInfo.LinearDrivePosition
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.LinearDrivePosition.ToString(), 
				//ParamGroup = ParamGroup.ProcessInfo, 
				//ParamType = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.LinearDrivePosition].paramType, 
				//ParamName = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.LinearDrivePosition].paramName, 
				//DisplayName = SettingParamIds.LinearDrivePosition.GetDescription(), 
				//Format = @"{ 'Unit' : true }", 
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, 
				ParamOrder = 3 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Height Calibration Valid (read only) (NonDyn) --- IhtModbusParamDyn.eStatusBit.CalibrationValid
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.CalibrationValid.ToString(),
				//ParamType = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.CalibrationValid].paramType,
				//ParamName = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.CalibrationValid].paramName,
				//DisplayName = SettingParamIds.CalibrationValid.GetDescription(), 
				//Format = @"{ 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }", 
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, 
				ParamOrder = 4 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Height Calibration Active (read only) (NonDyn) --- IhtModbusParamDyn.eStatusBit.CalibrationActive
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.CalibrationActive.ToString(),
				//ParamType = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.CalibrationActive].paramType,
				//ParamName = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.CalibrationActive].paramName,
				//DisplayName = SettingParamIds.CalibrationActive.GetDescription(),
				//Format = @"{ 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }", 
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, 
				ParamOrder = 5 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Retract Position (Dyn) --- IhtModbusParamDyn.eIdxProcess.RetractHeight
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.RetractHeight.ToString(), 
				//ParamGroup = ParamGroup.Process,
				//DisplayName = SettingParamIds.RetractHeight.GetDescription(),
				//Format = @"{ 'Name':'Retract Position', 'Mode':'Slider' }", 
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_RetractPosition.Id, 
				ParamOrder = 1 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Retract Position enable (read only) (NonDyn) --- IhtModbusCmdExecSwitch.eCmdBit.RetractPosAtProcessEnd
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.RetractPosAtProcessEnd.ToString(),
				//ParamType = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.RetractPosAtProcessEnd].paramType,
				//ParamName = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.RetractPosAtProcessEnd].paramName,
				//DisplayName = SettingParamIds.RetractPosAtProcessEnd.GetDescription(),
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_RetractPosition.Id, 
				ParamOrder = 2 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Slag Sensitivity (Dyn) --- IhtModbusParamDyn.eIdxProcess.SlagSensitivity
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.SlagSensitivity.ToString(), 
				//ParamGroup = ParamGroup.Process, 
				//DisplayName = SettingParamIds.SlagSensitivity.GetDescription(),
				//Format = @"{ 'Mode':'Select', 'Values': ['Off','Low','Default','High'] }", 
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_Slag.Id, 
				ParamOrder = 1 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Slag Post Time (Dyn) --- IhtModbusParamDyn.eIdxProcess.SlagPostTime
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.SlagPostTime.ToString(), 
				//ParamGroup = ParamGroup.Process,
				//DisplayName = SettingParamIds.SlagPostTime.GetDescription(),
				//Format = @"{ 'Mode':'Slider' }", 
				ClientId = "default", 
				PasswordLevel = 1, 
				ParamViewGroupId = ParamViewGroup_Slag.Id, 
				ParamOrder = 2 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Slag Cutting Speed Reduction (Slag detection Yes/No) (Dyn) --- IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.SlagCuttingSpeedReduction.ToString(), 
				//ParamGroup = ParamGroup.Service, 
				//DisplayName = SettingParamIds.SlagCuttingSpeedReduction.GetDescription(),
				//Format = @"{ 'Mode':'Slider' }", 
				ClientId = "default", 
				PasswordLevel = 2, 
				ParamViewGroupId = ParamViewGroup_Slag.Id, 
				ParamOrder = 3 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Start Preflow ?????? (Command) --- IhtModbusCmdExecTactile.eCmdBit.CutO2Blowout
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.CutO2Blowout.ToString(),
				//DisplayName = SettingParamIds.CutO2Blowout.GetDescription(),
				//Format = @"{ 'Mode':'Button', 'Values': ['Start'] }", 
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_PreFlow.Id, 
				ParamOrder = 1 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Break Preflow ?????? (Command) --- IhtModbusCmdExecTactile.eCmdBit.CutO2BlowoutBreak
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.CutO2BlowoutBreak.ToString(),
				//DisplayName = SettingParamIds.CutO2BlowoutBreak.GetDescription(),
				//Format = @"{ 'Mode':'Button', 'Values': ['Break'] }",
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_PreFlow.Id, 
				ParamOrder = 2 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Preflow active (read only) (NonDyn) --- IhtModbusParamDyn.eStatusBit.CutO2BlowoutActive
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.CutO2BlowoutActive.ToString(),
				//ParamType = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.CutO2BlowoutActive].paramType,
				//ParamName = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.CutO2BlowoutActive].paramName,
				//DisplayName = SettingParamIds.CutO2BlowoutActive.GetDescription(),
				//Format = @"{ 'Mode':'NoYes', 'Values':['No','Yes'],'ReadOnly':true }",
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_PreFlow.Id, 
				ParamOrder = 3 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Preflow active time (read only) (NonDyn) --- IhtModbusParamDyn.eIdxProcessInfo.CurrCutO2BlowoutTime
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.CurrCutO2BlowoutTime.ToString(), 
				//ParamGroup = ParamGroup.ProcessInfo,
				//ParamType = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.CurrCutO2BlowoutTime].paramType,
				//ParamName = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.CurrCutO2BlowoutTime].paramName,
				//DisplayName = SettingParamIds.CurrCutO2BlowoutTime.GetDescription(),
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_PreFlow.Id, 
				ParamOrder = 4 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//PreFlow Time (Dyn) --- IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.CutO2BlowOutTime.ToString(), 
				//ParamGroup = ParamGroup.Config,
				//DisplayName = SettingParamIds.CutO2BlowOutTime.GetDescription(),
				//Format = @"{ 'Mode':'Slider' }", 
				ClientId = "default", 
				PasswordLevel = 1, 
				ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 5 };
			ParamSettingsList_default.Add(ParamSettings);

			//PreFlow Pressure (Dyn) --- IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.CutO2BlowOutPressure.ToString(), 
				//ParamGroup = ParamGroup.Config,
				//DisplayName = SettingParamIds.CutO2BlowOutPressure.GetDescription(),
				//Format = @"{ 'Mode':'Slider' }", 
				ClientId = "default", 
				PasswordLevel = 1, 
				ParamViewGroupId = ParamViewGroup_PreFlow.Id, 
				ParamOrder = 6 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//PreFlow Timeout (Dyn) --- IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.CutO2BlowOutTimeOut.ToString(), 
				//ParamGroup = ParamGroup.Config,
				//DisplayName = SettingParamIds.CutO2BlowOutTimeOut.GetDescription(),
				//Format = @"{ 'Mode':'Slider' }", 
				ClientId = "default", 
				PasswordLevel = 1, 
				ParamViewGroupId = ParamViewGroup_PreFlow.Id, 
				ParamOrder = 7 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Piercing with Height Control ???? (Dyn) --- IhtModbusParamDyn.eIdxProcess.PiercingSensorMode
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.PiercingSensorMode.ToString(), 
				//ParamGroup = ParamGroup.Process,
				//DisplayName = SettingParamIds.PiercingSensorMode.GetDescription(),
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_Piercing.Id, 
				ParamOrder = 1 
			};
			ParamSettingsList_default.Add(ParamSettings);
			//Piercing detection ???? will use in the future
			// ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.PiercingDetection.ToString(), ParamName = "Piercing detection", ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_Piercing.Id, ParamOrder = 2 };
			// ParamSettingsList_default.Add(ParamSettings);

			//Dynamic (Dyn) --- IhtModbusParamDyn.eIdxConfig.Dynamic
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.Dynamic.ToString(), 
				//ParamGroup = ParamGroup.Config,
				//DisplayName = SettingParamIds.Dynamic.GetDescription(),
				//Format = @"{ 'Mode':'Slider' }", 
				ClientId = "default", 
				PasswordLevel = 1, 
				ParamViewGroupId = ParamViewGroup_HeightControl.Id, 
				ParamOrder = 1 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Height Control Active (NonDyn) ---- IsHeightControlActive = (StatusHeightControl != (int)IhtModbusParamDyn.eStatusHeightCtrl.Off) && !IsInpClearanceCtrlOff;
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.HeightControlActive.ToString(),
				//ParamType = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.HeightControlActive].paramType,
				//ParamName = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.HeightControlActive].paramName,
				//DisplayName = SettingParamIds.HeightControlActive.GetDescription(),
				//Format = @"{ 'Mode':'NoYes', 'Values': ['No','Yes'], 'ReadOnly':true }", 
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_HeightControl.Id, 
				ParamOrder = 2 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//Position (read only) --- IhtModbusParamDyn.eIdxProcessInfo.LinearDrivePosition
			ParamSettings = new ParamSettings { 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.LinearDrivePosition.ToString(),
				//ParamType = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.LinearDrivePosition].paramType,
				//ParamName = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.LinearDrivePosition].paramName,
				//DisplayName = SettingParamIds.LinearDrivePosition.GetDescription(),
				//Format = @"{ 'Unit' : true }", 
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_HeightControl.Id, 
				ParamOrder = 3 
			};
			ParamSettingsList_default.Add(ParamSettings);

			// StatusHeightControl - Off, Preheating, Piercing, Cutting --- IhtModbusParamDyn.eIdxProcessInfo.StatusHeightControl
			ParamSettings = new ParamSettings 
			{ 
				Id = Guid.NewGuid(), 
				ParamId = SettingParamIds.StatusHeightControl.ToString(),
				//ParamType = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.StatusHeightControl].paramType,
				//ParamName = ParamGroupHelper.NonDynSettingParamTypeAndName[SettingParamIds.StatusHeightControl].paramName,
				//DisplayName = SettingParamIds.StatusHeightControl.GetDescription(),
				//Format = @"{ 'Mode':'Select', 'Values': ['Off','PreHeating','Piercing','Cutting'] }", 
				ClientId = "default", 
				PasswordLevel = 0, 
				ParamViewGroupId = ParamViewGroup_HeightControl.Id, 
				ParamOrder = 4 
			};
			ParamSettingsList_default.Add(ParamSettings);

			//////////////////////////////////////////////////////////////////////////////////////////////

			modelBuilder.Entity<ParamSettings>().HasData(ParamSettingsList_default);
		}
	}
}


