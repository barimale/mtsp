using System.Threading.Tasks;

namespace MTSP.API.HostedServices.Hub
{
    public interface ILocalesStatusHub
    {
        Task OnStartAsync(string id);
        Task OnFinishAsync(string id);
    }
}