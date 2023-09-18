namespace Grains.User;

public class UserState
{
    public string? PasswordHash { get; set; }
    public List<string> Roles { get; set; } = new List<string>() {"admin"};
}