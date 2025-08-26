using Beykam.Domain.Entities;
using Beykam.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Beykam.Persistence.Context
{
    public class BeykamDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public BeykamDbContext(DbContextOptions<BeykamDbContext> options) : base(options) { }
        public DbSet<Candidate> Candidates { get; set; } = default!;
        public DbSet<CandidateSkill> CandidateSkills { get; set; } = default!;
        public DbSet<CandidateLanguage> CandidateLanguages { get; set; } = default!;
        public DbSet<CandidateExperience> CandidateExperiences { get; set; } = default!;
        public DbSet<CandidateEducation> CandidateEducations { get; set; } = default!;
        public DbSet<Employer> Employers { get; set; } = default!;
        public DbSet<JobPost> JobPosts { get; set; } = default!;
        public DbSet<JobApplication> JobApplications { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            // Candidate ↔ ApplicationUser
            modelBuilder.Entity<Candidate>()
                .HasOne(c => c.User)
                .WithOne(u => u.Candidate)
                .HasForeignKey<Candidate>(c => c.UserId);

            // Employer ↔ ApplicationUser
            modelBuilder.Entity<Employer>()
                .HasOne(e => e.User)
                .WithOne(u => u.Employer)
                .HasForeignKey<Employer>(e => e.UserId);
        }
    }
}
