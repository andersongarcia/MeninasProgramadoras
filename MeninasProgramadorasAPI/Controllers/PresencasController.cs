using MeninasProgramadorasAPI.Data.Dtos.Presencas;
using MeninasProgramadorasAPI.Models;
using MeninasProgramadorasAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MeninasProgramadorasAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class PresencasController : ControllerBase
{
    private IPresencaService _service;

    public PresencasController(IPresencaService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<RegistroPresencaDto> Get()
    {
        return _service.ObterPresencas();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var presencaDto = _service.ObterPresencasPorId(id);

        if (presencaDto == null) return NotFound();

        return Ok(presencaDto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateRegistroPresencaDto presencaDto)
    {
        RegistroPresenca presenca = _service.RegistrarPresenca(presencaDto);
        return CreatedAtAction(nameof(Get), new { id = presenca.Id }, presenca);
    }

    // PUT api/<PresencasController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<PresencasController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
