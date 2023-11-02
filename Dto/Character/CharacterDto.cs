namespace Dto.Character;

public class CharacterDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? UserId { get; set; }
}