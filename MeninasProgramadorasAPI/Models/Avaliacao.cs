﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeninasProgramadorasAPI.Models;

public class Avaliacao
{
    [Key]
    [Required]
    public int Id { get; set; }
    public virtual Aluna Aluna { get; set; }
    public string AlunaCPF { get; set; }
    public virtual Turma Turma { get; set; }
    public int TurmaNumero { get; set; }
    public virtual IList<RegistroPresenca> Presencas { get; set; }

    [NotMapped]
    public bool PresenteAbertura {
        get
        {
            return Presencas.Any(presenca => presenca.TipoDeEvento == TipoDeEvento.Abertura);
        }
    }


    [NotMapped]
    public double PresencaAulas
    {
        get
        {
            int totalPresencas = Presencas.Count(presenca => presenca.TipoDeEvento == TipoDeEvento.Aula);
            return (double)totalPresencas / (double)Turma.TotalSemanas;
        }
    }

    [NotMapped]
    public double PresencaMonitorias
    {
        get
        {
            int semanasCumpridas = 0;

            for (int i = 1; i <= Turma.TotalSemanas; i++)
            {
                if(Presencas.Count(presenca => presenca.TipoDeEvento == TipoDeEvento.Monitoria && presenca.NumeroEvento == i) > 4)
                    semanasCumpridas++;
            }
            return (double)semanasCumpridas / (double)Turma.TotalSemanas;
        }
    }
}
