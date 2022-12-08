using AutoMapper;
using MeninasProgramadorasAPI.Data.Dtos.Turmas;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Profiles;

public class TurmaProfile : Profile
{
	public TurmaProfile()
	{
        CreateMap<CreateTurmaDto, Turma>();
        CreateMap<Turma, TurmaDto>();
    }
}
