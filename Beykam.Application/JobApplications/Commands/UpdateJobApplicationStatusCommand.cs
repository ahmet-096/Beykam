using Beykam.Application.JobApplications.DTOs;
using Beykam.Domain.Enums;
using MediatR;

namespace Beykam.Application.JobApplications.Commands
{
    public class UpdateJobApplicationStatusCommand : IRequest<JobApplicationDTO>
    {
        public Guid Id { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
