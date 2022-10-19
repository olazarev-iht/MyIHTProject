using IhtApcWebServer.Features.HeightControlFeature.Services;
using IhtApcWebServer.Features.HeightControlFeature.Services.CNC;

namespace IhtApcWebServer.Features.HeightControlFeature
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddHeightControlFeature(this IServiceCollection services)
		{
			services.AddScoped<HeightControlDataProvider>();

			return services;
		}

		public static IServiceCollection AddLiveAPCParamsDataFeature(this IServiceCollection services)
		{
			services.AddScoped<LiveAPCParamsDataProvider>();

			return services;
		}

		public static IServiceCollection AddDynamicAPCParamsDataFeature(this IServiceCollection services)
		{
			services.AddScoped<DynamicAPCParamsDataProvider>();

			return services;
		}

		public static IServiceCollection AddDynDataModificationCNCDisplayFeature(this IServiceCollection services)
		{
			services.AddScoped<DynDataModificationCNCDataProvider>();

			return services;
		}
	}
}
