﻿using AutoMapper;
using MeninasProgramadorasAPI.Data;
using MeninasProgramadorasAPI.Data.Dtos.Avaliacoes;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Services.Impl;

public class AvaliacaoService : IAvaliacaoService
{
    private AppDbContext _context;
    private IMapper _mapper;

    public AvaliacaoService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Avaliacao CriarAvaliacao(CreateAvaliacaoDto avaliacaoDto)
    {
        Avaliacao avaliacao = _mapper.Map<Avaliacao>(avaliacaoDto);
        _context.Avaliacoes.Add(avaliacao);
        _context.SaveChanges();
        return avaliacao;
    }

    public Avaliacao CriarAvaliacao(string alunaCPF, int turmaNumero)
    {
        return CriarAvaliacao(new CreateAvaliacaoDto()
        {
            AlunaCPF = alunaCPF,
            TurmaNumero = turmaNumero
        });
    }

    public AvaliacaoDto? ObterAvaliacaoPorId(int id)
    {
        Avaliacao? avaliacao = _context.Avaliacoes.FirstOrDefault(avaliacao => avaliacao.Id == id);
        if (avaliacao == null) return null;

        return _mapper.Map<AvaliacaoDto>(avaliacao);
    }

    public IEnumerable<AvaliacaoDto> ObterAvaliacoes()
    {
        return _mapper.Map<List<AvaliacaoDto>>(_context.Avaliacoes);
    }

    public Avaliacao ObterOuCriarAvaliacao(string alunaCPF, int turmaNumero)
    {
        var avaliacao = _context.Avaliacoes.FirstOrDefault(
            avaliacao =>
                avaliacao.AlunaCPF == alunaCPF
                &&
                avaliacao.TurmaNumero == turmaNumero);

        if (avaliacao == null)
        {
            avaliacao = CriarAvaliacao(alunaCPF, turmaNumero);
        }

        return avaliacao;
    }
}
