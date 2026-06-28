using Progredi.DataAccess.Entities;

namespace Progredi.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user); 
}