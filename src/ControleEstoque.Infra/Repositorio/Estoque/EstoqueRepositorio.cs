using ControleEstoque.Dominio.Interfaces.Estoque;
using ControleEstoque.Dominio.ViewModelResults.Estoque;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Repositorio.Estoque;

public class EstoqueRepositorio(ControleEstoqueDbContext dbContext) : EntityDataService<Dominio.Classes.Estoque>(dbContext), IEstoqueRepositorio, IEstoqueGerenciamentoRepositorio
{
    public async Task<List<EstoqueViewModelResults>> BuscarListaEstoqueProdutoAsync(Guid produtoId, DateTime dataInicio, DateTime dataFim)
    {
        var estoques = await DbSet
            .AsNoTracking()
            .Select(estoque => new EstoqueViewModelResults
            {
                Id = estoque.Id,
                MesEstoque = estoque.MesEstoque,
                ProdutoId = estoque.ProdutoId,
                SaldoEstoque = estoque.SaldoEstoque
            })
            .Where(e => e.ProdutoId == produtoId && (e.MesEstoque >= dataInicio && e.MesEstoque <= dataFim))
            .ToListAsync();

        return estoques;
    }

    public async Task<EstoqueViewModelResults> BuscarEstoquePorIdAsync(Guid estoqueId)
    {
        var estoque = await DbSet
            .AsNoTracking()
            .Select(estoque => new EstoqueViewModelResults
            {
                Id = estoque.Id,
                MesEstoque = estoque.MesEstoque,
                ProdutoId = estoque.ProdutoId,
                SaldoEstoque = estoque.SaldoEstoque
            })
            .FirstAsync(e => e.Id == estoqueId);
        
        return estoque;
    }

    public Task<bool> ValidarEstoqueMesAsync(Guid idProduto, DateTime anoMesLancamento)
    {
        var validar = DbSet.AsNoTracking().AnyAsync(e => e.ProdutoId == idProduto && e.MesEstoque == anoMesLancamento);
        return validar;
    }
}
