using ControleEstoque.Dominio.Enum;
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

    public async Task<DashboardMes> BuscarInfoDashboardAsync()
    {
        var dashboardMes = new DashboardMes();
        var data = DateTime.Now;
        var primeiroDiaDoMes = new DateTime(data.Year, data.Month, 1);
        var ultimoDiaDoMes = primeiroDiaDoMes.AddMonths(1).AddDays(-1);
        var dashboard = await Db.LancamentoEstoques
            .AsNoTracking()
            .Where(e => e.DataLancamento >= primeiroDiaDoMes && e.DataLancamento <= ultimoDiaDoMes)
            .ToListAsync();
        foreach (var lancamentoEstoque in dashboard)
        {
            switch (lancamentoEstoque.TipoCadastro)
            {
                case TipoLancamento.Entrada:
                    dashboardMes.ValorEntrada += lancamentoEstoque.Valor;
                    break;
                case TipoLancamento.Saida:
                    dashboardMes.ValorSaida += lancamentoEstoque.Valor;
                    break;
            }
        }
        return dashboardMes;
    }

    public Task<bool> ValidarEstoqueMesAsync(Guid idProduto)
    {
        var validar = DbSet.AsNoTracking().AnyAsync(e => e.ProdutoId == idProduto);
        return validar;
    }
}
