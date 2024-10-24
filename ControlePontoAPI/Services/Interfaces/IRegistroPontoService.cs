using ControlePontoAPI.Models;

namespace ControlePontoAPI.Services.Interfaces;

public interface IRegistroPontoService
{
    Task<IEnumerable<RegistroPonto>> GetAllAsync();
    Task<RegistroPonto?> GetByIdAsync(int id);
    Task AddAsync(RegistroPonto registroPonto);
    Task<RegistroPonto?> UpdateAsync(RegistroPonto registroPonto);
    Task DeleteAsync(int id);
}
