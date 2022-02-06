using Algorithm.MTSP.DistanceMatrixProviders;
using DotNet.RestApi.Client;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Algorithm.MTSP
{
    public static class RegisterServices
    {
        public static void AddMTSP(this IServiceCollection services, int retryAttempts = 3)
        {
            services.AddScoped<IEngine, Engine>();
            services.AddScoped<IMatrixDistanceProvider, BingMapProvider>();
            services.AddTransient<RestApiClient>();
            services.AddHttpClient<RestApiClient>().AddTransientHttpErrorPolicy(p => p.RetryAsync(retryAttempts));
        }
    }
}
