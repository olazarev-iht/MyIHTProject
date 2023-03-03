using SharedComponents.Helpers;
using SharedComponents.IhtDev;
using SharedComponents.IhtModbus;
using SharedComponents.IhtModbusCmd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedComponents.Models.APCHardware
{
    public class DynParamsModel
    {
        // may be delete the Id
        public Guid Id { get; set; }
        public int ParamId { get; set; }
        public int Address { get; set; }
        public Guid? ConstParamsId { get; set; }
        public ConstParamsModel? ConstParams { get; set; } = new();
        public Guid? ParameterDataInfoId { get; set; }
        public ParameterDataInfoModel? ParameterDataInfo { get; set; } = new();
        public int Value { get; set; }

		public ICollection<ParameterDataModel> ParameterDatas { get; set; } = new List<ParameterDataModel>();


		private Dictionary<IhtModbusParamDyn.eIdxTechnology, (int? min, int? max)>? ConstParamsSettings
		{
			get
			{
				var currDeviceNum = ParameterDatas?.SingleOrDefault()?.APCDevice?.Num;

				if (currDeviceNum != null)
				{
					var ihtDevice = IhtDevices.GetIhtDevices().GetDevice((int)currDeviceNum + (int)IhtModbusCommunic.SlaveId.Id_Default);

					return ihtDevice?.ConstParamsSettings;
				}

				return null;
			}
		}

		private IhtModbusParamDyn.eIdxTechnology eIdxTechnology
		{
			get
			{
				return (IhtModbusParamDyn.eIdxTechnology)ParamId;
			}
		}

		private bool IsParamForSlider
		{
			get
			{
				return ConstParamsSettings?.ContainsKey(eIdxTechnology) ?? false;
			}
		}

		private int stepsNum = 5;

		/// <summary>
		/// To get/set min value of the ConstParamsSettings Dictionary
		/// </summary>
		private int? _minForSlider 
		{
			get
			{
				if (IsParamForSlider)
				{
					return ConstParamsSettings?[eIdxTechnology].min;
				}
				else 
				{ 
					return null;
				}
			}
			
			set 
			{
				if (IsParamForSlider)
				{
					if (ConstParamsSettings != null)
					{
						var max = ConstParamsSettings?[eIdxTechnology].max;
						ConstParamsSettings[eIdxTechnology] = (value, max);
					}
				}
			}
		}

		public int MinForSlider 
        {
            get
            {
				if (IsParamForSlider)
				{
					if (_minForSlider == null)
					{
						SetMinForSlider();
					}
				}

				return _minForSlider ?? 0;
            }
        }

		/// <summary>
		/// To get/set max value of the ConstParamsSettings Dictionary
		/// </summary>
		private int? _maxForSlider
		{
			get
			{
				if (IsParamForSlider)
				{
					return ConstParamsSettings?[eIdxTechnology].max;
				}
				else
				{
					return null;
				}
			}

			set
			{
				if (IsParamForSlider)
				{
					if (ConstParamsSettings != null)
					{
						var min = ConstParamsSettings?[eIdxTechnology].min;
						ConstParamsSettings[eIdxTechnology] = (min, value);
					}
				}
			}
		}

		public int MaxForSlider
        {
            get
            {
				if (IsParamForSlider)
				{
					if (_maxForSlider == null)
					{
						SetMaxForSlider();
					}
				}

				return _maxForSlider ?? 0;
            }
        }

		public void SetMinForSlider()
		{
			if (ConstParams != null && IsParamForSlider)
			{
				_minForSlider = Value - ConstParams.Step * stepsNum;

				if (_minForSlider < ConstParams.Min) _minForSlider = ConstParams.Min;
			}
		}

		public void SetMaxForSlider()
		{
			if (ConstParams != null && IsParamForSlider)
			{
				_maxForSlider = Value + ConstParams.Step * stepsNum;

				if (_maxForSlider > ConstParams.Max) _maxForSlider = ConstParams.Max;
			}
		}
	}
}

