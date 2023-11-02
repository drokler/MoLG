using Domain.Tips;
using Dto.Tips;
using Microsoft.AspNetCore.Mvc;

namespace MotherOfLearningGameWeb.Controllers;

public class TipsController  : Controller
{
    private readonly ILogger<TipsController> _logger;
    private readonly IGrainFactory _factory;

    public TipsController(ILogger<TipsController> logger, IGrainFactory factory)
    {
        _logger = logger;
        _factory = factory;
    }

    [HttpGet]
    public async Task<List<TipDto>> TipsGet([FromQuery] string objectId)
    {
        var grain = _factory.GetGrain<ITipAggregationGrain>(objectId);
        return await grain.GetTips();
    }
    
    [HttpPut]
    public async Task<TipDto> CreateTip([FromQuery] string objectId)
    {
        var grain = _factory.GetGrain<ITipAggregationGrain>(objectId);
        return await grain.NewTip();
    }
    
    [HttpPost]
    public async Task<TipDto> UpdateTip([FromBody] TipUpdateDto dto)
    {
        var grain = _factory.GetGrain<ITipGrain>(dto.Id);
        return await grain.UpdateTip(dto);
    }
}