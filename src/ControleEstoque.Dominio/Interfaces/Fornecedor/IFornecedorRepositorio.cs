using ControleEstoque.Dominio.Model;

namespace ControleEstoque.Dominio.Interfaces.Fornecedor;

public interface IFornecedorRepositorio : IEntityDataService<Classes.Fornecedor>
{
    Task<List<FornecedorViewModel>> ObterListaFornecedorAsync();
    Task<FornecedorViewModel> ObterFornecedorPorIdAsync(Guid id);
    Task<List<FornecedorViewModel>> ObterFornecedorPorIdCategoriaAsync(Guid idCategoria);
}