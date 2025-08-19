using Beykam.Domain.Entities;
using MediatR;

namespace Beykam.Application.Employers.Queries;

public record GetAllEmployersQuery() : IRequest<IEnumerable<Employer>>;


