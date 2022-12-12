using MeninasProgramadorasAPI.Data.Dtos.Avaliacoes;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Services;

public interface IAvaliacaoService
{
    Avaliacao CriarAvaliacao(CreateAvaliacaoDto avaliacaoDto);
    Avaliacao CriarAvaliacao(string alunaCPF, int turmaNumero);
    AvaliacaoDto? ObterAvaliacaoPorId(int id);
    IEnumerable<AvaliacaoDto> ObterAvaliacoes();
}
