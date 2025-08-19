using Beykam.Domain.Entities;
using MediatR;

namespace Beykam.Application.JobPosts.Queries;

public record GetAllJobPostsQuery() : IRequest<IEnumerable<JobPost>>;


