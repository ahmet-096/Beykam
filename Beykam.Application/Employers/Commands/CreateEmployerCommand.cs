using MediatR;

namespace Beykam.Application.Employers.Commands;

public record CreateEmployerCommand() : IRequest<Guid>;


