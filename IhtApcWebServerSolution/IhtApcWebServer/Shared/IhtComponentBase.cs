using IhtApcWebServer;
using IhtApcWebServer.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Hosting.WindowsServices;
using Microsoft.Extensions.Localization;
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


		private static readonly string BaseDirectory = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : @".\";

		private static readonly string defaultResxFile = @$"{BaseDirectory}Cultures\App.en-US.resx";

		private static ResXResourceReader? _rsxr;

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

		/// <summary>
		/// If the local string has not been found returns keyToLocalize 
		/// </summary>
		/// <param name="keyToLocalize"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public string? LocalStrByKey(string keyToLocalize, params object[] args)
		{
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

		public string P(double pressureInBar)
		{
			return (_unitService.IsPressureBar) ? $"{pressureInBar} Bar" : $"{pressureInBar * 14.5037738} psi";
		}

		public string D(double distanceInMetric)
		{
			return (_unitService.IsDistanceMetric) ? $"{distanceInMetric}" : $"{distanceInMetric / 25.4}\"";
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
