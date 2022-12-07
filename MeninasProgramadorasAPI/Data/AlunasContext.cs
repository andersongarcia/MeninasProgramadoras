using MeninasProgramadorasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeninasProgramadorasAPI.Data;

public class AlunasContext : DbContext
{
    public DbSet<Aluna> Alunas { get; set; }

    public AlunasContext(DbContextOptions<AlunasContext> opts)
        : base(opts)
    {
    }
}