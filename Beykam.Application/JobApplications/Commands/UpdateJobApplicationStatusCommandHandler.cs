using Beykam.Application.JobApplications.DTOs;
using Beykam.Persistence;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.JobApplications.Commands
{
    public class UpdateJobApplicationStatusCommandHandler 
        : IRequestHandler<UpdateJobApplicationStatusCommand, JobApplicationDTO>
    {
        private readonly BeykamDbContext _context;

        public UpdateJobApplicationStatusCommandHandler(BeykamDbContext context)
        {
            _context = context;
        }

        public async Task<JobApplicationDTO> Handle(UpdateJobApplicationStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.JobApplications
                .Include(x => x.JobPost)
                .Include(x => x.Candidate)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null) throw new KeyNotFoundException("Application not found");

            entity.Status = request.Status;
            await _context.SaveChangesAsync(cancellationToken);

            return new JobApplicationDTO
            {
                Id = entity.Id,
                JobPostId = entity.JobPostId,
                CandidateId = entity.CandidateId,
                CoverLetter = entity.CoverLetter,
                AppliedAt = entity.AppliedAt,
                Status = entity.Status,
                JobPostTitle = entity.JobPost?.Title ?? "",
                CandidateName = $"{entity.Candidate?.FirstName} {entity.Candidate?.LastName}".Trim()
            };
        }
    }
}
