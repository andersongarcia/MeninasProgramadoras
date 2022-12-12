using MeninasProgramadorasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeninasProgramadorasAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<Aluna> Alunas { get; set; }
    public DbSet<Turma> Turmas { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<RegistroPresenca> Presencas { get; set; }
    public DbSet<Exercicio> Exercicios { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> opts)
        : base(opts)
    {        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Avaliacao>()
                .HasOne(avaliacao => avaliacao.Turma)
                .WithMany(turma => turma.Avaliacoes)
                .HasForeignKey(avaliacao => avaliacao.TurmaNumero);

        builder.Entity<RegistroPresenca>()
            .HasOne(presenca => presenca.Avaliacao)
            .WithMany(avaliacao => avaliacao.Presencas)
            .HasForeignKey(presenca => presenca.AvaliacaoId);

        builder.Entity<Exercicio>()
            .HasOne(exercicio => exercicio.Avaliacao)
            .WithMany(avaliacao => avaliacao.Exercicios)
            .HasForeignKey(presenca => presenca.AvaliacaoId);
    }
}