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

		private static ResXResourceReader? rsxr;


		public string? LocalStr(string strToLocalize)
		{
			var strLocalized = T[strToLocalize];

			var returnStr = strLocalized.ToString();
			
			if (strLocalized.ResourceNotFound)
            {
				try
				{
					if (rsxr == null)
					{
						rsxr = new ResXResourceReader(defaultResxFile);
					}

					returnStr = rsxr.Cast<DictionaryEntry>()
						.FirstOrDefault( x => x.Key.Equals(strToLocalize) && x.Value != null)
						.Value?.ToString();
				}
				catch (Exception ex)
                {
					_logger.LogError(ex, ex.Message);
                }
			}
            
			return returnStr;
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
			rsxr?.Close();
		}
	}
}
