using MeninasProgramadorasAPI.Data.Dtos.Avaliacoes;
using MeninasProgramadorasAPI.Models;
using MeninasProgramadorasAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeninasProgramadorasAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private IAvaliacaoService _service;

        public AvaliacoesController(IAvaliacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<AvaliacaoDto> Get()
        {
            return _service.ObterAvaliacoes();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var avaliacaoDto = _service.ObterAvaliacaoPorId(id);

            if (avaliacaoDto == null) return NotFound();

            return Ok(avaliacaoDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAvaliacaoDto avaliacaoDto)
        {
            Avaliacao avaliacao = _service.CriarAvaliacao(avaliacaoDto);
            return CreatedAtAction(nameof(Get), new { id = avaliacao.Id }, avaliacao);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AvaliacoesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
