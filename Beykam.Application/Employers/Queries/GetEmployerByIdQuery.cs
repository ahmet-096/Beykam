using Beykam.Domain.Entities;
using MediatR;

namespace Beykam.Application.Employers.Queries;

public record GetEmployerByIdQuery(Guid Id) : IRequest<Employer?>;


