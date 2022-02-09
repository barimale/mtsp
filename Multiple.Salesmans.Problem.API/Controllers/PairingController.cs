using Algorithm.MTSP;
using Algorithm.MTSP.Model.Requests;
using Algorithm.MTSP.Model.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MTSP.API.Controllers
{
    [AllowAnonymous]
    [Route("api/engine/[controller]/[action]")]
    [ApiController]
    public class PairingController : ControllerBase
    {
        private readonly ILogger<PairingController> _logger;
        private readonly IEngine _engine;

        private PairingController(
            IEngine engine,
            ILogger<PairingController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _engine = engine;
            engine.Initialize(configuration["BingKey"], configuration["BingRootUrl"]);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OutputDataSummary))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Analyze(
            [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] AlgorithmRequest input,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _engine.CalculateAsync(input);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
