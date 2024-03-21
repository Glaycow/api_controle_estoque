using ControleEstoque.Dominio.Interfaces.Estoque;
using ControleEstoque.Dominio.ViewModelResults.Estoque;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Repositorio.Estoque;

public class EstoqueRepositorio(ControleEstoqueDbContext dbContext) : EntityDataService<Dominio.Classes.Estoque>(dbContext), IEstoqueRepositorio, IEstoqueGerenciamentoRepositorio
{
    public async Task<EstoqueViewModelResults?> BuscarListaEstoqueProdutoAsync(Guid produtoId)
    {
        var estoques = await DbSet
            .AsNoTracking()
            .Select(estoque => new EstoqueViewModelResults
            {
                Id = estoque.Id,
                ProdutoId = estoque.ProdutoId,
                SaldoEstoque = estoque.SaldoEstoque
            })
            .Where(e => e.ProdutoId == produtoId)
            .FirstOrDefaultAsync();

        return estoques;
    }

    public async Task<EstoqueViewModelResults> BuscarEstoquePorIdAsync(Guid estoqueId)
    {
        var estoque = await DbSet
            .AsNoTracking()
            .Select(estoque => new EstoqueViewModelResults
            {
                Id = estoque.Id,
                ProdutoId = estoque.ProdutoId,
                SaldoEstoque = estoque.SaldoEstoque
            })
            .FirstAsync(e => e.Id == estoqueId);
        
        return estoque;
    }

    public Task<bool> ValidarEstoqueMesAsync(Guid idProduto)
    {
        var validar = DbSet.AsNoTracking().AnyAsync(e => e.ProdutoId == idProduto);
        return validar;
    }
}
