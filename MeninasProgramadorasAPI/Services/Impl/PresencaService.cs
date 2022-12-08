using AutoMapper;
using MeninasProgramadorasAPI.Data;
using MeninasProgramadorasAPI.Data.Dtos.Presencas;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Services.Impl;

public class PresencaService : IPresencaService
{
    private AppDbContext _context;
    private IMapper _mapper;

    public PresencaService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<RegistroPresencaDto> ObterPresencas()
    {
        return _mapper.Map<List<RegistroPresencaDto>>(_context.Presencas);
    }

    public RegistroPresencaDto? ObterPresencasPorId(int id)
    {
        RegistroPresenca? presenca = _context.Presencas.FirstOrDefault(presenca => presenca.Id == id);
        if (presenca == null) return null;

        return _mapper.Map<RegistroPresencaDto>(presenca);
    }

    public RegistroPresenca RegistrarPresenca(CreateRegistroPresencaDto presencaDto)
    {
        var avaliacao = _context.Avaliacoes.FirstOrDefault(
            avaliacao => 
                avaliacao.AlunaCPF == presencaDto.AlunaCPF 
                && 
                avaliacao.TurmaNumero == presencaDto.TurmaNumero);

        if (avaliacao == null)
            throw new ArgumentNullException(nameof(avaliacao));

        RegistroPresenca presenca = _mapper.Map<RegistroPresenca>(presencaDto);
        presenca.AvaliacaoId = avaliacao.Id;
        _context.Presencas.Add(presenca);
        _context.SaveChanges();
        return presenca;
    }
}
