using CsvHelper.Configuration;
using CsvHelper;
using MeninasProgramadorasAPI.Data.Dtos.Alunas;
using MeninasProgramadorasAPI.Data.Dtos.Exercicios;
using MeninasProgramadorasAPI.Data.Dtos.Presencas;
using MeninasProgramadorasAPI.Data.Dtos.Turmas;
using MeninasProgramadorasAPI.Exceptions;
using MeninasProgramadorasAPI.Models;
using MeninasProgramadorasAPI.Services;
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

    /// <summary>
    /// Listar exercícios, avaliações finais e avaliações de recuperação
    /// </summary>
    /// <returns>Lista de todos os exercícios, avaliações finais e avaliações de recuperação</returns>
    [HttpGet]
    public IEnumerable<ExercicioDto> Get()
    {
        return _exercicioService.ObterExercicios();
    }

    /// <summary>
    /// Obter exercício, avaliação final ou avaliação de recuperação
    /// </summary>
    /// <param name="id">Id do exercício</param>
    /// <returns>Dados do exercício</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var exercicioDto = _exercicioService.ObterExercicioPorId(id);

        if (exercicioDto == null) return NotFound();

        return Ok(exercicioDto);
    }

    /// <summary>
    /// Registrar exercício
    /// </summary>
    /// <param name="exercicioDto">Dados do exercício a ser registrado</param>
    /// <returns>Dados do exercício registrado</returns>
    [HttpPost]
    public IActionResult Create([FromBody] CreateExercicioDto exercicioDto)
    {
        Exercicio exercicio = _exercicioService.RegistrarExercicio(exercicioDto);
        return CreatedAtAction(nameof(Get), new { id = exercicio.Id }, exercicio);
    }

    /// <summary>
    /// Remover exercício
    /// </summary>
    /// <param name="id">Id do exercício</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _exercicioService.RemoverExercicio(id);
        return Ok();
    }

    /// <summary>
    /// Importar dados de exercícios, avaliação final ou avaliação de recuperação
    /// </summary>
    /// <param name="exercicioDto">Arquivo CSC, número da turma e tipo de exercício</param>
    /// <returns>Lista de exercícios cadastrados com sucesso</returns>
    /// <exception cref="Exception"></exception>
    [HttpPost]
    [Route("importar")]
    public async Task<IEnumerable<ExercicioDto>> ImportarExercicios([FromForm] ImportExercicioDto exercicioDto)
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
                            if (csv.GetField(0).StartsWith("beecrowd"))
                            {
                                csv.ReadHeader();
                                leituraLinhaCabecalho = true;
                            }
                            continue;
                        }

                        AlunaDto alunaDto = null;
                        if (csv.HeaderRecord.Contains("beecrowd id"))
                            alunaDto = _alunaService.ObterAlunaBeecrowdId(csv.GetField("beecrowd id"));
                        else if (csv.HeaderRecord.Contains("email"))
                            alunaDto = _alunaService.ObterAlunaPorEmail(csv.GetField("email"));

                        if (alunaDto == null) continue;

                        try
                        {
                            int total = int.Parse(csv.GetField("total_score")) / 100;
                            int resolvidos = int.Parse(csv.GetField("solved"));

                            CreateExercicioDto createDto = new CreateExercicioDto()
                            {
                                AlunaCPF = alunaDto.CPF,
                                TurmaNumero = exercicioDto.TurmaNumero,
                                TipoDeExercicio = exercicioDto.TipoDeExercicio,
                                Total = total,
                                Resolvidos = resolvidos
                            };

                            if(exercicioDto.TipoDeExercicio == TipoDeExercicio.Exercicio)
                            {
                                createDto.NumeroExercicio = exercicioDto.NumeroExercicio;
                            }
                            Exercicio exercicio = _exercicioService.RegistrarExercicio(createDto);
                            exerciciosCadastrados.Add(exercicio);
                        }
                        catch (AlunaNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
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