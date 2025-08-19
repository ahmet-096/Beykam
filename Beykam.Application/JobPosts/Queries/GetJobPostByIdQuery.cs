using Beykam.Application.JobPosts.DTOs;
using MediatR;

namespace Beykam.Application.JobPosts.Queries
{
    public class GetJobPostByIdQuery : IRequest<JobPostDTO?>
    {
        public Guid Id { get; set; }
    }
}