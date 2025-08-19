using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.Candidates.Commands
{
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand, Unit>
    {
        private readonly BeykamDbContext _dbContext;

        public DeleteCandidateCommandHandler(BeykamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            if (candidate is null)
            {
                return Unit.Value; // Or throw NotFoundException
            }

            _dbContext.Candidates.Remove(candidate);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}


