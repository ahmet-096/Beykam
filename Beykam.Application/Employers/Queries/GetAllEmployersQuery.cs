using Beykam.Domain.Entities;
using MediatR;

namespace Beykam.Application.Employers.Queries
{
    public class GetAllEmployersQuery : IRequest<IEnumerable<Employer>>
    {
    }
}


