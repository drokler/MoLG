using Domain.Npc;
using Dto.Npc;
using Microsoft.AspNetCore.Mvc;

namespace MotherOfLearningGameWeb.Controllers;

public class NpcController  : Controller
{
    private readonly ILogger<NpcController> _logger;
    private readonly IGrainFactory _factory;

    public NpcController(ILogger<NpcController> logger, IGrainFactory factory)
    {
        _logger = logger;
        _factory = factory;
    }
    [HttpGet]
    public async Task<List<NpcDto>> Get([FromQuery] string objectId)
    {
        var grain = _factory.GetGrain<INpcAggregationGrain>(0);
        return await grain.GetNpcs();
    }

    [HttpPut]
    public async Task<NpcDto> CreateNpc()
    {
        return null;
    }
    
    [HttpPost]
    public async Task<NpcDto> UpdateNpc([FromBody] NpcUpdateDto dto)
    {
        return null;
    }
    
    
    
}