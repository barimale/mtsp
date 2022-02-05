using MTSP.Database.SQLite.Repositories.Abstractions.Scoped;
using System.Threading;
using System.Threading.Tasks;

namespace MTSP.API.Services.Abstractions
{
    public interface IParticipantService : IBaseRepositoryOuterScope<object, string>, IBaseRepositoryInnerScope<object, string>
    {
        Task<dynamic[]> GetAllAsync(string eventId, CancellationToken? cancellationToken = null);
    }
}
