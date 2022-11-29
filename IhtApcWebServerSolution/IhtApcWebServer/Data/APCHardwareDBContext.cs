﻿using Microsoft.EntityFrameworkCore;
using IhtApcWebServer.Data.Models.APCHardware;
using SharedComponents.IhtModbus;
using SharedComponents.IhtModbusCmd;

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

			//Automatic Height Calibration
			var ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, ParamOrder = 1 };
			ParamSettingsList_default.Add(ParamSettings);
			//Manual Height Calibration
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.DistanceCalibration.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, ParamOrder = 2 };
			ParamSettingsList_default.Add(ParamSettings);
			//Position (read only)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcessInfo.LinearDrivePosition.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, ParamOrder = 3 };
			ParamSettingsList_default.Add(ParamSettings);
			//Height Calibration Valid (read only)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusBit.CalibrationValid.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, ParamOrder = 4 };
			ParamSettingsList_default.Add(ParamSettings);
			//Height Calibration Active (read only)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusBit.CalibrationActive.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration.Id, ParamOrder = 5 };
			ParamSettingsList_default.Add(ParamSettings);

			//Retract Position
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcess.RetractHeight.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_RetractPosition.Id, ParamOrder = 1 };
			ParamSettingsList_default.Add(ParamSettings);
			//Retract Position (read only)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusCmdExecSwitch.eCmdBit.RetractPosAtProcessEnd.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_RetractPosition.Id, ParamOrder = 2 };
			ParamSettingsList_default.Add(ParamSettings);

			//Slag Sensitivity
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcess.SlagSensitivity.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_Slag.Id, ParamOrder = 1 };
			ParamSettingsList_default.Add(ParamSettings);
			//Slag Post Time
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcess.SlagPostTime.ToString(), ClientId = "default", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_Slag.Id, ParamOrder = 2 };
			ParamSettingsList_default.Add(ParamSettings);
			//Slag Cutting Speed Reduction (Slag detection Yes/No)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction.ToString(), ClientId = "default", PasswordLevel = 2, ParamViewGroupId = ParamViewGroup_Slag.Id, ParamOrder = 3 };
			ParamSettingsList_default.Add(ParamSettings);

			//Start Preflow
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusCmdExecTactile.eCmdBit.CutO2Blowout.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 1 };
			ParamSettingsList_default.Add(ParamSettings);
			//Break Preflow
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusCmdExecTactile.eCmdBit.CutO2BlowoutBreak.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 2 };
			ParamSettingsList_default.Add(ParamSettings);
			//Preflow active (read only)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusBit.CutO2BlowoutActive.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 3 };
			ParamSettingsList_default.Add(ParamSettings);
			//Preflow active time (read only)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcessInfo.CurrCutO2BlowoutTime.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 4 };
			ParamSettingsList_default.Add(ParamSettings);
			//PreFlow Time
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime.ToString(), ClientId = "default", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 5 };
			ParamSettingsList_default.Add(ParamSettings);
			//PreFlow Pressure
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure.ToString(), ClientId = "default", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 6 };
			ParamSettingsList_default.Add(ParamSettings);
			//PreFlow Timeout
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut.ToString(), ClientId = "default", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_PreFlow.Id, ParamOrder = 7 };
			ParamSettingsList_default.Add(ParamSettings);

			//Piercing with Height Control
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_Piercing.Id, ParamOrder = 1 };
			ParamSettingsList_default.Add(ParamSettings);
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.PiercingDetection.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_Piercing.Id, ParamOrder = 2 };
			ParamSettingsList_default.Add(ParamSettings);

			//Dynamic
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.Dynamic.ToString(), ClientId = "default", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 1 };
			ParamSettingsList_default.Add(ParamSettings);
			//Height Control Active ---- IsHeightControlActive = (StatusHeightControl != (int)IhtModbusParamDyn.eStatusHeightCtrl.Off) && !IsInpClearanceCtrlOff;
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusInpBit.ClearanceCtrlOff.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 2 };
			ParamSettingsList_default.Add(ParamSettings);
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.Off.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 3 };
			ParamSettingsList_default.Add(ParamSettings);
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightPreHeat.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 4 };
			ParamSettingsList_default.Add(ParamSettings);
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 5 };
			ParamSettingsList_default.Add(ParamSettings);
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightCut.ToString(), ClientId = "default", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl.Id, ParamOrder = 6 };
			ParamSettingsList_default.Add(ParamSettings);

			modelBuilder.Entity<ParamSettings>().HasData(ParamSettingsList_default);

			//////////////////////////////////////////////////////////////////////////////////////////////
			
			//Seed ParamSettings Table row for client - client1
			var ParamSettingsList_client1 = new List<ParamSettings>();

			//Automatic Height Calibration
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_RetractPosition_client1.Id, ParamOrder = 1 };
			ParamSettingsList_client1.Add(ParamSettings);
			//Manual Height Calibration
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.DistanceCalibration.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration_client1.Id, ParamOrder = 2 };
			ParamSettingsList_client1.Add(ParamSettings);
			//Position (read only)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcessInfo.LinearDrivePosition.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration_client1.Id, ParamOrder = 3 };
			ParamSettingsList_client1.Add(ParamSettings);
			//Height Calibration Valid (read only)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusBit.CalibrationValid.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration_client1.Id, ParamOrder = 4 };
			ParamSettingsList_client1.Add(ParamSettings);
			//Height Calibration Active (read only)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusBit.CalibrationActive.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration_client1.Id, ParamOrder = 5 };
			ParamSettingsList_client1.Add(ParamSettings);

			//Retract Position
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcess.RetractHeight.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration_client1.Id, ParamOrder = 1 };
			ParamSettingsList_client1.Add(ParamSettings);
			//Retract Position (read only)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusCmdExecSwitch.eCmdBit.RetractPosAtProcessEnd.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_RetractPosition_client1.Id, ParamOrder = 2 };
			ParamSettingsList_client1.Add(ParamSettings);

			//Slag Sensitivity
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcess.SlagSensitivity.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_Slag_client1.Id, ParamOrder = 1 };
			ParamSettingsList_client1.Add(ParamSettings);
			//Slag Post Time
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcess.SlagPostTime.ToString(), ClientId = "client1", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_Slag_client1.Id, ParamOrder = 2 };
			ParamSettingsList_client1.Add(ParamSettings);
			//Slag Cutting Speed Reduction (Slag detection Yes/No)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction.ToString(), ClientId = "client1", PasswordLevel = 2, ParamViewGroupId = ParamViewGroup_Slag_client1.Id, ParamOrder = 3 };
			ParamSettingsList_client1.Add(ParamSettings);

			//Start Preflow
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusCmdExecTactile.eCmdBit.CutO2Blowout.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_PreFlow_client1.Id, ParamOrder = 3 };
			ParamSettingsList_client1.Add(ParamSettings);
			//Break Preflow
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusCmdExecTactile.eCmdBit.CutO2BlowoutBreak.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_PreFlow_client1.Id, ParamOrder = 2 };
			ParamSettingsList_client1.Add(ParamSettings);
			//Preflow active (read only)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusBit.CutO2BlowoutActive.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_PreFlow_client1.Id, ParamOrder = 1 };
			ParamSettingsList_client1.Add(ParamSettings);
			//Preflow active time (read only)
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcessInfo.CurrCutO2BlowoutTime.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_PreFlow_client1.Id, ParamOrder = 4 };
			ParamSettingsList_client1.Add(ParamSettings);
			//PreFlow Time
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime.ToString(), ClientId = "client1", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_PreFlow_client1.Id, ParamOrder = 5 };
			ParamSettingsList_client1.Add(ParamSettings);
			//PreFlow Pressure
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure.ToString(), ClientId = "client1", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_PreFlow_client1.Id, ParamOrder = 6 };
			ParamSettingsList_client1.Add(ParamSettings);
			//PreFlow Timeout
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut.ToString(), ClientId = "client1", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_PreFlow_client1.Id, ParamOrder = 7 };
			ParamSettingsList_client1.Add(ParamSettings);

			//Piercing with Height Control
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_Piercing_client1.Id, ParamOrder = 1 };
			ParamSettingsList_client1.Add(ParamSettings);
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxAdditional.PiercingDetection.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_Piercing_client1.Id, ParamOrder = 2 };
			ParamSettingsList_client1.Add(ParamSettings);

			//Dynamic
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxConfig.Dynamic.ToString(), ClientId = "client1", PasswordLevel = 1, ParamViewGroupId = ParamViewGroup_HeightControl_client1.Id, ParamOrder = 1 };
			ParamSettingsList_client1.Add(ParamSettings);
			//Height Control Active ---- IsHeightControlActive = (StatusHeightControl != (int)IhtModbusParamDyn.eStatusHeightCtrl.Off) && !IsInpClearanceCtrlOff;
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusInpBit.ClearanceCtrlOff.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl_client1.Id, ParamOrder = 2 };
			ParamSettingsList_client1.Add(ParamSettings);
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eIdxProcessInfo.LinearDrivePosition.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightCalibration_client1.Id, ParamOrder = 3 };
			ParamSettingsList_client1.Add(ParamSettings);
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.Off.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl_client1.Id, ParamOrder = 4 };
			ParamSettingsList_client1.Add(ParamSettings);
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightPreHeat.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl_client1.Id, ParamOrder = 5 };
			ParamSettingsList_client1.Add(ParamSettings);
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl_client1.Id, ParamOrder = 6 };
			ParamSettingsList_client1.Add(ParamSettings);
			ParamSettings = new ParamSettings { Id = Guid.NewGuid(), ParamId = IhtModbusParamDyn.eStatusHeightCtrl.HeightCut.ToString(), ClientId = "client1", PasswordLevel = 0, ParamViewGroupId = ParamViewGroup_HeightControl_client1.Id, ParamOrder = 7 };
			ParamSettingsList_client1.Add(ParamSettings);

			modelBuilder.Entity<ParamSettings>().HasData(ParamSettingsList_client1);
		}
	}
}


