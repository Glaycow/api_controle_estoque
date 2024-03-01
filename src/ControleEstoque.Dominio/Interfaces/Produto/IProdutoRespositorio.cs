using ControleEstoque.Dominio.ViewModelResults.Produto;

namespace ControleEstoque.Dominio.Interfaces.Produto;

public interface IProdutoRepositorio : IEntityDataService<Classes.Produto>
{
    Task<List<ProdutoListaViewModelResults>> BuscarListaProdutosAsync();
    Task<ProdutoViewModelResults> BuscarProdutoPorIdAsync(Guid idProduto);
}