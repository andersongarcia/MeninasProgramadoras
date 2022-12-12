using System.ComponentModel.DataAnnotations;

namespace MeninasProgramadorasAPI.Models;

public class Exercicio
{
    [Key]
    [Required]
    public int Id { get; set; }
    public Avaliacao Avaliacao { get; set; }
    public TipoDeEvento TipoDeExercicio { get; set; }
    public int? NumeroExercicio { get; set; }  // 1 para Exercício 1, 2 para Exercício 2, etc
    public int Total { get; set; } = 0;
    public int Resolvidos { get; set; } = 0;
}
