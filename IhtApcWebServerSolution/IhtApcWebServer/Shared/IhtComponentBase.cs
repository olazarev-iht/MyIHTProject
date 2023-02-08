using IhtApcWebServer;
using IhtApcWebServer.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Hosting.WindowsServices;
using Microsoft.Extensions.Localization;
using SharedComponents.Helpers;
using SharedComponents.IhtDev;
using SharedComponents.Models.APCHardware;
using System.Reflection;
using System.Resources.NetStandard;
using System.Globalization;
using System.Collections;
using SharedComponents.Services.APCCommunicServices;

namespace IhtApcWebServer.Shared
{
	public class IhtComponentBase : ComponentBase, IDisposable
	{
		[Inject]
		public IStringLocalizer<App> T { get; set; }

		[Inject]
		protected UnitService _unitService { get; set; }

		[Inject]
		protected ILogger<IhtComponentBase> _logger { get; set; }

		[Inject]
		protected IHttpContextAccessor _httpContextAccessor { get; set; }

		protected static string? Cookie { get; set; }

		private static readonly string BaseDirectory = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : @".\";

		private static readonly string defaultResxFile = @$"{BaseDirectory}Cultures\App.en-US.resx";

		private static ResXResourceReader? _rsxr;

		//public IhtComponentBase()
		//      {
		//	Cookie = _httpContextAccessor?.HttpContext?.Request?.Cookies[CookieRequestCultureProvider.DefaultCookieName];
		//}

		public static ResXResourceReader? Rsxr
		{
			get
			{
				if (_rsxr == null)
				{
					_rsxr = new ResXResourceReader(defaultResxFile);
				}

				return _rsxr;
			}
			set
			{
				_rsxr = value;
			}
		}


		public CultureInfo CurrentCulture { get; set; }
		public CultureInfo CurrentUICulture { get; set; }

		/// <summary>
		/// If the local string has not been found returns keyToLocalize 
		/// </summary>
		/// <param name="keyToLocalize"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public string? LocalStrByKey(string keyToLocalize, params object[] args)
		{
			string? cookie = string.Empty;

			try
			{

				cookie = _httpContextAccessor?.HttpContext?.Request?.Cookies[CookieRequestCultureProvider.DefaultCookieName];

				if (!string.IsNullOrWhiteSpace(cookie))
				{
					Cookie = cookie;
					CurrentCulture = System.Globalization.CultureInfo.CurrentCulture;
					CurrentUICulture = System.Globalization.CultureInfo.CurrentUICulture;
				}

				if (string.IsNullOrWhiteSpace(cookie) && !string.IsNullOrWhiteSpace(Cookie))
				{
					//var cultureStr = Cookie.Split("|")[0].Split("=")[1];
					//var cultureUIStr = Cookie.Split("|")[1].Split("=")[1];
					System.Globalization.CultureInfo.CurrentCulture = CurrentCulture;
					System.Globalization.CultureInfo.CurrentUICulture = CurrentUICulture;
				}
			}
			catch (Exception ex)
			{
				var message = ex.Message;
			}

			var strLocalized = T[keyToLocalize, args];

			var returnStr = strLocalized.ToString();

			if (strLocalized.ResourceNotFound)
			{
				try
				{
					if (Rsxr != null)
					{
						returnStr = Rsxr.Cast<DictionaryEntry>()
							.FirstOrDefault(x => x.Key.Equals(keyToLocalize) && x.Value != null)
							.Value?.ToString();

						if (string.IsNullOrWhiteSpace(returnStr))
							returnStr = keyToLocalize;
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, ex.Message);
				}
			}

			return returnStr;
		}

		/// <summary>
		/// Returns key if translation not exists or english text if the key not exists
		/// </summary>
		/// <param name="strToLocalize"></param>
		/// <returns></returns>
		public string? LocalStrByEnStr(string strToLocalize)
		{
			string? localStr;

			var localKey = GetKeyByEnStr(strToLocalize);

			// If the key exists in the en resource file we try to get local string
			if (!string.IsNullOrWhiteSpace(localKey))
			{
				localStr = LocalStrByKey(localKey);
			}
			else
			{
				localStr = strToLocalize;
			}

			return localStr;
		}

		/// <summary>
		/// If the key has not been found returns null or string.Empty
		/// </summary>
		/// <param name="stringToLocalize"></param>
		/// <returns></returns>
		public string? GetKeyByEnStr(string stringToLocalize)
		{
			var returnKey = string.Empty;

			if (Rsxr != null)
			{
				returnKey = Rsxr.Cast<DictionaryEntry>()
					.FirstOrDefault(x => x.Value != null && x.Value.Equals(stringToLocalize))
					.Key?.ToString();
			}

			return returnKey;
		}

