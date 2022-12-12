using CsvHelper;
using CsvHelper.Configuration;
using MeninasProgramadorasAPI.Data.Dtos.Alunas;
using MeninasProgramadorasAPI.Models;
using MeninasProgramadorasAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace MeninasProgramadorasAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class AlunasController : ControllerBase
{
    private IAlunaService _alunaService;
    private TextInfo _textInfo;

    public AlunasController(IAlunaService alunaService, TextInfo textInfo)
    {
        _alunaService = alunaService;
        _textInfo = textInfo;
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

    [HttpDelete()]
    public IActionResult Delete()
    {
        _alunaService.RemoverTodasAlunas();
        return Ok();
    }

    [HttpPost]
    [Route("importar")]
    public async Task<IEnumerable<AlunaDto>> ImportarAlunas(IFormFile file)
    {
        var leituraLinhaCabecalho = false;
        ICollection<Aluna> alunasCadastradas = new List<Aluna>();
        var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };

        if (file.Length > 0)
        {
            using (var reader = new StreamReader(file.OpenReadStream(), Encoding.GetEncoding("UTF-8")))
            using (var csv = new CsvReader(reader, config))
            {
                try
                {
                    while (csv.Read())
                    {
                        // Se ainda não leu o cabeçalho, verifica se está na linha do cabeçalho para leitura
                        // Caso contrário, segue para a próxima linha
                        if (!leituraLinhaCabecalho)
                        {
                            if (csv.GetField(0).StartsWith("CPF"))
                            {
                                csv.ReadHeader();
                                leituraLinhaCabecalho = true;
                            }
                            continue;
                        }

                        CreateAlunaDto alunaDto = new CreateAlunaDto()
                        {
                            CPF = csv.GetField("CPF").Trim(),
                            DataCadastro = DateTime.Now,
                            //PrimeiroNome = csv.GetField("PrimeiroNome").Trim(),
                            NomeCompleto = _textInfo.ToTitleCase(csv.GetField("NomeCompleto").Trim()),
                            Email = csv.GetField("Email").Trim(),
                            BeecrowdId = csv.GetField("BeecrowdId").Trim()
                        };
                        Aluna aluna = _alunaService.CriarAluna(alunaDto);
                        alunasCadastradas.Add(aluna);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        return _alunaService.ObterAlunas(alunasCadastradas);
    }
}
