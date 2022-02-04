using System.Threading.Tasks;

namespace MTSP.API.Services.Abstractions
{
    public interface IImageExtractor
    {
        Task SaveLocallyAsync();
    }
}