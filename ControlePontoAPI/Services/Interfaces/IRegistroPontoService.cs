using ControlePontoAPI.Models;

namespace ControlePontoAPI.Services.Interfaces;

public interface IRegistroPontoService
{
    Task<IEnumerable<RegistroPonto>> GetAllAsync();
    Task<RegistroPonto?> GetByIdAsync(int id);
    Task<RegistroPonto> AddAsync(RegistroPonto registroPonto);
    Task<RegistroPonto?> UpdateAsync(int id, RegistroPonto registroPonto);
    Task<RegistroPonto?> DeleteAsync(int id);
}
