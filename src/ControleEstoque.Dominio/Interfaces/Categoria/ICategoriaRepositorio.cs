namespace ControleEstoque.Dominio.Interfaces.Categoria;

public interface ICategoriaRepositorio : IEntityDataService<Classes.TipoProduto>
{
    Task<IEnumerable<Classes.TipoProduto>> ObterListaCategoriaAsync();
    Task<Classes.TipoProduto?> ObterCategoriaPorIdAsync(Guid id);
}

