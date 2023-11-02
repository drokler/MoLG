using Dto.Tips;

namespace Domain.Tips;

public interface ITipAggregationGrain: IGrainWithStringKey
{
    Task<List<TipDto>> GetTips();
    Task<TipDto> NewTip();

}