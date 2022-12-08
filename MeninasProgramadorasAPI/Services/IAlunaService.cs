using MeninasProgramadorasAPI.Data.Dtos.Alunas;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Services;

public interface IAlunaService
{
    Aluna CriarAluna(CreateAlunaDto alunaDto);
    AlunaDto? ObterAlunaPorCPF(string cpf);
    IEnumerable<AlunaDto> ObterAlunas();
}