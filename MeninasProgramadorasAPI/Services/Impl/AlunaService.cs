using AutoMapper;
using MeninasProgramadorasAPI.Data;
using MeninasProgramadorasAPI.Data.Dtos.Alunas;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Services.Impl;

public class AlunaService : IAlunaService
{
    private AppDbContext _context;
    private IMapper _mapper;

    public AlunaService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Aluna CriarAluna(CreateAlunaDto alunaDto)
    {
        Aluna aluna = _mapper.Map<Aluna>(alunaDto);
        _context.Alunas.Add(aluna);
        _context.SaveChanges();
        return aluna;
    }

    public AlunaDto? ObterAlunaPorCPF(string cpf)
    {
        Aluna? aluna = _context.Alunas.FirstOrDefault(aluna => aluna.CPF == cpf);
        if (aluna == null) return null;

        return _mapper.Map<AlunaDto>(aluna);
    }

    public IEnumerable<AlunaDto> ObterAlunas()
    {
        return _mapper.Map<List<AlunaDto>>(_context.Alunas);
    }
}
