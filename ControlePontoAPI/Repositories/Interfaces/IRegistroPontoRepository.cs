﻿using ControlePontoAPI.Models;

namespace ControlePontoAPI.Repositories.Interfaces;

public interface IRegistroPontoRepository
{
    Task<IEnumerable<RegistroPonto>> GetAllAsync();
    Task<RegistroPonto?> GetByIdAsync(int id);
    Task<IEnumerable<RegistroPonto>> GetByFuncionarioAsync(int idFuncionario);
    Task<RegistroPonto?> GetLastRegistroPontoAsync(int funcionarioId);
    Task<RegistroPonto> AddAsync(RegistroPonto registroPonto);
    Task<RegistroPonto> UpdateAsync(RegistroPonto registroPonto);
    Task DeleteAsync(RegistroPonto registroPonto);
}
