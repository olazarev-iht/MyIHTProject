using BlazorServerHost.Data;
using SharedComponents.Models;

namespace BlazorServerHost.Extensions
{
	public static class CuttingParametersExtensions
	{
		public static CuttingParametersModel ToModel(this CuttingParameterSet set)
		{
			return new CuttingParametersModel()
			{
				Id = set.Id,
				Thickness = set.Thickness,
				HeatingHeight = set.HeatingHeight,
				CuttingHeight = set.CuttingHeight,
			};
		}

		public static CuttingParameterSet FromModel(this CuttingParametersModel model)
		{
			return new CuttingParameterSet().CopyFromModel(model);
		}

		public static CuttingParameterSet CopyFromModel(this CuttingParameterSet set, CuttingParametersModel model)
		{
			set.Thickness = model.Thickness;
			set.HeatingHeight = model.HeatingHeight;
			set.CuttingHeight = model.CuttingHeight;
			return set;
		}
	}
}
