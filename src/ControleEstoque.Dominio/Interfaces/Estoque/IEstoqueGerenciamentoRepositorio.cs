namespace ControleEstoque.Dominio.Interfaces.Estoque;

public interface IEstoqueGerenciamentoRepositorio : IDisposable
{
    Task<bool> ValidarEstoqueMesAsync(Guid idProduto, DateTime anoMesLancamento);
}