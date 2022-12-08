using AutoMapper;
using MeninasProgramadorasAPI.Data.Dtos.Alunas;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Profiles;

public class AlunaProfile : Profile
{
    public AlunaProfile()
    {
        CreateMap<CreateAlunaDto, Aluna>();
        //CreateMap<UpdateAlunaDto, Aluna>();
        //CreateMap<Aluna, UpdateAlunaDto>();
        CreateMap<Aluna, AlunaDto>();
    }
}
