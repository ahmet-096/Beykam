using MediatR;

namespace Beykam.Application.JobPosts.Commands;

public record CreateJobPostCommand() : IRequest<Guid>;


