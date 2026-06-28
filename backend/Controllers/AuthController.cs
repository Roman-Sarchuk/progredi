using Microsoft.AspNetCore.Mvc;
using Progredi.DTOs.Auth;
using Progredi.Interfaces;

namespace Progredi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
    {
        var token = await authService.RegisterAsync(dto);
            
        return Ok(new { token });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
        var token = await authService.LoginAsync(dto);

        return Ok(new { token });
    }
}