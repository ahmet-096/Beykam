using Beykam.Application.JobApplications.DTOs;
using MediatR;

namespace Beykam.Application.JobApplications.Queries
{
    public class GetJobApplicationsListQuery : IRequest<List<JobApplicationDTO>>
    {
        public Guid? JobPostId { get; set; }
        public Guid? CandidateId { get; set; }
        public Guid? EmployerId { get; set; } 
    }
}
