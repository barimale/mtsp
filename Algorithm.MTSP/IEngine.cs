using Algorithm.MTSP.Model.Requests;
using Algorithm.MTSP.Model.Responses;
using System.Threading.Tasks;

namespace Algorithm.MTSP
{
    // WIP:START WITH THIS ONE AS IT IS THE FULL SOLUTION:  add possibility to take under consideration time for delivery per type of building -> each location has its own time constant - dynamic?: https://developers.google.com/optimization/routing/cvrptw_resources#create-the-data
    // WIP: add time window as the distance matrix is actually the Time Matrix: https://developers.google.com/optimization/routing/vrptw#time_window_constraints
    // WIP add capacity as the postperson's bag size is limited: https://developers.google.com/optimization/routing/cvrp#demand
    // WIP: algorithm settings: https://developers.google.com/optimization/routing/routing_tasks
    public interface IEngine
    {
        Task<OutputDataSummary> CalculateAsync(InputData input);
        void Initialize(string matrixDistanceProviderUrl, string matrixDistanceProviderApiKey);
    }
}