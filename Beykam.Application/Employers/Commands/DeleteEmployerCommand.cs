using MediatR;

namespace Beykam.Application.Employers.Commands
{
    public class DeleteEmployerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}


