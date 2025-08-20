using Beykam.Application.JobApplications.DTOs;
using Beykam.Persistence;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.JobApplications.Queries
{
    public class GetJobApplicationsListQueryHandler 
        : IRequestHandler<GetJobApplicationsListQuery, List<JobApplicationDTO>>
    {
        private readonly BeykamDbContext _context;

        public GetJobApplicationsListQueryHandler(BeykamDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobApplicationDTO>> Handle(GetJobApplicationsListQuery request, CancellationToken cancellationToken)
        {
            var query = _context.JobApplications
            .Include(x => x.JobPost)
            .Include(x => x.Candidate)
            .AsQueryable();

        if (request.CandidateId.HasValue)
        {
            query = query.Where(x => x.CandidateId == request.CandidateId.Value);
        }
        if (request.EmployerId.HasValue)
        {
            query = query.Where(x => x.JobPost.EmployerId == request.EmployerId.Value);
        }

        if (request.JobPostId.HasValue)
            query = query.Where(x => x.JobPostId == request.JobPostId.Value);

        return await query.Select(entity => new JobApplicationDTO
        {
            Id = entity.Id,
            JobPostId = entity.JobPostId,
            CandidateId = entity.CandidateId,
            CoverLetter = entity.CoverLetter,
            AppliedAt = entity.AppliedAt,
            Status = entity.Status,
            JobPostTitle = entity.JobPost.Title,
            CandidateName = entity.Candidate.FirstName + " " + entity.Candidate.LastName
        }).ToListAsync(cancellationToken);
        }
    }
}
