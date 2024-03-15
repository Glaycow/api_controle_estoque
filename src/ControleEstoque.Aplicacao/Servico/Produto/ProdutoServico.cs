using ControleEstoque.Dominio.Interfaces.Produto;
using ControleEstoque.Dominio.ViewModelResults.Produto;

namespace ControleEstoque.Application.Servico.Produto;

public class ProdutoServico(IProdutoRepositorio produtoRepositorio) : IProdutoServico
{
    private readonly  IProdutoRepositorio _produtoRepositorio = produtoRepositorio;

    public void Dispose()
    {
        _produtoRepositorio.Dispose();
    }

    public async Task<ProdutoViewModelResults> CadastrarProdutoAsync(Dominio.Classes.Produto produto)
    {
        await _produtoRepositorio.Add(produto);
        return new ProdutoViewModelResults(produto);
    }

    public async Task<ProdutoViewModelResults> AlterarProdutoAsync(Dominio.Classes.Produto produto)
    {
        await _produtoRepositorio.Update(produto);
        return new ProdutoViewModelResults(produto);
    }

    public async Task ExcluirProdutoAsync(Guid idProduto)
    {
        await  _produtoRepositorio.Delete(idProduto);
    }
}