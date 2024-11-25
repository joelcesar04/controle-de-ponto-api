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

    public IQueryable<Funcionario> GetAll()
    {
        return _context.Funcionarios.AsNoTracking().AsQueryable();
    }

    public async Task<IEnumerable<Funcionario>> GetAllAsync(IQueryable<Funcionario> query)
    {
        return await query.ToListAsync();
    }

    public async Task<Funcionario?> GetByIdAsync(int id)
    {
        return await _context.Funcionarios.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Funcionario?> GetByEmailAsync(string email)
    {
        return await _context.Funcionarios.AsNoTracking().FirstOrDefaultAsync(f => f.Email == email);
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
