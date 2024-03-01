using ControleEstoque.Dominio.Interfaces.TipoQuantidade;
using ControleEstoque.Dominio.ViewModelResults.TipoQuantidade;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Repositorio.TipoQuantidade;

public class TipoQuantidadeRepositorio(ControleEstoqueDbContext dbContext) : EntityDataService<Dominio.Classes.TipoQuantidade>(dbContext), ITipoQuantidadeRepositorio
{
    public async Task<IEnumerable<TipoQuantidadeViewModelResults>> ObterListaTipoQuantidadeAsync()
    {
        return await DbSet
            .AsNoTracking()
            .Select(t => new TipoQuantidadeViewModelResults
            {
                Id = t.Id,
                Descricao = t.Descricao,
                Quantidade = t.Quantidade
            })
            .ToListAsync();
    }

    public async Task<TipoQuantidadeViewModelResults> ObterTipoQuantidadePorIdAsync(Guid id)
    {
        return await DbSet
            .AsNoTracking()
            .Select(t => new TipoQuantidadeViewModelResults
            {
                Id = t.Id,
                Descricao = t.Descricao,
                Quantidade = t.Quantidade
            })
            .Where(t => t.Id == id)
            .FirstAsync();
    }

    public async Task<bool> ExisteTipoQuantidadeProdutoAsync(Guid id)
    {
        return await Db.Produtos
            .AsNoTracking()
            .AnyAsync(x => x.TipoQuantidadeId == id);
    }
}