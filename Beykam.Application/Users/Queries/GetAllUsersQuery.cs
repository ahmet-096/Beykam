using Beykam.Domain.Entities;
using MediatR;

namespace Beykam.Application.Users.Queries;

public record GetAllUsersQuery() : IRequest<IEnumerable<ApplicationUser>>;


