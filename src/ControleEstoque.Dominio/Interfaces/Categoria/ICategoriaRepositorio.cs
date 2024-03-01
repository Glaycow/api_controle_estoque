using ControleEstoque.Dominio.ViewModelResults.Categoria;

namespace ControleEstoque.Dominio.Interfaces.Categoria;

public interface ICategoriaRepositorio : IEntityDataService<Classes.Categoria>
{
    Task<IEnumerable<CategoriaViewModelResults>> ObterListaCategoriaAsync();
    Task<CategoriaViewModelResults?> ObterCategoriaPorIdAsync(Guid id);
    
    Task<bool> ExisteCategoriaVinculoFornecedorAsync(Guid id);
    Task<bool> ExisteCategoriaVinculoProdutoAsync(Guid id);
}

