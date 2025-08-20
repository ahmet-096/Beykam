using Beykam.Application.JobApplications.Commands;
using Beykam.Application.JobApplications.DTOs;
using Beykam.Application.JobApplications.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Beykam.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobApplicationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin,Employer")]
        [HttpGet]
        public async Task<ActionResult<List<JobApplicationDTO>>> Get([FromQuery] Guid? jobPostId)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (userIdClaim == null)
                return Unauthorized();

            var userId = Guid.Parse(userIdClaim);

            var query = new GetJobApplicationsListQuery
            {
                JobPostId = jobPostId
            };

            if (User.IsInRole("Employer"))
                query.EmployerId = userId;
            else if (User.IsInRole("Candidate"))
                query.CandidateId = userId;
            else
                return Forbid();

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobApplicationDTO>> GetById(Guid id)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (userIdClaim == null)
                return Unauthorized();

            var userId = Guid.Parse(userIdClaim);

            var query = new GetJobApplicationByIdQuery { Id = id, RequestingUserId = userId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Candidate")]
        [HttpPost]
        public async Task<ActionResult<JobApplicationDTO>> Create([FromBody] CreateJobApplicationCommand command)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            if (userIdClaim == null)
                return Unauthorized();

            command.CandidateId = Guid.Parse(userIdClaim);

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [Authorize(Roles = "Admin,Employer")]
        [HttpPut("{id}/status")]
        public async Task<ActionResult<JobApplicationDTO>> UpdateStatus(Guid id, [FromBody] UpdateJobApplicationStatusCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = "Admin,Employer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteJobApplicationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
