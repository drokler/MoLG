using Dto.Character;

namespace Dto.Company;

public class CompanyDto
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public List<CharacterDto> Characters { get; set; } = new();
    public uint Cycles { get; set; }
    public DateTime TimeInCycle { get; set; }
    
}