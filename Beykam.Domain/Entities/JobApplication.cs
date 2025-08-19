using Beykam.Domain.Enums;

namespace Beykam.Domain.Entities;

public class JobApplication
{
    public Guid Id { get; set; }
    public Guid JobPostId { get; set; }
    public Guid CandidateId { get; set; }
    public string CoverLetter { get; set; } = string.Empty;
    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
    public ApplicationStatus Status { get; set; } = ApplicationStatus.Pending;
    public JobPost JobPost { get; set; } = null!;
    public Candidate Candidate { get; set; } = null!;
}
