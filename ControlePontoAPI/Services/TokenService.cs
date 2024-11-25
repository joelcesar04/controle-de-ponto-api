using ControlePontoAPI.Models;
using ControlePontoAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControlePontoAPI.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Funcionario funcionario)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));
        var issuer = _configuration["Jwt:Issuer"];
        var Audience = _configuration["Jwt:Audience"];

        var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: Audience,
            claims:
            [
                new Claim(ClaimTypes.Name, funcionario.Nome),
                new Claim(ClaimTypes.Role, funcionario.Role),
                new Claim(ClaimTypes.NameIdentifier, funcionario.Id.ToString()),
                new Claim(ClaimTypes.Email, funcionario.Email),
            ],
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}
