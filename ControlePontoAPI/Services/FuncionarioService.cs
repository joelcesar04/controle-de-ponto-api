using ControlePontoAPI.Models;
using ControlePontoAPI.Repositories.Interfaces;
using ControlePontoAPI.Services.Interfaces;

namespace ControlePontoAPI.Services;

public class FuncionarioService : IFuncionarioService
{
    private readonly IFuncionarioRepository _repository;

    public FuncionarioService(IFuncionarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Funcionario>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Funcionario?> GetByIdAsync(int id)
    {
        var funcionario = await _repository.GetByIdAsync(id);

        if (funcionario == null)
            return null;

        return funcionario;
    }

    public async Task<Funcionario> AddAsync(Funcionario funcionario)
    {
        if (funcionario.DataAdmissao == default)
            funcionario.DataAdmissao = DateTime.Now;

        await _repository.AddAsync(funcionario);

        return funcionario;
    }

    public async Task<Funcionario?> UpdateAsync(int id, Funcionario funcionario)
    {
        var existsFuncionario = await _repository.GetByIdAsync(id);

        if (existsFuncionario == null)
            return null;

        existsFuncionario.Nome = funcionario.Nome;
        existsFuncionario.Email = funcionario.Email;
        existsFuncionario.Cargo = funcionario.Cargo;
        existsFuncionario.Ativo = funcionario.Ativo;

        await _repository.UpdateAsync(existsFuncionario);

        return existsFuncionario;
    }

    public async Task<Funcionario?> DeleteAsync(int id)
    {
        var funcionario = await _repository.GetByIdAsync(id);

        if (funcionario == null)
            return null;

        await _repository.DeleteAsync(funcionario);
        return funcionario;
    }
}
