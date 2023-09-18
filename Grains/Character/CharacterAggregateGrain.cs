using Domain.Character;
using Dto.Character;
using Orleans.Providers;

namespace Grains.Character;

[StorageProvider]
public class CharacterAggregateGrain: Grain<CharacterAggregateGrain>, ICharacterAggregateGrain
{
    public async Task<List<CharacterDto>> GetCharacters()
    {
        throw new NotImplementedException();
    }

    public async Task<List<CharacterDto>> GetCharacters(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<CharacterDto> CreateCharacter(CharacterCreateDto dto)
    {
        throw new NotImplementedException();
    }
}