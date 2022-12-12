using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Data.Dtos.Presencas;

public class ImportExercicioDto
{
    public IFormFile File { get; set; }
    public int TurmaNumero { get; set; }
    public TipoDeExercicio TipoDeExercicio { get; set; }
}
