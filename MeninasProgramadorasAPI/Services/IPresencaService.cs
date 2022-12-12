using MeninasProgramadorasAPI.Data.Dtos.Presencas;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Services;

public interface IPresencaService
{
    RegistroPresenca RegistrarPresenca(CreateRegistroPresencaDto presencaDto);
    RegistroPresencaDto? ObterPresencasPorId(int id);
    IEnumerable<RegistroPresencaDto> ObterPresencas();
    IEnumerable<RegistroPresencaDto> ObterPresencas(IEnumerable<RegistroPresenca> presencasCadastradas);
}