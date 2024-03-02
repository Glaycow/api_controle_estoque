namespace ControleEstoque.Dominio.LancamentoEstoque;

public interface ILancamentoEstoqueGerenciarRepositorio : IDisposable
{
    Task CadastrarLancamentoEstoqueComEstoqueDisponivelAsync(Classes.LancamentoEstoque lancamentoEstoque);
    Task CadastrarLancamentoEstoqueSemEstoqueDisponivelAsync(Classes.LancamentoEstoque lancamentoEstoque);
    Task RetiradaLancamentoEstoque(Classes.LancamentoEstoque lancamentoEstoque);
    Task AlterarLancamentoEstoqueAsync(Classes.LancamentoEstoque lancamentoEstoque);
    Task ExcluirLancamentoEstoqueAsync(Guid idLancamentoEstoque);
}