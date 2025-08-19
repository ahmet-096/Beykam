using Beykam.Domain.Entities;
using MediatR;

namespace Beykam.Application.JobPosts.Queries;

public record GetJobPostByIdQuery(Guid Id) : IRequest<JobPost?>;


