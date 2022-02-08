using Algorithm.MTSP.Domain;
using BingMapsRESTToolkit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Algorithm.MTSP.DistanceMatrixProviders
{
    public interface IRouteProvider
    {
        public void Initialize(string url, string apiKey);
        public Task<List<Waypoint>> GetRoutes(List<Checkpoint> checkpoints);
    }
}
