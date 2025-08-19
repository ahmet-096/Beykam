using MediatR;

namespace Beykam.Application.Users.Commands;

public record DeleteUserCommand(Guid Id) : IRequest<Unit>;


