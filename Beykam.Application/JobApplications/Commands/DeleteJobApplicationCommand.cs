using MediatR;

namespace Beykam.Application.JobApplications.Commands;

public record DeleteJobApplicationCommand(Guid Id) : IRequest<Unit>;


