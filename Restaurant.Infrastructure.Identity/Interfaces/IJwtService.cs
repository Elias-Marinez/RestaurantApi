
using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Infrastructure.Identity.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace Restaurant.Infrastructure.Identity.Interfaces
{
    public interface IJwtService
    {
        Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user);
        RefreshToken GenerateRefreshToken();
    }
}
