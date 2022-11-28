using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;

namespace SharedComponents.Models.APCHardware
{
    public class ParameterDataModel
    {
        public Guid Id { get; set; }

        private string _paramName = string.Empty;
        public string ParamName
        {
            get
            {
                return _paramName.Contains('_') ? _paramName.Split('_')[1] : _paramName;
            }

            set => _paramName = value;
        }
        public Guid APCDeviceId { get; set; }
        public APCDeviceModel? APCDevice { get; set; } = new();
        public ParamGroup ParamGroupId { get; set; }
        public Guid? DynParamsId { get; set; }
        public DynParamsModel? DynParams { get; set; } = new();
        public ParamSettingsModel ParamSettings { get; set; } = new();
        public string ViewGroup
        {
            get
            {
                return ParamSettings?.ParamViewGroup?.GroupName ?? string.Empty;
            }
        }

        public int ViewGroupOrder
        {
            get
            {
                return ParamSettings.ParamViewGroup?.GroupOrder ?? 100;
            }
        }

        public int ViewItemOrder
        {
            get
            {
                return ParamSettings.ParamOrder;
            }
        }

        public IhtDevices.PasswordLevel_SW PasswordLevel
        {
            get
            {
                return (IhtDevices.PasswordLevel_SW)ParamSettings.PasswordLevel;
            }
        }

        //public Dictionary<string, (string Group, int GroupOrder, int ItemOrder)> _viewGroupDictionary = new Dictionary<string, (string, int, int)>()
        //{
        //    { IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding.ToString(), (ViewGroups.HeightCalibration.Group, ViewGroups.HeightCalibration.Order, 1)},
        //    { IhtModbusParamDyn.eIdxConfig.DistanceCalibration.ToString(), (ViewGroups.HeightCalibration.Group, ViewGroups.HeightCalibration.Order, 2)},

        //    { IhtModbusParamDyn.eIdxProcess.RetractHeight.ToString(), (ViewGroups.RetractPosition.Group, ViewGroups.RetractPosition.Order, 1)},
        //    // RetractPosition - experimental
        //    { IhtModbusParamDyn.eIdxAdditional.RetractPosition.ToString(), (ViewGroups.RetractPosition.Group, ViewGroups.RetractPosition.Order, 2)},

        //    { IhtModbusParamDyn.eIdxProcess.SlagSensitivity.ToString(), (ViewGroups.Slag.Group, ViewGroups.Slag.Order, 1)},
        //    { IhtModbusParamDyn.eIdxProcess.SlagPostTime.ToString(), (ViewGroups.Slag.Group, ViewGroups.Slag.Order, 2)},
        //    { IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction.ToString(), (ViewGroups.Slag.Group, ViewGroups.Slag.Order, 3)},

        //    { IhtModbusParamDyn.eIdxAdditional.StartPreflow.ToString(), (ViewGroups.PreFlow.Group, ViewGroups.PreFlow.Order, 1)},
        //    { IhtModbusParamDyn.eIdxAdditional.PreflowActive.ToString(), (ViewGroups.PreFlow.Group, ViewGroups.PreFlow.Order, 2)},
        //    { IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime.ToString(), (ViewGroups.PreFlow.Group, ViewGroups.PreFlow.Order, 3)},
        //    { IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure.ToString(), (ViewGroups.PreFlow.Group, ViewGroups.PreFlow.Order, 4)},
        //    { IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut.ToString(), (ViewGroups.PreFlow.Group, ViewGroups.PreFlow.Order, 5)},

        //    { IhtModbusParamDyn.eIdxAdditional.PiercingHeightControl.ToString(), (ViewGroups.Piercing.Group, ViewGroups.Piercing.Order, 1)},
        //    { IhtModbusParamDyn.eIdxAdditional.PiercingDetection.ToString(), (ViewGroups.Piercing.Group, ViewGroups.Piercing.Order, 2)},

