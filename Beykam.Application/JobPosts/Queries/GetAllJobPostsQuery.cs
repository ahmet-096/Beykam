using Beykam.Application.JobPosts.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Beykam.Application.JobPosts.Queries
{
    public class GetAllJobPostsQuery() : IRequest<List<JobPostResponseDTO>>
    {
        
    }

}
