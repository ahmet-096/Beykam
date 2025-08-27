using Beykam.Domain.Enums;

namespace Beykam.Domain.Entities;

public class JobPost
{
    public Guid Id { get; set; }
    public Guid EmployerId { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = null!;
    public JobType JobType { get; set; }
    public string Location { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int ViewCount { get; set; } = 0;
    public int ApplicationCount { get; set; } = 0;
    public bool IsApproved { get; set; } = false;
    public bool IsActive { get; set; } = true;
    public Employer Employer { get; set; } = null!;
    public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
}
