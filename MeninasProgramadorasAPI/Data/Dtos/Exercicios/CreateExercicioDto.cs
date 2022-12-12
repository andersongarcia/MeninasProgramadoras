using MeninasProgramadorasAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MeninasProgramadorasAPI.Data.Dtos.Exercicios;

public class CreateExercicioDto
{
    [Required(ErrorMessage = "O CPF da aluna deve ser informado")]
    public string AlunaCPF { get; set; }
    [Required(ErrorMessage = "O número da turma deve ser informado")]
    public int TurmaNumero { get; set; }
    [Required(ErrorMessage = "O tipo do evento deve ser informado")]
    public TipoDeEvento TipoDeEvento { get; set; }
    public int? NumeroExercicio { get; set; }  // 1 para Exercício 1, 2 para Exercício 2, etc
    public int Total { get; set; } = 0;
    public int Resolvidos { get; set; } = 0;
}