using BlazorServerHost.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace BlazorServerHost.Shared
{
	public class IhtComponentBase : ComponentBase, IDisposable
	{
		[Inject]
		public IStringLocalizer<App> T { get; set; }

		[Inject]
		protected UnitService _unitService { get; set; }

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
