using ControlePontoAPI.Data;
using ControlePontoAPI.Models;
using ControlePontoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlePontoAPI.Repositories;

public class RegistroPontoRepository : IRegistroPontoRepository
{
    private readonly AppDbContext _context;

    public RegistroPontoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RegistroPonto>> GetAllAsync()
    {
        return await _context.RegistrosPonto.AsNoTracking().ToListAsync();
    }

    public async Task<RegistroPonto?> GetByIdAsync(int id)
    {
        return await _context.RegistrosPonto.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<RegistroPonto>> GetByFuncionarioAsync(int idFuncionario)
    {
        return await _context.RegistrosPonto
                        .Where(r => r.FuncionarioId == idFuncionario)
                        .OrderBy(r => r.DataHora)
                        .ToListAsync();
    }

    public async Task<RegistroPonto?> GetLastRegistroPontoAsync(int funcionarioId)
    {
        return await _context.RegistrosPonto
                        .Where(r => r.FuncionarioId == funcionarioId)
                        .OrderByDescending(r => r.DataHora)
                        .FirstOrDefaultAsync();
    }

    public async Task<RegistroPonto> AddAsync(RegistroPonto registroPonto)
    {
        await _context.RegistrosPonto.AddAsync(registroPonto);
        await _context.SaveChangesAsync();

        return registroPonto;
    }

    public async Task<RegistroPonto> UpdateAsync(RegistroPonto registroPonto)
    {
        _context.Entry(registroPonto).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return registroPonto;
    }

    public async Task DeleteAsync(RegistroPonto registroPonto)
    {
        _context.RegistrosPonto.Remove(registroPonto);
        await _context.SaveChangesAsync();
    }
}
