using Beykam.Domain.Enums;

namespace Beykam.Application.JobPosts.DTOs
{
    public class JobPostDTO
    {
        public Guid EmployerId { get; set; }

        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string Location { get; set; } = default!;
        public JobType JobType { get; set; }
        public string EmployerName { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public int ViewCount { get; set; }
        public int ApplicationCount { get; set; }
        public string Description { get; set; } = default!;
        public bool IsApproved { get; set; }
    }
}
