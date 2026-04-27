using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using DayNotes.API.Models;

namespace DayNotes.API.Services;

public class TokenService
{
    public string GenerateToken(DayNotes.API.Models.User user)
    {
        var key = "daynotes-super-secret-key-development-2026-very-strong-key"; 
        
        
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var keyBytes = Encoding.UTF8.GetBytes(key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
