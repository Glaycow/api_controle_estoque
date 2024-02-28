using ControleEstoque.Dominio.Interfaces.Categoria;
using ControleEstoque.Infra.DbContexts;
using ControleEstoque.Infra.EFCore;

namespace ControleEstoque.Infra.Repositorio.Categoria;

public class CategoriaRepositorio(ControleEstoqueDbContext dbContext) : EntityDataService<Dominio.Classes.Categoria>(dbContext), ICategoriaRepositorio
{
    public async Task<IEnumerable<Dominio.Classes.Categoria>> ObterListaCategoriaAsync()
    {
        return await GetAll();
    }

    public async Task<Dominio.Classes.Categoria?> ObterCategoriaPorIdAsync(Guid id)
    {
        return await GetById(id);
    }
}