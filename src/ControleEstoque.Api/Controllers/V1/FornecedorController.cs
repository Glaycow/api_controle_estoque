using Asp.Versioning;
using ControleEstoque.Api.ViewModel.Fornecedor;
using ControleEstoque.Dominio.Interfaces.Fornecedor;
using ControleEstoque.Dominio.ViewModelResults.Fornecedor;
using ControleEstoque.Exception.CustomException;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Controllers.V1;

[ApiVersion(1.0)]
[ApiExplorerSettings(GroupName = "Fornecedor")]
public class FornecedorController(IFornecedorServico fornecedorService, IFornecedorRepositorio fornecedorRepositorio) : MainController
{
  private  readonly  IFornecedorServico _fornecedorService = fornecedorService;
  private  readonly  IFornecedorRepositorio _fornecedorRepositorio = fornecedorRepositorio;

  [HttpGet]
  [ProducesResponseType(typeof(List<FornecedorViewModelResults>), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> Get()
  {
    return  Ok(await _fornecedorRepositorio.ObterListaFornecedorAsync());
  }

  [HttpGet("{id:guid}")]
  [ProducesResponseType(typeof(FornecedorViewModelResults), StatusCodes.Status200OK)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> Get(Guid id)
  {
    return  Ok(await _fornecedorRepositorio.ObterFornecedorPorIdAsync(id));
  }
  
  [HttpPost]
  [ProducesResponseType(typeof(FornecedorViewModelResults), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
  public async Task<IActionResult> Post([FromBody] CadastroFornecedorViewModel fornecedor)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(GerarErrosValidacao(ModelState));
    }

    var fornecedorConversao = fornecedor.ConverterModel();
    var fornecedorDb = await _fornecedorService.CadastrarFornecedorAsync(fornecedorConversao);

    return CreatedAtAction(nameof(Get), new { id = fornecedorDb.Id }, fornecedorDb);
  }
}