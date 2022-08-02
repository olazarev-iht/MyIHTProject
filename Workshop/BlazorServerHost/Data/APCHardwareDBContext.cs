using Microsoft.EntityFrameworkCore;
using BlazorServerHost.Data.Models.APCHardware;
using SharedComponents.IhtModbus;
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

		public DbSet<ViewParamGroup> ViewParamGroups { get; set; } = null!;

		public DbSet<ViewParamOrder> ViewParamOrders { get; set; } = null!;

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

			
			var ViewParamGroup_HeightCalibration = new ViewParamGroup { Id = Guid.NewGuid(), Name = "Height Calibration", ViewOrder = 1 };
			var ViewParamGroup_RetractPosition = new ViewParamGroup { Id = Guid.NewGuid(), Name = "Retract Position", ViewOrder = 2 };
			var ViewParamGroup_Slag = new ViewParamGroup { Id = Guid.NewGuid(), Name = "Slag", ViewOrder = 3 };
			var ViewParamGroup_PreFlow = new ViewParamGroup { Id = Guid.NewGuid(), Name = "Pre Flow", ViewOrder = 4 };
			var ViewParamGroup_Piercing = new ViewParamGroup { Id = Guid.NewGuid(), Name = "Piercing", ViewOrder = 5 };
			var ViewParamGroup_HeightControl = new ViewParamGroup { Id = Guid.NewGuid(), Name = "Height Control", ViewOrder = 6 };

			//////////////////////////////////////////// View Param Groups /////////////////////////////////
			
			modelBuilder.Entity<ViewParamGroup>().HasData(ViewParamGroup_HeightCalibration);
			modelBuilder.Entity<ViewParamGroup>().HasData(ViewParamGroup_RetractPosition);
			modelBuilder.Entity<ViewParamGroup>().HasData(ViewParamGroup_Slag);
			modelBuilder.Entity<ViewParamGroup>().HasData(ViewParamGroup_PreFlow);
			modelBuilder.Entity<ViewParamGroup>().HasData(ViewParamGroup_Piercing);
			modelBuilder.Entity<ViewParamGroup>().HasData(ViewParamGroup_HeightControl);

			List<int> APCDeviceNums = new() { 1, 2, 3 };

			foreach (var deviceNum in APCDeviceNums)
            {
				CreateViewParamOrder(
					modelBuilder, 
					deviceNum, 
					ViewParamGroup_HeightCalibration,
					ViewParamGroup_RetractPosition,
					ViewParamGroup_Slag,
					ViewParamGroup_PreFlow,
					ViewParamGroup_Piercing,
					ViewParamGroup_HeightControl);
			}
		}

		public void CreateViewParamOrder(
			ModelBuilder modelBuilder, 
			int APCDeviceNum, 
			ViewParamGroup ViewParamGroup_HeightCalibration,
			ViewParamGroup ViewParamGroup_RetractPosition,
			ViewParamGroup ViewParamGroup_Slag,
			ViewParamGroup ViewParamGroup_PreFlow,
			ViewParamGroup ViewParamGroup_Piercing,
			ViewParamGroup ViewParamGroup_HeightControl)
		{
			//////////////////////////////////////////////////////// View Param Orders //////////////////////////////
			var ViewParamOrderList = new List<ViewParamOrder>();

			// ViewParamGroup_HeightCalibration
			var ViewParamOrder_TactileInitialPosFinding = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Config, ViewParamGroupId = ViewParamGroup_HeightCalibration.Id, ViewItemOrder = 1 };
			var ViewParamOrder_DistanceCalibration = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxConfig.DistanceCalibration.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Config, ViewParamGroupId = ViewParamGroup_HeightCalibration.Id, ViewItemOrder = 2 };

			ViewParamOrderList.Add(ViewParamOrder_TactileInitialPosFinding);
			ViewParamOrderList.Add(ViewParamOrder_DistanceCalibration);

			// ViewParamGroup_RetractPosition
			var ViewParamOrder_RetractHeight = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxProcess.RetractHeight.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Process, ViewParamGroupId = ViewParamGroup_RetractPosition.Id, ViewItemOrder = 1 };
			var ViewParamOrder_RetractPosition = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxAdditional.RetractPosition.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Additional, ViewParamGroupId = ViewParamGroup_RetractPosition.Id, ViewItemOrder = 2 };

			ViewParamOrderList.Add(ViewParamOrder_RetractHeight);
			ViewParamOrderList.Add(ViewParamOrder_RetractPosition);

			// ViewParamGroup_Slag
			var ViewParamOrder_SlagSensitivity = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxProcess.SlagSensitivity.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Process, ViewParamGroupId = ViewParamGroup_Slag.Id, ViewItemOrder = 1 };
			var ViewParamOrder_SlagPostTime = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxProcess.SlagPostTime.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Process, ViewParamGroupId = ViewParamGroup_Slag.Id, ViewItemOrder = 2 };
			var ViewParamOrder_SlagCuttingSpeedReduction = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Service, ViewParamGroupId = ViewParamGroup_Slag.Id, ViewItemOrder = 3 };

			ViewParamOrderList.Add(ViewParamOrder_SlagSensitivity);
			ViewParamOrderList.Add(ViewParamOrder_SlagPostTime);
			ViewParamOrderList.Add(ViewParamOrder_SlagCuttingSpeedReduction);

			// ViewParamGroup_PreFlow
			var ViewParamOrder_StartPreflow = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxAdditional.StartPreflow.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Additional, ViewParamGroupId = ViewParamGroup_PreFlow.Id, ViewItemOrder = 1 };
			var ViewParamOrder_PreflowActive = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxAdditional.PreflowActive.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Additional, ViewParamGroupId = ViewParamGroup_PreFlow.Id, ViewItemOrder = 2 };
			var ViewParamOrder_CutO2BlowOutTime = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Config, ViewParamGroupId = ViewParamGroup_PreFlow.Id, ViewItemOrder = 3 };
			var ViewParamOrder_CutO2BlowOutPressure = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Config, ViewParamGroupId = ViewParamGroup_PreFlow.Id, ViewItemOrder = 4 };
			var ViewParamOrder_CutO2BlowOutTimeOut = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Config, ViewParamGroupId = ViewParamGroup_PreFlow.Id, ViewItemOrder = 5 };

			ViewParamOrderList.Add(ViewParamOrder_StartPreflow);
			ViewParamOrderList.Add(ViewParamOrder_PreflowActive);
			ViewParamOrderList.Add(ViewParamOrder_CutO2BlowOutTime);
			ViewParamOrderList.Add(ViewParamOrder_CutO2BlowOutPressure);
			ViewParamOrderList.Add(ViewParamOrder_CutO2BlowOutTimeOut);

			// ViewParamGroup_Piercing
			var ViewParamOrder_PiercingHeightControl = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxAdditional.PiercingHeightControl.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Additional, ViewParamGroupId = ViewParamGroup_Piercing.Id, ViewItemOrder = 1 };
			var ViewParamOrder_PiercingDetection = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxAdditional.PiercingDetection.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Additional, ViewParamGroupId = ViewParamGroup_Piercing.Id, ViewItemOrder = 2 };

			ViewParamOrderList.Add(ViewParamOrder_PiercingHeightControl);
			ViewParamOrderList.Add(ViewParamOrder_PiercingDetection);

			// ViewParamGroup_HeightControl
			var ViewParamOrder_Dynamic = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxConfig.Dynamic.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Config, ViewParamGroupId = ViewParamGroup_HeightControl.Id, ViewItemOrder = 1 };
			var ViewParamOrder_HeightControlActive = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eIdxAdditional.HeightControlActive.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.Additional, ViewParamGroupId = ViewParamGroup_HeightControl.Id, ViewItemOrder = 2 };
			var ViewParamOrder_Off = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eStatusHeightCtrl.Off.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.StatusHeightCtrl, ViewParamGroupId = ViewParamGroup_HeightControl.Id, ViewItemOrder = 3 };
			var ViewParamOrder_HeightPreHeat = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eStatusHeightCtrl.HeightPreHeat.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.StatusHeightCtrl, ViewParamGroupId = ViewParamGroup_HeightControl.Id, ViewItemOrder = 4 };
			var ViewParamOrder_HeightPierce = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.StatusHeightCtrl, ViewParamGroupId = ViewParamGroup_HeightControl.Id, ViewItemOrder = 5 };
			var ViewParamOrder_HeightCut = new ViewParamOrder { Id = Guid.NewGuid(), ParamName = IhtModbusParamDyn.eStatusHeightCtrl.HeightCut.ToString(), APCDeviceNum = APCDeviceNum, ParamGroupId = ParamGroup.StatusHeightCtrl, ViewParamGroupId = ViewParamGroup_HeightControl.Id, ViewItemOrder = 6 };

			ViewParamOrderList.Add(ViewParamOrder_Dynamic);
			ViewParamOrderList.Add(ViewParamOrder_HeightControlActive);
			ViewParamOrderList.Add(ViewParamOrder_Off);
			ViewParamOrderList.Add(ViewParamOrder_HeightPreHeat);
			ViewParamOrderList.Add(ViewParamOrder_HeightPierce);
			ViewParamOrderList.Add(ViewParamOrder_HeightCut);

			modelBuilder.Entity<ViewParamOrder>().HasData(ViewParamOrderList);
		}
	}
}


