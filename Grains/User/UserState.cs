namespace Grains.User;

public class UserState
{
    public string? PasswordHash { get; set; }
    public List<string> Roles { get; set; } = new ();
    public required string Name { get; set; } = "DefaultUserName";
}