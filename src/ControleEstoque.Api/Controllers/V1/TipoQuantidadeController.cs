﻿using Asp.Versioning;
using AutoMapper;
using ControleEstoque.Api.CustomException;
using ControleEstoque.Api.ViewModel.TipoQuantidade;
using ControleEstoque.Dominio.Classes;
using ControleEstoque.Dominio.Enum;
using ControleEstoque.Dominio.Interfaces.TipoQuantidade;
using ControleEstoque.Mensagens;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Controllers.V1;

[ApiVersion(1.0)]
[ApiExplorerSettings(GroupName = "TipoQuantidade")]
public class TipoQuantidadeController(ITipoQuantidadeRepositorio tipoQuantidadeRepositorio, ITipoQuantidadeServico tipoQuantidadeServico, IMapper mapper)
    : MainController
{
    private readonly ITipoQuantidadeRepositorio _tipoQuantidadeRepositorio = tipoQuantidadeRepositorio;
    private readonly ITipoQuantidadeServico _tipoQuantidadeServico = tipoQuantidadeServico;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TipoLancamento>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var buscarListaTipoQuantidade = await _tipoQuantidadeRepositorio.ObterListaTipoQuantidadeAsync();
        return Ok(buscarListaTipoQuantidade);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(TipoQuantidade), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(Guid id)
    {
        var buscarTipoQuantidade = await _tipoQuantidadeRepositorio.ObterTipoQuantidadePorIdAsync(id);
        return Ok(buscarTipoQuantidade); 
    }

    [HttpPost]
    [ProducesResponseType(typeof(TipoQuantidade), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] CadastroTipoQuantidadeViewModel cadastroTipoQuantidade)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(GerarErrosValidacao(ModelState));
        }
        var salvarTipoQuantidade = await _tipoQuantidadeServico.CadastrarTipoQuantidadeAsync(_mapper.Map<TipoQuantidade>(cadastroTipoQuantidade));
        return CreatedAtAction(nameof(Get), new { id = salvarTipoQuantidade.Id }, salvarTipoQuantidade); 
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(TipoQuantidade), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(Guid id, [FromBody] AlterarTipoQuantidadeViewModel alterarTipoQuantidade)
    {
        if (id != alterarTipoQuantidade.Id)
        {
            ModelState.AddModelError("Id", MensagensValidacao.IdInvalido);
            return BadRequest(GerarErrosValidacao(ModelState));
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(GerarErrosValidacao(ModelState));
        }
        var atualizarTipoQuantidade = await _tipoQuantidadeServico.AlterarQuantidadeAsync(_mapper.Map<TipoQuantidade>(alterarTipoQuantidade));
        return Ok(atualizarTipoQuantidade);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _tipoQuantidadeServico.ApagarTipoQuantidadeAsync(id);
        return Ok(); 
    }
}