using Beykam.Application.JobPosts.DTOs;
using Beykam.Application.JobPosts.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Beykam.Persistence.Context; // Eğer DbContext burada ise
namespace Beykam.Application.JobPosts.Queries
{
    public class GetAllJobPostQueryByEmployerHandler : IRequestHandler<GetAllJobPostQueryByEmployer, List<JobPostDTO>>
    {
        private readonly BeykamDbContext _context;

        public GetAllJobPostQueryByEmployerHandler(BeykamDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobPostDTO>> Handle(GetAllJobPostQueryByEmployer request, CancellationToken cancellationToken)
        {
            var jobPosts = await _context.JobPosts
                .Where(jp => jp.EmployerId == request.EmployerId)
                .ToListAsync(cancellationToken);

            return jobPosts.Select(jp => new JobPostDTO
            {
                Id = jp.Id,
                Title = jp.Title,
                Description = jp.Description,
                EmployerId = jp.EmployerId
                // DTO'da varsa diğer alanlar...
            }).ToList();
        }
    }
}