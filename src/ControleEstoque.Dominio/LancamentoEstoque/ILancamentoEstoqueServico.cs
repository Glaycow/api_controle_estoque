namespace ControleEstoque.Dominio.LancamentoEstoque;

public interface ILancamentoEstoqueServico : IDisposable
{
    Task<Guid> AdicionarLancamentoEstoqueAsync(Classes.LancamentoEstoque lancamentoEstoque);
    Task<Guid> RetiradaLancamentoEstoqueAsync(Classes.LancamentoEstoque lancamentoEstoque);
    Task<Guid> AlterarLancamentoEstoqueAsync(Classes.LancamentoEstoque lancamentoEstoque);
    Task ApagarLancamentoEstoqueAsync(Guid idLancamentoEstoque);
}