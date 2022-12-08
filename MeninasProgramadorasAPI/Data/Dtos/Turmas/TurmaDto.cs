using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Data.Dtos.Turmas;

public class TurmaDto
{
    public int Numero { get; set; }
    public virtual IList<Avaliacao> Avaliacoes { get; set; }
    public int TotalSemanas { get; set; }
}
