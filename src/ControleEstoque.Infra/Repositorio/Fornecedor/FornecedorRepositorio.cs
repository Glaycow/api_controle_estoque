using ControleEstoque.Dominio.Interfaces.Fornecedor;
using ControleEstoque.Dominio.Model;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Repositorio.Fornecedor;

public class FornecedorRepositorio(ControleEstoqueDbContext dbContext) : EntityDataService<Dominio.Classes.Fornecedor>(dbContext), IFornecedorRepositorio
{
    public async Task<List<FornecedorViewModel>> ObterListaFornecedorAsync()
    {
        var listaFornecedor = await dbContext.Fornecedores
            .AsNoTracking()
            .Select(f => new FornecedorViewModel
            {
                Id = f.Id,
                Nome = f.Nome,
                Categoria = f.FornecedorCategoria.Select(c => new CategoriaViewModel
                {
                    Id = c.Id,
                    Nome = c.Categoria.Nome
                }).ToList()
            }).ToListAsync();
        return listaFornecedor;
    }

    public async Task<FornecedorViewModel> ObterFornecedorPorIdAsync(Guid id)
    {
        return await dbContext.Fornecedores
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(f => new FornecedorViewModel
            {
                Id = f.Id,
                Nome = f.Nome,
                Categoria = f.FornecedorCategoria.Select(c => new CategoriaViewModel
                {
                    Id = c.Id,
                    Nome = c.Categoria.Nome
                }).ToList()
            })
            .FirstAsync();
    }

    public async Task<List<Dominio.Classes.Fornecedor>> ObterFornecedorPorIdCategoriaAsync(Guid idCategoria)
    {
        return await dbContext.Fornecedores
            .AsNoTracking()
            .Where(x => x.FornecedorCategoria.Any(c => c.Categoria.Id == idCategoria))
            .Select(f => new Dominio.Classes.Fornecedor()
            {
                Id = f.Id,
                Nome = f.Nome,
                FornecedorCategoria = f.FornecedorCategoria.Select(c => new Dominio.Classes.FornecedorCategoria()
                {
                    Id = c.Id,
                    Categoria = new Dominio.Classes.Categoria() {Id = c.Categoria.Id}
                }).ToList()
            })
            .ToListAsync();
    }
}