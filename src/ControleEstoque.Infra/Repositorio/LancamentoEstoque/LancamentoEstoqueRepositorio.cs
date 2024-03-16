using ControleEstoque.Dominio.LancamentoEstoque;
using ControleEstoque.Dominio.ViewModelResults.LancamentoEstoque;
using ControleEstoque.Exception.CustomException;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;
using ControleEstoque.Mensagens;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Repositorio.LancamentoEstoque;

public class LancamentoEstoqueRepositorio(ControleEstoqueDbContext dbContext) : EntityDataService<Dominio.Classes.LancamentoEstoque>(dbContext), ILancamentoEstoqueRepositorio, ILancamentoEstoqueGerenciarRepositorio
{
    public async Task<List<LancamentoEstoqueViewModelResults>> ObterTodosLancamentosEstoquePorProdutoDataLancamentoAsync(Guid idProduto, DateTime dataLancamento)
    {
        var primeiroDiaDoMes = new DateTime(dataLancamento.Year, dataLancamento.Month, 1);
        var ultimoDiaDoMes = primeiroDiaDoMes.AddMonths(1).AddDays(-1);
        var lancamentos = 
            await DbSet.AsNoTracking()
                .Include(l => l.Estoque)
                .Where(l => l.Estoque.ProdutoId == idProduto && l.DataLancamento >= primeiroDiaDoMes && l.DataLancamento <= ultimoDiaDoMes)
                .Select(l => new LancamentoEstoqueViewModelResults
                {
                    Id = l.Id,
                    Quantidade = l.Quantidade,
                    Valor = l.Valor,
                    DataLancamento = l.DataLancamento,
                    EstoqueId = l.EstoqueId,
                    TipoLancamento = l.TipoCadastro
                })
                .ToListAsync();
        return lancamentos;
    }

    public async Task<LancamentoEstoqueViewModelResults> ObteLancamentoEstoquePorIdAsync(Guid idEstoque)
    {
        var lancamentos = 
            await DbSet.AsNoTracking()
                .Select(l => new LancamentoEstoqueViewModelResults
                {
                    Id = l.Id,
                    Quantidade = l.Quantidade,
                    Valor = l.Valor,
                    DataLancamento = l.DataLancamento,
                    EstoqueId = l.EstoqueId,
                    TipoLancamento = l.TipoCadastro
                })
                .FirstAsync(l => l.EstoqueId == idEstoque);
        return lancamentos;
    }

    public async Task CadastrarLancamentoEstoqueComEstoqueDisponivelAsync(Dominio.Classes.LancamentoEstoque lancamentoEstoque)
    {
        await using var transaction = await Db.Database.BeginTransactionAsync();
        try
        {
            var estoque = await Db.Estoques.FirstAsync(e => e.ProdutoId == lancamentoEstoque.ProdutoId && e.MesEstoque == lancamentoEstoque.DataLancamento);
            estoque.SaldoEstoque += lancamentoEstoque.Quantidade;
            lancamentoEstoque.EstoqueId = lancamentoEstoque.Id;
            await DbSet.AddAsync(lancamentoEstoque);
            Db.Estoques.Update(estoque);
            await Db.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (System.Exception)
        {
            await transaction.RollbackAsync();
            throw new BadRequestException(MensagensValidacao.ErrorLancamentoEstoque);
        }
    }
    
    public async Task CadastrarLancamentoEstoqueSemEstoqueDisponivelAsync(Dominio.Classes.LancamentoEstoque lancamentoEstoque)
    {
        await using var transaction = await Db.Database.BeginTransactionAsync();
        try
        {
            var estoque = new Dominio.Classes.Estoque
            {
                MesEstoque = lancamentoEstoque.DataLancamento,
                ProdutoId = lancamentoEstoque.ProdutoId,
                SaldoEstoque = lancamentoEstoque.Quantidade
            };
            await Db.Estoques.AddAsync(estoque);
            lancamentoEstoque.EstoqueId = estoque.Id;
            await Db.LancamentoEstoques.AddAsync(lancamentoEstoque);
            await Db.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (System.Exception)
        {
            await transaction.RollbackAsync();
            throw new BadRequestException(MensagensValidacao.ErrorLancamentoEstoque);
        }
    }

    public async Task RetiradaLancamentoEstoque(Dominio.Classes.LancamentoEstoque lancamentoEstoque)
    {
        await using var transaction = await Db.Database.BeginTransactionAsync();
        try
        {
            var estoque = await Db.Estoques.FirstAsync(e => e.ProdutoId == lancamentoEstoque.ProdutoId && e.MesEstoque == lancamentoEstoque.DataLancamento);
            estoque.SaldoEstoque -= lancamentoEstoque.Quantidade;
            lancamentoEstoque.EstoqueId = lancamentoEstoque.Id;
            await DbSet.AddAsync(lancamentoEstoque);
            Db.Estoques.Update(estoque);
            await Db.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (System.Exception)
        {
            await transaction.RollbackAsync();
            throw new BadRequestException(MensagensValidacao.ErrorLancamentoEstoque);
        }
    }

    public async Task AlterarLancamentoEstoqueAsync(Dominio.Classes.LancamentoEstoque lancamentoEstoque)
    {
        await using var transaction = await Db.Database.BeginTransactionAsync();
        try
        {
            var estoque = await Db.Estoques.FirstAsync(e => e.ProdutoId == lancamentoEstoque.ProdutoId && e.MesEstoque == lancamentoEstoque.DataLancamento);
            var lancamentoEstoqueDb = await DbSet.FirstAsync(l => l.Id == lancamentoEstoque.Id);
            if (lancamentoEstoque.Quantidade > lancamentoEstoqueDb.Quantidade)
            {
                estoque.SaldoEstoque += lancamentoEstoque.Quantidade - lancamentoEstoqueDb.Quantidade;
            }
            else if (lancamentoEstoque.Quantidade < lancamentoEstoqueDb.Quantidade)
            {
                estoque.SaldoEstoque -= lancamentoEstoqueDb.Quantidade - lancamentoEstoque.Quantidade;
            }
            Db.Estoques.Update(estoque);
            DbSet.Update(lancamentoEstoque);
            await Db.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (System.Exception)
        {
            await transaction.RollbackAsync();
            throw new BadRequestException(MensagensValidacao.ErrorLancamentoEstoque);
        }
    }

    public async Task ExcluirLancamentoEstoqueAsync(Guid idLancamentoEstoque)
    {
        await using var transaction = await Db.Database.BeginTransactionAsync();
        try
        {
            var lancamentoEstoqueDb = await DbSet.FirstAsync(l => l.Id == idLancamentoEstoque);
            var primeiroDiaDoMes = new DateTime(lancamentoEstoqueDb.DataLancamento.Year, lancamentoEstoqueDb.DataLancamento.Month, 1);
            var ultimoDiaDoMes = primeiroDiaDoMes.AddMonths(1).AddDays(-1);
            var estoque = await Db.Estoques.FirstAsync(e => e.ProdutoId == lancamentoEstoqueDb.ProdutoId && e.MesEstoque >= primeiroDiaDoMes && e.MesEstoque <= ultimoDiaDoMes);
            estoque.SaldoEstoque -= lancamentoEstoqueDb.Quantidade;
            Db.Estoques.Update(estoque);
            DbSet.Remove(lancamentoEstoqueDb);
            await Db.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (System.Exception)
        {
            await transaction.RollbackAsync();
            throw new BadRequestException(MensagensValidacao.ErroExcluirLancamentoEstoque);
        }
    }
}