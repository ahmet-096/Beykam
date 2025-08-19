using Beykam.Application.Employers.DTOs;
using MediatR;

namespace Beykam.Application.Employers.Commands
{
    public class UpdateEmployerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public UpdateEmployerDto Employer { get; set; } = default!;
    }
}


