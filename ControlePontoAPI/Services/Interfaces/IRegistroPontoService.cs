using ControlePontoAPI.Models;
using ControlePontoAPI.Queries;

namespace ControlePontoAPI.Services.Interfaces;

public interface IRegistroPontoService
{
    Task<IEnumerable<RegistroPonto>> GetAllAsync(RegistroPontoQueryParams registroPontoQueryParams);
    Task<RegistroPonto?> GetByIdAsync(int id);
    Task<IEnumerable<RegistroPonto>> GetByFuncionarioAsync(int idFuncionario);
    Task<RegistroPonto> AddAsync(RegistroPonto registroPonto);
    Task<RegistroPonto?> UpdateAsync(int id, RegistroPonto registroPonto);
    Task<RegistroPonto?> DeleteAsync(int id);
}
