using Beykam.Application.Candidates.Commands;
using Beykam.Application.Candidates.DTOs;
using Beykam.Application.Candidates.Queries;
using Beykam.Domain.Enums;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Beykam.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CandidatesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly BeykamDbContext _dbContext;

        public CandidatesController(IMediator mediator, BeykamDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            // Admins can view any candidate. Candidates can view only their own profile.
            if (!User.IsInRole(Roles.Admin))
            {
                var currentUserIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (Guid.TryParse(currentUserIdClaim, out var currentUserId))
                {
                    var currentCandidateId = await _dbContext.Candidates
                        .Where(c => c.UserId == currentUserId)
                        .Select(c => c.Id)
                        .FirstOrDefaultAsync(cancellationToken);

                    if (currentCandidateId == Guid.Empty || currentCandidateId != id)
                    {
                        return Forbid();
                    }
                }
            }
            var candidate = await _mediator.Send(new GetCandidateByIdQuery { Id = id }, cancellationToken);
            if (candidate is null) return NotFound();
            return Ok(candidate);
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var candidates = await _mediator.Send(new GetAllCandidatesQuery(), cancellationToken);
            return Ok(candidates);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreateCandidateDto dto, CancellationToken cancellationToken)
        {
            // Admins can update any candidate. Candidates can update only their own profile.
            if (!User.IsInRole(Roles.Admin))
            {
                var currentUserIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (Guid.TryParse(currentUserIdClaim, out var currentUserId))
                {
                    var currentCandidateId = await _dbContext.Candidates
                        .Where(c => c.UserId == currentUserId)
                        .Select(c => c.Id)
                        .FirstOrDefaultAsync(cancellationToken);

                    if (currentCandidateId == Guid.Empty || currentCandidateId != id)
                    {
                        return Forbid();
                    }
                }
            }
            await _mediator.Send(new UpdateCandidateCommand { Id = id, Candidate = dto }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteCandidateCommand { Id = id }, cancellationToken);
            return NoContent();
        }
    }
}


