using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.Employers.Commands
{
    public class UpdateEmployerCommandHandler : IRequestHandler<UpdateEmployerCommand, Unit>
    {
        private readonly BeykamDbContext _dbContext;

        public UpdateEmployerCommandHandler(BeykamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateEmployerCommand request, CancellationToken cancellationToken)
        {
            var employer = await _dbContext.Employers
                .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (employer is null)
            {
                return Unit.Value;
            }

            if (request.Employer.CompanyName is not null)
                employer.CompanyName = request.Employer.CompanyName;
            if (request.Employer.CompanyDescription is not null)
                employer.CompanyDescription = request.Employer.CompanyDescription;
            if (request.Employer.Website is not null)
                employer.Website = request.Employer.Website;
            if (request.Employer.LogoUrl is not null)
                employer.LogoUrl = request.Employer.LogoUrl;
            if (request.Employer.Phone is not null)
                employer.Phone = request.Employer.Phone;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}


