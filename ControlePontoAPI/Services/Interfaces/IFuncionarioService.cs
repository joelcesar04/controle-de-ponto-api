﻿using ControlePontoAPI.Models;
using ControlePontoAPI.Queries;

namespace ControlePontoAPI.Services.Interfaces;

public interface IFuncionarioService
{
    Task<IEnumerable<Funcionario>> GetAllAsync(FuncionarioQueryParams funcionarioQueryParams);
    Task<Funcionario?> GetByIdAsync(int id);
    Task<Funcionario?> GetByEmailAsync(string email);
    Task<Funcionario> AddAsync(Funcionario funcionario);
    Task<Funcionario?> UpdateAsync(int id, Funcionario funcionario);
    Task<Funcionario?> DeleteAsync(int id);
    Task<Funcionario?> ValidateCredentialsAsync(string email, string senha);
}
