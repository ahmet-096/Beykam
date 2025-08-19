using MediatR;

namespace Beykam.Application.Employers.Commands;

public record UpdateEmployerCommand(Guid Id) : IRequest<Unit>;


