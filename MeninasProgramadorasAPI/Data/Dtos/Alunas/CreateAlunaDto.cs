﻿using System.ComponentModel.DataAnnotations;

namespace MeninasProgramadorasAPI.Data.Dtos.Alunas;

public class CreateAlunaDto
{
    [Required(ErrorMessage = "O CPF da aluna é obrigatório")]
    [StringLength(11, ErrorMessage = "O tamanho do CPF não pode exceder 11 caracteres")]
    public string CPF { get; set; }
    public string? PrimeiroNome { get; set; }
    [Required(ErrorMessage = "O nome completo da aluna é obrigatório")]
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public string BeecrowdId { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;
}
