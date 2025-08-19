namespace Beykam.Domain.Entities
{
    public class CandidateSkill
    {
        public Guid Id { get; set; }
        public required string SkillName { get; set; }
        public int Level { get; set; } // 1-5 arası seviye
        public Guid CandidateId { get; set; }
        public Candidate? Candidate { get; set; }
    }
}
