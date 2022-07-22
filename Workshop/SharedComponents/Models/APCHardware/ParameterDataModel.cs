using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.IhtModbus;

namespace SharedComponents.Models.APCHardware
{
    public class ParameterDataModel
    {
        public Guid Id { get; set; }
        public string ParamName { get; set; } = "";
        public Guid APCDeviceId { get; set; }
        public APCDeviceModel? APCDevice { get; set; } = new();
        public ParamGroup ParamGroupId { get; set; }
        public Guid? DynParamsId { get; set; }
        public DynParamsModel? DynParams { get; set; } = new();
        public string ViewGroup
        {
            get
            {
                var paramName = ParamName.Split("_")[1];
                return _viewGroupDictionary[paramName];
            }
        }

        public Dictionary<string, string> _viewGroupDictionary = new Dictionary<string, string>()
        {
            { IhtModbusParamDyn.eIdxConfig.TactileInitialPosFinding.ToString(), ViewGroups.HeightCalibration},
            { IhtModbusParamDyn.eIdxConfig.DistanceCalibration.ToString(), ViewGroups.HeightCalibration},

            { IhtModbusParamDyn.eIdxProcess.RetractHeight.ToString(), ViewGroups.RetractPosition},
            // RetractPosition - experimental
            { IhtModbusParamDyn.eIdxAdditional.RetractPosition.ToString(), ViewGroups.RetractPosition},

            { IhtModbusParamDyn.eIdxProcess.SlagSensitivity.ToString(), ViewGroups.Slag},
            { IhtModbusParamDyn.eIdxProcess.SlagPostTime.ToString(), ViewGroups.Slag},
            { IhtModbusParamDyn.eIdxService.SlagCuttingSpeedReduction.ToString(), ViewGroups.Slag},

            { IhtModbusParamDyn.eIdxAdditional.StartPreflow.ToString(), ViewGroups.PreFlow},
            { IhtModbusParamDyn.eIdxAdditional.PreflowActive.ToString(), ViewGroups.PreFlow},

            { IhtModbusParamDyn.eIdxAdditional.PiercingHeightControl.ToString(), ViewGroups.Piercing},
            { IhtModbusParamDyn.eIdxAdditional.PiercingDetection.ToString(), ViewGroups.Piercing},

            { IhtModbusParamDyn.eIdxConfig.Dynamic.ToString(), ViewGroups.HeightControl},
            { IhtModbusParamDyn.eIdxAdditional.HeightControlActive.ToString(), ViewGroups.HeightControl},
            { IhtModbusParamDyn.eStatusHeightCtrl.Off.ToString(), ViewGroups.HeightControl},
            { IhtModbusParamDyn.eStatusHeightCtrl.HeightPreHeat.ToString(), ViewGroups.HeightControl},
            { IhtModbusParamDyn.eStatusHeightCtrl.HeightPierce.ToString(), ViewGroups.HeightControl},
            { IhtModbusParamDyn.eStatusHeightCtrl.HeightCut.ToString(), ViewGroups.HeightControl},
            
        };

    }

    class ViewGroups
    {
        public static string HeightCalibration = "Height Calibration";
        public static string RetractPosition = "Retract Position";
        public static string Slag = "Slag";
        public static string PreFlow = "Pre Flow";
        public static string Piercing = "Piercing";
        public static string HeightControl = "Height Control";       
    }
}
