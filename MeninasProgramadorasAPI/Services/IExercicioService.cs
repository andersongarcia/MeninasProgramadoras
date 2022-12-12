using MeninasProgramadorasAPI.Data.Dtos.Exercicios;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Services;

public interface IExercicioService
{
    ExercicioDto? ObterExercicioPorId(int id);
    IEnumerable<ExercicioDto> ObterExercicios();
    IEnumerable<ExercicioDto> ObterExercicios(IEnumerable<Exercicio> exercicios);
    Exercicio RegistrarExercicio(CreateExercicioDto exercicioDto);
    void RemoverExercicio(int id);
}
