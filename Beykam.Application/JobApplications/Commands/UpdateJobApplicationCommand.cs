using MediatR;

namespace Beykam.Application.JobApplications.Commands;

public record UpdateJobApplicationCommand(Guid Id) : IRequest<Unit>;


