using MeninasProgramadorasAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MeninasProgramadorasAPI.Data.Dtos.Presencas;

public class CreateRegistroPresencaDto
{
    [Required(ErrorMessage = "O CPF da aluna deve ser informado")]
    public string AlunaCPF { get; set; }
    [Required(ErrorMessage = "O número da turma deve ser informado")]
    public int TurmaNumero { get; set; }
    [Required(ErrorMessage = "O tipo do evento deve ser informado")]
    public TipoDeEvento TipoDeEvento { get; set; }
    public int? NumeroEvento { get; set; }  // 1 para Aula 1 ou Semana 1, 2 para Aula 2 ou Semana 2, etc
}
