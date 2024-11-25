using ControlePontoAPI.Models;

namespace ControlePontoAPI.Repositories.Interfaces;

public interface IFuncionarioRepository
{
    IQueryable<Funcionario> GetAll();
    Task<IEnumerable<Funcionario>> GetAllAsync(IQueryable<Funcionario> query);
    Task<Funcionario?> GetByIdAsync(int id);
    Task<Funcionario?> GetByEmailAsync(string email);
    Task AddAsync(Funcionario funcionario);
    Task<Funcionario> UpdateAsync(Funcionario funcionario);
    Task DeleteAsync(Funcionario funcionario);
}
