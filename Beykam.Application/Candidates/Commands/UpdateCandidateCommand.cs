using Beykam.Application.Candidates.DTOs;
using MediatR;

namespace Beykam.Application.Candidates.Commands
{
    public class UpdateCandidateCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public CreateCandidateDto Candidate { get; set; } = default!;
    }
}


