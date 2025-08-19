using Beykam.Application.Candidates.DTOs;
using MediatR;

namespace Beykam.Application.Candidates.Queries
{
    public class GetAllCandidatesQuery : IRequest<IEnumerable<CandidateResponseDto>>
    {
    }
}