		public string DisplayParamValue(ParameterDataModel parameterDataModel, string parameterFormat = "")
		{
			var returnStr = string.Empty;

			var displayParamValueAndUnit = DisplayParamValueAndUnit(parameterDataModel, parameterFormat);

			if (!string.IsNullOrWhiteSpace(displayParamValueAndUnit))
			{
				var arrValueAndUnit = displayParamValueAndUnit.Split(" ");

				if (arrValueAndUnit.Length > 0)
				{
					returnStr = arrValueAndUnit[0];
				}
			}

			return returnStr;
		}

		public string DisplayParamUnit(ParameterDataModel parameterDataModel, string parameterFormat = "")
		{
			var returnStr = string.Empty;

			var displayParamValueAndUnit = DisplayParamValueAndUnit(parameterDataModel, parameterFormat);

			if (!string.IsNullOrWhiteSpace(displayParamValueAndUnit))
			{
				var arrValueAndUnit = displayParamValueAndUnit.Split(" ");

				if (arrValueAndUnit.Length > 1)
				{
					returnStr = arrValueAndUnit[1];
				}
			}

			return returnStr;
		}

		public int CorrectTheCurrentValue(ParameterDataModel parameterDataModel, int currentValue)
        {
			var curStep = GetValueForPressure(parameterDataModel, "Step");
			var minValue = GetValueForPressure(parameterDataModel, "Min");
			var maxValue = GetValueForPressure(parameterDataModel, "Max");

			var index = ((double)currentValue) / curStep;

			var roundedIndex = (int)Math.Round(index, MidpointRounding.AwayFromZero);

			var newValue = curStep * roundedIndex;

			if(newValue < minValue)
            {
				newValue = minValue;
            }

			if(newValue > maxValue)
            {
				newValue = maxValue;
            }

			return newValue;
        }

		public string DisplayParamValueAndUnit(ParameterDataModel parameterDataModel, string parameterFormat = "")
		{
			if (parameterDataModel == null)
				throw new ArgumentNullException($"{nameof(parameterDataModel)} param is null");

			CheckAndUpdateValueIfNotValid(parameterDataModel);

			var returnStr = string.Empty;
			var defaultFormat = !string.IsNullOrWhiteSpace(parameterFormat) ? parameterFormat : "{0}";

			var paramUnit = parameterDataModel?.DynParams?.ParameterDataInfo?.Unit;
			var paramValue = parameterDataModel?.DynParams?.Value;
			var paramMultiplier = parameterDataModel?.DynParams?.ParameterDataInfo?.Multiplier ?? 0;
			var paramMaxValue = (double)(parameterDataModel?.DynParams?.ConstParams?.Max ?? 0);
			var paramStepValue = (double)(parameterDataModel?.DynParams?.ConstParams?.Step ?? 0);

			double displayValue;


			if (paramValue != null)
			{
				var correctedParamValue = (paramMaxValue > 0 && paramStepValue > 0) ? CorrectTheCurrentValue(parameterDataModel, (int)paramValue) : paramValue;

				if (paramUnit == Units.txtBar || paramUnit == Units.txtPsi)
				{
					if (paramMultiplier == 0) paramMultiplier = 0.001;

					displayValue = GetValueToDisplay(correctedParamValue, paramMultiplier);

					returnStr = GetFormatedPressureValue(displayValue, paramMaxValue, parameterFormat);
				}
				else if (paramUnit == Units.txtMm || paramUnit == Units.txtInch || paramUnit == Units.txtInch_min)
				{
					if (paramMultiplier == 0) paramMultiplier = 0.1;

					displayValue = GetValueToDisplay(correctedParamValue, paramMultiplier);

					returnStr = GetFormatedLengthValue(displayValue, parameterFormat, parameterDataModel);
				}
				else
				{
					if (paramMultiplier == 0) paramMultiplier = 1;

					displayValue = GetValueToDisplay(paramValue, paramMultiplier);

					returnStr = $"{string.Format(defaultFormat, displayValue)} {paramUnit}";
				}
			}

			return returnStr;
		}

