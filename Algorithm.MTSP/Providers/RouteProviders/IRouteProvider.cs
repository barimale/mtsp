using Algorithm.MTSP.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Waypoint = Algorithm.MTSP.Domain.Waypoint;

namespace Algorithm.MTSP.Providers.RouteProviders
{
    public interface IRouteProvider
    {
        public void Initialize(string url, string apiKey);
        public Task<List<Waypoint>> GetRoutes(List<Checkpoint> checkpoints);
    }
}
