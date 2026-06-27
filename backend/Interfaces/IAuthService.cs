using Progredi.DTOs.Auth;

namespace Progredi.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterUserDto dto);
}