using AutoMapper;
using MeninasProgramadorasAPI.Data;
using MeninasProgramadorasAPI.Data.Dtos.Exercicios;
using MeninasProgramadorasAPI.Data.Dtos.Presencas;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Services.Impl;

public class ExercicioService : IExercicioService
{
    private AppDbContext _context;
    private IMapper _mapper;
    private IAvaliacaoService _avaliacaoService;
    private IAlunaService _alunaService;

    public ExercicioService(AppDbContext context, IMapper mapper, IAvaliacaoService avaliacaoService, IAlunaService alunaService)
    {
        _context = context;
        _mapper = mapper;
        _avaliacaoService = avaliacaoService;
        _alunaService = alunaService;
    }

    public ExercicioDto? ObterExercicioPorId(int id)
    {
        Exercicio? exercicio = _context.Exercicios.FirstOrDefault(exercicio => exercicio.Id == id);
        if (exercicio == null) return null;

        return _mapper.Map<ExercicioDto>(exercicio);
    }

    public IEnumerable<ExercicioDto> ObterExercicios()
    {
        return ObterExercicios(_context.Exercicios);
    }

    public IEnumerable<ExercicioDto> ObterExercicios(IEnumerable<Exercicio> exercicios)
    {
        return _mapper.Map<List<ExercicioDto>>(exercicios);
    }

    public Exercicio RegistrarExercicio(CreateExercicioDto exercicioDto)
    {
        _alunaService.ValidaAluna(exercicioDto.AlunaCPF);
        var avaliacao = _avaliacaoService.ObterOuCriarAvaliacao(exercicioDto.AlunaCPF, exercicioDto.TurmaNumero);

        Exercicio exercicio = _mapper.Map<Exercicio>(exercicioDto);
        exercicio.AvaliacaoId = avaliacao.Id;
        _context.Exercicios.Add(exercicio);
        _context.SaveChanges();
        return exercicio;
    }
}
