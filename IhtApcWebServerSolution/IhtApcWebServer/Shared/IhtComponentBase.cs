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

			if(!string.IsNullOrWhiteSpace(displayParamValueAndUnit))
            {
				var arrValueAndUnit = displayParamValueAndUnit.Split(" ");

				if(arrValueAndUnit.Length > 0)
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

		public string DisplayParamValueAndUnit(ParameterDataModel parameterDataModel, string parameterFormat = "")
        {
			var returnStr = string.Empty;
			//double resultValue = 0d;

			var paramUnit = parameterDataModel?.DynParams?.ParameterDataInfo?.Unit;
			var paramValue = parameterDataModel?.DynParams?.Value;
			var paramMultiplier = parameterDataModel?.DynParams?.ParameterDataInfo?.Multiplier ?? 0;
			var paramMaxValue = (double)(parameterDataModel?.DynParams?.ConstParams?.Max ?? 0);

			double displayValue;

			//if (paramMultiplier == 0d) paramMultiplier = 1d;

			//var displayValue = (paramValue ?? 0) * paramMultiplier;


			if (!string.IsNullOrWhiteSpace(paramUnit) && paramValue != null)
            {
				if(paramUnit == Units.txtBar || paramUnit == Units.txtPsi)
                {
					if (paramMultiplier == 0) paramMultiplier = 0.001;

					displayValue = GetValueToDisplay(paramValue, paramMultiplier);

					returnStr = GetFormatedPressureValue(displayValue, paramMaxValue, parameterFormat);
				}
				else if(paramUnit == Units.txtMm || paramUnit == Units.txtInch || paramUnit == Units.txtInch_min)
                {
					if (paramMultiplier == 0) paramMultiplier = 0.1;

					displayValue = GetValueToDisplay(paramValue, paramMultiplier);

					returnStr = GetFormatedLengthValue(displayValue, parameterFormat);
				}
                else
                {
					if (paramMultiplier == 0) paramMultiplier = 1;

					displayValue = GetValueToDisplay(paramValue, paramMultiplier);

					returnStr = $"{string.Format(parameterFormat, displayValue)} {paramUnit}";
				}
            }

			return returnStr;
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

		public string GetFormatedLengthValue(double lengthValue, string parameterFormat = "")
		{
			string? returnStr;

			var strFormat = !string.IsNullOrWhiteSpace(parameterFormat) ? parameterFormat : "{0,1:0.0}";

			double lengthInchValue = lengthValue * Units.inchMultiplier;
			
			if (UnitService.LengthUnit == IhtDevices.LengthUnit.IsUnitInch)
			{
				string formatedInchValue = Units.GetFormattedUnitInch(lengthInchValue);
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
	}
}
