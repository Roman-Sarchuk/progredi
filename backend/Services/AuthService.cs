using Microsoft.EntityFrameworkCore;
using Progredi.DataAccess;
using Progredi.DataAccess.Entities;
using Progredi.DTOs.Auth;
using Progredi.Interfaces;

namespace Progredi.Services;

public class AuthService(AppDbContext context) : IAuthService
{
    public async Task<string> RegisterAsync(RegisterUserDto dto)
    {
        var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        if (existingUser != null)
        {
            throw new Exception("User with this email already exists"); 
        }

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var newUser = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PasswordHash = passwordHash
        };

        context.Users.Add(newUser);
        await context.SaveChangesAsync();

        return "User registered successfully!";
    }
}