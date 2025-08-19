using MediatR;

namespace Beykam.Application.JobPosts.Commands;

public record DeleteJobPostCommand(Guid Id) : IRequest<Unit>;


