using Domain.Tips;
using Dto.Tips;
using Orleans.Providers;

namespace Grains.Tips;

[StorageProvider]
public class TipAggregationGrain: Grain<TipAggregationState>, ITipAggregationGrain
{
    public async Task<List<TipDto>> GetTips()
    {
        var dtoTasks = State.TipIds.Select(async t => await GrainFactory.GetGrain<ITipGrain>(t).GetDto()).ToList();
        await Task.WhenAll(dtoTasks);
        return dtoTasks.Select(t => t.Result).ToList();
    }

    public async Task<TipDto> NewTip()
    {
        var id = Guid.NewGuid().ToString();
        var grain = GrainFactory.GetGrain<ITipGrain>(id);

        await grain.Save();
        
        State.TipIds.Add(id);
        await WriteStateAsync();
        
        return await grain.GetDto();
    }

}