using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MotherOfLearningGameWeb;

public class JwtTokenValidator : ISecurityTokenValidator
{
    private readonly string _key;
    public bool CanReadToken(string securityToken) => true;

    public JwtTokenValidator(string key)
    {
        _key = key;
    }

    public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters,
        out SecurityToken validatedToken)
    {
        var handler = new JwtSecurityTokenHandler();
        var tokenValidationParameters = TokenValidationParameters(_key);
        var claimsPrincipal = handler.ValidateToken(securityToken, tokenValidationParameters, out validatedToken);
        return claimsPrincipal;
    }

    public static string GetToken(string key, string login, List<string> roles)
    {
        var claims = roles.Select(t => new Claim(ClaimTypes.Role, t)).ToList();
        claims.Add(new(ClaimTypes.Name, login));
        claims.Add(new(ClaimTypes.Sid, login));

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public static TokenValidationParameters TokenValidationParameters(string key)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateActor = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        };
        return tokenValidationParameters;
    }

    public bool CanValidateToken { get; } = true;
    public int MaximumTokenSizeInBytes { get; set; } = int.MaxValue;
}