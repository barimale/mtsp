using Algorithm.MTSP.Domain;
using Algorithm.MTSP.Model.Responses;
using MTSP.Database.SQLite.Repositories.Abstractions.Scoped;
using System.Threading;
using System.Threading.Tasks;

namespace MTSP.API.Services.Abstractions
{
    public interface IEventService : IBaseRepositoryOuterScope<GiftEvent, string>
    {
        Task<AlgorithmResponse> ExecuteAsync(GiftEvent giftEvent, CancellationToken cancellationToken = default);
    }
}
