using Dto.Tips;

namespace Domain.Tips;

public interface ITipGrain: IGrainWithStringKey
{
    Task Save();
    Task<TipDto> GetDto();
    Task<TipDto> UpdateTip(TipUpdateDto dto);
}