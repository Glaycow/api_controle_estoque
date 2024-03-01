using ControleEstoque.Dominio.ViewModelResults.TipoQuantidade;

namespace ControleEstoque.Dominio.Interfaces.TipoQuantidade;

public interface ITipoQuantidadeServico : IDisposable
{
    Task<TipoQuantidadeViewModelResults> CadastrarTipoQuantidadeAsync(Classes.TipoQuantidade tipoQuantidade);
    Task<TipoQuantidadeViewModelResults> AlterarQuantidadeAsync(Classes.TipoQuantidade tipoQuantidade);
    Task ApagarTipoQuantidadeAsync(Guid id);
}