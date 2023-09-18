namespace Grains.Company;

public class CompanyState
{
    public required string Name { get; set; } = "DefaultName";
    public Dictionary<string, string> CompanyCharacters = new();

}