using MediatR;
using Microsoft.EntityFrameworkCore;
using Beykam.Persistence.Context;


namespace Beykam.Application.JobApplications.Commands
{
    public class DeleteJobApplicationCommandHandler
        : IRequestHandler<DeleteJobApplicationCommand, Unit>
    {
        private readonly BeykamDbContext _context;

        public DeleteJobApplicationCommandHandler(BeykamDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var jobApp = await _context.JobApplications
                .FirstOrDefaultAsync(j => j.Id == request.Id, cancellationToken);

            if (jobApp == null)
            {
                throw new Exception("Job application not found.");
            }

            _context.JobApplications.Remove(jobApp);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
