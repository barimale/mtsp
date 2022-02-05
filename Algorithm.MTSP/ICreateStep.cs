using Algorithm.MTSP.Model.Requests;
using System.Threading.Tasks;

namespace Algorithm.MTSP
{
    public interface ICreateStep
    {
        Task Initialize(InputData input);
    }
}