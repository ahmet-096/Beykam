using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.Employers.Commands
{
    public class DeleteEmployerCommandHandler : IRequestHandler<DeleteEmployerCommand, Unit>
    {
        private readonly BeykamDbContext _dbContext;

        public DeleteEmployerCommandHandler(BeykamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteEmployerCommand request, CancellationToken cancellationToken)
        {
            var employer = await _dbContext.Employers.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
            if (employer is null)
            {
                return Unit.Value; 
            }

            _dbContext.Employers.Remove(employer);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}


