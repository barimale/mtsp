using Algorithm.MTSP.Domain;
using MTSP.Database.SQLite.Repositories.Abstractions.Scoped;
using System.Threading;
using System.Threading.Tasks;

namespace MTSP.API.Services.Abstractions
{
    public interface IParticipantService : IBaseRepositoryOuterScope<Participant, string>, IBaseRepositoryInnerScope<Participant, string>
    {
        Task<Participant[]> GetAllAsync(string eventId, CancellationToken? cancellationToken = null);
    }
}
