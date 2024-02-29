using ControleEstoque.Dominio.Interfaces.Fornecedor;
using ControleEstoque.Dominio.ViewModelResults.Categoria;
using ControleEstoque.Dominio.ViewModelResults.Fornecedor;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Repositorio.Fornecedor;

public class FornecedorRepositorio(ControleEstoqueDbContext dbContext) : EntityDataService<Dominio.Classes.Fornecedor>(dbContext), IFornecedorRepositorio
{
    public  async Task<List<FornecedorViewModelResults>> ObterListaFornecedorAsync()
    {
        var listaFornecedor = await dbContext.Fornecedores
            .AsNoTracking()
            .Select(f => new FornecedorViewModelResults
            {
                Id = f.Id,
                Nome = f.Nome,
                Categorias = f.Categorias.Select(c => new CategoriaViewModelResults
                {
                    Nome = c.Categoria.Nome,
                    Id = c.CategoriaId
                }).ToList()
            }).ToListAsync();
        return listaFornecedor;
    }

    public Task<FornecedorViewModelResults> ObterFornecedorPorIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<FornecedorViewModelResults>> ObterFornecedorPorIdCategoriaAsync(Guid idCategoria)
    {
        throw new NotImplementedException();
    }
}