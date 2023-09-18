namespace Dto.CompanyCharacter;

public class CompanyCharacterGetResultDto
{
    public required string CompanyId { get; set; }
    public List<string> CharacterIds { get; set; } = new();
}