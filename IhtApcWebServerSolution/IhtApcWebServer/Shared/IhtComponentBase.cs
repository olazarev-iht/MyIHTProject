using IhtApcWebServer;
using IhtApcWebServer.Services;
using Microsoft.AspNetCore.Components;
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

		public string LocalStr(string strToLocalize)
		{
			var returnStr = string.Empty;

			var strLocalized = T[strToLocalize];

            const string defaultResxFile = @".\Cultures\App.en-US.resx";

			if (strLocalized.ResourceNotFound)
            {
				var rsxr = new ResXResourceReader(defaultResxFile);

				foreach (DictionaryEntry d in rsxr)
                {
					if (d.Key.Equals(strToLocalize)) 
					{
						returnStr = (string)(d.Value ?? string.Empty);
						break;
					}
                }
			}
            else
            {
				returnStr = strLocalized;
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
		}
	}
}
