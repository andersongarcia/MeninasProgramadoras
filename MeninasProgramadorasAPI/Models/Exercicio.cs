using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeninasProgramadorasAPI.Models;

public class Exercicio
{
    [Key]
    [Required]
    public int Id { get; set; }
    public virtual Avaliacao Avaliacao { get; set; }
    public int AvaliacaoId { get; set; }
    public TipoDeExercicio TipoDeExercicio { get; set; }
    public int? NumeroExercicio { get; set; }  // 1 para Exercício 1, 2 para Exercício 2, etc
    public int Total { get; set; } = 0;
    public int Resolvidos { get; set; } = 0;
    public virtual DateTime Registro { get; set; } = DateTime.Now;

    [NotMapped]
    public double Nota 
    { 
        get
        {
            if(Total > 0) return Resolvidos / (double)Total;
            return 0.0;
        }
    }
}
