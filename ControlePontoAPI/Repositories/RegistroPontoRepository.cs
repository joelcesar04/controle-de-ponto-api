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

    public async Task AddAsync(RegistroPonto registroPonto)
    {
        await _context.RegistrosPonto.AddAsync(registroPonto);
        await _context.SaveChangesAsync();
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
