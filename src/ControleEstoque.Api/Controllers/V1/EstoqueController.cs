﻿using Asp.Versioning;
using ControleEstoque.Api.ViewModel.Estoque;
using ControleEstoque.Api.ViewModel.LancamentoEstoque;
using ControleEstoque.Dominio.Interfaces.Estoque;
using ControleEstoque.Dominio.LancamentoEstoque;
using ControleEstoque.Dominio.ViewModelResults.Estoque;
using ControleEstoque.Dominio.ViewModelResults.LancamentoEstoque;
using ControleEstoque.Exception.CustomException;
using ControleEstoque.Mensagens;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Controllers.V1;

[ApiVersion(1.0)]
[ApiExplorerSettings(GroupName = "Categoria")]
public class EstoqueController(
    IEstoqueServico estoqueServico,
    IEstoqueRepositorio estoqueRepositorio,
    ILancamentoEstoqueServico lancamentoEstoqueServico,
    ILancamentoEstoqueRepositorio lancamentoEstoqueRepositorio)
    : MainController
{
    private readonly IEstoqueServico _estoqueServico = estoqueServico;
    private readonly IEstoqueRepositorio _estoqueRepositorio = estoqueRepositorio;
    private readonly ILancamentoEstoqueServico _lancamentoEstoqueServico = lancamentoEstoqueServico;
    private readonly ILancamentoEstoqueRepositorio _lancamentoEstoqueRepositorio = lancamentoEstoqueRepositorio;

    [HttpGet]
    [ProducesResponseType(typeof(List<EstoqueViewModelResults>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get([FromQuery] EstoqueQueryViewModel query)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(GerarErrosValidacao(ModelState));
        }

        var estoques = await _estoqueRepositorio.BuscarListaEstoqueProdutoAsync(query.ProdutoId, query.DataInicio, query.DataFim);
        return Ok(estoques);
    }
    
    [HttpGet("lancamento-estoque")]
    [ProducesResponseType(typeof(List<LancamentoEstoqueViewModelResults>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ObterLancamentosEstoquePorProduto([FromQuery] LancamentoEstoqueQueryViewModel query)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(GerarErrosValidacao(ModelState));
        }

        var estoques = await _lancamentoEstoqueRepositorio.ObterTodosLancamentosEstoquePorProdutoDataLancamentoAsync(query.ProdutoId, query.DataLancamento);
        return Ok(estoques);
    }
    
    [HttpGet("lancamento-estoque/{id:guid}")]
    [ProducesResponseType(typeof(LancamentoEstoqueViewModelResults), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ObterLancamentosEstoquePorProduto(Guid id)
    {
        var estoques = await _lancamentoEstoqueRepositorio.ObteLancamentoEstoquePorIdAsync(id);
        return Ok(estoques);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(EstoqueViewModelResults), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(Guid id)
    {
        var estoque = await _estoqueRepositorio.BuscarEstoquePorIdAsync(id);
        return Ok(estoque);
    }

    [HttpPost("lancamento-estoque-entrada")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AdicionarLancamentoEstoque([FromBody] LancamentoEstoqueViewModel estoque)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(GerarErrosValidacao(ModelState));
        }

        var id = await _lancamentoEstoqueServico.AdicionarLancamentoEstoqueAsync(estoque.Converter());
        return Ok(id);
    }
    
    [HttpPost("lancamento-estoque-saida")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RetiradaLancamentoEstoque([FromBody] LancamentoEstoqueViewModel estoque)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(GerarErrosValidacao(ModelState));
        }

        var id = await _lancamentoEstoqueServico.RetiradaLancamentoEstoqueAsync(estoque.Converter());
        return Ok(id);
    }
    
    [HttpPost("lancamento-estoque/{id:guid}")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RetiradaLancamentoEstoque([FromBody] LancamentoEstoqueAlterarViewModel estoque, Guid id)
    {
        if (id != estoque.Id)
        {
            ModelState.AddModelError("Id", MensagensValidacao.IdInvalido);
            return BadRequest(GerarErrosValidacao(ModelState));
        }
        
        if (!ModelState.IsValid)
        {
            return BadRequest(GerarErrosValidacao(ModelState));
        }

        var idAlteracao = await _lancamentoEstoqueServico.AlterarLancamentoEstoqueAsync(estoque.Converter());
        return Ok(idAlteracao);
    }

    [HttpDelete("lancamento-estoque/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ExcluirLancamentoEstoque(Guid id)
    {
        await _lancamentoEstoqueServico.ApagarLancamentoEstoqueAsync(id);
        return Ok(); 
    }
}