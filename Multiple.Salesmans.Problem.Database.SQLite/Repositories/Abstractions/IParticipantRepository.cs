using MTSP.Database.SQLite.Entries;

namespace MTSP.Database.SQLite.Repositories.Abstractions
{
    public interface IParticipantRepository : IBaseRepository<ParticipantEntry, string>
    {
        Task<ParticipantEntry[]> GetAllAsync(string eventId, CancellationToken? cancellationToken = null);
    }
}