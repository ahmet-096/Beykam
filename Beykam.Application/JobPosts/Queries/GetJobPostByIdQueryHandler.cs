using AutoMapper;
using Beykam.Application.JobPosts.DTOs;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.JobPosts.Queries
{
    public class GetJobPosyByIdQueryHandler :  IRequestHandler<GetJobPostByIdQuery, JobPostDTO?>
    {
        private readonly BeykamDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetJobPosyByIdQueryHandler(BeykamDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<JobPostDTO?> Handle(GetJobPostByIdQuery request, CancellationToken cancellationToken)
        {
            var jobPost = await _dbContext.JobPosts
                .Include(j => j.Employer)
                .FirstOrDefaultAsync(j => j.Id == request.Id, cancellationToken);

            if (jobPost is null)
                throw new Exception("Job post not found");

            return _mapper.Map<JobPostDTO>(jobPost);
        }
    }

}
