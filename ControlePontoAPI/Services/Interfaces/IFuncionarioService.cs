using ControlePontoAPI.Models;

namespace ControlePontoAPI.Services.Interfaces;

public interface IFuncionarioService
{
    Task<IEnumerable<Funcionario>> GetAllAsync();
    Task<Funcionario?> GetByIdAsync(int id);
    Task<Funcionario> AddAsync(Funcionario funcionario);
    Task<Funcionario?> UpdateAsync(int id, Funcionario funcionario);
    Task<Funcionario?> DeleteAsync(int id);
}
