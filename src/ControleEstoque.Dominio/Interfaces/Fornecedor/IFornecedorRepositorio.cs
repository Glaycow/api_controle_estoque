using ControleEstoque.Dominio.ViewModelResults.Fornecedor;

namespace ControleEstoque.Dominio.Interfaces.Fornecedor;

public interface IFornecedorRepositorio : IEntityDataService<Classes.Fornecedor>
{
    Task<List<FornecedorViewModelResults>> ObterListaFornecedorAsync();
    Task<FornecedorViewModelResults> ObterFornecedorPorIdAsync(Guid id);
    Task<List<FornecedorViewModelResults>> ObterFornecedorPorIdCategoriaAsync(Guid idCategoria);
}