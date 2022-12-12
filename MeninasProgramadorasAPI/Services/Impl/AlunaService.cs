using AutoMapper;
using MeninasProgramadorasAPI.Data;
using MeninasProgramadorasAPI.Data.Dtos.Alunas;
using MeninasProgramadorasAPI.Exceptions;
using MeninasProgramadorasAPI.Models;
using Microsoft.EntityFrameworkCore;

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

    public AlunaDto? ObterAlunaPorNome(string? nome)
    {
        Aluna? aluna = _context.Alunas.FirstOrDefault(aluna => aluna.NomeCompleto.Trim().ToLower() == nome.Trim().ToLower());
        if (aluna == null) return null;

        return _mapper.Map<AlunaDto>(aluna);
    }

    public IEnumerable<AlunaDto> ObterAlunas()
    {
        return ObterAlunas(_context.Alunas);
    }

    public IEnumerable<AlunaDto> ObterAlunas(IEnumerable<Aluna> alunas)
    {
        return _mapper.Map<List<AlunaDto>>(alunas);
    }

    public void RemoverTodasAlunas()
    {
        _context.Database.ExecuteSqlRaw("SET FOREIGN_KEY_CHECKS = 0;TRUNCATE TABLE alunas;");
    }

    public void ValidaAluna(string cpf)
    {
        Aluna? aluna = _context.Alunas.FirstOrDefault(aluna => aluna.CPF == cpf);
        if (aluna == null) throw new AlunaNotFoundException();
    }
}
