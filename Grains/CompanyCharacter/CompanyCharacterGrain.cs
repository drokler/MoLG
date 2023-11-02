using Domain;
using Domain.CompanyCharacter;
using Orleans.Providers;

namespace Grains.CompanyCharacter;

[StorageProvider]
public class CompanyCharacterGrain: Grain<CompanyCharacterState>, ICompanyCharacterGrain
{
    public async Task AddCharacter(string characterId)
    {
        if (!State.Characters.Contains(characterId))
        {
            State.Characters.Add(characterId);
            await WriteStateAsync();
        }
    }

    public Task<List<string>> GetCharacterList()
    {
        return Task.FromResult(State.Characters);
    }
}