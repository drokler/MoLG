using Domain.Tips;
using Dto.Tips;
using Orleans.Providers;

namespace Grains.Tips;

[StorageProvider]
public class TipGrain: Grain<TipState>, ITipGrain

{
    public async Task Save()
    {
        await WriteStateAsync();
    }

    public Task<TipDto> GetDto()
    {
        return Task.FromResult(new TipDto
        {
            Id = this.GetPrimaryKeyString(),
            Body = State.Body,
            TipStatement = State.TipStatement
        });
    }

    public async Task<TipDto> UpdateTip(TipUpdateDto dto)
    {
        State.Body = dto.Body;
        State.TipStatement = dto.TipStatement;
        await WriteStateAsync();
        return dto;
    }
}