using AutoMapper;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.Candidates.Commands
{
    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, Unit>
    {
        private readonly BeykamDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateCandidateCommandHandler(BeykamDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _dbContext.Candidates
                .Include(c => c.Skills)
                .Include(c => c.Languages)
                .Include(c => c.Experiences)
                .Include(c => c.Educations)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (candidate is null)
            {
                return Unit.Value; // Or throw NotFoundException
            }

            _mapper.Map(request.Candidate, candidate);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}


