using AutoMapper;
using Beykam.Application.JobApplications.DTOs;
using Beykam.Domain.Entities;
using Beykam.Domain.Enums;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.JobApplications.Commands
{
    public class CreateJobApplicationCoommandHandler : IRequestHandler<CreateJobApplicationCommand, JobApplicationDTO>
    {
        private readonly BeykamDbContext _context;
        private readonly IMapper _mapper;

        public CreateJobApplicationCoommandHandler(BeykamDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<JobApplicationDTO> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var jobPost = await _context.JobPosts
                .FirstOrDefaultAsync(x => x.Id == request.JobPostId, cancellationToken);

            if (jobPost == null)
                throw new Exception("Job post not found");

            var candidate = await _context.Candidates
                .FirstOrDefaultAsync(x => x.Id == request.CandidateId, cancellationToken);

            if (candidate == null)
                throw new Exception("Candidate not found");

            var application = new JobApplication
            {
                Id = Guid.NewGuid(),
                JobPostId = request.JobPostId,
                CandidateId = request.CandidateId,
                AppliedAt = DateTime.UtcNow,
                Status = ApplicationStatus.Pending,
                CoverLetter = string.IsNullOrWhiteSpace(request.CoverLetter)
                                ? null
                                : request.CoverLetter
            };

            _context.JobApplications.Add(application);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<JobApplicationDTO>(application);
        }
    }
}
