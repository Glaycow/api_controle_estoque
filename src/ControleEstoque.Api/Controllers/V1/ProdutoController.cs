using Asp.Versioning;
using ControleEstoque.Api.ViewModel.Produto;
using ControleEstoque.Dominio.Interfaces.Produto;
using ControleEstoque.Dominio.ViewModelResults.Produto;
using ControleEstoque.Exception.CustomException;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Api.Controllers.V1;

[ApiVersion(1.0)]
[ApiExplorerSettings(GroupName = "Produto")]
public class ProdutoController(IProdutoRepositorio produtoRepositorio, IProdutoServico produtoServico) : MainController
{
    private readonly IProdutoRepositorio _produtoRepositorio = produtoRepositorio;
    private readonly IProdutoServico _produtoServico = produtoServico;

    [HttpGet]
    [ProducesResponseType(typeof(List<ProdutoListaViewModelResults>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ListarProdutos()
    {
        var produtos = await _produtoRepositorio.BuscarListaProdutosAsync();
        return Ok(produtos);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ProdutoViewModelResults), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BuscarProdutoPorId(Guid id)
    {
        var  produto = await _produtoRepositorio.BuscarProdutoPorIdAsync(id);
        return Ok(produto);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProdutoViewModelResults), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CadastrarProduto([FromBody] CadastroProdutoViewModel produto)
    {
        var produtoCadastrado = await _produtoServico.CadastrarProdutoAsync(produto.Converter());
        return CreatedAtAction(nameof(BuscarProdutoPorId), new { id = produtoCadastrado.Id }, produtoCadastrado); 
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ProdutoViewModelResults), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AtualizarProduto([FromBody] AlterarProdutoViewModel produto, Guid id)
    {
        var produtoAtualizado = await _produtoServico.AlterarProdutoAsync(produto.Converter());
        return Ok(produtoAtualizado); 
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(ProdutoViewModelResults), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeletarProduto(Guid id)
    {
        await _produtoServico.ExcluirProdutoAsync(id);
        return Ok();
    }
}