using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Data.Dtos.Presencas;

public class ImportExercicioDto
{
    public IFormFile File { get; set; }
    public int TurmaNumero { get; set; }
    public TipoDeExercicio TipoDeExercicio { get; set; }
    public int? NumeroExercicio { get; set; }  // 1 para Exercício 1, 2 para Exercício 2, etc
}
