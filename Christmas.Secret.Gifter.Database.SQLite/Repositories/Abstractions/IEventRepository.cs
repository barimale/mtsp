using MTSP.Database.SQLite.Entries;

namespace MTSP.Database.SQLite.Repositories.Abstractions
{
    public interface IEventRepository : IBaseRepository<EventEntry, string>
    {
        //intentionally left blank
    }
}