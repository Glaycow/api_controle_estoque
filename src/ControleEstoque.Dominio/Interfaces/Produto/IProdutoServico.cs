using ControleEstoque.Dominio.ViewModelResults.Produto;

namespace ControleEstoque.Dominio.Interfaces.Produto;

public interface IProdutoServico : IDisposable
{
    Task<ProdutoViewModelResults> CadastrarProdutoAsync(Classes.Produto produto);
    Task<ProdutoViewModelResults> AlterarProdutoAsync(Classes.Produto produto);
    Task ExcluirProdutoAsync(Guid idProduto);
}