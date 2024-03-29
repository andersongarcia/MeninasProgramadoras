﻿using CsvHelper;
using CsvHelper.Configuration;
using MeninasProgramadorasAPI.Data.Dtos.Alunas;
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
public class PresencasController : ControllerBase
{
    private IPresencaService _presencaService;
    private ITurmaService _turmaService;
    private IAlunaService _alunaService;
    private TextInfo _textInfo;

    public PresencasController(IPresencaService presencaService, ITurmaService turmaService, IAlunaService alunaService, TextInfo textInfo)
    {
        _presencaService = presencaService;
        _turmaService = turmaService;
        _alunaService = alunaService;
        _textInfo = textInfo;
    }

    /// <summary>
    /// Listar todos os registros de presenças em aulas e monitorias
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IEnumerable<RegistroPresencaDto> Get()
    {
        return _presencaService.ObterPresencas();
    }

    /// <summary>
    /// Obter registro de presença em aula ou monitoria
    /// </summary>
    /// <param name="id">Id do registro de presença</param>
    /// <returns>Dados do registro de presença, se encontrado</returns>
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var presencaDto = _presencaService.ObterPresencasPorId(id);

        if (presencaDto == null) return NotFound();

        return Ok(presencaDto);
    }

    /// <summary>
    /// Registrar presença em aula ou monitoria
    /// </summary>
    /// <param name="presencaDto">Dados da aluna, da turma e do tipo de evento</param>
    /// <returns>Dados registrados</returns>
    [HttpPost]
    public IActionResult Create([FromBody] CreateRegistroPresencaDto presencaDto)
    {
        RegistroPresenca presenca = _presencaService.RegistrarPresenca(presencaDto);
        return CreatedAtAction(nameof(Get), new { id = presenca.Id }, presenca);
    }

    /// <summary>
    /// Remover registro de presença em aula ou monitoria
    /// </summary>
    /// <param name="id">Id do registro</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _presencaService.RemoverPresenca(id);
        return Ok();
    }

    /// <summary>
    /// Importar dados de registros de presença em aulas ou monitorias
    /// </summary>
    /// <param name="presencaDto">Arquivo CSV, número da turma e tipo de evento</param>
    /// <returns>Dados das presenças registradas com sucesso</returns>
    /// <exception cref="Exception"></exception>
    [HttpPost]
    [Route("importar")]
    public async Task<IEnumerable<RegistroPresencaDto>> ImportarPresencas([FromForm] ImportRegistroPresencaDto presencaDto)
    {
        var leituraLinhaCabecalho = false;
        ICollection<RegistroPresenca> presencasCadastradas = new List<RegistroPresenca>();
        var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };

        TurmaDto? turmaDto = _turmaService.ObterTurmaPorNumero(presencaDto.TurmaNumero);
        if (turmaDto == null)
            throw new Exception("Turma não cadastrada");

        if (presencaDto.File.Length > 0)
        {
            using (var reader = new StreamReader(presencaDto.File.OpenReadStream(), Encoding.GetEncoding("UTF-8")))
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
                                switch (presencaDto.TipoDeEvento)
                                {
                                    case TipoDeEvento.Aula:
                                        InserirAula(presencasCadastradas, turmaDto.Numero, alunaDto.CPF, csv, i);
                                        break;
                                    case TipoDeEvento.Monitoria:
                                        InserirMonitoria(presencasCadastradas, turmaDto.Numero, alunaDto.CPF, csv, i);
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

        return _presencaService.ObterPresencas(presencasCadastradas);
    }

    private void InserirAula(ICollection<RegistroPresenca> presencasCadastradas, int turmaNumero, string alunaCPF, CsvReader csv, int aula)
    {
        if (csv.GetField("AULA " + aula).Equals("VERDADEIRO"))
        {
            CreateRegistroPresencaDto createDto = new CreateRegistroPresencaDto()
            {
                AlunaCPF = alunaCPF,
                TurmaNumero = turmaNumero,
                TipoDeEvento = TipoDeEvento.Aula,
                NumeroEvento = aula
            };
            RegistroPresenca registroPresenca = _presencaService.RegistrarPresenca(createDto);
            presencasCadastradas.Add(registroPresenca);
        }
    }

    private void InserirMonitoria(ICollection<RegistroPresenca> presencasCadastradas, int turmaNumero, string alunaCPF, CsvReader csv, int semana)
    {
        try
        {
            int monitorias = int.Parse(csv.GetField("Semana " + semana));

            for (int i = 0; i < monitorias; i++)
            {
                CreateRegistroPresencaDto createDto = new CreateRegistroPresencaDto()
                {
                    AlunaCPF = alunaCPF,
                    TurmaNumero = turmaNumero,
                    TipoDeEvento = TipoDeEvento.Monitoria,
                    NumeroEvento = semana
                };
                RegistroPresenca registroPresenca = _presencaService.RegistrarPresenca(createDto);
                presencasCadastradas.Add(registroPresenca);
            }
        }
        catch (Exception)
        {
            return;
        }
    }
}
