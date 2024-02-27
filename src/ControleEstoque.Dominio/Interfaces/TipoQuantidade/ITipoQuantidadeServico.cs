namespace ControleEstoque.Dominio.Interfaces.TipoQuantidade;

public interface ITipoQuantidadeServico : IDisposable
{
    Task<Classes.TipoQuantidade> CadastrarTipoQuantidadeAsync(Classes.TipoQuantidade tipoQuantidade);
    Task<Classes.TipoQuantidade> AlterarQuantidadeAsync(Classes.TipoQuantidade tipoQuantidade);
    Task ApagarTipoQuantidadeAsync(Guid id);
}