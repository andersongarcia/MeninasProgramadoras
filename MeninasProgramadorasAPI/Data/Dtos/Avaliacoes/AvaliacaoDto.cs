using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Data.Dtos.Avaliacoes;

public class AvaliacaoDto
{
    public int Id { get; set; }
    public virtual Aluna Aluna { get; set; }
    public virtual object Turma { get; set; }
    public virtual object Presencas { get; set; }
    public bool PresencaAbertura { get; set; }
    public double PresencaAulas { get; set; }
    public double PresencaMonitorias { get; set; }
    public virtual double? NotaAvaliacaoFinal { get; set; }
    public virtual double? NotaAvaliacaoRecuperacao { get; set; }
    public virtual double? MediaExercicios { get; set; }
    public bool Aprovado { get; set; }
}
