using Beykam.Domain.Enums;

namespace Beykam.Application.JobApplications.DTOs
{
    public class JobApplicationDTO
    {
        public Guid Id { get; set; }
        public Guid JobPostId { get; set; }
        public string JobPostTitle { get; set; } = string.Empty; 
        public Guid CandidateId { get; set; }
        public string CandidateName { get; set; } = string.Empty; 
        public string? CoverLetter { get; set; }
        public DateTime AppliedAt { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
