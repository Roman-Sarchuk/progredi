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
            var result = await authService.RegisterAsync(dto);
            
            return Ok(new { message = result });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}