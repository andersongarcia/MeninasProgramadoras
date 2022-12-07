using System.ComponentModel.DataAnnotations;

namespace MeninasProgramadorasAPI.Models;

public class Turma
{
    [Key]
    [Required]
    public int Numero { get; set; }
    public DateTime DataInicio { get; set; }
    public IList<Avaliacao> Avaliacoes { get; set; }
    public int TotalSemanas { get; set; }
}