        //    { IhtModbusParamDyn.eIdxConfig.Dynamic.ToString(), (ViewGroups.HeightControl.Group, ViewGroups.HeightControl.Order, 1)},
        //    { IhtModbusParamDyn.eIdxAdditional.HeightControlActive.ToString(), (ViewGroups.HeightControl.Group, ViewGroups.HeightControl.Order, 2)},
        //    { IhtModbusParamDyn.eStatusHeightCtrl.Off.ToString(), (ViewGroups.HeightControl.Group, ViewGroups.HeightControl.Order, 3)},
        //    { IhtModbusParamDyn.eStatusHeightCtrl.HeightPreHeat.ToString(), (ViewGroups.HeightControl.Group, ViewGroups.HeightControl.Order, 4)},
        //    { IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce.ToString(), (ViewGroups.HeightControl.Group, ViewGroups.HeightControl.Order, 5)},
        //    { IhtModbusParamDyn.eStatusHeightCtrl.HeightCut.ToString(), (ViewGroups.HeightControl.Group, ViewGroups.HeightControl.Order, 6)}
        //};

        //public Dictionary<string, IhtDevices.PasswordLevel_SW> _passwordLevelDictionary = new Dictionary<string, IhtDevices.PasswordLevel_SW>()
        //{
        //    { IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding.ToString(), IhtDevices.PasswordLevel_SW.Level_0 },
        //    { IhtModbusParamDyn.eIdxConfig.DistanceCalibration.ToString(), IhtDevices.PasswordLevel_SW.Level_0 },

        //    { IhtModbusParamDyn.eIdxProcess.RetractHeight.ToString(), IhtDevices.PasswordLevel_SW.Level_0 },
        //    // RetractPosition - experimental
        //    { IhtModbusParamDyn.eIdxAdditional.RetractPosition.ToString(), IhtDevices.PasswordLevel_SW.Level_0 },

        //    { IhtModbusParamDyn.eIdxProcess.SlagSensitivity.ToString(), IhtDevices.PasswordLevel_SW.Level_0 },
        //    { IhtModbusParamDyn.eIdxProcess.SlagPostTime.ToString(), IhtDevices.PasswordLevel_SW.Level_1 },
        //    { IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction.ToString(), IhtDevices.PasswordLevel_SW.Level_2 },

        //    { IhtModbusParamDyn.eIdxAdditional.StartPreflow.ToString(), IhtDevices.PasswordLevel_SW.Level_0 },
        //    { IhtModbusParamDyn.eIdxAdditional.PreflowActive.ToString(), IhtDevices.PasswordLevel_SW.Level_0 },
        //    { IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTime.ToString(), IhtDevices.PasswordLevel_SW.Level_1 },
        //    { IhtModbusParamDyn.eIdxConfig.CutO2BlowOutPressure.ToString(), IhtDevices.PasswordLevel_SW.Level_1 },
        //    { IhtModbusParamDyn.eIdxConfig.CutO2BlowOutTimeOut.ToString(), IhtDevices.PasswordLevel_SW.Level_1 },

        //    { IhtModbusParamDyn.eIdxAdditional.PiercingHeightControl.ToString(), IhtDevices.PasswordLevel_SW.Level_0 },
        //    { IhtModbusParamDyn.eIdxAdditional.PiercingDetection.ToString(), IhtDevices.PasswordLevel_SW.Level_0 },

        //    { IhtModbusParamDyn.eIdxConfig.Dynamic.ToString(), IhtDevices.PasswordLevel_SW.Level_1 },
        //    { IhtModbusParamDyn.eIdxAdditional.HeightControlActive.ToString(), IhtDevices.PasswordLevel_SW.Level_0 },
        //    { IhtModbusParamDyn.eStatusHeightCtrl.Off.ToString(), IhtDevices.PasswordLevel_SW.Level_0 },
        //    { IhtModbusParamDyn.eStatusHeightCtrl.HeightPreHeat.ToString(), IhtDevices.PasswordLevel_SW.Level_0 },
        //    { IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce.ToString(), IhtDevices.PasswordLevel_SW.Level_0 },
        //    { IhtModbusParamDyn.eStatusHeightCtrl.HeightCut.ToString(), IhtDevices.PasswordLevel_SW.Level_0 }
        //};

    }

    //class ViewGroups
    //{
    //    public static (string Group, int Order) HeightCalibration = ("Height Calibration", 1);
    //    public static (string Group, int Order) RetractPosition = ("Retract Position", 2);
    //    public static (string Group, int Order) Slag = ("Slag", 3);
    //    public static (string Group, int Order) PreFlow = ("Pre Flow", 4);
    //    public static (string Group, int Order) Piercing = ("Piercing", 5);
    //    public static (string Group, int Order) HeightControl = ("Height Control", 6);
    //}
}
