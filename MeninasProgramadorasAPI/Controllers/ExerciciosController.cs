using CsvHelper.Configuration;
using CsvHelper;
using MeninasProgramadorasAPI.Data.Dtos.Alunas;
using MeninasProgramadorasAPI.Data.Dtos.Exercicios;
using MeninasProgramadorasAPI.Data.Dtos.Presencas;
using MeninasProgramadorasAPI.Data.Dtos.Turmas;
using MeninasProgramadorasAPI.Exceptions;
using MeninasProgramadorasAPI.Models;
using MeninasProgramadorasAPI.Services;
using MeninasProgramadorasAPI.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace MeninasProgramadorasAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class ExerciciosController : ControllerBase
{
    private IExercicioService _exercicioService;
    private ITurmaService _turmaService;
    private IAlunaService _alunaService;
    private TextInfo _textInfo;

    public ExerciciosController(IExercicioService exercicioService, ITurmaService turmaService, IAlunaService alunaService, TextInfo textInfo)
    {
        _exercicioService = exercicioService;
        _turmaService = turmaService;
        _alunaService = alunaService;
        _textInfo = textInfo;
    }

    [HttpGet]
    public IEnumerable<ExercicioDto> Get()
    {
        return _exercicioService.ObterExercicios();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var exercicioDto = _exercicioService.ObterExercicioPorId(id);

        if (exercicioDto == null) return NotFound();

        return Ok(exercicioDto);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateExercicioDto exercicioDto)
    {
        Exercicio exercicio = _exercicioService.RegistrarExercicio(exercicioDto);
        return CreatedAtAction(nameof(Get), new { id = exercicio.Id }, exercicio);
    }

    // PUT api/<ExerciciosController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ExerciciosController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }

    [HttpPost]
    [Route("importar")]
    public async Task<IEnumerable<ExercicioDto>> ImportarPresencas([FromForm] ImportExercicioDto exercicioDto)
    {
        var leituraLinhaCabecalho = false;
        ICollection<Exercicio> exerciciosCadastrados = new List<Exercicio>();
        var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };

        TurmaDto? turmaDto = _turmaService.ObterTurmaPorNumero(exercicioDto.TurmaNumero);
        if (turmaDto == null)
            throw new Exception("Turma não cadastrada");

        if (exercicioDto.File.Length > 0)
        {
            using (var reader = new StreamReader(exercicioDto.File.OpenReadStream(), Encoding.GetEncoding("UTF-8")))
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
                            if (csv.GetField(0).StartsWith("NOME"))
                            {
                                csv.ReadHeader();
                                leituraLinhaCabecalho = true;
                            }
                            continue;
                        }

                        AlunaDto alunaDto = null;
                        if (csv.HeaderRecord.Contains("CPF"))
                            alunaDto = _alunaService.ObterAlunaPorCPF(csv.GetField("CPF"));
                        else if (csv.HeaderRecord.Contains("NOME"))
                            alunaDto = _alunaService.ObterAlunaPorNome(csv.GetField("NOME"));

                        if (alunaDto == null) continue;

                        // Lê presença em aula/monitoria para cada semana
                        for (int i = 1; i <= turmaDto.TotalSemanas; i++)
                        {
                            try
                            {
                                switch (exercicioDto.TipoDeExercicio)
                                {
                                    case TipoDeExercicio.Exercicio:
                                        break;
                                    case TipoDeExercicio.AvaliacaoFinal:
                                        break;
                                }
                            }
                            catch (AlunaNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        return _exercicioService.ObterExercicios(exerciciosCadastrados);
    }
}
