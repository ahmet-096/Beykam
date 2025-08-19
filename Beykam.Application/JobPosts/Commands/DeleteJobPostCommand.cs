using MediatR;

namespace Beykam.Application.JobPosts.Commands
{
    public class DeleteJobPostCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
