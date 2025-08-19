using Beykam.Domain.Enums;

namespace Beykam.Domain.Entities;

public class JobPost
{
    public Guid Id { get; set; }
    public Guid EmployerId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public JobType JobType { get; set; }
    public string Location { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public Employer Employer { get; set; } = null!;
    public ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
}
