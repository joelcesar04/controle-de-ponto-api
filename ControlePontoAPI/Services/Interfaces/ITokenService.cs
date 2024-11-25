using ControlePontoAPI.Models;

namespace ControlePontoAPI.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(Funcionario funcionario);
}
