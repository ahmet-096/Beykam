using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.Employers.Commands
{
    public class ApproveEmployerCommandHandler : IRequestHandler<ApproveEmployerCommand, Unit>
    {
        private readonly BeykamDbContext _dbContext;

        public ApproveEmployerCommandHandler(BeykamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ApproveEmployerCommand request, CancellationToken cancellationToken)
        {
            var employer = await _dbContext.Employers
                .FirstOrDefaultAsync(j => j.Id == request.Id, cancellationToken);

            if (employer == null)
                throw new KeyNotFoundException("Employer not found");

            employer.IsApproved = true;
            employer.ApprovedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
