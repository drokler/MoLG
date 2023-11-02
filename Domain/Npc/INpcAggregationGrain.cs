using Dto.Npc;

namespace Domain.Npc;

public interface INpcAggregationGrain: IGrainWithIntegerKey
{
    Task<List<NpcDto>> GetNpcs();
}