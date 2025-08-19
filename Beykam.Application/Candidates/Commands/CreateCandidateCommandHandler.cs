using AutoMapper;
using Beykam.Domain.Entities;
using Beykam.Persistence.Context;
using MediatR;

namespace Beykam.Application.Candidates.Commands
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, Guid>
    {
        private readonly BeykamDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateCandidateCommandHandler(BeykamDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            Candidate candidate = _mapper.Map<Candidate>(request.Candidate);

            await _dbContext.Candidates.AddAsync(candidate, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return candidate.Id;
        }
    }
}


