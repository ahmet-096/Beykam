using Beykam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Persistence.Context
{
    public class BeykamDbContext : DbContext
    {
        public BeykamDbContext(DbContextOptions<BeykamDbContext> options) : base(options) { }

        // Entities
        public DbSet<User> Users { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }
        public DbSet<CandidateLanguage> CandidateLanguages { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }
        public DbSet<CandidateEducation> CandidateEducations { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<JobPost> Jobs { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // UserType enum conversion
            modelBuilder.Entity<User>()
                .Property(u => u.UserType)
                .HasConversion<string>();

            // Candidate ↔ Skills
            modelBuilder.Entity<CandidateSkill>()
                .HasOne(s => s.Candidate)
                .WithMany(c => c.Skills)
                .HasForeignKey(s => s.CandidateId);

            // Candidate ↔ Languages
            modelBuilder.Entity<CandidateLanguage>()
                .HasOne(l => l.Candidate)
                .WithMany(c => c.Languages)
                .HasForeignKey(l => l.CandidateId);

            // Candidate ↔ Experiences
            modelBuilder.Entity<CandidateExperience>()
                .HasOne(e => e.Candidate)
                .WithMany(c => c.Experiences)
                .HasForeignKey(e => e.CandidateId);

            // Candidate ↔ Educations
            modelBuilder.Entity<CandidateEducation>()
                .HasOne(ed => ed.Candidate)
                .WithMany(c => c.Educations)
                .HasForeignKey(ed => ed.CandidateId);

            // Employer ↔ Jobs
            modelBuilder.Entity<JobPost>()
                .HasOne(j => j.Employer)
                .WithMany(e => e.JobPosts)
                .HasForeignKey(j => j.EmployerId);

            // JobApplication ↔ Job & Candidate
            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.JobPost)
                .WithMany(j => j.JobApplications)
                .HasForeignKey(ja => ja.JobPostId);

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.Candidate)
                .WithMany(c => c.Applications)
                .HasForeignKey(ja => ja.CandidateId);
        }
    }
}
