using Domain.Npc;
using Dto.Npc;
using Orleans.Providers;

namespace Grains.Npc;

[StorageProvider]
public class NpcAggregationGrain: Grain<NpcAggregationState>, INpcAggregationGrain
{
    public async Task<List<NpcDto>> GetNpcs()
    {
        var tasks = State.Ids.Select(async id => await GrainFactory.GetGrain<INpcGrain>(id).GetShortDto()).ToList();
        await Task.WhenAll(tasks);
        
        return tasks.Select(t => t.Result).ToList();
    }
}