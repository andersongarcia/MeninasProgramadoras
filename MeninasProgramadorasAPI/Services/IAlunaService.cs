using MeninasProgramadorasAPI.Data.Dtos.Alunas;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Services;

public interface IAlunaService
{
    Aluna CriarAluna(CreateAlunaDto alunaDto);
    AlunaDto? ObterAlunaPorCPF(string cpf);
    AlunaDto? ObterAlunaPorNome(string? v);
    IEnumerable<AlunaDto> ObterAlunas();
    IEnumerable<AlunaDto> ObterAlunas(IEnumerable<Aluna> alunas);
    void RemoverAluna(string cpf);
    void RemoverTodasAlunas();
    void ValidaAluna(string cpf);
}