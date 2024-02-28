namespace ControleEstoque.Dominio.Interfaces.Estoque;

public interface IEstoqueRepositorio: IEntityDataService<Classes.Estoque>
{
    Task<List<Classes.Estoque>> BuscarListaEstoqueProdutoAsync(Guid produtoId);
    Task<Classes.Estoque> BuscarEstoquePorIdAsync(Guid estoqueId);
}