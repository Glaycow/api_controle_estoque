using ControleEstoque.Dominio.Interfaces.Categoria;
using ControleEstoque.Dominio.ViewModelResults.Categoria;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Repositorio.Categoria;

public class CategoriaRepositorio(ControleEstoqueDbContext dbContext) : EntityDataService<Dominio.Classes.Categoria>(dbContext), ICategoriaRepositorio
{
    public async Task<IEnumerable<CategoriaViewModelResults>> ObterListaCategoriaAsync()
    {
        var listaCategoria = await DbSet
            .AsNoTracking()
            .Select(c => new CategoriaViewModelResults()
            {
                Id = c.Id,
                Nome = c.Nome
            })
            .ToListAsync();
        return listaCategoria;
    }

    public async Task<CategoriaViewModelResults?> ObterCategoriaPorIdAsync(Guid id)
    {
        var categoria = await DbSet
            .AsNoTracking()
            .Select(c => new CategoriaViewModelResults()
            {
                Id = c.Id,
                Nome = c.Nome
            })
            .Where(c => c.Id == id)
            .FirstAsync();
        return categoria;
    }

    public async Task<bool> ExisteCategoriaVinculoFornecedorAsync(Guid id)
    {
        return await Db.FornecedorCategoria
            .AsNoTracking()
            .AnyAsync(fc => fc.CategoriaId == id);
    }

    public async Task<bool> ExisteCategoriaVinculoProdutoAsync(Guid id)
    {
        return await Db.Produtos
            .AsNoTracking()
            .AnyAsync(p => p.CategoriaId == id);
    }
}