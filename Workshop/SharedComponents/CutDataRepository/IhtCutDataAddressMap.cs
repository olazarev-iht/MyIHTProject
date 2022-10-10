using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedComponents.Helpers;
using SharedComponents.IhtModbus;
using SharedComponents.Models.APCHardware;
using SharedComponents.Models.CuttingData;

namespace SharedComponents.CutDataRepository
{
    class IhtCutDataMap
    {
        public IhtCutDataMap() { }
        public IhtCutDataMap(string _paramText, double _multiplier, string _unit, int _min, int _max, int _step)
        {
            this.paramText = _paramText;
            this.multiplier = _multiplier;
            this.unit = _unit;
            this.min = _min;
            this.max = _max;
            this.step = _step;
        }

        public string paramText { get; set; }
        public double multiplier { get; set; }
        public string unit { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public int step { get; set; }
    }
   
    public class IhtCutDataAddressMap
    {
        private Dictionary<IhtModbusParamDyn.eIdxTechnology, IhtCutDataMap> addressMap = new Dictionary<IhtModbusParamDyn.eIdxTechnology, IhtCutDataMap>();
        private UInt16[] au16TechnologyConst;
        private Dictionary<IhtModbusParamDyn.eIdxTechnology, UInt16> paramsDyn = new Dictionary<IhtModbusParamDyn.eIdxTechnology, UInt16>();

