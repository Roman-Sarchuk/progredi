using Microsoft.AspNetCore.Mvc;
using Progredi.DTOs.Auth;
using Progredi.Interfaces;

namespace Progredi.Controllers;

[ApiController] // Вмикає автоматичну валідацію наших DTO!
[Route("api/v1/[controller]")] // [controller] автоматично підставить слово "auth"
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
    {
        try
        {
            var token = await authService.RegisterAsync(dto);
            
            return Ok(new { token });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
        try
        {
            var token = await authService.LoginAsync(dto);

            return Ok(new { token });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { error = ex.Message });
        }
    }
}