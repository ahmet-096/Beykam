namespace Beykam.Application.Candidates.DTOs
{
    public class UpdateCandidateDto
    {
        public string? FirstName { get; set; } = default!;
        public string? LastName { get; set; } = default!;
        public string? Email { get; set; } = default!;
        public string? PhoneNumber { get; set; } = default!;
        public string? CvUrl { get; set; }
        public List<CandidateSkillDto>? Skills { get; set; } = new();
        public List<CandidateLanguageDto>? Languages { get; set; } = new();
        public List<CandidateExperienceDto>? Experiences { get; set; } = new();
        public List<CandidateEducationDto>? Educations { get; set; } = new();
    }

    public class CandidateLanguageDto
    {
        public string LanguageName { get; set; } = default!;
        public string? Proficiency { get; set; } 
    }

    public class CandidateSkillDto
    {
        public string SkillName { get; set; } = default!;
        public int? Level { get; set; } 
    }

    public class CandidateExperienceDto
    {
        public string Position { get; set; } = default!;
        public string CompanyName { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
    }

    public class CandidateEducationDto
    {
        public string SchoolName { get; set; } = default!;
        public string Degree { get; set; } = default!;
        public string? Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
