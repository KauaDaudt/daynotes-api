using DayNotes.API.DTOs;
using DayNotes.API.Models;

namespace DayNotes.API.Services;

public class AuthService
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }

    public DayNotes.API.Models.User CreateUser(RegisterRequestDto dto)
    {
        var user = new DayNotes.API.Models.User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = HashPassword(dto.Password)
        };

        return user;
    }
}
