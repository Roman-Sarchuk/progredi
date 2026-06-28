using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Progredi.DataAccess.Entities;
using Progredi.Interfaces;

namespace Progredi.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string GenerateToken(User user)
    {
        var secretKey = config["JwtSettings:Secret"];
        
        var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        
        var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("FirstName", user.FirstName), 
            new Claim("LastName", user.LastName)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(config["JwtSettings:ExpiryMinutes"]!)),
            Issuer = config["JwtSettings:Issuer"],
            Audience = config["JwtSettings:Audience"],
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}