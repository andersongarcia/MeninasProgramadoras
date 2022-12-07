using MeninasProgramadorasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeninasProgramadorasAPI.Data;

public class TurmaContext : DbContext
{
    public DbSet<Turma> Turmas { get; set; }

    public TurmaContext(DbContextOptions<AlunasContext> opts)
        : base(opts)
    {
    }
}
