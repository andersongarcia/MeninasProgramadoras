using MeninasProgramadorasAPI.Data.Dtos.Turmas;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Services;

public interface ITurmaService
{
    Turma CriarTurma(CreateTurmaDto turmaDto);
    TurmaDto? ObterTurmaPorNumero(int numero);
    IEnumerable<TurmaDto> ObterTurmas();
    void RemoverTurma(int numero);
}
