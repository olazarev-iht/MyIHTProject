using SharedComponents.Helpers;
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

		//public ParameterDataModel parameterDataModel { get; set; } = new();
		public ICollection<ParameterDataModel> ParameterDatas { get; set; } = new List<ParameterDataModel>();

		public static Dictionary<IhtModbusParamDyn.eIdxTechnology, (int? min, int? max)> ConstParamsSettings = new()
		{
			{ IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition, (null, null) },
			{ IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition, (null, null) },
			{ IhtModbusParamDyn.eIdxTechnology.IgnitionFlameAdjust, (null, null) },
			{ IhtModbusParamDyn.eIdxTechnology.HeatO2PreHeat, (null, null) },
			{ IhtModbusParamDyn.eIdxTechnology.FuelGasPreHeat, (null, null) },
			{ IhtModbusParamDyn.eIdxTechnology.HeatO2Pierce, (null, null) },
			{ IhtModbusParamDyn.eIdxTechnology.FuelGasPierce, (null, null) },
			{ IhtModbusParamDyn.eIdxTechnology.CutO2Pierce, (null, null) },
			{ IhtModbusParamDyn.eIdxTechnology.HeatO2Cut, (null, null) },
			{ IhtModbusParamDyn.eIdxTechnology.FuelGasCut, (null, null) },
			{ IhtModbusParamDyn.eIdxTechnology.CutO2Cut, (null, null) }
		};

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
				return ConstParamsSettings.ContainsKey(eIdxTechnology);
			}
		}

		private int stepsNum = 5;
		private int? _minForSlider 
		{
			get
			{
				if (IsParamForSlider)
				{
					return ConstParamsSettings[eIdxTechnology].min;
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
					var max = ConstParamsSettings[eIdxTechnology].max;
					ConstParamsSettings[eIdxTechnology] = (value, max);
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

		private int? _maxForSlider
		{
			get
			{
				if (IsParamForSlider)
				{
					return ConstParamsSettings[eIdxTechnology].max;
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
					var min = ConstParamsSettings[(IhtModbusParamDyn.eIdxTechnology)ParamId].min;
					ConstParamsSettings[(IhtModbusParamDyn.eIdxTechnology)ParamId] = (min, value);
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

