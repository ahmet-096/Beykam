using Beykam.Application.JobApplications.DTOs;
using MediatR;

namespace Beykam.Application.JobApplications.Queries
{
    public class GetJobApplicationByIdQuery : IRequest<JobApplicationDTO>
    {
        public Guid Id { get; set; }
        public Guid RequestingUserId { get; set; } 
    }
}
