using Beykam.Domain.Entities;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.Employers.Queries
{
    public class GetAllEmployersQueryHandler : IRequestHandler<GetAllEmployersQuery, IEnumerable<Employer>>
    {
        private readonly BeykamDbContext _dbContext;

        public GetAllEmployersQueryHandler(BeykamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employer>> Handle(GetAllEmployersQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Employers.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}


