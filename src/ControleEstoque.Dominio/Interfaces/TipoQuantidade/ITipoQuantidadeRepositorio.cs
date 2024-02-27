namespace ControleEstoque.Dominio.Interfaces.TipoQuantidade;

public interface ITipoQuantidadeRepositorio : IEntityDataService<Classes.TipoQuantidade>
{
    Task<IEnumerable<Classes.TipoQuantidade>> ObterListaTipoQuantidadeAsync();
    Task<Classes.TipoQuantidade> ObterTipoQuantidadePorIdAsync(Guid id);
}