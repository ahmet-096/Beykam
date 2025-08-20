using Beykam.Application.JobApplications.DTOs;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.JobApplications.Queries
{
    public class GetJobApplicationByIdQueryHandler 
        : IRequestHandler<GetJobApplicationByIdQuery, JobApplicationDTO>
    {
        private readonly BeykamDbContext _context;

        public GetJobApplicationByIdQueryHandler(BeykamDbContext context)
        {
            _context = context;
        }

        public async Task<JobApplicationDTO> Handle(GetJobApplicationByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.JobApplications
                .Include(x => x.JobPost)
                .Include(x => x.Candidate)
                .ThenInclude(c => c.User) 
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new KeyNotFoundException("Job application not found");

            if (entity.CandidateId != request.RequestingUserId &&
                entity.JobPost.EmployerId != request.RequestingUserId)
            {
                throw new UnauthorizedAccessException("You are not allowed to view this application");
            }

            return new JobApplicationDTO
            {
                Id = entity.Id,
                JobPostId = entity.JobPostId,
                CandidateId = entity.CandidateId,
                CoverLetter = entity.CoverLetter,
                AppliedAt = entity.AppliedAt,
                Status = entity.Status,
                JobPostTitle = entity.JobPost.Title,
                CandidateName = entity.Candidate.FirstName + " " + entity.Candidate.LastName
            };
        }
    }
}
