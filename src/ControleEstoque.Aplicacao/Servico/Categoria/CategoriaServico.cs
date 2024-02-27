using ControleEstoque.Dominio.Interfaces;
using ControleEstoque.Dominio.Interfaces.Categoria;
using ControleEstoque.Infra.EFCore;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Application.Servico.Categoria;

public class CategoriaServico(ICategoriaRepositorio categoriaRepositorio) : ICategoriaServico
{
    private readonly ICategoriaRepositorio _categoriaRepositorio = categoriaRepositorio;

    public async Task<Dominio.Classes.Categoria> AdicionarCategoriaAsync(Dominio.Classes.Categoria categoria)
    {
        return await _categoriaRepositorio.Add(categoria);
    }

    public async Task<Dominio.Classes.Categoria> AlterarCategoriaAsync(Dominio.Classes.Categoria categoria)
    {
        return await _categoriaRepositorio.Update(categoria);
    }

    public async Task ApagarCategoriaAsync(Guid id)
    {
        await _categoriaRepositorio.Delete(id);
    }
}

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