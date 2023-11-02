using System.Security.Cryptography;
using System.Text;
using Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotherOfLearningGameWeb.Dto;

namespace MotherOfLearningGameWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly IGrainFactory _factory;
    private readonly string _key;

    public AuthController(ILogger<AuthController> logger, IGrainFactory factory, IConfiguration configuration)
    {
        _logger = logger;
        _factory = factory;
        _key = configuration.GetValue<string>("JwtKey")!;
    }

    
    [HttpPost("setup-admin")]
    public async Task<AuthResult> SetupAdmin([FromBody] AuthDto authDto)
    {
        var aggregate = _factory.GetGrain<IUserAggregateGrain>(0);
        if (await aggregate.IsSetUp())
        {
            throw new InvalidOperationException("Admin has already set up");
        }
        var admin = await aggregate.CreateAdmin(authDto.Login, GetSha(authDto.Password, _key));
        return new AuthResult { Token = JwtTokenValidator.GetToken(_key, authDto.Login, admin.Roles) };
    }
    
    [HttpPost]
    public async Task<AuthResult> Post([FromBody] AuthDto authDto)
    {
        var user = _factory.GetGrain<IUserGrain>(authDto.Login);
        var isValidCredential = await user.CheckCredentials(GetSha(authDto.Password, _key));
        if (isValidCredential)
        {
            var roles = await user.GetRoles();
            return new AuthResult { Token = JwtTokenValidator.GetToken(_key, authDto.Login, roles) };
        }

        return new AuthResult();
    }
    
    [HttpPut]
    public async Task<AuthResult> Register([FromBody] AuthDto dto)
    {
        var user = await _factory.GetGrain<IUserAggregateGrain>(0).CreateUser(dto.Login, GetSha(dto.Password, _key));
        return new AuthResult { Token = JwtTokenValidator.GetToken(_key, dto.Login, user.Roles) };
    }

    private static string GetSha(string password, string key)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(key + password));
        return Convert.ToBase64String(bytes);
    }
}