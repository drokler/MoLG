using Domain.Npc;
using Dto.Npc;
using Orleans.Providers;

namespace Grains.Npc;

[StorageProvider]
public class NpcGrain: Grain<NpcState>, INpcGrain
{
    public async Task<NpcDto> GetShortDto()
    {
        throw new NotImplementedException();
    }
}