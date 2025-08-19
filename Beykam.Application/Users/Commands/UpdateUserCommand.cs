using MediatR;

namespace Beykam.Application.Users.Commands;

public record UpdateUserCommand(Guid Id) : IRequest<Unit>;


