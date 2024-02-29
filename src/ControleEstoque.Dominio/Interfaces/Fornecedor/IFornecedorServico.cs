using ControleEstoque.Dominio.ViewModelResults.Fornecedor;

namespace ControleEstoque.Dominio.Interfaces.Fornecedor;

public interface IFornecedorServico : IDisposable
{
    Task<FornecedorViewModelResults> CadastrarFornecedorAsync(Classes.Fornecedor fornecedor);
    Task<FornecedorViewModelResults> AlterarFornecedorAsync(Classes.Fornecedor fornecedor);
    Task ApagarFornecedorAsync(Guid id);
}