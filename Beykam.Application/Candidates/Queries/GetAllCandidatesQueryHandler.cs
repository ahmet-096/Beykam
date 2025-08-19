using AutoMapper;
using Beykam.Application.Candidates.DTOs;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.Candidates.Queries
{
    public class GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, IEnumerable<CandidateResponseDto>>
    {
        private readonly BeykamDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllCandidatesQueryHandler(BeykamDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CandidateResponseDto>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _dbContext.Candidates
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<CandidateResponseDto>>(entities);
        }
    }
}


