using Beykam.Application.JobPosts.Commands;
using Beykam.Application.JobPosts.DTOs;
using Beykam.Application.JobPosts.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Beykam.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobPostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobPostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var jobPosts = await _mediator.Send(new GetAllJobPostsQuery());
            return Ok(jobPosts);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var jobPost = await _mediator.Send(new GetJobPostByIdQuery{ Id = id });
            if (jobPost == null)
                return NotFound();
            return Ok(jobPost);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Employer")]
        public async Task<IActionResult> Create([FromBody] CreateJobPostCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Employer")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateJobPostCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var updated = await _mediator.Send(command);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Employer")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteJobPostCommand { Id = id });
            return NoContent();
        }

        [HttpPost("approve/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve(Guid id)
        {
            await _mediator.Send(new ApproveJobPostCommand{ Id = id });
            return NoContent();
        }
    }
}
