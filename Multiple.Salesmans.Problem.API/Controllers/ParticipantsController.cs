﻿using Algorithm.MTSP.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using MTSP.API.Services.Abstractions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MTSP.API.Controllers
{
    [AllowAnonymous]
    [Route("api")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantService _participantService;
        private readonly IEventService _eventService;
        private readonly ILogger<ParticipantsController> _logger;

        public ParticipantsController(
            ILogger<ParticipantsController> logger,
            IParticipantService participantService,
            IEventService eventService)
        {
            _logger = logger;
            _participantService = participantService;
            _eventService = eventService;
        }

        [HttpPost("events/{eventId}/[controller]/register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Participant))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Register(
            string eventId,
            [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] Participant input,
            CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var existedEvent = await _eventService.GetByIdAsync(eventId, cancellationToken);

                if (existedEvent == null)
                {
                    return NotFound("Event with such id not registered.");
                }

                var created = await _participantService.AddAsync(input, cancellationToken);

                return Ok(created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("events/{eventId}/[controller]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Participant))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update(
            string eventId,
            string id,
            [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] Participant input,
            CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var existedEvent = await _eventService.GetByIdAsync(eventId, cancellationToken);

                if (existedEvent == null)
                {
                    return NotFound("Event with such id not registered.");
                }

                var existed = await _participantService.GetByIdAsync(id, cancellationToken);

                if (existed == null)
                {
                    return NotFound("Participant with such id not created.");
                }

                var updated = await _participantService.UpdateAsync(input, cancellationToken);

                return Ok(updated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("events/{eventId}/[controller]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Remove(
           string eventId,
           string id,
           CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var existedEvent = await _eventService.GetByIdAsync(eventId, cancellationToken);

                if (existedEvent == null)
                {
                    return NotFound("Event with such id not registered.");
                }

                var deleted = await _participantService.DeleteAsync(id, cancellationToken);

                return Ok(deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("events/{eventId}/[controller]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Participant))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetById(
            string eventId,
            string id,
            CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var existedEvent = await _eventService.GetByIdAsync(eventId, cancellationToken);

                if (existedEvent == null)
                {
                    return NotFound("Event with such id not registered.");
                }

                var existed = await _participantService.GetByIdAsync(id, cancellationToken);

                if (existed == null)
                {
                    return NotFound();
                }

                return Ok(existed);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("events/{eventId}/[controller]/all")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Participant[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAll(
            string eventId,
            CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                var existedEvent = await _eventService.GetByIdAsync(eventId, cancellationToken);

                if (existedEvent == null)
                {
                    return NotFound("Event with such id not registered.");
                }

                return Ok(existedEvent.Participants.ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
