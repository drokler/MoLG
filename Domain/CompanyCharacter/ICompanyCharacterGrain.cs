namespace Domain.CompanyCharacter;

public interface ICompanyCharacterGrain: IGrainWithStringKey
{
    Task AddCharacter(string characterId);
    Task<List<string>> GetCharacterList();
}