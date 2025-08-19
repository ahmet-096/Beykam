using AutoMapper;
using Beykam.Application.JobPosts.DTOs;
using Beykam.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Application.JobPosts.Queries
{
    public class GetAllJobPostsQueryHandler :  IRequestHandler<GetAllJobPostsQuery, List<JobPostResponseDTO>>
    {
        private readonly BeykamDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllJobPostsQueryHandler(BeykamDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<JobPostResponseDTO>> Handle(GetAllJobPostsQuery request, CancellationToken cancellationToken)
        {
            var jobPosts = await _dbContext.Jobs
                .Include(j => j.Employer)
                .Where(j => j.IsActive && j.IsApproved)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<JobPostResponseDTO>>(jobPosts);
        }

    }
}
