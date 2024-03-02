using ControleEstoque.Dominio.Interfaces;
using ControleEstoque.Dominio.ViewModelResults.LancamentoEstoque;

namespace ControleEstoque.Dominio.LancamentoEstoque;

public interface ILancamentoEstoqueRepositorio : IEntityDataService<Classes.LancamentoEstoque>
{
    Task<List<LancamentoEstoqueViewModelResults>> ObterTodosLancamentosEstoquePorProdutoDataLancamentoAsync(Guid idEstoque, DateTime dataLancamento);
    Task<LancamentoEstoqueViewModelResults> ObteLancamentoEstoquePorIdAsync(Guid idEstoque);
}