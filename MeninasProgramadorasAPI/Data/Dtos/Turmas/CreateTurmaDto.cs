using System.ComponentModel.DataAnnotations;

namespace MeninasProgramadorasAPI.Data.Dtos.Turmas;

public class CreateTurmaDto
{
    [Required]
    public int Numero { get; set; }
    public DateTime DataInicio { get; set; }
    public int TotalSemanas { get; set; }
}
