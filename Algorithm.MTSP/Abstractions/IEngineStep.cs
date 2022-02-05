using Algorithm.MTSP.Model.Requests;
using System.Threading.Tasks;

namespace Algorithm.MTSP.Abstractions
{
    public interface IEngineStep
    {
        Task Initialize(InputData input);
    }
}