namespace MeninasProgramadorasAPI.Models;

public class Avaliacao
{
    public int Id { get; set; }
    public Aluna Aluna { get; set; }
    public Turma Turma { get; set; }
    public RegistroPresenca PresencaAbertura { get; set; }
    public IList<RegistroPresenca> PresencasAulas { get; set; }
    public IList<RegistroPresenca> PresencasMonitorias { get; set; }


}
