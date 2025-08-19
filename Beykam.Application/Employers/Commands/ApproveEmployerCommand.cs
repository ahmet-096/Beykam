using MediatR;

namespace Beykam.Application.Employers.Commands
{
    public class ApproveEmployerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

    }
}
