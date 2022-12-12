using AutoMapper;
using MeninasProgramadorasAPI.Data;
using MeninasProgramadorasAPI.Data.Dtos.Turmas;
using MeninasProgramadorasAPI.Models;

namespace MeninasProgramadorasAPI.Services.Impl;

public class TurmaService : ITurmaService
{
    private AppDbContext _context;
    private IMapper _mapper;

    public TurmaService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Turma CriarTurma(CreateTurmaDto turmaDto)
    {
        Turma turma = _mapper.Map<Turma>(turmaDto);
        _context.Turmas.Add(turma);
        _context.SaveChanges();
        return turma;
    }

    public TurmaDto? ObterTurmaPorNumero(int numero)
    {
        Turma? turma = _context.Turmas.FirstOrDefault(turma => turma.Numero == numero);
        
        if (turma == null) return null;

        return _mapper.Map<TurmaDto>(turma);
    }

    public IEnumerable<TurmaDto> ObterTurmas()
    {
        return _mapper.Map<List<TurmaDto>>(_context.Turmas);
    }

    public void RemoverTurma(int numero)
    {
        Turma? turma = _context.Turmas.FirstOrDefault(turma => turma.Numero == numero);

        if (turma == null) return;

        _context.Turmas.Remove(turma);
    }
}
