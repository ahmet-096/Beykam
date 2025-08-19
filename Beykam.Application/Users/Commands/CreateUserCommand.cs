using MediatR;

namespace Beykam.Application.Users.Commands;

public record CreateUserCommand() : IRequest<Guid>;


