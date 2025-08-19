using Beykam.Domain.Entities;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.Employers.Queries
{
    public class GetEmployerByIdQueryHandler : IRequestHandler<GetEmployerByIdQuery, Employer?>
    {
        private readonly BeykamDbContext _dbContext;

        public GetEmployerByIdQueryHandler(BeykamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employer?> Handle(GetEmployerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Employers.AsNoTracking().FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        }
    }
}


