namespace Beykam.Domain.Entities
{
    public class CandidateExperience
    {
        public Guid Id { get; set; }
        public required string CompanyName { get; set; }
        public required string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // Devam ediyorsa null
        public Guid CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
    }
}
