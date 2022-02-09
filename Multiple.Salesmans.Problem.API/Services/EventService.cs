using Algorithm.MTSP;
using Algorithm.MTSP.Domain;
using Algorithm.MTSP.Model.Requests;
using Algorithm.MTSP.Model.Responses;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MTSP.API.Services.Abstractions;
using MTSP.Database.SQLite.Entries;
using MTSP.Database.SQLite.Repositories.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace MTSP.API.Services
{
    public class EventService : IEventService
    {
        private readonly ILogger<EventService> _logger;
        private readonly IEngine _engine;
        private readonly IEventRepository _eventRepoistory;
        private readonly IMapper _mapper;

        public EventService(
            ILogger<EventService> logger,
            IEventRepository eventRepoistory,
            IMapper mapper,
            IEngine engine,
            IConfiguration configuration)
        {
            _logger = logger;
            _eventRepoistory = eventRepoistory;
            _mapper = mapper;
            _engine = engine;

            _engine.Initialize(
              configuration["BingMapsUrl"],
              configuration["BingMapsKey"]);
        }

        public async Task<GiftEvent> AddAsync(GiftEvent item, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<EventEntry>(item);
            var added = await _eventRepoistory.AddAsync(mapped, cancellationToken);

            return _mapper.Map<dynamic>(added);
        }

        public async Task<GiftEvent> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var found = await _eventRepoistory.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<GiftEvent>(found);
        }

        public async Task<AlgorithmResponse> ExecuteAsync(GiftEvent existed, CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _engine.CalculateAsync(new InputData());

                return new AlgorithmResponse()
                {
                    IsError = result.IsError,
                    Reason = result.Reason,
                    AnalysisStatus = result.Data.Status.ToString()
                };
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }
    }
}
