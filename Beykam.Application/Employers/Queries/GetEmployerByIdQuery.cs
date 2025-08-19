using Beykam.Domain.Entities;
using MediatR;

namespace Beykam.Application.Employers.Queries
{
    public class GetEmployerByIdQuery : IRequest<Employer?>
    {
        public Guid Id { get; set; }
    }
}


