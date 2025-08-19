using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.JobPosts.Commands
{
    public class ApproveJobPostCommandHandler : IRequestHandler<ApproveJobPostCommand, Unit>
    {
        private readonly BeykamDbContext _dbContext;

        public ApproveJobPostCommandHandler(BeykamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ApproveJobPostCommand request, CancellationToken cancellationToken)
        {
            var jobPost = await _dbContext.Jobs
                .FirstOrDefaultAsync(j => j.Id == request.Id, cancellationToken);

            if (jobPost == null)
                throw new KeyNotFoundException("Job post not found");

            jobPost.IsApproved = true;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
