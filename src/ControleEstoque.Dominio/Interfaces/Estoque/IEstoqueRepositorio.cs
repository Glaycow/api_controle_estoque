using ControleEstoque.Dominio.ViewModelResults.Estoque;

namespace ControleEstoque.Dominio.Interfaces.Estoque;

public interface IEstoqueRepositorio: IEntityDataService<Classes.Estoque>
{
    Task<List<EstoqueViewModelResults>> BuscarListaEstoqueProdutoAsync(Guid produtoId, DateTime dataInicio, DateTime dataFim);
    Task<EstoqueViewModelResults> BuscarEstoquePorIdAsync(Guid estoqueId);
}