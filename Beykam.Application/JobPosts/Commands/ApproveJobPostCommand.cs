using MediatR;

namespace Beykam.Application.JobPosts.Commands
{
    public class ApproveJobPostCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

    }
}
