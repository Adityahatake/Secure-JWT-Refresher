using System.Security.Cryptography;
using System.Text;
using AuthSystem.Api.Models;

namespace AuthSystem.Api.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Users.Any())
            return;

        var user = new User
        {
            Username = "admin",
            PasswordHash = HashPassword("Admin@123"),
            Role = "admin",
            IsActive = true,
            RefreshToken = Guid.NewGuid().ToString(),
            RefreshTokenExpiry = DateTime.UtcNow.AddDays(7)
        };

        context.Users.Add(user);
        context.SaveChanges();
    }

    private static string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        return Convert.ToBase64String(
            sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
    }
}
