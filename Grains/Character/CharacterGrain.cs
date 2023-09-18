using Domain.Character;
using Orleans.Providers;

namespace Grains.Character;

[StorageProvider]
public class CharacterGrain: Grain<CharacterState>, ICharacterGrain
{
    
}