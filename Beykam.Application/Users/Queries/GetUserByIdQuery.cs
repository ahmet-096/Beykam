using Beykam.Domain.Entities;
using MediatR;

namespace Beykam.Application.Users.Queries;

public record GetUserByIdQuery(Guid Id) : IRequest<User?>;


