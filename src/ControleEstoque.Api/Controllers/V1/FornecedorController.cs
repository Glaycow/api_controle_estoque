using Asp.Versioning;
using ControleEstoque.Api.CustomException;
using ControleEstoque.Api.ViewModel.Fornecedor;
using ControleEstoque.Dominio.Classes;
using ControleEstoque.Dominio.Interfaces.Fornecedor;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Controllers.V1;

[ApiVersion(1.0)]
[ApiExplorerSettings(GroupName = "Fornecedor")]
public class FornecedorController(IFornecedorServico fornecedorService, IFornecedorRepositorio fornecedorRepositorio) : MainController
{
  private  readonly  IFornecedorServico _fornecedorService = fornecedorService;
  private  readonly  IFornecedorRepositorio _fornecedorRepositorio = fornecedorRepositorio;

  [HttpPost]
  [ProducesResponseType(typeof(Fornecedor), StatusCodes.Status201Created)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
  [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
  public IActionResult Post([FromBody] CadastroFornecedorViewModel fornecedor)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(GerarErrosValidacao(ModelState));
    }

    return Ok();
  }
}