using Domain.Company;
using Domain.User;
using Dto.Company;
using Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace MotherOfLearningGameWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IGrainFactory _factory;

    public UserController(ILogger<UserController> logger, IGrainFactory factory)
    {
        _logger = logger;
        _factory = factory;
    }

    [HttpGet]
    public async Task<List<UserDto>> Get()
    {
        return await _factory.GetGrain<IUserAggregateGrain>(0).GetUsers();
    }

    [HttpPut]
    public async Task<UserDto> CreateUser()
    {
        return await _factory.GetGrain<IUserAggregateGrain>(0).CreateUser();
    }

    
    
}