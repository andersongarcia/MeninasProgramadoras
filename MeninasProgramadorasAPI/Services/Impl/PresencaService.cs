using AutoMapper;
using MeninasProgramadorasAPI.Data;
using MeninasProgramadorasAPI.Data.Dtos.Exercicios;
using MeninasProgramadorasAPI.Data.Dtos.Presencas;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Services.Impl;

public class PresencaService : IPresencaService
{
    private AppDbContext _context;
    private IMapper _mapper;
    private IAvaliacaoService _avaliacaoService;
    private IAlunaService _alunaService;

    public PresencaService(AppDbContext context, IMapper mapper, IAvaliacaoService avaliacaoService, IAlunaService alunaService)
    {
        _context = context;
        _mapper = mapper;
        _avaliacaoService = avaliacaoService;
        _alunaService = alunaService;
    }

    public IEnumerable<RegistroPresencaDto> ObterPresencas()
    {
        return ObterPresencas(_context.Presencas);
    }

    public IEnumerable<RegistroPresencaDto> ObterPresencas(IEnumerable<RegistroPresenca> presencas)
    {
        return _mapper.Map<List<RegistroPresencaDto>>(presencas);
    }

    public RegistroPresencaDto? ObterPresencasPorId(int id)
    {
        RegistroPresenca? presenca = _context.Presencas.FirstOrDefault(presenca => presenca.Id == id);
        if (presenca == null) return null;

        return _mapper.Map<RegistroPresencaDto>(presenca);
    }

    public RegistroPresenca RegistrarPresenca(CreateRegistroPresencaDto presencaDto)
    {
        _alunaService.ValidaAluna(presencaDto.AlunaCPF);
        var avaliacao = _avaliacaoService.ObterOuCriarAvaliacao(presencaDto.AlunaCPF, presencaDto.TurmaNumero);

        RegistroPresenca presenca = _mapper.Map<RegistroPresenca>(presencaDto);
        presenca.AvaliacaoId = avaliacao.Id;
        _context.Presencas.Add(presenca);
        _context.SaveChanges();
        return presenca;
    }
}
