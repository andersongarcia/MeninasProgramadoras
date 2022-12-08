using AutoMapper;
using MeninasProgramadorasAPI.Data.Dtos.Avaliacoes;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Profiles;

public class AvaliacaoProfile : Profile
{
    public AvaliacaoProfile()
    {
        CreateMap<CreateAvaliacaoDto, Avaliacao>();
        CreateMap<Avaliacao, AvaliacaoDto>()
            .ForMember(avaliacao => avaliacao.Presencas, opts => opts
            .MapFrom(avaliacao => avaliacao.Presencas.Select
            (p => new { p.Id, p.TipoDeEvento, p.NumeroEvento })))
            .ForMember(avaliacao => avaliacao.Turma, opts => opts
            .MapFrom(avaliacao => new { avaliacao.Turma.Numero, avaliacao.Turma.TotalSemanas }));
    }
}
