using ControleEstoque.Dominio.Interfaces.Categoria;
using ControleEstoque.Infra.EFCore;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.Repositorio.Categoria;

public class CategoriaRepositorio(DbContext dbContext) : EntityDataService<Dominio.Classes.Categoria>(dbContext), ICategoriaRepositorio
{
    public async Task<IEnumerable<Dominio.Classes.Categoria>> ObterListaCategoriaAsync()
    {
        return await GetAll();
    }

    public async Task<Dominio.Classes.Categoria> ObterListaCategoriaPorIdAsync(Guid id)
    {
        return await GetById(id);
    }
}