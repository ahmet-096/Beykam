using Beykam.Application.Candidates.DTOs;
using MediatR;

namespace Beykam.Application.Candidates.Commands
{
    public class CreateCandidateCommand : IRequest<Guid>
    {
        public CreateCandidateDto Candidate { get; set; } = default!;
    }
}
