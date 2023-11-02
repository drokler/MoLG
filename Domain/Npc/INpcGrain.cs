using Dto.Npc;

namespace Domain.Npc;

public interface INpcGrain: IGrainWithStringKey
{
    Task<NpcDto> GetShortDto();
}