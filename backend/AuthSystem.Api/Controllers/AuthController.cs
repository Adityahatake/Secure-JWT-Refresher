using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AuthSystem.Api.Data;
using AuthSystem.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthSystem.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

[HttpPost("login")]
public IActionResult Login(LoginRequest request)
{
    var username = request.Username.Trim().ToLower();
    var password = request.Password.Trim();

    var passwordHash = HashPassword(password);

    var user = _context.Users.FirstOrDefault(u =>
        u.Username.ToLower() == username &&
        u.PasswordHash == passwordHash &&
        u.IsActive);

    if (user == null)
        return Unauthorized("Invalid credentials");

    return Ok(new { message = "Login successful" });
}


    private static string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        return Convert.ToBase64String(
            sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
    }
}

public record LoginRequest(string Username, string Password);
