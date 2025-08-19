namespace Beykam.Application.Candidates.DTOs
{
    public class CandidateResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string? CvUrl { get; set; }
        public List<CandidateSkillDto>? Skills { get; set; }
        public List<CandidateLanguageDto>? Languages { get; set; } 
        public List<CandidateExperienceDto>? Experiences { get; set; }
        public List<CandidateEducationDto>? Educations { get; set; } 
    }
}
