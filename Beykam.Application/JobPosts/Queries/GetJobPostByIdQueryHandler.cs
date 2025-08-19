using AutoMapper;
using Beykam.Application.JobPosts.DTOs;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.JobPosts.Queries
{
    public class GetJobPosyByIdQueryHandler :  IRequestHandler<GetJobPostByIdQuery, JobPostResponseDTO?>
    {
        private readonly BeykamDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetJobPosyByIdQueryHandler(BeykamDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<JobPostResponseDTO?> Handle(GetJobPostByIdQuery request, CancellationToken cancellationToken)
        {
            var jobPost = await _dbContext.Jobs
                .Include(j => j.Employer)
                .FirstOrDefaultAsync(j => j.Id == request.Id, cancellationToken);

            if (jobPost is null)
                throw new Exception("Job post not found");

            return _mapper.Map<JobPostResponseDTO>(jobPost);
        }
    }

}
