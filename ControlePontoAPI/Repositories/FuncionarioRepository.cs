using ControlePontoAPI.Data;
using ControlePontoAPI.Models;
using ControlePontoAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlePontoAPI.Repositories;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly AppDbContext _context;
    public FuncionarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Funcionario>> GetAllAsync()
    {
        return await _context.Funcionarios.AsNoTracking().ToListAsync();
    }

    public async Task<Funcionario?> GetByIdAsync(int id)
    {
        return await _context.Funcionarios.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task AddAsync(Funcionario funcionario)
    {
        await _context.Funcionarios.AddAsync(funcionario);
        await _context.SaveChangesAsync();
    }

    public async Task<Funcionario> UpdateAsync(Funcionario funcionario)
    {
        _context.Entry(funcionario).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return funcionario;
    }

    public async Task DeleteAsync(Funcionario funcionario)
    {
        _context.Funcionarios.Remove(funcionario);
        await _context.SaveChangesAsync();
    }
}
