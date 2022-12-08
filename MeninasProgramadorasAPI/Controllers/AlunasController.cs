using MeninasProgramadorasAPI.Data.Dtos.Alunas;
using MeninasProgramadorasAPI.Models;
using MeninasProgramadorasAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeninasProgramadorasAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class AlunasController : ControllerBase
{
    private IAlunaService _alunaService;

    public AlunasController(IAlunaService alunaService)
    {
        _alunaService = alunaService;
    }

    [HttpGet]
    public IEnumerable<AlunaDto> Get()
    {
        return _alunaService.ObterAlunas();
    }

    [HttpGet("{cpf}")]
    public IActionResult Get(string cpf)
    {
        AlunaDto? alunaDto = _alunaService.ObterAlunaPorCPF(cpf);

        if(alunaDto == null) return NotFound();

        return Ok(alunaDto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateAlunaDto alunaDto)
    {
        Aluna aluna = _alunaService.CriarAluna(alunaDto);
        return CreatedAtAction(nameof(Get), new { cpf = aluna.CPF }, aluna);
    }

    // PUT api/<AlunasController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<AlunasController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
