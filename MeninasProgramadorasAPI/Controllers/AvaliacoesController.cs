using MeninasProgramadorasAPI.Data.Dtos.Avaliacoes;
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

        /// <summary>
        /// Listar avaliações
        /// </summary>
        /// <returns>Lista de avaliações</returns>
        [HttpGet]
        public IEnumerable<AvaliacaoDto> Get()
        {
            return _service.ObterAvaliacoes();
        }

        /// <summary>
        /// Obter avaliação por id
        /// </summary>
        /// <param name="id">Id da avaliação</param>
        /// <returns>Dados da avaliação, se encontrada</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var avaliacaoDto = _service.ObterAvaliacaoPorId(id);

            if (avaliacaoDto == null) return NotFound();

            return Ok(avaliacaoDto);
        }
    }
}
