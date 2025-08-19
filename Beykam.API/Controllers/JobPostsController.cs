using Beykam.Application.JobPosts.DTOs;
using Beykam.Application.JobPosts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Beykam.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobPostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobPostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobPosts = await _mediator.Send(new GetAllJobPostsQuery());
            return Ok(jobPosts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var jobPost = await _mediator.Send(new GetJobPostByIdQuery { Id = id });

            return Ok(jobPost);
        }
    }
}
