using Beykam.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Beykam.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FullName { get; set; }
        public UserType? UserType { get; set; } 
        public bool IsActive { get; set; } = true;
        public Candidate? Candidate { get; set; }
        public Employer? Employer { get; set; }
    }
}
