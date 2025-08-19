using Beykam.Domain.Entities;

namespace Beykam.Application.Common.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> CreateTokenAsync(ApplicationUser user, CancellationToken cancellationToken = default);
    }
}


