namespace Beykam.Domain.Entities
{
    public class Candidate
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public string? CvUrl { get; set; }
        public ICollection<CandidateSkill> Skills { get; set; } = new List<CandidateSkill>();
        public ICollection<CandidateLanguage> Languages { get; set; } = new List<CandidateLanguage>();
        public ICollection<CandidateExperience> Experiences { get; set; } = new List<CandidateExperience>();
        public ICollection<CandidateEducation> Educations { get; set; } = new List<CandidateEducation>();
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}
