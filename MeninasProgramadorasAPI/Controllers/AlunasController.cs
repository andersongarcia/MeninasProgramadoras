using AutoMapper;
using MeninasProgramadorasAPI.Data;
using MeninasProgramadorasAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeninasProgramadorasAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlunasController : ControllerBase
    {
        private AlunasContext _context;
        private IMapper _mapper;

        public AlunasController(AlunasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Aluna> Get()
        {
            return _context.Alunas;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlunasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
}
