namespace AuthSystem.Api.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Role { get; set; } = "User";
    public bool IsActive { get; set; } = true;

    public string RefreshToken { get; set; } = null!;
    public DateTime RefreshTokenExpiry { get; set; }
}
