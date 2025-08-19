using System.Security.Claims;
using Beykam.Application.Employers.Commands;
using Beykam.Application.Employers.DTOs;
using Beykam.Application.Employers.Queries;
using Beykam.Domain.Enums;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beykam.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly BeykamDbContext _dbContext;

        public EmployersController(IMediator mediator, BeykamDbContext dbContext)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var employers = await _mediator.Send(new GetAllEmployersQuery(), cancellationToken);
            return Ok(employers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            if (!User.IsInRole(Roles.Admin))
            {
                var currentUserIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (Guid.TryParse(currentUserIdClaim, out var currentUserId))
                {
                    var currentEmployerId = await _dbContext.Employers
                        .Where(e => e.UserId == currentUserId)
                        .Select(e => e.Id)
                        .FirstOrDefaultAsync(cancellationToken);

                    if (currentEmployerId == Guid.Empty || currentEmployerId != id)
                    {
                        return Forbid();
                    }
                }
            }

            var employer = await _mediator.Send(new GetEmployerByIdQuery { Id = id }, cancellationToken);
            if (employer is null) return NotFound();
            return Ok(employer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEmployerDto dto, CancellationToken cancellationToken)
        {
            if (!User.IsInRole(Roles.Admin))
            {
                var currentUserIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (Guid.TryParse(currentUserIdClaim, out var currentUserId))
                {
                    var currentEmployerId = await _dbContext.Employers
                        .Where(e => e.UserId == currentUserId)
                        .Select(e => e.Id)
                        .FirstOrDefaultAsync(cancellationToken);

                    if (currentEmployerId == Guid.Empty || currentEmployerId != id)
                    {
                        return Forbid();
                    }
                }
            }

            await _mediator.Send(new UpdateEmployerCommand
            {
                Id = id,
                Employer = new Beykam.Application.Employers.DTOs.UpdateEmployerDto
                {
                    CompanyName = dto.CompanyName,
                    CompanyDescription = dto.CompanyDescription,
                    Website = dto.Website,
                    LogoUrl = dto.LogoUrl,
                    Phone = dto.Phone
                }
            }, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteEmployerCommand { Id = id }, cancellationToken);
            return NoContent();
        }
        
        [HttpPost("{id}/approve")]
        public async Task<IActionResult> Approve(Guid id)
        {
            var command = new ApproveEmployerCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

