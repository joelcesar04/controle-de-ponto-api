using ControlePontoAPI.Models;

namespace ControlePontoAPI.Repositories.Interfaces;

public interface IRegistroPontoRepository
{
    IQueryable<RegistroPonto> GetAll();
    Task<IEnumerable<RegistroPonto>> GetAllAsync(IQueryable<RegistroPonto> query);
    Task<RegistroPonto?> GetByIdAsync(int id);
    Task<IEnumerable<RegistroPonto>> GetByFuncionarioAsync(int idFuncionario);
    Task<RegistroPonto?> GetLastRegistroPontoAsync(int funcionarioId);
    Task<RegistroPonto> AddAsync(RegistroPonto registroPonto);
    Task<RegistroPonto> UpdateAsync(RegistroPonto registroPonto);
    Task DeleteAsync(RegistroPonto registroPonto);
}
