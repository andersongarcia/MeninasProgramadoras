using System.ComponentModel.DataAnnotations;

namespace MeninasProgramadorasAPI.Models;

public class Aluna
{
    [Key]
    [Required]
    [MaxLength(15, ErrorMessage = "O tamanho do CPF não pode exceder 11 caracteres")]
    public string CPF { get; set; }
    [Required(ErrorMessage = "O nome da aluna é obrigatório")]
    public string PrimeiroNome { get; set; }
    [Required(ErrorMessage = "O nome completo da aluna é obrigatório")]
    public string NomeCompleto { get; set; }
    public string? Email { get; set; }
    public string? BeecrowdId { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;

}
