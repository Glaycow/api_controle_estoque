using Asp.Versioning;
using AutoMapper;
using ControleEstoque.Api.CustomException;
using ControleEstoque.Api.ViewModel.Fornecedor;
using ControleEstoque.Dominio.Classes;
using ControleEstoque.Dominio.Interfaces.Fornecedor;
using ControleEstoque.Dominio.Model;
using ControleEstoque.Mensagens;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Controllers.V1;

[ApiVersion(1.0)]
[ApiExplorerSettings(GroupName = "Fornecedor")]
public class FornecedorController(IFornecedorRepositorio fornecedorRepositorio, IFornecedorServico fornecedorServico, IMapper mapper)
    : MainController
{
    private readonly IFornecedorRepositorio _fornecedorRepositorio = fornecedorRepositorio;
    private readonly IFornecedorServico _fornecedorServico = fornecedorServico;
    private readonly IMapper _mapper = mapper;


    [HttpGet]
    [ProducesResponseType(typeof(List<FornecedorViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var fornecedor = await _fornecedorRepositorio.ObterListaFornecedorAsync();
        return  Ok(fornecedor);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FornecedorViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BuscarFornecedorPorId(Guid id)
    {
        var fornecedor = await _fornecedorRepositorio.ObterFornecedorPorIdAsync(id);
        return  Ok(fornecedor);
    }


    [HttpPost]
    [ProducesResponseType(typeof(FornecedorViewModel), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] CadastroFornecedorViewModel fornecedor)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(GerarErrosValidacao(ModelState));
        }
        var fornecedorDomain = _mapper.Map<Fornecedor>(fornecedor);
        var fornecedorRetorno = await _fornecedorServico.CadastrarFornecedorAsync(fornecedorDomain);
        return CreatedAtAction(nameof(BuscarFornecedorPorId), new { id = fornecedorRetorno.Id }, fornecedorRetorno);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(Fornecedor), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(Guid id, [FromBody] AlterarFornecedorViewModel fornecedor)
    {
        if (id != fornecedor.Id)
        {
            ModelState.AddModelError("Id", MensagensValidacao.IdInvalido);
            return BadRequest(GerarErrosValidacao(ModelState));
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(GerarErrosValidacao(ModelState));
        }
        var fornecedorDomain = _mapper.Map<Fornecedor>(fornecedor);
        var fornecedorRetorno = await _fornecedorServico.AlterarFornecedorAsync(fornecedorDomain);
        return Ok(fornecedorRetorno); 
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _fornecedorServico.ApagarFornecedorAsync(id);
        return Ok();
    }
}