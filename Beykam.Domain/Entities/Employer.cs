using Beykam.Domain.Enums;

namespace Beykam.Domain.Entities;

public class Employer
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public ApplicationUser? User { get; set; } 
    public string CompanyName { get; set; } = null!;
     public string? CompanyDescription { get; set; }
    public string? Website { get; set; }
    public string? LogoUrl { get; set; }
    public string? Phone { get; set; }
    public EmployerStatus Status { get; set; } = EmployerStatus.Pending;
    public bool IsApproved { get; set; } = false;
    public DateTime? ApprovedAt { get; set; }
    public string? RejectionReason { get; set; }
    public ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
}
