using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Data.Dtos.Presencas;

public class ImportRegistroPresencaDto
{
    public IFormFile File { get; set; }
    public int TurmaNumero { get; set; }
    public TipoDeEvento TipoDeEvento { get; set; }
}
