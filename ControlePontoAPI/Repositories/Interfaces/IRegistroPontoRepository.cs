using ControlePontoAPI.Models;

namespace ControlePontoAPI.Repositories.Interfaces;

public interface IRegistroPontoRepository
{
    Task<IEnumerable<RegistroPonto>> GetAllAsync();
    Task<RegistroPonto?> GetByIdAsync(int id);
    Task<RegistroPonto?> GetLastRegistroPonto(int funcionarioId);
    Task<RegistroPonto> AddAsync(RegistroPonto registroPonto);
    Task<RegistroPonto> UpdateAsync(RegistroPonto registroPonto);
    Task DeleteAsync(RegistroPonto registroPonto);
}
