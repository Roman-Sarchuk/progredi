using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Progredi.Exceptions;

namespace Progredi.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        var value = user.FindFirstValue(JwtRegisteredClaimNames.Sub);
        
        if (string.IsNullOrEmpty(value))
        {
            throw new UnauthorizedException("User ID claim is missing in token.");
        }

        return Guid.Parse(value);
    }
}