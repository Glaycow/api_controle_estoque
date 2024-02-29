using ControleEstoque.Dominio.Interfaces.Fornecedor;
using ControleEstoque.Dominio.ViewModelResults.Fornecedor;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;

namespace ControleEstoque.Infra.Repositorio.Fornecedor;

public class FornecedorRepositorio(ControleEstoqueDbContext dbContext) : EntityDataService<Dominio.Classes.Fornecedor>(dbContext), IFornecedorRepositorio
{
    public Task<List<FornecedorViewModelResults>> ObterListaFornecedorAsync()
    {
        throw new NotImplementedException();
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