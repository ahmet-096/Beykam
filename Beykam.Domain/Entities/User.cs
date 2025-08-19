using Beykam.Domain.Enums;

namespace Beykam.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public UserType UserType { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Employer? Employer { get; set; }
    public Candidate? Candidate { get; set; }
}
