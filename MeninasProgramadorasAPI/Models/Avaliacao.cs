using System.ComponentModel.DataAnnotations;
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
    public virtual IList<Exercicio> Exercicios { get; set; }

    [NotMapped]
    public bool PresencaAbertura {
        get
        {
            return Presencas.Any(presenca => presenca.TipoDeEvento == TipoDeEvento.Abertura);
        }
    }

    /// <summary>
    /// Presença em aulas: percentual de aulas com registro de presença / total de aulas
    /// </summary>
    [NotMapped]
    public double PresencaAulas
    {
        get
        {
            int totalPresencas = Presencas.Count(presenca => presenca.TipoDeEvento == TipoDeEvento.Aula);
            return totalPresencas / (double)Turma.TotalSemanas;
        }
    }

    /// <summary>
    /// Presença em Monitorias:
    /// - Registro de presença deve ser feito por unidade de meia hora de monitoria
    /// - Presença na semana só será contada se houver ao menos 4 registros 
    /// - Percentual de presença em monitorias será total de semenas com presença / total de semanas
    /// </summary>
    [NotMapped]
    public double PresencaMonitorias
    {
        get
        {
            int totalPresencas = 0;
            for (int i = 1; i <= Turma.TotalSemanas; i++)
            {
                int presencasSemana = Presencas.Count(presenca => presenca.TipoDeEvento == TipoDeEvento.Monitoria && presenca.NumeroEvento == i);
                if (presencasSemana >= 4) totalPresencas++;
            }
            return totalPresencas / (double)Turma.TotalSemanas;
        }
    }

    [NotMapped]
    public double? NotaAvaliacaoFinal 
    { 
        get
        {
            Exercicio? avaliacaoFinal = Exercicios.FirstOrDefault(e => e.TipoDeExercicio == TipoDeExercicio.AvaliacaoFinal);

            if (avaliacaoFinal == null) return null;

            return avaliacaoFinal.Nota;
        }
    }

    [NotMapped]
    public double? NotaAvaliacaoRecuperacao
    {
        get
        {
            Exercicio? avaliacaoRecuperacao = Exercicios.FirstOrDefault(e => e.TipoDeExercicio == TipoDeExercicio.Recuperacao);

            if (avaliacaoRecuperacao == null) return null;

            return avaliacaoRecuperacao.Nota;
        }
    }


    [NotMapped]
    public double? MediaExercicios
    {
        get
        {
            IList<double> notas = new List<double>();
            for (int i = 1; i <= Turma.TotalSemanas; i++)
            {
                Exercicio? exercicio = Exercicios.FirstOrDefault(e => e.TipoDeExercicio == TipoDeExercicio.Exercicio && e.NumeroExercicio == i);

                if (exercicio != null) notas.Add(exercicio.Nota);
            }

            if(notas.Count == 0) return null;

            return notas.Average();
        }
    }

    [NotMapped]
    public bool Aprovado 
    { 
        get 
        {
            // Participar de 2hrs de monitoria por semana
            if (PresencaMonitorias < 1) return false;

            // Participar da primeira aula
            if(!PresencaAbertura) return false;

            // Ter 75% de presença nas aulas de sábado
            if (PresencaAulas < 0.75) return false;

            // Ter 75% de acerto na prova final
            if (ObterNotaFinal() < 0.75) return false;

            return true;
        }
    }

    /// <summary>
    /// Obter maior nota entre a avaliação final e a recuperação
    /// </summary>
    /// <returns>Maior notra entre avaliação final e recuperação, ou zero se ambas forem nulas</returns>
    private double ObterNotaFinal()
    {
        double? nota = 
            Nullable.Compare(NotaAvaliacaoFinal, NotaAvaliacaoRecuperacao) > 0 ? 
            NotaAvaliacaoFinal : NotaAvaliacaoRecuperacao;
        if(nota == null) return 0;
        return nota.Value;
    }
}
