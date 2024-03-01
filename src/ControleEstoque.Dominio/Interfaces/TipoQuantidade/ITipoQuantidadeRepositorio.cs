using ControleEstoque.Dominio.ViewModelResults.TipoQuantidade;

namespace ControleEstoque.Dominio.Interfaces.TipoQuantidade;

public interface ITipoQuantidadeRepositorio : IEntityDataService<Classes.TipoQuantidade>
{
    Task<IEnumerable<TipoQuantidadeViewModelResults>> ObterListaTipoQuantidadeAsync();
    Task<TipoQuantidadeViewModelResults> ObterTipoQuantidadePorIdAsync(Guid id);
    Task<bool> ExisteTipoQuantidadeProdutoAsync(Guid id);
}