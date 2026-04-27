using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DayNotes.API.DTOs;
using DayNotes.API.Data;
using DayNotes.API.Services;

namespace DayNotes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly AuthService _authService;
    private readonly TokenService _tokenService;

    public AuthController(
        AppDbContext context,
        AuthService authService,
        TokenService tokenService)
    {
        _context = context;
        _authService = authService;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequestDto dto)
    {
        var emailAlreadyExists = _context.Users.Any(user => user.Email == dto.Email);

        if (emailAlreadyExists)
        {
            return BadRequest("Este e-mail já está cadastrado.");
        }

        var user = _authService.CreateUser(dto);

        _context.Users.Add(user);
        _context.SaveChanges();

        return Created("", new
        {
            user.Id,
            user.Name,
            user.Email
        });
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequestDto dto)
    {
        var user = _context.Users.FirstOrDefault(user => user.Email == dto.Email);

        if (user is null)
        {
            return Unauthorized("E-mail ou senha inválidos.");
        }

        var passwordIsValid = _authService.VerifyPassword(dto.Password, user.PasswordHash);

        if (!passwordIsValid)
        {
            return Unauthorized("E-mail ou senha inválidos.");
        }

        var token = _tokenService.GenerateToken(user);

        return Ok(new
        {
            token
        });
    }
}