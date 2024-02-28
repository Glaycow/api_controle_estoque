namespace ControleEstoque.Dominio.Interfaces.Fornecedor;

public interface IFornecedorServico : IDisposable
{
    Task<Classes.Fornecedor> CadastrarFornecedorAsync(Classes.Fornecedor fornecedor);
    Task<Classes.Fornecedor> AlterarFornecedorAsync(Classes.Fornecedor fornecedor);
    Task ApagarFornecedorAsync(Guid id);
}