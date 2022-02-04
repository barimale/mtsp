using AutoMapper;
using MTSP.Database.SQLite.Entries;
using MTSP.Domain;

namespace MTSP.Database.SQLite.Extensions
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<GiftEvent, EventEntry>()
                .ReverseMap();

            CreateMap<Participant, ParticipantEntry>()
                .ReverseMap();

            CreateMap<EventEntry, EventEntry>();
            CreateMap<ParticipantEntry, ParticipantEntry>();
        }
    }
}
