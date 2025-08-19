using AutoMapper;
using Beykam.Application.Candidates.DTOs;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.Candidates.Queries
{
    public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, CandidateResponseDto?>
    {
        private readonly BeykamDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCandidateByIdQueryHandler(BeykamDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CandidateResponseDto?> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Candidates
                .AsNoTracking()
                .Include(c => c.Skills)
                .Include(c => c.Languages)
                .Include(c => c.Experiences)
                .Include(c => c.Educations)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
                return null;

            return _mapper.Map<CandidateResponseDto>(entity);
        }
    }
}
