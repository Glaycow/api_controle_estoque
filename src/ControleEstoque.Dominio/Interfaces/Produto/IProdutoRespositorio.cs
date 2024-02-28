namespace ControleEstoque.Dominio.Interfaces.Produto;

public interface IProdutoRepositorio : IEntityDataService<Classes.Produto>
{
    Task<List<Classes.Produto>> BuscarListaProdutosAsync();
    Task<Classes.Produto> BuscarProdutoPorIdAsync(Guid idProduto);
}