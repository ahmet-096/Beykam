using Beykam.Application.JobApplications.DTOs;
using MediatR;

namespace Beykam.Application.JobApplications.Commands
{
    public class CreateJobApplicationCommand : IRequest<JobApplicationDTO>
    {
        public Guid JobPostId { get; set; }
        public Guid CandidateId { get; set; }
        public string? CoverLetter { get; set; }
    }
}
