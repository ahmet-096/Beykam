using Beykam.Application.Candidates.Commands;
using Beykam.Application.Candidates.DTOs;
using Beykam.Application.Candidates.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Beykam.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCandidateDto dto, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateCandidateCommand { Candidate = dto }, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var candidate = await _mediator.Send(new GetCandidateByIdQuery { Id = id }, cancellationToken);
            if (candidate is null) return NotFound();
            return Ok(candidate);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var candidates = await _mediator.Send(new GetAllCandidatesQuery(), cancellationToken);
            return Ok(candidates);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreateCandidateDto dto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateCandidateCommand { Id = id, Candidate = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteCandidateCommand { Id = id }, cancellationToken);
            return NoContent();
        }
    }
}


