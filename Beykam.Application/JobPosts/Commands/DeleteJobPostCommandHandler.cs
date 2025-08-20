using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.JobPosts.Commands
{
    public class DeleteJobPostCommandHandler : IRequestHandler<DeleteJobPostCommand, Unit>
    {
        private readonly BeykamDbContext _dbContext;

        public DeleteJobPostCommandHandler(BeykamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteJobPostCommand request, CancellationToken cancellationToken)
        {
            var jobPost = await _dbContext.JobPosts.FirstOrDefaultAsync(j => j.Id == request.Id, cancellationToken);
            if (jobPost == null)
                throw new KeyNotFoundException("Job post not found.");

            _dbContext.JobPosts.Remove(jobPost);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
