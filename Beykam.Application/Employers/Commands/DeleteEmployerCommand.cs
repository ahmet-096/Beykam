using MediatR;

namespace Beykam.Application.Employers.Commands;

public record DeleteEmployerCommand(Guid Id) : IRequest<Unit>;


