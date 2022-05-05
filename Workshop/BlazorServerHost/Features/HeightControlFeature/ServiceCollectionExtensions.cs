using BlazorServerHost.Features.HeightControlFeature.Services;

namespace BlazorServerHost.Features.HeightControlFeature
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddHeightControlFeature(this IServiceCollection services)
		{
			services.AddScoped<HeightControlDataProvider>();

			return services;
		}
	}
}
