using Beykam.Application.JobPosts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;

namespace Beykam.Application.JobPosts.Queries
{
    public class GetAllJobPostQueryByEmployer : IRequest<List<JobPostDTO>>
    {
        public Guid EmployerId { get; set; }
        public GetAllJobPostQueryByEmployer(Guid employerId)
        {
            EmployerId = employerId;
        }
    }
}