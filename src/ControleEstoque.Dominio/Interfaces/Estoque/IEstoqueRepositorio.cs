using ControleEstoque.Dominio.ViewModelResults.Estoque;

namespace ControleEstoque.Dominio.Interfaces.Estoque;

public interface IEstoqueRepositorio: IEntityDataService<Classes.Estoque>
{
    Task<EstoqueViewModelResults?> BuscarListaEstoqueProdutoAsync(Guid produtoId);
    Task<EstoqueViewModelResults> BuscarEstoquePorIdAsync(Guid estoqueId);
    Task<DashboardMes> BuscarInfoDashboardAsync();
}