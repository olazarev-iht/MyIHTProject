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

		private int stepsNum = 5;
		private int? _minForSlider 
		{
			get
			{
				return ConstParamsSettings[(IhtModbusParamDyn.eIdxTechnology)ParamId].min;
			}
			
			set 
			{
				var max = ConstParamsSettings[(IhtModbusParamDyn.eIdxTechnology)ParamId].max;
				ConstParamsSettings[(IhtModbusParamDyn.eIdxTechnology)ParamId] = (value, max);
			}
		}

		public int MinForSlider 
        {
            get
            {
                if (ConstParams != null && this.IsBarUnits && _minForSlider == null)
                {
                    _minForSlider = Value - ConstParams.Step * stepsNum;

                    if (_minForSlider < ConstParams.Min) _minForSlider = ConstParams.Min;
                }

                return _minForSlider ?? 0;
            }
        }

		private int? _maxForSlider
		{
			get
			{
				return ConstParamsSettings[(IhtModbusParamDyn.eIdxTechnology)ParamId].max;
			}

			set
			{
				var min = ConstParamsSettings[(IhtModbusParamDyn.eIdxTechnology)ParamId].min;
				ConstParamsSettings[(IhtModbusParamDyn.eIdxTechnology)ParamId] = (min, value);
			}
		}
		public int MaxForSlider
        {
            get
            {
                if (ConstParams != null && this.IsBarUnits && _maxForSlider == null)
                {
                    _maxForSlider = Value + ConstParams.Step * stepsNum;

                    if (_maxForSlider > ConstParams.Max) _maxForSlider = ConstParams.Max;
                }

                return _maxForSlider ?? 0;
            }
        }

        private bool IsBarUnits
        {
            get
            {
                return (ParameterDataInfo?.Unit ?? "").Equals(Units.txtBar, StringComparison.OrdinalIgnoreCase);
            }
        }


        //public DynParamsModel()
        //{
        //    if (MinForSlider == null && MaxForSlider == null)
        //    {
        //        MinForSlider = GetMinForSlider();

        //        MaxForSlider = GetMaxForSlider();
        //    }
        //}

        //private int GetMinForSlider()
        //{
        //    var returnValue = 0;

        //    if (ConstParams != null && this.IsBarUnits)
        //    {
        //        returnValue = Value - ConstParams.Step * stepsNum;

        //        if (returnValue < 0) returnValue = 0;
        //    }

        //    return returnValue;
        //}

        //private int GetMaxForSlider()
        //{
        //    var returnValue = 0;

        //    if (ConstParams != null && this.IsBarUnits)
        //    {
        //        returnValue = Value + ConstParams.Step * stepsNum;
        //    }

        //    return returnValue;
        //}



    }
}

