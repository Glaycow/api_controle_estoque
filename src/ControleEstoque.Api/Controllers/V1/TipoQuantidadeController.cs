using Asp.Versioning;
using ControleEstoque.Api.ViewModel.TipoQuantidade;
using ControleEstoque.Dominio.Interfaces.TipoQuantidade;
using ControleEstoque.Dominio.ViewModelResults.TipoQuantidade;
using ControleEstoque.Exception.CustomException;
using ControleEstoque.Mensagens;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Controllers.V1;

[ApiVersion(1.0)]
[ApiExplorerSettings(GroupName = "TipoQuantidade")]
public class TipoQuantidadeController(ITipoQuantidadeServico tipoQuantidadeServico, ITipoQuantidadeRepositorio tipoQuantidadeRepositorio)
    : MainController
{
    private readonly  ITipoQuantidadeServico _tipoQuantidadeServico = tipoQuantidadeServico;
    private readonly ITipoQuantidadeRepositorio _tipoQuantidadeRepositorio = tipoQuantidadeRepositorio;

    [HttpGet]
    [ProducesResponseType(typeof(List<TipoQuantidadeViewModelResults>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var listaTipoQuantidade = await _tipoQuantidadeRepositorio.ObterListaTipoQuantidadeAsync();
        return Ok(listaTipoQuantidade);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(TipoQuantidadeViewModelResults), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(Guid id)
    {
        var tipoQuantidade = await _tipoQuantidadeRepositorio.ObterTipoQuantidadePorIdAsync(id);
        return Ok(tipoQuantidade); 
    }

    [HttpPost]
    [ProducesResponseType(typeof(TipoQuantidadeViewModelResults), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] CadastroTipoQuantidadeViewModel tipoQuantidade)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(GerarErrosValidacao(ModelState));
        }
        var tipoQuantidadeCriado = await _tipoQuantidadeServico.CadastrarTipoQuantidadeAsync(tipoQuantidade.Converter());
        return CreatedAtAction(nameof(Get), new { id = tipoQuantidadeCriado.Id }, tipoQuantidadeCriado); 
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(TipoQuantidadeViewModelResults), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put(Guid id, [FromBody] AlterarTipoQuantidadeViewModel tipoQuantidade)
    {
        if (id != tipoQuantidade.Id)
        {
            ModelState.AddModelError("Id", MensagensValidacao.IdInvalido);
            return BadRequest(GerarErrosValidacao(ModelState));
        }
    
        if (!ModelState.IsValid)
        {
            return BadRequest(GerarErrosValidacao(ModelState));
        }
        var  tipoQuantidadeEditado = await _tipoQuantidadeServico.AlterarQuantidadeAsync(tipoQuantidade.Converter());
        return Ok(tipoQuantidadeEditado);
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