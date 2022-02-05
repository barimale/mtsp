using Algorithm.MTSP.Model.Responses;
using MTSP.Database.SQLite.Repositories.Abstractions.Scoped;
using System.Threading;
using System.Threading.Tasks;

namespace MTSP.API.Services.Abstractions
{
    public interface IEventService : IBaseRepositoryOuterScope<object, string>
    {
        Task<AlgorithmResponse> ExecuteAsync(dynamic giftEvent, CancellationToken cancellationToken = default);
    }
}
