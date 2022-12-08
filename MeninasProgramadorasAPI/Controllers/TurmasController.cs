using AutoMapper;
using MeninasProgramadorasAPI.Data;
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

    [HttpGet]
    public IEnumerable<TurmaDto> Get()
    {
        return _service.ObterTurmas();
    }

    [HttpGet("{numero}")]
    public IActionResult Get(int numero)
    {
        var turmaDto = _service.ObterTurmaPorNumero(numero);

        if (turmaDto == null) return NotFound();

        return Ok(turmaDto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateTurmaDto turmaDto)
    {
        Turma turma = _service.CriarTurma(turmaDto);
        return CreatedAtAction(nameof(Get), new { numero = turma.Numero }, turma);
    }

    // PUT api/<TurmasController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<TurmasController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
