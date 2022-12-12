using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Data.Dtos.Avaliacoes;

public class AvaliacaoDto
{
    public int Id { get; set; }
    public virtual Aluna Aluna { get; set; }
    public virtual object Turma { get; set; }
    public virtual object Presencas { get; set; }
    public bool PresenteAbertura { get; set; }
    public double PresencaAulas { get; set; }
    public double PresencaMonitorias { get; set; }
}
