using MediatR;

namespace Beykam.Application.JobApplications.Commands;

public record CreateJobApplicationCommand() : IRequest<Guid>;


