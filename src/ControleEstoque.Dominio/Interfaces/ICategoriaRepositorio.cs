using ControleEstoque.Dominio.Classes;

namespace ControleEstoque.Dominio.Interfaces;

public interface ICategoriaRepositorio : IEntityDataService<Categoria>
{
    Task<IEnumerable<Categoria>> ObterListaCategoriaAsync();
    Task<Categoria> ObterListaCategoriaPorIdAsync(Guid id);
}