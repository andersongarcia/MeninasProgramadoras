namespace MeninasProgramadorasAPI.Models;

public class RegistroPresenca
{
    public int Id { get; set; }
    public Aluna Aluna { get; set; }
    public Turma Turma { get; set; }
    public TipoDeEvento TipoDeEvento { get; set; }
    public int NumeroEvento { get; set; }  // 1 para Aula 1 ou Semana 1, 2 para Aula 2 ou Semana 2, etc
    public DateTime Registro { get; set; } = DateTime.Now;
}