        /// <summary>
        /// 
        /// </summary>
        public IhtCutDataAddressMap()
        {
            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetData(CuttingDataModel cutData, IhtModbusData ihtModbusData)
        {
            SetValue(cutData.PreHeatHeight, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.PreHeatHeight);
            SetValue(cutData.PierceHeight, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.PierceHeight);
            SetValue(cutData.CutHeight, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.CutHeight);
            SetValue(cutData.PI0, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition);
            SetValue(cutData.PreHeatHeatingOxygenPressure, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.HeatO2PreHeat);
            SetValue(cutData.PierceHeatingOxygenPressure, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.HeatO2Pierce);
            SetValue(cutData.CutHeatingOxygenPressure, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.HeatO2Cut);
            SetValue(cutData.PierceCuttingOxygenPressure, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.CutO2Pierce);
            SetValue(cutData.CutCuttingOxygenPressure, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.CutO2Cut);
            SetValue(cutData.PI1, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition);
            SetValue(cutData.PreHeatFuelGasPressure, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.FuelGasPreHeat);
            SetValue(cutData.PierceFuelGasPressure, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.FuelGasPierce);
            SetValue(cutData.CutFuelGasPressure, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.FuelGasCut);
            SetValue(cutData.PreHeatTime, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.PreHeatTime);
            SetValue(cutData.PP1, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.PiercePreTime);
            SetValue(cutData.PierceTime, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.PierceTime);
            SetValue(cutData.PP2, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.PiercePostTime);
            SetValue(cutData.PP3, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.PierceHeightRampTime);
            SetValue(cutData.PP4, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.CutHeightRampTime);
            SetValue(cutData.PP0, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.PierceMode);
            SetValue(cutData.IgnitionFlameAdjustment, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.IgnitionFlameAdjust);
            SetValue(cutData.Gas.GasId, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.GasType);
            SetValue(cutData.CuttingSpeed, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.CuttingSpeed);
            SetValue(cutData.PierceCuttingSpeedChange, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.PierceCuttingSpeedChange);
            SetValue(cutData.Controlbits, ihtModbusData, IhtModbusParamDyn.eIdxTechnology.ControlBits);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetParamDynValue(UInt16 u16Value, IhtModbusParamDyn.eIdxTechnology eIdxTechnology)
        {
            UInt16 u16Data = 0;
            if (paramsDyn.TryGetValue(eIdxTechnology, out u16Data))
            {
                paramsDyn[eIdxTechnology] = u16Value;
            }
            else
            {
                paramsDyn.Add(eIdxTechnology, u16Value);
            }
        }

            /// <summary>
            /// 
            /// </summary>
            private void SetValue(double value, IhtModbusData ihtModbusdata, IhtModbusParamDyn.eIdxTechnology eIdxTechnology)
            {
                UInt16 u16Value = 0;
                IhtCutDataMap ihtCutDataMap = null;

                if (addressMap.TryGetValue(eIdxTechnology, out ihtCutDataMap))
                {
                    //u16Value = Convert.ToUInt16(value * ihtCutDataMap.multiplier);
                    u16Value = Convert.ToUInt16(value);

                    ihtModbusdata.SetValue(eIdxTechnology, u16Value);
                }

                SetParamDynValue(u16Value, eIdxTechnology);
            }


            /// <summary>
            /// 
            /// </summary>
            internal static void GetParamTextAndUnit(string paramText, out string paramTextNew, ref string unit, bool blPasswordValid)
        {
            paramTextNew = paramText;

            string[] paramTexts = paramText.Split(';');

            if (paramTexts.Length == 1)
            {
                paramTextNew = paramText;
            }
            else if (paramTexts.Length == 2)
            {
                paramTextNew = (blPasswordValid) ? paramTexts[0] + ": " + paramTexts[1] : paramTexts[0];
            }
            else if (paramTexts.Length == 3)
            {
                if (blPasswordValid)
                {
                    paramTextNew = paramTexts[0] + ": " + paramTexts[1];
                    //unit = paramTexts[2]; todo
                }
                else
                {
                    paramTextNew = paramTexts[0];
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        //private IhtCutDataSetParam GetCutDataSetParam(string paramText, string _value, string unit, bool blPasswordValid)
        //{
        //    /*
        //          string[] paramTexts = paramText.Split(';');
        //          string txt = String.Empty;

        //          if (paramTexts.Length == 1) 
        //          {
        //            txt = paramText;
        //          }
        //          else if (paramTexts.Length == 2)
        //          {
        //            txt = (blPasswordValid) ? paramTexts[0] + ": " + paramTexts[1] : paramTexts[0];
        //          }
        //          else if (paramTexts.Length == 3)
        //          {
        //            if (blPasswordValid)
        //            {
        //              txt  = paramTexts[0] + ": " + paramTexts[1];
        //              unit = paramTexts[2];
        //            }
        //            else
        //            {
        //              txt = paramTexts[0];
        //            }
        //          }
        //    */
        //    string paramTextNew = String.Empty;
        //    GetParamTextAndUnit(paramText, out paramTextNew, ref unit, blPasswordValid);
        //    return new IhtCutDataSetParam(paramTextNew, _value, unit);
        //}

        /// <summary>
        /// 
        /// </summary>
        //private IhtCutDataSetParam GetListViewItem(double value, string paramText, string unit, bool blPasswordValid)
        //{
        //    string _value = String.Empty;
        //    if (unit == Units.txtPsi && Units.IsPressurePsi)
        //    {
        //        _value = Units.GetFormattedPressurePsi(value * Units.psiMultiplier, false);
        //    }
        //    else if ((Units.IsUnitInch || Units.IsUnitInchFractional) && (unit == Units.txtInch || unit == Units.txtInch_min))
        //    {
        //        _value = Units.GetFormattedUnitInch(value * Units.inchMultiplier);
        //    }
        //    else
        //    {
        //        _value = value.ToString();
        //    }

        //    IhtCutDataSetParam item = GetCutDataSetParam(paramText, _value, unit, blPasswordValid);
        //    return item;
        //}

        /// <summary>
        /// 
        /// </summary>
        //private IhtCutDataSetParam GetListViewItem(double value, IhtModbusParamDyn.eIdxTechnology eIdxTechnology, ref string unit, bool blPasswordValid)
        //{
        //    IhtCutDataSetParam item = new IhtCutDataSetParam();

        //    IhtCutDataMap ihtCutDataMap = null;
        //    if (addressMap.TryGetValue(eIdxTechnology, out ihtCutDataMap))
        //    {
        //        unit = IhtModbusUnitParam.GetTechnology((UInt16)eIdxTechnology);
        //        ihtCutDataMap.unit = unit;

        //        string _value = String.Empty;
        //        if (unit == Units.txtPsi && Units.IsPressurePsi)
        //        {
        //            _value = Units.GetFormattedPressurePsi(value * Units.psiMultiplier, false);
        //        }
        //        else if ((Units.IsUnitInch || Units.IsUnitInchFractional) && (unit == Units.txtInch || unit == Units.txtInch_min))
        //        {
        //            _value = Units.GetFormattedUnitInch(value * Units.inchMultiplier);
        //        }
        //        else
        //        {
        //            _value = value.ToString();
        //        }

        //        UInt16 u16Value = Convert.ToUInt16(value * ihtCutDataMap.multiplier);
        //        SetParamDynValue(u16Value, eIdxTechnology);

        //        item = GetCutDataSetParam(ihtCutDataMap.paramText, _value, unit, blPasswordValid);
        //    }
        //    return item;
        //}

        /// <summary>
        /// 
        /// </summary>
        public string GetDescription(IhtModbusParamDyn.eIdxTechnology eIdxTechnology)
        {
            IhtCutDataMap ihtCutDataMap = null;
            if (addressMap.TryGetValue(eIdxTechnology, out ihtCutDataMap))
            {
                return ihtCutDataMap.paramText;
            }
            return "Description";
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetUnit(IhtModbusParamDyn.eIdxTechnology eIdxTechnology)
        {
            IhtCutDataMap ihtCutDataMap = null;
            if (addressMap.TryGetValue(eIdxTechnology, out ihtCutDataMap))
            {
                return ihtCutDataMap.unit;
            }
            return String.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        internal double GetMultiplier(IhtModbusParamDyn.eIdxTechnology eIdxTechnology)
        {
            IhtCutDataMap ihtCutDataMap = null;
            if (addressMap.TryGetValue(eIdxTechnology, out ihtCutDataMap))
            {
                return 1.0 / ihtCutDataMap.multiplier;
            }
            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        internal int GetMin(IhtModbusParamDyn.eIdxTechnology eIdxTechnology)
        {
            IhtCutDataMap ihtCutDataMap = null;
            if (addressMap.TryGetValue(eIdxTechnology, out ihtCutDataMap))
            {
                return ihtCutDataMap.min;
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        internal int GetMax(IhtModbusParamDyn.eIdxTechnology eIdxTechnology)
        {
            IhtCutDataMap ihtCutDataMap = null;
            if (addressMap.TryGetValue(eIdxTechnology, out ihtCutDataMap))
            {
                return ihtCutDataMap.max;
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        internal int GetStep(IhtModbusParamDyn.eIdxTechnology eIdxTechnology)
        {
            IhtCutDataMap ihtCutDataMap = null;
            if (addressMap.TryGetValue(eIdxTechnology, out ihtCutDataMap))
            {
                return ihtCutDataMap.step;
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        internal int GetValue(IhtModbusParamDyn.eIdxTechnology eIdxTechnology)
        {
            UInt16 u16Data = 0;
            if (paramsDyn.TryGetValue(eIdxTechnology, out u16Data))
            {
                return u16Data;
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        //public List<IhtCutDataSetParam> GetListViewItems(CCutData cutData, bool blPasswordValid, int passwordLevel_SW = (int)IhtDevices.PasswordLevel_SW.Level_3)
        //{
        //    List<IhtCutDataSetParam> items = new List<IhtCutDataSetParam>();
        //    string unit = String.Empty;
        //    bool isPassworLevel_1 = passwordLevel_SW == (int)IhtDevices.PasswordLevel_SW.Level_1 || blPasswordValid;
        //    items.Add(GetListViewItem(cutData.PreHeatHeight, IhtModbusParamDyn.eIdxTechnology.PreHeatHeight, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PierceHeight, IhtModbusParamDyn.eIdxTechnology.PierceHeight, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.CutHeight, IhtModbusParamDyn.eIdxTechnology.CutHeight, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PI0, IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition, ref unit, isPassworLevel_1));
        //    items.Add(GetListViewItem(cutData.PreHeatHeatingOxygenPressure, IhtModbusParamDyn.eIdxTechnology.HeatO2PreHeat, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PierceHeatingOxygenPressure, IhtModbusParamDyn.eIdxTechnology.HeatO2Pierce, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.CutHeatingOxygenPressure, IhtModbusParamDyn.eIdxTechnology.HeatO2Cut, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PierceCuttingOxygenPressure, IhtModbusParamDyn.eIdxTechnology.CutO2Pierce, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.CutCuttingOxygenPressure, IhtModbusParamDyn.eIdxTechnology.CutO2Cut, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PI1, IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition, ref unit, isPassworLevel_1));
        //    items.Add(GetListViewItem(cutData.PreHeatFuelGasPressure, IhtModbusParamDyn.eIdxTechnology.FuelGasPreHeat, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PierceFuelGasPressure, IhtModbusParamDyn.eIdxTechnology.FuelGasPierce, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.CutFuelGasPressure, IhtModbusParamDyn.eIdxTechnology.FuelGasCut, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PreHeatTime, IhtModbusParamDyn.eIdxTechnology.PreHeatTime, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PP1, IhtModbusParamDyn.eIdxTechnology.PiercePreTime, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PierceTime, IhtModbusParamDyn.eIdxTechnology.PierceTime, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PP2, IhtModbusParamDyn.eIdxTechnology.PiercePostTime, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PP3, IhtModbusParamDyn.eIdxTechnology.PierceHeightRampTime, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PP4, IhtModbusParamDyn.eIdxTechnology.CutHeightRampTime, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PP0, IhtModbusParamDyn.eIdxTechnology.PierceMode, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.IgnitionFlameAdjustment, IhtModbusParamDyn.eIdxTechnology.IgnitionFlameAdjust, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.IdGas, IhtModbusParamDyn.eIdxTechnology.GasType, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.CuttingSpeed, IhtModbusParamDyn.eIdxTechnology.CuttingSpeed, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.PierceCuttingSpeedChange, IhtModbusParamDyn.eIdxTechnology.PierceCuttingSpeedChange, ref unit, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.ControlBits, IhtModbusParamDyn.eIdxTechnology.ControlBits, ref unit, blPasswordValid));

        //    items.Add(GetListViewItem(cutData.Kerf, "Kerf width", IhtModbusUnitParam.IsUnitInch ? Units.txtInch : Units.txtMm, blPasswordValid));
        //    items.Add(GetListViewItem(cutData.LeadInLength, "LeadIn length", IhtModbusUnitParam.IsUnitInch ? Units.txtInch : Units.txtMm, blPasswordValid));
        //    return items;
        //}

        /// <summary>
        /// 
        /// </summary>
        private IhtCutDataMap GenerateCutDataMap(string _paramText, IhtModbusParamDyn.eIdxTechnology eIdxTechnology)
        {
            UInt16 u16IdxTechnology = (UInt16)eIdxTechnology;
            bool IgnorePasswordValid = true;

            string unit = IhtModbusUnitParam.GetTechnology(u16IdxTechnology);
            double multiplier = IhtModbusRealMultiplierParam.GetTechnology(u16IdxTechnology, IgnorePasswordValid);

            int idx = (int)eIdxTechnology * 3;
            int min = au16TechnologyConst[idx + 0];
            int max = au16TechnologyConst[idx + 1];
            int step = au16TechnologyConst[idx + 2];
            return new IhtCutDataMap(_paramText, 1.0 / multiplier, unit, min, max, step);
        }

        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {
            // Konstante Daten für Min-, Max- und Stepwerte einholen
            IhtModbusParamConst.SetTechnologySimulationData(ref au16TechnologyConst);

            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.PreHeatHeight, GenerateCutDataMap("PreHeatHeight", IhtModbusParamDyn.eIdxTechnology.PreHeatHeight));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.PierceHeight, GenerateCutDataMap("PierceHeight", IhtModbusParamDyn.eIdxTechnology.PierceHeight));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.CutHeight, GenerateCutDataMap("CutHeight", IhtModbusParamDyn.eIdxTechnology.CutHeight));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition, GenerateCutDataMap("PI0;HeatO2 Ignition;bar", IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.HeatO2PreHeat, GenerateCutDataMap("PreHeatHeatingOxygenPressure", IhtModbusParamDyn.eIdxTechnology.HeatO2PreHeat));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.HeatO2Pierce, GenerateCutDataMap("PierceHeatingOxygenPressure", IhtModbusParamDyn.eIdxTechnology.HeatO2Pierce));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.HeatO2Cut, GenerateCutDataMap("CutHeatingOxygenPressure", IhtModbusParamDyn.eIdxTechnology.HeatO2Cut));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.CutO2Pierce, GenerateCutDataMap("PierceCuttingOxygenPressure", IhtModbusParamDyn.eIdxTechnology.CutO2Pierce));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.CutO2Cut, GenerateCutDataMap("CutCuttingOxygenPressure", IhtModbusParamDyn.eIdxTechnology.CutO2Cut));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition, GenerateCutDataMap("PI1;FuelGas Ignition;bar", IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.FuelGasPreHeat, GenerateCutDataMap("PreHeatFuelGasPressure", IhtModbusParamDyn.eIdxTechnology.FuelGasPreHeat));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.FuelGasPierce, GenerateCutDataMap("PierceFuelGasPressure", IhtModbusParamDyn.eIdxTechnology.FuelGasPierce));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.FuelGasCut, GenerateCutDataMap("CutFuelGasPressure", IhtModbusParamDyn.eIdxTechnology.FuelGasCut));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.PreHeatTime, GenerateCutDataMap("PreHeatTime", IhtModbusParamDyn.eIdxTechnology.PreHeatTime));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.PiercePreTime, GenerateCutDataMap("PP1;Pierce Pre Time;s", IhtModbusParamDyn.eIdxTechnology.PiercePreTime));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.PierceTime, GenerateCutDataMap("PierceTime", IhtModbusParamDyn.eIdxTechnology.PierceTime));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.PiercePostTime, GenerateCutDataMap("PP2;Pierce Post Time;s", IhtModbusParamDyn.eIdxTechnology.PiercePostTime));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.PierceHeightRampTime, GenerateCutDataMap("PP3;Pierce Height Ramp Time;s", IhtModbusParamDyn.eIdxTechnology.PierceHeightRampTime));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.CutHeightRampTime, GenerateCutDataMap("PP4;Cut Height Ramp Time;s", IhtModbusParamDyn.eIdxTechnology.CutHeightRampTime));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.PierceMode, GenerateCutDataMap("PP0;Pierce Mode", IhtModbusParamDyn.eIdxTechnology.PierceMode));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.IgnitionFlameAdjust, GenerateCutDataMap("IgnitionFlameAdjustment", IhtModbusParamDyn.eIdxTechnology.IgnitionFlameAdjust));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.GasType, GenerateCutDataMap("Gas", IhtModbusParamDyn.eIdxTechnology.GasType));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.CuttingSpeed, GenerateCutDataMap("CuttingSpeed", IhtModbusParamDyn.eIdxTechnology.CuttingSpeed));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.PierceCuttingSpeedChange, GenerateCutDataMap("PierceCuttingSpeedChange", IhtModbusParamDyn.eIdxTechnology.PierceCuttingSpeedChange));
            addressMap.Add(IhtModbusParamDyn.eIdxTechnology.ControlBits, GenerateCutDataMap("PC0;ControlBits", IhtModbusParamDyn.eIdxTechnology.ControlBits));
        }
        /*
                    case IhtModbusParamDyn.eIdxTechnology.HeatO2Ignition          : return IsPasswordValid ? "HeatO2 Ignition" : "PI0";
                    case IhtModbusParamDyn.eIdxTechnology.FuelGasIgnition         : return IsPasswordValid ? "FuelGas Ignition" : "PI1";
         * 
                    case IhtModbusParamDyn.eIdxTechnology.PiercePreTime           : return IsPasswordValid ? "Pierce Pre Time" : "PP1";
         * 
                    case IhtModbusParamDyn.eIdxTechnology.PiercePostTime          : return IsPasswordValid ? "Pierce Post Time" : "PP2";
                    case IhtModbusParamDyn.eIdxTechnology.PierceHeightRampTime    : return IsPasswordValid ? "Pierce Height Ramp Time" : "PP3";
         * 
                    case IhtModbusParamDyn.eIdxTechnology.CutHeightRampTime       : return IsPasswordValid ? "Cut Height Ramp Time" : "PP4";
                    case IhtModbusParamDyn.eIdxTechnology.PierceMode              : return IsPasswordValid ? (u16PierceMode == 0) ? "Pierce Mode absolute" : "Pierce Mode realtive" : "PP0";
                    case IhtModbusParamDyn.eIdxTechnology.GasType                 : return (u16GasType == 0) ? "Gas Type: Propane" : "Gas Type: Acetylene";

                    case IhtModbusParamDyn.eIdxTechnology.ControlBits             : return IsPasswordValid ? "Control Bits" : "PC0";
        */

    }
}
