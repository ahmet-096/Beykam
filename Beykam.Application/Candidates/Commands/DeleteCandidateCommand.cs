using MediatR;

namespace Beykam.Application.Candidates.Commands
{
    public class DeleteCandidateCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}


