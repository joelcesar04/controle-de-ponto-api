using ControlePontoAPI.Models;
using ControlePontoAPI.Queries;
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

    public async Task<IEnumerable<Funcionario>> GetAllAsync(FuncionarioQueryParams funcionarioQueryParams)
    {
        var query = _repository.GetAll();

        if (!string.IsNullOrEmpty(funcionarioQueryParams.Nome))
            query = query.Where(q => q.Nome.Contains(funcionarioQueryParams.Nome));

        if (!string.IsNullOrEmpty(funcionarioQueryParams.Cargo))
            query = query.Where(q => q.Cargo.Contains(funcionarioQueryParams.Cargo));

        // Essa abordagem tem o mesmo efeito e é mais concisa. 
        if (funcionarioQueryParams.Ativo.HasValue)
        {
            query = query.Where(q => q.Ativo == funcionarioQueryParams.Ativo.Value);
        }

        // Movida logica para classe
        funcionarioQueryParams.ApplyDefaults();

        var filters = query
            .OrderBy(q => q.Nome)
            .Skip((funcionarioQueryParams.PageNumber - 1) * funcionarioQueryParams.PageSize)
            .Take(funcionarioQueryParams.PageSize);

        var registros = await _repository.GetAllAsync(filters);

        return registros;
    }

    // Se voce faz uma comparação se é nulo e devolve nulo pode devolver diretamente.
    public async Task<Funcionario?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    // Se voce faz uma comparação se é nulo e devolve nulo pode devolver diretamente.
    public async Task<Funcionario?> GetByEmailAsync(string email) => await _repository.GetByEmailAsync(email);
    

    public async Task<Funcionario> AddAsync(Funcionario funcionario)
    {
        if (funcionario.DataAdmissao == default)
            funcionario.DataAdmissao = DateTime.Now;

        funcionario.Ativo = true;
        funcionario.Senha = BCrypt.Net.BCrypt.HashPassword(funcionario.Senha);

        await _repository.AddAsync(funcionario);

        return funcionario;
    }

    public async Task<Funcionario?> UpdateAsync(int id, Funcionario funcionario)
    {
        var existsFuncionario = await _repository.GetByIdAsync(id);

        if (existsFuncionario == null)
            return null;

        existsFuncionario.Nome = funcionario.Nome;
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

    public async Task<Funcionario?> ValidateCredentialsAsync(string email, string senha)
    {
        var funcionario = await _repository.GetByEmailAsync(email);
        
        if (funcionario == null || !VerifyPasswordHash(senha, funcionario.Senha))
            return null;

        return funcionario;
    }

    private bool VerifyPasswordHash(string senha, string senhaHash)
    {
        return BCrypt.Net.BCrypt.Verify(senha, senhaHash);
    }

}
