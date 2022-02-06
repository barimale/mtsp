using Microsoft.Extensions.DependencyInjection;

namespace Algorithm.MTSP.UT
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMTSP();
        }
    }
}
