using MeninasProgramadorasAPI.Data.Dtos.Avaliacoes;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Services;

public interface IAvaliacaoService
{
    Avaliacao CriarAvaliacao(CreateAvaliacaoDto avaliacaoDto);
    AvaliacaoDto? ObterAvaliacaoPorId(int id);
    IEnumerable<AvaliacaoDto> ObterAvaliacoes();
}
