using MediatR;

namespace Beykam.Application.JobPosts.Commands;

public record UpdateJobPostCommand(Guid Id) : IRequest<Unit>;


