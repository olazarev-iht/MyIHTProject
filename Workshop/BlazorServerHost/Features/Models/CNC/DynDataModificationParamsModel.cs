using SharedComponents.Models.APCHardware;

namespace BlazorServerHost.Features.Models.CNC
{
    public class DynDataModificationParamsModel
    {
        public int CurrentDeviceNumber { get; set; } = 1;
        public string CurrentParamsType { get; set; } = "Ignition";

        //public IEnumerable<ParameterDataModel> CurrentParameters { get; set; } = Enumerable.Empty<ParameterDataModel>();
        public ParameterDataModel HeatO2Param { get; set; } = null;
        public ParameterDataModel? FuelGasParam { get; set; } = null;
        public ParameterDataModel? CutO2Param { get; set; } = null;
    }
}
