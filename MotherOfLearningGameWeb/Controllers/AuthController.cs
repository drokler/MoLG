using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;
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
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AuthDto authDto)
    {
        var user = _factory.GetGrain<IUserGrain>(authDto.Login);
        var isValidCredential = await user.CheckCredentials( GetSha(authDto.Password, _key));
        if (isValidCredential)
        {
            var roles = await user.GetRoles();
            return Json(JwtTokenValidator.GetToken(_key, authDto.Login, roles));
        }

        return Unauthorized();
    }

    private static string GetSha(string password, string key)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(key + password));
        return Convert.ToBase64String(bytes);
    }

}