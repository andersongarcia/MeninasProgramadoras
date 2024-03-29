﻿using System.ComponentModel.DataAnnotations;

namespace MeninasProgramadorasAPI.Models;

public class RegistroPresenca
{
    [Key]
    [Required]
    public int Id { get; set; }
    public virtual Avaliacao Avaliacao { get; set; }
    public int AvaliacaoId { get; set; }
    public TipoDeEvento TipoDeEvento { get; set; }
    public int? NumeroEvento { get; set; }  // 1 para Aula 1 ou Semana 1, 2 para Aula 2 ou Semana 2, etc
    public virtual DateTime Registro { get; set; } = DateTime.Now;
}