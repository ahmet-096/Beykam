using Beykam.Application.JobPosts.DTOs;
using Beykam.Domain.Enums;
using MediatR;

namespace Beykam.Application.JobPosts.Commands
{
    public class UpdateJobPostCommand : IRequest<JobPostDTO>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public JobType? JobType { get; set; }
    }
}