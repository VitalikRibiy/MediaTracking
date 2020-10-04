using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MediaTracking.BLL.DTOs;

namespace MediaTracking.BLL.Factories
{
    public interface IJwtFactory
    {
        (ClaimsPrincipal principal, JwtSecurityToken jwt) GetPrincipalFromExpiredToken(string token);

        TokenDTO GenerateToken(string userId, string login, string role);
    }
}