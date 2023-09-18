using Domain.Character;
using Dto.Character;
using Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace MotherOfLearningGameWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class CharacterController : Controller
{
    private readonly ILogger<CharacterController> _logger;
    private readonly IGrainFactory _factory;

    public CharacterController(ILogger<CharacterController> logger, IGrainFactory factory)
    {
        _logger = logger;
        _factory = factory;
    }

    [HttpGet]
    public async Task<List<CharacterDto>> Get()
    {
        return await _factory.GetGrain<ICharacterAggregateGrain>(0).GetCharacters();
    }
    
    [HttpGet("getByUser/{userId}")]
    public async Task<List<CharacterDto>> Get(string userId)
    {
        return await _factory.GetGrain<ICharacterAggregateGrain>(0).GetCharacters(userId);
    }

    [HttpPut]
    public async Task<CharacterDto> CreateCharacter(CharacterCreateDto dto)
    {
        return await _factory.GetGrain<ICharacterAggregateGrain>(0).CreateCharacter(dto);
    }

    
    
}