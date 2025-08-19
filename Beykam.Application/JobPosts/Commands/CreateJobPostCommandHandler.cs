using Beykam.Application.JobPosts.DTOs;
using Beykam.Domain.Entities;
using Beykam.Domain.Enums;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.JobPosts.Commands
{
    public class CreateJobPostCommandHandler : IRequestHandler<CreateJobPostCommand, JobPostDTO>
    {
        private readonly BeykamDbContext _dbContext;

        public CreateJobPostCommandHandler(BeykamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<JobPostDTO> Handle(CreateJobPostCommand request, CancellationToken cancellationToken)
        {
            var employer = await _dbContext.Employers.FirstOrDefaultAsync(e => e.Id == request.EmployerId && e.IsApproved, cancellationToken);
            if (employer == null)
                throw new KeyNotFoundException("Employer not found or not approved.");

            var jobPost = new JobPost
            {
                EmployerId = employer.Id,
                Title = request.Title,
                Description = request.Description,
                JobType = request.JobType,
                Location = request.Location,
                IsApproved = false, // önce admin onayına düşecek
                IsActive = true
            };

            _dbContext.Jobs.Add(jobPost);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new JobPostDTO
            {
                Id = jobPost.Id,
                Title = jobPost.Title,
                Location = jobPost.Location,
                JobType = jobPost.JobType,
                EmployerName = employer.CompanyName,
                CreatedAt = jobPost.CreatedAt,
                ViewCount = jobPost.ViewCount,
                ApplicationCount = jobPost.ApplicationCount
            };
        }
    }
}
