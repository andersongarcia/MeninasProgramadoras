using AutoMapper;
using MeninasProgramadorasAPI.Data.Dtos.Exercicios;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Profiles;

public class ExercicioProfile : Profile
{
	public ExercicioProfile()
	{
        CreateMap<CreateExercicioDto, Exercicio>();
        CreateMap<Exercicio, ExercicioDto>();
    }
}
