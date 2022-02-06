using Algorithm.MTSP.Model.Requests;
using Algorithm.MTSP.Model.Responses;
using System.Threading.Tasks;

namespace Algorithm.MTSP
{
    public interface IEngine
    {
        Task<OutputDataSummary> CalculateAsync(InputData input);
        void Initialize(string matrixDistanceProviderUrl, string matrixDistanceProviderApiKey);
    }
}