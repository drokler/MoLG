using Dto.Character;

namespace Domain.Character;

public interface ICharacterAggregateGrain: IGrainWithIntegerKey
{
    Task<List<CharacterDto>> GetCharacters();
    Task<List<CharacterDto>> GetCharacters(string userId);
    Task<CharacterDto> CreateCharacter(CharacterCreateDto dto);
}