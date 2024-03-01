using ControleEstoque.Dominio.Interfaces.Produto;
using ControleEstoque.Dominio.ViewModelResults.Categoria;
using ControleEstoque.Dominio.ViewModelResults.Fornecedor;
using ControleEstoque.Dominio.ViewModelResults.Produto;
using ControleEstoque.Dominio.ViewModelResults.TipoQuantidade;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Repositorio.Produto;

public class ProdutoRepositorio(ControleEstoqueDbContext dbContext) : EntityDataService<Dominio.Classes.Produto>(dbContext), IProdutoRepositorio
{
    public async Task<List<ProdutoListaViewModelResults>> BuscarListaProdutosAsync()
    {
        var produtos = await 
            DbSet
                .Include(p => p.Categoria)
                .Include(p => p.Fornecedor)
                .Include(p => p.TipoQuantidade)
                .Select(p => new ProdutoListaViewModelResults
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    NomeCategoria = p.Categoria.Nome,
                    NomeFornecedor = p.Fornecedor.Nome,
                    TipoQuantidade = p.TipoQuantidade.Descricao,
                    ValorTipoQuantidade = p.TipoQuantidade.Quantidade
                })
                .AsNoTracking()
                .ToListAsync();

        return produtos;
    }

    public async Task<ProdutoViewModelResults> BuscarProdutoPorIdAsync(Guid idProduto)
    {
        var produto = await 
            DbSet
                .AsNoTracking()
                .Include(p => p.Categoria)
                .Include(p => p.Fornecedor)
                .Include(p => p.TipoQuantidade)
                .Select(p => new ProdutoViewModelResults
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Fornecedor = new FornecedorViewModelResults
                    {
                        Id = p.Fornecedor.Id,
                        Nome= p.Fornecedor.Nome,
                    },
                    TipoQuantidade = new TipoQuantidadeViewModelResults
                    {
                        Id = p.TipoQuantidade.Id,
                        Descricao = p.TipoQuantidade.Descricao,
                        Quantidade = p.TipoQuantidade.Quantidade
                    },
                    Categoria = new CategoriaViewModelResults
                    {
                        Id = p.Categoria.Id,
                        Nome = p.Categoria.Nome,
                    }
                })
                .FirstAsync(p => p.Id == idProduto);

        return produto;
    }
}