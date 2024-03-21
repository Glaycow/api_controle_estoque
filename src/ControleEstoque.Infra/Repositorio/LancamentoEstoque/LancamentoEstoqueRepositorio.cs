using ControleEstoque.Dominio.Enum;
using ControleEstoque.Dominio.Interfaces.Produto;
using ControleEstoque.Dominio.LancamentoEstoque;
using ControleEstoque.Dominio.ViewModelResults.LancamentoEstoque;
using ControleEstoque.Exception.CustomException;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;
using ControleEstoque.Mensagens;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Repositorio.LancamentoEstoque;

public class LancamentoEstoqueRepositorio(ControleEstoqueDbContext dbContext, IProdutoRepositorio produtoRepositorio) : EntityDataService<Dominio.Classes.LancamentoEstoque>(dbContext), ILancamentoEstoqueRepositorio, ILancamentoEstoqueGerenciarRepositorio
{
    private readonly IProdutoRepositorio _produtoRepositorio = produtoRepositorio;
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

    public async Task<LancamentoEstoqueViewModelResults> ObteLancamentoEstoquePorIdAsync(Guid id)
    {
        var lancamentos = 
            await DbSet.AsNoTracking()
                .Where(l => l.Id == id)
                .Select(l => new LancamentoEstoqueViewModelResults
                {
                    Id = l.Id,
                    Quantidade = l.Quantidade,
                    Valor = l.Valor,
                    DataLancamento = l.DataLancamento,
                    EstoqueId = l.EstoqueId,
                    TipoLancamento = l.TipoCadastro
                })
                .FirstAsync();
        return lancamentos;
    }

    public async Task CadastrarLancamentoEstoqueComEstoqueDisponivelAsync(Dominio.Classes.LancamentoEstoque lancamentoEstoque)
    {
        await using var transaction = await Db.Database.BeginTransactionAsync();
        try
        {
            var estoque = await Db.Estoques.Where(e => e.ProdutoId == lancamentoEstoque.ProdutoId).FirstAsync();
            var produto = await _produtoRepositorio.BuscarProdutoPorIdAsync(lancamentoEstoque.ProdutoId);
            lancamentoEstoque.Quantidade = (produto.TipoQuantidade.Quantidade * lancamentoEstoque.Quantidade);
            estoque.SaldoEstoque += lancamentoEstoque.Quantidade;
            lancamentoEstoque.EstoqueId = estoque.Id;
            await DbSet.AddAsync(lancamentoEstoque);
            Db.Estoques.Update(estoque);
            await Db.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (System.Exception e)
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
            var cadastarEstoque = false;
            var produto = await _produtoRepositorio.BuscarProdutoPorIdAsync(lancamentoEstoque.ProdutoId);
            lancamentoEstoque.Quantidade = (produto.TipoQuantidade.Quantidade * lancamentoEstoque.Quantidade);
            var estoque = await Db.Estoques
                .Where(e => e.ProdutoId == lancamentoEstoque.ProdutoId)
                .FirstOrDefaultAsync();
            if (estoque == null)
            {
                estoque = new Dominio.Classes.Estoque
                {
                    ProdutoId = lancamentoEstoque.ProdutoId,
                    SaldoEstoque = lancamentoEstoque.Quantidade
                };
                cadastarEstoque = true;
            }
            else
            {
                estoque.SaldoEstoque += lancamentoEstoque.Quantidade;
            }

            if (cadastarEstoque)
            {
                await Db.Estoques.AddAsync(estoque);
            }
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
            var estoque = await Db.Estoques
                .Where(e => e.ProdutoId == lancamentoEstoque.ProdutoId)
                .FirstAsync();
            estoque.SaldoEstoque -= lancamentoEstoque.Quantidade;
            lancamentoEstoque.EstoqueId = estoque.Id;
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
            var estoque = await Db.Estoques
                .Where(e => e.ProdutoId == lancamentoEstoque.ProdutoId)
                .FirstAsync();
            var lancamentoEstoqueDb = await DbSet.Where(l => l.Id == lancamentoEstoque.Id).FirstAsync();
            lancamentoEstoqueDb.DataLancamento  = lancamentoEstoque.DataLancamento;
            lancamentoEstoqueDb.Quantidade = lancamentoEstoque.Quantidade;
            lancamentoEstoqueDb.Valor = lancamentoEstoque.Valor;
            if (lancamentoEstoque.Quantidade > lancamentoEstoqueDb.Quantidade)
            {
                estoque.SaldoEstoque += lancamentoEstoque.Quantidade - lancamentoEstoqueDb.Quantidade;
            }
            else if (lancamentoEstoque.Quantidade < lancamentoEstoqueDb.Quantidade)
            {
                estoque.SaldoEstoque -= lancamentoEstoqueDb.Quantidade - lancamentoEstoque.Quantidade;
            }

            if (lancamentoEstoque.TipoCadastro == TipoLancamento.Entrada)
            {
                var produto = await _produtoRepositorio.BuscarProdutoPorIdAsync(lancamentoEstoque.ProdutoId);
                lancamentoEstoqueDb.Quantidade = (produto.TipoQuantidade.Quantidade * lancamentoEstoque.Quantidade);
            }
            Db.Estoques.Update(estoque);
            DbSet.Entry(lancamentoEstoqueDb).State = EntityState.Modified;
            DbSet.Update(lancamentoEstoqueDb);
            await Db.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (System.Exception e)
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
            var lancamentoEstoqueDb = await DbSet.Where(l => l.Id == idLancamentoEstoque).FirstAsync();
            var estoque = await Db.Estoques
                .Where(e => e.Id == lancamentoEstoqueDb.EstoqueId)
                .FirstAsync();
            estoque.SaldoEstoque -= lancamentoEstoqueDb.Quantidade;
            Db.Estoques.Update(estoque);
            DbSet.Remove(lancamentoEstoqueDb);
            await Db.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (System.Exception e)
        {
            await transaction.RollbackAsync();
            throw new BadRequestException(MensagensValidacao.ErroExcluirLancamentoEstoque);
        }
    }
}