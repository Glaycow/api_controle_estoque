namespace ControleEstoque.Dominio.Interfaces.Categoria;

public interface ICategoriaRepositorio : IEntityDataService<Classes.Categoria>
{
    Task<IEnumerable<Classes.Categoria>> ObterListaCategoriaAsync();
    Task<Classes.Categoria> ObterListaCategoriaPorIdAsync(Guid id);
}

