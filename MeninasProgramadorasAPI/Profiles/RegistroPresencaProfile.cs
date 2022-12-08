using AutoMapper;
using MeninasProgramadorasAPI.Data.Dtos.Presencas;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Profiles;

public class RegistroPresencaProfile : Profile
{
	public RegistroPresencaProfile()
	{
        CreateMap<CreateRegistroPresencaDto, RegistroPresenca>();
        CreateMap<RegistroPresenca, RegistroPresencaDto>()
            .ForMember(presenca => presenca.Avaliacao, opts => opts
            .MapFrom(presenca => new { presenca.Avaliacao.AlunaCPF, presenca.Avaliacao.TurmaNumero }));
    }
}
