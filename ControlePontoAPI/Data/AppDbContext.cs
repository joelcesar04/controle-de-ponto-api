using ControlePontoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlePontoAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<RegistroPonto> RegistrosPonto { get; set; }
}
