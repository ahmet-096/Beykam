using MediatR;
using Beykam.Domain.Enums;
using Beykam.Application.JobPosts.DTOs;

namespace Beykam.Application.JobPosts.Commands
{
    public class CreateJobPostCommand : IRequest<JobPostDTO>
    {
        public Guid EmployerId { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public JobType JobType { get; set; }
        public string Location { get; set; } = default!;
    }
}
