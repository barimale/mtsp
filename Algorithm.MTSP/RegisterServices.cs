using Algorithm.MTSP.DistanceMatrixProviders;
using DotNet.RestApi.Client;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System.Diagnostics.CodeAnalysis;

namespace Algorithm.MTSP
{
    public static class RegisterServices
    {
        public static void AddMTSPWithDefaultProviders(this IServiceCollection services, int retryAttempts = 3)
        {
            services.AddScoped<IEngine, Engine>();
            services.AddScoped<IMatrixDistanceProvider, BingMapProvider>();
            services.AddScoped<IRouteProvider, BingMapRouteProvider>();
            services.AddTransient<RestApiClient>();
            services.AddHttpClient<RestApiClient>().AddTransientHttpErrorPolicy(p => p.RetryAsync(retryAttempts));
        }

        public static void AddMTSP(this IServiceCollection services, int retryAttempts = 3)
        {
            services.AddScoped<IEngine, Engine>();
            services.AddTransient<RestApiClient>();
            services.AddHttpClient<RestApiClient>().AddTransientHttpErrorPolicy(p => p.RetryAsync(retryAttempts));
        }

        public static void AddMatrixDistanceProvider<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
            this IServiceCollection services)
            where TImplementation : class, IMatrixDistanceProvider
        {
            services.AddScoped<IMatrixDistanceProvider, TImplementation>();
        }

        public static void AddRouteProvider<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(
            this IServiceCollection services)
            where TImplementation : class, IRouteProvider
        {
            services.AddScoped<IRouteProvider, TImplementation>();
        }
    }
}
