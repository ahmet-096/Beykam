using Beykam.Application.JobPosts.DTOs;
using MediatR;

namespace Beykam.Application.JobPosts.Queries
{
    public class GetJobPostByIdQuery : IRequest<JobPostResponseDTO?>
    {
        public Guid Id { get; set; }
    }
}