		public void CheckAndUpdateValueIfNotValid(ParameterDataModel parameterDataModel)
		{
			if (parameterDataModel == null) return;

			var paramValue = parameterDataModel?.DynParams?.Value;
			var paramMaxValue = parameterDataModel?.DynParams?.ConstParams?.Max ?? 0;
			var paramMinValue = parameterDataModel?.DynParams?.ConstParams?.Min ?? 0;


			if (parameterDataModel != null && parameterDataModel.DynParams != null && parameterDataModel.DynParams.ConstParams != null && paramMaxValue > 0)
			{
				if (paramValue < paramMinValue)
				{
					parameterDataModel.DynParams.Value = paramMinValue;
					UpdateDynParam(parameterDataModel);
				}
				else if (paramValue > paramMaxValue)
				{
					parameterDataModel.DynParams.Value = paramMaxValue;
					UpdateDynParam(parameterDataModel);
				}
			}
		}

        private int GetParamConstPropForPsi(int paramMinValue, int paramMaxValue, double paramMultiplier, string propertyName)
        {
			int returnValue;

			if (paramMultiplier == 0) paramMultiplier = 0.001;

            double minBarValue = GetValueToDisplay(paramMinValue, paramMultiplier);
            double minPsiValue = minBarValue * Units.psiMultiplier;
            double minPsiValueRounded = Math.Ceiling(minPsiValue);

            double maxBarValue = GetValueToDisplay(paramMaxValue, paramMultiplier);
            double maxPsiValue = maxBarValue * Units.psiMultiplier;
            double maxPsiValueRounded = Math.Floor(maxPsiValue);

            /* real values of step and param 
			//double paramBarValue = GetValueToDisplay(paramValue, paramMultiplier);
			//double paramPsiValue = paramBarValue * Units.psiMultiplier;

			//double stepValue = GetValueToDisplay(paramStepValue, paramMultiplier);
			//double stepPsiValue = stepValue * Units.psiMultiplier;
			*/

            // we can calculate stepPsiValue
            //var stepIndex = (paramMaxValue - paramMinValue) / paramStepValue;
            //double stepPsiValue = (maxPsiValueRounded - minPsiValueRounded) / stepIndex;
            //double stepPsiValueRounded = Math.Floor(stepPsiValue);
            // but now we take 1
            double stepPsiValueRounded = 1;

			var psiToIntMultiplier = Units.psiToBarMultiplier / paramMultiplier;

			if (propertyName.ToLower() == "min")
            {
                double newMinBarValue = minPsiValueRounded * psiToIntMultiplier;
                returnValue = (int)Math.Floor(newMinBarValue);
            }
            else if (propertyName.ToLower() == "max")
            {
                double newMaxBarValue = maxPsiValueRounded * psiToIntMultiplier;
                returnValue = (int)Math.Floor(newMaxBarValue);
            }
            else if (propertyName.ToLower() == "step")
            {
                double newBarStepValue = stepPsiValueRounded * psiToIntMultiplier;
                returnValue = (int)Math.Ceiling(newBarStepValue);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(propertyName));
            }

			return returnValue;
        }

		private int GetParamConstPropForInch(int paramMinIntValue, int paramMaxIntValue, int paramStepIntValue, double paramMultiplier, string propertyName)
		{
			int returnValue;

			if (paramMultiplier == 0) paramMultiplier = 0.1;

			double minMmValue = GetValueToDisplay(paramMinIntValue, paramMultiplier);
			double minInchValue = minMmValue * Units.inchMultiplier;
			double minInchValueRounded = Math.Ceiling(minInchValue);

			double maxMmValue = GetValueToDisplay(paramMaxIntValue, paramMultiplier);
			double maxInchValue = maxMmValue * Units.inchMultiplier;
			double maxInchValueRounded = Math.Round(maxInchValue, 3, MidpointRounding.ToZero);

			double stepInchValueRounded = paramStepIntValue >= 25 ? 1.0 : 0.03937;

			var inchToIntMultiplier = Units.inchToMmMultiplier / paramMultiplier;

			if (propertyName.ToLower() == "min")
			{
				double newMinMmValue = minInchValueRounded * inchToIntMultiplier;
				returnValue = (int)Math.Floor(newMinMmValue);
			}
			else if (propertyName.ToLower() == "max")
			{
				double newMaxMmValue = maxInchValueRounded * inchToIntMultiplier;
				returnValue = (int)Math.Floor(newMaxMmValue);
			}
			else if (propertyName.ToLower() == "step")
			{
				double newMmStepValue = stepInchValueRounded * inchToIntMultiplier;
				//returnValue = (int)Math.Round(newMmStepValue, MidpointRounding.AwayFromZero);
				returnValue = (int)Math.Round(newMmStepValue, MidpointRounding.AwayFromZero);
			}
			else
			{
				throw new ArgumentOutOfRangeException(nameof(propertyName));
			}

			return returnValue;
		}

