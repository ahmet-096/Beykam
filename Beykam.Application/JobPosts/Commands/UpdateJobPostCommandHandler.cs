using Beykam.Application.JobPosts.DTOs;
using Beykam.Domain.Entities;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.JobPosts.Commands
{

    public class UpdateJobPostCommandHandler : IRequestHandler<UpdateJobPostCommand, JobPostDTO>
    {
        private readonly BeykamDbContext _dbContext;

        public UpdateJobPostCommandHandler(BeykamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<JobPostDTO> Handle(UpdateJobPostCommand request, CancellationToken cancellationToken)
        {
            var jobPost = await _dbContext.JobPosts.Include(j => j.Employer)
                .FirstOrDefaultAsync(j => j.Id == request.Id && j.IsActive, cancellationToken);

            if (jobPost == null)
                throw new KeyNotFoundException("Job post not found.");

            jobPost.Title = request.Title ?? jobPost.Title;
            jobPost.Description = request.Description ?? jobPost.Description;
            jobPost.Location = request.Location ?? jobPost.Location;
            jobPost.JobType = request.JobType ?? jobPost.JobType;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new JobPostDTO
            {
                Id = jobPost.Id,
                Title = jobPost.Title,
                Location = jobPost.Location,
                JobType = jobPost.JobType,
                EmployerName = jobPost.Employer.CompanyName,
                CreatedAt = jobPost.CreatedAt,
                ViewCount = jobPost.ViewCount,
                ApplicationCount = jobPost.ApplicationCount,
                Description = jobPost.Description
            };
        }
    }
}
