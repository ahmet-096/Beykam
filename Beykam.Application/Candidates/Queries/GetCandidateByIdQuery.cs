using Beykam.Application.Candidates.DTOs;
using MediatR;

namespace Beykam.Application.Candidates.Queries
{
    public class GetCandidateByIdQuery : IRequest<CandidateResponseDto?>
    {
        public Guid Id { get; set; }
    }
}


