namespace Dto.User;

public class UserDto
{
    public required string Login { get; set; }
    public required string Name { get; set; }
    public required List<string> Roles { get; set; }
}