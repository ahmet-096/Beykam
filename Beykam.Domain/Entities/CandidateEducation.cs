namespace Beykam.Domain.Entities
{
    public class CandidateEducation
    {
        public Guid Id { get; set; }
        public required string SchoolName { get; set; }
        public required string Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // Devam ediyorsa null
        public Guid CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
    }
}