		public int GetValueForPressure(ParameterDataModel parameterDataModel, string propertyName)
		{
			var paramUnit = parameterDataModel?.DynParams?.ParameterDataInfo?.Unit;
			var paramMultiplier = parameterDataModel?.DynParams?.ParameterDataInfo?.Multiplier ?? 0;
			var paramMinValue = parameterDataModel?.DynParams?.ConstParams?.Min ?? 0;
			var paramMaxValue = parameterDataModel?.DynParams?.ConstParams?.Max ?? 0;
			var paramStepValue = parameterDataModel?.DynParams?.ConstParams?.Step ?? 0;
			var paramValue = parameterDataModel?.DynParams?.Value;

			int returnValue;

			if (propertyName.ToLower() == "min")
			{				
				returnValue = paramMinValue;
			}
			else if (propertyName.ToLower() == "max")
			{
				returnValue = paramMaxValue;
			}
			else if (propertyName.ToLower() == "step")
			{
				returnValue = paramStepValue;
			}
			else
			{
				throw new ArgumentOutOfRangeException(nameof(propertyName));
			}

			if (paramUnit == Units.txtBar || paramUnit == Units.txtPsi)
			{
				if (UnitService.PressureUnit == IhtDevices.PressureUnit.IsPressurePsi) //for psi only
				{
					returnValue = GetParamConstPropForPsi(paramMinValue, paramMaxValue, paramMultiplier, propertyName);
				}
			}
			else if (paramUnit == Units.txtMm || paramUnit == Units.txtInch)
			{
				if (UnitService.LengthUnit == IhtDevices.LengthUnit.IsUnitInch || UnitService.LengthUnit == IhtDevices.LengthUnit.IsUnitInchFractional) //for inch
				{
					returnValue = GetParamConstPropForInch(paramMinValue, paramMaxValue, paramStepValue, paramMultiplier, propertyName);
				}
			}

			return returnValue;
		}
		

		private double GetValueToDisplay(int? value, double multiplier)
        {
			return (value ?? 0) * multiplier;
		}

		public string GetFormatedPressureValue(double pressureValue, double maxValue = 0, string parameterFormat = "")
		{
			string? returnStr;

			if (UnitService.PressureUnit == IhtDevices.PressureUnit.IsPressurePsi) //for psi
            {
				double pressurePsiValue = pressureValue * Units.psiMultiplier;
				returnStr = $"{Units.GetFormattedPressurePsi(pressurePsiValue, maxValue, parameterFormat:parameterFormat)} {Units.txtPsi}";
			}
            else // for bar
            {
				returnStr = $"{Units.GetFormattedPressureBar(pressureValue, maxValue, parameterFormat: parameterFormat)} {Units.txtBar}";
			}

			return returnStr;
		}

		public string GetFormatedLengthValue(double lengthValue, string parameterFormat = "", ParameterDataModel? parameterDataModel = null)
		{
			string? returnStr;

			var strFormat = !string.IsNullOrWhiteSpace(parameterFormat) ? parameterFormat : "{0,1:0.0}";

			double lengthInchValue = lengthValue * Units.inchMultiplier;
			
			if (UnitService.LengthUnit == IhtDevices.LengthUnit.IsUnitInch)
			{
				string formatedInchValue = Units.GetFormattedUnitInch(lengthInchValue, true, parameterDataModel?.ParamName ?? "");
				returnStr = $"{formatedInchValue} {Units.txtInch}";
			}
			else if (UnitService.LengthUnit == IhtDevices.LengthUnit.IsUnitInchFractional)
			{
				returnStr = $"{Units.mmToinchFractions[(int)lengthValue]} {Units.txtInch}";
			}
			else
			{
				returnStr = $"{string.Format(strFormat, lengthValue)} {Units.txtMm}";
			}

			return returnStr;
		}

		protected override async Task OnInitializedAsync()
		{
			await _unitService.EnsureInitializedAsync();
			await base.OnInitializedAsync();
		}

		public virtual void Dispose()
		{
			Rsxr?.Close();
		}

		public virtual void UpdateDynParam(ParameterDataModel parameterData)
        {
            throw new NotImplementedException();
        }
    }
}
