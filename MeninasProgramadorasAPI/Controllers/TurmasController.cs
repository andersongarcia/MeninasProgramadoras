using MeninasProgramadorasAPI.Data.Dtos.Turmas;
using MeninasProgramadorasAPI.Models;
using MeninasProgramadorasAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeninasProgramadorasAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class TurmasController : ControllerBase
{
    private ITurmaService _service;

    public TurmasController(ITurmaService service)
    {
        _service = service;
    }

    /// <summary>
    /// Listar todas as turmas
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<TurmaDto> Get()
    {
        return _service.ObterTurmas();
    }

    /// <summary>
    /// Obter turma pelo número
    /// </summary>
    /// <param name="numero">Número da turma</param>
    /// <returns>Dados da turma, se encontrada</returns>
    [HttpGet("{numero}")]
    public IActionResult Get(int numero)
    {
        var turmaDto = _service.ObterTurmaPorNumero(numero);

        if (turmaDto == null) return NotFound();

        return Ok(turmaDto);
    }

    /// <summary>
    /// Criar turma
    /// </summary>
    /// <param name="turmaDto">Dados da turma a ser criada</param>
    /// <returns>Dados da turma</returns>
    [HttpPost]
    public IActionResult Create([FromBody] CreateTurmaDto turmaDto)
    {
        Turma turma = _service.CriarTurma(turmaDto);
        return CreatedAtAction(nameof(Get), new { numero = turma.Numero }, turma);
    }

    /// <summary>
    /// Remover turma
    /// </summary>
    /// <param name="numero">Número da turma</param>
    [HttpDelete("{numero}")]
    public IActionResult Delete(int numero)
    {
        _service.RemoverTurma(numero);
        return Ok();
    }
}
