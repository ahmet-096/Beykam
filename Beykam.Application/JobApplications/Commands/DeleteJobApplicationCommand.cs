using MediatR;

namespace Beykam.Application.JobApplications.Commands
{
    public class DeleteJobApplicationCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
