namespace Beykam.Domain.Entities
{
    public class CandidateLanguage
    {
        public Guid Id { get; set; }
        public required string LanguageName { get; set; }
        public string? Proficiency { get; set; } // Beginner, Intermediate, Advanced, Native
        public Guid CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
    }
}
